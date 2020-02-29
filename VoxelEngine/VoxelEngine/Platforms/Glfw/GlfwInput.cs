using System;
using OpenToolkit.GraphicsLibraryFramework;
using OpenToolkit.Mathematics;

namespace VoxelEngine.Platforms.Glfw
{
    internal sealed class GlfwInput : BaseInput
    {
        private readonly unsafe OpenToolkit.GraphicsLibraryFramework.Window* _window;
        private Vector2 _mousePos;
        private bool _isCenterMode;
        
        public unsafe GlfwInput(OpenToolkit.GraphicsLibraryFramework.Window* window)
        {
            _window = window;
            
            GLFW.GetCursorPos(_window, out double x, out double y);
            _mousePos = new Vector2((float)x, (float)y);
            
            GLFW.SetKeyCallback(window, KeyEvent);
            GLFW.SetCursorPosCallback(window, MouseEvent);
        }
        
        private unsafe void KeyEvent(OpenToolkit.GraphicsLibraryFramework.Window* window1, Keys key, int code, InputAction action,KeyModifiers mods)
        {
            Key? k = GlfwKeyToKey(key);
            if (k != null)
            {
                if (action == InputAction.Press)
                {
                    OnKeyPressed(k.Value);
                }
                else if (action == InputAction.Release)
                {
                    OnKeyReleased(k.Value);
                }
            }
        }
        
        private unsafe void MouseEvent(OpenToolkit.GraphicsLibraryFramework.Window* window1, double x, double y)
        {
            Vector2 newMouse = new Vector2((float) x, (float) y);
            MouseMoved?.Invoke(_mousePos - newMouse);
            _mousePos = newMouse;
        }
        
        public override void Update()
        {
            base.Update();
            GLFW.PollEvents();
        }

        public override Action<Vector2> MouseMoved { get; set; }
        
        public override unsafe Vector2 MousePosition
        {
            get => _mousePos;
            set
            {
                GLFW.SetCursorPos(_window, value.X, value.Y);
            }
        }

        public override unsafe bool IsCenterMode
        {
            get => _isCenterMode;
            set
            {
                _isCenterMode = value;
                if (value)
                {
                    GLFW.SetInputMode(_window, CursorStateAttribute.Cursor, CursorModeValue.CursorDisabled);
                }
                else
                {
                    GLFW.SetInputMode(_window, CursorStateAttribute.Cursor, CursorModeValue.CursorNormal);
                }
            }
        }

        private static KeyState GlfwKeystateToKeystate(InputAction state)
        {
            return state switch
            {
                InputAction.Release => KeyState.Released,
                InputAction.Press => KeyState.Pressed,
                InputAction.Repeat => KeyState.Down,
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };
        }

        private static Key? GlfwKeyToKey(Keys key)
        {
            Key? InvalidKey()
            {
                Console.WriteLine($"Glfw key {key} has not yet been mapped to a key.");
                return null;
            }

            return key switch
            {
                Keys.D0 => Key.Num0,
                Keys.D1 => Key.Num1,
                Keys.D2 => Key.Num2,
                Keys.D3 => Key.Num3,
                Keys.D4 => Key.Num4,
                Keys.D5 => Key.Num5,
                Keys.D6 => Key.Num6,
                Keys.D7 => Key.Num7,
                Keys.D8 => Key.Num8,
                Keys.D9 => Key.Num9,
                Keys.A => Key.A,
                Keys.B => Key.B,
                Keys.C => Key.C,
                Keys.D => Key.D,
                Keys.E => Key.E,
                Keys.F => Key.F,
                Keys.G => Key.G,
                Keys.H => Key.H,
                Keys.I => Key.I,
                Keys.J => Key.J,
                Keys.K => Key.K,
                Keys.L => Key.L,
                Keys.M => Key.M,
                Keys.N => Key.N,
                Keys.O => Key.O,
                Keys.P => Key.P,
                Keys.Q => Key.Q,
                Keys.R => Key.R,
                Keys.S => Key.S,
                Keys.T => Key.T,
                Keys.U => Key.U,
                Keys.V => Key.V,
                Keys.W => Key.W,
                Keys.X => Key.X,
                Keys.Y => Key.Y,
                Keys.Z => Key.Z,
                Keys.Escape => Key.Escape,
                Keys.KeyPad0 => Key.Num0,
                Keys.KeyPad1 => Key.Num1,
                Keys.KeyPad2 => Key.Num2,
                Keys.KeyPad3 => Key.Num3,
                Keys.KeyPad4 => Key.Num4,
                Keys.KeyPad5 => Key.Num5,
                Keys.KeyPad6 => Key.Num6,
                Keys.KeyPad7 => Key.Num7,
                Keys.KeyPad8 => Key.Num8,
                Keys.KeyPad9 => Key.Num9,
                Keys.LeftShift => Key.Shift,
                Keys.LeftControl => Key.Control,
                Keys.LeftAlt => Key.Alt,
                Keys.RightShift => Key.Shift,
                Keys.RightControl => Key.Control,
                Keys.RightAlt => Key.Alt,
                Keys.Space => Key.Space,
                _ => InvalidKey()
            };
        }
    }
}