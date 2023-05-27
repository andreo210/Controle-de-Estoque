using ControleEstoque.App.Dtos;
using ControleEstoque.Domain.Repository;
using ControleEstoque.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Fornecedor
{
    public class FornecedorHandlers : IFornecedorHandlers
    {
        
        private readonly ControleEstoqueContext context;

        IFornecedorRepository fornecedorRepository;

        public FornecedorHandlers(IFornecedorRepository _fornecedorRepository, ControleEstoqueContext _context)
        {
            fornecedorRepository = _fornecedorRepository;
            context = _context;

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
            var model = context.Fornecedor.AsNoTracking().FirstOrDefault(x=>x.Id == fornecedorDTO.Id);

            if (model == null)
            {
                fornecedorRepository.Insert(fornecedorDTO.retornoFornecedorEntity());
                fornecedorRepository.Save();
                return "Ok";
            }
            else
            {
                fornecedorRepository.Update(fornecedorDTO.retornoFornecedorEntity());
                fornecedorRepository.Save();
                return "No Content";
            }
        }

        public string Alterar(FornecedorDTO fornecedorDTO)
        {
            var model = context.Fornecedor.AsNoTracking().FirstOrDefault(x => x.Id == fornecedorDTO.Id);

            if (model !=null)
            {
                fornecedorRepository.Update(fornecedorDTO.retornoFornecedorEntity());
                fornecedorRepository.Save();
                return "OK";
            }
            else
            {                
                return "ERROR";
            }
        }

    }

    

}

