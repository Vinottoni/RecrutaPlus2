using AutoMapper;
using Safety.Application.AutoMapper;

namespace Safety.Web.Extensions
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
