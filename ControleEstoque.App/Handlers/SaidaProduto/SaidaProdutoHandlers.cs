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
        private readonly IProdutoRepository ProdutoRepository;

        public SaidaProdutoHandlers(ISaidaProdutoRepository _saidaRepository, IProdutoRepository _ProdutoRepository)
        {
            saidaRepository = _saidaRepository;
            ProdutoRepository = _ProdutoRepository;
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
                var produto = SubtrairProduto(command.IdProduto, command.Quantidade);
                if (produto is not null)
                {
                    var model = saidaRepository.Insert(command);
                    saidaRepository.Save();
                    return new SaidaProdutoView(model);
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
        private ProdutoView SubtrairProduto(int id, int quantidade)
        {
            try
            {
                var model = ProdutoRepository.GetByID(id);

                if (model is not null)
                {
                    model.QuantEstoque = model.QuantEstoque - quantidade;
                    ProdutoRepository.Save();
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
