namespace Triskai.Core
{
    /// <summary>
    /// Provides an interface for getting the ID
    /// for an object.
    /// </summary>
    public interface IIdentifiable
    {
        /// <summary>
        /// The internal Id for an object. Assign this as you
        /// wish, either with your own method or via Guid.NewGuid().ToString()
        /// </summary>
        string Id { get; set; }
    }
}