using System;

namespace VoxelEngine.Rendering
{
    public interface IUniformBuffer<T> : IDisposable where T : unmanaged
    {
        public string Name { get; set; }
    }
}