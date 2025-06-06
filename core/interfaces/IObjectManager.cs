namespace Triskai.Core
{
    /// <summary>
    /// Generic Manager for unordered ticks
    /// </summary>
    /// <typeparam name="T">Type of tickable object managed</typeparam>
    public interface IObjectManager<T> : ITickable where T : ITickable
    {
        void Register(T obj);
        void Deregister(T obj);

        bool GetObject(string id, out T target);
    }
}