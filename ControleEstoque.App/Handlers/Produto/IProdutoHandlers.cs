using ControleEstoque.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Produto
{
    public interface IProdutoHandlers
    {
        public int RecuperarQuantidade();

        public List<ProdutoView> RecuperarLista();

        public ProdutoView RecuperarPeloId(int id);

        public ProdutoView Salvar(ProdutoCommand command);
        public ProdutoView Alterar (int id,ProdutoCommand command);

        public void ExcluirPeloId(int id);
    }
}
