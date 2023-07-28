﻿namespace OperacaoMatematica.Application.Notificacoes
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
        void LimparNotificacao();
    }
}
