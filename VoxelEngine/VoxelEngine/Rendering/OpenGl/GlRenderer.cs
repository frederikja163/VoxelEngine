using System.Drawing;
using OpenToolkit;
using OpenToolkit.Graphics.OpenGL4;
using VoxelEngine.Platforms;

namespace VoxelEngine.Rendering.OpenGl
{
    public sealed class GlRenderer : IRenderer
    {
        public GlRenderer()
        {
            
        }

        public void LoadBindings(IBindingsContext context)
        {
            GL.LoadBindings(context);
        }

        private Color _clearColor;

        public Color ClearColor
        {
            get => _clearColor;
            set
            {
                _clearColor = value;
                GL.ClearColor(value);
            }
        }
        
        public void Clear()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public IVertexBuffer<TType> CreateVertexBuffer<TType>(TType[] data)
            where TType : unmanaged
        {
            return new GlVertexBuffer<TType>(data);
        }

        public IIndexBuffer<TType> CreateIndexBuffer<TType>(TType[] data)
            where TType : unmanaged
        {
            return new GlIndexBuffer<TType>(data);
        }

        public IVertexArray<TVertex, TIndex> CreateVertexArray<TVertex, TIndex>(
            TVertex[] vertices,
            TIndex[] indices,
            Layout? layout = null)
                where TVertex : unmanaged
                where TIndex : unmanaged
        {
            return CreateVertexArray(CreateVertexBuffer(vertices), CreateIndexBuffer(indices), layout);
        }

        public IVertexArray<TVertex, TIndex> CreateVertexArray<TVertex, TIndex>(
            IVertexBuffer<TVertex> vertices,
            IIndexBuffer<TIndex> indices,
            Layout? layout = null)
                where TVertex : unmanaged
                where TIndex : unmanaged
        {
            GlVertexBuffer<TVertex> vert = vertices as GlVertexBuffer<TVertex>;
            GlIndexBuffer<TIndex> ind = indices as GlIndexBuffer<TIndex>;
            
            if (layout == null)
            {
                layout = new Layout();
            }

            return new GlVertexArray<TVertex, TIndex>(vert, ind, layout.Value);
        }

        public IShader CreateShader(string vertexPath, string fragmentPath)
        {
            return new GlShader(vertexPath, fragmentPath);
        }
    }
}