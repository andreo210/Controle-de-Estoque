using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class EntradaProdutoCommand
    {
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public int IdProduto { get; set; }

        public EntradaProdutoCommand(){ }

        public EntradaProdutoCommand(EntradaProdutoEntity entradaProduto)
        {
            this.Numero = entradaProduto.Numero;
            this.Data = entradaProduto.Data;
            this.Quantidade = entradaProduto.Quantidade;
            this.IdProduto = entradaProduto.IdProduto;

        }

        //retorna os valores da entidade
        public EntradaProdutoEntity retornoEntradaProdutoEntity()
        {
            return new EntradaProdutoEntity
            {                
                Numero = this.Numero,
                Data = this.Data,
                Quantidade = this.Quantidade,
                IdProduto = this.IdProduto
            };
        }

        public static implicit operator EntradaProdutoEntity(EntradaProdutoCommand model)
        {
            return new EntradaProdutoEntity
            {
                Numero = model.Numero,
                Data = model.Data,
                Quantidade = model.Quantidade,
                IdProduto = model.IdProduto
            };

        }
        public static implicit operator EntradaProdutoCommand(EntradaProdutoEntity model)
        {
            return new EntradaProdutoCommand
            {
                Numero = model.Numero,
                Data = model.Data,
                Quantidade = model.Quantidade,
                IdProduto = model.IdProduto
            };
        }
    }
}
