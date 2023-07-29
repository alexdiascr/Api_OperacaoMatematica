using AutoMapper;
using OperacaoMatematica.Application.ViewModels.Produto;
using OperacaoMatematica.Dominio.ProdutoRoot;

namespace OperacaoMatematica.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Numero, NumeroViewModel>().ReverseMap();
            CreateMap<Numero, ViewModel>().ReverseMap();
        }
    }
}
