using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.Produto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        IProdutoHandlers produtoHandler;
        public ProdutoController(IProdutoHandlers _produtoHandler)
        {
            this.produtoHandler = _produtoHandler;
        }

        // POST api/<PessoaFisicaController>
        [HttpPost]
        public IActionResult Post([FromBody] ProdutoDTO produtoDTO)
        {
            produtoHandler.Salvar(produtoDTO);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<ProdutoDTO> Get()
        {
            return produtoHandler.RecuperarLista();
        }

        // GET api/<PessoaFisicaController>/5
        [HttpGet("{id}")]
        public ProdutoDTO Get(int id)
        {
            return produtoHandler.RecuperarPeloId(id);
        }

        [HttpGet("Cont")]
        public int GetQuantidade()
        {
            return produtoHandler.RecuperarQuantidade();
        }

        // DELETE api/<PessoaFisicaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            produtoHandler.ExcluirPeloId(id);
            return Ok();
        }

    }
}
