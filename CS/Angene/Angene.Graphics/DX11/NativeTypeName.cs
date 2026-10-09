#if WINDOWS
using System;

namespace Angene.Graphics.DX11
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    internal sealed partial class NativeTypeNameAttribute : Attribute
    {
        private readonly string _name;

        public NativeTypeNameAttribute(string name)
        {
            _name = name;
        }

        public string Name => _name;
    }
}
#endif