using System;
using System.Numerics;

namespace VoxelEngine.Platforms
{
    public interface IInput
    {
        public void Update();

        public Action<Key> KeyPressed { get; }
        
        public Action<Key> KeyReleased { get; }
        
        public Action<Vector2> MouseMoved { get; }
        
        public KeyState this[Key key] { get; }
        
        public KeyState this[MouseButton button] { get; }
        
        public Vector2 MousePosition { get; set; }
        
        public bool IsCenterMode { get; set; }
    }
}