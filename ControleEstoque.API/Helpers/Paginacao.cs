using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Helpers
{
    public class Paginacao 
    { 
        public int NumeroDaPaginas { get; set; }
        public int NumeroDeRegistroPorPaginas { get; set; }
        public int TotalDeRegistro { get; set; }
        public int TotalDePaginas { get; set; }

    }
}
