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

        public FornecedorDTO Salvar(FornecedorDTO fornecedorDTO);

        public string ExcluirPeloId(int id);
        public string Alterar(FornecedorDTO fornecedor);

    }
}
