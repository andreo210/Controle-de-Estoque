using ControleEstoque.App.Dtos;
using ControleEstoque.App.Views;
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
        public GrupoProdutoView ExcluirPeloId(int id)
        {            
            try
            {
                var grupo = RecuperarPeloId(id);
                if(grupo == null)
                {
                    return null;
                }else
                {
                    grupoRepository.Delete(id);
                    grupoRepository.Save();
                    return grupo;
                }                

            }catch(Exception e)
            {
                throw;
            }

        }

        public List<GrupoProdutoView> RecuperarLista()
        {
            return grupoRepository.Get().Select(x => new GrupoProdutoView(x)).ToList();
        }


        public GrupoProdutoView RecuperarPeloId(int id)
        {
            var retorno = grupoRepository.GetByID(id);
            if (retorno != null)
            {
                return new GrupoProdutoView(retorno);
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


        public GrupoProdutoView Salvar(GrupoProdutoCommand grupoDTO)
        {
            try
            {
                var grupoEntity =  grupoRepository.Insert(grupoDTO.retornoGrupoProdutoEntity());
                grupoRepository.Save();
                return new GrupoProdutoView(grupoEntity);
            }
            catch(Exception e)
            {
                throw;
            }         
        }


        public GrupoProdutoView Alterar (int id, GrupoProdutoCommand grupo)
        {

            var model = context.GrupoProduto.FirstOrDefault(x=>x.Id == id);

            if (model != null)
            {             
                model.Ativo = grupo.Ativo;
                model.Nome = grupo.Nome;
                context.GrupoProduto.Update(model);
                context.SaveChanges();
                return  new GrupoProdutoView(model);
            }
            else
            {
                return null;
            }
        }
    }
}
