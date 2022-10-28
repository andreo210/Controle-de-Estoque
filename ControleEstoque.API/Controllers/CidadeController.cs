using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.Cidade;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {

        ICidadeHandlers cidadeHandler;
        public CidadeController(ICidadeHandlers _cidadeHandler)
        {
            this.cidadeHandler = _cidadeHandler;
        }

        // POST api/<PessoaFisicaController>
        [HttpPost]
        public IActionResult Post([FromBody] CidadeDTO cidadeDTO)
        {
            cidadeHandler.Salvar(cidadeDTO);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<CidadeDTO> Get()
        {
            return cidadeHandler.RecuperarLista();
        }

        // GET api/<PessoaFisicaController>/5
        [HttpGet("{id}")]
        public CidadeDTO Get(int id)
        {
            return cidadeHandler.RecuperarPeloId(id);
        }

        [HttpGet("Cont")]
        public int GetQuantidade()
        {
            return cidadeHandler.RecuperarQuantidade();
        }

        // DELETE api/<PessoaFisicaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            cidadeHandler.ExcluirPeloId(id);
            return Ok();
        }
    }
}
