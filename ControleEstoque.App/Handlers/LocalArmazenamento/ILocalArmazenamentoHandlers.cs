using ControleEstoque.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.LocalArmazenamento
{
    public interface ILocalArmazenamentoHandlers
    {
        public int RecuperarQuantidade();

        public List<LocalArmazenamentoDTO> RecuperarLista();

        public LocalArmazenamentoDTO RecuperarPeloId(int id);

        public LocalArmazenamentoDTO Salvar(LocalArmazenamentoDTO localDTO);
        public LocalArmazenamentoDTO Alterar(LocalArmazenamentoDTO localDTO);

        public string ExcluirPeloId(int id);
    }
}
