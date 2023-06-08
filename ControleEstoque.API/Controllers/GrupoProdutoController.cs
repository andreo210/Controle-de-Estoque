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
            return Ok(grupoHandler.Salvar(grupoDTO));
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] GrupoProdutoDTO grupoDTO)
        {
            grupoHandler.Alterar(grupoDTO);
            return Ok(grupoDTO);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok( grupoHandler.RecuperarLista());
        }

        // GET api/<PessoaFisicaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok( grupoHandler.RecuperarPeloId(id));
        }

        [HttpGet("Cont")]
        public IActionResult GetQuantidade()
        {
            return Ok( grupoHandler.RecuperarQuantidade());
        }

        // DELETE api/<PessoaFisicaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            grupoHandler.ExcluirPeloId(id);
            return Ok("Grupo de Produto com id : "+id+ " foi excluido com sucesso");
        }
    }
}
