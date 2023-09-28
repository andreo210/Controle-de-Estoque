using System.Collections.Generic;

namespace ControleEstoque.App.Notificacoes.Interface
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}