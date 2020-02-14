using System;
using System.Drawing;
using System.Numerics;

namespace VoxelEngine.Rendering
{
    public interface IShader : IDisposable
    {
        public void Bind();

        public int GetAttributeLocation(string attribute);

        public void SetUniform(string name, byte value);
        public void SetUniform(string name, short value);
        public void SetUniform(string name, int value);
        public void SetUniform(string name, float value);
        public void SetUniform(string name, Color value);
        public void SetUniform(string name, Vector2 value);
        public void SetUniform(string name, Vector3 value);
        public void SetUniform(string name, Vector4 value);
        public void SetUniform(string name, Matrix4x4 value);
    }
}