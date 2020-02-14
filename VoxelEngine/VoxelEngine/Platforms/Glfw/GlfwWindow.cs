using System;
using OpenToolkit.GraphicsLibraryFramework;

namespace VoxelEngine.Platforms.Glfw
{
    public class GlfwWindow : IWindow
    {
        private readonly unsafe OpenToolkit.GraphicsLibraryFramework.Window* _windowHandle;
        
        public unsafe GlfwWindow()
        {
            _windowHandle = GLFW.CreateWindow(1028, 720, "voxel engine", null, null);
            GLFW.SwapInterval(1);
        }

        public unsafe bool IsRunning
        {
            get => !GLFW.WindowShouldClose(_windowHandle);
            set => GLFW.SetWindowShouldClose(_windowHandle, !value);
        }

        public unsafe void MakeCurrent()
        {
            GLFW.MakeContextCurrent(_windowHandle);
        }

        public unsafe void SwapBuffers()
        {
            GLFW.SwapBuffers(_windowHandle);
        }

        private unsafe void ReleaseUnmanagedResources()
        {
            GLFW.DestroyWindow(_windowHandle);
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~GlfwWindow()
        {
            ReleaseUnmanagedResources();
        }
    }
}