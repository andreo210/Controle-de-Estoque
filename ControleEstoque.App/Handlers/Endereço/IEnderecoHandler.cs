using ControleEstoque.App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Endereço
{
    public interface IEnderecoHandler
    {
        public List<EnderecoView> RecuperarLista();
        public EnderecoView FindByID(int id);
    }
}
