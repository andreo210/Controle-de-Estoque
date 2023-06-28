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

        public List<UnidadeMedidaView> RecuperarLista();

        public UnidadeMedidaView RecuperarPeloId(int id);

        public UnidadeMedidaView Salvar(UnidadeMedidaCommand unidade);

        public void ExcluirPeloId(int id);

        public UnidadeMedidaView Alterar(int id, UnidadeMedidaCommand unidade);
    }
}
