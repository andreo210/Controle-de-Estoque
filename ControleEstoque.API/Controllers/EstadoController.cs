using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.Estado;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {

        IEstadoHandlers estadoHandler;
        public EstadoController(IEstadoHandlers _estadoHandler)
        {
            this.estadoHandler = _estadoHandler;
        }

        // POST api/<PessoaFisicaController>
        [HttpPost]
        public IActionResult Post([FromBody] EstadoDTO estadoDTO)
        {
            estadoHandler.Salvar(estadoDTO);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<EstadoDTO> Get()
        {
            return estadoHandler.RecuperarLista();
        }

        // GET api/<PessoaFisicaController>/5
        [HttpGet("{id}")]
        public EstadoDTO Get(int id)
        {
            return estadoHandler.RecuperarPeloId(id);
        }

        [HttpGet("Cont")]
        public int GetQuantidade()
        {
            return estadoHandler.RecuperarQuantidade();
        }

        // DELETE api/<PessoaFisicaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            estadoHandler.ExcluirPeloId(id);
            return Ok();
        }

    }
}
