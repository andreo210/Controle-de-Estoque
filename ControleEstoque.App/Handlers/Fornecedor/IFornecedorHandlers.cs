using ControleEstoque.App.Dtos;
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

        public List<FornecedorDTO> RecuperarLista();

        public FornecedorDTO RecuperarPeloId(int id);

        public FornecedorDTO Salvar(FornecedorDTO fornecedorDTO);

        public string ExcluirPeloId(int id);
        public string Alterar(FornecedorDTO fornecedorDTO);

    }
}
