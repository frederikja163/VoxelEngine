using System;
using OpenToolkit;

namespace VoxelEngine.Platforms
{
    public interface IPlatform : IDisposable, IBindingsContext
    {
        public void Initialize();

        public IWindow CreateWindow();

        public IInput CreateInput();
    }
}