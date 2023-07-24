using ControleEstoque.App.Dtos;
using ControleEstoque.App.Models.Views;
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

        public IEnumerable<LocalArmazenamentoView> RecuperarLista();

        public LocalArmazenamentoView RecuperarPeloId(int id);

        public LocalArmazenamentoView Salvar(LocalArmazenamentoCommand command);
        public LocalArmazenamentoView Alterar(int id, LocalArmazenamentoCommand command);

        public void ExcluirPeloId(int id);
    }
}
