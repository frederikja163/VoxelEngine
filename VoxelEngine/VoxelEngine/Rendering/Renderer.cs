using System;
using VoxelEngine.Rendering.OpenGl;

namespace VoxelEngine.Rendering
{
    public static class Renderer
    {
        public static IRenderer CreateRenderer(RenderingApi renderer)
        {
            return renderer switch
            {
                RenderingApi.OpenGl => new GlRenderer(),
                _ => throw new ArgumentOutOfRangeException(nameof(renderer), renderer, null)
            };
        }
    }
}