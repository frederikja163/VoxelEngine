using System;
using OpenToolkit.Mathematics;

namespace VoxelEngine.Platforms
{
    public interface IInput
    {
        public void Update();

        public Action<Key> KeyPressed { get; set; }
        
        public Action<Key> KeyReleased { get; set; }
        
        public Action<OpenToolkit.Mathematics.Vector2> MouseMoved { get; set; }
        
        public KeyState this[Key key] { get; }
        
        public KeyState this[MouseButton button] { get; }
        
        public Vector2 MousePosition { get; set; }
        
        public bool IsCenterMode { get; set; }
    }
}