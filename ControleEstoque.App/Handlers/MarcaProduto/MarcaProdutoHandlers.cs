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

namespace ControleEstoque.App.Handlers.MarcaProduto
{
    public class MarcaProdutoHandlers : IMarcaProdutoHandlers
    {
        IMarcaProdutoRepository marcaRepository;
        private readonly ControleEstoqueContext context;
        public MarcaProdutoHandlers(IMarcaProdutoRepository _marcaRepository, ControleEstoqueContext _context)
        {
            marcaRepository = _marcaRepository;
            context = _context;
        }
        public string ExcluirPeloId(int id)
        {
            marcaRepository.Delete(id);
            marcaRepository.Save();
            return "ok";
        }

        public List<MarcaProdutoDTO> RecuperarLista()
        {
            return marcaRepository.Get().Select(x => new MarcaProdutoDTO(x)).ToList();
        }

        public MarcaProdutoDTO RecuperarPeloId(int id)
        {
            var retorno = marcaRepository.GetByID(id);
            return retorno != null ? new MarcaProdutoDTO(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            return marcaRepository.Get().Count();
        }

        public string Salvar(MarcaProdutoDTO marcaDTO)
        {
            var model = context.Set<MarcaProdutoEntity>().AsNoTracking().Where(e => e.Id == marcaDTO.Id).FirstOrDefault();

            if (model == null)
            {
                marcaRepository.Insert(marcaDTO.retornoMarcaProduto());
                marcaRepository.Save();
                return "Ok";
            }
            else
            {
                marcaRepository.Update(marcaDTO.retornoMarcaProduto());
                marcaRepository.Save();
                return "No Content";
            }
        }
    }
}
