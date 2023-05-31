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
            try
            {
                var x = RecuperarPeloId(id);
                if (x != null)
                {
                    fornecedorRepository.Delete(id);
                    fornecedorRepository.Save();
                    return "Ok";
                }
                else
                {
                    return "fornecedor não encontardo";
                }
            }catch(Exception e)
            {
                throw;
            }
           
        }


        public List<FornecedorDTO> RecuperarLista()
        {
            try
            {
                return fornecedorRepository.Get().Select(x => new FornecedorDTO(x)).ToList();
            }catch(Exception e)
            {
                throw;
            }
        }

        public FornecedorDTO RecuperarPeloId(int id)
        {
            try
            {
                var retorno = fornecedorRepository.GetByID(id);
                return retorno != null ? new FornecedorDTO(retorno) : null;
            }catch(Exception e)
            {
                throw;
            }
        }

        public int RecuperarQuantidade()
        {
            try
            {
                return fornecedorRepository.Get().Count();
            }
            catch(Exception e)
            {
                throw;
            }
            
        }


        public FornecedorDTO Salvar(FornecedorDTO fornecedorDTO)       
        {
            try
            {
                var x = fornecedorRepository.Insert(fornecedorDTO.retornoFornecedorEntity());
                return new FornecedorDTO(x);
            }catch(Exception e)
            {
                throw ;
            }
        }

        public string Alterar(FornecedorDTO fornecedorDTO)
        {
            try
            {
                var model = context.Fornecedor.AsNoTracking().FirstOrDefault(x => x.Id == fornecedorDTO.Id);

                if (model != null)
                {
                    fornecedorRepository.Update(fornecedorDTO.retornoFornecedorEntity());
                    fornecedorRepository.Save();
                    return "OK";
                }
                else
                {
                    return "Usuario nao encontrado";
                }
            }
            catch(Exception e)
            {
                throw;
            }
        }

    }

    

}

