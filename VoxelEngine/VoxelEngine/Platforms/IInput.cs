namespace VoxelEngine.Platforms
{
    public interface IInput
    {
        public void Update();
        
        public KeyState this[Key key] { get; }
        
        public KeyState this[MouseButton button] { get; }
    }
}