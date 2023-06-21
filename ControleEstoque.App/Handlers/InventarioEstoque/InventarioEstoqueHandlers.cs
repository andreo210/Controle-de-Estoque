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
        public void ExcluirPeloId(int id)
        {
            inventarioRepository.Delete(id);
            inventarioRepository.Save();            
        }

        public List<InventarioEstoqueView> RecuperarLista()
        {
            return inventarioRepository.Get().Select(x => new InventarioEstoqueView(x)).ToList();
        }

        public InventarioEstoqueView RecuperarPeloId(int id)
        {
            var retorno = inventarioRepository.GetByID(id);
            return retorno != null ? new InventarioEstoqueView(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            return inventarioRepository.Get().Count();
        }

        public InventarioEstoqueView Salvar(InventarioEstoqueCommand inventario)
        {
            try
            {
                var x = inventarioRepository.Insert(inventario.retornoInventarioEstoque());
                inventarioRepository.Save();
                return new InventarioEstoqueView(x);
            }
            catch (Exception e)
            {
                throw;
            }
            
        }
      


        public InventarioEstoqueView Alterar(int id, InventarioEstoqueCommand inventario)
        {

            var model = context.InventarioEstoque.FirstOrDefault(x => x.Id == id);

            if (model != null)
            {
                model.Data = inventario.Data;
                model.IdProduto = inventario.IdProduto;
                model.Motivo = inventario.Motivo;
                model.QuantidadeEstoque = inventario.QuantidadeEstoque;
                model.QuantidadeInventario = inventario.QuantidadeInventario;
                context.InventarioEstoque.Update(model);
                context.SaveChanges();
                return new InventarioEstoqueView(model);
            }
            else
            {
                return null;
            }
        }

    }
}
