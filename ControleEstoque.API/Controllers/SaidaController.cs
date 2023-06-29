using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.SaidaProduto;
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
    public class SaidaController : ControllerBase
    {
        ISaidaProdutoHandlers saidaHandler;
        public SaidaController(ISaidaProdutoHandlers _saidaHandler)
        {
            this.saidaHandler = _saidaHandler;
        }

        /// <summary>
        /// Cria um nova saida de produto
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Retona uma Saida</returns>
        /// <response code="201">Returna um novo fornecedor</response>
        /// <response code="400">se o item for nulo</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SaidaProdutoView))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Post([FromBody] SaidaProdutoCommand command)
        {
            var model = saidaHandler.Salvar(command);
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
        /// Alterar uma saida de produto.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="id"></param>
        /// <returns>Um grupo de produto foi alterado</returns>
        /// <response code="200">Quando saida de produto é alterado com sucesso</response>
        /// <response code="404">Quando saida de produto não existir</response>  
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaidaProdutoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, [FromBody] SaidaProdutoCommand command)
        {
            var model = saidaHandler.Alterar(id, command);
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
        /// Buscar uma lista de saida de produto
        /// </summary>    
        /// <returns>Uma lista de saida de produto</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando saida de produto não existir</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaidaProdutoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IActionResult Get()
        {
            var model = saidaHandler.RecuperarLista();
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
        /// Buscar saida de produto pelo id.
        /// </summary>
        /// <returns>saida de produtos</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando saida de produto não existir</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaidaProdutoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = saidaHandler.RecuperarPeloId(id);

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
        /// Contar a quantidade de saida de produto   
        /// </summary>  
        /// <returns>a quantidade de saida de produto foi recuperada</returns>
        /// <response code="200"></response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [HttpGet("Cont")]
        public IActionResult GetQuantidade()
        {
            return Ok(saidaHandler.RecuperarQuantidade());
        }

        /// <summary>
        /// Excluir saida de produto.
        /// </summary>        
        /// <param name="id"></param>
        /// <returns>Um fornecedor excluido</returns>
        /// <response code="204">Quando excluido com sucesso</response>
        /// <response code="404">Quando saida de produtor não existir</response> 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Delete(int id)
        {

            var model = saidaHandler.RecuperarPeloId(id);

            if (model is not null)
            {
                saidaHandler.ExcluirPeloId(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
