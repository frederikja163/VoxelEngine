using System.Numerics;

namespace VoxelEngine
{
    public class Transform
    {
        public Vector3 Position { get; set; }
        
        public Quaternion Rotation { get; set; }
        
        public float Scale { get; set; }

        public Matrix4x4 CreateMatrix()
        {
            return Matrix4x4.Identity *
                   Matrix4x4.CreateScale(Scale) *
                   Matrix4x4.CreateFromQuaternion(Rotation) *
                   Matrix4x4.CreateTranslation(Position);
        }
    }
}