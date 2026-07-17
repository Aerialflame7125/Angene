using System;
using System.Runtime.InteropServices;
using static Angene.Windows.D3D11.D3D11Interop;
using static Angene.Windows.Dxgi.DxgiEnums;
using static Angene.Windows.Dxgi.DxgiInterfaces;

namespace Angene.Windows.D3D11
{
    /// <summary>
    /// P/Invoke declarations for Direct3D 11 and DXGI
    /// </summary>
    public class D3D11
    {
        private const string D3D11_DLL = "d3d11.dll";
        private const string DXGI_DLL = "dxgi.dll";

        private const int VT_CreateBuffer = 3;
        private const int VT_CreateTexture2D = 5;
        private const int VT_CreateRenderTargetView = 9;
        private const int VT_Factory_CreateSwapChain = 10;
        private const int VT_CreateDepthStencilView = 10;
        private const int VT_CreateInputLayout = 11;
        private const int VT_CreateVertexShader = 12;
        private const int VT_CreatePixelShader = 15;
        private const int VT_CreateRasterizerState = 22;

        // enums
        [StructLayout(LayoutKind.Sequential)]
        public struct D3D11_INPUT_ELEMENT_DESC
        {
            public IntPtr SemanticName; // ANSI string pointer — marshal manually, see note below
            public uint SemanticIndex;
            public DXGI_FORMAT Format;
            public uint InputSlot;
            public uint AlignedByteOffset;
            public uint InputSlotClass; // D3D11_INPUT_PER_VERTEX_DATA = 0
            public uint InstanceDataStepRate;
        }
        public enum D3D11_MAP
        {
            D3D11_MAP_READ = 1,
            D3D11_MAP_WRITE = 2,
            D3D11_MAP_READ_WRITE = 3,
            D3D11_MAP_WRITE_DISCARD = 4,
            D3D11_MAP_WRITE_NO_OVERWRITE = 5,
        }

        [Flags]
        public enum D3D11_CPU_ACCESS_FLAG : uint
        {
            D3D11_CPU_ACCESS_WRITE = 0x10000,
            D3D11_CPU_ACCESS_READ = 0x20000,
        }

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
        [StructLayout(LayoutKind.Sequential)]
        public struct D3D11_RASTERIZER_DESC
        {
            public uint FillMode;
            public uint CullMode;
            public int FrontCounterClockwise;
            public int DepthBias;
            public float DepthBiasClamp;
            public float SlopeScaledDepthBias;
            public int DepthClipEnable;
            public int ScissorEnable;
            public int MultisampleEnable;
            public int AntialiasedLineEnable;
        }

        // structs
        [StructLayout(LayoutKind.Sequential)]
        public struct D3D11_BUFFER_DESC
        {
            public uint ByteWidth;
            public D3D11_USAGE Usage;
            public uint BindFlags;
            public uint CPUAccessFlags;
            public uint MiscFlags;
            public uint StructureByteStride;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct D3D11_SUBRESOURCE_DATA
        {
            public IntPtr pSysMem;
            public uint SysMemPitch;
            public uint SysMemSlicePitch;
        }
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
        private delegate int CreateRasterizerStateDelegate(IntPtr pDevice, ref D3D11_RASTERIZER_DESC pDesc, out IntPtr ppState);
        public static int CreateRasterizerState(IntPtr pDevice, ref D3D11_RASTERIZER_DESC desc, out IntPtr state)
        {
            var del = GetComMethod<CreateRasterizerStateDelegate>(pDevice, VT_CreateRasterizerState);
            return del(pDevice, ref desc, out state);
        }

        public static void RSSetState(IntPtr pContext, IntPtr pState)
        {
            // ID3D11DeviceContext::RSSetState (43)
            var vtable = Marshal.ReadIntPtr(pContext);
            var func = Marshal.ReadIntPtr(vtable, 43 * IntPtr.Size);
            var del = Marshal.GetDelegateForFunctionPointer<RSSetStateDelegate>(func);
            del(pContext, pState);
        }
        private delegate void RSSetStateDelegate(IntPtr pContext, IntPtr pRasterizerState);

