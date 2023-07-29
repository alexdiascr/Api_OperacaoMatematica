using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OperacaoMatematica.Application.Interfaces.Produtos;
using OperacaoMatematica.Application.Notificacoes;
using OperacaoMatematica.Application.ViewModels.Produto;
using OperacaoMatematica.Dominio.ProdutoRoot;
using SomaNumeros.Dominio.Core.Utils;

namespace SomaNumeros.API.V1.Controllers.Numeros
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/operacoesmatematicas")]
    [ApiController]
    public class NumeroController : BaseController
    {
        private readonly INumeroService _appService;
        private readonly IMapper _mapper;

        public NumeroController(INotificador notificador,
                                 IMapper mapper,
                                 INumeroService appService)
                                 : base(notificador)
        {
            _appService = appService;
        }

        /// <summary>
        /// Post para a operação de dois números
        /// </summary>
        /// <param name="viewmodel">Dto para o post</param>
        /// <returns></returns>
        /// /// <remarks>
        /// Exemplo de requisição
        ///
        ///     POST /api/v1/operacoesmatematicas
        ///     {
        ///       "dateTime": "2023-07-29T00:34:28.473Z",
        ///       "nome": "string",
        ///       "primeiroValor": 0,
        ///       "segundoValor": 0,
        ///       "operadorMatematico": "string",
        ///       "resultado": 0
        ///     }
        ///     Obs: para o campo operadorMatematico só será aceito operação do tipo "+", "-" "/"
        ///     Ou seja, somente operação do tipo soma, subtração e divisão. 
        ///     Nesse campo só será aceito um caracter, + ou - ou /
        /// </remarks>
        /// <response code="200">Operação realizada com sucesso.</response>
        /// <response code="400">Operação não realizada com sucesso.</response>
        [HttpPost]
        [ProducesResponseType(typeof(SucessRetorno<NumeroViewModel>), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 400)]
        public async Task<IActionResult> AcaoMetodoPost(NumeroViewModel viewmodel)
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

        [HttpGet]
        [ProducesResponseType(typeof(SucessRetorno<NumeroViewModel>), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 400)]
        public async Task<IActionResult> AcaoMetodoGet()
        {
            Random random = new Random();
            int numeroAleatorio = random.Next(1, 100); 

            return CustomResponse(numeroAleatorio);
        }
    }
}
