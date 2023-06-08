using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.Contato;
using ControleEstoque.App.Handlers.Endereço;
using ControleEstoque.App.Handlers.Fornecedor;
using ControleEstoque.App.Views;
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

           
        [HttpPost]
        public IActionResult Post([FromBody] FornecedorDTO fornecedorDTO)
        {
            var x = _fornecedorHandlers.Salvar(fornecedorDTO);
            if (x != null)
            {
                return Ok(x);
            }
            else
            {
                return BadRequest();
            }
        }
        //tras todos os fornecedores
        [HttpGet]
        public IActionResult Get()
        {
            return Ok( _fornecedorHandlers.RecuperarLista());
        }

        //tras todos os contatos dos fornecedores
        [HttpGet("Contato/Listar")]
        public IActionResult GetContatos()
        {
            return Ok( _contatosHandler.RecuperarLista());
        }

        //tras o contato dos fornecedor com Id
        [HttpGet("Contato/{id}")]
        public IActionResult GetContatos(int id)
        {
            return Ok( _contatosHandler.FindByID(id));
        }

        //tras todos os endereco dos fornecedores
        [HttpGet("Endereco/Listar")]
        public IEnumerable<EnderecoView> GetEndereco()
        {
            return enderecoHandler.RecuperarLista();
        }

        //tras o endereco dos fornecedor com Id
        [HttpGet("Endereco/{id}")]
        public IActionResult GetEndereco(int id)
        {
            return Ok(enderecoHandler.FindByID(id));
        }


        [HttpGet("{id}")]
        public  IActionResult Get(int id)
        {
            var x = _fornecedorHandlers.RecuperarPeloId(id);
            if (x!=null)
            {
                return Ok(x);
            }
            else
            {
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Type = "https://example.com/probs/out-of-credit",
                    Title = "Objeto não encontrado",
                    Detail = "o fornecedor com id numero : "+id+ " não foi encontrado",
                    Instance = HttpContext.Request.Path
                };
                return NotFound(problemDetails);
            }
        }

        //retorna a quantidade de fornecedor
        [HttpGet("Cont")]
        public IActionResult GetQuantidade()
        {
            return Ok( _fornecedorHandlers.RecuperarQuantidade());
        }


        [HttpPut]
        public IActionResult Alterar(FornecedorDTO fornecedorDTO)
        {
            var x = _fornecedorHandlers.Alterar(fornecedorDTO);
            if (x=="OK")
            {
                return Ok(fornecedorDTO);
            }
            else 
            {
                return NotFound("objeto não encontrado");
            }
        }

          [HttpDelete("{id}")]
        public IActionResult Delete(int id)        {
            
                var x = _fornecedorHandlers.ExcluirPeloId(id);

                if (x == "OK")
                {
                    return Ok("excluido com sucesso");
                }
                else
                {
                    return NotFound("objeto não encontrado");
                }
           
          
        }
    }
}
