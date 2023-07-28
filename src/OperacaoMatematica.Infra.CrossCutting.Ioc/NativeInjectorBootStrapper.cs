using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OperacaoMatematica.Application.Interfaces.Produtos;
using OperacaoMatematica.Application.Notificacoes;
using OperacaoMatematica.Application.Services.Numeros;

namespace FastPagamentos.Infra.CrossCutting.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {

            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotificador, Notificador>();

            #region Services

            services.AddScoped<INumeroService, NumeroService>();

            #endregion

            #region Repository

            #endregion

            services.AddScoped<HttpClient>();
        }
    }
}
