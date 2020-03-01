using OpenToolkit.Graphics.OpenGL4;

namespace VoxelEngine.Rendering.OpenGl
{
    internal sealed class GlVertexBuffer<TType> : IVertexBuffer<TType>
        where TType : unmanaged
    {
        internal readonly int Handle;
        
        public unsafe GlVertexBuffer(TType[] data)
        {
            GL.CreateBuffers(1, out Handle);
            GL.NamedBufferData(Handle, data.Length * sizeof(TType), data, BufferUsageHint.StaticDraw);
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, Handle);
        }

        public void Dispose()
        {
            GL.DeleteBuffer(Handle);
        }
    }
}