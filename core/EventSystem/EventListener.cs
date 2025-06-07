using System;

namespace Triskai.Core
{
    public static class EventListener
    {
        public static IEventListener<T> FromAction<T>(Action<T> action) where T : IEvent
            => new ActionEventListener<T>(action);
    }
}