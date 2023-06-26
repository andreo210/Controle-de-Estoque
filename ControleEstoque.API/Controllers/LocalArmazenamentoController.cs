using ControleEstoque.API.Config;
using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.LocalArmazenamento;
using ControleEstoque.App.Models.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalArmazenamentoController : ControllerBase
    { //
        ILocalArmazenamentoHandlers localArmazenamentoHadlers;
        public LocalArmazenamentoController(ILocalArmazenamentoHandlers _localArmazenamentoHadlers)
        {
            this.localArmazenamentoHadlers = _localArmazenamentoHadlers;
        }

        /// <summary>
        /// Cria um novo Local de armazenamento
        /// </summary>
        /// <param name="local"></param>
        /// <returns>Retona um Local de armazenamento criado</returns>
        /// <response code="201">Returna um novo Local de armazenamento</response>
        /// <response code="400">se o item for nulo</response>
        /// <response code="401">Quando não conter um token valido</response> 
        /// 
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LocalArmazenamentoView))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public IActionResult Post([FromBody] LocalArmazenamentoCommand local)
        {
            var model = localArmazenamentoHadlers.Salvar(local);
            if (model != null)
            {
                return Created(HttpContext.Request.Path + "/" + model.Id, model);
            }
            else
            {
                return BadRequest();
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
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var x = localArmazenamentoHadlers.RecuperarPeloId(id);

            if (x != null)
            {
                return Ok(x);
            }
            else
            {
                return NotFound(new ObjetoNotFoundProblemDetails($"Local de armazenamento com  id = {id} não encontrado", Request));
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
        public IActionResult GetList()
        {
            var model = localArmazenamentoHadlers.RecuperarLista();
            if (model != null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound(new ObjetoNotFoundProblemDetails($"Lista de Local de Armazenamento não encontrada não encontrada", Request));
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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var x = localArmazenamentoHadlers.RecuperarPeloId(id);

            if (x != null)
            {
                localArmazenamentoHadlers.ExcluirPeloId(id);
                return NoContent();
            }
            else
            {
                return NotFound(new ObjetoNotFoundProblemDetails($"Local de armazenamento com  id = {id} não encontrado", Request));
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
        /// <param name="marca"></param>
        /// <returns>Um Local de armazenamento foi alterado</returns>
        /// <response code="200">Quando Local de armazenamento é alterado com sucesso</response>
        /// <response code="404">Quando o Local de armazenamento não existir</response>  
        /// <response code="401">Quando não conter um token valido</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LocalArmazenamentoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, [FromBody] LocalArmazenamentoCommand marca)
        {
            var x = localArmazenamentoHadlers.Alterar(id, marca);
            if (x != null)
            {
                return Ok(x);
            }
            else
            {
                return NotFound(new ObjetoNotFoundProblemDetails($"Local de armazenamento com  id = {id} não encontrado", Request));
            }

        }




    }
}

