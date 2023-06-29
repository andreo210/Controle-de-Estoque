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

namespace ControleEstoque.App.Handlers.Produto
{
    class ProdutoHandlers : IProdutoHandlers
    {
        IProdutoRepository produtoRepository;

        public ProdutoHandlers(IProdutoRepository _produtoRepository)
        {
            produtoRepository = _produtoRepository;          
        }
        public void ExcluirPeloId(int id)
        {
          
            try
            {
                produtoRepository.Delete(id);
                produtoRepository.Save();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<ProdutoView> RecuperarLista()
        {
            
            try
            {
                var listaModel = produtoRepository.Get().Select(model => new ProdutoView(model)).ToList();
                return listaModel;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ProdutoView RecuperarPeloId(int id)
        {
            try
            {
                var model = produtoRepository.GetByID(id);
                return model is not null ? model : null; ;
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
                return produtoRepository.Get().Count();
            }
            catch (Exception e)
            {
                throw;
            }
        }



        public ProdutoView Salvar(ProdutoCommand command)
        {

            try
            {
                var model = produtoRepository.Insert(command);
                produtoRepository.Save();
                return model;
            }
            catch (Exception e)
            {
                throw;
            }

        }


        public ProdutoView Alterar(int id, ProdutoCommand command)
        {
            try
            {
                var model = produtoRepository.GetByID(id);

                if (model is not null)
                {
                    model.Nome = command.Nome;
                    model.Ativo = command.Ativo;
                    model.Codigo = command.Codigo;
                    model.IdFornecedor = command.IdFornecedor;
                    model.IdGrupo = command.IdGrupo;
                    model.IdLocalArmazenamento = command.IdLocalArmazenamento;
                    model.IdMarca = command.IdMarca;
                    model.IdUnidadeMedida = command.IdUnidadeMedida;
                    model.Imagem = command.Imagem;
                    model.PrecoCusto = command.PrecoCusto;
                    model.PrecoVenda = command.PrecoVenda;
                    model.QuantEstoque = command.QuantEstoque;
                    produtoRepository.Save();
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
    

