using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triskai.Core
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<object>> _listeners = new Dictionary<Type, List<object>>();
        private readonly object _lock = new object();

        public void Raise<T>(T evt) where T : IEvent
        {
            List<IEventListener<T>> snapshot;

            lock (_lock)
            {
                if (!_listeners.TryGetValue(typeof(T), out var list))
                    return;

                snapshot = list.Cast<IEventListener<T>>().ToList();
            }

            for (int i = 0; i < snapshot.Count; i++)
            {
                snapshot[i].OnEvent(evt);
            }
        }

        public void Subscribe<T>(IEventListener<T> listener) where T : IEvent
        {
            lock (_lock)
            {
                if (!_listeners.TryGetValue(typeof(T), out var list))
                {
                    list = new List<object>();
                    _listeners[typeof(T)] = list;
                }

                list.Add(listener);
            }
        }

        public void Unsubscribe<T>(IEventListener<T> listener) where T : IEvent
        {
            lock (_lock)
            {
                if (_listeners.TryGetValue(typeof(T), out var list))
                {
                    list.Remove(listener);
                    if (list.Count == 0)
                    {
                        _listeners.Remove(typeof(T));
                    }
                }
            }
        }
    }
}