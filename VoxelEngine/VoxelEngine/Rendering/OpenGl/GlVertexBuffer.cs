using System;
using OpenToolkit.Graphics.OpenGL4;

namespace VoxelEngine.Rendering.OpenGl
{
    public sealed class GlVertexBuffer<TType> : IVertexBuffer<TType>
        where TType : unmanaged
    {
        private readonly int _handle;
        
        public unsafe GlVertexBuffer(TType[] data)
        {
            _handle = GL.GenBuffer();
            Bind();
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * sizeof(TType), data, BufferUsageHint.StaticDraw);
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, _handle);
        }

        public void Dispose()
        {
            GL.DeleteBuffer(_handle);
        }
    }
}