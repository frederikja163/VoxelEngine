using System;
using System.Collections.Generic;

namespace VoxelEngine.Layers
{
    public class LayerManager : IDisposable
    {
        private readonly AppData _appData;
        private readonly List<ILayer> _layers;
        
        public LayerManager(AppData appData)
        {
            _appData = appData;
            _layers = new List<ILayer>();
        }

        public void AddLayer(ILayer layer)
        {
            _layers.Add(layer);
            layer.AddedToManager(_appData);
        }
        
        public void UpdateThreadInitialize()
        {
            for (int i = 0; i < _layers.Count; i++)
            {
                _layers[i].UpdateThreadInitialize();
            }
        }

        public void RenderThreadInitialize()
        {
            for (int i = 0; i < _layers.Count; i++)
            {
                _layers[i].RenderThreadInitialize();
            }
        }

        public void UpdateThreadTick()
        {
            for (int i = 0; i < _layers.Count; i++)
            {
                _layers[i].UpdateThreadTick();
            }   
        }

        public void RenderThreadTick()
        {
            for (int i = 0; i < _layers.Count; i++)
            {
                _layers[i].RenderThreadTick();
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < _layers.Count; i++)
            {
                _layers[i].Dispose();
            }
        }
    }
}