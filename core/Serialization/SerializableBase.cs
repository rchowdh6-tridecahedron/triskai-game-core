namespace Triskai.Core
{
    public abstract class SerializableBase : ISerializable
    {
        public virtual void OnAfterDeserialize() { }

        public virtual void OnBeforeSerialize() { }
    }
}