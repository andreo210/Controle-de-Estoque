using ControleEstoque.App.Dtos;
using ControleEstoque.App.Models.Views;
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

        private readonly  ILocalArmazenamentoRepository localRepository;
        public LocalArmazenamentoHandlers(ILocalArmazenamentoRepository _localRepository)
        {
            localRepository = _localRepository;
        }
        public void ExcluirPeloId(int id)
        {
            try
            {
                localRepository.Delete(id);
                localRepository.Save();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IEnumerable<LocalArmazenamentoView> RecuperarLista()
        {
            try
            {
               var listaModels = localRepository.Get().Select(model => new LocalArmazenamentoView(model)).ToList();
                return listaModels;
            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        public LocalArmazenamentoView RecuperarPeloId(int id)
        {            
            try
            {
                var model = localRepository.GetByID(id);
                return model is not null ? new LocalArmazenamentoView(model) : null;
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
                return localRepository.Get().Count();
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public LocalArmazenamentoView Salvar(LocalArmazenamentoCommand command)
        {
            try
            {
                command.Ativo = true;
                command.DataCriacao = DateTime.Now;
                var model = localRepository.Insert(command.retornoLocalArmazenamento());
                localRepository.Save();
                return new LocalArmazenamentoView(model);

            }catch(Exception e)
            {
                throw;
            }
            
        }

        public LocalArmazenamentoView Alterar(int id, LocalArmazenamentoCommand local)
        {
            try
            {
                var model = RecuperarPeloId(id);

                if (model is not null)
                {
                    model.Nome = local.Nome;
                    model.Ativo = local.Ativo;
                    localRepository.Save();
                    return model;
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
