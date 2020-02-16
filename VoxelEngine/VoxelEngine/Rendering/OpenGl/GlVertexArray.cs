using System;
using OpenToolkit.Graphics.OpenGL4;

namespace VoxelEngine.Rendering.OpenGl
{
    public sealed class GlVertexArray<TVertex, TIndex> : IVertexArray<TVertex, TIndex>
        where TVertex : unmanaged
        where TIndex : unmanaged
    {
        private readonly int _handle;
        
        public IVertexBuffer<TVertex> Vbo { get; }
        
        public IIndexBuffer<TIndex> Ibo { get; }

        public Layout Layout { get; }

        public GlVertexArray(GlVertexBuffer<TVertex> vertices, GlIndexBuffer<TIndex> indices, Layout layout)
        {
            Vbo = vertices;
            Ibo = indices;
            Layout = layout;

            _handle = GL.GenVertexArray();
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
                GL.VertexAttribPointer(location, layout[i].Count, GetAttribType(layout[i].Type), true, stride, offset);
                offset += Layout.GetSizeOf(layout[i].Type) * layout[i].Count;
            }
        }
        
        public void Bind()
        {
            GL.BindVertexArray(_handle);
        }

        public void Dispose()
        {
            GL.DeleteVertexArray(_handle);
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