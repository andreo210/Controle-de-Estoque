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

        public List<ProdutoCommand> RecuperarLista();

        public ProdutoCommand RecuperarPeloId(int id);

        public string Salvar(ProdutoCommand cidadeDTO);

        public string ExcluirPeloId(int id);
    }
}
