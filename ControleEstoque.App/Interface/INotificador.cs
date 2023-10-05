using ControleEstoque.App.Notificacoes;
using System.Collections.Generic;

namespace ControleEstoque.App.Interface
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}