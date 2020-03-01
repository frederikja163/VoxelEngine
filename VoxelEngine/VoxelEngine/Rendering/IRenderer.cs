using System.Drawing;
using OpenToolkit;

namespace VoxelEngine.Rendering
{
    internal interface IRenderer
    {
        public void LoadBindings(IBindingsContext context);
        
        public Color ClearColor { get; set; }

        public void Clear();
        
        //TODO: use params
        public IUniformBuffer<T> CreateUniformBuffer<T>(T[] data)
            where T : unmanaged;
        
        public IVertexBuffer<T> CreateVertexBuffer<T>(T[] data)
            where T : unmanaged;
        
        public IIndexBuffer<T> CreateIndexBuffer<T>(T[] data)
            where T : unmanaged;

        public IVertexArray<T1, T2> CreateVertexArray<T1, T2>(
            T1[] vertices,
            T2[] indices,
            Layout layout)
                where T1 : unmanaged
                where T2 : unmanaged;
        
        public IVertexArray<T1, T2> CreateVertexArray<T1, T2>(IVertexBuffer<T1> vertices,
            IIndexBuffer<T2> indices,
            Layout layout)
                where T1 : unmanaged
                where T2 : unmanaged;

        public IShader CreateShader(string vertexPath, string fragmentPath);
        
        public IShader CreateShader(string vertexPath, string geometryPath, string fragmentPath);
        
        public void Submit<T1, T2>(IShader shader, IVertexArray<T1, T2> vertexArray)
            where T1 : unmanaged
            where T2 : unmanaged;
    }
}