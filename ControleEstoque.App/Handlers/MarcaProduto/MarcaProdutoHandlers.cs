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
        private readonly IMarcaProdutoRepository marcaRepository;       
        public MarcaProdutoHandlers(IMarcaProdutoRepository _marcaRepository)
        {
            marcaRepository = _marcaRepository;            
        }

        //excluir
        public void ExcluirPeloId(int id)
        {
            try
            {
                marcaRepository.Delete(id);
                marcaRepository.Save();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //buscar lista
        public List<MarcaProdutoView> RecuperarLista()
        {
            return marcaRepository.Get().Select(model => new MarcaProdutoView(model)).ToList();
        }

        //buscar por id
        public MarcaProdutoView RecuperarPeloId(int id)
        {
            var model = marcaRepository.GetByID(id);
            return model is not null ? new MarcaProdutoView(model) : null;
        }

        //buscar quantidade
        public int RecuperarQuantidade()
        {
            return marcaRepository.Get().Count();
        }

        //salvar
        public MarcaProdutoView Salvar(MarcaProdutoCommand command)
        {
            try
            {
               var model =  marcaRepository.Insert(command.retornoMarcaProduto());
               marcaRepository.Save();
               return new MarcaProdutoView(model);

            }catch(Exception e)
            {
                throw;
            }
            
        }

        //alterar
        public MarcaProdutoView Alterar(int id, MarcaProdutoCommand command)
        {
            var model = RecuperarPeloId(id);

            if (model is not null)
            {
                model.Ativo = command.Ativo;
                model.Nome = command.Nome;
                marcaRepository.Save();
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
