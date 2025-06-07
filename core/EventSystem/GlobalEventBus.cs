namespace Triskai.Core
{
    public static class GlobalEventBus
    {
        public static IEventBus Instance { get; } = new EventBus();
    }
}