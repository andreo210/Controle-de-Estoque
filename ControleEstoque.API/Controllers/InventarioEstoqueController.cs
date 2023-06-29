using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.InventarioEstoque;
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
    public class InventarioEstoqueController : ControllerBase
    {
        IinventarioEstoqueHandlers inventarioHandler;
        public InventarioEstoqueController(IinventarioEstoqueHandlers _inventarioHandler)
        {
            this.inventarioHandler = _inventarioHandler;
        }

        /// <summary>
        /// Cria um novo Inventario
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Retona um fornecedor criado</returns>
        /// <response code="201">Returna um novo fornecedor</response>
        /// <response code="400">se o item for nulo</response>
        /// <response code="401">Quando não conter um token valido</response> 
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InventarioEstoqueView))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public IActionResult Post([FromBody] InventarioEstoqueCommand command)
        {
            var model = inventarioHandler.Salvar(command);
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
        /// Alterar grupo de produto.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:        
        /// PUT /GrupoProduto/id           
        /// </remarks>
        ///<param name="id"></param>
        /// <param name="command"></param>
        /// <returns>Um grupo de produto foi alterado</returns>
        /// <response code="200">Quando fornecedor é alterado com sucesso</response>
        /// <response code="404">Quando o Fornecedor não existir</response>  
        /// <response code="401">Quando não conter um token valido</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InventarioEstoqueView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, [FromBody] InventarioEstoqueCommand command)
        {
            var model = inventarioHandler.Alterar(id, command);
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
        /// Buscar uma lisrta de grupo de produtos
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:        
        /// Get /GrupoProduto/          
        /// </remarks>
        /// <returns>Uma lista de grupo de produtos</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o grupo não existir</response>
        /// <response code="401">Quando não conter um token valido</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InventarioEstoqueView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public IActionResult GetList()
        {
            var model = inventarioHandler.RecuperarLista();
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
        /// Buscar produto pelo id.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:        
        /// Get /GrupoProduto/id          
        /// </remarks>
        /// <returns>Um grupo de produtos</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o grupo não existir</response>
        /// <response code="401">Quando não conter um token valido</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InventarioEstoqueView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var model = inventarioHandler.RecuperarPeloId(id);

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
        /// Contar a quantidade de grupo de produtos.
        /// </summary>
        /// <remarks>
        /// Sample request:        
        /// Get /GrupoProduto/Cont          
        /// </remarks>
        /// <returns>a quantidade de fornecedor foi recuperada</returns>
        /// <response code="200"></response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [HttpGet("Cont")]
        public IActionResult GetQuantidade()
        {
            return Ok( inventarioHandler.RecuperarQuantidade());
        }


        /// <summary>
        /// Excluir Grupo de Produtos.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:        
        /// DELETE /GrupoProduto/id           
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Um fornecedor excluido</returns>
        /// <response code="204">Quando excluido com sucesso</response>
        /// <response code="404">Quando o Fornecedor não existir</response> 
        /// <response code="401">Quando não conter um token valido</response> 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var model = inventarioHandler.RecuperarPeloId(id);

            if (model is not null)
            {
                inventarioHandler.ExcluirPeloId(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
