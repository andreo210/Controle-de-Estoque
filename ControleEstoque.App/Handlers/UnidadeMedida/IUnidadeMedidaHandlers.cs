using ControleEstoque.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.UnidadeMedida
{
    public interface IUnidadeMedidaHandlers
    {
        public int RecuperarQuantidade();

        public List<UnidadeMedidaDTO> RecuperarLista();

        public UnidadeMedidaDTO RecuperarPeloId(int id);

        public string Salvar(UnidadeMedidaDTO cidadeDTO);

        public string ExcluirPeloId(int id);
    }
}
