using System.Drawing;
using System.Runtime.InteropServices;
using static Angene.Windows.Dxgi.DxgiEnums;
using static Angene.Windows.Dxgi.DxgiStructs;
using static Angene.Windows.WindowManagement;
using DXGI_DEBUG_ID = System.Guid;

namespace Angene.Windows.Dxgi
{
    public class DxgiStructs
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LUID
        {
            public uint LowPart;
            public int HighPart;
        }

        [StructLayout(LayoutKind.Explicit, Size = 8)]
        public struct LARGE_INTEGER
        {
            [FieldOffset(0)] public long QuadPart;
            [FieldOffset(0)] public uint LowPart;
            [FieldOffset(4)] public int HighPart;
        }

        // now actual dxgi things
        [StructLayout(LayoutKind.Sequential)]
        public struct D3DCOLORVALUE
        {
            public float r;
            public float g;
            public float b;
            public float a;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct DXGI_ADAPTER_DESC
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string Description;
            public uint VendorId;
            public uint DeviceId;
            public uint SubSysId;
            public uint Revision;
            public nuint DedicatedVideoMemory;
            public nuint DedicatedSystemMemory;
            public nuint SharedSystemMemory;
            public LUID AdapterLuid;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct DXGI_ADAPTER_DESC1
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string Description;
            public uint VendorId;
            public uint DeviceId;
            public uint SubSysId;
            public uint Revision;
            public nuint DedicatedVideoMemory;
            public nuint DedicatedSystemMemory;
            public nuint SharedSystemMemory;
            public LUID AdapterLuid;
            public uint Flags;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct DXGI_ADAPTER_DESC2
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string Description;
            public uint VendorId;
            public uint DeviceId;
            public uint SubSysId;
            public uint Revision;
            public nuint DedicatedVideoMemory;
            public nuint DedicatedSystemMemory;
            public nuint SharedSystemMemory;
            public LUID AdapterLuid;
            public uint Flags;
            public DXGI_GRAPHICS_PREEMPTION_GRANULARITY GraphicsPreemptionGramularity;
            public DXGI_COMPUTE_PREEMPTION_GRANULARITY ComputePreemptionGramularity;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct DXGI_ADAPTER_DESC3
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string Description;
            public uint VendorId;
            public uint DeviceId;
            public uint SubSysId;
            public uint Revision;
            public nuint DedicatedVideoMemory;
            public nuint DedicatedSystemMemory;
            public nuint SharedSystemMemory;
            public LUID AdapterLuid;
            public DXGI_ADAPTER_FLAG3 Flags;
            public DXGI_GRAPHICS_PREEMPTION_GRANULARITY GraphicsPreemptionGramularity;
            public DXGI_COMPUTE_PREEMPTION_GRANULARITY ComputePreemptionGramularity;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_DECODE_SWAP_CHAIN_DESC
        {
            public uint Flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_DISPLAY_COLOR_SPACE
        {
            public unsafe fixed float PrimaryCoordinates[16];
            public unsafe fixed float WhitePoints[16]; // or something like that
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_FRAME_STATISTICS
        {
            public uint PresentCount;
            public uint PresentRefreshCount;
            public uint SyncRefreshCount;
            public LARGE_INTEGER SyncQPCTime;
            public LARGE_INTEGER SyncGPUTime;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_FRAME_STATISTICS_MEDIA
        {
            public uint PresentCount;
            public uint PresentRefreshCount;
            public uint SyncRefreshCount;
            public LARGE_INTEGER SyncQPCTime;
            public LARGE_INTEGER SyncGPUTime;
            public DXGI_FRAME_PRESENTATION_MODE CompositionMode;
            public uint ApprovedPresentDuration;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_GAMMA_CONTROL
        {
            public DXGI_RGB Scale;
            public DXGI_RGB Offset;
            public unsafe fixed float GammaCurve[3075];
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_GAMMA_CONTROL_CAPABILITIES
        {
            [MarshalAs(UnmanagedType.Bool)]
            public bool ScaleAndOffsetSupported;
            public float MaxConvertedValue;
            public float MinConvertedValue;
            public uint NumGammaControlPoints;
            public unsafe fixed float ControlPointPositions[1025];
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_HDE_METADATA_HDR10
        {
            public unsafe fixed UInt16 RedPrimary[2];
            public unsafe fixed UInt16 GreenPrimary[2];
            public unsafe fixed UInt16 BluePrimary[2];
            public unsafe fixed UInt16 WhitePoint[2];
            public uint MaxMasteringLuminance;
            public uint MinMasteringLuminance;
            public UInt16 MaxContentLightLevel;
            public UInt16 MaxFrameAverageLightLevel;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_INFO_QUEUE_FILTER
        {
            public DXGI_INFO_QUEUE_FILTER_DESC AllowList;
            public DXGI_INFO_QUEUE_FILTER_DESC DenyList;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_INFO_QUEUE_FILTER_DESC
        {
            public uint NumCategories;
            public IntPtr pCategoryList; // DXGI_INFO_QUEUE_MESSAGE_CATEGORY*
            public uint NumSeverities;
            public IntPtr pSeverityList; // DXGI_INFO_QUEUE_MESSAGE_SEVERITY*
            public uint NumIDs;
            public IntPtr pIDList; // DXGI_INFO_QUEUE_MESSAGE_ID*
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_INFO_QUEUE_MESSAGE
        {
            public DXGI_DEBUG_ID Producer;
            public DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category;
            public DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity;
            public uint ID; // DXGI_INFO_QUEUE_MESSAGE_ID
            public IntPtr pDescription; // const char*
            public nuint DescriptionByteLength; // Was size_t
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_JPEG_AC_HUFFMAN_TABLE
        {
            public unsafe fixed byte CodeCounts[16];
            public unsafe fixed byte CodeValues[162];
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_JPEG_DC_HUFFMAN_TABLE
        {
            public unsafe fixed byte CodeCounts[12];
            public unsafe fixed byte CodeValues[12];
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_JPEG_QUANTIZATION_TABLE
        {
            public unsafe fixed byte Elements[64];
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_MATRIX_3X2_F
        {
            public float _11;
            public float _12;
            public float _21;
            public float _22;
            public float _31;
            public float _32;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_MAPPED_RECT
        {
            public int Pitch;
            public IntPtr pBits;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_MODE_DESC
        {
            public uint Width;
            public uint Height;
            public DXGI_RATIONAL RefreshRate;
            public DXGI_FORMAT Format;
            public DXGI_MODE_SCANLINE_ORDER ScanlineOrdering;
            public DXGI_MODE_SCALING Scaling;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_MODE_DESC1
        {
            public uint Width;
            public uint Height;
            public DXGI_RATIONAL RefreshRate;
            public DXGI_FORMAT Format;
            public DXGI_MODE_SCANLINE_ORDER ScanlineOrdering;
            public DXGI_MODE_SCALING Scaling;
            [MarshalAs(UnmanagedType.Bool)]
            public bool Stereo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_OUTPUT_DESC
        {
            public unsafe fixed char DeviceName[32];
            public RECT DesktopCoordinates;
            [MarshalAs(UnmanagedType.Bool)]
            public bool AttachedToDesktop;
            public DXGI_MODE_ROTATION Rotation;
            public IntPtr Monitor; // HMONITOR
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_OUTPUT_DESC1
        {
            public unsafe fixed char DeviceName[32];
            public RECT DesktopCoordinates;
            [MarshalAs(UnmanagedType.Bool)]
            public bool AttachedToDesktop;
            public DXGI_MODE_ROTATION Rotation;
            public IntPtr Monitor; // HMONITOR
            public uint BitsPerColor;
            public DXGI_COLOR_SPACE_TYPE ColorSpace;
            public unsafe fixed float RedPrimary[2];
            public unsafe fixed float GreenPrimary[2];
            public unsafe fixed float BluePrimary[2];
            public unsafe fixed float WhitePoint[2];
            public float MinLuminance;
            public float MaxLuminance;
            public float MaxFullFrameLuminance;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_OUTDUPL_DESC
        {
            public DXGI_MODE_DESC ModeDesc;
            public DXGI_MODE_ROTATION Rotation;
            [MarshalAs(UnmanagedType.Bool)]
            public bool DesktopImageInSystemMemory;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_OUTDUPL_FRAME_INFO
        {
            public LARGE_INTEGER LastPresentTime;
            public LARGE_INTEGER LastMouseUpdateTime;
            public uint AccumulatedFrames;
            [MarshalAs(UnmanagedType.Bool)]
            public bool RectsCoalesced;
            [MarshalAs(UnmanagedType.Bool)]
            public bool ProtectedContentMaskedOut;
            public DXGI_OUTDUPL_POINTER_POSITION PointerPosition;
            public uint TotalMetadataBufferSize;
            public uint PointerShapeBufferSize;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_OUTDUPL_MOVE_RECT
        {
            public POINT SourcePoint;
            public RECT DestinationRect;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_OUTDUPL_POINTER_POSITION
        {
            public POINT Position;
            [MarshalAs(UnmanagedType.Bool)]
            public bool Visible;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_OUTDUPL_POINTER_SHAPE_INFO
        {
            public uint Type;
            public uint Width;
            public uint Height;
            public uint Pitch;
            public POINT HotSpot;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_PRESENT_PARAMETERS
        {
            public uint DirtyRectsCount;
            public RECT pDirtyRects;
            public RECT pScrollRect;
            public POINT pScrollOffset;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_QUERY_VIDEO_MEMORY_INFO
        {
            public UInt64 Budget;
            public UInt64 CurrentUsage;
            public UInt64 AvailableForReservation;
            public UInt64 CurrentReservation;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_RATIONAL
        {
            public uint Numerator;
            public uint Denominator;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_RGB
        {
            public float Red;
            public float Green;
            public float Blue;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_RGBA
        {
            public float r;
            public float g;
            public float b;
            public float a;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_SAMPLE_DESC
        {
            public uint Count;
            public uint Quality;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_SHARED_RESOURCE
        {
            public IntPtr Handle;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_SURFACE_DESC
        {
            public uint Width;
            public uint Height;
            public DXGI_FORMAT Format;
            public DXGI_SAMPLE_DESC SampleDesc;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_SWAP_CHAIN_DESC
        {
            public DXGI_MODE_DESC BufferDesc;
            public DXGI_SAMPLE_DESC SampleDesc;
            public DXGI_USAGE BufferUsage;
            public uint BufferCount;
            public IntPtr OutputWindow;
            [MarshalAs(UnmanagedType.Bool)]
            public bool Windowed;
            public DXGI_SWAP_EFFECT SwapEffect;
            public uint Flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_SWAP_CHAIN_DESC1
        {
            public uint Width;
            public uint Height;
            public DXGI_FORMAT Format;
            [MarshalAs(UnmanagedType.Bool)]
            public bool Stereo;
            public DXGI_SAMPLE_DESC SampleDesc;
            public DXGI_USAGE BufferUsage;
            public uint BufferCount;
            public DXGI_SCALING Scaling;
            public DXGI_SWAP_EFFECT SwapEffect;
            public DXGI_ALPHA_MODE AlphaMode;
            public DXGI_SWAP_CHAIN_FLAG Flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DXGI_SWAP_CHAIN_FULLSCREEN_DESC
        {
            public DXGI_RATIONAL RefreshRate;
            public DXGI_MODE_SCANLINE_ORDER ScanlineOrdering;
            public DXGI_MODE_SCALING Scaling;
            [MarshalAs(UnmanagedType.Bool)]
            public bool Windowed;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct D3D12_FEATURE_DATA_D3D12_OPTIONS
        {
            [MarshalAs(UnmanagedType.Bool)]
            public bool DoublePrecisionFloatShaderOps;
            [MarshalAs(UnmanagedType.Bool)]
            public bool OutputMergerLogicOp;
            public D3D12_SHADER_MIN_PRECISION_SUPPORT MinPrecisionSupport;
            public D3D12_TILED_RESOURCES_TIER TiledResourcesTier;
            public D3D12_RESOURCE_BINDING_TIER ResourceBindingTier;
            [MarshalAs(UnmanagedType.Bool)]
            public bool PSSpecifiedStencilRefSupported;
            [MarshalAs(UnmanagedType.Bool)]
            public bool TypedUAVLoadAdditionalFormats;
            [MarshalAs(UnmanagedType.Bool)]
            public bool ROVsSupported;
            public D3D12_CONSERVATIVE_RASTERIZATION_TIER ConservativeRasterizationTier;
            public uint MaxGPUVirtualAddressBitsPerResource;
            [MarshalAs(UnmanagedType.Bool)]
            public bool StandardSwizzle64KBSupported;
            public D3D12_CROSS_NODE_SHARING_TIER CrossNodeSharingTier;
            [MarshalAs(UnmanagedType.Bool)]
            public bool CrossAdapterRowMajorTextureSupported;
            [MarshalAs(UnmanagedType.Bool)]
            public bool VPAndRTArrayIndexFromAnyShaderFeedingRasterizerSupportedWithoutGSEmulation;
            public D3D12_RESOURCE_HEAP_TIER ResourceHeapTier;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct _SECURITY_ATTRIBUTES
        {
            public uint nLength;
            public IntPtr lpSecurityDescriptor;
            [MarshalAs(UnmanagedType.Bool)]
            public bool bInheritHandle;

        }
    }
}
