using System;
using System.Runtime.InteropServices;

namespace Angene.Windows
{
    /// <summary>
    /// P/Invoke declarations for Direct3D 11 and DXGI
    /// </summary>
    public class D3D11
    {
        
        private const string D3D11_DLL = "d3d11.dll";
        private const string DXGI_DLL = "dxgi.dll";

        // enums
        public enum D3D_DRIVER_TYPE
        {
            D3D_DRIVER_TYPE_UNKNOWN = 0,
            D3D_DRIVER_TYPE_HARDWARE = 1,
            D3D_DRIVER_TYPE_REFERENCE = 2,
            D3D_DRIVER_TYPE_NULL = 3,
            D3D_DRIVER_TYPE_SOFTWARE = 4,
            D3D_DRIVER_TYPE_WARP = 5,
        }

        public enum D3D_FEATURE_LEVEL
        {
            D3D_FEATURE_LEVEL_9_1 = 0x9100,
            D3D_FEATURE_LEVEL_9_2 = 0x9200,
            D3D_FEATURE_LEVEL_9_3 = 0x9300,
            D3D_FEATURE_LEVEL_10_0 = 0xa000,
            D3D_FEATURE_LEVEL_10_1 = 0xa100,
            D3D_FEATURE_LEVEL_11_0 = 0xb000,
            D3D_FEATURE_LEVEL_11_1 = 0xb100,
        }

        public enum D3D11_USAGE
        {
            D3D11_USAGE_DEFAULT = 0,
            D3D11_USAGE_IMMUTABLE = 1,
            D3D11_USAGE_DYNAMIC = 2,
            D3D11_USAGE_STAGING = 3,
        }

        public enum D3D11_BIND_FLAG
        {
            D3D11_BIND_VERTEX_BUFFER = 0x1,
            D3D11_BIND_INDEX_BUFFER = 0x2,
            D3D11_BIND_CONSTANT_BUFFER = 0x4,
            D3D11_BIND_SHADER_RESOURCE = 0x8,
            D3D11_BIND_RENDER_TARGET = 0x20,
            D3D11_BIND_DEPTH_STENCIL = 0x40,
            D3D11_BIND_UNORDERED_ACCESS = 0x80,
        }

        public enum DXGI_FORMAT
        {
            DXGI_FORMAT_UNKNOWN = 0,
            DXGI_FORMAT_R32G32B32A32_TYPELESS = 1,
            DXGI_FORMAT_R32G32B32A32_FLOAT = 2,
            DXGI_FORMAT_R8G8B8A8_UNORM = 28,
            DXGI_FORMAT_R8G8B8A8_UNORM_SRGB = 29,
            DXGI_FORMAT_B8G8R8A8_UNORM = 87,
            DXGI_FORMAT_B8G8R8A8_UNORM_SRGB = 91,
            DXGI_FORMAT_D24_UNORM_S8_UINT = 45,
        }

        public enum DXGI_USAGE
        {
            DXGI_USAGE_SHADER_INPUT = 0x00000001,
            DXGI_USAGE_RENDER_TARGET_OUTPUT = 0x00000002,
            DXGI_USAGE_BACK_BUFFER = 0x00000004,
            DXGI_USAGE_SHARED = 0x00000008,
            DXGI_USAGE_READ_ONLY = 0x00000010,
            DXGI_USAGE_DISCARD_ON_PRESENT = 0x00000020,
            DXGI_USAGE_UNORDERED_ACCESS = 0x00000040,
        }

        public enum DXGI_SWAP_EFFECT
        {
            DXGI_SWAP_EFFECT_DISCARD = 0,
            DXGI_SWAP_EFFECT_SEQUENTIAL = 1,
            DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL = 3,
            DXGI_SWAP_EFFECT_FLIP_DISCARD = 4,
        }

