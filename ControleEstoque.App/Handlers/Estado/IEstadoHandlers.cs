using ControleEstoque.App.Dtos;
using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Estado
{
    public interface IEstadoHandlers
    {
        public int RecuperarQuantidade();
        public  List<EstadoDTO> RecuperarLista();
        public EstadoDTO RecuperarPeloId(int id);
        public string ExcluirPeloId(int i);
        public string Salvar(EstadoDTO estadoDTO);
        public List<EstadoDTO> GetTodos(int Id);
    }
}
