using System.Runtime.Serialization.Formatters.Binary;
using Triskai.Core;


namespace Triskai.Serialization
{
    public class BinarySerializer : ISerializer
    {
        public string Serialize<T>(T obj)
        {
            if (obj is ISerializable serializable)
            {
                serializable.OnBeforeSerialize();
            }

            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
        public T Deserialize<T>(string data)
        {
            var bytes = Convert.FromBase64String(data);

            using (var ms = new MemoryStream(bytes))
            {
                var formatter = new BinaryFormatter();
                var obj = (T)formatter.Deserialize(ms);

                if (obj is ISerializable serializable)
                {
                    serializable.OnAfterDeserialize();
                }

                return obj;
            }
        }

    }
}

