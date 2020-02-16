using System.Numerics;

namespace VoxelEngine
{
    public class Camera : Transform
    {
        public Matrix4x4 Projection { get; private set; }
        
        public static Camera CreateOrthographic()
        {
            Camera cam = new Camera();
            cam.Projection = Matrix4x4.CreateOrthographic(1, 1, 0.001f, 1000f);
            return cam;
        }
        
        public static Camera CreatePerspective(float width, float height)
        {
            Camera cam = new Camera();
            cam.Projection = Matrix4x4.CreatePerspective(width, height, 0.001f, 1000f);
            return cam;
        }
    }
}