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

        public List<SaidaProdutoDTO> RecuperarLista();

        public SaidaProdutoDTO RecuperarPeloId(int id);

        public string Salvar(SaidaProdutoDTO cidadeDTO);

        public string ExcluirPeloId(int id);
    }
}
