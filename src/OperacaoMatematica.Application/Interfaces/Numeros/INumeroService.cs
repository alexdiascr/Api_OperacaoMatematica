using OperacaoMatematica.Dominio.ProdutoRoot;

namespace OperacaoMatematica.Application.Interfaces.Produtos
{
    public interface INumeroService 
    {
        Task<Numero?> RealizarOperacaoMatematica(Numero model);
    }
}
