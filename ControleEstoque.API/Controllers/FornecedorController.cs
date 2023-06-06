using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.Contato;
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

        public FornecedorController(IFornecedorHandlers fornecedorHandlers, IContatoHandler contatosHandler)
        {
            this._fornecedorHandlers = fornecedorHandlers;
            this._contatosHandler = contatosHandler;
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

        [HttpGet]
        public IEnumerable<FornecedorView> Get()
        {
            return _fornecedorHandlers.RecuperarLista();
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

        [HttpGet("Cont")]
        public int GetQuantidade()
        {
            return _fornecedorHandlers.RecuperarQuantidade();
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
        public IActionResult Delete(int id)
        {
            
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
