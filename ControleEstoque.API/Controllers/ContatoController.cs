using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.Contato;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoHandler _contatosHandler;
        public ContatoController(IContatoHandler contatosHandler)
        {
            _contatosHandler = contatosHandler;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var x =_contatosHandler.RecuperarLista();
            return Ok(x);
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var x = _contatosHandler.FindByID(id);
            return Ok(x);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ContatosDTO contatosDTO)
        {
            var x = _contatosHandler.Salvar(contatosDTO);
            if (x != null)
            {
                return Ok(x);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var x = _contatosHandler.ExcluirPeloId(id);

            if (x=="OK")
            {
                _contatosHandler.ExcluirPeloId(id);
                return Ok(id + " excluido com sucesso");
            }
            else
            {
                return NotFound("objeto com id: " + id + " não encontrado");
            }
        }
    }
}
