using ControleEstoque.App.Dtos;
using ControleEstoque.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Contato
{
    public class ContatoHandler : IContatoHandler
    {
        private readonly IContatoRepository _contato;

        public ContatoHandler(IContatoRepository contato)
        {
            _contato = contato;

        }

        public List<ContatosDto> RecuperarLista()
        {
            return _contato.Get().Select(x => new ContatosDto(x)).ToList();
        }


        public ContatosDto FindByID(int id)
        {
            var retorno = _contato.GetByID(id);
            return retorno != null ? new ContatosDto(retorno) : null;
        }




    }
}
