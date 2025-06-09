using System;

namespace Triskai.Core
{
    /// <summary>
    /// Example Action Event Listener. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
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