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

        public InventarioEstoqueHandlers(IinventarioEstoqueRepository _inventarioRepository)
        {
            inventarioRepository = _inventarioRepository;
        }
        public void ExcluirPeloId(int id)
        {
            try
            {
                inventarioRepository.Delete(id);
                inventarioRepository.Save();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<InventarioEstoqueView> RecuperarLista()
        {
            try
            {
                var listaModels = inventarioRepository.Get().Select(model => new InventarioEstoqueView(model)).ToList();
                return listaModels;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public InventarioEstoqueView RecuperarPeloId(int id)
        {
            try
            {
                var model = inventarioRepository.GetByID(id);
                return model is not null ? new InventarioEstoqueView(model) : null;
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public int RecuperarQuantidade()
        {
            try
            {
                return inventarioRepository.Get().Count();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public InventarioEstoqueView Salvar(InventarioEstoqueCommand command)
        {
            try
            {
                var model = inventarioRepository.Insert(command.retornoInventarioEstoque());
                inventarioRepository.Save();
                return new InventarioEstoqueView(model);
            }
            catch (Exception e)
            {
                throw;
            }
            
        }
      


        public InventarioEstoqueView Alterar(int id, InventarioEstoqueCommand command)
        {
            try
            {
                var model = RecuperarPeloId(id);
                if (model is not null)
                {
                    model.Data = command.Data;
                    model.IdProduto = command.IdProduto;
                    model.Motivo = command.Motivo;
                    model.QuantidadeEstoque = command.QuantidadeEstoque;
                    model.QuantidadeInventario = command.QuantidadeInventario;
                    inventarioRepository.Save();
                    return new InventarioEstoqueView(model);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }

    }
}
