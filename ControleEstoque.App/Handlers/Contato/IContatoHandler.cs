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
        public List<ContatoView> RecuperarLista();
        public ContatosDTO FindByID(int id);
        public ContatosDTO Salvar(ContatosDTO contatoDTO);
        public string ExcluirPeloId(int id);
    }
}
