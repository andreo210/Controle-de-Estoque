using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.SaidaProduto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaidaController : ControllerBase
    {
        ISaidaProdutoHandlers saidaHandler;
        public SaidaController(ISaidaProdutoHandlers _saidaHandler)
        {
            this.saidaHandler = _saidaHandler;
        }

        // POST api/<PessoaFisicaController>
        [HttpPost]
        public IActionResult Post([FromBody] SaidaProdutoDTO estadoDTO)
        {
            saidaHandler.Salvar(estadoDTO);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<SaidaProdutoDTO> Get()
        {
            return saidaHandler.RecuperarLista();
        }

        // GET api/<PessoaFisicaController>/5
        [HttpGet("{id}")]
        public SaidaProdutoDTO Get(int id)
        {
            return saidaHandler.RecuperarPeloId(id);
        }

        [HttpGet("Cont")]
        public int GetQuantidade()
        {
            return saidaHandler.RecuperarQuantidade();
        }

        // DELETE api/<PessoaFisicaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            saidaHandler.ExcluirPeloId(id);
            return Ok();
        }

    }
}
