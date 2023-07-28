using AutoMapper;
using SomaNumeros.Application.Interfaces.Produtos;
using SomaNumeros.Application.Notificacoes;
using SomaNumeros.Application.ViewModels.Produto;
using SomaNumeros.Dominio.ProdutoRoot;
using SomaNumeros.Dominio.ProdutoRoot.Repository;
using SomaNumeros.Dominio.ProdutoRoot.Validation;
using SomaNumeros.Services.Interfaces;
using SomaNumeros.Services.Services.Base;

namespace SomaNumeros.Services.Services.Produtos
{
    public class ProdutosApp : BaseCadastroApp
        <Numero,
        ProdutoViewModel,
        ProdutoAdicionarViewModel,
        ProdutoAtualizarViewModel,
        ProdutoValidation>, IProdutosApp
    {
        private readonly IProdutoService _appService;
        private readonly IProdutoRepository _repository;
        public ProdutosApp(INotificador notificador,
                           IMapper mapper,
                           IProdutoService appService,
                           IProdutoRepository repository
                           ) : base(notificador, mapper, appService, repository)
        {
            _appService = appService;
            _repository = repository;
        }

        public async Task<bool> AdicionarProduto(Numero model)
        {
            return await _appService.AdicionarProduto(model);
        }
    }
}
