using ControleEstoque.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Cidade
{
    public interface ICidadeHandlers 
    {
        public int RecuperarQuantidade();

        public  List<CidadeDTO> RecuperarLista();

        public CidadeDTO RecuperarPeloId(int id);

        public string Salvar(CidadeDTO cidadeDTO);

        public string ExcluirPeloId(int id);

    }
}
