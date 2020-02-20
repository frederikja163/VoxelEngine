using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using VoxelEngine.Gameplay;
using VoxelEngine.Layers;
using VoxelEngine.Platforms;
using VoxelEngine.Rendering;

/*
 * TODO-list:
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
        private readonly IState _state;
        
        public Application()
        {
            _appData = new AppData(Platform.CreateWindow(PlatformApi.GlfwDesktop),
                Renderer.CreateRenderer(RenderingApi.OpenGl));
            _state = new TestState(_appData);
        }

        public void Run()
        {
            new Thread(RunDraw).Start();
            new Thread(RunUpdate).Start();
            RunInput();
        }

        private void RunUpdate()
        {
            _state.UpdateThreadInitialize();
            Stopwatch watch = Stopwatch.StartNew();
            while (_appData.Window.IsRunning)
            {
                float deltaT = (float)watch.ElapsedTicks / Stopwatch.Frequency;
                watch.Restart();
                _state.UpdateThreadTick(deltaT);
            }
        }

        private void RunDraw()
        {
            _appData.Window.MakeCurrent();
            _appData.Renderer.LoadBindings(_appData.Window);
            _appData.Renderer.ClearColor = Color.Aqua;
            
            _state.RenderThreadInitialize();
            while (_appData.Window.IsRunning)
            {
                _appData.Renderer.Clear();
                
                _state.RenderThreadTick();
                
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
            _state.Dispose();
            _appData.Window.Dispose();
        }
    }
}