namespace Triskai.Core
{
    public interface IEventListener<T> where T : IEvent
    {
        void OnEvent(T evt);
    }
}