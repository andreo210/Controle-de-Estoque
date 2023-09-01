using ControleEstoque.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Models.Command
{
    public class PerfilCommand
    {
        
        public string Nome { get; set; }
        public bool Ativo { get; set; }        
    }
}
