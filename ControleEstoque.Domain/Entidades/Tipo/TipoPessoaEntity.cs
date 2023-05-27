using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Entidades.Tipo
{
    public class  TipoPessoaEntity 
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public FornecedorEntity Fornecedor { get; set; }
    }
}
