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

        public List<LocalArmazenamentoView> RecuperarLista()
        {
            return localRepository.Get().Select(x => new LocalArmazenamentoView(x)).ToList();
        }

        public LocalArmazenamentoView RecuperarPeloId(int id)
        {
            var retorno = localRepository.GetByID(id);
            return retorno != null ? new LocalArmazenamentoView(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            return localRepository.Get().Count();

        }

        public LocalArmazenamentoView Salvar(LocalArmazenamentoCommand localDTO)
        {
            try
            {
                var x = localRepository.Insert(localDTO.retornoLocalArmazenamento());
                localRepository.Save();
                return new LocalArmazenamentoView(x);

            }catch(Exception e)
            {
                throw;
            }
            
        }

        public LocalArmazenamentoView Alterar(int id, LocalArmazenamentoCommand local)
        {
            try
            {
                var model = context.LocalArmazenamento.FirstOrDefault(x => x.Id == id);

                if (model != null)
                {
                    model.Nome = local.Nome;
                    model.Ativo = local.Ativo;
                    context.SaveChanges();
                    return new LocalArmazenamentoView(model);
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
