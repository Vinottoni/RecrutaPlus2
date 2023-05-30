using Microsoft.Extensions.DependencyInjection;
using RecrutaPlus.Domain.Interfaces;
using RecrutaPlus.Domain.Interfaces.Repositories;
using RecrutaPlus.Domain.Interfaces.Services;
using RecrutaPlus.Domain.Services;
using RecrutaPlus.Infra.Data.Logging;
using RecrutaPlus.Infra.Data.Repositories;

namespace RecrutaPlus.Infra.Data.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Repository
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<ICargoRepository, CargoRepository>();
            services.AddTransient<IAppLoggerRepository, AppLoggerRepository>();

            //Service
            services.AddTransient<IFuncionarioService, FuncionarioService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<ICargoService, CargoService>();
            services.AddTransient<IAppLoggerService, AppLoggerService>();

            //Logger
            services.AddSingleton<IAppLogger, LoggerAdapter>();
        }

    }
}