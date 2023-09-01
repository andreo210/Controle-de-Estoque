using ControleEstoque.App.Models.Command;
using ControleEstoque.App.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Pefil
{
    public interface IPerfilHandlers
    {
        public int RecuperarQuantidade();

        public IEnumerable<PerfilView> RecuperarLista();

        public PerfilView RecuperarPeloId(int id);

        public PerfilView Salvar(PerfilCommand command);
        public PerfilView Alterar(int id, PerfilCommand command);

        public void ExcluirPeloId(int id);
    }
}
