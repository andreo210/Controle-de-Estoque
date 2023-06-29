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

        IGrupoProdutoRepository grupoRepository;

        public GrupoProdutoHandlers(IGrupoProdutoRepository _grupoRepository)
        {
            grupoRepository = _grupoRepository;
            

        }
        public void ExcluirPeloId(int id)
        {            
            try
            {               
              grupoRepository.Delete(id);
              grupoRepository.Save();  

            }catch(Exception e)
            {
                throw;
            }

        }

        public List<GrupoProdutoView> RecuperarLista()
        {
            try
            {
                var listaModels = grupoRepository.Get().Select(model => new GrupoProdutoView(model)).ToList();
                return listaModels;
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public GrupoProdutoView RecuperarPeloId(int id)
        {
            try
            {
                var model = grupoRepository.GetByID(id);
                if (model is not null)
                {
                    return new GrupoProdutoView(model);
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


        public int RecuperarQuantidade()
        {
            try
            {
                return grupoRepository.Get().Count();
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public GrupoProdutoView Salvar(GrupoProdutoCommand command)
        {
            try
            {
                var model =  grupoRepository.Insert(command.retornoGrupoProdutoEntity());
                grupoRepository.Save();
                return new GrupoProdutoView(model);
            }
            catch(Exception e)
            {
                throw;
            }         
        }


        public GrupoProdutoView Alterar (int id, GrupoProdutoCommand command)
        {
            try
            {

                var model = RecuperarPeloId(id);

                if (model != null)
                {
                    model.Ativo = command.Ativo;
                    model.Nome = command.Nome;
                    grupoRepository.Save();
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
