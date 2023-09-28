using ControleEstoque.API.Config;
using ControleEstoque.API.Helpers;
using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.LocalArmazenamento;
using ControleEstoque.App.Models.Views;
using ControleEstoque.App.Notificacoes.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")/*,Deprecated =true)*/]
    [ApiVersion("2.1")]
    public class LocalArmazenamentoController : MainController
    { //
        ILocalArmazenamentoHandlers localArmazenamentoHadlers;
        public LocalArmazenamentoController(ILocalArmazenamentoHandlers _localArmazenamentoHadlers, INotificador notificador, IUser user) : base(notificador, user)
        {
            this.localArmazenamentoHadlers = _localArmazenamentoHadlers;
        }

        /// <summary>
        /// Cria um novo Local de armazenamento
        /// </summary>
        /// <param name="command">entidade para salvar um local de armazenamento</param>
        /// <returns>Retona um novo Local de armazenamento </returns>
        /// <response code="201">Returna um novo Local de armazenamento</response>
        /// <response code="400">se o item for nulo</response>
        /// <response code="401">Quando não conter um token valido</response> 
        /// <response code="422">A Entidade Local Armazenamento não pode ser nula</response> 
        /// 
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LocalArmazenamentoView))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult Post([FromBody] LocalArmazenamentoCommand command)
        {
            if (command is null) return BadRequest(new BadRequestProblemDetails("A entidade não pode ser nula", Request));

            if (!ModelState.IsValid) return UnprocessableEntity(ModelState); 
                var model = localArmazenamentoHadlers.Salvar(command);
            

            if (model is not null)
            {
                return Resposta(model);
            }
            else
            {
                return Resposta("erro",0);
            }

        }

        /// <summary>
        /// Buscar Local de armazenamento pelo id.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:        
        /// Get /MarcaProduto/id          
        /// </remarks>
        /// <returns>Um Local de armazenamento</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o Local de armazenamento não existir</response>
        /// <response code="401">Quando não conter um token valido</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LocalArmazenamentoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}", Name = "ObterLocalArmazenamento")]
       // [MapToApiVersion("2.0")]
       // [MapToApiVersion("2.1")]
        public IActionResult GetId(int id)
        {
            var model = localArmazenamentoHadlers.RecuperarPeloId(id);

            

            if (model is not null)
            {
                //colocando link seguindo as normas de api nivel 3, seguindo o padrão Hateous
                model.Link.Add(new LinkView("self", Url.Link("ObterLocalArmazenamento", new { id = model.Id }), "GET"));
                model.Link.Add(new LinkView("update", Url.Link("AtualizarLocalArmazenamento", new { id = model.Id }), "PUT"));
                model.Link.Add(new LinkView("delete", Url.Link("DeletarLocalArmazenamento", new { id = model.Id }), "DELETE"));

                return Resposta(model);
            }
            else
            {
                //NotificarErro("Os ids informados não são iguais!");
                return Resposta("local de armazenamento", id);
            }
        }


        /// <summary>
        /// Buscar todos Local de armazenamento
        /// </summary>
        /// <remarks>
        /// Sample request:       
        /// Get /MarcaProduto/          
        /// </remarks>
        /// <returns>Uma lista de Local de armazenamento</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o Local de armazenamento não existir</response>
        /// <response code="401">Quando não conter um token valido</response> 
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LocalArmazenamentoView))]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [HttpGet]
        public IActionResult GetList([FromQuery] int? numeroDaPagina, [FromQuery] int? registroPorPagina)
        {
            var model = localArmazenamentoHadlers.RecuperarLista();
            if (model is not null)
            {
                var quantidade = model.Count();
                if (registroPorPagina.HasValue)
                {
                    if (numeroDaPagina is null) numeroDaPagina = 1;
                    if (registroPorPagina > quantidade) registroPorPagina = quantidade;
                    //transforma a model em paginas
                    model = model.Skip((numeroDaPagina.Value - 1) * registroPorPagina.Value).Take(registroPorPagina.Value);

                    var paginacao = new Paginacao();
                    paginacao.NumeroDaPaginas = numeroDaPagina.Value;
                    paginacao.NumeroDeRegistroPorPaginas = registroPorPagina.Value;
                    paginacao.TotalDeRegistro = quantidade;
                    paginacao.TotalDePaginas = (int)Math.Ceiling((double)quantidade / registroPorPagina.Value);
                    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginacao));

                    if (numeroDaPagina > paginacao.TotalDePaginas) return NotFound(new ObjetoNotFoundProblemDetails("pagina não existe", Request));


                }
                foreach(var modelo in model)
                {
                    modelo.Link.Add(new LinkView("self", Url.Link("ObterLocalArmazenamento", new { id = modelo.Id }), "GET"));
                    modelo.Link.Add(new LinkView("update", Url.Link("AtualizarLocalArmazenamento", new { id = modelo.Id }), "PUT"));
                    modelo.Link.Add(new LinkView("delete", Url.Link("DeletarLocalArmazenamento", new { id = modelo.Id }), "DELETE"));
                }

                return Resposta(model);
            }
            else
            {
                return Resposta(model);
            }
        }

        /// <summary>
        /// Contar a quantidade de Local de armazenamento.
        /// </summary>
        /// <remarks>
        /// Sample request:        
        /// Get /MarcaProduto/Cont          
        /// </remarks>
        /// <returns>a quantidade de Local de armazenamento</returns>
        /// <response code="200"></response>
        [MapToApiVersion("2.1")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [HttpGet("Cont")]
        public int GetQuantidade()
        {
            return localArmazenamentoHadlers.RecuperarQuantidade();
        }


        /// <summary>
        /// Excluir Local de armazenamento.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:        
        /// DELETE /MarcaProduto/id           
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Um Local de armazenamento excluido</returns>
        /// <response code="204">Quando excluido com sucesso</response>
        /// <response code="404">Quando o Local de armazenamento não existir</response> 
        /// <response code="401">Quando não conter um token valido</response> 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpDelete("{id}" , Name = "DeletarLocalArmazenamento")]
        public IActionResult Delete(int id)
        {
            var model = localArmazenamentoHadlers.RecuperarPeloId(id);

            if (model is not null)
            {
                localArmazenamentoHadlers.ExcluirPeloId(id);
                return Resposta(model);
            }
            else
            {
                return Resposta(id);
            }
        }


        /// <summary>
        /// Alterar Local de armazenamento.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:        
        /// PUT /GrupoProduto/id           
        /// </remarks>
        /// /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns>Um Local de armazenamento foi alterado</returns>
        /// <response code="200">Quando Local de armazenamento é alterado com sucesso</response>
        /// <response code="404">Quando o Local de armazenamento não existir</response>  
        /// <response code="401">Quando não conter um token valido</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LocalArmazenamentoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}", Name = "AtualizarLocalArmazenamento")]
        public IActionResult Alterar(int id, [FromBody] LocalArmazenamentoCommand command)
        {
            var model = localArmazenamentoHadlers.Alterar(id, command);
            if (model is not null)
            {
                return Resposta(model);
            }
            else
            {
                return Resposta(id);
            }

        }




    }
}

