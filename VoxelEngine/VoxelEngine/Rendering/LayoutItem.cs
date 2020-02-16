using System;

namespace VoxelEngine.Rendering
{
    public struct LayoutItem
    {
        public string AttributeName { get; }
        
        public LayoutType Type { get; }
        
        public int Count { get; }
        
        
        public LayoutItem(string attribName, LayoutType type, int count)
        {
            AttributeName = attribName;
            Count = count;
            Type = type;
        }
    }
}