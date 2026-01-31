using System;
using System.Runtime.InteropServices;

namespace Angene.Graphics.D3D11Types
{
    internal static class D3D11Interop
    {
        public const int D3D11_SDK_VERSION = 7;

        [DllImport("d3d11.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int D3D11CreateDevice(
            IntPtr adapter,
            D3D_DRIVER_TYPE driverType,
            IntPtr software,
            uint flags,
            IntPtr featureLevels,
            uint featureLevelsCount,
            int sdkVersion,
            out ID3D11Device device,
            out D3D_FEATURE_LEVEL featureLevel,
            out ID3D11DeviceContext context
        );

        [DllImport("dxgi.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int CreateDXGIFactory(
            ref Guid riid,
            out IDXGIFactory factory
        );
    }

    internal enum D3D_DRIVER_TYPE : uint
    {
        HARDWARE = 1,
        WARP = 5
    }

    internal enum D3D_FEATURE_LEVEL : uint
    {
        LEVEL_11_0 = 0xB000
    }
}
