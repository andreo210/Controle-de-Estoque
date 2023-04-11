using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.LocalArmazenamento;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalArmazenamentoController : ControllerBase
    {
        ILocalArmazenamentoHandlers localArmazenamentoHadlers;
        public LocalArmazenamentoController(ILocalArmazenamentoHandlers _localArmazenamentoHadlers)
        {
            this.localArmazenamentoHadlers = _localArmazenamentoHadlers;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LocalArmazenamentoDTO localDTO)
        {
            localArmazenamentoHadlers.Salvar(localDTO);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<LocalArmazenamentoDTO> Get()
        {
            return localArmazenamentoHadlers.RecuperarLista();
        }

        // GET api/<PessoaFisicaController>/5
        [HttpGet("{id}")]
        public LocalArmazenamentoDTO Get(int id)
        { 
            return localArmazenamentoHadlers.RecuperarPeloId(id);
        }

        [HttpGet("Cont")]
        public int GetQuantidade()
        {
            return localArmazenamentoHadlers.RecuperarQuantidade();
        }

        // DELETE api/<PessoaFisicaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            localArmazenamentoHadlers.ExcluirPeloId(id);
            return Ok();
        }
    }
}

