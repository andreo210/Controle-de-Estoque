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
        public  List<EstadoEntity> RecuperarLista();
        public EstadoEntity RecuperarPeloId(int id);
        public bool ExcluirPeloId(int i);
        public int Salvar();
    }
}
