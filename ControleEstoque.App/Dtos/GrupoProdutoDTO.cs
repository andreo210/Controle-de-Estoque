using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class GrupoProdutoDTO
    {
        public GrupoProdutoDTO()
        {

        }
        public GrupoProdutoDTO(GrupoProdutoEntity entity)
        {
            this.Id = entity.Id;
            this.Nome = entity.Nome;
            this.Ativo = entity.Ativo;

        }
        //atributos
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public GrupoProdutoEntity retornoGrupoProdutoEntity()
        {
            return new GrupoProdutoEntity()
            {
                Id = this.Id,
                Nome = this.Nome,
                Ativo = this.Ativo
            };
        }
    }
}
