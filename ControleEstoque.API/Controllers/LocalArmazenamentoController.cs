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
    { //
        ILocalArmazenamentoHandlers localArmazenamentoHadlers;
        public LocalArmazenamentoController(ILocalArmazenamentoHandlers _localArmazenamentoHadlers)
        {
            this.localArmazenamentoHadlers = _localArmazenamentoHadlers;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LocalArmazenamentoDTO localDTO)
        {
            
                var x = localArmazenamentoHadlers.Salvar(localDTO);
                return Ok(x);
           
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] LocalArmazenamentoDTO localDTO)
        {
            var x = localArmazenamentoHadlers.Alterar(localDTO);
            return Ok(x);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(localArmazenamentoHadlers.RecuperarLista());
        }

        // GET api/<PessoaFisicaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(localArmazenamentoHadlers.RecuperarPeloId(id));
        }

        [HttpGet("Cont")]
        public IActionResult GetQuantidade()
        {
            return Ok(localArmazenamentoHadlers.RecuperarQuantidade());
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

