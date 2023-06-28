using ControleEstoque.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.EntradaProduto
{
    public interface IEntradaProdutoHandlers
    {
        public int RecuperarQuantidade();

        public List<EntradaProdutoView> RecuperarLista();

        public EntradaProdutoView RecuperarPeloId(int id);

        public EntradaProdutoView Salvar(EntradaProdutoCommand cidadeDTO);

        public void ExcluirPeloId(int id);
        public EntradaProdutoView Alterar(int id, EntradaProdutoCommand Entrada);
    }
}
