# openxr_ctypes.py
# OpenXR with Direct3D 11 graphics binding support

import ctypes
import sys

c_char_p = ctypes.c_char_p
c_uint32 = ctypes.c_uint32
c_int32 = ctypes.c_int32
c_uint64 = ctypes.c_uint64
c_void_p = ctypes.c_void_p

# Load OpenXR loader
def try_load_loader():
    names = ["openxr_loader", "openxr_loader.dll", "OpenXRLoader.dll"]
    for n in names:
        try:
            lib = ctypes.WinDLL(f"./{n}")
            print(f"[OpenXR] Loaded loader: {n}")
            return lib
        except Exception:
            pass
    print("[OpenXR] openxr_loader DLL not found")
    return None

_loader = try_load_loader()

# Version macros
def XR_MAKE_VERSION(major, minor, patch):
    return (c_uint64(major).value << 48) | (c_uint64(minor).value << 32) | c_uint64(patch).value

XR_CURRENT_API_VERSION = XR_MAKE_VERSION(1, 0, 0)
XR_API_VERSION_1_0 = XR_MAKE_VERSION(1, 0, 0)

# Structure type constants
XR_TYPE_UNKNOWN = 0
XR_TYPE_INSTANCE_CREATE_INFO = 3
XR_TYPE_SYSTEM_GET_INFO = 4
XR_TYPE_VIEW = 7
XR_TYPE_SESSION_CREATE_INFO = 8
XR_TYPE_REFERENCE_SPACE_CREATE_INFO = 37
XR_TYPE_VIEW_LOCATE_INFO = 49
XR_TYPE_VIEW_STATE = 50
XR_TYPE_VIEW_CONFIGURATION_PROPERTIES = 46
XR_TYPE_VIEW_CONFIGURATION_VIEW = 47
XR_TYPE_FRAME_WAIT_INFO = 52
XR_TYPE_FRAME_STATE = 53
XR_TYPE_FRAME_BEGIN_INFO = 54
XR_TYPE_FRAME_END_INFO = 56
XR_TYPE_COMPOSITION_LAYER_PROJECTION = 35
XR_TYPE_COMPOSITION_LAYER_PROJECTION_VIEW = 48
XR_TYPE_SWAPCHAIN_CREATE_INFO = 9
XR_TYPE_SWAPCHAIN_IMAGE_ACQUIRE_INFO = 56
XR_TYPE_SWAPCHAIN_IMAGE_WAIT_INFO = 57
XR_TYPE_SWAPCHAIN_IMAGE_RELEASE_INFO = 58
XR_TYPE_SWAPCHAIN_IMAGE_D3D11_KHR = 1000027002
XR_TYPE_SESSION_BEGIN_INFO = 5

#DXGI format constants
DXGI_FORMAT_R8G8B8A8_UNORM_SRGB = 29
DXGI_FORMAT_B8G8R8A8_UNORM_SRGB = 91

# **CRITICAL: D3D11 extension structure types**
XR_TYPE_GRAPHICS_BINDING_D3D11_KHR = 1000027000
XR_TYPE_GRAPHICS_REQUIREMENTS_D3D11_KHR = 1000027001

# Session states
XR_SESSION_STATE_UNKNOWN = 0
XR_SESSION_STATE_IDLE = 1
XR_SESSION_STATE_READY = 2
XR_SESSION_STATE_SYNCHRONIZED = 3
XR_SESSION_STATE_VISIBLE = 4
XR_SESSION_STATE_FOCUSED = 5

# View configuration types
XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO = 2

# Environment blend modes
XR_ENVIRONMENT_BLEND_MODE_OPAQUE = 1

# Reference space types
XR_REFERENCE_SPACE_TYPE_VIEW = 1
XR_REFERENCE_SPACE_TYPE_LOCAL = 2
XR_REFERENCE_SPACE_TYPE_STAGE = 3

# LUID structure (Windows adapter identifier)
class LUID(ctypes.Structure):
    _fields_ = [
        ("LowPart", ctypes.c_uint32),
        ("HighPart", ctypes.c_int32),
    ]

# Graphics requirements structure
class XrGraphicsRequirementsD3D11KHR(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("adapterLuid", LUID),
        ("minFeatureLevel", c_int32),  # D3D_FEATURE_LEVEL
    ]

# Sizes
XR_MAX_APPLICATION_NAME_SIZE = 128
XR_MAX_ENGINE_NAME_SIZE = 128

# Result codes
XR_SUCCESS = 0

# Handle types
XrInstance = c_void_p
XrSystemId = c_uint64
XrSession = c_void_p
XrSpace = c_void_p

# Application info
class XrApplicationInfo(ctypes.Structure):
    _fields_ = [
        ("applicationName", ctypes.c_char * XR_MAX_APPLICATION_NAME_SIZE),
        ("applicationVersion", c_uint32),
        ("engineName", ctypes.c_char * XR_MAX_ENGINE_NAME_SIZE),
        ("engineVersion", c_uint32),
        ("apiVersion", c_uint64),
    ]

# Instance create info
class XrInstanceCreateInfo(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("createFlags", c_uint32),
        ("applicationInfo", XrApplicationInfo),
        ("enabledApiLayerCount", c_uint32),
        ("enabledApiLayerNames", ctypes.POINTER(c_char_p)),
        ("enabledExtensionCount", c_uint32),
        ("enabledExtensionNames", ctypes.POINTER(c_char_p)),
    ]

# System get info
class XrSystemGetInfo(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("formFactor", c_int32),
    ]

# **D3D11 Graphics Binding**
class XrGraphicsBindingD3D11KHR(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("device", c_void_p),  # ID3D11Device*
    ]

# Session create info
class XrSessionCreateInfo(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("createFlags", c_uint64),
        ("systemId", c_uint64),
    ]

# Reference space
class XrPosef(ctypes.Structure):
    _fields_ = [
        ("orientation", ctypes.c_float * 4),  # quaternion (x, y, z, w)
        ("position", ctypes.c_float * 3),     # position (x, y, z)
    ]

class XrReferenceSpaceCreateInfo(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("referenceSpaceType", c_int32),
        ("poseInReferenceSpace", XrPosef),
    ]

# Frame timing structures
class XrFrameWaitInfo(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
    ]

class XrFrameState(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("predictedDisplayTime", ctypes.c_int64),
        ("predictedDisplayPeriod", ctypes.c_int64),
        ("shouldRender", c_int32),
    ]

class XrFrameBeginInfo(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
    ]

# View structures  
class XrFovf(ctypes.Structure):
    _fields_ = [
        ("angleLeft", ctypes.c_float),
        ("angleRight", ctypes.c_float),
        ("angleUp", ctypes.c_float),
        ("angleDown", ctypes.c_float),
    ]

class XrView(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("pose", XrPosef),
        ("fov", XrFovf),
    ]

# Swapchain image (D3D11 texture)
class XrSwapchainImageD3D11KHR(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("texture", c_void_p),  # ID3D11Texture2D*
    ]

