using System;

namespace VoxelEngine.Platforms
{
    public interface IWindow : IDisposable
    {
        public bool IsRunning { get; set; }
        
        public void MakeCurrent();
        
        public void SwapBuffers();
    }
}