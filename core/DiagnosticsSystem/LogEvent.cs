namespace Triskai.Core
{
    public class LogEvent : IEvent
    {
        public string Message { get; }
        public LogLevel Type { get; }

        public LogEvent(string message, LogLevel type = LogLevel.Log)
        {
            Message = message;
            Type = type;
        }
    }
}