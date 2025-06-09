namespace Triskai.Core
{
    /// <summary>
    /// Marker interface for objects that want to participate in 
    /// Core serialization lifecycle
    /// </summary>
    public interface ISerializable
    {
        void OnBeforeSerialize();
        void OnAfterDeserialize();
    }
}