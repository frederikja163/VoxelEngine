using OpenToolkit.Mathematics;
using VoxelEngine.Rendering;

namespace VoxelProgram
{
    public class ChunkManager
    {
        private struct Cube
        {
            public Vector3 VPosition;

            public Cube(byte x, byte y, byte z)
            {
                VPosition.X = x;
                VPosition.Y = y;
                VPosition.Z = z;
            }
        }
        
        private struct Chunk
        {
            public Cube[] Cubes { get; }
            
            public byte Width { get; }
            
            public byte Height { get; }
            
            public byte Depth { get; }

            public int TotalSize => Width * Height * Depth;
            
            public Vector3 Position { get; set; }

            public Chunk(byte width, byte height, byte depth)
            {
                Position = Vector3.Zero;
                Width = width;
                Height = height;
                Depth = depth;
                
                Cubes = new Cube[Width * Height * Depth];
                for (byte x = 0; x < Width; x++)
                {
                    for (byte y = 0; y < height; y++)
                    {
                        for (byte z = 0; z < Depth; z++)
                        {
                            this[x, y, z] = new Cube(x, y, z);
                        }
                    }
                }
            }

            public Cube this[int x, int y, int z]
            {
                get => Cubes[x + y * Width + z * Width * Height];
                private set => Cubes[x + y * Width + z * Width * Height] = value;
            }
        }

        private Chunk _chunk;
        private Renderer _renderer;
        private IVertexArray<Cube, uint> _vertexArray;
        private IShader _shader;

        public ChunkManager(Renderer renderer)
        {
            _chunk = new Chunk(32, 32, 32);
            _chunk.Position = new Vector3(0, 0, 0);
            _renderer = renderer;
        }

        public void Initialize()
        {
            uint[] indices = new uint[_chunk.TotalSize];
            for (uint i = 0; i < _chunk.TotalSize; i++)
            {
                indices[i] = i;
            }
            _shader = _renderer.CreateShader("Assets\\Chunk.vert", "Assets\\Chunk.geom", "Assets\\Chunk.frag");
            _vertexArray = _renderer.CreateVertexArray(_chunk.Cubes, indices, Layout.GenerateFrom<Cube>(_shader));
        }

        public void Render()
        {
            _shader.SetUniform("UPosition", _chunk.Position);
            _renderer.Submit(_shader, _vertexArray);
        }
    }
}