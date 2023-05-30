using AutoMapper;
using RecrutaPlus.Application.AutoMapper;

namespace RecrutaPlus.Web.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            var mappingConfig = AutoMapperConfiguration.ConfigureMappings();

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
