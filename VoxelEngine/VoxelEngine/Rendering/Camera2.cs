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

        public IUniformBuffer<CamData> UniformBuffer;

        private float _yaw;
        private float _pitch;
        private float _fov = 1;
        private float _aspectRatio;

        public Camera2(float aspectRatio, Renderer renderer)
        {
            UniformBuffer = renderer.CreateUniformBuffer(new CamData[] {Data});
            
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
                _pitch = value;
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

        public Vector3 Right =>  Quaternion.FromEulerAngles(_pitch, _yaw, 0) * -Vector3.UnitX;
        
        public Vector3 Front =>  Quaternion.FromEulerAngles(_pitch, _yaw, 0) * Vector3.UnitZ;
        
        public Vector3 Up =>  Vector3.UnitY;

        private void CalculateProjection()
        {
            Data.Projection = Matrix4.CreatePerspectiveFieldOfView(_fov, AspectRatio, 0.001f, 1000f);
        }

        private void CalculateView()
        {
            Data.View = Matrix4.LookAt(Data.Position, Data.Position + Front, Up);
        }
    }
}