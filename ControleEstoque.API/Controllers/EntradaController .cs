using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.EntradaProduto;
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
    public class EntradaProdutoController : ControllerBase
    {
        private readonly IEntradaProdutoHandlers EntradaHandler;
        public EntradaProdutoController(IEntradaProdutoHandlers _EntradaHandler)
        {
            this.EntradaHandler = _EntradaHandler;
        }

        /// <summary>
        /// Cria um nova Entrada de produto
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns>Retona uma Entrada</returns>
        /// <response code="201">Returna um nova Entrada</response>
        /// <response code="400">se o item for nulo</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EntradaProdutoView))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Post([FromBody] EntradaProdutoCommand entrada)
        {
            var model = EntradaHandler.Salvar(entrada);
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
        /// Alterar uma Entrada de produto.
        /// </summary>
        /// <param name="Entrada"></param>
        /// <param name="id"></param>
        /// <returns>Um grupo de produto foi alterado</returns>
        /// <response code="200">Quando Entrada de produto é alterado com sucesso</response>
        /// <response code="404">Quando Entrada de produto não existir</response>  
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntradaProdutoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, [FromBody] EntradaProdutoCommand Entrada)
        {
            var model = EntradaHandler.Alterar(id, Entrada);
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
        /// Buscar uma lista de Entrada de produto
        /// </summary>    
        /// <returns>Uma lista de Entrada de produto</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando Entrada de produto não existir</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntradaProdutoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IActionResult Get()
        {
            var model = EntradaHandler.RecuperarLista();
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
        /// Buscar Entrada de produto pelo id.
        /// </summary>
        /// <returns>Entrada de produtos</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando Entrada de produto não existir</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntradaProdutoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = EntradaHandler.RecuperarPeloId(id);

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
        /// Contar a quantidade de Entrada de produto   
        /// </summary>  
        /// <returns>a quantidade de Entrada de produto foi recuperada</returns>
        /// <response code="200"></response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [HttpGet("Cont")]
        public IActionResult GetQuantidade()
        {
            return Ok(EntradaHandler.RecuperarQuantidade());
        }

        /// <summary>
        /// Excluir Entrada de produto.
        /// </summary>        
        /// <param name="id"></param>
        /// <returns>Um fornecedor excluido</returns>
        /// <response code="204">Quando excluido com sucesso</response>
        /// <response code="404">Quando Entrada de produtor não existir</response> 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Delete(int id)
        {

            var model = EntradaHandler.RecuperarPeloId(id);

            if (model is not null)
            {
                EntradaHandler.ExcluirPeloId(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
