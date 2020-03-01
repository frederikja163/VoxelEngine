using VoxelEngine.Core;
using VoxelEngine.Platforms;
using VoxelEngine.Rendering;

namespace VoxelProgram
{
    public class GameState : IState
    {
        private readonly Window _window;
        private readonly Renderer _renderer;
        private Player _player;
        private ChunkManager _chunkManager;

        public GameState(AppData appData)
        {
            _window = appData.Window;
            _window.Input.IsCenterMode = true;
            _window.Input.KeyPressed += key =>
            {
                if(key == Key.Escape)
                {
                    _window.IsRunning = false;
                } 
            };
            _renderer = appData.Renderer;
        }
        
        public void Update(float deltaT)
        {
            _player?.Update(deltaT);
        }

        public void Initialize(AppData data)
        {
            _player = new Player(_window, _renderer);
            _chunkManager = new ChunkManager(_renderer);
            _renderer.Camera = _player.Camera;
            _chunkManager.Initialize();
        }

        public void Render()
        {
            _chunkManager.Render();
        }
        
        public void Dispose()
        {
            _window.Dispose();
        }
    }
}