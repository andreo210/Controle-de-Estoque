using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class InventarioEstoqueDTO
    {
        public InventarioEstoqueDTO()
        {

        }
        public InventarioEstoqueDTO(InventarioEstoqueEntity entity)
        {
            this.Id = entity.Id;
            this.Data = entity.Data;
            this.Motivo = entity.Motivo;
            this.QuantidadeInventario = entity.QuantidadeInventario;
            this.QuantidadeInventario = entity.QuantidadeEstoque;
            this.IdProduto = entity.IdProduto;
            this.Produto = entity.Produto;
                 
        }

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Motivo { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int QuantidadeInventario { get; set; }
        public int IdProduto { get; set; }
        public ProdutoEntity Produto { get; set; }

        public InventarioEstoqueEntity retornoInventarioEstoque()
        {
            return new InventarioEstoqueEntity(){
                Id = this.Id,
                Data = this.Data,
                Motivo = this.Motivo,
                QuantidadeEstoque= this.QuantidadeEstoque,
                QuantidadeInventario = this.QuantidadeInventario,
                IdProduto = this.IdProduto
            };
        }
    }
}
