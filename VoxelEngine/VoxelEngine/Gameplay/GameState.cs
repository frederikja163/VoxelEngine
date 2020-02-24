using VoxelEngine.Platforms;
using VoxelEngine.Rendering;

namespace VoxelEngine.Gameplay
{
    public class GameState : IState
    {
        private readonly IWindow _window;
        private readonly IRenderer _renderer;
        private readonly Player _player;

        public GameState(AppData appData)
        {
            _window = appData.Window;
            _renderer = appData.Renderer;
            
            _player = new Player(_window);
        }

        public void UpdateThreadTick(float deltaT)
        {
            _player.Update(deltaT);
        }
        
        public void Dispose()
        {
            _window.Dispose();
        }
    }
}