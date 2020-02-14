using System;

namespace VoxelEngine.Layers
{
    public interface ILayer : IDisposable
    {
        public void AddedToManager(AppData appData);
        
        public void UpdateThreadInitialize() { }

        public void RenderThreadInitialize() { }
        
        public void UpdateThreadTick() { }
        
        public void RenderThreadTick() { }
    }
}