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

namespace ControleEstoque.App.Handlers.GrupoProduto
{
   public   class GrupoProdutoHandlers : IGrupoProdutoHandlers
    {
        private readonly ControleEstoqueContext context;

        IGrupoProdutoRepository grupoRepository;

        public GrupoProdutoHandlers(IGrupoProdutoRepository _grupoRepositoryy, ControleEstoqueContext _context)
        {
            grupoRepository = _grupoRepositoryy;
            context = _context;

        }
        public string ExcluirPeloId(int id)
        {
            grupoRepository.Delete(id);
            grupoRepository.Save();
            return "Ok";

        }


        public List<GrupoProdutoDTO> RecuperarLista()
        {
            return grupoRepository.Get().Select(x => new GrupoProdutoDTO(x)).ToList();
        }

        public GrupoProdutoDTO RecuperarPeloId(int id)
        {
            var retorno = grupoRepository.GetByID(id);
            return retorno != null ? new GrupoProdutoDTO(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            return grupoRepository.Get().Count();
        }


        public string Salvar(GrupoProdutoDTO grupoDTO)
        {

            var model = context.Set<GrupoProdutoEntity>().AsNoTracking().Where(e => e.Id == grupoDTO.Id).FirstOrDefault();

            if (model == null)
            {
                grupoRepository.Insert(grupoDTO.retornoGrupoProdutoEntity());
                grupoRepository.Save();
                return "Ok";
            }else
            {
                grupoRepository.Update(grupoDTO.retornoGrupoProdutoEntity());
                grupoRepository.Save();
                return "No Content";
            }
        }
    }
}
