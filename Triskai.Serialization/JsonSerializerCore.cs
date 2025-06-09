using System.Text.Json;
using Triskai.Core;


namespace Triskai.Serialization
{
    public class JsonSerializerCore : ISerializer
    {
        private readonly JsonSerializerOptions options;

        public JsonSerializerCore()
        {
            options = new JsonSerializerOptions
            {
                WriteIndented = false,
                PropertyNameCaseInsensitive = true,
            };
        }

        public string Serialize<T>(T obj)
        {
            if (obj is ISerializable serializable)
            {
                serializable.OnBeforeSerialize();
            }

            string json = JsonSerializer.Serialize(obj, options);

            return json;
        }
        public T Deserialize<T>(string data)
        {
            T obj = JsonSerializer.Deserialize<T>(data, options);

            if (obj is ISerializable serializable)
            {
                serializable.OnAfterDeserialize();
            }

            return obj;
        }
    }
}

