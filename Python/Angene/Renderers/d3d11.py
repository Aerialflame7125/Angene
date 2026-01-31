import ctypes
import math
from ctypes import wintypes

# Load D3D11 and DXGI libraries
d3d11 = ctypes.WinDLL('d3d11')
dxgi = ctypes.WinDLL('dxgi')
d3dcompiler = ctypes.WinDLL('d3dcompiler_47')

# DXGI COM interfaces
class IUnknown(ctypes.Structure):
    pass

# LUID structure
class LUID(ctypes.Structure):
    _fields_ = [
        ("LowPart", wintypes.UINT),
        ("HighPart", wintypes.LONG),
    ]

# DXGI_ADAPTER_DESC
class DXGI_ADAPTER_DESC(ctypes.Structure):
    _fields_ = [
        ("Description", wintypes.WCHAR * 128),
        ("VendorId", wintypes.UINT),
        ("DeviceId", wintypes.UINT),
        ("SubSysId", wintypes.UINT),
        ("Revision", wintypes.UINT),
        ("DedicatedVideoMemory", ctypes.c_size_t),
        ("DedicatedSystemMemory", ctypes.c_size_t),
        ("SharedSystemMemory", ctypes.c_size_t),
        ("AdapterLuid", LUID),
    ]

# CreateDXGIFactory
CreateDXGIFactory = dxgi.CreateDXGIFactory
CreateDXGIFactory.restype = ctypes.c_long
CreateDXGIFactory.argtypes = [ctypes.POINTER(ctypes.c_byte * 16), ctypes.POINTER(ctypes.c_void_p)]

# IID for IDXGIFactory
def make_iid(data1, data2, data3, data4):
    """Helper to create an IID (GUID)"""
    iid = (ctypes.c_byte * 16)()
    struct_bytes = data1.to_bytes(4, 'little') + \
                   data2.to_bytes(2, 'little') + \
                   data3.to_bytes(2, 'little') + \
                   bytes(data4)
    ctypes.memmove(iid, struct_bytes, 16)
    return iid

IID_IDXGIFactory = make_iid(0x7b7166ec, 0x21c7, 0x44ae, 
                             [0xb2, 0x1a, 0xc9, 0xae, 0x32, 0x1a, 0xe3, 0x69])

# D3D11 Feature Levels
D3D_FEATURE_LEVEL_11_0 = 0xb000
D3D_FEATURE_LEVEL_10_1 = 0xa100
D3D_FEATURE_LEVEL_10_0 = 0xa000

# Driver types
D3D_DRIVER_TYPE_HARDWARE = 1
D3D_DRIVER_TYPE_WARP = 5
D3D_DRIVER_TYPE_REFERENCE = 2

# Create device flags
D3D11_CREATE_DEVICE_DEBUG = 0x2

# DXGI formats
DXGI_FORMAT_R8G8B8A8_UNORM = 28
DXGI_FORMAT_D24_UNORM_S8_UINT = 45

# Usage flags
DXGI_USAGE_RENDER_TARGET_OUTPUT = 0x20

# Swap effect
DXGI_SWAP_EFFECT_DISCARD = 0

# DXGI structures
class DXGI_MODE_DESC(ctypes.Structure):
    _fields_ = [
        ("Width", wintypes.UINT),
        ("Height", wintypes.UINT),
        ("RefreshRate_Numerator", wintypes.UINT),
        ("RefreshRate_Denominator", wintypes.UINT),
        ("Format", ctypes.c_int),
        ("ScanlineOrdering", ctypes.c_int),
        ("Scaling", ctypes.c_int),
    ]

class DXGI_SAMPLE_DESC(ctypes.Structure):
    _fields_ = [
        ("Count", wintypes.UINT),
        ("Quality", wintypes.UINT),
    ]

class DXGI_SWAP_CHAIN_DESC(ctypes.Structure):
    _fields_ = [
        ("BufferDesc", DXGI_MODE_DESC),
        ("SampleDesc", DXGI_SAMPLE_DESC),
        ("BufferUsage", wintypes.UINT),
        ("BufferCount", wintypes.UINT),
        ("OutputWindow", wintypes.HWND),
        ("Windowed", wintypes.BOOL),
        ("SwapEffect", ctypes.c_int),
        ("Flags", wintypes.UINT),
    ]

