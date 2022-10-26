using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.Pais;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PaisController :  ControllerBase
    {

        IPaisHandlers paisHandler;
        public PaisController(IPaisHandlers _paisHandler)
        {
            this.paisHandler = _paisHandler;
        }

        // POST api/<PessoaFisicaController>
        [HttpPost]
        public IActionResult Post([FromBody] PaisDTO paisDTO)
        {
            
            paisHandler.Salvar(paisDTO);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<PaisDTO> Get()
        {
            return paisHandler.RecuperarLista();
        }

        // GET api/<PessoaFisicaController>/5
        [HttpGet("{id}")]
        public PaisDTO Get(int id)
        {
            return paisHandler.RecuperarPeloId(id);
        }

        [HttpGet("Cont")]
        public int GetTodos()
        {
            return paisHandler.RecuperarQuantidade();
        }

        // DELETE api/<PessoaFisicaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            paisHandler.ExcluirPeloId(id);
            return Ok();
        }

    }
}
