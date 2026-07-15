using System;

namespace Angene.Graphics.DX11 // match your --namespace value
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