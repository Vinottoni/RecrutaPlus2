using Microsoft.Extensions.DependencyInjection;
using Safety.Domain.Interfaces;
using Safety.Domain.Interfaces.Repositories;
using Safety.Domain.Interfaces.Services;
using Safety.Domain.Services;
using Safety.Infra.Data.Logging;
using Safety.Infra.Data.Repositories;

namespace Safety.Infra.Data.IoC
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