using System;
using OpenToolkit.GraphicsLibraryFramework;

namespace VoxelEngine.Platforms.Glfw
{
    public class GlfwInput : BaseInput
    {
        public unsafe GlfwInput(Window* window)
        {
            GLFW.SetKeyCallback(window, (window1, key, code, action, mods) =>
            {
                Key? k = GlfwKeyToKey(key);
                KeyState state = GlfwKeystateToKeystate(action);
                if (k != null)
                {
                    if (state == KeyState.Pressed)
                    {
                        OnKeyPressed(k.Value);
                    }
                    else if (state == KeyState.Released)
                    {
                        OnKeyReleased(k.Value);
                    }
                }
            });
        }
        
        public override void Update()
        {
            base.Update();
            GLFW.PollEvents();
        }

        private KeyState GlfwKeystateToKeystate(InputAction state)
        {
            return state switch
            {
                InputAction.Release => KeyState.Released,
                InputAction.Press => KeyState.Pressed,
                InputAction.Repeat => KeyState.Down,
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };
        }

        private Key? GlfwKeyToKey(Keys key)
        {
            Key? InvalidKey()
            {
                Console.WriteLine($"Glfw key {key} has not yet been mapped to a key.");
                return null;
            }

            return key switch
            {
                OpenToolkit.GraphicsLibraryFramework.Keys.D0 => Key.Num0,
                OpenToolkit.GraphicsLibraryFramework.Keys.D1 => Key.Num1,
                OpenToolkit.GraphicsLibraryFramework.Keys.D2 => Key.Num2,
                OpenToolkit.GraphicsLibraryFramework.Keys.D3 => Key.Num3,
                OpenToolkit.GraphicsLibraryFramework.Keys.D4 => Key.Num4,
                OpenToolkit.GraphicsLibraryFramework.Keys.D5 => Key.Num5,
                OpenToolkit.GraphicsLibraryFramework.Keys.D6 => Key.Num6,
                OpenToolkit.GraphicsLibraryFramework.Keys.D7 => Key.Num7,
                OpenToolkit.GraphicsLibraryFramework.Keys.D8 => Key.Num8,
                OpenToolkit.GraphicsLibraryFramework.Keys.D9 => Key.Num9,
                OpenToolkit.GraphicsLibraryFramework.Keys.A => Key.A,
                OpenToolkit.GraphicsLibraryFramework.Keys.B => Key.B,
                OpenToolkit.GraphicsLibraryFramework.Keys.C => Key.C,
                OpenToolkit.GraphicsLibraryFramework.Keys.D => Key.D,
                OpenToolkit.GraphicsLibraryFramework.Keys.E => Key.E,
                OpenToolkit.GraphicsLibraryFramework.Keys.F => Key.F,
                OpenToolkit.GraphicsLibraryFramework.Keys.G => Key.G,
                OpenToolkit.GraphicsLibraryFramework.Keys.H => Key.H,
                OpenToolkit.GraphicsLibraryFramework.Keys.I => Key.I,
                OpenToolkit.GraphicsLibraryFramework.Keys.J => Key.J,
                OpenToolkit.GraphicsLibraryFramework.Keys.K => Key.K,
                OpenToolkit.GraphicsLibraryFramework.Keys.L => Key.L,
                OpenToolkit.GraphicsLibraryFramework.Keys.M => Key.M,
                OpenToolkit.GraphicsLibraryFramework.Keys.N => Key.N,
                OpenToolkit.GraphicsLibraryFramework.Keys.O => Key.O,
                OpenToolkit.GraphicsLibraryFramework.Keys.P => Key.P,
                OpenToolkit.GraphicsLibraryFramework.Keys.Q => Key.Q,
                OpenToolkit.GraphicsLibraryFramework.Keys.R => Key.R,
                OpenToolkit.GraphicsLibraryFramework.Keys.S => Key.S,
                OpenToolkit.GraphicsLibraryFramework.Keys.T => Key.T,
                OpenToolkit.GraphicsLibraryFramework.Keys.U => Key.U,
                OpenToolkit.GraphicsLibraryFramework.Keys.V => Key.V,
                OpenToolkit.GraphicsLibraryFramework.Keys.W => Key.W,
                OpenToolkit.GraphicsLibraryFramework.Keys.X => Key.X,
                OpenToolkit.GraphicsLibraryFramework.Keys.Y => Key.Y,
                OpenToolkit.GraphicsLibraryFramework.Keys.Z => Key.Z,
                OpenToolkit.GraphicsLibraryFramework.Keys.Escape => Key.Escape,
                OpenToolkit.GraphicsLibraryFramework.Keys.KeyPad0 => Key.Num0,
                OpenToolkit.GraphicsLibraryFramework.Keys.KeyPad1 => Key.Num1,
                OpenToolkit.GraphicsLibraryFramework.Keys.KeyPad2 => Key.Num2,
                OpenToolkit.GraphicsLibraryFramework.Keys.KeyPad3 => Key.Num3,
                OpenToolkit.GraphicsLibraryFramework.Keys.KeyPad4 => Key.Num4,
                OpenToolkit.GraphicsLibraryFramework.Keys.KeyPad5 => Key.Num5,
                OpenToolkit.GraphicsLibraryFramework.Keys.KeyPad6 => Key.Num6,
                OpenToolkit.GraphicsLibraryFramework.Keys.KeyPad7 => Key.Num7,
                OpenToolkit.GraphicsLibraryFramework.Keys.KeyPad8 => Key.Num8,
                OpenToolkit.GraphicsLibraryFramework.Keys.KeyPad9 => Key.Num9,
                OpenToolkit.GraphicsLibraryFramework.Keys.LeftShift => Key.Shift,
                OpenToolkit.GraphicsLibraryFramework.Keys.LeftControl => Key.Control,
                OpenToolkit.GraphicsLibraryFramework.Keys.LeftAlt => Key.Alt,
                OpenToolkit.GraphicsLibraryFramework.Keys.RightShift => Key.Shift,
                OpenToolkit.GraphicsLibraryFramework.Keys.RightControl => Key.Control,
                OpenToolkit.GraphicsLibraryFramework.Keys.RightAlt => Key.Alt,
                _ => InvalidKey()
            };
        }
    }
}