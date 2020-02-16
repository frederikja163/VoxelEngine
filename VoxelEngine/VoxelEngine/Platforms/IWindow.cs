using System;
using OpenToolkit;

namespace VoxelEngine.Platforms
{
    public interface IWindow : IDisposable, IBindingsContext
    {
        public bool IsRunning { get; set; }
        
        public IInput Input { get; }
        
        public void MakeCurrent();
        
        public void SwapBuffers();
    }
}