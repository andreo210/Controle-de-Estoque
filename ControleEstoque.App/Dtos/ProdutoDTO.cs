using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class ProdutoDTO
    {
        public ProdutoDTO()
        {

        }

        //método DTO para entidade
        public ProdutoDTO(ProdutoEntity entity)
        {
            this.Id = entity.Id;
            this.Codigo = entity.Codigo;
            this.Nome = entity.Nome;
            this.PrecoCusto = entity.PrecoCusto;
            this.PrecoVenda = entity.PrecoVenda;
            this.QuantEstoque = entity.QuantEstoque;
            this.IdUnidadeMedida = entity.IdUnidadeMedida;
            this.UnidadeMedida = entity.UnidadeMedida;
            this.IdGrupo = entity.IdGrupo;
            this.Grupo = entity.Grupo;
            this.IdMarca = entity.IdMarca;
            this.Marca = entity.Marca;
            this.IdFornecedor = entity.IdFornecedor;
            this.Fornecedor = entity.Fornecedor;
            this.IdLocalArmazenamento = entity.IdLocalArmazenamento;
            this.LocalArmazenamento = entity.LocalArmazenamento;
            this.Ativo = entity.Ativo;
            this.Imagem = entity.Imagem;

        }

        //atributos 
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
        public MarcaProdutoEntity Marca { get; set; }
        public int IdFornecedor { get; set; }
        public virtual FornecedorEntity Fornecedor { get; set; }
        public int IdLocalArmazenamento { get; set; }
        public virtual LocalArmazenamentoEntity LocalArmazenamento { get; set; }
        public bool Ativo { get; set; }
        public string Imagem { get; set; }

        //metodo de retorno da entidade para DTO
        public ProdutoEntity retornoProduto()
        {
            return new ProdutoEntity()
            {
                Id = this.Id,
                Codigo = this.Codigo,
                Nome = this.Nome,
                PrecoCusto = this.PrecoCusto,
                PrecoVenda = this.PrecoVenda,
                QuantEstoque = this.QuantEstoque,
                IdUnidadeMedida = this.IdUnidadeMedida,
                IdGrupo = this.IdGrupo,
                IdFornecedor = this.IdFornecedor,
                IdLocalArmazenamento = this.IdLocalArmazenamento,
                Ativo = this.Ativo,
                Imagem = this.Imagem              

            };
        }

    }
}
