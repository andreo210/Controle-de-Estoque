using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Entidades
{
    public class LocalArmazenamentoEntity
    {
       
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public ICollection<ProdutoEntity> Produtos { get; set; }
    }
}
