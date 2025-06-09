using System;

namespace Triskai.Core
{
    /// <summary>
    /// The base level timer interface
    /// </summary>
    public interface ITimer : ITickableObject
    {
        /// <summary>
        /// Check if the timer is running.
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// How much time has passed since timer has started
        /// </summary>
        float ElapsedTime { get; }

        /// <summary>
        /// Timer Start Event
        /// </summary>
        event Action OnTimerStart;

        /// <summary>
        /// Timer Stop Event
        /// </summary>
        event Action OnTimerStop;

        /// <summary>
        /// Start Timer
        /// </summary>
        void Start();

        /// <summary>
        /// Stop Timer
        /// </summary>
        void Stop();

        /// <summary>
        /// Reset Elapsed Time
        /// </summary>
        void Reset();
    }
}