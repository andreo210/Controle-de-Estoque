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

        public FornecedorView Salvar(FornecedorCommand fornecedorDTO);

        public void ExcluirPeloId(int id);
        public FornecedorView Alterarfornecedor(int id, FornecedorCommand fornecedor);
        public string GetTipoPessoa(int id);
        public string GetTipoContato(int id);



    }
}
