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

        public List<ContatosDTO> RecuperarLista()
        {
            return _contato.Get().Select(x => new ContatosDTO(x)).ToList();
        }


        public ContatosDTO FindByID(int id)
        {
            var retorno = _contato.GetByID(id);
            return retorno != null ? new ContatosDTO(retorno) : null;
        }
        public ContatosDTO Salvar(ContatosDTO contatoDTO)
        {
            var x = _contato.Insert(contatoDTO.retornoContatoEntity());
            return new ContatosDTO(x);
        }

        public string ExcluirPeloId(int id)
        {
            try
            {
                _contato.Delete(id);
                _contato.Save();
                return "OK";
            }catch(Exception e)
            {
                return "ERROR";
            }

        }




    }
}
