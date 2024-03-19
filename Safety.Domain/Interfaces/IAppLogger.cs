using System;

namespace Safety.Domain.Interfaces
{
    public interface IAppLogger
    {
        void LogVersobe(string message, params object[] args);
        void LogInformation(string message, params object[] args);
        void LogDebug(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogError(string message, params object[] args);
        void LogError(Exception exception, string message, params object[] args);
        void LogFatal(string message, params object[] args);
        void LogFatal(Exception exception, string message, params object[] args);
    }
}
