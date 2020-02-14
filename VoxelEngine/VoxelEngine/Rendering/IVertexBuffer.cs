using System;

namespace VoxelEngine.Rendering
{
    public interface IVertexBuffer<in TType> : IDisposable
        where TType : unmanaged
    {
        void Bind();
    }
}