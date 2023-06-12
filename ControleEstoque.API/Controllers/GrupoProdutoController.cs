using ControleEstoque.API.exceptions;
using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.GrupoProduto;
using ControleEstoque.App.Views;
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
        public IActionResult Post([FromBody] GrupoProdutoCommand grupoDTO)
        { 
            return Ok(grupoHandler.Salvar(grupoDTO));
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] GrupoProdutoView grupoDTO)
        {
            var grupo = grupoHandler.Alterar(grupoDTO);
            if (grupo == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(grupo);

            }
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
            var grupo = grupoHandler.RecuperarPeloId(id);

            if (grupo == null)
            {
                return NotFound();
            }else
            {
                return Ok(grupo);
            }
            
        }

        [HttpGet("Cont")]
        public IActionResult GetQuantidade()
        {
            return Ok(grupoHandler.RecuperarQuantidade());
        }

        // DELETE api/<PessoaFisicaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var grupo = grupoHandler.ExcluirPeloId(id);

            if (grupo == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(grupo);
            }
        }
    }
}
