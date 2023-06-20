using ControleEstoque.App.Dtos;
using ControleEstoque.App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.GrupoProduto
{
   public  interface IGrupoProdutoHandlers
    {
        public int RecuperarQuantidade();

        public List<GrupoProdutoView> RecuperarLista();

        public GrupoProdutoView RecuperarPeloId(int id);

        public GrupoProdutoView Salvar(GrupoProdutoCommand grupoDTO);
        public GrupoProdutoView Alterar(GrupoProdutoView grupoDTO);

        public GrupoProdutoView ExcluirPeloId(int id);

    }
}
