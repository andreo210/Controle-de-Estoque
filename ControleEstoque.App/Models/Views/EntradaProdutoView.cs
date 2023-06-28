using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class EntradaProdutoView
    {
                      
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public int IdProduto { get; set; }

        //retorna os valores da entidade
        public EntradaProdutoEntity retornoEntradaProdutoEntity()
        {
            return new EntradaProdutoEntity
            {
                Id = this.Id,
                Numero = this.Numero,
                Data = this.Data,
                Quantidade = this.Quantidade,
                IdProduto = this.IdProduto
            };
        }

        public EntradaProdutoView()
        {

        }

        public EntradaProdutoView(EntradaProdutoEntity entradaProduto)
        {
            this.Id = entradaProduto.Id;
            this.Numero = entradaProduto.Numero;
            this.Data = entradaProduto.Data;
            this.Quantidade = entradaProduto.Quantidade;
            this.IdProduto = entradaProduto.IdProduto;
        }

        public static implicit operator EntradaProdutoEntity(EntradaProdutoView view)
        {
            return new EntradaProdutoEntity
            {
                Id = view.Id,
                Numero = view.Numero,
                Data = view.Data,
                Quantidade = view.Quantidade,
                IdProduto = view.IdProduto
            };

        }
        public static implicit operator EntradaProdutoView(EntradaProdutoEntity entity)
        {
            return new EntradaProdutoView
            {
                Id = entity.Id,
                Numero = entity.Numero,
                Data = entity.Data,
                Quantidade = entity.Quantidade,
                IdProduto = entity.IdProduto
            };
        }

    }
}
