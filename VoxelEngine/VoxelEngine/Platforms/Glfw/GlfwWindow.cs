using System;
using OpenToolkit.GraphicsLibraryFramework;
using OpenToolkit.Mathematics;

namespace VoxelEngine.Platforms.Glfw
{
    internal sealed class GlfwWindow : IWindow
    {
        private static int _windowCount = 0;
        private readonly unsafe OpenToolkit.GraphicsLibraryFramework.Window* _windowHandle;
        
        public unsafe GlfwWindow()
        {
            if (_windowCount++ == 0)
            {
                GLFW.Init();
            }
            _windowHandle = GLFW.CreateWindow(1028, 720, "voxel engine", null, null);
            GLFW.SwapInterval(1);
            
            Input = new GlfwInput(_windowHandle);
        }

        public unsafe bool IsRunning
        {
            get => !GLFW.WindowShouldClose(_windowHandle);
            set => GLFW.SetWindowShouldClose(_windowHandle, !value);
        }

        public IInput Input { get; }

        public unsafe void MakeCurrent()
        {
            GLFW.MakeContextCurrent(_windowHandle);
        }

        public unsafe void SwapBuffers()
        {
            GLFW.SwapBuffers(_windowHandle);
        }


        public unsafe Vector2i Size
        {
            get
            {
                GLFW.GetWindowSize(_windowHandle, out int w, out int h);
                return new Vector2i(w, h);
            }
        }

        public int Width => Size.Y;
        
        public int Height => Size.X;

        private unsafe void ReleaseUnmanagedResources()
        {
            GLFW.DestroyWindow(_windowHandle);
        }

        public unsafe void Dispose()
        {
            GLFW.DestroyWindow(_windowHandle);
            if (_windowCount-- == 1)
            {
                GLFW.Terminate();
            }
        }

        ~GlfwWindow()
        {
            ReleaseUnmanagedResources();
        }
        
        public IntPtr GetProcAddress(string procName)
        {
            return GLFW.GetProcAddress(procName);
        }
    }
}