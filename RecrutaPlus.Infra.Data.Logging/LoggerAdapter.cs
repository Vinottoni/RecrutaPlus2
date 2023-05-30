using Microsoft.Extensions.Configuration;
using RecrutaPlus.Domain.Interfaces;
using Serilog;
using System;

namespace RecrutaPlus.Infra.Data.Logging
{

    public class LoggerAdapter : IAppLogger, IDisposable
    {
        //private readonly ILogger<T> _logger;
        private readonly Serilog.ILogger _logger;

        private readonly bool _loggerIsPersisted = false;
        public LoggerAdapter()
        {
            var configuration = new ConfigurationBuilder()

            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            string logger = configuration.GetSection(AppLogSettingsConfigurationConst.AppSettings)
              .GetValue<string>(AppLogSettingsConfigurationConst.Logger);

            if (logger != null && logger.ToLower().Equals(AppLogSettingsConfigurationConst.LoggerTrue.ToLower()))
            {
                _loggerIsPersisted = true;

                _logger = new LoggerConfiguration()
                 .ReadFrom.Configuration(configuration)
                 .CreateLogger();
            }
        }

        public void Dispose()
        {
            Log.CloseAndFlush();
            Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual void LogDebug(string message, params object[] args)
        {
            if (_loggerIsPersisted)
            {
                _logger.Debug(message, args);
            }
        }

        public virtual void LogError(string message, params object[] args)
        {
            if (_loggerIsPersisted)
            {
                _logger.Error(message, args);

            }
        }

        public void LogError(Exception exception, string message, params object[] args)
        {
            if (_loggerIsPersisted)
            {
                _logger.Error(exception, message, args);
            }
        }

        public virtual void LogFatal(string message, params object[] args)
        {
            if (_loggerIsPersisted)
            {
                _logger.Fatal(message, args);
            }
        }

        public void LogFatal(Exception exception, string message, params object[] args)
        {
            if (_loggerIsPersisted)
            {
                _logger.Fatal(exception, message, args);
            }
        }

        public virtual void LogInformation(string message, params object[] args)
        {
            if (_loggerIsPersisted)
            {
                _logger.Information(message, args);
            }
        }

        public void LogVersobe(string message, params object[] args)
        {
            if (_loggerIsPersisted)
            {
                _logger.Verbose(message, args);
            }
        }

        public virtual void LogWarning(string message, params object[] args)
        {
            if (_loggerIsPersisted)
            {
                _logger.Warning(message, args);
            }
        }
    }
}
