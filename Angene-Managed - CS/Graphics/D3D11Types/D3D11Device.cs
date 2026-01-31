using System;
using static Angene.Graphics.D3D11Types.D3D11Interop;

namespace Angene.Graphics.D3D11Types
{
    internal sealed class D3D11Device
    {
        public ID3D11Device Device { get; }
        public ID3D11DeviceContext Context { get; }

        public D3D11Device()
        {
            D3D11CreateDevice(
                IntPtr.Zero,
                D3D_DRIVER_TYPE.HARDWARE,
                IntPtr.Zero,
                0,
                IntPtr.Zero,
                0,
                D3D11_SDK_VERSION,
                out var device,
                out _,
                out var context
            );

            Device = device;
            Context = context;
        }
    }
}
