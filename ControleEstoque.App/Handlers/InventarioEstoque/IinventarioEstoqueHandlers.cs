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

        public List<InventarioEstoqueView> RecuperarLista();

        public InventarioEstoqueView RecuperarPeloId(int id);

        public InventarioEstoqueView Salvar(InventarioEstoqueCommand inventarioDTO);

        public void ExcluirPeloId(int id);
        public InventarioEstoqueView Alterar(int id, InventarioEstoqueCommand inventario);
    }
}
