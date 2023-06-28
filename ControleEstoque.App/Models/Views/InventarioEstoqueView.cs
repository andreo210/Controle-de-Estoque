﻿using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class InventarioEstoqueView
    {
        
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Motivo { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int QuantidadeInventario { get; set; }
        public int IdProduto { get; set; }
        //public ProdutoEntity Produto { get; set; }

        public InventarioEstoqueView()
        {

        }
        public InventarioEstoqueView(InventarioEstoqueEntity entity)
        {
            this.Id = entity.Id;
            this.Data = entity.Data;
            this.Motivo = entity.Motivo;
            this.QuantidadeInventario = entity.QuantidadeInventario;
            this.QuantidadeInventario = entity.QuantidadeEstoque;
            this.IdProduto = entity.IdProduto;
            // this.Produto = entity.Produto;

        }


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

        public static implicit operator InventarioEstoqueEntity(InventarioEstoqueView inventarioEstoque)
        {
            return new InventarioEstoqueEntity
            {                
                Id = inventarioEstoque.Id,
                Data = inventarioEstoque.Data,
                Motivo = inventarioEstoque.Motivo,
                QuantidadeEstoque= inventarioEstoque.QuantidadeEstoque,
                QuantidadeInventario= inventarioEstoque.QuantidadeInventario,
                IdProduto = inventarioEstoque.IdProduto
            };

        }
        public static implicit operator InventarioEstoqueView(InventarioEstoqueEntity inventarioEstoque)
        {
            return new InventarioEstoqueView
            {

                Id = inventarioEstoque.Id,
                Data = inventarioEstoque.Data,
                Motivo = inventarioEstoque.Motivo,
                QuantidadeEstoque = inventarioEstoque.QuantidadeEstoque,
                QuantidadeInventario = inventarioEstoque.QuantidadeInventario,
                IdProduto = inventarioEstoque.IdProduto
            };
        }




    }
}
