using ControleEstoque.App.Views;
using ControleEstoque.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Endereço
{
    public class EnderecoHandler: IEnderecoHandler
    {
        private readonly IEnderecoRepository enderecoRepository;

        public EnderecoHandler(IEnderecoRepository enderecoRepository)
        {
            this.enderecoRepository = enderecoRepository;
        }

        public List<EnderecoView> RecuperarLista()
        {
            try
            {    
                var listaModels = enderecoRepository.Get().Select(model => new EnderecoView(model)).ToList();
                return listaModels;
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public EnderecoView FindByID(int id)
        {
            try
            {
                var model = enderecoRepository.GetByID(id);
                return model is not null ? new EnderecoView(model) : null;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
