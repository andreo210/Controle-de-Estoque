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
        ISaidaProdutoRepository saidaRepository;
        private readonly ControleEstoqueContext context;

        public SaidaProdutoHandlers(ISaidaProdutoRepository _saidaRepository, ControleEstoqueContext _context)
        {
            saidaRepository = _saidaRepository;
            context = _context;
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
            return saidaRepository.Get().Select(x => new SaidaProdutoView(x)).ToList();
        }

        public SaidaProdutoView RecuperarPeloId(int id)
        {
            var retorno = saidaRepository.GetByID(id);
            return retorno != null ? new SaidaProdutoView(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            return saidaRepository.Get().Count();
        }

        public SaidaProdutoView Salvar(SaidaProdutoCommand cidade)
        {

            try
            {
                var model= saidaRepository.Insert(cidade);
                saidaRepository.Save();
                return new SaidaProdutoView(model);
            }
            catch (Exception e)
            {
                throw;
            }

        }


        public SaidaProdutoView Alterar(int id, SaidaProdutoCommand saida)
        {

            var model = context.SaidaProduto.FirstOrDefault(x => x.Id == id);

            if (model != null)
            {
                model.IdProduto = saida.IdProduto;
                model.Numero = saida.Numero;
                model.Data = DateTime.Now;
                model.Quantidade = saida.Quantidade;
                context.SaveChanges();
                return new SaidaProdutoView(model);
            }
            else
            {
                return null;
            }
        }

    }
}
