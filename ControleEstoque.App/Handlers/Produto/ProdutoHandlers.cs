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
        private readonly ControleEstoqueContext context;

        IProdutoRepository produtoRepository;

        public ProdutoHandlers(IProdutoRepository _produtoRepository, ControleEstoqueContext _context)
        {
            produtoRepository = _produtoRepository;
            context = _context;

        }
        public string ExcluirPeloId(int id)
        {
            produtoRepository.Delete(id);
            produtoRepository.Save();
            return "Ok";
        }

        public List<ProdutoCommand> RecuperarLista()
        {
            return produtoRepository.Get().Select(x => new ProdutoCommand(x)).ToList(); ;
        }

        public ProdutoCommand RecuperarPeloId(int id)
        {
            var retorno = produtoRepository.GetByID(id);
            return retorno != null ? new ProdutoCommand(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            return produtoRepository.Get().Count();
        }

        public string Salvar(ProdutoView cidadeDTO)
        {
            var model = context.Set<ProdutoEntity>().AsNoTracking().Where(e => e.Id == cidadeDTO.Id).FirstOrDefault();

            if (model == null)
            {
                produtoRepository.Insert(cidadeDTO.retornoProduto());
                produtoRepository.Save();
                return "Ok";
            }
            else
            {
                produtoRepository.Update(cidadeDTO.retornoProduto());
                produtoRepository.Save();
                return "No Content";
            }
        }
    }
}