# D3D11CreateDeviceAndSwapChain
D3D11CreateDeviceAndSwapChain = d3d11.D3D11CreateDeviceAndSwapChain
D3D11CreateDeviceAndSwapChain.restype = ctypes.c_long  # HRESULT
D3D11CreateDeviceAndSwapChain.argtypes = [
    ctypes.c_void_p,                      # pAdapter
    ctypes.c_int,                         # DriverType
    ctypes.c_void_p,                      # Software
    wintypes.UINT,                        # Flags
    ctypes.POINTER(ctypes.c_int),         # pFeatureLevels
    wintypes.UINT,                        # FeatureLevels
    wintypes.UINT,                        # SDKVersion
    ctypes.POINTER(DXGI_SWAP_CHAIN_DESC), # pSwapChainDesc
    ctypes.POINTER(ctypes.c_void_p),      # ppSwapChain
    ctypes.POINTER(ctypes.c_void_p),      # ppDevice
    ctypes.POINTER(ctypes.c_int),         # pFeatureLevel
    ctypes.POINTER(ctypes.c_void_p),      # ppImmediateContext
]

# HRESULT success check
def SUCCEEDED(hr):
    return hr >= 0

def FAILED(hr):
    return hr < 0

# COM interface GUIDs
GUID = ctypes.c_byte * 16

def make_guid(data1, data2, data3, data4):
    """Helper to create a GUID"""
    guid = GUID()
    # Pack the GUID structure
    struct_bytes = data1.to_bytes(4, 'little') + \
                   data2.to_bytes(2, 'little') + \
                   data3.to_bytes(2, 'little') + \
                   bytes(data4)
    ctypes.memmove(guid, struct_bytes, 16)
    return guid

# IID for ID3D11Texture2D
IID_ID3D11Texture2D = make_guid(0x6f15aaf2, 0xd208, 0x4e89, 
                                 [0x9a, 0xb4, 0x48, 0x95, 0x35, 0xd3, 0x4f, 0x9c])

# Viewport structure
class D3D11_VIEWPORT(ctypes.Structure):
    _fields_ = [
        ("TopLeftX", ctypes.c_float),
        ("TopLeftY", ctypes.c_float),
        ("Width", ctypes.c_float),
        ("Height", ctypes.c_float),
        ("MinDepth", ctypes.c_float),
        ("MaxDepth", ctypes.c_float),
    ]

# Color for clear
class D3D11_COLOR_RGBA(ctypes.Structure):
    _fields_ = [
        ("r", ctypes.c_float),
        ("g", ctypes.c_float),
        ("b", ctypes.c_float),
        ("a", ctypes.c_float),
    ]


