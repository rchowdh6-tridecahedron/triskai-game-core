namespace Triskai.Core
{
    /// <summary>
    /// A general UpdateLoop interface.
    /// </summary>
    public interface ITickable
    {
        void Tick(float deltaTime);
    }
}