namespace Triskai.Core
{
    /// <summary>
    /// A general Update Loop interface.
    /// </summary>
    public interface ITickable
    {
        /// <summary>
        /// Tick forward a period of time. This could
        /// be per frame, but could also be used for any other
        /// situation. 
        /// This is similar to Update or FixedUpdate in Unity
        /// The deltaTime would be equivalent to the Time.deltaTime or Time.fixedDeltaTime
        /// in Unity.
        /// </summary>
        /// <param name="deltaTime">The amount of time that has passed</param>
        void Tick(float deltaTime);
    }
}