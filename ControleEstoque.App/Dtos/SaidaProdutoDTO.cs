using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class SaidaProdutoDTO
    {
        public SaidaProdutoDTO()
        {

        }

        //método DTO para entidade
        public SaidaProdutoDTO(SaidaProdutoEntity entity)
        {
            this.Id = entity.Id;
            this.Numero = entity.Numero;
            this.Data = entity.Data;
            this.Quantidade = entity.Quantidade;
            this.IdProduto = entity.IdProduto;
           

        }

        //atributos 
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public int IdProduto { get; set; }
        

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
    }
}
