using System;

namespace VoxelEngine.Rendering
{
    public interface IUniformBuffer<T> : IDisposable where T : unmanaged
    {
        public void UpdateBuffer(int start, params T[] data);

        public unsafe void UpdateBuffer(params T[] data);
        
        public string Name { get; set; }
    }
}