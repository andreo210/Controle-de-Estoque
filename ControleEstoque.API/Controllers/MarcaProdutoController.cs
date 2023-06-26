using ControleEstoque.API.Config;
using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.MarcaProduto;
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
    public class MarcaProdutoController : ControllerBase
    {
        IMarcaProdutoHandlers marcaHandler;
        public MarcaProdutoController(IMarcaProdutoHandlers _marcaHandler)
        {
            this.marcaHandler = _marcaHandler;
        }


        /// <summary>
        /// Cria uma nova marca de produto
        /// </summary>
        /// <param name="marca"></param>
        /// <returns>Retona uma marca de produto</returns>
        /// <response code="201">Returna uma nova marcar</response>
        /// <response code="400">se o item for nulo</response>
        /// <response code="401">Quando não conter um token valido</response> 
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MarcaProdutoView))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost] 
        public IActionResult Post([FromBody] MarcaProdutoCommand marca)
        {
            var model = marcaHandler.Salvar(marca);

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
        /// Buscar todas as marcas de produto.
        /// </summary>
        /// <remarks>
        /// Sample request:       
        /// Get /MarcaProduto/          
        /// </remarks>
        /// <returns>Uma lista de marcas de produto</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o Fornecedor não existir</response>
        /// <response code="401">Quando não conter um token valido</response>  
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarcaProdutoView))]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [HttpGet]
        public IActionResult GetList()
        {
            var model = marcaHandler.RecuperarLista();
            if (model != null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound(new ObjetoNotFoundProblemDetails($"Lista de marca de produto não encontrada", Request));
            }
        }


        /// <summary>
        /// Buscar marca de  produto pelo id.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:        
        /// Get /MarcaProduto/id          
        /// </remarks>
        /// <returns>Uma marca de produtos</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o grupo não existir</response>
        /// <response code="401">Quando não conter um token valido</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarcaProdutoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var x = marcaHandler.RecuperarPeloId(id);

            if (x != null)
            {
                return Ok(x);
            }
            else
            {
                return NotFound(new ObjetoNotFoundProblemDetails($"Marca de produto com  id = {id} não encontrado", Request));
            }
        }



        /// <summary>
        /// Contar a quantidade de marca de produtos.
        /// </summary>
        /// <remarks>
        /// Sample request:        
        /// Get /MarcaProduto/Cont          
        /// </remarks>
        /// <returns>a quantidade de fornecedor foi recuperada</returns>
        /// <response code="200"></response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [HttpGet("Cont")]
        public int GetQuantidade()
        {
            return marcaHandler.RecuperarQuantidade();
        }



        /// <summary>
        /// Excluir Marca de Produtos.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:        
        /// DELETE /MarcaProduto/id           
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Uma marca excluida</returns>
        /// <response code="204">Quando excluido com sucesso</response>
        /// <response code="404">Quando o Fornecedor não existir</response> 
        /// <response code="401">Quando não conter um token valido</response> 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var x =marcaHandler.RecuperarPeloId(id);

            if (x != null)
            {
                marcaHandler.ExcluirPeloId(id);
                return NoContent();
            }
            else
            {
                return NotFound(new ObjetoNotFoundProblemDetails($"Marca de produto com  id = {id} não encontrado", Request));
            }
        }

        /// <summary>
        /// Alterar grupo de produto.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:        
        /// PUT /GrupoProduto/id           
        /// </remarks>
        /// /// <param name="id"></param>
        /// <param name="marca"></param>
        /// <returns>Um grupo de produto foi alterado</returns>
        /// <response code="200">Quando fornecedor é alterado com sucesso</response>
        /// <response code="404">Quando o Fornecedor não existir</response>  
        /// <response code="401">Quando não conter um token valido</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarcaProdutoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, [FromBody] MarcaProdutoCommand marca)
        {
            var x = marcaHandler.Alterar(id, marca);
            if (x != null)
            {
                return Ok(x);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
