using System;
using OpenToolkit;
using OpenToolkit.Graphics.OpenGL4;
using OpenToolkit.GraphicsLibraryFramework;
using VoxelEngine.Platforms.Glfw;

namespace VoxelEngine
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Application app = new Application();
            app.Run();
            app.Dispose();
        }
    }
}