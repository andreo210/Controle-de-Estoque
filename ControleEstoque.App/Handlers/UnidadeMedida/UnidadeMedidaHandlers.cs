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
        private readonly ControleEstoqueContext context;

        public UnidadeMedidaHandlers(IUnidadeMedidaRepository _EntradaRepository, ControleEstoqueContext _context)
        {
            EntradaRepository = _EntradaRepository;
            context = _context;
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
            return EntradaRepository.Get().Select(x => new UnidadeMedidaView(x)).ToList();
        }

        public UnidadeMedidaView RecuperarPeloId(int id)
        {
            var retorno = EntradaRepository.GetByID(id);
            return retorno != null ? new UnidadeMedidaView(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            return EntradaRepository.Get().Count();
        }

        public UnidadeMedidaView Salvar(UnidadeMedidaCommand cidade)
        {

            try
            {
                var model = EntradaRepository.Insert(cidade);
                EntradaRepository.Save();
                return new UnidadeMedidaView(model);
            }
            catch (Exception e)
            {
                throw;
            }

        }


        public UnidadeMedidaView Alterar(int id, UnidadeMedidaCommand Entrada)
        {

            var model = context.UnidadeMedida.FirstOrDefault(x => x.Id == id);

            if (model is not null)
            {
                model.Nome = Entrada.Nome;
                model.Sigla= Entrada.Sigla;
                model.Ativo = Entrada.Ativo;
                context.SaveChanges();
                return model;
            }
            else
            {
                return null;
            }
        }
                
    }
}

