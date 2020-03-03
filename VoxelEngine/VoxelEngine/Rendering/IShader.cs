using System;
using OpenToolkit;
using OpenToolkit.Mathematics;

namespace VoxelEngine.Rendering
{
    public interface IShader : IDisposable
    {
        public void Bind();

        public int GetAttributeLocation(string attribute);

        public void SetUniform(string name, byte value, bool throwOnError = false);
        public void SetUniform(string name, short value, bool throwOnError = false);
        public void SetUniform(string name, int value, bool throwOnError = false);
        public void SetUniform(string name, float value, bool throwOnError = false);
        public void SetUniform(string name, Color4<Rgba> value, bool throwOnError = false);
        public void SetUniform(string name, Vector2 value, bool throwOnError = false);
        public void SetUniform(string name, Vector3 value, bool throwOnError = false);
        public void SetUniform(string name, Vector4 value, bool throwOnError = false);
        public void SetUniform(string name, Matrix4 value, bool throwOnError = false);
    }
}