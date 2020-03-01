using System;
using System.Drawing;
using OpenToolkit;
using VoxelEngine.Rendering.OpenGl;

namespace VoxelEngine.Rendering
{
    public class Renderer : IRenderer
    {
        private readonly IRenderer _rendererImplementation;

        public Camera2 Camera { get; set; }
        
        public Renderer(RenderingApi renderingApi)
        {
            _rendererImplementation = renderingApi switch
            {
                RenderingApi.OpenGl => new GlRenderer(),
                _ => throw new ArgumentOutOfRangeException(nameof(renderingApi), renderingApi, null)
            };
        }

        public void LoadBindings(IBindingsContext context)
        {
            _rendererImplementation.LoadBindings(context);
        }

        public Color ClearColor
        {
            get => _rendererImplementation.ClearColor;
            set => _rendererImplementation.ClearColor = value;
        }

        public void Clear()
        {
            _rendererImplementation.Clear();
        }

        public IUniformBuffer<T> CreateUniformBuffer<T>(T[] data) where T : unmanaged
        {
            return _rendererImplementation.CreateUniformBuffer(data);
        }

        public IVertexBuffer<TType> CreateVertexBuffer<TType>(TType[] data) where TType : unmanaged
        {
            return _rendererImplementation.CreateVertexBuffer(data);
        }

        public IIndexBuffer<TType> CreateIndexBuffer<TType>(TType[] data) where TType : unmanaged
        {
            return _rendererImplementation.CreateIndexBuffer(data);
        }

        public IVertexArray<TVertex, TIndex> CreateVertexArray<TVertex, TIndex>(TVertex[] vertices, TIndex[] indices, Layout layout) where TVertex : unmanaged where TIndex : unmanaged
        {
            return _rendererImplementation.CreateVertexArray(vertices, indices, layout);
        }

        public IVertexArray<TVertex, TIndex> CreateVertexArray<TVertex, TIndex>(IVertexBuffer<TVertex> vertices,
            IIndexBuffer<TIndex> indices, Layout layout) where TVertex : unmanaged where TIndex : unmanaged
        {
            return _rendererImplementation.CreateVertexArray(vertices, indices, layout);
        }

        public IShader CreateShader(string vertexPath, string fragmentPath)
        {
            return _rendererImplementation.CreateShader(vertexPath, fragmentPath);
        }
        
        public IShader CreateShader(string vertexPath, string geometryPath, string fragmentPath)
        {
            return _rendererImplementation.CreateShader(vertexPath, geometryPath, fragmentPath);
        }

        public void Submit<TVertex, TIndex>(IShader shader, IVertexArray<TVertex, TIndex> vertexArray) where TVertex : unmanaged where TIndex : unmanaged
        {
            shader.Bind();
            shader.SetUniform("uView", Camera.Data.View);
            shader.SetUniform("uProjection", Camera.Data.Projection);
            _rendererImplementation.Submit(shader, vertexArray);
        }
    }
}