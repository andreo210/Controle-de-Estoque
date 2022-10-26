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
        public int RecuperarQuantidade(int cont);

        public  List<CidadeDTO> RecuperarLista(int pagina, int tamPagina, string filtro, string ordem, int idEstado = 0);

        public CidadeDTO RecuperarPeloId(int id);

        public int Salvar();

        public int ExcluirPeloId(int id);

    }
}
