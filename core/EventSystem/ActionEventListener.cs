using System;

namespace Triskai.Core
{
    internal class ActionEventListener<T> : IEventListener<T> where T : IEvent
    {
        private readonly Action<T> _action;

        public ActionEventListener(Action<T> action)
        {
            _action = action;
        }

        public void OnEvent(T evt)
        {
            _action(evt);
        }
    }
}