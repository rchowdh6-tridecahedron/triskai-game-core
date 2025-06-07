namespace Triskai.Core
{
    public interface IEventBus
    {
        void Raise<T>(T evt) where T : IEvent;
        void Subscribe<T>(IEventListener<T> listener) where T : IEvent;
        void Unsubscribe<T>(IEventListener<T> listener) where T : IEvent;
    }
}