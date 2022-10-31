using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.GrupoProduto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoProdutoController : ControllerBase
    {
        IGrupoProdutoHandlers grupoHandler;
        public GrupoProdutoController(IGrupoProdutoHandlers _grupoHandlerr)
        {
            this.grupoHandler = _grupoHandlerr;
        }

        // POST api/<PessoaFisicaController>
        [HttpPost]
        public IActionResult Post([FromBody] GrupoProdutoDTO grupoDTO)
        {
            grupoHandler.Salvar(grupoDTO);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<GrupoProdutoDTO> Get()
        {
            return grupoHandler.RecuperarLista();
        }

        // GET api/<PessoaFisicaController>/5
        [HttpGet("{id}")]
        public GrupoProdutoDTO Get(int id)
        {
            return grupoHandler.RecuperarPeloId(id);
        }

        [HttpGet("Cont")]
        public int GetQuantidade()
        {
            return grupoHandler.RecuperarQuantidade();
        }

        // DELETE api/<PessoaFisicaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            grupoHandler.ExcluirPeloId(id);
            return Ok();
        }
    }
}
