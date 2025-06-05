namespace Triskai.Core
{
    /// <summary>
    /// Priority for sorting tickable objects
    /// </summary>
    public interface IPrioritized
    {
        int Priority { get; }
    }
}