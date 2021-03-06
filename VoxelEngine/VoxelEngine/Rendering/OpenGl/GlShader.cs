﻿using System;
using System.IO;
using OpenToolkit;
using OpenToolkit.Mathematics;
using OpenToolkit.Graphics.OpenGL4;

namespace VoxelEngine.Rendering.OpenGl
{
    internal class GlShader : IShader
    {
        internal readonly int Handle;

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
            Handle = GL.CreateProgram();

            int vert = CreateShader(vertexPath, ShaderType.VertexShader);
            int frag= CreateShader(fragmentPath, ShaderType.FragmentShader);
            
            GL.AttachShader(Handle, vert);
            GL.AttachShader(Handle, frag);
            GL.LinkProgram(Handle);
            GL.DetachShader(Handle, vert);
            GL.DeleteShader(vert);
            GL.DetachShader(Handle, frag);
            GL.DeleteShader(frag);
        }
        
        public GlShader(string vertexPath, string geometryPath, string fragmentPath)
        {
            
            Handle = GL.CreateProgram();

            int vert = CreateShader(vertexPath, ShaderType.VertexShader);
            int geo = CreateShader(geometryPath, ShaderType.GeometryShader);
            int frag = CreateShader(fragmentPath, ShaderType.FragmentShader);
            
            GL.AttachShader(Handle, vert);
            GL.AttachShader(Handle, geo);
            GL.AttachShader(Handle, frag);
            GL.LinkProgram(Handle);
            GL.DetachShader(Handle, vert);
            GL.DeleteShader(vert);
            GL.DetachShader(Handle, geo);
            GL.DeleteShader(geo);
            GL.DetachShader(Handle, frag);
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
            GL.DeleteProgram(Handle);
        }
        
        public void Bind()
        {
            GL.UseProgram(Handle);
        }

        public int GetAttributeLocation(string attribute)
        {
            return GL.GetAttribLocation(Handle, attribute);
        }

        public void SetUniform(string name, byte value, bool throwOnError = false)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            if (throwOnError && loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            GL.ProgramUniform1(Handle, loc, value);
        }

        public void SetUniform(string name, short value, bool throwOnError = false)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            if (throwOnError && loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            GL.ProgramUniform1(Handle, loc, value);
        }

        public void SetUniform(string name, int value, bool throwOnError = false)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            if (throwOnError && loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            GL.ProgramUniform1(Handle, loc, value);
        }

        public void SetUniform(string name, float value, bool throwOnError = false)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            if (throwOnError && loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            GL.ProgramUniform1(Handle, loc, value);
        }

        public void SetUniform(string name, Color4<Rgba> value, bool throwOnError = false)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            if (throwOnError && loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            GL.ProgramUniform4(Handle, loc, value);
        }

        public void SetUniform(string name, Vector2 value, bool throwOnError = false)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            if (throwOnError && loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            GL.ProgramUniform2(Handle, loc, value);
        }

        public void SetUniform(string name, Vector3 value, bool throwOnError = false)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            if (throwOnError && loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            GL.ProgramUniform3(Handle, loc, value);
        }

        public void SetUniform(string name, Vector4 value, bool throwOnError = false)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            if (throwOnError && loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            GL.ProgramUniform4(Handle, loc, value);
        }

        public void SetUniform(string name, Matrix4 value, bool throwOnError = false)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            if (throwOnError && loc == -1)
            {
                throw new ArgumentException($"{name} is not a valid uniform name on the shader.");
            }
            Matrix4 v = value;
            Bind();
            GL.UniformMatrix4(loc, false, ref v);
        }
    }
}