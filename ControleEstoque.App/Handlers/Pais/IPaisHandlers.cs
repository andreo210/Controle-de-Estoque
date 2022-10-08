using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Pais
{
    public interface IPaisHandlers
    {
        public int RecuperarQuantidade();
        public List<PaisEntity> RecuperarLista();
        public PaisEntity RecuperarPeloId(int id);
        public bool ExcluirPeloId(int id);
        public int Salvar();
    }
}
