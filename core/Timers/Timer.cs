using System;

namespace Triskai.Core
{
    public class Timer : ITimer
    {
        public bool IsRunning { get; private set; }

        public float ElapsedTime { get; private set; }

        public event Action OnTimerStart;

        public event Action OnTimerStop;

        // This gets set by the Manager.
        public string Id { get; set; }

        public Timer()
        {
            IsRunning = false;
            ElapsedTime = 0;
        }

        public virtual void Reset()
        {
            ElapsedTime = 0;
        }

        public virtual void Start()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                OnTimerStart?.Invoke();
            }
        }

        public virtual void Stop()
        {
            if (IsRunning)
            {
                IsRunning = false;
                OnTimerStop?.Invoke();
            }
        }

        public virtual void Tick(float deltaTime)
        {
            if (IsRunning)
            {
                ElapsedTime += deltaTime;
            }
        }
    }
}