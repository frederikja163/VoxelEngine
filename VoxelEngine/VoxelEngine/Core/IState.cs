using System;

namespace VoxelEngine.Core
{
    public interface IState : IDisposable
    {
        public void Initialize(AppData appData);

        public void Update(float deltaT);

        public void Render();
    }
}