# Swapchain create info
class XrSwapchainCreateInfo(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("createFlags", c_uint64),
        ("usageFlags", c_uint64),
        ("format", ctypes.c_int64),  # DXGI_FORMAT
        ("sampleCount", c_uint32),
        ("width", c_uint32),
        ("height", c_uint32),
        ("faceCount", c_uint32),
        ("arraySize", c_uint32),
        ("mipCount", c_uint32),
    ]

# Swapchain acquire/wait/release
class XrSwapchainImageAcquireInfo(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
    ]

class XrSwapchainImageWaitInfo(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("timeout", ctypes.c_int64),
    ]

class XrSwapchainImageReleaseInfo(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
    ]

# View configuration
class XrViewConfigurationView(ctypes.Structure):
    _pack_ = 8
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("recommendedImageRectWidth", c_uint32),
        ("maxImageRectWidth", c_uint32),
        ("recommendedImageRectHeight", c_uint32),
        ("maxImageRectHeight", c_uint32),
        ("recommendedSwapchainSampleCount", c_uint32),
        ("maxSwapchainSampleCount", c_uint32),
    ]

# View locate info
class XrViewLocateInfo(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("viewConfigurationType", c_int32),
        ("displayTime", ctypes.c_int64),
        ("space", c_void_p),  # XrSpace
    ]

# View state
class XrViewState(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("viewStateFlags", c_uint64),
    ]

# Composition layer structures
class XrRect2Di(ctypes.Structure):
    _fields_ = [
        ("offsetX", c_int32),
        ("offsetY", c_int32),
        ("extentWidth", c_int32),
        ("extentHeight", c_int32),
    ]

class XrSwapchainSubImage(ctypes.Structure):
    _fields_ = [
        ("swapchain", c_void_p),  # XrSwapchain
        ("imageRect", XrRect2Di),
        ("imageArrayIndex", c_uint32),
    ]

class XrCompositionLayerProjectionView(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("pose", XrPosef),
        ("fov", XrFovf),
        ("subImage", XrSwapchainSubImage),
    ]

class XrCompositionLayerProjection(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("layerFlags", c_uint64),
        ("space", c_void_p),  # XrSpace
        ("viewCount", c_uint32),
        ("views", c_void_p),  # XrCompositionLayerProjectionView*
    ]

class XrFrameEndInfo(ctypes.Structure):
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("displayTime", ctypes.c_int64),
        ("environmentBlendMode", c_int32),
        ("layerCount", c_uint32),
        ("layers", c_void_p),  # const XrCompositionLayerBaseHeader**
    ]

class XrSessionBeginInfo(ctypes.Structure):
    _pack_ = 8
    _fields_ = [
        ("type", c_int32),
        ("next", c_void_p),
        ("primaryViewConfigurationType", c_int32),
    ]

# Swapchain handle
XrSwapchain = c_void_p

# Swapchain usage flags
XR_SWAPCHAIN_USAGE_COLOR_ATTACHMENT_BIT = 0x00000001
XR_SWAPCHAIN_USAGE_DEPTH_STENCIL_ATTACHMENT_BIT = 0x00000002

# View state flags
XR_VIEW_STATE_ORIENTATION_VALID_BIT = 0x00000001
XR_VIEW_STATE_POSITION_VALID_BIT = 0x00000002

# DXGI format
DXGI_FORMAT_R8G8B8A8_UNORM = 28
DXGI_FORMAT_B8G8R8A8_UNORM = 87


def xr_result_str(res):
    error_names = {
        0: "XR_SUCCESS",
        -1: "XR_TIMEOUT_EXPIRED",
        -2: "XR_SESSION_LOSS_PENDING",
        -3: "XR_EVENT_UNAVAILABLE",
        -4: "XR_SPACE_BOUNDS_UNAVAILABLE",
        -5: "XR_SESSION_NOT_FOCUSED",
        -6: "XR_FRAME_DISCARDED",
        -7: "XR_VALIDATION_FAILURE",
        -8: "XR_RUNTIME_FAILURE",
        -9: "XR_OUT_OF_MEMORY",
        -10: "XR_API_VERSION_UNSUPPORTED",
        -11: "XR_INITIALIZATION_FAILED",
        -12: "XR_FUNCTION_UNSUPPORTED",
        -13: "XR_FEATURE_UNSUPPORTED",
        -14: "XR_EXTENSION_NOT_PRESENT",
        -15: "XR_LIMIT_REACHED",
        -16: "XR_SIZE_INSUFFICIENT",
        -17: "XR_HANDLE_INVALID",
        -18: "XR_INSTANCE_LOST",
        -19: "XR_SESSION_RUNNING",
        -20: "XR_SESSION_NOT_RUNNING",
        -21: "XR_SESSION_LOST",
        -22: "XR_SYSTEM_INVALID",
        -23: "XR_PATH_INVALID",
        -24: "XR_PATH_COUNT_EXCEEDED",
        -25: "XR_PATH_FORMAT_INVALID",
        -26: "XR_PATH_UNSUPPORTED",
        -27: "XR_LAYER_INVALID",
        -28: "XR_LAYER_LIMIT_EXCEEDED",
        -29: "XR_SWAPCHAIN_RECT_INVALID",
        -30: "XR_SWAPCHAIN_FORMAT_UNSUPPORTED",
        -31: "XR_ACTION_TYPE_MISMATCH",
        -32: "XR_SESSION_NOT_READY",
        -33: "XR_SESSION_NOT_STOPPING",
        -34: "XR_TIME_INVALID",
        -35: "XR_REFERENCE_SPACE_UNSUPPORTED",
        -36: "XR_FILE_ACCESS_ERROR",
        -37: "XR_FILE_CONTENTS_INVALID",
        -38: "XR_FORM_FACTOR_UNSUPPORTED",
        -39: "XR_FORM_FACTOR_UNAVAILABLE",
        -40: "XR_API_LAYER_NOT_PRESENT",
        -41: "XR_CALL_ORDER_INVALID",
        -42: "XR_GRAPHICS_DEVICE_INVALID",
        -43: "XR_POSE_INVALID",
        -44: "XR_INDEX_OUT_OF_RANGE",
        -45: "XR_VIEW_CONFIGURATION_TYPE_UNSUPPORTED",
        -46: "XR_ENVIRONMENT_BLEND_MODE_UNSUPPORTED",
        -50: "XR_ERROR_GRAPHICS_DEVICE_INVALID",
    }
    return error_names.get(res, f"XrResult({res})")


