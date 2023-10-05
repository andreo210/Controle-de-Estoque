using ControleEstoque.API.ProblemDetailsModels;
using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.Produto;
using ControleEstoque.App.Handlers.SaidaProduto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaidaProdutoController : ControllerBase
    {
        private readonly ISaidaProdutoHandlers SaidaHandler;
        private readonly IProdutoHandlers ProdutoHandler;
        public SaidaProdutoController(ISaidaProdutoHandlers _saidaHandler, IProdutoHandlers _ProdutoHandler)
        {
            this.SaidaHandler = _saidaHandler;
            this.ProdutoHandler = _ProdutoHandler;
        }

        /// <summary>
        /// Cria um nova Entrada de produto e subtrai mais estoque de determinado produto
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
            var idProduto = ProdutoHandler.RecuperarPeloId(command.IdProduto);

            if (idProduto is null)
                return BadRequest(new CustomBadRequest("O Id do Produto é invalido e não foi encontrado", Request));
            else
            {
                var model = SaidaHandler.Salvar(command);
                if (model is not null)
                {
                    return Created(HttpContext.Request.Path + "/" + model.Id, model);
                }
                else
                {
                    return BadRequest();
                }
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
        /// <response code="400">se o item for nulo</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaidaProdutoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, [FromBody] SaidaProdutoCommand command)
        {
            var idProduto = ProdutoHandler.RecuperarPeloId(command.IdProduto);

            if (idProduto is null)
                return BadRequest(new CustomBadRequest("O Id do Produto é invalido e não foi encontrado", Request));
            else
            {
                var model = SaidaHandler.Alterar(id, command);
                if (model is not null)
                {
                    return Ok(model);
                }
                else
                {
                    return NotFound(new CustomNotFound($"Saida de Produto com  id = {id} não encontrado", Request));
                }
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
            var model = SaidaHandler.RecuperarLista();
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
            var model = SaidaHandler.RecuperarPeloId(id);

            if (model is not null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound(new CustomNotFound($"Saida de Produto com  id = {id} não encontrado", Request));
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
            return Ok(SaidaHandler.RecuperarQuantidade());
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

            var model = SaidaHandler.RecuperarPeloId(id);

            if (model is not null)
            {
                SaidaHandler.ExcluirPeloId(id);
                return NoContent();
            }
            else
            {
                return NotFound(new CustomNotFound($"Saida de Produto com  id = {id} não encontrado", Request));
            }
        }

    }
}