        public static void VSSetConstantBuffers(IntPtr pContext, uint startSlot, IntPtr pBuffer)
        {
            // ID3D11DeviceContext::VSSetConstantBuffers (7)
            var vtable = Marshal.ReadIntPtr(pContext);
            var func = Marshal.ReadIntPtr(vtable, 7 * IntPtr.Size);
            var del = Marshal.GetDelegateForFunctionPointer<VSSetConstantBuffersDelegate>(func);
            del(pContext, startSlot, 1, ref pBuffer);
        }
        private delegate void VSSetConstantBuffersDelegate(IntPtr pContext, uint StartSlot, uint NumBuffers, ref IntPtr ppConstantBuffers);
        private static TDelegate GetComMethod<TDelegate>(IntPtr comObject, int vtableIndex) where TDelegate : Delegate
        {
            var vtable = Marshal.ReadIntPtr(comObject);
            var fn = Marshal.ReadIntPtr(vtable, vtableIndex * IntPtr.Size);
            return Marshal.GetDelegateForFunctionPointer<TDelegate>(fn);
        }
        public static void IASetVertexBuffers(IntPtr pContext, uint startSlot, IntPtr pBuffer, uint stride, uint offset)
        {
            // ID3D11DeviceContext::IASetVertexBuffers (18)
            var vtable = Marshal.ReadIntPtr(pContext);
            var func = Marshal.ReadIntPtr(vtable, 18 * IntPtr.Size);
            var del = Marshal.GetDelegateForFunctionPointer<IASetVertexBuffersDelegate>(func);
            del(pContext, startSlot, 1, ref pBuffer, ref stride, ref offset);
        }
        private delegate void IASetVertexBuffersDelegate(IntPtr pContext, uint StartSlot, uint NumBuffers, ref IntPtr ppVertexBuffers, ref uint pStrides, ref uint pOffsets);

        public static void IASetIndexBuffer(IntPtr pContext, IntPtr pBuffer, DXGI_FORMAT format, uint offset)
        {
            // ID3D11DeviceContext::IASetIndexBuffer (19)
            var vtable = Marshal.ReadIntPtr(pContext);
            var func = Marshal.ReadIntPtr(vtable, 19 * IntPtr.Size);
            var del = Marshal.GetDelegateForFunctionPointer<IASetIndexBufferDelegate>(func);
            del(pContext, pBuffer, format, offset);
        }
        private delegate void IASetIndexBufferDelegate(IntPtr pContext, IntPtr pIndexBuffer, DXGI_FORMAT Format, uint Offset);

        public static void IASetInputLayout(IntPtr pContext, IntPtr pInputLayout)
        {
            // ID3D11DeviceContext::IASetInputLayout (17)
            var vtable = Marshal.ReadIntPtr(pContext);
            var func = Marshal.ReadIntPtr(vtable, 17 * IntPtr.Size);
            var del = Marshal.GetDelegateForFunctionPointer<IASetInputLayoutDelegate>(func);
            del(pContext, pInputLayout);
        }
        private delegate void IASetInputLayoutDelegate(IntPtr pContext, IntPtr pInputLayout);

        public static void IASetPrimitiveTopology(IntPtr pContext, uint topology)
        {
            // ID3D11DeviceContext::IASetPrimitiveTopology (24), 4 = D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST
            var vtable = Marshal.ReadIntPtr(pContext);
            var func = Marshal.ReadIntPtr(vtable, 24 * IntPtr.Size);
            var del = Marshal.GetDelegateForFunctionPointer<IASetPrimitiveTopologyDelegate>(func);
            del(pContext, topology);
        }
        private delegate void IASetPrimitiveTopologyDelegate(IntPtr pContext, uint Topology);

