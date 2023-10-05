using ControleEstoque.Domain.Entidades;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class ProdutoCommand
    {       
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public int QuantEstoque { get; set; }
        public int IdUnidadeMedida { get; set; }
        public int IdGrupo { get; set; }
        public int IdMarca { get; set; }
        public int IdFornecedor { get; set; }
        public int IdLocalArmazenamento { get; set; }
        public bool Ativo { get; set; }
        [JsonIgnore]
        public string Imagem { get; set; }
        public string ImagemUpload { get; set; }

        public ProdutoCommand() { }
        public ProdutoCommand(ProdutoEntity entity)
        {
            this.Codigo = entity.Codigo;
            this.Nome = entity.Nome;
            this.PrecoCusto = entity.PrecoCusto;
            this.PrecoVenda = entity.PrecoVenda;
            this.QuantEstoque = entity.QuantEstoque;
            this.IdUnidadeMedida = entity.IdUnidadeMedida;
            this.IdGrupo = entity.IdGrupo;
            this.IdMarca = entity.IdMarca;
            this.IdFornecedor = entity.IdFornecedor;
            this.IdLocalArmazenamento = entity.IdLocalArmazenamento;
            this.Ativo = entity.Ativo;
            //this.Imagem = entity.Imagem;
        }
        public ProdutoEntity retornoProduto()
        {
            return new ProdutoEntity()
            {
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
               // Imagem = this.Imagem              

            };
        }

        //metodos estatico que que fazem conversão de classes para retorno
        public static implicit operator ProdutoEntity(ProdutoCommand model)
        {
            return new ProdutoEntity
            {
                Codigo = model.Codigo,
                Nome = model.Nome,
                PrecoCusto = model.PrecoCusto,
                PrecoVenda = model.PrecoVenda,
                QuantEstoque = model.QuantEstoque,
                IdUnidadeMedida = model.IdUnidadeMedida,
                IdMarca = model.IdMarca,
                IdGrupo = model.IdGrupo,
                IdFornecedor = model.IdFornecedor,
                IdLocalArmazenamento = model.IdLocalArmazenamento,
                Ativo = model.Ativo,
                Imagem = model.Imagem
            };

        }
        public static implicit operator ProdutoCommand(ProdutoEntity model)
        {
            return new ProdutoCommand
            {
                Codigo = model.Codigo,
                Nome = model.Nome,
                PrecoCusto = model.PrecoCusto,
                PrecoVenda = model.PrecoVenda,
                QuantEstoque = model.QuantEstoque,
                IdUnidadeMedida = model.IdUnidadeMedida,
                IdMarca = model.IdMarca,
                IdGrupo = model.IdGrupo,
                IdFornecedor = model.IdFornecedor,
                IdLocalArmazenamento = model.IdLocalArmazenamento,
                Ativo = model.Ativo,
                Imagem = model.Imagem
            };

        }

    }
}
