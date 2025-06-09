using System.Collections.Generic;

namespace Triskai.Core
{
    /// <summary>
    /// Generic Manager for ordered updates
    /// This will sort objects before applying
    /// updates and is good for prioritizing certain
    /// objects over others.
    /// </summary>
    /// <typeparam name="T">Type of prioritized tickable object managed</typeparam>
    public interface IObjectManagerWithPriority<T> : IObjectManager<T> where T : IPrioritizedTickableObject
    {
        /// <summary>
        /// Sort using .Priority.CompareTo
        /// </summary>
        void SortObjects();

        /// <summary>
        /// Use some sort of custom comparison
        /// </summary>
        /// <param name="comparer">Comparer to define custom sort order</param>
        void SortObjects(IComparer<T> comparer);
    }
}