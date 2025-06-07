namespace Triskai.Core
{
    public interface ILogger
    {
        void Log(string message, LogLevel level = LogLevel.Info);
        void LogWarning(string message);
        void LogError(string message);
        void LogDebug(string message);
    }
}