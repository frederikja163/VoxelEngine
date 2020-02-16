using System.Collections.Generic;
using System.IO;

namespace VoxelEngine.Platforms
{
    public abstract class BaseInput : IInput
    {
        private readonly Dictionary<Key, KeyState> _keys = new Dictionary<Key, KeyState>();
        private readonly List<Key> _keysToUpdate = new List<Key>();
        
        protected void OnKeyPressed(Key key)
        {
            _keys[key] = KeyState.Pressed;
            _keysToUpdate.Add(key);
        }

        protected void OnKeyReleased(Key key)
        {
            _keys[key] = KeyState.Released;
            _keysToUpdate.Add(key);
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
                    return KeyState.Up;
                }
            }
        }

        public KeyState this[MouseButton button] => throw new System.NotImplementedException();
    }
}