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
                var lista = enderecoRepository.Get().Select(x => new EnderecoView(x)).ToList();
                return lista;

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
                var retorno = enderecoRepository.GetByID(id);
                return retorno != null ? new EnderecoView(retorno) : null;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
