using System;
using OpenToolkit.Mathematics;
using VoxelEngine.Platforms;
using VoxelEngine.Rendering;

namespace VoxelEngine.Gameplay
{
    public sealed class Player
    {
        private readonly IInput _input;
        
        public Camera Camera { get; }

        public Player(in IWindow window)
        {
            _input = window.Input;
            Camera = new Camera(Vector3.Zero, (float)window.Width / window.Height);
        }

        public void Update(float deltaT)
        {
            Vector3 dir = Vector3.Zero;
            Vector3 front = Camera.Front;
            front.Y = 0;
            front.Normalize();
            if (_input[Key.W] == KeyState.Down)
            {
                dir += front;
            }
            if (_input[Key.S] == KeyState.Down)
            {
                dir -= front;
            }
            if (_input[Key.A] == KeyState.Down)
            {
                dir -= Camera.Right;
            }
            if (_input[Key.D] == KeyState.Down)
            {
                dir += Camera.Right;
            }
            if (_input[Key.Space] == KeyState.Down)
            {
                dir.Y += 1;
            }
            if (_input[Key.Shift] == KeyState.Down)
            {
                dir.Y -= 1;
            }

            if (_input[Key.Control] == KeyState.Down)
            {
                dir *= 2f;
                Camera.Fov = (float)Math.PI / 2.1f;
            }
            else
            {
                Camera.Fov = (float) Math.PI / 2f;
            }
            
            Camera.Position += dir * deltaT;
        }
    }
}