using System.Numerics;
using VoxelEngine.Extensions;

namespace VoxelEngine.Rendering
{
    public class Transform
    {
        public Vector3 Position { get; set; }
        
        public Quaternion Rotation { get; set; } = Quaternion.Identity;

        public float Scale { get; set; } = 1;

        public Vector3 Right =>  Rotation.Multiply(Vector3.UnitX);
        
        public Vector3 Front =>  Rotation.Multiply(Vector3.UnitZ);
        
        public Vector3 Up =>  Rotation.Multiply(Vector3.UnitY);

        public Matrix4x4 CreateMatrix()
        {
            return Matrix4x4.Identity *
                   Matrix4x4.CreateFromQuaternion(Rotation) *
                   Matrix4x4.CreateScale(Scale) *
                   Matrix4x4.CreateTranslation(Position);
        }
    }
}