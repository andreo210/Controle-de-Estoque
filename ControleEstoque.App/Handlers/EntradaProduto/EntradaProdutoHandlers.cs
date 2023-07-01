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
        private readonly IProdutoRepository ProdutoRepository;

        public EntradaProdutoHandlers(IEntradaProdutoRepository _EntradaRepository, IProdutoRepository _ProdutoRepository)
        {
            EntradaRepository = _EntradaRepository;
            ProdutoRepository = _ProdutoRepository;
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
            try
            {
                var listaModels = EntradaRepository.Get().Select(model => new EntradaProdutoView(model)).ToList();
                return listaModels;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public EntradaProdutoView RecuperarPeloId(int id)
        {
            var model = EntradaRepository.GetByID(id);
            return model is not null ? new EntradaProdutoView(model) : null;
        }

        public int RecuperarQuantidade()
        {
            return EntradaRepository.Get().Count();
        }

        public EntradaProdutoView Salvar(EntradaProdutoCommand command)
        {

            try
            {
                var produto = SomarProduto(command.IdProduto, command.Quantidade);
                if (produto is not null)
                {
                    var model = EntradaRepository.Insert(command);
                    EntradaRepository.Save();

                    return new EntradaProdutoView(model);
                }else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }


        public EntradaProdutoView Alterar(int id, EntradaProdutoCommand command)
        {

            var model = RecuperarPeloId(id);
            if (model is not null)
            {
                model.IdProduto = command.IdProduto;
                model.Numero = command.Numero;
                model.Data = DateTime.Now;
                model.Quantidade = command.Quantidade;
                EntradaRepository.Save();
                return model;
            }
            else
            {
                return null;
            }
        }

        private ProdutoView SomarProduto(int id, int quantidade)
        {
            try
            {
                var model = ProdutoRepository.GetByID(id);

                if (model is not null)
                {
                    model.QuantEstoque = model.QuantEstoque + quantidade;
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
