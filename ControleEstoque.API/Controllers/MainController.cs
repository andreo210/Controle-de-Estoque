using System;
using System.Linq;
using ControleEstoque.API.Config;
using ControleEstoque.App.Notificacoes;
using ControleEstoque.App.Notificacoes.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ControleEstoque.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;
        public readonly IUser AppUser;

        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        protected MainController(INotificador notificador, 
                                 IUser appUser)
        {
            _notificador = notificador;
            AppUser = appUser;

            if (appUser.IsAuthenticated())
            {
                UsuarioId = appUser.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult Resposta(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(result);
            }            

            return BadRequest(new
            {               
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }
        protected ActionResult Resposta()
        {
            var errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem);
            return BadRequest(new CustomProblemDetails(System.Net.HttpStatusCode.BadRequest,"erro de validacao", errors));
        }
        protected ActionResult FalhaRequisicao(string objeto, int id)
        { 
             return BadRequest(new BadRequestProblemDetails($"O {objeto} com id: {id} é invalido e não foi encontrado", Request));
        }

        protected ActionResult NaoEncontrado(int id=0)
        {           
            return NotFound(new ObjetoNotFoundProblemDetails($" Registro com {id} não encontrado", Request));         
        }

        protected ActionResult Resposta(ModelStateDictionary modelState)
        {
            if(!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return Resposta();
        }


        //1 cria metodo notificar erro
        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        //2 coloca o erro na lista
        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
