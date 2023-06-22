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
        public void ExcluirPeloId(int id)
        {
            marcaRepository.Delete(id);
            marcaRepository.Save();            
        }

        public List<MarcaProdutoView> RecuperarLista()
        {
            return marcaRepository.Get().Select(x => new MarcaProdutoView(x)).ToList();
        }

        public MarcaProdutoView RecuperarPeloId(int id)
        {
            var retorno = marcaRepository.GetByID(id);
            return retorno != null ? new MarcaProdutoView(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            return marcaRepository.Get().Count();
        }

        public MarcaProdutoView Salvar(MarcaProdutoCommand marca)
        {
            try
            {
               var model =  marcaRepository.Insert(marca.retornoMarcaProduto());
               marcaRepository.Save();
               return new MarcaProdutoView(model);

            }catch(Exception e)
            {
                throw;
            }
            
        }

        public MarcaProdutoView Alterar(int id, MarcaProdutoCommand marca)
        {

            var model = context.MarcaProduto.FirstOrDefault(x => x.Id == id);

            if (model != null)
            {
                model.Ativo = marca.Ativo;
                model.Nome = marca.Nome;
                context.SaveChanges();
                return new MarcaProdutoView(model);
            }
            else
            {
                return null;
            }
        }
    }
}
