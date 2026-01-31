using System;
using System.Runtime.InteropServices;

namespace Angene.Graphics.D3D11Types
{
    internal static class D3D11Shaders
    {
        [DllImport("d3dcompiler_47.dll")]
        public static extern int D3DCompile(
            string src,
            IntPtr srcLen,
            string sourceName,
            IntPtr defines,
            IntPtr include,
            string entryPoint,
            string target,
            uint flags,
            uint flags2,
            out IntPtr code,
            out IntPtr errors
        );
    }
}
