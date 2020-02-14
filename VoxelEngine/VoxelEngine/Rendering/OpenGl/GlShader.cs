using System;
using System.Drawing;
using System.IO;
using System.Numerics;
using OpenToolkit.Graphics.OpenGL4;

namespace VoxelEngine.Rendering.OpenGl
{
    public class GlShader : IShader
    {
        private readonly int _handle;

        public GlShader(string vertexPath, string fragmentPath)
        {
            int CreateShader(string path, ShaderType type)
            {
                int shader = GL.CreateShader(type);
                GL.ShaderSource(shader, File.ReadAllText(path));
                GL.CompileShader(shader);
                GL.GetShader(shader, ShaderParameter.InfoLogLength, out int length);
                if (length != 0)
                {
                    throw new Exception("Error compiling shader.");
                }
                return shader;
            }
            
            _handle = GL.CreateProgram();

            int vert = CreateShader(vertexPath, ShaderType.VertexShader);
            int frag= CreateShader(fragmentPath, ShaderType.FragmentShader);
            
            GL.AttachShader(_handle, frag);
            GL.AttachShader(_handle, vert);
            GL.LinkProgram(_handle);
            GL.DetachShader(_handle, vert);
            GL.DeleteShader(vert);
            GL.DetachShader(_handle, frag);
            GL.DeleteShader(frag);
        }

        public void Dispose()
        {
            GL.DeleteProgram(_handle);
        }
        
        public void Bind()
        {
            GL.UseProgram(_handle);
        }

        public int GetAttributeLocation(string attribute)
        {
            return GL.GetAttribLocation(_handle, attribute);
        }

        public void SetUniform(string name, byte value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            Bind();
            GL.Uniform1(loc, value);
        }

        public void SetUniform(string name, short value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            Bind();
            GL.Uniform1(loc, value);
        }

        public void SetUniform(string name, int value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            Bind();
            GL.Uniform1(loc, value);
        }

        public void SetUniform(string name, float value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            Bind();
            GL.Uniform1(loc, value);
        }

        public void SetUniform(string name, Color value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            Bind();
            GL.Uniform4(loc, value);
        }

        public void SetUniform(string name, Vector2 value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            Bind();
            GL.Uniform2(loc, value.X, value.Y);
        }

        public void SetUniform(string name, Vector3 value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            Bind();
            GL.Uniform3(loc, value.X, value.Y, value.Y);
        }

        public void SetUniform(string name, Vector4 value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            Bind();
            GL.Uniform4(loc, value.X, value.Y, value.Z, value.W);
        }

        public void SetUniform(string name, Matrix4x4 value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            Bind();
            GL.UniformMatrix4(loc, 4 * 4, false, ref value.M11);
        }
    }
}