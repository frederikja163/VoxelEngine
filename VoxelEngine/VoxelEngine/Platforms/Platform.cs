using System;
using VoxelEngine.Platforms.Glfw;

namespace VoxelEngine.Platforms
{
    public static class Platform
    {
        public static IWindow CreateWindow(PlatformApi platformApi)
        {
            return platformApi switch
            {
                PlatformApi.GlfwDesktop => new GlfwWindow(),
                _ => throw new ArgumentOutOfRangeException(nameof(platformApi), platformApi, null)
            };
        }
    }
}