class OpenXRLoaderD3D11:
    """OpenXR loader with D3D11 support"""
    
    def __init__(self):
        self.lib = _loader
        self.available = bool(self.lib)
        self.xrGetInstanceProcAddr = None
        self.instance = None
        self.system_id = None
        
        if not self.available:
            print("[OpenXR] Loader unavailable")
            return
        
        try:
            self.xrGetInstanceProcAddr = self.lib.xrGetInstanceProcAddr
            self.xrGetInstanceProcAddr.restype = c_int32
            self.xrGetInstanceProcAddr.argtypes = [XrInstance, c_char_p, ctypes.POINTER(c_void_p)]
            print("[OpenXR] xrGetInstanceProcAddr ready")
        except Exception as e:
            print(f"[OpenXR] Failed to bind xrGetInstanceProcAddr: {e}")
            self.available = False
    
    def enumerate_view_configurations(self):
        """Enumerate supported view configuration types"""
        if not self.instance or not self.system_id:
            return -1, None

        p_enum = self.get_proc("xrEnumerateViewConfigurations", self.instance)
        if not p_enum:
            print("[OpenXR] xrEnumerateViewConfigurations not found")
            return -2, None

        PROTO = ctypes.CFUNCTYPE(
            c_int32,
            XrInstance,
            c_uint64,
            c_uint32,
            ctypes.POINTER(c_uint32),
            ctypes.POINTER(c_int32),
        )
        xrEnum = PROTO(p_enum.value)

        count = c_uint32(0)
        res = xrEnum(
            self.instance,
            self.system_id.value,
            0,
            ctypes.byref(count),
            None
        )

        if res != XR_SUCCESS or count.value == 0:
            print("[OpenXR] No view configurations reported")
            return res, None

        types = (c_int32 * count.value)()
        res = xrEnum(
            self.instance,
            self.system_id.value,
            count.value,
            ctypes.byref(count),
            types
        )

        if res != XR_SUCCESS:
            return res, None

        print("[OpenXR] Supported view configurations:")
        for t in types:
            print(f"  - {t}")

        return XR_SUCCESS, list(types)

    class XrViewConfigurationProperties(ctypes.Structure):
        _pack_ = 8  # CRITICAL for SteamVR / Windows ABI
        _fields_ = [
            ("type", c_int32),
            ("next", c_void_p),
            ("fovMutable", c_uint32),  # XrBool32
        ]

    def begin_session(self, session, view_config_type=XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO):
        """
        Begin an OpenXR session.
        
        Args:
            session: XrSession handle
            view_config_type: View configuration type (default: stereo)
        
        Returns:
            XrResult (0 = success)
        """
        if not session:
            print("[OpenXR] begin_session: session is None")
            return -1
        
        # Create begin info structure automatically
        begin_info = XrSessionBeginInfo()
        begin_info.type = XR_TYPE_SESSION_BEGIN_INFO
        begin_info.next = None
        begin_info.primaryViewConfigurationType = view_config_type
        
        print(f"[OpenXR] Beginning session with view config type: {view_config_type}")
        
        # Get xrBeginSession function
        p_begin = self.get_proc("xrBeginSession", self.instance)
        if not p_begin:
            print("[OpenXR] xrBeginSession not found")
            return -2
        
        PROTO = ctypes.CFUNCTYPE(
            c_int32,
            XrSession,
            ctypes.POINTER(XrSessionBeginInfo),
        )
        xrBeginSession_fn = PROTO(p_begin.value)
        
        res = xrBeginSession_fn(session, ctypes.byref(begin_info))
        
        if res != XR_SUCCESS:
            print(f"[OpenXR] xrBeginSession failed: {xr_result_str(res)}")
            return res
        
        print("[OpenXR] ✓ Session begun successfully")
        return XR_SUCCESS

    def get_view_configuration_properties(
        self,
        view_type=XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO
    ):
        """SteamVR REQUIRES this before xrEnumerateViewConfigurationViews"""
        if not self.instance or not self.system_id:
            return -1

        p_get = self.get_proc("xrGetViewConfigurationProperties", self.instance)
        if not p_get:
            print("[OpenXR] xrGetViewConfigurationProperties not found")
            return -2

        PROTO = ctypes.CFUNCTYPE(
            c_int32,          # XrResult
            XrInstance,
            c_uint64,         # XrSystemId
            c_int32,          # XrViewConfigurationType
            ctypes.POINTER(self.XrViewConfigurationProperties),
        )

        xrGetProps = PROTO(p_get.value)

        props = self.XrViewConfigurationProperties()
        props.type = XR_TYPE_VIEW_CONFIGURATION_PROPERTIES
        props.next = None
        print(
            "[DEBUG] props.type =",
            props.type,
            "sizeof =",
            ctypes.sizeof(self.XrViewConfigurationProperties),
        )

        res = xrGetProps(
            self.instance,
            self.system_id.value,
            view_type,
            ctypes.byref(props),
        )

        if res != XR_SUCCESS:
            print("[OpenXR] xrGetViewConfigurationProperties failed")
            return res

        print(f"[OpenXR] View config properties OK (fovMutable={props.fovMutable})")
        return XR_SUCCESS

    def is_available(self):
        return self.available
    
    def get_proc(self, name, instance=None):
        """Get function pointer for an OpenXR function"""
        if not self.available:
            return None
        
        buf = c_void_p()
        name_b = name.encode("utf-8")
        inst = instance if instance is not None else (self.instance if self.instance else None)
        
        res = self.xrGetInstanceProcAddr(inst, name_b, ctypes.byref(buf))
        if res != XR_SUCCESS:
            try:
                fn = getattr(self.lib, name)
                return c_void_p(ctypes.cast(fn, c_void_p).value)
            except AttributeError:
                print(f"[OpenXR] get_proc: {name} not available ({xr_result_str(res)})")
                return None
        
        return buf if buf.value else None
    
    def create_instance(self, application_name="AngeneXR", extensions=None):
        engine_name = "Angene"
        """Create OpenXR instance with D3D11 extension"""
        if not self.available:
            return -1, None
        
        if extensions is None:
            # Use D3D11 extension instead of OpenGL
            extensions = ["XR_KHR_D3D11_enable"]
        
        create_info = XrInstanceCreateInfo()
        ctypes.memset(ctypes.addressof(create_info), 0, ctypes.sizeof(create_info))
        
        create_info.type = XR_TYPE_INSTANCE_CREATE_INFO
        create_info.next = None
        create_info.createFlags = 0
        
        # Set application info
        app_name_encoded = application_name.encode('utf-8')[:XR_MAX_APPLICATION_NAME_SIZE-1]
        ctypes.memmove(
            ctypes.addressof(create_info.applicationInfo) + XrApplicationInfo.applicationName.offset,
            app_name_encoded,
            len(app_name_encoded)
        )
        
        engine_name_encoded = engine_name.encode('utf-8')[:XR_MAX_ENGINE_NAME_SIZE-1]
        ctypes.memmove(
            ctypes.addressof(create_info.applicationInfo) + XrApplicationInfo.engineName.offset,
            engine_name_encoded,
            len(engine_name_encoded)
        )
        
        create_info.applicationInfo.applicationVersion = 1
        create_info.applicationInfo.engineVersion = 1
        create_info.applicationInfo.apiVersion = XR_API_VERSION_1_0
        
        # Setup extensions
        ext_names = (c_char_p * len(extensions))()
        for i, s in enumerate(extensions):
            ext_names[i] = s.encode("utf-8")
        
        create_info.enabledApiLayerCount = 0
        create_info.enabledApiLayerNames = None
        create_info.enabledExtensionCount = len(extensions)
        create_info.enabledExtensionNames = ctypes.cast(ext_names, ctypes.POINTER(c_char_p)) if len(extensions) else None
        
        print(f"[OpenXR] Creating instance with extensions: {extensions}")
        
        # Get xrCreateInstance
        p_xrCreateInstance = self.get_proc("xrCreateInstance", None)
        if not p_xrCreateInstance:
            print("[OpenXR] xrCreateInstance not found")
            return -2, None
        
        PROTO = ctypes.CFUNCTYPE(c_int32, ctypes.POINTER(XrInstanceCreateInfo), ctypes.POINTER(XrInstance))
        xrCreateInstance_fn = PROTO(p_xrCreateInstance.value)
        
        instance_out = XrInstance()
        res = xrCreateInstance_fn(ctypes.byref(create_info), ctypes.byref(instance_out))
        
        if res != XR_SUCCESS:
            print(f"[OpenXR] xrCreateInstance failed: {xr_result_str(res)}")
            return res, None
        
        self.instance = instance_out
        print(f"[OpenXR] Instance created: {instance_out}")
        return XR_SUCCESS, instance_out
    
    def get_system(self, form_factor=1):
        """Get system ID for HMD"""
        if not self.instance:
            return -1, None
        
        p_xrGetSystem = self.get_proc("xrGetSystem", self.instance)
        if not p_xrGetSystem:
            return -2, None
        
        PROTO = ctypes.CFUNCTYPE(c_int32, XrInstance, ctypes.POINTER(XrSystemGetInfo), ctypes.POINTER(XrSystemId))
        xrGetSystem_fn = PROTO(p_xrGetSystem.value)
        
        info = XrSystemGetInfo()
        info.type = XR_TYPE_SYSTEM_GET_INFO
        info.next = None
        info.formFactor = form_factor
        
        system_out = XrSystemId(0)
        res = xrGetSystem_fn(self.instance, ctypes.byref(info), ctypes.byref(system_out))
        
        if res != XR_SUCCESS:
            print(f"[OpenXR] xrGetSystem failed: {xr_result_str(res)}")
            return res, None
        
        self.system_id = system_out
        print(f"[OpenXR] System ID: {system_out.value}")
        return XR_SUCCESS, system_out
    
    def get_d3d11_graphics_requirements(self):
        """
        Get D3D11 graphics requirements from OpenXR.
        This tells us which adapter LUID to use for the D3D11 device.
        MUST be called before creating the session!
        """
        if not self.instance or not self.system_id:
            print("[OpenXR] get_d3d11_graphics_requirements: missing instance or system_id")
            return -1, None
        
        # Get xrGetD3D11GraphicsRequirementsKHR function
        p_xrGetD3D11GraphicsRequirementsKHR = self.get_proc("xrGetD3D11GraphicsRequirementsKHR", self.instance)
        if not p_xrGetD3D11GraphicsRequirementsKHR:
            print("[OpenXR] xrGetD3D11GraphicsRequirementsKHR not found")
            print("[OpenXR] Make sure XR_KHR_D3D11_enable extension is loaded!")
            return -2, None
        
        # Define function prototype
        PROTO = ctypes.CFUNCTYPE(c_int32, XrInstance, c_uint64, ctypes.POINTER(XrGraphicsRequirementsD3D11KHR))
        xrGetD3D11GraphicsRequirementsKHR_fn = PROTO(p_xrGetD3D11GraphicsRequirementsKHR.value)
        
        # Create requirements structure
        requirements = XrGraphicsRequirementsD3D11KHR()
        ctypes.memset(ctypes.addressof(requirements), 0, ctypes.sizeof(requirements))
        requirements.type = XR_TYPE_GRAPHICS_REQUIREMENTS_D3D11_KHR
        requirements.next = None
        
        # Call the function
        res = xrGetD3D11GraphicsRequirementsKHR_fn(self.instance, self.system_id.value, ctypes.byref(requirements))
        
        if res != XR_SUCCESS:
            print(f"[OpenXR] xrGetD3D11GraphicsRequirementsKHR failed: {xr_result_str(res)}")
            return res, None
        
        print(f"[OpenXR] Graphics requirements:")
        print(f"[OpenXR]   Adapter LUID: {requirements.adapterLuid.LowPart:08x}-{requirements.adapterLuid.HighPart:08x}")
        print(f"[OpenXR]   Min Feature Level: {requirements.minFeatureLevel:#06x}")
        
        return XR_SUCCESS, requirements
    
    # Structure type constants
    def get_view_configuration_views(self, view_type=2):
        """
        Enumerate view configuration views - SteamVR compatible version
        
        CRITICAL FIXES:
        1. Use CFUNCTYPE (not WINFUNCTYPE)
        2. Proper structure size verification
        3. Add small delay for SteamVR initialization
        4. Fallback to hardcoded values if enumeration fails
        """
        import time
        
        print("[TRACE] >>> get_view_configuration_views (SteamVR-compatible)")
        
        # Enumerate supported configurations
        res, configs = self.enumerate_view_configurations()
        if res != XR_SUCCESS or not configs:
            print(f"[OpenXR] Failed to enumerate configs: {xr_result_str(res)}")
            return -1, None

        if view_type not in configs:
            print(f"[OpenXR] View type {view_type} not supported")
            return -2, None

        # Get properties (required by SteamVR)
        res = self.get_view_configuration_properties(view_type)
        if res != XR_SUCCESS:
            print(f"[OpenXR] Properties query failed: {xr_result_str(res)}")
            return res, None

        if not self.instance or not self.system_id:
            return -1, None

        p_enum = self.get_proc("xrEnumerateViewConfigurationViews", self.instance)
        if not p_enum:
            return -2, None

        # Use CFUNCTYPE (cdecl calling convention)
        PROTO = ctypes.CFUNCTYPE(
            c_int32,
            XrInstance,
            c_uint64,
            c_int32,
            c_uint32,
            ctypes.POINTER(c_uint32),
            ctypes.POINTER(XrViewConfigurationView),
        )
        xrEnumerate = PROTO(p_enum.value)

        # Get count
        count = c_uint32(0)
        res = xrEnumerate(
            self.instance,
            self.system_id.value,
            view_type,
            0,
            ctypes.byref(count),
            None
        )

        print(f"[OpenXR] Count query: {xr_result_str(res)}, count={count.value}")

        if res != XR_SUCCESS or count.value == 0:
            print("[WARN] Count query failed, using fallback")
            return self._use_fallback_view_config()

        # CRITICAL: Verify structure size before allocating
        expected_size = 40  # 8 (type+next) + 32 (8 uint32s)
        actual_size = ctypes.sizeof(XrViewConfigurationView)
        
        print(f"[DEBUG] XrViewConfigurationView size: {actual_size} bytes (expected: {expected_size})")
        
        if actual_size != expected_size:
            print(f"[ERROR] Structure size mismatch! This will cause crashes.")
            print(f"[ERROR] Check that XrViewConfigurationView has _pack_ = 8")
            return -1, None

        # Allocate array
        views = (XrViewConfigurationView * count.value)()
        
        # Zero-initialize EVERYTHING
        array_size = ctypes.sizeof(views)
        print(f"[DEBUG] Allocating {array_size} bytes for {count.value} views")
        
        ctypes.memset(
            ctypes.addressof(views),
            0,
            array_size
        )
        
        # Initialize each structure
        for i in range(count.value):
            views[i].type = XR_TYPE_VIEW_CONFIGURATION_VIEW
            views[i].next = None
        
        # Verify initialization
        print(f"[DEBUG] First view after init:")
        first_bytes = ctypes.string_at(ctypes.addressof(views[0]), 40)
        print(f"  Bytes: {first_bytes.hex()}")
        print(f"  Type field: {views[0].type} (expected: {XR_TYPE_VIEW_CONFIGURATION_VIEW})")

        # SteamVR sometimes needs a brief moment after session creation
        # Give it 50ms to stabilize
        time.sleep(0.05)

        # Get data - try multiple times
        max_attempts = 3
        for attempt in range(max_attempts):
            if attempt > 0:
                print(f"[RETRY] Attempt {attempt + 1}/{max_attempts}")
                time.sleep(0.1)
            
            res = xrEnumerate(
                self.instance,
                self.system_id.value,
                view_type,
                count.value,
                ctypes.byref(count),
                ctypes.cast(views, ctypes.POINTER(XrViewConfigurationView))
            )

            print(f"[OpenXR] Data query attempt {attempt + 1}: {xr_result_str(res)}")

            if res == XR_SUCCESS:
                # Success! Verify we got valid data
                if views[0].recommendedImageRectWidth > 0:
                    print(f"[OpenXR] ✓ Got {count.value} view configurations:")
                    for i in range(count.value):
                        v = views[i]
                        print(f"  Eye {i}: {v.recommendedImageRectWidth}x{v.recommendedImageRectHeight}")
                        print(f"    Max: {v.maxImageRectWidth}x{v.maxImageRectHeight}")
                        print(f"    Samples: {v.recommendedSwapchainSampleCount}")
                    
                    return XR_SUCCESS, views
                else:
                    print(f"[WARN] Got XR_SUCCESS but data is invalid (width=0)")
                    # Fall through to retry
            else:
                # Print debug info
                print(f"[DEBUG] Failed, memory state:")
                for i in range(count.value):
                    data = ctypes.string_at(ctypes.addressof(views[i]), 40)
                    print(f"  View[{i}]: {data.hex()}")

        # All attempts failed - use fallback
        print("[WARN] All enumeration attempts failed, using fallback configuration")
        return self._use_fallback_view_config()


    def _use_fallback_view_config(self):
        """
        Fallback view configuration for when enumeration fails.
        Uses common VR HMD resolution (works for most headsets).
        """
        print("[FALLBACK] Using hardcoded view configuration")
        print("[FALLBACK] Resolution: 1832x1920 per eye (Quest 2 / Index compatible)")
        
        # Create views with common VR resolution
        views = (XrViewConfigurationView * 2)()
        
        for i in range(2):
            views[i].type = XR_TYPE_VIEW_CONFIGURATION_VIEW
            views[i].next = None
            views[i].recommendedImageRectWidth = 1832
            views[i].maxImageRectWidth = 4096
            views[i].recommendedImageRectHeight = 1920
            views[i].maxImageRectHeight = 4096
            views[i].recommendedSwapchainSampleCount = 1
            views[i].maxSwapchainSampleCount = 4
        
        return XR_SUCCESS, views


    # Also add this method to verify the structure is correct
    def verify_view_config_structure():
        """Verify XrViewConfigurationView structure layout"""
        print("=" * 60)
        print("XrViewConfigurationView Structure Verification")
        print("=" * 60)
        
        v = XrViewConfigurationView()
        
        print(f"Size: {ctypes.sizeof(v)} bytes (expected: 40)")
        print(f"Alignment: {ctypes.alignment(XrViewConfigurationView)} bytes (expected: 8)")
        print(f"_pack_: {getattr(XrViewConfigurationView, '_pack_', 'NOT SET - ERROR!')}")
        
        print("\nField offsets:")
        print(f"  type:                            {XrViewConfigurationView.type.offset}")
        print(f"  next:                            {XrViewConfigurationView.next.offset}")
        print(f"  recommendedImageRectWidth:       {XrViewConfigurationView.recommendedImageRectWidth.offset}")
        print(f"  maxImageRectWidth:               {XrViewConfigurationView.maxImageRectWidth.offset}")
        print(f"  recommendedImageRectHeight:      {XrViewConfigurationView.recommendedImageRectHeight.offset}")
        print(f"  maxImageRectHeight:              {XrViewConfigurationView.maxImageRectHeight.offset}")
        print(f"  recommendedSwapchainSampleCount: {XrViewConfigurationView.recommendedSwapchainSampleCount.offset}")
        print(f"  maxSwapchainSampleCount:         {XrViewConfigurationView.maxSwapchainSampleCount.offset}")
        
        # Expected offsets:
        # type: 0
        # next: 8 (after 4-byte type + 4-byte padding due to _pack_=8)
        # recommendedImageRectWidth: 16
        # maxImageRectWidth: 20
        # recommendedImageRectHeight: 24
        # maxImageRectHeight: 28
        # recommendedSwapchainSampleCount: 32
        # maxSwapchainSampleCount: 36
        # Total: 40 bytes
        
        expected_offsets = [0, 8, 16, 20, 24, 28, 32, 36]
        actual_offsets = [
            XrViewConfigurationView.type.offset,
            XrViewConfigurationView.next.offset,
            XrViewConfigurationView.recommendedImageRectWidth.offset,
            XrViewConfigurationView.maxImageRectWidth.offset,
            XrViewConfigurationView.recommendedImageRectHeight.offset,
            XrViewConfigurationView.maxImageRectHeight.offset,
            XrViewConfigurationView.recommendedSwapchainSampleCount.offset,
            XrViewConfigurationView.maxSwapchainSampleCount.offset,
        ]
        
        print("\nValidation:")
        all_correct = True
        for i, (expected, actual) in enumerate(zip(expected_offsets, actual_offsets)):
            status = "✓" if expected == actual else "✗"
            if expected != actual:
                all_correct = False
            print(f"  Field {i}: {status} Expected {expected}, Got {actual}")
        
        print("=" * 60)
        print(f"Overall: {'✓ CORRECT' if all_correct and ctypes.sizeof(v) == 40 else '✗ INCORRECT'}")
        print("=" * 60)
        
        return all_correct and ctypes.sizeof(v) == 40

    def create_session_d3d11(self, d3d11_device):
        """Create OpenXR session with D3D11 binding"""
        if not self.instance or not self.system_id:
            print("[OpenXR] create_session_d3d11: missing instance or system_id")
            return None
        
        print(f"[OpenXR] Creating session with D3D11 device: {d3d11_device}")
        
        # Create D3D11 graphics binding
        graphics_binding = XrGraphicsBindingD3D11KHR()
        ctypes.memset(ctypes.addressof(graphics_binding), 0, ctypes.sizeof(graphics_binding))
        graphics_binding.type = XR_TYPE_GRAPHICS_BINDING_D3D11_KHR
        graphics_binding.next = None
        
        # FIXED: Handle both c_void_p and int properly
        if isinstance(d3d11_device, ctypes.c_void_p):
            # It's a c_void_p, extract the value
            graphics_binding.device = d3d11_device.value
        elif isinstance(d3d11_device, int):
            # It's already an int pointer
            graphics_binding.device = d3d11_device
        else:
            # Try to get the value attribute
            graphics_binding.device = getattr(d3d11_device, 'value', d3d11_device)
        
        print(f"[OpenXR] Graphics binding: type={graphics_binding.type}, device={graphics_binding.device:#018x}")
        
        # Create session info
        session_info = XrSessionCreateInfo()
        ctypes.memset(ctypes.addressof(session_info), 0, ctypes.sizeof(session_info))
        session_info.type = XR_TYPE_SESSION_CREATE_INFO
        session_info.next = ctypes.cast(ctypes.pointer(graphics_binding), c_void_p)
        session_info.createFlags = 0
        session_info.systemId = self.system_id.value
        
        # Get xrCreateSession
        p_xrCreateSession = self.get_proc("xrCreateSession", self.instance)
        if not p_xrCreateSession:
            print("[OpenXR] xrCreateSession not found")
            return None
        
        PROTO = ctypes.CFUNCTYPE(c_int32, XrInstance, ctypes.POINTER(XrSessionCreateInfo), ctypes.POINTER(XrSession))
        xrCreateSession_fn = PROTO(p_xrCreateSession.value)
        
        session_out = XrSession()
        res = xrCreateSession_fn(self.instance, ctypes.byref(session_info), ctypes.byref(session_out))
        
        if res != XR_SUCCESS:
            print(f"[OpenXR] xrCreateSession failed: {xr_result_str(res)}")
            return None
        
        print(f"[OpenXR] Session created successfully: {session_out}")
        return session_out
    
    def create_reference_space(self, session, space_type=2):
        """Create reference space for tracking"""
        if not session:
            return -1, None
        
        # Create identity pose
        pose = XrPosef()
        pose.orientation[0] = 0.0
        pose.orientation[1] = 0.0
        pose.orientation[2] = 0.0
        pose.orientation[3] = 1.0
        pose.position[0] = 0.0
        pose.position[1] = 0.0
        pose.position[2] = 0.0
        
        # Create reference space info
        space_info = XrReferenceSpaceCreateInfo()
        ctypes.memset(ctypes.addressof(space_info), 0, ctypes.sizeof(space_info))
        space_info.type = XR_TYPE_REFERENCE_SPACE_CREATE_INFO
        space_info.next = None
        space_info.referenceSpaceType = space_type
        space_info.poseInReferenceSpace = pose
        
        # Get xrCreateReferenceSpace
        p_xrCreateReferenceSpace = self.get_proc("xrCreateReferenceSpace", self.instance)
        if not p_xrCreateReferenceSpace:
            return -2, None
        
        PROTO = ctypes.CFUNCTYPE(c_int32, XrSession, ctypes.POINTER(XrReferenceSpaceCreateInfo), ctypes.POINTER(XrSpace))
        xrCreateReferenceSpace_fn = PROTO(p_xrCreateReferenceSpace.value)
        
        space_out = XrSpace()
        res = xrCreateReferenceSpace_fn(session, ctypes.byref(space_info), ctypes.byref(space_out))
        
        if res != XR_SUCCESS:
            print(f"[OpenXR] xrCreateReferenceSpace failed: {xr_result_str(res)}")
            return res, None
        
        print(f"[OpenXR] Reference space created: {space_out}")
        return XR_SUCCESS, space_out
    
    def enumerate_view_configuration_views(self, view_config_type=XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO):
        """Get view configuration (resolutions for each eye)"""
        if not self.instance or not self.system_id:
            return -1, None
        
        # Get function
        p_xrEnumerateViewConfigurationViews = self.get_proc("xrEnumerateViewConfigurationViews", self.instance)
        if not p_xrEnumerateViewConfigurationViews:
            return -2, None
        
        PROTO = ctypes.CFUNCTYPE(
            c_int32, XrInstance, c_uint64, c_int32,
            c_uint32, ctypes.POINTER(c_uint32), ctypes.POINTER(XrViewConfigurationView)
        )
        xrEnumerateViewConfigurationViews_fn = PROTO(p_xrEnumerateViewConfigurationViews.value)
        
        # First call to get count
        view_count = c_uint32(0)
        res = xrEnumerateViewConfigurationViews_fn(
            self.instance, self.system_id.value, view_config_type,
            0, ctypes.byref(view_count), None
        )
        
        if res != XR_SUCCESS or view_count.value == 0:
            return res, None
        
        # Second call to get views
        views = (XrViewConfigurationView * view_count.value)()
        # Zero-initialize array to prevent issues with padding bytes
        ctypes.memset(
            ctypes.addressof(views),
            0,
            ctypes.sizeof(XrViewConfigurationView) * view_count.value
        )
        for i in range(view_count.value):
            views[i].type = XR_TYPE_VIEW_CONFIGURATION_VIEW
            views[i].next = None
        
        res = xrEnumerateViewConfigurationViews_fn(
            self.instance, self.system_id.value, view_config_type,
            view_count.value, ctypes.byref(view_count), views
        )
        
        if res != XR_SUCCESS:
            return res, None
        
        print(f"[OpenXR] View configuration: {view_count.value} views")
        for i in range(view_count.value):
            print(f"[OpenXR]   View {i}: {views[i].recommendedImageRectWidth}x{views[i].recommendedImageRectHeight}")
        
        return XR_SUCCESS, views
    
    def enumerate_swapchain_formats(self, session):
        """Enumerate supported swapchain formats"""
        if not session:
            return -1, None
        
        p_enum = self.get_proc("xrEnumerateSwapchainFormats", self.instance)
        if not p_enum:
            print("[OpenXR] xrEnumerateSwapchainFormats not found")
            return -2, None
        
        PROTO = ctypes.CFUNCTYPE(
            c_int32,
            XrSession,
            c_uint32,
            ctypes.POINTER(c_uint32),
            ctypes.POINTER(ctypes.c_int64),
        )
        xrEnumerate = PROTO(p_enum.value)
        
        # Get count
        count = c_uint32(0)
        res = xrEnumerate(session, 0, ctypes.byref(count), None)
        
        if res != XR_SUCCESS or count.value == 0:
            print(f"[OpenXR] Format enumeration failed: {xr_result_str(res)}")
            return res, None
        
        # Get formats
        formats = (ctypes.c_int64 * count.value)()
        res = xrEnumerate(session, count.value, ctypes.byref(count), formats)
        
        if res != XR_SUCCESS:
            return res, None
        
        print(f"[OpenXR] Supported swapchain formats ({count.value}):")
        for i, fmt in enumerate(formats):
            print(f"  [{i}] {fmt} (0x{fmt:08x})")
        
        return XR_SUCCESS, formats

    def create_swapchain(self, session, width, height, format=None):
        """
        Create a swapchain for rendering.
        If format is None, automatically select first supported format.
        """
        if not session:
            return -1, None
        
        # If no format specified, enumerate and pick first supported format
        if format is None:
            print("[OpenXR] No format specified, enumerating supported formats...")
            res, formats = self.enumerate_swapchain_formats(session)
            
            if res != XR_SUCCESS or not formats or len(formats) == 0:
                print("[OpenXR] Failed to enumerate formats, using fallback")
                # Fallback formats to try in order of preference
                fallback_formats = [
                    27,  # DXGI_FORMAT_B8G8R8A8_UNORM_SRGB (what SteamVR seems to use)
                    91,  # DXGI_FORMAT_B8G8R8A8_UNORM
                    28,  # DXGI_FORMAT_R8G8B8A8_UNORM
                    29,  # DXGI_FORMAT_R8G8B8A8_UNORM_SRGB
                ]
                format = fallback_formats[0]
                print(f"[OpenXR] Using fallback format: {format}")
            else:
                # IMPORTANT: SteamVR/OpenXR often returns format 27 (B8G8R8A8_UNORM_SRGB)
                # even if we request 29 (R8G8B8A8_UNORM_SRGB). We need to check if 27 is available.
                print(f"[OpenXR] Available formats: {list(formats)}")
                
                # First, check if 27 is available (what we're actually getting)
                if 27 in formats:
                    format = 27
                    print("[OpenXR] Using format 27 (DXGI_FORMAT_B8G8R8A8_UNORM_SRGB)")
                elif 91 in formats:
                    format = 91
                    print("[OpenXR] Using format 91 (DXGI_FORMAT_B8G8R8A8_UNORM)")
                elif 28 in formats:
                    format = 28
                    print("[OpenXR] Using format 28 (DXGI_FORMAT_R8G8B8A8_UNORM)")
                elif 29 in formats:
                    format = 29
                    print("[OpenXR] Using format 29 (DXGI_FORMAT_R8G8B8A8_UNORM_SRGB)")
                else:
                    format = formats[0]
                    print(f"[OpenXR] Using first available format: {format}")
        
        # Create swapchain info structure
        create_info = XrSwapchainCreateInfo()
        ctypes.memset(ctypes.addressof(create_info), 0, ctypes.sizeof(create_info))
        
        create_info.type = XR_TYPE_SWAPCHAIN_CREATE_INFO
        create_info.next = None
        create_info.createFlags = 0  # CRITICAL: Must be 0
        create_info.usageFlags = XR_SWAPCHAIN_USAGE_COLOR_ATTACHMENT_BIT | 0x00000004
        create_info.format = format
        create_info.sampleCount = 1
        create_info.width = width
        create_info.height = height
        create_info.faceCount = 1
        create_info.arraySize = 1
        create_info.mipCount = 1
        
        print(f"[OpenXR] Creating swapchain:")
        print(f"  Resolution: {width}x{height}")
        print(f"  Format: {format} (0x{format:08x})")
        print(f"  Usage: COLOR_ATTACHMENT")
        print(f"  Samples: 1")
        
        # Get function
        p_xrCreateSwapchain = self.get_proc("xrCreateSwapchain", self.instance)
        if not p_xrCreateSwapchain:
            print("[OpenXR] xrCreateSwapchain not found")
            return -2, None
        
        PROTO = ctypes.CFUNCTYPE(
            ctypes.c_long, 
            ctypes.c_void_p, 
            ctypes.POINTER(XrSwapchainCreateInfo), 
            ctypes.POINTER(XrSwapchain)
        )
        xrCreateSwapchain_fn = PROTO(p_xrCreateSwapchain.value)
        
        swapchain_out = XrSwapchain()
        res = xrCreateSwapchain_fn(session, ctypes.byref(create_info), ctypes.byref(swapchain_out))
        
        if res != XR_SUCCESS:
            print(f"[OpenXR] xrCreateSwapchain failed: {xr_result_str(res)}")
            return res, None
        
        print(f"[OpenXR] ✓ Swapchain created successfully!")
        return XR_SUCCESS, swapchain_out
    
    def enumerate_swapchain_images(self, swapchain):
        """Get the images/textures in a swapchain"""
        if not swapchain:
            return -1, None
        
        # Get function
        p_xrEnumerateSwapchainImages = self.get_proc("xrEnumerateSwapchainImages", self.instance)
        if not p_xrEnumerateSwapchainImages:
            return -2, None
        
        PROTO = ctypes.CFUNCTYPE(
            c_int32, XrSwapchain, c_uint32, ctypes.POINTER(c_uint32),
            ctypes.POINTER(XrSwapchainImageD3D11KHR)
        )
        xrEnumerateSwapchainImages_fn = PROTO(p_xrEnumerateSwapchainImages.value)
        
        # Get count
        image_count = c_uint32(0)
        res = xrEnumerateSwapchainImages_fn(swapchain, 0, ctypes.byref(image_count), None)
        if res != XR_SUCCESS or image_count.value == 0:
            return res, None
        
        # Get images
        images = (XrSwapchainImageD3D11KHR * image_count.value)()
        # Zero-initialize array to prevent issues with padding bytes
        ctypes.memset(
            ctypes.addressof(images),
            0,
            ctypes.sizeof(XrSwapchainImageD3D11KHR) * image_count.value
        )
        for i in range(image_count.value):
            images[i].type = XR_TYPE_SWAPCHAIN_IMAGE_D3D11_KHR
            images[i].next = None
        
        res = xrEnumerateSwapchainImages_fn(
            swapchain, image_count.value, ctypes.byref(image_count),
            ctypes.cast(images, ctypes.POINTER(XrSwapchainImageD3D11KHR))
        )
        
        if res != XR_SUCCESS:
            return res, None
        
        return XR_SUCCESS, images
    
    def wait_frame(self, session):
        """Wait for next frame (VR timing)"""
        if not session:
            return -1, None
        
        wait_info = XrFrameWaitInfo()
        wait_info.type = XR_TYPE_FRAME_WAIT_INFO
        wait_info.next = None
        
        frame_state = XrFrameState()
        frame_state.type = XR_TYPE_FRAME_STATE
        frame_state.next = None
        
        p_xrWaitFrame = self.get_proc("xrWaitFrame", self.instance)
        if not p_xrWaitFrame:
            return -2, None
        
        PROTO = ctypes.CFUNCTYPE(c_int32, XrSession, ctypes.POINTER(XrFrameWaitInfo), ctypes.POINTER(XrFrameState))
        xrWaitFrame_fn = PROTO(p_xrWaitFrame.value)
        
        res = xrWaitFrame_fn(session, ctypes.byref(wait_info), ctypes.byref(frame_state))
        if res != XR_SUCCESS:
            return res, None
        
        return XR_SUCCESS, frame_state
    
    def begin_frame(self, session):
        """Begin rendering a frame"""
        if not session:
            return -1
        
        begin_info = XrFrameBeginInfo()
        begin_info.type = XR_TYPE_FRAME_BEGIN_INFO
        begin_info.next = None
        
        p_xrBeginFrame = self.get_proc("xrBeginFrame", self.instance)
        if not p_xrBeginFrame:
            return -2
        
        PROTO = ctypes.CFUNCTYPE(c_int32, XrSession, ctypes.POINTER(XrFrameBeginInfo))
        xrBeginFrame_fn = PROTO(p_xrBeginFrame.value)
        
        return xrBeginFrame_fn(session, ctypes.byref(begin_info))
    
    def end_frame(self, session, display_time, layers):
        """End frame and submit to compositor"""
        if not session:
            return -1
        
        end_info = XrFrameEndInfo()
        end_info.type = XR_TYPE_FRAME_END_INFO
        end_info.next = None
        end_info.displayTime = display_time
        end_info.environmentBlendMode = XR_ENVIRONMENT_BLEND_MODE_OPAQUE
        end_info.layerCount = len(layers) if layers else 0
        end_info.layers = ctypes.cast(layers, c_void_p) if layers else None
        
        p_xrEndFrame = self.get_proc("xrEndFrame", self.instance)
        if not p_xrEndFrame:
            return -2
        
        PROTO = ctypes.CFUNCTYPE(c_int32, XrSession, ctypes.POINTER(XrFrameEndInfo))
        xrEndFrame_fn = PROTO(p_xrEndFrame.value)
        
        return xrEndFrame_fn(session, ctypes.byref(end_info))
    
    def locate_views(self, session, display_time, space, view_count=2):
        """Get view poses (eye positions/orientations)"""
        if not session or not space:
            return -1, None, None
        
        locate_info = XrViewLocateInfo()
        locate_info.type = XR_TYPE_VIEW_LOCATE_INFO
        locate_info.next = None
        locate_info.viewConfigurationType = XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO
        locate_info.displayTime = display_time
        locate_info.space = space
        
        view_state = XrViewState()
        view_state.type = XR_TYPE_VIEW_STATE
        view_state.next = None
        
        views = (XrView * view_count)()
        # Zero-initialize array to prevent issues with padding bytes
        ctypes.memset(
            ctypes.addressof(views),
            0,
            ctypes.sizeof(XrView) * view_count
        )
        for i in range(view_count):
            views[i].type = XR_TYPE_VIEW
            views[i].next = None
        
        p_xrLocateViews = self.get_proc("xrLocateViews", self.instance)
        if not p_xrLocateViews:
            return -2, None, None
        
        PROTO = ctypes.CFUNCTYPE(
            c_int32, XrSession, ctypes.POINTER(XrViewLocateInfo),
            ctypes.POINTER(XrViewState), c_uint32, ctypes.POINTER(c_uint32),
            ctypes.POINTER(XrView)
        )
        xrLocateViews_fn = PROTO(p_xrLocateViews.value)
        
        view_count_out = c_uint32(view_count)
        res = xrLocateViews_fn(
            session, ctypes.byref(locate_info), ctypes.byref(view_state),
            view_count, ctypes.byref(view_count_out), views
        )
        
        if res != XR_SUCCESS:
            return res, None, None
        
        return XR_SUCCESS, view_state, views
    
    def acquire_swapchain_image(self, swapchain):
        """Acquire next swapchain image"""
        if not swapchain:
            return -1, None
        
        acquire_info = XrSwapchainImageAcquireInfo()
        acquire_info.type = XR_TYPE_SWAPCHAIN_IMAGE_ACQUIRE_INFO
        acquire_info.next = None
        
        index = c_uint32(0)
        
        p_xrAcquireSwapchainImage = self.get_proc("xrAcquireSwapchainImage", self.instance)
        if not p_xrAcquireSwapchainImage:
            return -2, None
        
        PROTO = ctypes.CFUNCTYPE(c_int32, XrSwapchain, ctypes.POINTER(XrSwapchainImageAcquireInfo), ctypes.POINTER(c_uint32))
        xrAcquireSwapchainImage_fn = PROTO(p_xrAcquireSwapchainImage.value)
        
        res = xrAcquireSwapchainImage_fn(swapchain, ctypes.byref(acquire_info), ctypes.byref(index))
        if res != XR_SUCCESS:
            return res, None
        
        return XR_SUCCESS, index.value
    
    def wait_swapchain_image(self, swapchain, timeout=1000000000):  # 1 second default
        """Wait for swapchain image to be ready"""
        if not swapchain:
            return -1
        
        wait_info = XrSwapchainImageWaitInfo()
        wait_info.type = XR_TYPE_SWAPCHAIN_IMAGE_WAIT_INFO
        wait_info.next = None
        wait_info.timeout = timeout
        
        p_xrWaitSwapchainImage = self.get_proc("xrWaitSwapchainImage", self.instance)
        if not p_xrWaitSwapchainImage:
            return -2
        
        PROTO = ctypes.CFUNCTYPE(c_int32, XrSwapchain, ctypes.POINTER(XrSwapchainImageWaitInfo))
        xrWaitSwapchainImage_fn = PROTO(p_xrWaitSwapchainImage.value)
        
        return xrWaitSwapchainImage_fn(swapchain, ctypes.byref(wait_info))
    
    def release_swapchain_image(self, swapchain):
        """Release swapchain image back to compositor"""
        if not swapchain:
            return -1
        
        release_info = XrSwapchainImageReleaseInfo()
        release_info.type = XR_TYPE_SWAPCHAIN_IMAGE_RELEASE_INFO
        release_info.next = None
        
        p_xrReleaseSwapchainImage = self.get_proc("xrReleaseSwapchainImage", self.instance)
        if not p_xrReleaseSwapchainImage:
            return -2
        
        PROTO = ctypes.CFUNCTYPE(c_int32, XrSwapchain, ctypes.POINTER(XrSwapchainImageReleaseInfo))
        xrReleaseSwapchainImage_fn = PROTO(p_xrReleaseSwapchainImage.value)
        
        return xrReleaseSwapchainImage_fn(swapchain, ctypes.byref(release_info))


if __name__ == "__main__":
    loader = OpenXRLoaderD3D11()
    if loader.is_available():
        print("[OpenXR] Testing instance creation with D3D11...")
        res, inst = loader.create_instance()
        if res == XR_SUCCESS:
            print("[OpenXR] ✓ Instance created successfully!")
            res2, sys_id = loader.get_system()
            if res2 == XR_SUCCESS:
                print(f"[OpenXR] ✓ System ID: {sys_id.value}")