using VoxelEngine.Platforms;
using VoxelEngine.Rendering;

namespace VoxelEngine
{
    public struct AppData
    {
        public IWindow Window { get; }
        
        public Renderer Renderer { get; }
        
        public AppData(IWindow window, Renderer renderer)
        {
            Window = window;
            Renderer = renderer;
        }
    }
}