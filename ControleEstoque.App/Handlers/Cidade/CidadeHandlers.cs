using ControleEstoque.App.Dtos;
using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Repository;
using ControleEstoque.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Cidade
{
    public class CidadeHandlers : ICidadeHandlers
    {
        ICidadeRepository cidadeRepository;
        private readonly ControleEstoqueContext context;
        public CidadeHandlers(ICidadeRepository _cidadeRepository, ControleEstoqueContext _context)
        {
            cidadeRepository = _cidadeRepository;
            context = _context;

        }
        public string ExcluirPeloId(int id)
        {
            cidadeRepository.Delete(id);
            cidadeRepository.Save();
            return "Ok";
        }


        public List<CidadeDTO> RecuperarLista()
        {
            return cidadeRepository.Get().Select(x => new CidadeDTO(x)).ToList();
        }

        public CidadeDTO RecuperarPeloId(int id)
        {
            var retorno = cidadeRepository.GetByID(id);
            return retorno != null ? new CidadeDTO(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            return cidadeRepository.Get().Count();
        }
                

        public string Salvar(CidadeDTO cidadeDTO)
        {
             var model = context.Set<CidadeEntity>().AsNoTracking().Where(e => e.Id == cidadeDTO.Id).FirstOrDefault();

            if (model == null)
            {
                cidadeRepository.Insert(cidadeDTO.retornoCidadeEntity());
                cidadeRepository.Save();
                return "Ok";
            }
            else
            {
                cidadeRepository.Update(cidadeDTO.retornoCidadeEntity());
                cidadeRepository.Save();
                return "No Content";
            }
        }

       
    }
}