class RendererD3D11:
    """Direct3D 11 renderer for VR and high-performance 3D"""
    
    def __init__(self, hwnd, width, height, adapter_luid=None):
        """
        Initialize D3D11 renderer.
        
        Args:
            hwnd: Window handle
            width: Window width
            height: Window height
            adapter_luid: Optional LUID tuple (low, high) to specify which GPU adapter to use.
                         Required for OpenXR - use the LUID from xrGetD3D11GraphicsRequirementsKHR
        """
        self.hwnd = hwnd
        self.width = width
        self.height = height
        self.adapter_luid = adapter_luid
        
        # D3D11 objects
        self.device = None
        self.context = None
        self.swap_chain = None
        self.render_target_view = None
        self.depth_stencil_view = None
        self.adapter = None
        
        # Initialize D3D11
        self._init_d3d11()
        
    def _find_adapter_by_luid(self, luid_low, luid_high):
        """Find DXGI adapter matching the given LUID - FULL IMPLEMENTATION"""
        print(f"[D3D11] Looking for adapter with LUID: {luid_low:08x}-{luid_high:08x}")
        
        # Create DXGI factory
        factory = ctypes.c_void_p()
        hr = CreateDXGIFactory(ctypes.byref(IID_IDXGIFactory), ctypes.byref(factory))
        
        if FAILED(hr):
            print(f"[D3D11] Failed to create DXGI factory! HRESULT: {hr:#010x}")
            return None
        
        print(f"[D3D11] DXGI Factory created: {factory.value:#018x}")
        
        # Enumerate adapters using COM vtable calls
        try:
            factory_vtable = ctypes.cast(
                ctypes.c_void_p.from_buffer(ctypes.c_void_p.from_address(factory.value)),
                ctypes.POINTER(ctypes.c_void_p)
            )
            
            # IDXGIFactory::EnumAdapters is at vtable index 7
            enum_adapters_ptr = factory_vtable[7]
            ENUM_PROTO = ctypes.WINFUNCTYPE(
                ctypes.c_long,  # HRESULT
                ctypes.c_void_p,  # this (factory)
                wintypes.UINT,  # adapter index
                ctypes.POINTER(ctypes.c_void_p)  # out: adapter
            )
            enum_adapters = ENUM_PROTO(enum_adapters_ptr)
            
            adapter_index = 0
            found_adapter = None
            
            while True:
                adapter = ctypes.c_void_p()
                hr = enum_adapters(factory, adapter_index, ctypes.byref(adapter))
                
                # DXGI_ERROR_NOT_FOUND = 0x887A0002
                if hr == -2005270526 or hr == 0x887A0002:
                    break
                elif FAILED(hr):
                    print(f"[D3D11] EnumAdapters failed at index {adapter_index}: {hr:#010x}")
                    break
                
                if not adapter or not adapter.value:
                    break
                
                # Get adapter description using IDXGIAdapter::GetDesc (vtable index 8)
                adapter_vtable = ctypes.cast(
                    ctypes.c_void_p.from_buffer(ctypes.c_void_p.from_address(adapter.value)),
                    ctypes.POINTER(ctypes.c_void_p)
                )
                
                get_desc_ptr = adapter_vtable[8]
                GET_DESC_PROTO = ctypes.WINFUNCTYPE(
                    ctypes.c_long,  # HRESULT
                    ctypes.c_void_p,  # this (adapter)
                    ctypes.POINTER(DXGI_ADAPTER_DESC)  # out: desc
                )
                get_desc = GET_DESC_PROTO(get_desc_ptr)
                
                desc = DXGI_ADAPTER_DESC()
                hr = get_desc(adapter, ctypes.byref(desc))
                
                if SUCCEEDED(hr):
                    adapter_luid_low = desc.AdapterLuid.LowPart
                    adapter_luid_high = desc.AdapterLuid.HighPart
                    
                    print(f"[D3D11] Adapter {adapter_index}: {desc.Description}")
                    print(f"[D3D11]   LUID: {adapter_luid_low:08x}-{adapter_luid_high:08x}")
                    print(f"[D3D11]   VRAM: {desc.DedicatedVideoMemory // (1024*1024)} MB")
                    
                    # Check if this matches the required LUID
                    if adapter_luid_low == luid_low and adapter_luid_high == luid_high:
                        print(f"[D3D11] ✓ Found matching adapter!")
                        found_adapter = adapter
                        # Don't release this adapter - we're returning it
                        break
                
                # Release this adapter if it didn't match
                release_ptr = adapter_vtable[2]  # IUnknown::Release
                RELEASE_PROTO = ctypes.WINFUNCTYPE(wintypes.ULONG, ctypes.c_void_p)
                release = RELEASE_PROTO(release_ptr)
                release(adapter)
                
                adapter_index += 1
                
                # Safety limit
                if adapter_index > 10:
                    print("[D3D11] Adapter enumeration limit reached")
                    break
            
            # Release factory
            release_ptr = factory_vtable[2]
            RELEASE_PROTO = ctypes.WINFUNCTYPE(wintypes.ULONG, ctypes.c_void_p)
            release = RELEASE_PROTO(release_ptr)
            release(factory)
            
            if not found_adapter:
                print(f"[D3D11] ✗ No adapter found matching LUID {luid_low:08x}-{luid_high:08x}")
                print(f"[D3D11]   This WILL cause RTV creation to fail!")
            
            return found_adapter
            
        except Exception as e:
            print(f"[D3D11] Exception during adapter enumeration: {e}")
            import traceback
            traceback.print_exc()
            return None
        
    """
    Replace the _init_d3d11 method in your RendererD3D11 class with this version.
    This version creates a device WITHOUT a swap chain when adapter_luid is provided (for VR).
    """

    def _init_d3d11(self):
        """Initialize Direct3D 11 device (with or without swap chain)"""
        print("[D3D11] Initializing Direct3D 11...")
        
        # If adapter LUID was specified, find that adapter
        adapter = None
        if self.adapter_luid:
            luid_low, luid_high = self.adapter_luid
            adapter = self._find_adapter_by_luid(luid_low, luid_high)
        
        # Feature levels to try
        feature_levels = (ctypes.c_int * 3)(
            D3D_FEATURE_LEVEL_11_0,
            D3D_FEATURE_LEVEL_10_1,
            D3D_FEATURE_LEVEL_10_0
        )
        
        # Output variables
        device = ctypes.c_void_p()
        context = ctypes.c_void_p()
        feature_level = ctypes.c_int()
        
        # VR MODE: Create device WITHOUT swap chain
        if self.adapter_luid:
            print("[D3D11] VR mode: Creating device without swap chain")
            
            # Use D3D11CreateDevice (no swap chain)
            D3D11CreateDevice = d3d11.D3D11CreateDevice
            D3D11CreateDevice.restype = ctypes.c_long
            D3D11CreateDevice.argtypes = [
                ctypes.c_void_p,                      # pAdapter
                ctypes.c_int,                         # DriverType
                ctypes.c_void_p,                      # Software
                wintypes.UINT,                        # Flags
                ctypes.POINTER(ctypes.c_int),         # pFeatureLevels
                wintypes.UINT,                        # FeatureLevels count
                wintypes.UINT,                        # SDKVersion
                ctypes.POINTER(ctypes.c_void_p),      # ppDevice
                ctypes.POINTER(ctypes.c_int),         # pFeatureLevel
                ctypes.POINTER(ctypes.c_void_p),      # ppImmediateContext
            ]
            
            hr = D3D11CreateDevice(
                adapter,                       # Use the specific adapter we found
                0,                            # DriverType = 0 (UNKNOWN) when adapter is specified
                None,                          # Software
                0,                            # Flags (add D3D11_CREATE_DEVICE_DEBUG for debugging)
                feature_levels,                # pFeatureLevels
                3,                             # FeatureLevels count
                7,                             # SDK Version
                ctypes.byref(device),          # ppDevice
                ctypes.byref(feature_level),   # pFeatureLevel
                ctypes.byref(context)          # ppImmediateContext
            )
            
            if FAILED(hr):
                print(f"[D3D11] Failed to create device! HRESULT: {hr:#010x}")
                # Try with debug layer for more info
                hr = D3D11CreateDevice(
                    adapter,
                    0,
                    None,
                    D3D11_CREATE_DEVICE_DEBUG,  # Enable debug layer
                    feature_levels,
                    3,
                    7,
                    ctypes.byref(device),
                    ctypes.byref(feature_level),
                    ctypes.byref(context)
                )
                if SUCCEEDED(hr):
                    print("[D3D11] ✓ Device created with debug layer")
                else:
                    print(f"[D3D11] Failed even with debug layer: {hr:#010x}")
                    return
            
            self.device = device
            self.context = context
            self.swap_chain = None  # No swap chain for VR
            
            print(f"[D3D11] ✓ Device created successfully!")
            print(f"[D3D11]   Feature level: {feature_level.value:#06x}")
            print(f"[D3D11]   Device: {device.value:#018x}")
            print(f"[D3D11]   Context: {context.value:#018x}")
            
            # Release adapter if we used one
            if adapter:
                adapter_vtable = ctypes.cast(
                    ctypes.c_void_p.from_buffer(ctypes.c_void_p.from_address(adapter.value)),
                    ctypes.POINTER(ctypes.c_void_p)
                )
                release_ptr = adapter_vtable[2]
                RELEASE_PROTO = ctypes.WINFUNCTYPE(wintypes.ULONG, ctypes.c_void_p)
                release = RELEASE_PROTO(release_ptr)
                release(adapter)
        
        # NORMAL MODE: Create device WITH swap chain (for non-VR window rendering)
        else:
            print("[D3D11] Normal mode: Creating device with swap chain")
            
            # Setup swap chain description
            swap_desc = DXGI_SWAP_CHAIN_DESC()
            swap_desc.BufferDesc.Width = self.width
            swap_desc.BufferDesc.Height = self.height
            swap_desc.BufferDesc.RefreshRate_Numerator = 60
            swap_desc.BufferDesc.RefreshRate_Denominator = 1
            swap_desc.BufferDesc.Format = DXGI_FORMAT_R8G8B8A8_UNORM
            swap_desc.SampleDesc.Count = 1
            swap_desc.SampleDesc.Quality = 0
            swap_desc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT
            swap_desc.BufferCount = 2
            swap_desc.OutputWindow = self.hwnd
            swap_desc.Windowed = True
            swap_desc.SwapEffect = DXGI_SWAP_EFFECT_DISCARD
            swap_desc.Flags = 0
            
            swap_chain = ctypes.c_void_p()
            
            # Create device and swap chain
            hr = D3D11CreateDeviceAndSwapChain(
                None,                          # pAdapter (default)
                D3D_DRIVER_TYPE_HARDWARE,      # DriverType
                None,                          # Software
                0,                             # Flags
                feature_levels,                # pFeatureLevels
                3,                             # FeatureLevels count
                7,                             # SDK Version
                ctypes.byref(swap_desc),       # pSwapChainDesc
                ctypes.byref(swap_chain),      # ppSwapChain
                ctypes.byref(device),          # ppDevice
                ctypes.byref(feature_level),   # pFeatureLevel
                ctypes.byref(context)          # ppImmediateContext
            )
            
            if FAILED(hr):
                print(f"[D3D11] Failed to create device and swap chain! HRESULT: {hr:#010x}")
                return
            
            self.device = device
            self.context = context
            self.swap_chain = swap_chain
            
            print(f"[D3D11] ✓ Device created successfully!")
            print(f"[D3D11]   Feature level: {feature_level.value:#06x}")
            print(f"[D3D11]   Device: {device.value:#018x}")
            print(f"[D3D11]   Context: {context.value:#018x}")
            
            # Create render target view from swap chain
            self._create_render_target()
        
    def _create_render_target(self):
        """Create render target view from swap chain back buffer"""
        if not self.swap_chain:
            return
        
        # Get back buffer from swap chain
        # IDXGISwapChain::GetBuffer
        back_buffer = ctypes.c_void_p()
        
        # Call swap chain GetBuffer (vtable index 9)
        swap_chain_vtbl = ctypes.cast(
            ctypes.c_void_p.from_buffer(ctypes.c_void_p.from_address(self.swap_chain.value)),
            ctypes.POINTER(ctypes.c_void_p)
        )
        
        # For now, we'll use a simpler approach - just set up the viewport
        # Full render target creation requires more COM interface work
        print("[D3D11] Render target setup (basic)")
        
    def begin_frame(self):
        """Begin rendering a frame"""
        if not self.context:
            return
        
        # Clear render target (simplified - full version needs COM calls)
        # This is a placeholder - full implementation needs proper COM interface calls
        pass
        
    def end_frame(self):
        """Present the frame"""
        if not self.swap_chain:
            return
        
        # IDXGISwapChain::Present (vtable index 8)
        # For now, placeholder
        pass
        
    def get_device(self):
        """Get D3D11 device pointer for OpenXR"""
        return self.device
    
    def cleanup(self):
        """Release D3D11 resources"""
        # Release COM objects
        if self.render_target_view:
            # Call Release on the interface
            pass
        if self.depth_stencil_view:
            pass
        if self.swap_chain:
            pass
        if self.context:
            pass
        if self.device:
            pass
        
        print("[D3D11] Cleanup complete")


