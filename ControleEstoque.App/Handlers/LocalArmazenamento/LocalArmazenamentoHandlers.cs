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

namespace ControleEstoque.App.Handlers.LocalArmazenamento
{
    public class LocalArmazenamentoHandlers : ILocalArmazenamentoHandlers
    {

        ILocalArmazenamentoRepository localRepository;
        private readonly ControleEstoqueContext context;
        public LocalArmazenamentoHandlers(ILocalArmazenamentoRepository _localRepository, ControleEstoqueContext _context)
        {
            localRepository = _localRepository;
            context = _context;
        }
        public string ExcluirPeloId(int id)
        {
            localRepository.Delete(id);
            localRepository.Save();
            return "ok";

            
        }

        public List<LocalArmazenamentoDTO> RecuperarLista()
        {
            return localRepository.Get().Select(x => new LocalArmazenamentoDTO(x)).ToList();
        }

        public LocalArmazenamentoDTO RecuperarPeloId(int id)
        {
            var retorno = localRepository.GetByID(id);
            return retorno != null ? new LocalArmazenamentoDTO(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            return localRepository.Get().Count();

        }

        public string Salvar(LocalArmazenamentoDTO localDTO)
        {
            var model = context.Set<LocalArmazenamentoEntity>().AsNoTracking().Where(e => e.Id == localDTO.Id).FirstOrDefault();

            if (model == null)
            {
                localRepository.Insert(localDTO.retornoLocalArmazenamento());
               localRepository.Save();
                return "Ok";
            }
            else
            {
                localRepository.Update(localDTO.retornoLocalArmazenamento());
                localRepository.Save();
                return "No Content";
            }
        }
    }
}
