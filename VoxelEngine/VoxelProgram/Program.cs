using VoxelEngine;
using VoxelEngine.Core;
using VoxelEngine.Platforms;
using VoxelEngine.Rendering;

namespace VoxelProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            AppData data = new AppData(PlatformApi.GlfwDesktop, RenderingApi.OpenGl);
            Application app = new Application(data);
            app.State = new GameState(data);
            
            app.Run();
            app.Dispose();
        }
    }
}