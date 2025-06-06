using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Triskai.Core
{
    public class PrioritizedObjectManager : IObjectManagerWithPriority<IPrioritizedTickableObject>
    {
        private readonly ConcurrentDictionary<string, IPrioritizedTickableObject> objects;

        private List<IPrioritizedTickableObject> readList;

        private bool _isDirty;
        private readonly object _lock = new object();

        private static readonly IComparer<IPrioritizedTickableObject> DefaultComparer =
            Comparer<IPrioritizedTickableObject>.Create((a, b) => a.Priority.CompareTo(b.Priority));

        public PrioritizedObjectManager()
        {
            objects = new ConcurrentDictionary<string, IPrioritizedTickableObject>();
            readList = new List<IPrioritizedTickableObject>();
        }

        public void Register(IPrioritizedTickableObject obj)
        {
            string id = Guid.NewGuid().ToString();
            obj.Id = id;

            if (objects.TryAdd(id, obj))
            {
                lock (_lock)
                {
                    readList.Add(obj);
                    _isDirty = true;
                }
            }
        }
        public void Deregister(IPrioritizedTickableObject obj)
        {
            lock (_lock)
            {
                if (objects.TryRemove(obj.Id, out _))
                {
                    readList.Remove(obj);
                    _isDirty = true;
                }
            }

        }

        public bool GetObject(string id, out IPrioritizedTickableObject target)
        {
            return objects.TryGetValue(id, out target);
        }

        public void SortObjects()
        {
            SortObjects(DefaultComparer);
        }

        public void SortObjects(IComparer<IPrioritizedTickableObject> comparer)
        {
            lock (_lock)
            {
                readList.Sort(comparer);
                _isDirty = false;    
            }
        }

        public void Tick(float deltaTime)
        {
            List<IPrioritizedTickableObject> snapshot;

            lock (_lock)
            {
                if (_isDirty)
                    SortObjects();

                snapshot = new List<IPrioritizedTickableObject>(readList);
            }

            Parallel.ForEach(snapshot, obj =>
            {
                obj.Tick(deltaTime);
            });
        }
    }
}