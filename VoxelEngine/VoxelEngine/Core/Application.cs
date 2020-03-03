using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace VoxelEngine.Core
{
    public class Application : IDisposable
    {
        private readonly AppData _appData;
        public IState State { get; set; }
        
        public Application(AppData appData)
        {
            _appData = appData;
        }

        public void Run()
        {
            new Thread(RunDraw).Start();
            new Thread(RunUpdate).Start();
            RunInput();
        }

        private void RunUpdate()
        {
            Stopwatch watch = Stopwatch.StartNew();
            while (_appData.Window.IsRunning)
            {
                float deltaT = (float)watch.ElapsedTicks / Stopwatch.Frequency;
                watch.Restart();
                
                State.Update(deltaT);
            }
        }

        private void RunDraw()
        {
            _appData.Window.MakeCurrent();
            _appData.Renderer.LoadBindings(_appData.Window);
            _appData.Renderer.ClearColor = Color.Black;
            
            State.Initialize(_appData);
            float deltaT = 0;
            Stopwatch watch = Stopwatch.StartNew();
            Timer timer = new Timer((_) => _appData.Window.Title = "frame time [s]:" + deltaT, null, 1000, 1000);
            while (_appData.Window.IsRunning)
            {
                deltaT = (float)watch.ElapsedTicks / Stopwatch.Frequency;
                watch.Restart();
                _appData.Renderer.Clear();
                
                State.Render();
                
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
            State.Dispose();
            _appData.Window.Dispose();
        }
    }
}