namespace Triskai.Core
{
    /// <summary>
    /// General serializer interface - no constraints to allow serializing anything
    /// </summary>
    public interface ISerializer
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string data);
    }
}