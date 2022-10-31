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

        public string Salvar(FornecedorDTO cidadeDTO);

        public string ExcluirPeloId(int id);
        public FornecedorCompletoDTO RecuperarPeloIdCompleto(int id);
        public List<FornecedorCompletoDTO> ListarCompleto(int id);
        public string SalvarCompleto(FornecedorCompletoDTO fornecedorDTO);
    }
}
