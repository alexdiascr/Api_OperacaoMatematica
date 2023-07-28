using OperacaoMatematica.Application.AutoMapper;

namespace OperacaoMatematica.Services.API.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile));
        }
    }
}
