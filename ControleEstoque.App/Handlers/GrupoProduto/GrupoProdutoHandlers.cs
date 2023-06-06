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
            try
            {
                grupoRepository.Delete(id);
                grupoRepository.Save();
                return "Ok";
            }catch(Exception e)
            {
                throw;
            }

        }

        public List<GrupoProdutoDTO> RecuperarLista()
        {
            return grupoRepository.Get().Select(x => new GrupoProdutoDTO(x)).ToList();
        }

        public GrupoProdutoDTO RecuperarPeloId(int id)
        {
            var retorno = grupoRepository.GetByID(id);
            if (retorno != null)
            {
                return new GrupoProdutoDTO(retorno);
            }
            else
            {
                return null;
            }
        }

        public int RecuperarQuantidade()
        {
            return grupoRepository.Get().Count();
        }


        public GrupoProdutoDTO Salvar(GrupoProdutoDTO grupoDTO)
        {
            try
            {
                var x =  grupoRepository.Insert(grupoDTO.retornoGrupoProdutoEntity());
                grupoRepository.Save();
                return new GrupoProdutoDTO(x);
            }
            catch(Exception e)
            {
                throw;
            }
            
          
            
        }

        public GrupoProdutoDTO Alterar (GrupoProdutoDTO grupoDTO)
        {

            var model = context.GrupoProduto.FirstOrDefault(e => e.Id == grupoDTO.Id);

            if (model != null)
            {             
                model.Ativo = grupoDTO.Ativo;
                model.Nome = grupoDTO.Nome;
                context.SaveChangesAsync();
                return grupoDTO;
            }
            else
            {
                return null;
            }
        }
    }
}
