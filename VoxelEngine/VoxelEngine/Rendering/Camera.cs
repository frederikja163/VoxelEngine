using OpenToolkit.Mathematics;

namespace VoxelEngine.Rendering
{
    public class Camera : Transform
    {
        public Matrix4 Projection { get; private set; }
        
        public static Camera CreateOrthographic()
        {
            Camera cam = new Camera();
            cam.Projection = Matrix4.CreateOrthographic(1, 1, 0.001f, 1000f);
            return cam;
        }
        
        public static Camera CreatePerspective(float fov, float aspect)
        {
            Camera cam = new Camera();
            cam.Projection = Matrix4.CreatePerspectiveFieldOfView(fov, aspect, 0.001f, 1000f);
            return cam;
        }
    }
}