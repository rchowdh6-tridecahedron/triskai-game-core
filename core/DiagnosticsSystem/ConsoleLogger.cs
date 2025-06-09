using System;

namespace Triskai.Core
{
    public class ConsoleLogger : ILogger
    {
        private readonly LogLevel minimumLevel;

        public ConsoleLogger(LogLevel minLevel = LogLevel.Debug)
        {
            minimumLevel = minLevel;
        }

        public void Log(string message, LogLevel level = LogLevel.Log)
        {
            if (level >= minimumLevel)
            {
                Console.WriteLine($"[{level}] {message}");
            }
        }

        public void LogDebug(string message) => Log(message, LogLevel.Debug);
        public void LogError(string message) => Log(message, LogLevel.Error);

        public void LogWarning(string message) => Log(message, LogLevel.Warning);
    }
}