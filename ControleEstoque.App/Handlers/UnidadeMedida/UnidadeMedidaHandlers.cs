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
    public class UnidadeMedidaHandlers : IUnidadeMedidaHandlers
    {
        private readonly IUnidadeMedidaRepository EntradaRepository;

        public UnidadeMedidaHandlers(IUnidadeMedidaRepository _EntradaRepository )
        {
            EntradaRepository = _EntradaRepository;
        }
        public void ExcluirPeloId(int id)
        {
            try
            {
                EntradaRepository.Delete(id);
                EntradaRepository.Save();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<UnidadeMedidaView> RecuperarLista()
        {            
            try
            {
                var listaModel = EntradaRepository.Get().Select(model => new UnidadeMedidaView(model)).ToList();
                return listaModel;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public UnidadeMedidaView RecuperarPeloId(int id)
        {            
            try
            {
                var model = EntradaRepository.GetByID(id);
                return model is not null ? new UnidadeMedidaView(model) : null; 
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
                return EntradaRepository.Get().Count();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public UnidadeMedidaView Salvar(UnidadeMedidaCommand command)
        {

            try
            {
                var model = EntradaRepository.Insert(command);
                EntradaRepository.Save();
                return model;
            }
            catch (Exception e)
            {
                throw;
            }

        }


        public UnidadeMedidaView Alterar(int id, UnidadeMedidaCommand command)
        {

            var model = RecuperarPeloId(id);

            if (model is not null)
            {
                model.Nome = command.Nome;
                model.Sigla= command.Sigla;
                model.Ativo = command.Ativo;
                EntradaRepository.Save();
                return model;
            }
            else
            {
                return null;
            }
        }
                
    }
}

