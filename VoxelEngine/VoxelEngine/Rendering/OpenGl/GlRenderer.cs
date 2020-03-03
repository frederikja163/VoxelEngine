using System.Drawing;
using OpenToolkit;
using OpenToolkit.Graphics.OpenGL4;

namespace VoxelEngine.Rendering.OpenGl
{
    internal sealed class GlRenderer : IRenderer
    {
        public GlRenderer()
        {
            
        }

        public void LoadBindings(IBindingsContext context)
        {
            GL.LoadBindings(context);
            GL.Enable(EnableCap.DepthTest);
            //GL.Enable(EnableCap.CullFace);
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
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
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
            Layout layout)
                where TVertex : unmanaged
                where TIndex : unmanaged
        {
            return CreateVertexArray(CreateVertexBuffer(vertices), CreateIndexBuffer(indices), layout);
        }

        public IVertexArray<TVertex, TIndex> CreateVertexArray<TVertex, TIndex>(IVertexBuffer<TVertex> vertices,
            IIndexBuffer<TIndex> indices,
            Layout layout)
                where TVertex : unmanaged
                where TIndex : unmanaged
        {
            GlVertexBuffer<TVertex> vert = vertices as GlVertexBuffer<TVertex>;
            GlIndexBuffer<TIndex> ind = indices as GlIndexBuffer<TIndex>;

            return new GlVertexArray<TVertex, TIndex>(vert, ind, layout);
        }

        public IShader CreateShader(string vertexPath, string fragmentPath)
        {
            return new GlShader(vertexPath, fragmentPath);
        }

        public IShader CreateShader(string vertexPath, string geometryPath, string fragmentPath)
        {
            return new GlShader(vertexPath, geometryPath, fragmentPath);
        }

        public void Submit<TVertex, TIndex>(IShader shader, IVertexArray<TVertex, TIndex> vertexArray) where TVertex : unmanaged where TIndex : unmanaged
        {
            GlIndexBuffer<TIndex> ibo = (vertexArray as GlVertexArray<TVertex, TIndex>)?.GlIbo;
            
            vertexArray.Bind();
            GL.DrawElements(PrimitiveType.Points, ibo.Size, DrawElementsType.UnsignedInt, 0);
        }
    }
}