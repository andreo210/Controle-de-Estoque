using ControleEstoque.App.Dtos;
using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Estado
{
    class EstadoHandlers : IEstadoHandlers
    {
        IEstadoRepository estadoRepesository;

        public EstadoHandlers(IEstadoRepository _estadoRpesository)
        {
            estadoRepesository = _estadoRpesository;
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

        public int RecuperarQuantidade()
        {
            return estadoRepesository.Get().Count();
        }

        public string Salvar(EstadoDTO estadoDTO)
        {
            estadoRepesository.Insert(estadoDTO.retornoEstadoEntity());
            estadoRepesository.Save();
            return "Ok";
        }

       
    }
}
