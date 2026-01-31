using System;
using System.Runtime.InteropServices;

namespace Angene.Renderers.D3D11Types
{
    // Core COM interfaces (kept minimal to what's used)
    [ComImport, Guid("db6f6ddb-ac77-4e88-8253-819df9bbf140"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID3D11Device
    {
        void CreateRenderTargetView(
            IntPtr resource,
            IntPtr desc,
            out IntPtr rtv
        );

        // Required for CreateVertexBuffer usage in D3D11Resources
        void CreateBuffer(
            ref D3D11_BUFFER_DESC desc,
            ref D3D11_SUBRESOURCE_DATA initialData,
            out IntPtr buffer
        );
    }

    [ComImport, Guid("c0bfa96c-e089-44fb-8eaf-26f8796190da"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID3D11DeviceContext
    {
        void ClearRenderTargetView(
            IntPtr rtv,
            float[] colorRGBA
        );

        void OMSetRenderTargets(
            uint numViews,
            ref IntPtr rtv,
            IntPtr depthStencilView
        );
    }

    [ComImport, Guid("7b7166ec-21c7-44ae-b21a-c9ae321ae369"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDXGIFactory
    {
        void CreateSwapChain(
            ID3D11Device device,
            ref DXGI_SWAP_CHAIN_DESC desc,
            out IDXGISwapChain swapChain
        );
    }

    [ComImport, Guid("310d36a0-d2e7-4c0a-aa04-6b3c76cba9d8"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDXGISwapChain
    {
        void Present(uint syncInterval, uint flags);
        void GetBuffer(uint index, ref Guid riid, out IntPtr surface);
    }

    // -----------------------
    // D3D11 helper enums/types
    // -----------------------
    internal enum D3D11_USAGE : uint
    {
        DEFAULT = 0,
        IMMUTABLE = 1,
        DYNAMIC = 2,
        STAGING = 3
    }

    [Flags]
    internal enum D3D11_BIND_FLAG : uint
    {
        VERTEX_BUFFER = 0x1,
        INDEX_BUFFER = 0x2,
        CONSTANT_BUFFER = 0x4,
        SHADER_RESOURCE = 0x8,
        STREAM_OUTPUT = 0x10,
        RENDER_TARGET = 0x20,
        DEPTH_STENCIL = 0x40,
        UNORDERED_ACCESS = 0x80,
        DECODER = 0x200,
        VIDEO_ENCODER = 0x400
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct D3D11_BUFFER_DESC
    {
        public uint ByteWidth;
        public D3D11_USAGE Usage;
        public D3D11_BIND_FLAG BindFlags;
        public uint CPUAccessFlags;
        public uint MiscFlags;
        public uint StructureByteStride;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct D3D11_SUBRESOURCE_DATA
    {
        public IntPtr pSysMem;
        public IntPtr SysMemPitch;
        public IntPtr SysMemSlicePitch;
    }

    // -----------------------
    // DXGI helper enums/types
    // -----------------------
    internal enum DXGI_USAGE : uint
    {
        SHADER_INPUT = 1,
        RENDER_TARGET_OUTPUT = 0x20,
        BACK_BUFFER = 0x40,
        SHARED = 0x80,
        READ_ONLY = 0x200,
        DISCARD_ON_PRESENT = 0x400,
        UNORDERED_ACCESS = 0x800
    }

    internal enum DXGI_SWAP_EFFECT : uint
    {
        DISCARD = 0,
        SEQUENTIAL = 1,
        FLIP_SEQUENTIAL = 3,
        FLIP_DISCARD = 4
    }

    internal enum DXGI_FORMAT : uint
    {
        UNKNOWN = 0,
        R8G8B8A8_UNORM = 28
        // add more as needed
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct DXGI_MODE_DESC
    {
        public uint Width;
        public uint Height;
        public uint RefreshRateNumerator;
        public uint RefreshRateDenominator;
        public DXGI_FORMAT Format;
        public uint ScanlineOrdering;
        public uint Scaling;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct DXGI_SAMPLE_DESC
    {
        public uint Count;
        public uint Quality;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct DXGI_SWAP_CHAIN_DESC
    {
        public DXGI_MODE_DESC BufferDesc;
        public DXGI_SAMPLE_DESC SampleDesc;
        public uint BufferUsage; // use DXGI_USAGE values
        public uint BufferCount;
        public IntPtr OutputWindow;
        [MarshalAs(UnmanagedType.Bool)]
        public bool Windowed;
        public DXGI_SWAP_EFFECT SwapEffect;
        public uint Flags;
    }
}