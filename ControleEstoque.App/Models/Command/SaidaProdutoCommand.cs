using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class SaidaProdutoCommand
    {
                   
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public int IdProduto { get; set; }



        //metodos estatico que que fazem conversão de classes para retorno
        public static implicit operator SaidaProdutoEntity(SaidaProdutoCommand saida)
        {
            return new SaidaProdutoEntity
            {                
                Numero = saida.Numero,
                Data = saida.Data,
                Quantidade = saida.Quantidade,
                IdProduto = saida.IdProduto,                
            };

        }
        public static implicit operator SaidaProdutoCommand(SaidaProdutoEntity saida)
        {
            return new SaidaProdutoCommand
            {
                Numero = saida.Numero,
                Data = saida.Data,
                Quantidade = saida.Quantidade,
                IdProduto = saida.IdProduto,
            };

        }

        public SaidaProdutoEntity retornoSaidaProduto()
        {
            return new SaidaProdutoEntity()
            {
                Numero = this.Numero,
                Data = this.Data,
                Quantidade = this.Quantidade,
                IdProduto = this.IdProduto,

            };
        }

        //construtores
        public SaidaProdutoCommand() { }

        public SaidaProdutoCommand(SaidaProdutoEntity entity)
        {
            this.Numero = entity.Numero;
            this.Data = entity.Data;
            this.Quantidade = entity.Quantidade;
            this.IdProduto = entity.IdProduto;

        }
    }
}
