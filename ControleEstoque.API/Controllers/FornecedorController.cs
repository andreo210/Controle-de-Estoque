using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.Contato;
using ControleEstoque.App.Handlers.Endereço;
using ControleEstoque.App.Handlers.Fornecedor;
using ControleEstoque.App.Views;
using Microsoft.AspNetCore.Authorization;
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

    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorHandlers _fornecedorHandlers;
        private readonly IContatoHandler _contatosHandler;
        private readonly IEnderecoHandler enderecoHandler;

        public FornecedorController(IFornecedorHandlers fornecedorHandlers, IContatoHandler contatosHandler, IEnderecoHandler enderecoHandler)
        {
            this._fornecedorHandlers = fornecedorHandlers;
            this._contatosHandler = contatosHandler;
            this.enderecoHandler = enderecoHandler;
        }

        /// <summary>
        /// Cria um novo Fornecedor
        /// </summary>
        /// <param name="fornecedorDTO"></param>
        /// <returns>Retona um fornecedor criado</returns>
        /// <response code="201">Returna um novo fornecedor</response>
        /// <response code="400">se o item for nulo</response>
        /// <response code="401">Quando não conter um token valido</response> 

        [ProducesResponseType(StatusCodes.Status401Unauthorized)]        
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(FornecedorView))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public IActionResult Post([FromBody] FornecedorCommand fornecedorDTO)
        {
            var x = _fornecedorHandlers.Salvar(fornecedorDTO);

            if (x != null)
            {
                return Created(HttpContext.Request.Path + "/" + x.Id, x);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Buscar todos os fornecedores.
        /// </summary>
        /// <remarks>
        /// Sample request:       
        /// Get /Fornecedor/          
        /// </remarks>
        /// <returns>Uma lista de fornecedores</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o Fornecedor não existir</response>
        /// <response code="401">Quando não conter um token valido</response>  
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FornecedorView))]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [HttpGet]
        public IActionResult Get()
        {
            var fornecedores = _fornecedorHandlers.RecuperarLista();
            if (fornecedores != null)
            {
                return Ok(fornecedores);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Buscar todos os cotatos de fornecedores.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:        
        /// Get /Fornecedor/Contato/Listar         
        /// </remarks>
        /// <returns>Uma lista de contatos de fornecedores</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o Fornecedor não existir</response>
        /// <response code="401">Quando não conter um token valido</response> 
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContatoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("Contato/Listar")]
        public IActionResult GetContatos()
        {
            var contatos = _contatosHandler.RecuperarLista();
            if (contatos != null)
            {
                return Ok(contatos);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Buscar contato pelo id dos fornecedores.
        /// </summary>
        /// <remarks>
        /// Sample request:        
        /// Get /Fornecedor/Contato/Id        
        /// </remarks>
        /// <returns>Um contato de fornecedor</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o Fornecedor não existir</response>
        /// <response code="401">Quando não conter um token valido</response>  
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContatoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("Contato/{id}")]
        public IActionResult GetContatos(int id)
        {
            var contato = _contatosHandler.FindByID(id);
            if (contato != null)
            {
                return Ok(contato);
            }
            else
            {
                return NotFound(ProblemDetails(id));
            }

        }

        /// <summary>
        /// Buscar endereço pelo id.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:        
        /// Get /Fornecedor/Endereco/Listar        
        /// </remarks>
        /// <returns>Uma lista de endereço de fornecedor</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o Fornecedor não existir</response>
        /// <response code="401">Quando não conter um token valido</response>  
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EnderecoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("Endereco/Listar")]
        public IActionResult GetEndereco()
        {
            var endereços = enderecoHandler.RecuperarLista();

            if (endereços != null)
            {
                return Ok(endereços);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Buscar Endereço do fornecedor pelo Id.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:        
        /// Get /Fornecedor/Endereco/id           
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Um endereço de fornecedor </returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o Fornecedor não existir</response> 
        /// <response code="401">Quando não conter um token valido</response>  
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EnderecoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("Endereco/{id}")]
        public IActionResult GetEndereco(int id)
        {
            var endereços = enderecoHandler.FindByID(id);

            if (endereços != null)
            {
                return Ok(endereços);
            }
            else
            {
                return NotFound();
            }
            
        }


        /// <summary>
        /// Buscar Fornecedor pelo Id.
        /// </summary>
        /// <remarks>
        /// Exemplo de Requisição:        
        /// Get /Fornecedor/id           
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Um fornecedor foi recuperado</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o Fornecedor não existir</response> 
        /// <response code="401">Quando não conter um token valido</response>  
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FornecedorView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var x = _fornecedorHandlers.RecuperarPeloId(id);
            if (x != null)
            {
                return Ok(x);
            }
            else
            {

                return NotFound(ProblemDetails(id));
            }
        }

        /// <summary>
        /// Contar a quantidade de  Fornecedores.
        /// </summary>
        /// <remarks>
        /// Sample request:        
        /// Get /Fornecedor/Cont          
        /// </remarks>
        /// <returns>a quantidade de fornecedor foi recuperada</returns>
        /// <response code="200"></response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [HttpGet("Cont")]
        public IActionResult GetQuantidade()
        {
            return Ok(_fornecedorHandlers.RecuperarQuantidade());
        }

        /// <summary>
        /// Alterar Fornecedor.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:        
        /// PUT /Fornecedor/id           
        /// </remarks>
        /// <param name="fornecedorDTO"></param>
        /// <returns>Um fornecedor foi alterado</returns>
        /// <response code="200">Quando fornecedor é alterado com sucesso</response>
        /// <response code="404">Quando o Fornecedor não existir</response>  
        /// <response code="401">Quando não conter um token valido</response>  
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FornecedorView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, [FromBody] FornecedorCommand fornecedorDTO)
        {
            var x = _fornecedorHandlers.Alterarfornecedor(id, fornecedorDTO);
            
            if (x!= null)
            {
                return Ok(x);
            }
            else 
            {
                return NotFound(ProblemDetails(x.Id));
            }
        }

        /// <summary>
        /// Excluir Fornecedor.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:        
        /// DELETE /Fornecedor/id           
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Um fornecedor excluido</returns>
        /// <response code="200">Quando excluido com sucesso</response>
        /// <response code="404">Quando o Fornecedor não existir</response> 
        /// <response code="401">Quando não conter um token valido</response>  
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(FornecedorView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)        {
            
                var x = _fornecedorHandlers.RecuperarPeloId(id);

                if (x != null) { 
                    _fornecedorHandlers.ExcluirPeloId(id);
                    return NoContent();
                }
                else
                {
                    return NotFound(ProblemDetails(id));
                }          
          
        }

        private ProblemDetails ProblemDetails(int id)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://example.com/probs/out-of-credit",
                Title = "Objeto não encontrado",
                Detail = "o objeto com id numero :" + id + " não foi encontrado",
                Instance = HttpContext.Request.Path
            };
            return problemDetails;
        }
    }
}
