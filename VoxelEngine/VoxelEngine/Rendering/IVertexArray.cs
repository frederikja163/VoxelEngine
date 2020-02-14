using System;

namespace VoxelEngine.Rendering
{
    public interface IVertexArray<in TVertex, in TIndex> : IDisposable
        where TVertex : unmanaged
        where TIndex : unmanaged
    {
        IVertexBuffer<TVertex> Vbo { get; }
        
        IIndexBuffer<TIndex> Ibo { get; }
        
        Layout Layout { get; }

        void Bind();
    }
}