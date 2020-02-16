using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using VoxelEngine.Layers;
using VoxelEngine.Platforms;
using VoxelEngine.Rendering;

/*
 * TODO-list:
 * Camera
 * Input API
 * Chunks
 * Chunk batching
 * Multiple chunks
 * Render distance
 * Multiplayer
 */


namespace VoxelEngine
{
    public class Application : IDisposable
    {
        private readonly AppData _appData;
        private readonly LayerManager _layers;
        
        public Application()
        {
            _appData = new AppData(Platform.CreateWindow(PlatformApi.GlfwDesktop),
                Renderer.CreateRenderer(RenderingApi.OpenGl));
            
            _layers = new LayerManager(_appData);
        }

        public void Run()
        {
            _layers.AddLayer(new TestLayer());
            new Thread(RunDraw).Start();
            new Thread(RunUpdate).Start();
            RunInput();
        }

        private void RunUpdate()
        {
            _layers.UpdateThreadInitialize();
            while (_appData.Window.IsRunning)
            {
                _layers.UpdateThreadTick();
            }
        }

        private void RunDraw()
        {
            _appData.Window.MakeCurrent();
            _appData.Renderer.LoadBindings(_appData.Window);
            _appData.Renderer.ClearColor = Color.Aqua;
            
            _layers.RenderThreadInitialize();

            while (_appData.Window.IsRunning)
            {
                _appData.Renderer.Clear();
                
                _layers.RenderThreadTick();
                
                _appData.Window.SwapBuffers();
            }
        }

        private void RunInput()
        {
            while (_appData.Window.IsRunning)
            {
                _appData.Window.Input.Update();
            }
        }

        public void Dispose()
        {
            _layers.Dispose();
            _appData.Window.Dispose();
        }
    }
}