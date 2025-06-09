using System;
using System.Collections.Generic;
using System.Linq;

namespace Triskai.Core
{
    public class TimerManager : IObjectManager<ITimer>
    {
        private readonly Dictionary<string, ITimer> timers = new Dictionary<string, ITimer>();

        public void Register(ITimer timer)
        {
            string id = Guid.NewGuid().ToString();

            timer.Id = id;

            timers.Add(timer.Id, timer);
        }
        public void Deregister(ITimer timer)
        {
            timers.Remove(timer.Id);
        }

        public bool GetObject(string id, out ITimer target)
        {
            return timers.TryGetValue(id, out target);
        }

        public void Start()
        {
            for (int i = 0; i < timers.Values.Count; i++)
            {
                timers.Values.ToArray()[i].Start();
            }
        }

        public void Stop()
        {
            for (int i = 0; i < timers.Values.Count; i++)
            {
                timers.Values.ToArray()[i].Stop();
            }
        }

        public void Start(ITimer targetTimer)
        {
            Start(targetTimer.Id);
        }

        public void Stop(ITimer targetTimer)
        {
            Stop(targetTimer.Id);
        }

        public void Start(string timerId)
        {
            if (GetObject(timerId, out var timer))
            {
                timer.Start();
            }
        }

        public void Stop(string timerId)
        {
            if (GetObject(timerId, out var timer))
            {
                timer.Stop();
            }
        }


        public void Tick(float deltaTime)
        {
            List<ITimer> snapshot = timers.Values.ToList();

            for (int i = 0; i < snapshot.Count; i++)
            {
                snapshot[i].Tick(deltaTime);
            }
        }

        
    }
}