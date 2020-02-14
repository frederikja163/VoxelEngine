using VoxelEngine.Platforms;
using VoxelEngine.Rendering;

namespace VoxelEngine
{
    public struct AppData
    {
        public IWindow Window { get; }
        
        public IInput Input { get; }
        
        public IRenderer Renderer { get; }

        public AppData(IWindow window, IInput input, IRenderer renderer)
        {
            Window = window;
            Input = input;
            Renderer = renderer;
        }
    }
}