using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.MarcaProduto;
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

        // POST api/<PessoaFisicaController>
        [HttpPost]
        public IActionResult Post([FromBody] MarcaProdutoDTO marcaDTO)
        {
            marcaHandler.Salvar(marcaDTO);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<MarcaProdutoDTO> Get()
        {
            return marcaHandler.RecuperarLista();
        }

        // GET api/<PessoaFisicaController>/5
        [HttpGet("{id}")]
        public MarcaProdutoDTO Get(int id)
        {
            return marcaHandler.RecuperarPeloId(id);
        }

        [HttpGet("Cont")]
        public int GetQuantidade()
        {
            return marcaHandler.RecuperarQuantidade();
        }

        // DELETE api/<PessoaFisicaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            marcaHandler.ExcluirPeloId(id);
            return Ok();
        }
    }
}
