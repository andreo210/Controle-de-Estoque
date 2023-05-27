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
        public IActionResult PegarTodos()
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
    }
}
