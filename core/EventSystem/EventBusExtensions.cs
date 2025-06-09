namespace Triskai.Core
{
    public static class EventBusExtensions
    {
        /// <summary>
        /// Raise an event directly from the EventBus itself.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bus"></param>
        public static void Publish<T>(this IEventBus bus) where T : IEvent, new()
        {
            bus.Raise(new T());
        }
    }
}