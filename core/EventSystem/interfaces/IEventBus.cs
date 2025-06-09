namespace Triskai.Core
{
    /// <summary>
    /// The foundation behind creating event buses
    /// within the system.
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        /// Raise an event of Type T
        /// </summary>
        /// <typeparam name="T">The type of IEvent</typeparam>
        /// <param name="evt">The event arguments itself</param>
        void Raise<T>(T evt) where T : IEvent;
        void Subscribe<T>(IEventListener<T> listener) where T : IEvent;
        void Unsubscribe<T>(IEventListener<T> listener) where T : IEvent;
    }
}