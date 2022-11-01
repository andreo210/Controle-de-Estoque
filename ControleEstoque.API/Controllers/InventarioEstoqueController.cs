using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.InventarioEstoque;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioEstoqueController : ControllerBase
    {
        IinventarioEstoqueHandlers inventarioHandler;
        public InventarioEstoqueController(IinventarioEstoqueHandlers _inventarioHandler)
        {
            this.inventarioHandler = _inventarioHandler;
        }

        // POST api/<PessoaFisicaController>
        [HttpPost]
        public IActionResult Post([FromBody] InventarioEstoqueDTO inventarioDTO)
        {
            inventarioHandler.Salvar(inventarioDTO);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<InventarioEstoqueDTO> Get()
        {
            return inventarioHandler.RecuperarLista();
        }

        // GET api/<PessoaFisicaController>/5
        [HttpGet("{id}")]
        public InventarioEstoqueDTO Get(int id)
        {
            return inventarioHandler.RecuperarPeloId(id);
        }

        [HttpGet("Cont")]
        public int GetQuantidade()
        {
            return inventarioHandler.RecuperarQuantidade();
        }

        // DELETE api/<PessoaFisicaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            inventarioHandler.ExcluirPeloId(id);
            return Ok();
        }
    }
}
