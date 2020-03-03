﻿using System;
 using OpenToolkit.Mathematics;
using Quaternion = OpenToolkit.Mathematics.Quaternion;
using Vector3 = OpenToolkit.Mathematics.Vector3;

namespace VoxelEngine.Rendering
{
    public class Camera2
    {
        public struct CamData
        {
            public Vector3 Position;
            public Matrix4 View;
            public Matrix4 Projection;
        }

        public CamData Data;

        private float _yaw = -(float)Math.PI / 2f;
        private float _pitch;
        private float _fov = 1;
        private float _aspectRatio;

        private Vector3 _front;
        private Vector3 _right;
        private Vector3 _up;

        public Camera2(float aspectRatio, Renderer renderer)
        {   
            _aspectRatio = aspectRatio;
            Data = new CamData();

            CalculateProjection();
            CalculateView();
        }
        
        public Vector3 Position
        {
            get => Data.Position;
            set
            {
                Data.Position = value;
                CalculateView();
            }
        }
        
        public float Yaw
        {
            get => _yaw;
            set
            {
                _yaw = value;
                CalculateView();;
            } 
        }
        public float Pitch
        {
            get => _pitch;
            set
            {
                _pitch = Math.Clamp(value, -MathF.PI / 2.1f, MathF.PI / 2.1f);
                CalculateView();;
            } 
        }

        public float Fov
        {
            get => _fov;
            set
            {
                _fov = value;
                CalculateProjection();
            }
        }

        public float AspectRatio
        {
            get => _aspectRatio;
            set
            {
                _aspectRatio = value;
                CalculateProjection();
            }
        }

        public Vector3 Right =>  _right;
        
        public Vector3 Front =>  _front;
        
        public Vector3 Up =>  _up;

        private void CalculateProjection()
        {
            Data.Projection = Matrix4.CreatePerspectiveFieldOfView(_fov, AspectRatio, 0.001f, 1000f);
        }

        private void CalculateView()
        {
            _front.X = MathF.Cos(_pitch) * MathF.Cos(_yaw);
            _front.Y = MathF.Sin(_pitch);
            _front.Z = MathF.Cos(_pitch) * MathF.Sin(_yaw);
            
            _front.Normalize();
            
            _right = Vector3.Normalize(Vector3.Cross(_front, Vector3.UnitY));
            _up = Vector3.Normalize(Vector3.Cross(_right, _front));

            Data.View = Matrix4.LookAt(Data.Position, Data.Position + Front, Up);
        }
    }
}