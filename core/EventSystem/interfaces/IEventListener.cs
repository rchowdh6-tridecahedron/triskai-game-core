namespace Triskai.Core
{
    /// <summary>
    /// Who is listening to certain events
    /// </summary>
    /// <typeparam name="T">Type of event to be listened for</typeparam>
    public interface IEventListener<T> where T : IEvent
    {
        /// <summary>
        /// When an event occurs.
        /// </summary>
        /// <param name="evt"></param>
        void OnEvent(T evt);
    }
}