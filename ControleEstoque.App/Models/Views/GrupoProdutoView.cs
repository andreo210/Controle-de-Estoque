using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Views
{
    public class GrupoProdutoView
    {
        public GrupoProdutoView(GrupoProdutoEntity entity)
        {
            this.Id = entity.Id;
            this.Nome = entity.Nome;
            this.Ativo = entity.Ativo;
        }
        public GrupoProdutoView()
        {

        }
        
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
