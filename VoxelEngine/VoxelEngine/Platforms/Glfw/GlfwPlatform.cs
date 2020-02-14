using System;
using OpenToolkit.GraphicsLibraryFramework;

namespace VoxelEngine.Platforms.Glfw
{
    public class GlfwPlatform : IPlatform
    {
        public void Initialize()
        {
            if (!GLFW.Init())
            {
                throw new Exception("Failed to initialize glfw!");
            }
        }

        public IWindow CreateWindow()
        {
            return new GlfwWindow();
        }

        public IInput CreateInput()
        {
            return new GlfwInput();
        }

        public IntPtr GetProcAddress(string procName)
        {
            return GLFW.GetProcAddress(procName);
        }

        public void Dispose()
        {
            GLFW.Terminate();
        }
    }
}