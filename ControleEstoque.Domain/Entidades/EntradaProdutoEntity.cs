using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Entidades
{
    public class EntradaProdutoEntity
    {
       


        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public int IdProduto { get; set; }
        public virtual ProdutoEntity Produto { get; set; }



        
    }
}

