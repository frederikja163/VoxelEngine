using VoxelEngine.Platforms;
using VoxelEngine.Rendering;

namespace VoxelEngine
{
    public struct AppData
    {
        public IWindow Window { get; }
        
        public IRenderer Renderer { get; }
        
        public AppData(IWindow window, IRenderer renderer)
        {
            Window = window;
            Renderer = renderer;
        }
    }
}