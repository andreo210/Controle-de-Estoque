using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class EntradaProdutoDTO
    {
        public EntradaProdutoDTO()
        {

        }

        public EntradaProdutoDTO(EntradaProdutoEntity entradaProduto)
        {
            this.Id = entradaProduto.Id;
            this.Numero = entradaProduto.Numero;
            this.Data = entradaProduto.Data;
            this.Quantidade = entradaProduto.Quantidade;
            this.IdProduto = entradaProduto.IdProduto;

        }

        //atributos
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

    }
}
