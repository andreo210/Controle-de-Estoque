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
            fornecedorHandlers.Salvar(fornecedorDTO);
            return Ok();
        }
        [HttpPost("Completo")]
        public IActionResult Post([FromBody] FornecedorCompletoDTO fornecedorDTO)
        {
            fornecedorHandlers.SalvarCompleto(fornecedorDTO);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<FornecedorDTO> Get()
        {
            return fornecedorHandlers.RecuperarLista();
        }

        // GET api/<PessoaFisicaController>/5
        [HttpGet("{id}")]
        public FornecedorDTO Get(int id)
        {
            return fornecedorHandlers.RecuperarPeloId(id);
        }

        [HttpGet("Cont")]
        public int GetQuantidade()
        {
            return fornecedorHandlers.RecuperarQuantidade();
        }

        // DELETE api/<PessoaFisicaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            fornecedorHandlers.ExcluirPeloId(id);
            return Ok();
        }
    }
}
