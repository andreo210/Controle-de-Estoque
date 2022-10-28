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
        #region Atributos
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string NumDocumento { get; set; }
        public TipoPessoaEntity Tipo { get; set; }
        public string Telefone { get; set; }
        public string Contato { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }

        //um fornecedor pertence a um pais, um estado e a uma cidade
        public int IdPais { get; set; }
        public virtual PaisEntity Pais { get; set; }
        public int IdEstado { get; set; }
        public virtual EstadoEntity Estado { get; set; }
        public int IdCidade { get; set; }
        public virtual CidadeEntity Cidade { get; set; }
        public bool Ativo { get; set; }
        #endregion
    }
}
