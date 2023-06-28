using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.UnidadeMedida;
using ControleEstoque.Infra.Data;
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
    public class UnidadeMedidaController : ControllerBase
    {
        IUnidadeMedidaHandlers UnidadeMedidaHandler;
        public UnidadeMedidaController(IUnidadeMedidaHandlers _UnidadeMedidaHandler)
        {
            this.UnidadeMedidaHandler = _UnidadeMedidaHandler;
        }

        /// <summary>
        /// Cria um nova Unidade Medida de produto
        /// </summary>
        /// <param name="UnidadeMedida"></param>
        /// <returns>Retona uma Unidade Medida</returns>
        /// <response code="201">Returna um novo Unidade Medida</response>
        /// <response code="400">se o item for nulo</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UnidadeMedidaView))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Post([FromBody] UnidadeMedidaCommand UnidadeMedida)
        {
            var model = UnidadeMedidaHandler.Salvar(UnidadeMedida);
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
        /// Alterar uma Unidade Medida de produto.
        /// </summary>
        /// <param name="UnidadeMedida"></param>
        /// <param name="id"></param>
        /// <returns>Uma Unidade Medida foi alterado</returns>
        /// <response code="200">Quando Unidade Medida de produto é alterado com sucesso</response>
        /// <response code="404">Quando Unidade Medida de produto não existir</response>  
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UnidadeMedidaView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, [FromBody] UnidadeMedidaCommand UnidadeMedida)
        {
            var model = UnidadeMedidaHandler.Alterar(id, UnidadeMedida);
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
        /// Buscar uma lista de Unidade Medida de produto
        /// </summary>    
        /// <returns>Uma lista de Unidade Medida de produto</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando Unidade Medida de produto não existir</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UnidadeMedidaView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IActionResult Get()
        {
            var model = UnidadeMedidaHandler.RecuperarLista();
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
        /// Buscar Unidade Medida de produto pelo id.
        /// </summary>
        /// <returns>Unidade Medida de produtos</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando Unidade Medida de produto não existir</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UnidadeMedidaView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = UnidadeMedidaHandler.RecuperarPeloId(id);

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
        /// Contar a quantidade de Unidade Medida de produto   
        /// </summary>  
        /// <returns>a quantidade de Unidade Medida de produto foi recuperada</returns>
        /// <response code="200"></response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [HttpGet("Cont")]
        public IActionResult GetQuantidade()
        {
            return Ok(UnidadeMedidaHandler.RecuperarQuantidade());
        }

        /// <summary>
        /// Excluir Unidade Medida de produto.
        /// </summary>        
        /// <param name="id"></param>
        /// <returns>Uma Unidade Medida excluida</returns>
        /// <response code="204">Quando excluido com sucesso</response>
        /// <response code="404">Quando Unidade Medida de produtor não existir</response> 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Delete(int id)
        {

            var model = UnidadeMedidaHandler.RecuperarPeloId(id);

            if (model is not null)
            {
                UnidadeMedidaHandler.ExcluirPeloId(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
