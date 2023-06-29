using ControleEstoque.App.Dtos;
using ControleEstoque.App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Contato
{
    public interface IContatoHandler
    {
        public void ExcluirPeloId(int id);
        public List<ContatoView> RecuperarLista();
        public ContatoView FindByID(int id);
        public ContatoView Salvar(ContatosCommand command);
        
    }
}
