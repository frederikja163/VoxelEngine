using OpenToolkit.GraphicsLibraryFramework;

namespace VoxelEngine.Platforms.Glfw
{
    public class GlfwInput : IInput
    {
        public GlfwInput()
        {
            
        }
        
        public void Update()
        {
            GLFW.PollEvents();
        }
    }
}