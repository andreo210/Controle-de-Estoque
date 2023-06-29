using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.Produto;
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
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoHandlers handler;
        public ProdutoController(IProdutoHandlers _handler)
        {
            this.handler = _handler;
        }

        /// <summary>
        /// Cria um produto
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Retona um produto</returns>
        /// <response code="201">Returna um novo produto </response>
        /// <response code="400">se o item for nulo</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProdutoView))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Salvar([FromBody] ProdutoCommand command)
        {
            var model = handler.Salvar(command);
            if (model is not null)
            {
                return Created(HttpContext.Request.Path + "/" + model.Id, model);
            }
            else
            {
                return BadRequest();
            }

        }

        /// <summary>
        /// Alterar um produto.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="id"></param>
        /// <returns>Um produto foi alterado</returns>
        /// <response code="200">Quando produto é alterado com sucesso</response>
        /// <response code="404">Quando  produto não existir</response>  
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, [FromBody] ProdutoCommand command)
        {
            var model = handler.Alterar(id, command);
            if (model is not null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }

        }

        /// <summary>
        /// Buscar uma lista de produto
        /// </summary>    
        /// <returns>Uma lista de produto</returns>
        /// <response code="200">Quando produto existir</response>
        /// <response code="404">Quando produto não existir</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IActionResult Get()
        {
            var model = handler.RecuperarLista();
            if (model is not null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }


        /// <summary>
        /// Buscar  de produto pelo id.
        /// </summary>
        /// <returns> retorna um produto</returns>
        /// <response code="200">Quando produto existir</response>
        /// <response code="404">Quando produto não existir</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = handler.RecuperarPeloId(id);

            if (model is not null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }

        }

        /// <summary>
        /// Contar a quantidade de produto   
        /// </summary>  
        /// <returns>a quantidade de produto foi recuperada</returns>
        /// <response code="200"></response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [HttpGet("Cont")]
        public IActionResult GetQuantidade()
        {
            return Ok(handler.RecuperarQuantidade());
        }

        /// <summary>
        /// Excluir produto.
        /// </summary>        
        /// <param name="id"></param>
        /// <returns>Um produto excluido</returns>
        /// <response code="204">Quando produto excluido com sucesso</response>
        /// <response code="404">Quando produtor não existir</response> 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Delete(int id)
        {

            var model = handler.RecuperarPeloId(id);

            if (model is not null)
            {
                handler.ExcluirPeloId(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
