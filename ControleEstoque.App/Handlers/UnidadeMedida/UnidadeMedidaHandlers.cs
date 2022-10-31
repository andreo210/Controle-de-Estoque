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

namespace ControleEstoque.App.Handlers.UnidadeMedida
{
    class UnidadeMedidaHandlers : IUnidadeMedidaHandlers
    {
        IUnidadeMedidaRepository unidadeRepository;
        private readonly ControleEstoqueContext context;
        public UnidadeMedidaHandlers(IUnidadeMedidaRepository _unidadeRepository, ControleEstoqueContext _context)
        {
            unidadeRepository = _unidadeRepository;
            context = _context;
        }
        public string ExcluirPeloId(int id)
        {
            unidadeRepository.Delete(id);
            unidadeRepository.Save();
            return "Ok";
        }


        public List<UnidadeMedidaDTO> RecuperarLista()
        {
            return unidadeRepository.Get().Select(x => new UnidadeMedidaDTO(x)).ToList();
        }

        public UnidadeMedidaDTO RecuperarPeloId(int id)
        {
            var retorno = unidadeRepository.GetByID(id);
            return retorno != null ? new UnidadeMedidaDTO(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            return unidadeRepository.Get().Count();
        }


        public string Salvar(UnidadeMedidaDTO unidadeDTO)
        {
            var model = context.Set<UnidadeMedidaEntity>().AsNoTracking().Where(e => e.Id == unidadeDTO.Id).FirstOrDefault();

            if (model == null)
            {
                unidadeRepository.Insert(unidadeDTO.retornoUnidadeMedida());
                unidadeRepository.Save();
                return "Ok";
            }
            else
            {
                unidadeRepository.Update(unidadeDTO.retornoUnidadeMedida());
                unidadeRepository.Save();
                return "No Content";
            }
        }


    }
}

