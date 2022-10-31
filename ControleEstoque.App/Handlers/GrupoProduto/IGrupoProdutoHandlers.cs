using ControleEstoque.App.Dtos;
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

        public List<GrupoProdutoDTO> RecuperarLista();

        public GrupoProdutoDTO RecuperarPeloId(int id);

        public string Salvar(GrupoProdutoDTO cidadeDTO);

        public string ExcluirPeloId(int id);

    }
}
