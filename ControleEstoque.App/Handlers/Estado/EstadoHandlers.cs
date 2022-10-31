using ControleEstoque.App.Dtos;
using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Repository;
using ControleEstoque.Infra.Data;
using ControleEstoque.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Estado
{
    class EstadoHandlers : IEstadoHandlers
    {
        private readonly ControleEstoqueContext context;

        IEstadoRepository estadoRepesository;

        public EstadoHandlers(IEstadoRepository _estadoRpesository, ControleEstoqueContext _context)
        {
            estadoRepesository = _estadoRpesository;
            context = _context;
        }

        public string ExcluirPeloId(int i)
        {
            estadoRepesository.Delete(i);
            estadoRepesository.Save();
            return "Ok";
        }

        public List<EstadoDTO> RecuperarLista()
        {
            return estadoRepesository.Get().Select(x => new EstadoDTO(x)).ToList();
        }

        public EstadoDTO RecuperarPeloId(int id)
        {
            var retorno = estadoRepesository.GetByID(id);
            return retorno != null ? new EstadoDTO(retorno) : null;
        }

        //public int RecuperarQuantidade()
        //{
        //    return estadoRepesository.Get().Count();
        //}

        public string Salvar(EstadoDTO estadoDTO)
        {
            var model = RecuperarPeloId(estadoDTO.Id);

            if (model == null)
            {
                estadoRepesository.Insert(estadoDTO.retornoEstadoEntity());
                estadoRepesository.Save();
                return "Ok";
            }
            else
            {
                estadoRepesository.Update(estadoDTO.retornoEstadoEntity());
                estadoRepesository.Save();
                return "No Content";
            }
        }

       public List <EstadoDTO> GetTodos(int Id)
        {
            PaisEntity paisEntity = new PaisEntity();
            return estadoRepesository.Get(x => x.Id == paisEntity.Id).Select(x => new EstadoDTO(x)).ToList();

        }

        //usando context       
        public int RecuperarQuantidade()
        {
            var ret = 0;
            ret = context.Estado.Count();
            return ret;
        }
    }
}

