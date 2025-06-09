namespace Triskai.Core
{
    public class Logger
    {
        private readonly IEventBus _eventBus;

        public void Debug(string message)
        {
            _eventBus.Raise(new LogEvent(message, LogLevel.Debug));
        }
        public void Log(string message)
        {
            _eventBus.Raise(new LogEvent(message, LogLevel.Log));
        }

        public void Warn(string message)
        {
            _eventBus.Raise(new LogEvent(message, LogLevel.Warning));
        }

        public void Error(string message)
        {
            _eventBus.Raise(new LogEvent(message, LogLevel.Error));
        }

        public void Critical(string message)
        {
            _eventBus.Raise(new LogEvent(message, LogLevel.Critical));
        }
    }
}