﻿using System;

namespace VoxelEngine.Rendering
{
    public struct LayoutItem
    {
        public string AttributeName { get; }
        
        public LayoutType Type { get; }
        
        public int Count { get; }
        
        
        private LayoutItem(string attribName, LayoutType type, int count)
        {
            AttributeName = attribName;
            Count = count;
            Type = type;
        }

        public static LayoutItem CreateLayoutItem(string attributeName, LayoutType type, int count)
        {
            return new LayoutItem(attributeName, type, count);
        }
    }
}