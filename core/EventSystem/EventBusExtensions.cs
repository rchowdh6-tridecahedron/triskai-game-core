namespace Triskai.Core
{
    public static class EventBusExtensions
    {
        public static void Publish<T>(this IEventBus bus) where T : IEvent, new()
        {
            bus.Raise(new T());
        }
    }
}