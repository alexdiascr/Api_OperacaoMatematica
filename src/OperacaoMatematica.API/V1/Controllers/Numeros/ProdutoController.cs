using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OperacaoMatematica.Application.Interfaces.Produtos;
using OperacaoMatematica.Application.Notificacoes;
using OperacaoMatematica.Application.ViewModels.Produto;
using OperacaoMatematica.Dominio.ProdutoRoot;

namespace SomaNumeros.API.V1.Controllers.Numeros
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/produto")]
    [ApiController]
    public class ProdutoController : BaseController
    {
        private readonly INumeroService _appService;
        private readonly IMapper _mapper;
        public ProdutoController(INotificador notificador,
                                 IMapper mapper,
                                 INumeroService appService)
                                 : base(notificador)
        {
            _appService = appService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(NumeroViewModel viewmodel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var numero = _mapper.Map<Numero>(viewmodel);

            Numero? model = await _appService.RealizarOperacaoMatematica(numero);

            if (model != null)
            {
                var view = _mapper.Map<NumeroViewModel>(model);
                return CustomResponse(view);
            }

            return CustomResponse();
        }

        public async Task<IActionResult> Get()
        {
            Random random = new Random();
            int numeroAleatorio = random.Next(1, 100); 

            return CustomResponse(numeroAleatorio);
        }
    }
}
