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
            services.AddTransient<IAppLoggerRepository, AppLoggerRepository>();
            services.AddTransient<ICargoRepository, CargoRepository>();
            services.AddTransient<IFeriasRepository, FeriasRepository>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();

            //Service
            services.AddTransient<IAppLoggerService, AppLoggerService>();
            services.AddTransient<ICargoService, CargoService>();
            services.AddTransient<IFeriasService, FeriasService>();
            services.AddTransient<IFuncionarioService, FuncionarioService>();
            services.AddTransient<ILoginService, LoginService>();

            //Logger
            services.AddSingleton<IAppLogger, LoggerAdapter>();
        }

    }
}