using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.Fornecedor;
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
        IFornecedorHandlers fornecedorHandlers;
        public FornecedorController(IFornecedorHandlers _fornecedorHandlers)
        {
            this.fornecedorHandlers = _fornecedorHandlers;
        }

        // POST api/<PessoaFisicaController>
       
        [HttpPost]
        public IActionResult Post([FromBody] FornecedorDTO fornecedorDTO)
        {
            var x = fornecedorHandlers.Salvar(fornecedorDTO);
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
        public IEnumerable<FornecedorDTO> Get()
        {
            return fornecedorHandlers.RecuperarLista();
        }

        // GET api/<PessoaFisicaController>/5
        [HttpGet("{id}")]
        public  IActionResult Get(int id)
        {
            var x = fornecedorHandlers.RecuperarPeloId(id);
            if (x!=null)
            {
                return Ok(x);
            }
            else
            {
                return NotFound("objeto com id: " + id+ " não encontrado");
            }
        }

        [HttpGet("Cont")]
        public int GetQuantidade()
        {
            return fornecedorHandlers.RecuperarQuantidade();
        }
        [HttpPut]
        public IActionResult Alterar(FornecedorDTO fornecedorDTO)
        {
            var x = fornecedorHandlers.Alterar(fornecedorDTO);
            if (x=="OK")
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<PessoaFisicaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var x = fornecedorHandlers.RecuperarPeloId(id);

            if (x != null)
            {
                fornecedorHandlers.ExcluirPeloId(id);
                return Ok(id +" excluido com sucesso");
            }
            else
            {
                return NotFound("objeto com id: " + id + " não encontrado");
            }
            
            return Ok();
        }
    }
}
