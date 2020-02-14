using System;
using OpenToolkit.GraphicsLibraryFramework;
using VoxelEngine.Platforms.Glfw;

namespace VoxelEngine.Platforms
{
    public static class Platform
    {
        public static IPlatform CreatePlatform(PlatformApi platformApi)
        {
            return platformApi switch
            {
                PlatformApi.GlfwDesktop => new GlfwPlatform(),
                _ => throw new ArgumentOutOfRangeException(nameof(platformApi), platformApi, null)
            };
        }
    }
}