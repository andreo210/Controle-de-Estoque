using ControleEstoque.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.SaidaProduto
{
    public interface ISaidaProdutoHandlers
    {
        public int RecuperarQuantidade();

        public List<SaidaProdutoView> RecuperarLista();

        public SaidaProdutoView RecuperarPeloId(int id);

        public SaidaProdutoView Salvar(SaidaProdutoCommand cidadeDTO);

        public void ExcluirPeloId(int id);
        public SaidaProdutoView Alterar(int id, SaidaProdutoCommand saida);
    }
}
