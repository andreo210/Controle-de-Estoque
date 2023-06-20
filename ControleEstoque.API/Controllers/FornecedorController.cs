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
        /// Criar um novo fornecedor.
        /// </summary>
        /// <param name="fornecedorDTO"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <remarks>
        /// Exemplo da requisição:
        ///
        ///     POST /Fornecedor
        ///
        /// </remarks>
        /// <response code="201">Retorna um novo fornecedor, caso seja criado</response>
        /// <response code="400">caso ocorra algum tipo de erro </response>  
        /// <response code="401">Quando não conter um token valido</response> 
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
        /// <returns>Um fornecedor excluido</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o Fornecedor não existir</response>
        /// <response code="401">Quando não conter um token valido</response>  
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EnderecoView))]
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
        /// <returns>Um fornecedor excluido</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o Fornecedor não existir</response>
        /// <response code="401">Quando não conter um token valido</response> 
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
                return BadRequest();
            }
        }

        /// <summary>
        /// Buscar contato pelo id dos fornecedores.
        /// </summary>
        /// <remarks>
        /// Sample request:        
        /// Get /Fornecedor/Contato/Id        
        /// </remarks>
        /// <returns>Um fornecedor excluido</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o Fornecedor não existir</response>
        /// <response code="401">Quando não conter um token valido</response>  
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
        /// Buscar contato pelo id dos fornecedores.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:        
        /// Get /Fornecedor/Endereco/Listar        
        /// </remarks>
        /// <returns>Um fornecedor excluido</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o Fornecedor não existir</response>
        /// <response code="401">Quando não conter um token valido</response>  
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
        /// Sample request:        
        /// Get /Fornecedor/Endereco/id           
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Um fornecedor excluido</returns>
        /// <response code="200">Quando existir</response>
        /// <response code="404">Quando o Fornecedor não existir</response> 
        /// <response code="401">Quando não conter um token valido</response>  
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EnderecoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Endereco/{id}")]
        public IActionResult GetEndereco(int id)
        {
            return Ok(enderecoHandler.FindByID(id));
        }


        /// <summary>
        /// Buscar Fornecedor pelo Id.
        /// </summary>
        /// <remarks>
        /// Sample request:        
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
        /// Sample request:        
        ///     PUT /Fornecedor/id           
        ///
        /// </remarks>
        /// <param name="fornecedorDTO"></param>
        /// <returns>Um fornecedor foi alterado</returns>
        /// <response code="200">Quando fornecedor é alterado com sucesso</response>
        /// <response code="404">Quando o Fornecedor não existir</response>  
        /// <response code="401">Quando não conter um token valido</response>  
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FornecedorView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, [FromBody] FornecedorCommand fornecedorDTO)
        {
            var x = _fornecedorHandlers.Alterarfornecedor(id, fornecedorDTO);
            
            if (x!= null)
            {
                return Ok();
            }
            else 
            {
                return NotFound(ProblemDetails(fornecedorDTO.Id));
            }
        }

        /// <summary>
        /// Excluir Fornecedor.
        /// </summary>
        /// <remarks>
        /// Sample request:        
        ///     DELETE /Fornecedor/id           
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Um fornecedor excluido</returns>
        /// <response code="200">Quando excluido com sucesso</response>
        /// <response code="404">Quando o Fornecedor não existir</response> 
        /// <response code="401">Quando não conter um token valido</response>  
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FornecedorView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)        {
            
                var x = _fornecedorHandlers.RecuperarPeloId(id);

                if (x != null) { 
                    _fornecedorHandlers.ExcluirPeloId(id);
                    return Ok();
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
