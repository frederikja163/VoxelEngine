using System;
using System.Drawing;
using System.Numerics;
using OpenToolkit.Graphics.OpenGL4;
using VoxelEngine.Platforms;
using VoxelEngine.Rendering;

namespace VoxelEngine.Layers
{
    public class TestLayer : ILayer
    {
        private struct Vertex
        {
            public Vector3 vPos;
            public Vector4 vColor;

            public Vertex(float x, float y, float z)
            {
                vPos = new Vector3(x, y, z);
                vColor = Vector4.One;
            }

            public Vertex(Vector3 pos, Color color)
            {
                vPos = pos;
                vColor = new Vector4(color.R, color.G, color.B, color.A) / 255f;
            }
        }
        
        private IRenderer _renderer;
        private IInput _input;
        private IShader _shader;
        private IVertexBuffer<Vertex> _vbo;
        private IIndexBuffer<uint> _ebo;
        private IVertexArray<Vertex, uint> _vao;

        private static readonly uint[] Indices = new uint[]
        {
            0, 1, 2,
            0, 2, 3
        };

        private static readonly Vertex[] Vert = new Vertex[]
        {
            new Vertex(new Vector3(0.5f, 0.5f, 0), Color.Gray),
            new Vertex(new Vector3(0.5f, -0.5f, 0), Color.Gray),
            new Vertex(new Vector3(-0.5f, -0.5f, 0), Color.Gray),
            new Vertex(new Vector3(-0.5f, 0.5f, 0), Color.Gray)
        };

        public void AddedToManager(AppData appData)
        {
            _input = appData.Window.Input;
            _renderer = appData.Renderer;
        }

        public void RenderThreadInitialize()
        {
            _shader = _renderer.CreateShader("Assets\\vertex.glsl", "Assets\\fragment.glsl");
            Layout layout = Layout.GenerateFrom<Vertex>(_shader);

            _vbo = _renderer.CreateVertexBuffer(Vert);
            _ebo = _renderer.CreateIndexBuffer(Indices);
            _vao = _renderer.CreateVertexArray(_vbo, _ebo, layout);

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