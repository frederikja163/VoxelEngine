using OpenToolkit.Mathematics;
using VoxelEngine;

namespace VoxelEngine.Rendering
{
    public class Transform
    {
        public Vector3 Position { get; set; }
        
        public Quaternion Rotation { get; set; } = Quaternion.Identity;

        public float Scale { get; set; } = 1;

        public Vector3 Right =>  Rotation * Vector3.UnitX;
        
        public Vector3 Front =>  Rotation * Vector3.UnitZ;
        
        public Vector3 Up =>  Rotation * Vector3.UnitY;

        public Matrix4 CreateMatrix()
        {
            return Matrix4.Identity *
                   Matrix4.CreateFromQuaternion(Rotation) *
                   Matrix4.CreateScale(Scale) *
                   Matrix4.CreateTranslation(Position);
        }
    }
}