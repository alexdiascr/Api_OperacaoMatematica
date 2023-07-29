using Moq.AutoMock;
using OperacaoMatematica.Application.Services.Numeros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacaoMAtematica.Services.API.Tests
{
    [CollectionDefinition(nameof(NumeroTextFixtureCollection))]
    public class NumeroTextFixtureCollection : ICollectionFixture<NumeroTextFixture>
    { }

    public class NumeroTextFixture
    {
        public NumeroService numeroService;
        public AutoMocker Mocker;

        public NumeroService ObterNumeroService()
        {
            Mocker = new AutoMocker();

            numeroService = Mocker.CreateInstance<NumeroService>();
            return numeroService;
        }
    }
}
