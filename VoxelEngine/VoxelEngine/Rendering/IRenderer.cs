using System.Drawing;
using OpenToolkit;

namespace VoxelEngine.Rendering
{
    public interface IRenderer
    {
        public void LoadBindings(IBindingsContext context);
        
        public Color ClearColor { get; set; }

        public void Clear();

        public IVertexBuffer<TType> CreateVertexBuffer<TType>(TType[] data)
            where TType : unmanaged;
        
        public IIndexBuffer<TType> CreateIndexBuffer<TType>(TType[] data)
            where TType : unmanaged;

        public IVertexArray<TVertex, TIndex> CreateVertexArray<TVertex, TIndex>(
            TVertex[] vertices,
            TIndex[] indices,
            Layout layout)
                where TVertex : unmanaged
                where TIndex : unmanaged;
        
        public IVertexArray<TVertex, TIndex> CreateVertexArray<TVertex, TIndex>(IVertexBuffer<TVertex> vertices,
            IIndexBuffer<TIndex> indices,
            Layout layout)
                where TVertex : unmanaged
                where TIndex : unmanaged;

        public IShader CreateShader(string vertexPath, string fragmentPath);
        
        public IShader CreateShader(string vertexPath, string geometryPath, string fragmentPath);
        
        public void Submit<TVertex, TIndex>(IShader shader, IVertexArray<TVertex, TIndex> vertexArray)
            where TVertex : unmanaged
            where TIndex : unmanaged;
    }
}