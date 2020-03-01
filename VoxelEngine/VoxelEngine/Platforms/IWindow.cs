using System;

using OpenToolkit;
using OpenToolkit.Mathematics;

namespace VoxelEngine.Platforms
{
    internal interface IWindow : IDisposable, IBindingsContext
    {
        public bool IsRunning { get; set; }
        
        public IInput Input { get; }
        
        public void MakeCurrent();
        
        public void SwapBuffers();
        
        public Vector2i Size { get; }
        
        public string Title { get; set; }

        public int Width { get; }

        public int Height { get; }
    }
}