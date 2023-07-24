using ControleEstoque.App.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Helpers
{
    public class PaginacaoList<T>
    {
        public List<T> Resultado { get; set; } = new List<T>();
        public Paginacao Paginacao { get; set; }
        public List<LinkView> Links { get; set; }
    }
}
