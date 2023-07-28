using SomaNumeros.Application.ViewModels.Produto;
using SomaNumeros.Dominio.ProdutoRoot;
using SomaNumeros.Dominio.ProdutoRoot.Validation;
using SomaNumeros.Services.Services.Base.Interfaces;

namespace SomaNumeros.Services.Interfaces
{
    public interface IProdutosApp : IBaseCadastroApp
        <Numero,
        ProdutoViewModel,
        ProdutoAdicionarViewModel,
        ProdutoAtualizarViewModel,
        ProdutoValidation>
    {
        Task<bool> AdicionarProduto(Numero model);
    }
}
