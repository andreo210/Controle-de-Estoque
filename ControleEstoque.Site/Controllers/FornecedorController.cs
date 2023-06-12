using ControleEstoque.App.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Template.Models;

namespace Template.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly ILogger<FornecedorController> _logger;

        public FornecedorController(ILogger<FornecedorController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Cadastrar(FornecedorCommand fornecedor)
        {
            var x = fornecedor;
            return View();
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult ListarTodos()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
