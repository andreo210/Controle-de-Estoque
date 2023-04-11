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
        public string ExcluirPeloId(int id)
        {
            saidaRepository.Delete(id);
            saidaRepository.Save();
            return "ok";
        }

        public List<SaidaProdutoDTO> RecuperarLista()
        {
            return saidaRepository.Get().Select(x => new SaidaProdutoDTO(x)).ToList();
        }

        public SaidaProdutoDTO RecuperarPeloId(int id)
        {
            var retorno = saidaRepository.GetByID(id);
            return retorno != null ? new SaidaProdutoDTO(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            return saidaRepository.Get().Count();
        }

        public string Salvar(SaidaProdutoDTO cidadeDTO)
        {
            var model = context.Set<SaidaProdutoEntity>().AsNoTracking().Where(e => e.Id == cidadeDTO.Id).FirstOrDefault();

            if (model == null)
            {
                saidaRepository.Insert(cidadeDTO.retornoSaidaProduto());
                saidaRepository.Save();
                return "Ok";
            }
            else
            {
                saidaRepository.Update(cidadeDTO.retornoSaidaProduto());
                saidaRepository.Save();
                return "No Content";
            }
        }
    }
}
