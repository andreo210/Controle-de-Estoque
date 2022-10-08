using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public  class EstadoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public bool Ativo { get; set; }
        public int IdPais { get; set; }
        public  PaisDTO Pais { get; set; }
    }
}
