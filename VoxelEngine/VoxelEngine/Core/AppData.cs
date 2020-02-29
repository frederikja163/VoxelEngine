using VoxelEngine.Platforms;
using VoxelEngine.Rendering;

namespace VoxelEngine.Core
{
    public struct AppData
    {
        public Window Window { get; }
        
        public Renderer Renderer { get; }
        
        public AppData(PlatformApi platform, RenderingApi rendering)
        {
            Window = new Window(platform);
            Renderer = new Renderer(rendering);
        }
    }
}