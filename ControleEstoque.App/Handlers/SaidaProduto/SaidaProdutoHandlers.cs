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

namespace ControleEstoque.App.Handlers.SaidaProduto
{
    class SaidaProdutoHandlers : ISaidaProdutoHandlers
    {
        private readonly ISaidaProdutoRepository saidaRepository;

        public SaidaProdutoHandlers(ISaidaProdutoRepository _saidaRepository)
        {
            saidaRepository = _saidaRepository;
        }
        public void ExcluirPeloId(int id)
        {
            try
            {
                saidaRepository.Delete(id);
                saidaRepository.Save();
            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        public List<SaidaProdutoView> RecuperarLista()
        {
            try
            {
                return saidaRepository.Get().Select(x => new SaidaProdutoView(x)).ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public SaidaProdutoView RecuperarPeloId(int id)
        {  
            try
            {
                var model = saidaRepository.GetByID(id);
                return model is not null ? model : null;
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
                return saidaRepository.Get().Count();
            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        public SaidaProdutoView Salvar(SaidaProdutoCommand command)
        {
            try
            {
                var model= saidaRepository.Insert(command);
                saidaRepository.Save();
                return new SaidaProdutoView(model);
            }
            catch (Exception e)
            {
                throw;
            }

        }


        public SaidaProdutoView Alterar(int id, SaidaProdutoCommand command)
        {            
            try
            {
                var model = RecuperarPeloId(id);
                if (model != null)
                {
                    model.IdProduto = command.IdProduto;
                    model.Numero = command.Numero;
                    model.Data = DateTime.Now;
                    model.Quantidade = command.Quantidade;
                    saidaRepository.Save();
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