        // structs

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_SAMPLE_DESC
        {
            public uint Count;
            public uint Quality;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_MODE_DESC
        {
            public uint Width;
            public uint Height;
            public uint RefreshRate_Numerator;
            public uint RefreshRate_Denominator;
            public DXGI_FORMAT Format;
            public uint ScanlineOrdering; // DXGI_MODE_SCANLINE_ORDER
            public uint Scaling;          // DXGI_MODE_SCALING
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_SWAP_CHAIN_DESC
        {
            public DXGI_MODE_DESC BufferDesc;
            public DXGI_SAMPLE_DESC SampleDesc;
            public DXGI_USAGE BufferUsage;
            public uint BufferCount;
            public IntPtr OutputWindow;
            public int Windowed;
            public DXGI_SWAP_EFFECT SwapEffect;
            public uint Flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct D3D11_TEXTURE2D_DESC
        {
            public uint Width;
            public uint Height;
            public uint MipLevels;
            public uint ArraySize;
            public DXGI_FORMAT Format;
            public DXGI_SAMPLE_DESC SampleDesc;
            public D3D11_USAGE Usage;
            public D3D11_BIND_FLAG BindFlags;
            public uint CPUAccessFlags;
            public uint MiscFlags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct D3D11_VIEWPORT
        {
            public float TopLeftX;
            public float TopLeftY;
            public float Width;
            public float Height;
            public float MinDepth;
            public float MaxDepth;
        }

        // functions

        [DllImport(D3D11_DLL, CallingConvention = CallingConvention.StdCall)]
        public static extern int D3D11CreateDevice(
            IntPtr pAdapter,
            D3D_DRIVER_TYPE DriverType,
            IntPtr Software,
            uint Flags,
            D3D_FEATURE_LEVEL[] pFeatureLevels,
            uint FeatureLevels,
            uint SDKVersion,
            out IntPtr ppDevice,
            out D3D_FEATURE_LEVEL pFeatureLevel,
            out IntPtr ppImmediateContext
        );

        [DllImport(DXGI_DLL, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int CreateDXGIFactory(
            [In] ref Guid riid,
            [Out] out IntPtr ppFactory
        );

        public static int CreateDXGIFactory(out IntPtr factory)
        {
            Guid IID_IDXGIFactory = new Guid("7b7166ec-21c7-44ae-b21a-c9ae321ae369");
            return CreateDXGIFactory(ref IID_IDXGIFactory, out factory);
        }

        [DllImport(DXGI_DLL, CallingConvention = CallingConvention.StdCall)]
        public static extern int CreateSwapChain(
            IntPtr pFactory,
            IntPtr pDevice,
            ref DXGI_SWAP_CHAIN_DESC pDesc,
            out IntPtr ppSwapChain
        );

        [DllImport(D3D11_DLL, CallingConvention = CallingConvention.StdCall)]
        public static extern int CreateRenderTargetView(
            IntPtr pDevice,
            IntPtr pResource,
            IntPtr pDesc,
            out IntPtr ppRTView
        );

        [DllImport(D3D11_DLL, CallingConvention = CallingConvention.StdCall)]
        public static extern int CreateTexture2D(
            IntPtr pDevice,
            ref D3D11_TEXTURE2D_DESC pDesc,
            IntPtr pInitialData,
            out IntPtr ppTexture2D
        );

        [DllImport(D3D11_DLL, CallingConvention = CallingConvention.StdCall)]
        public static extern int CreateDepthStencilView(
            IntPtr pDevice,
            IntPtr pResource,
            IntPtr pDesc,
            out IntPtr ppDepthStencilView
        );

        [DllImport(DXGI_DLL, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetSwapChainBackBuffer(
            IntPtr pSwapChain,
            uint Buffer,
            out IntPtr ppSurface
        );

        // methods with devicecontext w/ vtables
        public static void SetViewports(IntPtr pContext, uint NumViewports, ref D3D11_VIEWPORT pViewports)
        {
            // ID3D11DeviceContext::RSSetViewports (44)
            var vtable = Marshal.ReadIntPtr(pContext);
            var rsSetViewports = Marshal.ReadIntPtr(vtable, 44 * IntPtr.Size);

            var del = Marshal.GetDelegateForFunctionPointer<
                SetViewportsDelegate>(rsSetViewports);
            del(pContext, NumViewports, ref pViewports);
        }
        private delegate void SetViewportsDelegate(IntPtr pContext, uint NumViewports, ref D3D11_VIEWPORT pViewports);

        public static void ClearRenderTargetView(IntPtr pContext, IntPtr pRenderTargetView, float r, float g, float b, float a)
        {
            // ID3D11DeviceContext::ClearRenderTargetView (50)
            var vtable = Marshal.ReadIntPtr(pContext);
            var clearFunc = Marshal.ReadIntPtr(vtable, 50 * IntPtr.Size);

            float[] color = { r, g, b, a };
            var del = Marshal.GetDelegateForFunctionPointer<
                ClearRenderTargetViewDelegate>(clearFunc);
            del(pContext, pRenderTargetView, color);
        }
        private delegate void ClearRenderTargetViewDelegate(IntPtr pContext, IntPtr pRenderTargetView, float[] color);

        public static void ClearDepthStencilView(IntPtr pContext, IntPtr pDepthStencilView, uint ClearFlags, float Depth, byte Stencil)
        {
            // ID3D11DeviceContext::ClearDepthStencilView (53)
            var vtable = Marshal.ReadIntPtr(pContext);
            var clearFunc = Marshal.ReadIntPtr(vtable, 53 * IntPtr.Size);

            var del = Marshal.GetDelegateForFunctionPointer<
                ClearDepthStencilViewDelegate>(clearFunc);
            del(pContext, pDepthStencilView, ClearFlags, Depth, Stencil);
        }
        private delegate void ClearDepthStencilViewDelegate(IntPtr pContext, IntPtr pDepthStencilView, uint ClearFlags, float Depth, byte Stencil);

        public static int PresentSwapChain(IntPtr pSwapChain, uint SyncInterval, uint Flags)
        {
            // IDXGISwapChain::Present (8)
            var vtable = Marshal.ReadIntPtr(pSwapChain);
            var presentFunc = Marshal.ReadIntPtr(vtable, 8 * IntPtr.Size);

            var del = Marshal.GetDelegateForFunctionPointer<
                PresentDelegate>(presentFunc);
            return del(pSwapChain, SyncInterval, Flags);
        }
        private delegate int PresentDelegate(IntPtr pSwapChain, uint SyncInterval, uint Flags);
    }
}
