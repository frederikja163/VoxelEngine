using System.Drawing;
using VoxelEngine.Platforms;

namespace VoxelEngine.Rendering
{
    public interface IRenderer
    {
        public void LoadBindings(IPlatform context);
        
        public Color ClearColor { get; set; }

        public void Clear();

        public IVertexBuffer<TType> CreateVertexBuffer<TType>(TType[] data)
            where TType : unmanaged;
        
        public IIndexBuffer<TType> CreateIndexBuffer<TType>(TType[] data)
            where TType : unmanaged;

        public IVertexArray<TVertex, TIndex> CreateVertexArray<TVertex, TIndex>(
            TVertex[] vertices,
            TIndex[] indices,
            Layout? layout = null)
                where TVertex : unmanaged
                where TIndex : unmanaged;
        
        public IVertexArray<TVertex, TIndex> CreateVertexArray<TVertex, TIndex>(
            IVertexBuffer<TVertex> vertices,
            IIndexBuffer<TIndex> indices,
            Layout? layout = null)
                where TVertex : unmanaged
                where TIndex : unmanaged;

        public IShader CreateShader(string vertexPath, string fragmentPath);
    }
}