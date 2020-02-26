using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using OpenToolkit;
using OpenToolkit.Mathematics;

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

        public static Layout GenerateFrom<TType>(IShader shader)
        {
            Layout layout = new Layout(shader);
            layout._items.AddRange(GetLayoutItems(typeof(TType)));
            return layout;
        }

        private static LayoutItem[] GetLayoutItems(Type type, string location = "")
        {
            List<LayoutItem> items = new List<LayoutItem>();
            FieldInfo[] fields = type.GetFields();
            for (int i = 0; i < fields.Length; i++)
            {
                try
                {
                    items.Add(new LayoutItem(location + fields[i].Name, GetLayoutTypeOf(fields[i].FieldType), 1));
                }
                catch (ArgumentOutOfRangeException e)
                {
                    if (fields[i].FieldType == typeof(Vector2))
                    {
                        items.Add(new LayoutItem(location + fields[i].Name, LayoutType.Float, 2));
                    }
                    else if (fields[i].FieldType == typeof(Vector3))
                    {
                        items.Add(new LayoutItem(location + fields[i].Name, LayoutType.Float, 3));
                    }
                    else if (fields[i].FieldType == typeof(Vector4) || fields[i].FieldType == typeof(Color4<Rgba>))
                    {
                        items.Add(new LayoutItem(location + fields[i].Name, LayoutType.Float, 4));
                    }
                    else
                    {
                        items.AddRange(GetLayoutItems(fields[i].FieldType, location + fields[i].Name + "."));
                    }
                }
            }

            return items.ToArray();
        }
        
        public Layout AddItem<TType>(string attributeName, int count = 1)
            where TType : unmanaged
        {
            return AddItem(new LayoutItem(attributeName, GetLayoutTypeOf<TType>(), count));
        }
        
        public Layout AddItem(string attributeName, LayoutType type, int count = 1)
        {
            return AddItem(new LayoutItem(attributeName, type, count));
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
            return GetLayoutTypeOf(typeof(TType));
        }
        
        private static LayoutType GetLayoutTypeOf(Type type)
        {
            return
                (type == typeof(float)) ? LayoutType.Float :
                (type == typeof(double)) ? LayoutType.Double :
                (type == typeof(sbyte)) ? LayoutType.SByte :
                (type == typeof(byte)) ? LayoutType.UByte :
                (type == typeof(short)) ? LayoutType.SShort :
                (type == typeof(ushort)) ? LayoutType.UShort :
                (type == typeof(int)) ? LayoutType.SInt :
                (type == typeof(uint)) ? LayoutType.UInt :
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
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