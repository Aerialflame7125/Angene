using System;
using System.Runtime.InteropServices;

namespace Angene.Graphics.D3D11Types
{
    internal static class D3D11Resources
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Vertex
        {
            public float X, Y, Z;
            public float R, G, B, A;
        }

        public static IntPtr CreateVertexBuffer(
            ID3D11Device device,
            Vertex[] vertices
        )
        {
            int size = Marshal.SizeOf<Vertex>() * vertices.Length;

            var desc = new D3D11_BUFFER_DESC
            {
                ByteWidth = (uint)size,
                Usage = D3D11_USAGE.DEFAULT,
                BindFlags = D3D11_BIND_FLAG.VERTEX_BUFFER
            };

            var data = new D3D11_SUBRESOURCE_DATA
            {
                pSysMem = Marshal.UnsafeAddrOfPinnedArrayElement(vertices, 0)
            };

            device.CreateBuffer(ref desc, ref data, out var buffer);
            return buffer;
        }
    }
}