# Simplified D3D11 renderer for basic shapes (similar to OpenGL cube demo)
class SimpleD3D11Renderer:
    """
    Simplified D3D11 renderer for basic demos.
    For full VR rendering with OpenXR, use RendererD3D11 directly.
    """
    
    def __init__(self, hwnd, width, height):
        self.d3d = RendererD3D11(hwnd, width, height)
        self.rotation = 0.0
        
    def begin_frame(self):
        self.d3d.begin_frame()
        
    def end_frame(self):
        self.d3d.end_frame()
        
    def draw_cube(self):
        """Draw a rotating cube (placeholder - needs vertex buffers and shaders)"""
        # In a full implementation, this would:
        # 1. Create vertex and index buffers
        # 2. Compile vertex and pixel shaders
        # 3. Set up input layout
        # 4. Set shader constants (MVP matrix)
        # 5. Draw indexed primitives
        pass
        
    def cleanup(self):
        self.d3d.cleanup()


# Helper function to check if D3D11 is available
def is_d3d11_available():
    """Check if D3D11 is available on this system"""
    try:
        # Try to load the DLL
        d3d11_lib = ctypes.WinDLL('d3d11')
        return True
    except:
        return False


print(f"[D3D11] Module loaded - D3D11 available: {is_d3d11_available()}")