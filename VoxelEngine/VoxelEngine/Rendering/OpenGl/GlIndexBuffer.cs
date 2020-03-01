using OpenToolkit.Graphics.OpenGL4;

namespace VoxelEngine.Rendering.OpenGl
{
    internal sealed class GlIndexBuffer<TType> : IIndexBuffer<TType>
        where TType : unmanaged
    {
        internal readonly int Handle;
        
        public unsafe GlIndexBuffer(params TType[] data)
        {
            Size = data.Length;
            GL.CreateBuffers(1, out Handle);
            GL.NamedBufferData(Handle, data.Length * sizeof(TType), data, BufferUsageHint.StaticDraw);
        }
        
        public int Size { get; }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, Handle);
        }

        public void Dispose()
        {
            GL.DeleteBuffer(Handle);
        }
    }
}