        public static void VSSetShader(IntPtr pContext, IntPtr pShader)
        {
            // ID3D11DeviceContext::VSSetShader (11)
            var vtable = Marshal.ReadIntPtr(pContext);
            var func = Marshal.ReadIntPtr(vtable, 11 * IntPtr.Size);
            var del = Marshal.GetDelegateForFunctionPointer<VSSetShaderDelegate>(func);
            del(pContext, pShader, IntPtr.Zero, 0);
        }
        private delegate void VSSetShaderDelegate(IntPtr pContext, IntPtr pVertexShader, IntPtr ppClassInstances, uint NumClassInstances);

        public static void PSSetShader(IntPtr pContext, IntPtr pShader)
        {
            // ID3D11DeviceContext::PSSetShader (9)
            var vtable = Marshal.ReadIntPtr(pContext);
            var func = Marshal.ReadIntPtr(vtable, 9 * IntPtr.Size);
            var del = Marshal.GetDelegateForFunctionPointer<PSSetShaderDelegate>(func);
            del(pContext, pShader, IntPtr.Zero, 0);
        }
        private delegate void PSSetShaderDelegate(IntPtr pContext, IntPtr pPixelShader, IntPtr ppClassInstances, uint NumClassInstances);

        public static void Draw(IntPtr pContext, uint vertexCount, uint startVertex)
        {
            // ID3D11DeviceContext::Draw (13)
            var vtable = Marshal.ReadIntPtr(pContext);
            var func = Marshal.ReadIntPtr(vtable, 13 * IntPtr.Size);
            var del = Marshal.GetDelegateForFunctionPointer<DrawDelegate>(func);
            del(pContext, vertexCount, startVertex);
        }
        private delegate void DrawDelegate(IntPtr pContext, uint VertexCount, uint StartVertexLocation);

        public static void DrawIndexed(IntPtr pContext, uint indexCount, uint startIndex, int baseVertex)
        {
            // ID3D11DeviceContext::DrawIndexed (12)
            var vtable = Marshal.ReadIntPtr(pContext);
            var func = Marshal.ReadIntPtr(vtable, 12 * IntPtr.Size);
            var del = Marshal.GetDelegateForFunctionPointer<DrawIndexedDelegate>(func);
            del(pContext, indexCount, startIndex, baseVertex);
        }
        private delegate void DrawIndexedDelegate(IntPtr pContext, uint IndexCount, uint StartIndexLocation, int BaseVertexLocation);

        private delegate int CreateInputLayoutDelegate(IntPtr pDevice, IntPtr pInputElementDescs, uint numElements, IntPtr shaderBytecodeWithInputSignature, nuint bytecodeLength, out IntPtr ppInputLayout);
        public static int CreateInputLayout(IntPtr pDevice, IntPtr descsArray, uint count, IntPtr vsBytecode, nuint vsLength, out IntPtr inputLayout)
        {
            var del = GetComMethod<CreateInputLayoutDelegate>(pDevice, VT_CreateInputLayout);
            return del(pDevice, descsArray, count, vsBytecode, vsLength, out inputLayout);
        }
        private delegate int CreateBufferDelegate(IntPtr pDevice, ref D3D11_BUFFER_DESC pDesc, ref D3D11_SUBRESOURCE_DATA pInitialData, out IntPtr ppBuffer);
        public static int CreateBuffer(IntPtr pDevice, ref D3D11_BUFFER_DESC desc, ref D3D11_SUBRESOURCE_DATA initData, out IntPtr ppBuffer)
        {
            var del = GetComMethod<CreateBufferDelegate>(pDevice, VT_CreateBuffer);
            return del(pDevice, ref desc, ref initData, out ppBuffer);
        }

        private delegate int CreateVertexShaderDelegate(IntPtr pDevice, IntPtr pBytecode, nuint bytecodeLength, IntPtr classLinkage, out IntPtr ppShader);
        public static int CreateVertexShader(IntPtr pDevice, IntPtr bytecode, nuint length, out IntPtr shader)
        {
            var del = GetComMethod<CreateVertexShaderDelegate>(pDevice, VT_CreateVertexShader);
            return del(pDevice, bytecode, length, IntPtr.Zero, out shader);
        }

