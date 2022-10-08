using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public  class PaisDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public bool Ativo { get; set; }
    }
}
