using ControleEstoque.App.Dtos;
using ControleEstoque.App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Fornecedor
{
    public  interface IFornecedorHandlers
    {
        public int RecuperarQuantidade();

        public IEnumerable<FornecedorView> RecuperarLista();

        public FornecedorView RecuperarPeloId(int id);

        public FornecedorCommand Salvar(FornecedorCommand fornecedorDTO);

        public void ExcluirPeloId(int id);
        public FornecedorCommand Alterarfornecedor(FornecedorCommand fornecedor);

    }
}