        private delegate int CreatePixelShaderDelegate(IntPtr pDevice, IntPtr pBytecode, nuint bytecodeLength, IntPtr classLinkage, out IntPtr ppShader);
        public static int CreatePixelShader(IntPtr pDevice, IntPtr bytecode, nuint length, out IntPtr shader)
        {
            var del = GetComMethod<CreatePixelShaderDelegate>(pDevice, VT_CreatePixelShader);
            return del(pDevice, bytecode, length, IntPtr.Zero, out shader);
        }

        public static int Map(IntPtr pContext, IntPtr pResource, uint Subresource, D3D11_MAP MapType, uint MapFlags, out D3D11_MAPPED_SUBRESOURCE pMappedResource)
        {
            // ID3D11DeviceContext::Map (14)
            var vtable = Marshal.ReadIntPtr(pContext);
            var func = Marshal.ReadIntPtr(vtable, 14 * IntPtr.Size);

            var del = Marshal.GetDelegateForFunctionPointer<MapDelegate>(func);
            return del(pContext, pResource, Subresource, MapType, MapFlags, out pMappedResource);
        }
        private delegate int MapDelegate(IntPtr pContext, IntPtr pResource, uint Subresource, D3D11_MAP MapType, uint MapFlags, out D3D11_MAPPED_SUBRESOURCE pMappedResource);

        public static void Unmap(IntPtr pContext, IntPtr pResource, uint Subresource)
        {
            // ID3D11DeviceContext::Unmap (15)
            var vtable = Marshal.ReadIntPtr(pContext);
            var func = Marshal.ReadIntPtr(vtable, 15 * IntPtr.Size);

            var del = Marshal.GetDelegateForFunctionPointer<UnmapDelegate>(func);
            del(pContext, pResource, Subresource);
        }
        private delegate void UnmapDelegate(IntPtr pContext, IntPtr pResource, uint Subresource);

        public static void CopyResource(IntPtr pContext, IntPtr pDstResource, IntPtr pSrcResource)
        {
            // ID3D11DeviceContext::CopyResource (47)
            var vtable = Marshal.ReadIntPtr(pContext);
            var func = Marshal.ReadIntPtr(vtable, 47 * IntPtr.Size);

            var del = Marshal.GetDelegateForFunctionPointer<CopyResourceDelegate>(func);
            del(pContext, pDstResource, pSrcResource);
        }
        private delegate void CopyResourceDelegate(IntPtr pContext, IntPtr pDstResource, IntPtr pSrcResource);


        public static int ResizeSwapChainBuffers(IntPtr pSwapChain, uint BufferCount, uint Width, uint Height, DXGI_FORMAT NewFormat, uint Flags)
        {
            // IDXGISwapChain::ResizeBuffers (13)
            var vtable = Marshal.ReadIntPtr(pSwapChain);
            var func = Marshal.ReadIntPtr(vtable, 13 * IntPtr.Size);

            var del = Marshal.GetDelegateForFunctionPointer<ResizeBuffersDelegate>(func);
            return del(pSwapChain, BufferCount, Width, Height, NewFormat, Flags);
        }
        private delegate int ResizeBuffersDelegate(IntPtr pSwapChain, uint BufferCount, uint Width, uint Height, DXGI_FORMAT NewFormat, uint Flags);

        public static void OMSetRenderTargets(IntPtr pContext, uint NumViews, IntPtr pRenderTargetView, IntPtr pDepthStencilView)
        {
            // ID3D11DeviceContext::OMSetRenderTargets (33)
            var vtable = Marshal.ReadIntPtr(pContext);
            var omSetRenderTargets = Marshal.ReadIntPtr(vtable, 33 * IntPtr.Size);

            var del = Marshal.GetDelegateForFunctionPointer<OMSetRenderTargetsDelegate>(omSetRenderTargets);
            del(pContext, NumViews, ref pRenderTargetView, pDepthStencilView);
        }
        private delegate void OMSetRenderTargetsDelegate(IntPtr pContext, uint NumViews, ref IntPtr pRenderTargetView, IntPtr pDepthStencilView);

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

