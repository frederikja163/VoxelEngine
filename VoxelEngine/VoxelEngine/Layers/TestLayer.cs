using System;
using System.Numerics;
using OpenToolkit.Graphics.OpenGL4;
using VoxelEngine.Rendering;

namespace VoxelEngine.Layers
{
    public class TestLayer : ILayer
    {
        private IRenderer _renderer;
        private IShader _shader;
        private IVertexBuffer<float> _vbo;
        private IIndexBuffer<uint> _ebo;
        private IVertexArray<float, uint> _vao;

        private static readonly float[] Vertices = new float[]
        {
              0.5f,  0.5f, 0,
              0.5f, -0.5f, 0,
             -0.5f, -0.5f, 0,
             -0.5f,  0.5f, 0
        };

        private static readonly uint[] Indices = new uint[]
        {
            0, 1, 2,
            0, 2, 3
        };

        public void AddedToManager(AppData appData)
        {
            _renderer = appData.Renderer;
        }

        public void RenderThreadInitialize()
        {
            _shader = _renderer.CreateShader("Assets\\vertex.glsl", "Assets\\fragment.glsl");
            
            Layout layout = new Layout(_shader)
                .AddItem<float>("vPos", 3);
            
            _vbo = _renderer.CreateVertexBuffer(Vertices);
            _ebo = _renderer.CreateIndexBuffer(Indices);
            _vao = _renderer.CreateVertexArray(Vertices, Indices, layout);

        }

        public void RenderThreadTick()
        {
            _shader.Bind();
            GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);
        }

        public void Dispose()
        {
            _shader.Dispose();
            _vbo.Dispose();
            _ebo.Dispose();
            _vao.Dispose();
        }
    }
}