using ControleEstoque.Domain.Entidades.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Entidades
{
    public class ContatoEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string DDD { get; set; }
        public string CodigoPais { get; set; }
        public bool Ativo { get; set; }

        public int TipoContatoId { get; set; }
        public TipoContatoEntity TipoContato { get; set; }

        public int IdFornecedor { get; set; }
        public FornecedorEntity Fornecedor { get; set; }
    }
}
