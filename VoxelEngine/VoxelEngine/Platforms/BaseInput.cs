using System;
using System.Collections.Generic;
using OpenToolkit.Mathematics;

namespace VoxelEngine.Platforms
{
    public abstract class BaseInput : IInput
    {
        private readonly Dictionary<Key, KeyState> _keys = new Dictionary<Key, KeyState>();
        private readonly List<Key> _keysToUpdate = new List<Key>();
        
        protected void OnKeyPressed(Key key)
        {
            if (!_keys.TryAdd(key, KeyState.Pressed))
            {
                _keys[key] = KeyState.Pressed;
            }
            _keysToUpdate.Add(key);
            KeyPressed?.Invoke(key);
        }

        protected void OnKeyReleased(Key key)
        {
            if (!_keys.TryAdd(key, KeyState.Released))
            {
                _keys[key] = KeyState.Released;
            }
            _keysToUpdate.Add(key);
            KeyReleased?.Invoke(key);
        }

        public virtual void Update()
        {
            for (int i = 0; i < _keysToUpdate.Count; i++)
            {
                if (_keys[_keysToUpdate[i]] == KeyState.Pressed)
                {
                    _keys[_keysToUpdate[i]] = KeyState.Down;
                }
                else
                {
                    _keys[_keysToUpdate[i]] = KeyState.Up;
                }
            }
            _keysToUpdate.Clear();
        }

        public Action<Key> KeyPressed { get; set; }
        
        public Action<Key> KeyReleased { get; set; }
        public abstract Action<Vector2> MouseMoved { get; set; }

        public KeyState this[Key key]
        {
            get
            {
                try
                {
                    return _keys[key];
                }
                catch
                {
                    _keys.TryAdd(key, KeyState.Up);
                    return KeyState.Up;
                }
            }
        }

        public KeyState this[MouseButton button] => throw new System.NotImplementedException();
        
        public abstract Vector2 MousePosition { get; set; }
        
        public abstract bool IsCenterMode { get; set; }
    }
}