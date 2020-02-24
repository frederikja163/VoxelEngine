using System;

using OpenToolkit;
using OpenToolkit.Mathematics;

namespace VoxelEngine.Platforms
{
    public interface IWindow : IDisposable, IBindingsContext
    {
        public bool IsRunning { get; set; }
        
        public IInput Input { get; }
        
        public void MakeCurrent();
        
        public void SwapBuffers();
        
        public Vector2i Size { get => new Vector2i(Width, Height); }

        public int Width => Size.X;

        public int Height => Size.Y;
    }
}