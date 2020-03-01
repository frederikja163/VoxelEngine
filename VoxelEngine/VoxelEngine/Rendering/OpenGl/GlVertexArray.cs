using System;
using OpenToolkit.Graphics.OpenGL4;

namespace VoxelEngine.Rendering.OpenGl
{
    internal sealed class GlVertexArray<TVertex, TIndex> : IVertexArray<TVertex, TIndex>
        where TVertex : unmanaged
        where TIndex : unmanaged
    {
        internal readonly int Handle;
        
        public GlVertexBuffer<TVertex> GlVbo { get; }

        public IVertexBuffer<TVertex> Vbo => GlVbo;
        
        public GlIndexBuffer<TIndex> GlIbo { get; }

        public IIndexBuffer<TIndex> Ibo => GlIbo;

        public Layout Layout { get; }

        public GlVertexArray(GlVertexBuffer<TVertex> vertices, GlIndexBuffer<TIndex> indices, Layout layout)
        {
            GlVbo = vertices;
            GlIbo = indices;
            Layout = layout;

            Handle = GL.GenVertexArray();
            Bind();
            Vbo.Bind();
            Ibo.Bind();

            int stride = 0;
            for (int i = 0; i < layout.Count; i++)
            {
                stride += Layout.GetSizeOf(layout[i].Type) * layout[i].Count;
            }

            int offset = 0;
            for (int i = 0; i < layout.Count; i++)
            {
                int location = layout.Shader.GetAttributeLocation(layout[i].AttributeName);
                GL.EnableVertexAttribArray(location);
                GL.VertexAttribPointer(location, layout[i].Count, GetAttribType(layout[i].Type), false, stride, offset);
                offset += Layout.GetSizeOf(layout[i].Type) * layout[i].Count;
            }
        }
        
        public void Bind()
        {
            GL.BindVertexArray(Handle);
        }

        public void Dispose()
        {
            GL.DeleteVertexArray(Handle);
        }

        private VertexAttribPointerType GetAttribType(LayoutType type)
        {
            return type switch
            {
                LayoutType.Float => VertexAttribPointerType.Float,
                LayoutType.Double => VertexAttribPointerType.Double,
                LayoutType.SByte => VertexAttribPointerType.Byte,
                LayoutType.UByte => VertexAttribPointerType.UnsignedByte,
                LayoutType.SShort => VertexAttribPointerType.Short,
                LayoutType.UShort => VertexAttribPointerType.UnsignedShort,
                LayoutType.SInt => VertexAttribPointerType.Int,
                LayoutType.UInt => VertexAttribPointerType.UnsignedInt,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}