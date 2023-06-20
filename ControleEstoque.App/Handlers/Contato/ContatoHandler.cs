using ControleEstoque.App.Dtos;
using ControleEstoque.App.Views;
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
        private readonly IFornecedorRepository _fornecedor;

        public ContatoHandler(IContatoRepository contato, IFornecedorRepository fornecedor)
        {
            _contato = contato;
            _fornecedor = fornecedor;

        }

        public List<ContatoView> RecuperarLista()
        {
            try
            {
                var lista = _contato.Get().Select(x => new ContatoView(x)).ToList();
                return lista;

            }catch(Exception e)
            {
                throw;
            }
        }


        public ContatoView FindByID(int id)
        {
            try
            {
                var retorno = _contato.GetByID(id);
                return retorno != null ? new ContatoView(retorno) : null;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public ContatosCommand Salvar(ContatosCommand contatoDTO)
        {
            var x = _contato.Insert(contatoDTO.retornoContatoEntity());
            return new ContatosCommand(x);
        }

        public void ExcluirPeloId(int id)
        {
            try
            {
                _contato.Delete(id);
                _contato.Save();
            }
            catch(Exception e)
            {
                throw;
            }

        }




    }
}
