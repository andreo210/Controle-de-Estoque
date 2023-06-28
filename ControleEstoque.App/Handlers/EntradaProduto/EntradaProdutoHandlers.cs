using ControleEstoque.App.Dtos;
using ControleEstoque.Domain.Repository;
using ControleEstoque.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.EntradaProduto
{
    class EntradaProdutoHandlers : IEntradaProdutoHandlers
    {
        private readonly IEntradaProdutoRepository EntradaRepository;
        private readonly ControleEstoqueContext context;

        public EntradaProdutoHandlers(IEntradaProdutoRepository _EntradaRepository, ControleEstoqueContext _context)
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

        public List<EntradaProdutoView> RecuperarLista()
        {
            return EntradaRepository.Get().Select(x => new EntradaProdutoView(x)).ToList();
        }

        public EntradaProdutoView RecuperarPeloId(int id)
        {
            var retorno = EntradaRepository.GetByID(id);
            return retorno != null ? new EntradaProdutoView(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            return EntradaRepository.Get().Count();
        }

        public EntradaProdutoView Salvar(EntradaProdutoCommand cidade)
        {

            try
            {
                var model = EntradaRepository.Insert(cidade);
                EntradaRepository.Save();
                return new EntradaProdutoView(model);
            }
            catch (Exception e)
            {
                throw;
            }

        }


        public EntradaProdutoView Alterar(int id, EntradaProdutoCommand Entrada)
        {

            var model = context.EntradaProduto.FirstOrDefault(x => x.Id == id);

            if (model != null)
            {
                model.IdProduto = Entrada.IdProduto;
                model.Numero = Entrada.Numero;
                model.Data = DateTime.Now;
                model.Quantidade = Entrada.Quantidade;
                context.SaveChanges();
                return new EntradaProdutoView(model);
            }
            else
            {
                return null;
            }
        }

    }

}
