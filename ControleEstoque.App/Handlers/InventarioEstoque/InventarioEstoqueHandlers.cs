using ControleEstoque.App.Dtos;
using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Repository;
using ControleEstoque.Infra.Data;
using ControleEstoque.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.InventarioEstoque
{
    public class InventarioEstoqueHandlers : IinventarioEstoqueHandlers

    {
        IinventarioEstoqueRepository inventarioRepository;
        private readonly ControleEstoqueContext context;

        public InventarioEstoqueHandlers(IinventarioEstoqueRepository _inventarioRepository, ControleEstoqueContext _context)
        {
            inventarioRepository = _inventarioRepository;
            context = _context;
        }
        public string ExcluirPeloId(int id)
        {
            inventarioRepository.Delete(id);
            inventarioRepository.Save();
            return "ok";
        }

        public List<InventarioEstoqueDTO> RecuperarLista()
        {
            return inventarioRepository.Get().Select(x => new InventarioEstoqueDTO(x)).ToList();
        }

        public InventarioEstoqueDTO RecuperarPeloId(int id)
        {
            var retorno = inventarioRepository.GetByID(id);
            return retorno != null ? new InventarioEstoqueDTO(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            return inventarioRepository.Get().Count();
        }

        public string Salvar(InventarioEstoqueDTO inventarioDTO)
        {
            var model = context.Set<InventarioEstoqueEntity>().AsNoTracking().Where(e => e.Id == inventarioDTO.Id).FirstOrDefault();

            if (model == null)
            {
                inventarioRepository.Insert(inventarioDTO.retornoInventarioEstoque());
                inventarioRepository.Save();
                return "Ok";
            }
            else
            {
                inventarioRepository.Update(inventarioDTO.retornoInventarioEstoque());
                inventarioRepository.Save();
                return "No Content";
            }
        }
    }
}
