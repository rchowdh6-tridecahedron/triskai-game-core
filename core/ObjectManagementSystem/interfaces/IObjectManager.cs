namespace Triskai.Core
{
    /// <summary>
    /// Generic Manager for unordered tickable objects
    /// All objects registered to this manager will be 
    /// updated by this manager.
    /// </summary>
    /// <typeparam name="T">Type of tickable object managed</typeparam>
    public interface IObjectManager<T> : ITickable where T : ITickable
    {
        /// <summary>
        /// Register the tickable in some way
        /// and add it to a list or dictionary or whatever really.
        /// </summary>
        /// <param name="obj"></param>
        void Register(T obj);

        /// <summary>
        /// Deregister the tickable.
        /// Make sure to remove it from your dictionaries.
        /// </summary>
        /// <param name="obj"></param>
        void Deregister(T obj);
    }
}