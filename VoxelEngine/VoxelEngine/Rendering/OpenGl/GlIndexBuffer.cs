using System;
using OpenToolkit.Graphics.OpenGL4;

namespace VoxelEngine.Rendering.OpenGl
{
    public sealed class GlIndexBuffer<TType> : IIndexBuffer<TType>
        where TType : unmanaged
    {
        private readonly int _handle;
        
        public unsafe GlIndexBuffer(TType[] data)
        {
            _handle = GL.GenBuffer();
            Bind();
            GL.BufferData(BufferTarget.ElementArrayBuffer, data.Length * sizeof(TType), data, BufferUsageHint.StaticDraw);
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _handle);
        }

        public void Dispose()
        {
            GL.DeleteBuffer(_handle);
        }
    }
}