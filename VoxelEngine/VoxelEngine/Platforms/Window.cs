using System;
using OpenToolkit.Mathematics;
using VoxelEngine.Platforms.Glfw;

namespace VoxelEngine.Platforms
{
    public sealed class Window : IWindow
    {
        private readonly IWindow _windowImplementation;
        
        public Window(PlatformApi platformApi)
        {
            _windowImplementation = platformApi switch
            {
                PlatformApi.GlfwDesktop => new GlfwWindow(),
                _ => throw new ArgumentOutOfRangeException(nameof(platformApi), platformApi, null)
            };
        }
        
        public void Dispose()
        {
            _windowImplementation.Dispose();
        }

        public IntPtr GetProcAddress(string procName)
        {
            return _windowImplementation.GetProcAddress(procName);
        }

        public bool IsRunning
        {
            get => _windowImplementation.IsRunning;
            set => _windowImplementation.IsRunning = value;
        }

        public IInput Input => _windowImplementation.Input;

        public void MakeCurrent()
        {
            _windowImplementation.MakeCurrent();
        }

        public void SwapBuffers()
        {
            _windowImplementation.SwapBuffers();
        }

        public Vector2i Size => _windowImplementation.Size;

        public int Width => _windowImplementation.Width;

        public int Height => _windowImplementation.Height;
    }
}