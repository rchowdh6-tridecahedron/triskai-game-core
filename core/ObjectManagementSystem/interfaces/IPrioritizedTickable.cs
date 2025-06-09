namespace Triskai.Core
{
    /// <summary>
    /// A tickable object that also has priority
    /// </summary>
    public interface IPrioritizedTickableObject : ITickableObject, IPrioritized { }
}