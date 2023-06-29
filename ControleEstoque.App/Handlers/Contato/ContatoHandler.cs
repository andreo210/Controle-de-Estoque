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

        public void ExcluirPeloId(int id)
        {
            try
            {
                _contato.Delete(id);
                _contato.Save();
            }
            catch (Exception e)
            {
                throw;
            }

        }


        public List<ContatoView> RecuperarLista()
        {
            try
            {
              var ListaModel = _contato.Get().Select(model => new ContatoView(model)).ToList();
              return ListaModel;

            }catch(Exception e)
            {
                throw;
            }
        }


        public ContatoView FindByID(int id)
        {
            try
            {
                var model = _contato.GetByID(id);
                return model is not null ? new ContatoView(model) : null;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public ContatoView Salvar(ContatosCommand command)
        {
            try
            {
                var model = _contato.Insert(command.retornoContatoEntity());
                return new ContatoView(model);
            }
            catch (Exception e)
            {
                throw;
            }
        }
             


    }
}
