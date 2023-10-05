using ControleEstoque.API.ProblemDetailsModels;
using ControleEstoque.App.Interface;
using ControleEstoque.App.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace ControleEstoque.API.Controllers.Base
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

        protected ActionResult FalhaNaRequisicao(object result = null)
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
        protected ActionResult FalhaNaRequisicao()
        {
            var errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem);
            return BadRequest(new CustomProblemDetails(System.Net.HttpStatusCode.BadRequest,"erro de validacao", errors));
        }
        
        //falha de requisição ao adicionar objeto
        protected ActionResult IdInvalido(string objeto, int id)
        { 
             return BadRequest(new CustomBadRequest($"O {objeto} com id: {id} é inválido e não foi encontrado", Request));
        }

        //retorna mensagem de não encontrado
        protected ActionResult Criado(int id, Object obj)
        {
            return Created(Request.Path +"/"+ id,obj);
        }


        //retorna mensagem de não encontrado
        protected ActionResult NaoEncontrado(int id)
        {           
            return NotFound(new CustomNotFound($" Registro com id : {id} não encontrado", Request));         
        }

        protected ActionResult Resposta(ModelStateDictionary modelState)
        {
            if(!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return FalhaNaRequisicao();
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
