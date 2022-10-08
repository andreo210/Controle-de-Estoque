using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Entidades
{
    public class ProdutoEntity
    {
        #region Atributos

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public int QuantEstoque { get; set; }
        public int IdUnidadeMedida { get; set; }
        public virtual UnidadeMedidaEntity UnidadeMedida { get; set; }
        public int IdGrupo { get; set; }
        public virtual GrupoProdutoEntity Grupo { get; set; }
        public int IdMarca { get; set; }
        public  MarcaProdutoEntity Marca { get; set; }
        public int IdFornecedor { get; set; }
        public virtual FornecedorEntity Fornecedor { get; set; }
        public int IdLocalArmazenamento { get; set; }
        public virtual LocalArmazenamentoEntity LocalArmazenamento { get; set; }
        public bool Ativo { get; set; }
        public string Imagem { get; set; }

        #endregion
    }
}
