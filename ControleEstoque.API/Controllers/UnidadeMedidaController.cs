using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.UnidadeMedida;
using ControleEstoque.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeMedidaController: ControllerBase
    {
        ControleEstoqueContext context;
        IUnidadeMedidaHandlers unidadeHandler;
        public UnidadeMedidaController(IUnidadeMedidaHandlers _unidadeHandle, ControleEstoqueContext _context)
        {
            this.unidadeHandler = _unidadeHandle;
            this.context = _context;
        }


        // POST api/<PessoaFisicaController>
        [HttpPost]
        public IActionResult Post([FromBody] UnidadeMedidaDTO unidadeDTO)
        {
            unidadeHandler.Salvar(unidadeDTO);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<UnidadeMedidaDTO> Get()
        {
            return unidadeHandler.RecuperarLista();
        }

        // GET api/<PessoaFisicaController>/5
        [HttpGet("{id}")]
        public UnidadeMedidaDTO Get(int id)
        {
            return unidadeHandler.RecuperarPeloId(id);
        }

        [HttpGet("Cont")]
        public int GetQuantidade()
        {
            return unidadeHandler.RecuperarQuantidade();
        }

        // DELETE api/<PessoaFisicaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            unidadeHandler.ExcluirPeloId(id);
            return Ok();
        }
    }
}
