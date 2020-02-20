using System;

namespace VoxelEngine.Gameplay
{
    public interface IState : IDisposable
    {
        public void UpdateThreadInitialize() { }

        public void RenderThreadInitialize() { }
        
        public void UpdateThreadTick(float deltaT) { }
        
        public void RenderThreadTick() { }
    }
}