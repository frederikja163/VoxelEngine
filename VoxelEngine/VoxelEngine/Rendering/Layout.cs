using System;
using System.Collections;
using System.Collections.Generic;

namespace VoxelEngine.Rendering
{
    public struct Layout : IEnumerable<LayoutItem>
    {
        private List<LayoutItem> _items;

        public Layout(IShader shader)
        {
            _items = new List<LayoutItem>();
            Shader = shader;
        }
        
        public IShader Shader { get; }
        
        public Layout AddItem<TType>(string attributeName, int count = 1)
            where TType : unmanaged
        {
            return AddItem(LayoutItem.CreateLayoutItem(attributeName, GetLayoutTypeOf<TType>(), count));
        }
        
        public Layout AddItem(string attributeName, LayoutType type, int count = 1)
        {
            return AddItem(LayoutItem.CreateLayoutItem(attributeName, type, count));
        }
        
        public Layout AddItem(LayoutItem item)
        {
            if (_items == null)
            {
                _items = new List<LayoutItem>();
            }
            _items.Add(item);
            return this;
        }

        public int Count => _items?.Count?? 0;

        public LayoutItem this[int index] => _items[index];
        
        public IEnumerator<LayoutItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static LayoutType GetLayoutTypeOf<TType>()
            where TType : unmanaged
        {
            return
                (typeof(TType) == typeof(float)) ? LayoutType.Float :
                (typeof(TType) == typeof(double)) ? LayoutType.Double :
                (typeof(TType) == typeof(sbyte)) ? LayoutType.SByte :
                (typeof(TType) == typeof(byte)) ? LayoutType.UByte :
                (typeof(TType) == typeof(short)) ? LayoutType.SShort :
                (typeof(TType) == typeof(ushort)) ? LayoutType.UShort :
                (typeof(TType) == typeof(int)) ? LayoutType.SInt :
                (typeof(TType) == typeof(uint)) ? LayoutType.UInt :
                throw new ArgumentOutOfRangeException(nameof(TType), typeof(TType), null);
        }

        public static Type GetTypeOf(LayoutType type)
        {
            return type switch
            {
                LayoutType.Float => typeof(float),
                LayoutType.Double => typeof(double),
                LayoutType.SByte => typeof(sbyte),
                LayoutType.UByte => typeof(byte),
                LayoutType.SShort => typeof(short),
                LayoutType.UShort => typeof(ushort),
                LayoutType.SInt => typeof(int),
                LayoutType.UInt => typeof(uint),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        public static int GetSizeOf(LayoutType type)
        {
            return type switch
            {
                LayoutType.Float => sizeof(float),
                LayoutType.Double => sizeof(double),
                LayoutType.SByte => sizeof(sbyte),
                LayoutType.UByte => sizeof(byte),
                LayoutType.SShort => sizeof(short),
                LayoutType.UShort => sizeof(ushort),
                LayoutType.SInt => sizeof(int),
                LayoutType.UInt => sizeof(uint),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}