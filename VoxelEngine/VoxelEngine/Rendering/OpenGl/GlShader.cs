using System;
using System.IO;
using OpenToolkit;
using OpenToolkit.Mathematics;
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
                GL.GetShaderInfoLog(shader, out string log);
                if (log.Length != 0)
                {
                    throw new Exception(log);
                }
                return shader;
            }
            _handle = GL.CreateProgram();

            int vert = CreateShader(vertexPath, ShaderType.VertexShader);
            int frag= CreateShader(fragmentPath, ShaderType.FragmentShader);
            
            GL.AttachShader(_handle, vert);
            GL.AttachShader(_handle, frag);
            GL.LinkProgram(_handle);
            GL.DetachShader(_handle, vert);
            GL.DeleteShader(vert);
            GL.DetachShader(_handle, frag);
            GL.DeleteShader(frag);
        }
        
        public GlShader(string vertexPath, string geometryPath, string fragmentPath)
        {
            
            _handle = GL.CreateProgram();

            int vert = CreateShader(vertexPath, ShaderType.VertexShader);
            int geo= CreateShader(geometryPath, ShaderType.GeometryShader);
            int frag= CreateShader(fragmentPath, ShaderType.FragmentShader);
            
            GL.AttachShader(_handle, vert);
            GL.AttachShader(_handle, geo);
            GL.AttachShader(_handle, frag);
            GL.LinkProgram(_handle);
            GL.DetachShader(_handle, vert);
            GL.DeleteShader(vert);
            GL.DetachShader(_handle, geo);
            GL.DeleteShader(geo);
            GL.DetachShader(_handle, frag);
            GL.DeleteShader(frag);
        }
        private int CreateShader(string path, ShaderType type)
        {
            int shader = GL.CreateShader(type);
            GL.ShaderSource(shader, File.ReadAllText(path));
            GL.CompileShader(shader);
            GL.GetShaderInfoLog(shader, out string log);
            if (log.Length != 0)
            {
                throw new Exception(log);
            }
            return shader;
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
            GL.ProgramUniform1(_handle, loc, value);
        }

        public void SetUniform(string name, short value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            GL.ProgramUniform1(_handle, loc, value);
        }

        public void SetUniform(string name, int value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            GL.ProgramUniform1(_handle, loc, value);
        }

        public void SetUniform(string name, float value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            GL.ProgramUniform1(_handle, loc, value);
        }

        public void SetUniform(string name, Color4<Rgba> value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            GL.ProgramUniform4(_handle, loc, value);
        }

        public void SetUniform(string name, Vector2 value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            GL.ProgramUniform2(_handle, loc, value);
        }

        public void SetUniform(string name, Vector3 value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            GL.ProgramUniform3(_handle, loc, value);
        }

        public void SetUniform(string name, Vector4 value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            GL.ProgramUniform4(_handle, loc, value);
        }

        public void SetUniform(string name, Matrix4 value)
        {
            int loc = GL.GetUniformLocation(_handle, name);
            if (loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            Matrix4 v = value;
            GL.ProgramUniformMatrix4(_handle, loc, false, ref v);
        }
    }
}