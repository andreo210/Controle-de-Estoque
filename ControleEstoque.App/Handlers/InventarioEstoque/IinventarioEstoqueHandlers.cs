using ControleEstoque.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.InventarioEstoque
{
    public interface IinventarioEstoqueHandlers
    {
        public int RecuperarQuantidade();

        public List<InventarioEstoqueDTO> RecuperarLista();

        public InventarioEstoqueDTO RecuperarPeloId(int id);

        public string Salvar(InventarioEstoqueDTO inventarioDTO);

        public string ExcluirPeloId(int id);
    }
}