        private delegate int CreateSwapChainDelegate(IntPtr pFactory, IntPtr pDevice, ref DXGI_SWAP_CHAIN_DESC pDesc, out IntPtr ppSwapChain);
        public static int CreateSwapChain(IntPtr pFactory, IntPtr pDevice, ref DXGI_SWAP_CHAIN_DESC pDesc, out IntPtr ppSwapChain)
        {
            var del = GetComMethod<CreateSwapChainDelegate>(pFactory, VT_Factory_CreateSwapChain); // index 10 on IDXGIFactory
            return del(pFactory, pDevice, ref pDesc, out ppSwapChain);
        }

        private delegate int CreateRenderTargetViewDelegate(IntPtr pDevice, IntPtr pResource, IntPtr pDesc, out IntPtr ppRTView);
        public static int CreateRenderTargetView(IntPtr pDevice, IntPtr pResource, IntPtr pDesc, out IntPtr ppRTView)
        {
            var del = GetComMethod<CreateRenderTargetViewDelegate>(pDevice, VT_CreateRenderTargetView); // index 9
            return del(pDevice, pResource, pDesc, out ppRTView);
        }

        private delegate int CreateTexture2DDelegate(IntPtr pDevice, ref D3D11Interop.D3D11_TEXTURE2D_DESC pDesc, IntPtr pInitialData, out IntPtr ppTexture2D);
        public static int CreateTexture2D(IntPtr pDevice, ref D3D11Interop.D3D11_TEXTURE2D_DESC pDesc, IntPtr pInitialData, out IntPtr ppTexture2D)
        {
            var del = GetComMethod<CreateTexture2DDelegate>(pDevice, VT_CreateTexture2D); // index 5
            return del(pDevice, ref pDesc, pInitialData, out ppTexture2D);
        }

        private delegate int CreateDepthStencilViewDelegate(IntPtr pDevice, IntPtr pResource, IntPtr pDesc, out IntPtr ppDepthStencilView);
        public static int CreateDepthStencilView(IntPtr pDevice, IntPtr pResource, IntPtr pDesc, out IntPtr ppDepthStencilView)
        {
            var del = GetComMethod<CreateDepthStencilViewDelegate>(pDevice, VT_CreateDepthStencilView); // index 10
            return del(pDevice, pResource, pDesc, out ppDepthStencilView);
        }

        private static readonly Guid IID_ID3D11Texture2D = new Guid("6f15aaf2-d208-4e89-9ab4-489535d34f9c");
        private delegate int GetBufferDelegate(IntPtr pSwapChain, uint Buffer, ref Guid riid, out IntPtr ppSurface);
        public static int GetSwapChainBackBuffer(IntPtr pSwapChain, uint Buffer, out IntPtr ppSurface)
        {
            // IDXGISwapChain::GetBuffer (9 — inherited from IDXGIDeviceSubObject/IDXGIObject chain)
            Guid riid = IID_ID3D11Texture2D;
            var del = GetComMethod<GetBufferDelegate>(pSwapChain, 9);
            return del(pSwapChain, Buffer, ref riid, out ppSurface);
        }
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

        [ComImport]
        [Guid("1841e5c8-16b0-448b-b895-c6a4c0c66005")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ID3D11DeviceChild
        {
            [PreserveSig]
            void GetDevice(out IntPtr ppDevice);

            [PreserveSig]
            void GetPrivateData(ref Guid guid, ref uint pDataSize, IntPtr pData);

            [PreserveSig]
            void SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);

            [PreserveSig]
            void SetPrivateDataInterface(ref Guid guid, [MarshalAs(UnmanagedType.IUnknown)] object pData);
        }
    }
}
