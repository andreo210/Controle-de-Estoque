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

        [HttpPost]
        public IActionResult Post([FromBody] InventarioEstoqueDTO inventarioDTO)
        {
            inventarioHandler.Salvar(inventarioDTO);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(inventarioHandler.RecuperarLista());
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok( inventarioHandler.RecuperarPeloId(id));
        }

        [HttpGet("Cont")]
        public IActionResult GetQuantidade()
        {
            return Ok( inventarioHandler.RecuperarQuantidade());
        }

  
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            inventarioHandler.ExcluirPeloId(id);
            return Ok();
        }
    }
}
