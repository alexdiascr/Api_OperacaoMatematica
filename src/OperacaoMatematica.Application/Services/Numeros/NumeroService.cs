using AutoMapper;
using OperacaoMatematica.Application.Interfaces.Produtos;
using OperacaoMatematica.Application.Notificacoes;
using OperacaoMatematica.Application.Services.Base;
using OperacaoMatematica.Dominio.ProdutoRoot;

namespace OperacaoMatematica.Application.Services.Numeros
{
    public class NumeroService : BaseService, INumeroService
    {
        public NumeroService(INotificador notificador, 
                              IMapper mapper)    
                            :base(notificador)
        {

        }

        public async Task<Numero?> RealizarOperacaoMatematica(Numero model)
        {
            try
            {
                return OperacaoMatematica(model);
            }
            catch (Exception ex)
            {
                Notificar($"Não foi possível realizar operação matemática. Motivo: {ex.Message}");
                return null;
            }
        }

        private Numero? OperacaoMatematica(Numero model)
        {
            switch (model.OperadorMatematico)
            {
                case "+":
                    model.Resultado = model.PrimeiroValor + model.SegundoValor;
                    return model;
                case "-":
                    model.Resultado = model.PrimeiroValor - model.SegundoValor;
                    return model;
                case "/":
                    model.Resultado = model.SegundoValor != 0 ? model.PrimeiroValor / model.SegundoValor : double.NaN;
                    return model;
                default:
                    throw new ArgumentException("Operador matemático inválido.");
            }
        }
    }
}
