namespace Triskai.Core
{
    /// <summary>
    /// Gives an object the ability to be prioritized
    /// </summary>
    public interface IPrioritized
    {
        /// <summary>
        /// The value of priority. It is up to the user
        /// to determine if lower means first, or higher number
        /// means first.
        /// </summary>
        int Priority { get; }
    }
}