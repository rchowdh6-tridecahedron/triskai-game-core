using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triskai.Core
{
    public class ObjectManager : IObjectManager<ITickableObject>
    {
        private readonly ConcurrentDictionary<string, ITickableObject> objects;

        private readonly object _lock = new object();

        public ObjectManager()
        {
            objects = new ConcurrentDictionary<string, ITickableObject>();
        }

        public void Register(ITickableObject obj)
        {
            var id = Guid.NewGuid().ToString();
            obj.Id = id;
            objects.TryAdd(id, obj);
        }

        public void Deregister(ITickableObject obj)
        {
            objects.TryRemove(obj.Id, out _);
        }

        public bool GetObject(string id, out ITickableObject target)
        {
            return objects.TryGetValue(id, out target);
        }

        public void Tick(float deltaTime)
        {
            List<ITickableObject> snapshot = objects.Values.ToList();

            Parallel.ForEach(snapshot, obj =>
            {
                obj.Tick(deltaTime);
            });
        }
    }
}