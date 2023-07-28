using SomaNumeros.Application.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SomaNumeros.Services.Services.Base
{
    public abstract class BaseApp
    {
        protected readonly INotificador _notificador;
        protected Guid EmpresaId { get; set; }

        protected BaseApp(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected object CustomResponse(object? result = null)
        {
            if (OperacaoValida())
            {
                return JsonSerializer.Serialize(new
                {
                    success = true,
                    data = result
                });
            }

            return JsonSerializer.Serialize(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
