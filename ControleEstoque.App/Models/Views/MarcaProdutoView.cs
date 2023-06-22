using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public  class MarcaProdutoView
    {
        public MarcaProdutoView()
        {

        }
        public MarcaProdutoView(MarcaProdutoEntity entity)
        {
            this.Id = entity.Id;
            this.Nome = entity.Nome;
            this.Ativo = entity.Ativo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public MarcaProdutoEntity retornoMarcaProduto()
        {
            return new MarcaProdutoEntity()
            {
                Id = this.Id,
                Nome = this.Nome,
                Ativo = this.Ativo
            };
        }
    }
}
