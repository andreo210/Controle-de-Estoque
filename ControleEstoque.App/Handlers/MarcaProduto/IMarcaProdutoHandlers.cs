using ControleEstoque.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.MarcaProduto
{
    public interface IMarcaProdutoHandlers
    {
        public int RecuperarQuantidade();

        public List<MarcaProdutoDTO> RecuperarLista();

        public MarcaProdutoDTO RecuperarPeloId(int id);

        public string Salvar(MarcaProdutoDTO marcaDTO);

        public string ExcluirPeloId(int id);
    }
}
