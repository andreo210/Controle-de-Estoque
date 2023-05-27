using ControleEstoque.Domain.Entidades.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Entidades
{
   public  class FornecedorEntity
    {
   
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string NumDocumento { get; set; }
        public string  Email { get; set; }
        public ContatoEntity Contato { get; set; }

        public EnderecoEntity Endereco { get; set; } 
      


        public int TipoFornecedorId { get; set; }
        public TipoPessoaEntity TipoPessoa { get; set; }

        public bool Ativo { get; set; }
     
    }
}
