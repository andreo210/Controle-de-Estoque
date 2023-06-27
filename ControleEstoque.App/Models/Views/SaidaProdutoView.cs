using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class SaidaProdutoView
    {
       
        //atributos 
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public int IdProduto { get; set; }


        //metodos estatico que que fazem conversão de classes para retorno
        public static implicit operator SaidaProdutoEntity(SaidaProdutoView saida)
        {
            return new SaidaProdutoEntity
            {
                Id = saida.Id,
                Numero = saida.Numero,
                Data = saida.Data,
                Quantidade = saida.Quantidade,
                IdProduto = saida.IdProduto,
            };

        }
        public static implicit operator SaidaProdutoView(SaidaProdutoEntity saida)
        {
            return new SaidaProdutoView
            {
                Id = saida.Id,
                Numero = saida.Numero,
                Data = saida.Data,
                Quantidade = saida.Quantidade,
                IdProduto = saida.IdProduto,
            };

        }


        //metodo de retorno da entidade para DTO
        public SaidaProdutoEntity retornoSaidaProduto()
        {
            return new SaidaProdutoEntity()
            {
                Id = this.Id,
                Numero = this.Numero,
                Data = this.Data,
                Quantidade = this.Quantidade,
                IdProduto = this.IdProduto,

            };
        }


        //construtores
        public SaidaProdutoView()
        {

        }


        public SaidaProdutoView(SaidaProdutoEntity entity)
        {
            this.Id = entity.Id;
            this.Numero = entity.Numero;
            this.Data = entity.Data;
            this.Quantidade = entity.Quantidade;
            this.IdProduto = entity.IdProduto;


        }
    }
}
