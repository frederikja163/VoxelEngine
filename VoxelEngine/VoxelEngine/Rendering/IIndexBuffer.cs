using System;

namespace VoxelEngine.Rendering
{
    public interface IIndexBuffer<in TType> : IDisposable
        where TType : unmanaged
    {
        void Bind();
    }
}