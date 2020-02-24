using System;
using System.Drawing;
using OpenToolkit;
using OpenToolkit.Mathematics;
using OpenToolkit.Graphics.OpenGL4;
using VoxelEngine.Gameplay;
using VoxelEngine.Platforms;
using VoxelEngine.Rendering;

namespace VoxelEngine.Layers
{
    public class TestState : IState
    {
        private struct Vertex
        {
            public Vector3 vPos;
            public Color4<Rgba> vColor;

            public Vertex(float x, float y, float z)
            {
                vPos = new Vector3(x, y, z);
                vColor = Color4.White;
            }

            public Vertex(Vector3 pos, Color4<Rgba> color)
            {
                vPos = pos;
                vColor = color;
            }
        }
        
        private IRenderer _renderer;
        private IInput _input;
        private IShader _shader;
        private IVertexBuffer<Vertex> _vbo;
        private IIndexBuffer<uint> _ebo;
        private IVertexArray<Vertex, uint> _vao;
        private Camera _camera;
        private Transform _transform = new Transform();

        private static readonly uint[] Indices = new uint[]
        {
            0, 1, 2,
            0, 2, 3
        };

        private static readonly Vertex[] Vert = new Vertex[]
        {
            new Vertex(new Vector3(0.5f, 0.5f, 0), Color4.Gray),
            new Vertex(new Vector3(0.5f, -0.5f, 0), Color4.White),
            new Vertex(new Vector3(-0.5f, -0.5f, 0), Color4.Black),
            new Vertex(new Vector3(-0.5f, 0.5f, 0), Color4.Gray)
        };

        public TestState(AppData appData)
        {
            _input = appData.Window.Input;
            _input.KeyPressed += (key) =>
            {
                if (key == Key.Escape)
                {
                    appData.Window.IsRunning = false;
                }
            };
            _input.MouseMoved += mouseDelta =>
            {
                _camera.Pitch += mouseDelta.Y / 100;
                _camera.Yaw -= mouseDelta.X / 100;
            };
            _input.IsCenterMode = true;
            _renderer = appData.Renderer;
            _camera = new Camera(Vector3.One, 1028 / 720f);
            _transform.Position = Vector3.UnitX * 0.5f;
            _transform.Rotation = Quaternion.FromAxisAngle(Vector3.UnitY, 1);
        }

        public void UpdateThreadTick(float deltaT)
        {
            Vector3 dir = Vector3.Zero;
            Vector3 front = _camera.Front;
            front.Y = 0;
            front.Normalize();
            if (_input[Key.W] == KeyState.Down)
            {
                dir += front;
            }
            if (_input[Key.S] == KeyState.Down)
            {
                dir -= front;
            }
            if (_input[Key.A] == KeyState.Down)
            {
                dir -= _camera.Right;
            }
            if (_input[Key.D] == KeyState.Down)
            {
                dir += _camera.Right;
            }
            if (_input[Key.Space] == KeyState.Down)
            {
                dir.Y += 1;
            }
            if (_input[Key.Shift] == KeyState.Down)
            {
                dir.Y -= 1;
            }

            if (_input[Key.Control] == KeyState.Down)
            {
                dir *= 2f;
                _camera.Fov = (float)Math.PI / 2.1f;
            }
            else
            {
                _camera.Fov = (float) Math.PI / 2f;
            }
            
            _camera.Position += dir * deltaT;
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
            _shader.SetUniform("uModel", _transform.CreateMatrix());
            _shader.SetUniform("uView", _camera.GetViewMatrix());
            _shader.SetUniform("uProjection", _camera.GetProjectionMatrix());
            GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);
            _shader.SetUniform("uModel", Matrix4.Identity);
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