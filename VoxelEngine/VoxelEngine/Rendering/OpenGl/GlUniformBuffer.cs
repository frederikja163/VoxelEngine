using OpenToolkit.Graphics.OpenGL4;

namespace VoxelEngine.Rendering.OpenGl
{
    internal class GlUniformBuffer<T> : IUniformBuffer<T>
        where T : unmanaged
    {
        internal readonly int Handle;

        public unsafe GlUniformBuffer(T[] data)
        {
            GL.CreateBuffers(1, out Handle);
            GL.NamedBufferData(Handle, sizeof(T) * data.Length, data, BufferUsageHint.StaticDraw);
        }

        public string Name { get; set; }

        public void Dispose()
        {
            GL.DeleteBuffer(Handle);
        }
    }
}