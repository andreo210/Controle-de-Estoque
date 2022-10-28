using ControleEstoque.App.Dtos;
using ControleEstoque.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Fornecedor
{
    public class FornecedorHandlers : IFornecedorHandlers
    {
        IFornecedorRepository fornecedorRepository;

        public FornecedorHandlers(IFornecedorRepository _fornecedorRepository)
        {
            fornecedorRepository = _fornecedorRepository;

        }
        public string ExcluirPeloId(int id)
        {
            fornecedorRepository.Delete(id);
            fornecedorRepository.Save();
            return "Ok";
        }


        public List<FornecedorDTO> RecuperarLista()
        {
            return fornecedorRepository.Get().Select(x => new FornecedorDTO(x)).ToList();
        }

        public FornecedorDTO RecuperarPeloId(int id)
        {
            var retorno = fornecedorRepository.GetByID(id);
            return retorno != null ? new FornecedorDTO(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            return fornecedorRepository.Get().Count();
        }


        public string Salvar(FornecedorDTO fornecedorDTO)
        {
            fornecedorRepository.Insert(fornecedorDTO.retornoFornecedorEntity());
            fornecedorRepository.Save();
            return "Ok";
        }

        public string SalvarCompleto(FornecedorCompletoDTO fornecedorDTO)
        {
            fornecedorRepository.Insert(fornecedorDTO.retornoFornecedorEntity());
            fornecedorRepository.Save();
            return "Ok";
        }
    }
}
