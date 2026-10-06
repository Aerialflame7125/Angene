using Angene.Common;
using Angene.Graphics;
using Angene.Windows;
using Angene.Linux.X11;
using static Angene.Vulkan.Interop.Methods;
using static Angene.Vulkan.Interop.Structs;
using static Angene.Vulkan.Interop.Enumerators;
using static Angene.Vulkan.Interop.VulkanMemoryAllocator;
using static Angene.Vulkan.Interop.VulkanMemoryAllocator.Methods;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using Angene.Graphics.SlangShader;
using System.Reflection.Metadata.Ecma335;
using Angene.Essentials;
using static Angene.Essentials.Types;
using Angene.Essentials.GraphicsContexts;
using Angene.Math.Vectors;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Angene.Essentials.Components;

namespace Angene.Graphics.Vulkan;
public unsafe class VkGraphicsContext : IVkGraphicsContext, IDisposable
{
    private IntPtr _vkInstance;
    private IntPtr _vkPhysicalDevice;
    private IntPtr _vkDevice;
    private IntPtr _vkQueue;
    private IntPtr _vkSurfaceKHR;
    private VkSurfaceCapabilitiesKHR _vkSurfaceCapabilities;
    private IntPtr _vkSwapchainKHR;
    private VkFormat _vkFormat;
    private VkExtent2D _vkExtent2D;
    private int _currentImageIndex;
    private IntPtr[] _vkImages = new IntPtr[0];
    private IntPtr[] _vkImageViews = new IntPtr[0];
    private IntPtr _vkCommandPool;
    private IntPtr _vkCommandBuffer;
    private IntPtr _vkRenderPass;
    private IntPtr _vkFramebuffer;
    public IntPtr[] _vkFramebuffers;
    private IntPtr _vkPipeline;
    private IntPtr _vkPipelineLayout;
    private IntPtr _vkSemaphoreImageAvailable;
    private IntPtr _vkSemaphoreRenderFinished;
    private IntPtr _vkFenceInFlight;
    private bool _disposed;
    private bool _sharingDevice;
    private Dictionary<IntPtr, VmaBufferHandle> _vmaBuffers = new();
    private IntPtr _currentVertexBuffer;
    private IntPtr _currentPipeline;
    private AppInfo _currentAppInfo;
    private IScene _scene;


    public AppInfo CurrentAppInfo => _currentAppInfo;
    public IntPtr VkPhysicalDevice => _vkPhysicalDevice;
    public IntPtr VkDevice => _vkDevice;
    public IntPtr VkQueue => _vkQueue;
    public IntPtr VkSurfaceKHR => _vkSurfaceKHR;
    private VkSurfaceCapabilitiesKHR VkSurfaceCapabilities => _vkSurfaceCapabilities;
    public IntPtr VkInstance => _vkInstance;
    public IntPtr VkSwapchainKHR => _vkSwapchainKHR;
    public VkFormat VkFormat => _vkFormat;
    public VkExtent2D VkExtent2D => _vkExtent2D;
    public int SwapchainImageCount => _vkImages.Count();
    public int CurrentImageIndex => _currentImageIndex;
    public IntPtr[] VkImages => _vkImages;
    public IntPtr[] VkImageViews => _vkImageViews;
    public IntPtr VkCommandPool => _vkCommandPool;
    public IntPtr VkCommandBuffer => _vkCommandBuffer;
    public IntPtr VkRenderPass => _vkRenderPass;
    public IntPtr VkFramebuffer => _vkFramebuffer;
    public IntPtr[] VkFrameBuffers => _vkFramebuffers;
    public IntPtr VkPipeline { get => _vkPipeline; set => _vkPipeline = value; }
    public IntPtr VkPipelineLayout => _vkPipelineLayout;
    public IntPtr VkSemaphoreImageAvailable => _vkSemaphoreImageAvailable;
    public IntPtr VkSemaphoreRenderFinished => _vkSemaphoreRenderFinished;
    public IntPtr VkFenceInFlight => _vkFenceInFlight;

    public IntPtr Handle => _vkDevice;
    public IntPtr ContextHandle => _vkInstance;

    private VkSurfaceFormatKHR _surfaceFormat;
    private VkPresentModeKHR _presentMode;

    private IntPtr _vmaAllocator;
    private IntPtr _vma_VkBuffer;
    private IntPtr _vmaAllocation;
    private IntPtr _debugMessenger;
    private delegate* unmanaged[Cdecl]<IntPtr, VkDebugUtilsMessengerCreateInfoEXT*, VkAllocationCallbacks*, IntPtr*, VkResult> _createFunc;
    private delegate* unmanaged[Cdecl]<IntPtr, IntPtr, VkAllocationCallbacks*, void> _destroyFunc;
    private VkShader[] Shaders = Array.Empty<VkShader>();
    private List<IntPtr> shaderModules = new List<IntPtr>();
    private readonly IntPtr _hwnd;
    private bool _needsRecreateSwapchain = false;

    public bool shuttingDown { get; internal set; } = false;
    private readonly int _w, _h;
    VkGraphicscontextHelpers contextHelpers = new VkGraphicscontextHelpers();
    private readonly object _allocatorLock = new object();
    public List<string> ExtraExtensions = new List<string>() {};
    public QueueFamilyIndices? queueFamilyIndices { get; internal set; }
    
    // OpenXR
    public bool UseOpenXR { get; internal set; }
    public (Types.XrSwapchain, Types.XrSwapchain) XrSwapchains { get; private set; } = (
        new XrSwapchain(IntPtr.Zero, VkFormat.VK_FORMAT_A8B8G8R8_SRGB_PACK32, 0, 0, true),
        new XrSwapchain(IntPtr.Zero, VkFormat.VK_FORMAT_A8B8G8R8_SRGB_PACK32, 0, 0, true));
    private IntPtr[][] _xrViews = new IntPtr[2][];
    private IntPtr[][] _xrFramebuffers = new IntPtr[2][];
    private VkExtent2D[] _xrExtent = new VkExtent2D[2];
    private Func<Types.XrFrameInfo> _xrBeginFrame;
    private Func<int, uint> _xrAcquire;
    private Action<int> _xrRelease;
    private Action<bool> _xrEndFrame;
    private Func<bool> _xrRunning;
    private ulong maxSupportedOpenXRVer = 0;
    private uint instanceVersion = (uint)((1 << 22) | (3 << 12) | 0);
    private string xrDll = Common.Settings.Settings.Instance.GetSetting<string>("Engine.RunningDirectory") + "/Angene.Extensions.XR.dll";
    private OpenXRController leftOXRController, rightOXRController = null;
    private IntPtr _xrCommandBuffer, _xrFence, _activeCmd, _xrPipeline, _xrRenderPass;
    
    // depth
    private const VkFormat DepthFormat = VkFormat.VK_FORMAT_D32_SFLOAT;
    private (IntPtr img, IntPtr alloc, IntPtr view) _depth;
    private (IntPtr img, IntPtr alloc, IntPtr view)[] _xrDepth = new (IntPtr, IntPtr, IntPtr)[2];
    
    
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
    private static uint DebugCallback(
        VkDebugUtilsMessageSeverityFlagBitsEXT severity,
        uint messageTypeFlags,  // VkDebugUtilsMessageTypeFlagsEXT
        VkDebugUtilsMessengerCallbackDataEXT* pCallbackData,
        void* pUserData)
    {
        string message = Marshal.PtrToStringAnsi((IntPtr)pCallbackData->pMessage);
        Logger.LogError($"[Vulkan Validation] {message}", LoggingTarget.Graphics);
        return 0;
    }


    private static object OXRInstance;
    private static Type CachedType;

    public void SetScene(IScene scene) => _scene = scene;
    
    internal static void InitializeExternalInstance(string assemblyPath, string typeName)
    {
        if (OXRInstance != null) return;

        Assembly assem = Assembly.LoadFrom(assemblyPath);
        CachedType = assem.GetType(typeName);
    
        if (CachedType == null)
            throw new Exception($"Type {typeName} was unable to be found.");

        OXRInstance = Activator.CreateInstance(CachedType);
    }
    internal static object CallExternalFunc(string method, object[] parameters, bool isStatic = true)
    {
        BindingFlags flags = isStatic 
            ? BindingFlags.Static | BindingFlags.Public 
            : BindingFlags.Instance | BindingFlags.Public;

        MethodInfo lmethod = CachedType.GetMethod(method, flags);
        if (lmethod == null)
            throw new Exception($"Method {method} was unable to be found.");

        try 
        { 
            object target = isStatic ? null : OXRInstance;
            return lmethod.Invoke(target, parameters); 
        } 
        catch (TargetInvocationException ex) when (ex.InnerException != null)
        {
            System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            return null; // Unreachable
        }
    }

    internal static object GetPreservedVariable(string variableName)
    {
        if (CachedType == null || OXRInstance == null)
            throw new InvalidOperationException("External library instance does not exist.");
        
        PropertyInfo prop = CachedType.GetProperty(variableName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (prop != null)
        {
            return prop.GetValue(OXRInstance);
        }
        
        FieldInfo field = CachedType.GetField(variableName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (field != null)
        {
            return field.GetValue(OXRInstance);
        }

        throw new MissingMemberException($"Field or Property '{variableName}' was not found on type {CachedType.FullName}.");
    }

    public VkGraphicsContext(object windowHandle, int width, int height, Dictionary<int, object> shaders, IScene Scene, Types.AppInfo? currentAppInfo = null, bool UseOpenXR = false)
    {
        if (windowHandle is MicrosoftWindowHandle MWinHandle)
            _hwnd = MWinHandle.Hwnd;
        else if (windowHandle is X11WindowHandle XWinHandle)
            _hwnd = XWinHandle.Window;
        else if (windowHandle is WaylandWindowHandle WayWinHandle)
            _hwnd = (IntPtr)WayWinHandle.Surface;

        _w = width;
        _h = height;
        _scene = Scene;
        _currentAppInfo = currentAppInfo;
        VkPresentModeKHR wantedPresentationMode = currentAppInfo.VulkanPresentMode;

        try
        {
            if (shaders != null)
            {
                var vkShaderList = new List<VkShader>();
                foreach (KeyValuePair<int, object> shader in shaders)
                    if (shader.Value is VkShader vkShader)
                        vkShaderList.Add(vkShader);
                Shaders = vkShaderList.ToArray();
            }

            IntPtr appNamePtr = IntPtr.Zero;
            IntPtr functionPointerName = IntPtr.Zero;
            IntPtr engineNamePtr = Marshal.StringToHGlobalAnsi("Angene");
            IntPtr createDebugUtilsPtr = Marshal.StringToHGlobalAnsi("vkCreateDebugUtilsMessengerEXT");
            IntPtr destroyDebugUtilsPtr = Marshal.StringToHGlobalAnsi("vkDestroyDebugUtilsMessengerEXT");
            var nameHandles = new List<GCHandle>();

            VkApplicationInfo appInfo;
            VkInstanceCreateInfo createInfo;
            VkResult result;
            
            IntPtr vulkanLib = NativeLibrary.Load(
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "vulkan-1.dll" : "libvulkan.so.1");
            IntPtr pfnGipa = NativeLibrary.GetExport(vulkanLib, "vkGetInstanceProcAddr");
            if (UseOpenXR)
                InitializeExternalInstance(Common.Settings.Settings.Instance.GetSetting<string>("Engine.RunningDirectory") + "/Angene.Extensions.XR.dll", "Angene.Extensions.XR.OpenXR");
            
#region OpenXR Init
                this.UseOpenXR = UseOpenXR;
                if (UseOpenXR)
                {
                    if (!Common.Settings.Settings.Instance.GetSetting<string[]>("Main.SupportedLibraries")
                        .Contains("Extensions.XR"))
                        throw new Exceptions.FailedToInitializeVulkanException("OpenXR is labeled to be used but the library is missing. Please check your installation.");
                    
                    
                    CallExternalFunc("CreateInstanceS1", new object[] { (IVkGraphicsContext)this, currentAppInfo });
                    
                    object ret = CallExternalFunc("getMinMaxSupportedVulkan", new object[] { } );
                    
                    (ulong, ulong) rret = (ValueTuple<ulong, ulong>)ret;
                    maxSupportedOpenXRVer = rret.Item2;
                }
#endregion
#region App Info (appInfo)
                if (maxSupportedOpenXRVer != 0)
                    instanceVersion = VkGraphicscontextHelpers.XrToVkVersion(maxSupportedOpenXRVer);
                
                uint vmaMajor = instanceVersion >> 22;
                uint vmaMinor = (instanceVersion >> 12) & 0x3FF;
                uint vmaApiVersion = (vmaMajor == 1 && vmaMinor <= 4) // vma asserts on anything above 1.4
                    ? instanceVersion
                    : (uint)((1 << 22) | (3 << 12));
                
                try
                {
                    if (currentAppInfo != null)
                    {
                        appNamePtr = Marshal.StringToHGlobalAnsi(currentAppInfo.AppName);
                        appInfo = new VkApplicationInfo
                        {
                            sType = VkStructureType.VK_STRUCTURE_TYPE_APPLICATION_INFO,
                            pApplicationName = (sbyte*)appNamePtr,
                            applicationVersion = (uint)System.Math.Round(currentAppInfo.AppVersion),
                            pEngineName = (sbyte*)engineNamePtr,
                            engineVersion = (uint)System.Math.Round(Angene.Common.Settings.Settings.Instance.GetSetting<float>("Main.VersionFloat")), // cancer
                            apiVersion = instanceVersion
                        };
                    }
                    else
                    {
                        appNamePtr = Marshal.StringToHGlobalAnsi("Angene Application");
                        appInfo = new VkApplicationInfo
                        {
                            sType = VkStructureType.VK_STRUCTURE_TYPE_APPLICATION_INFO,
                            pApplicationName = (sbyte*)appNamePtr,
                            applicationVersion = 0,
                            pEngineName = (sbyte*)engineNamePtr,
                            engineVersion = (uint)System.Math.Round(Angene.Common.Settings.Settings.Instance.GetSetting<float>("Main.VersionFloat")), // cancer
                            apiVersion = instanceVersion
                        };
                    }
#endregion
#region Extensions
                // Extensions //
                var requiredLinux = new List<string> { "VK_KHR_surface", "VK_KHR_xlib_surface", "VK_KHR_wayland_surface", "VK_KHR_get_surface_capabilities2", "VK_EXT_surface_maintenance1"};
                var requiredWindows = new List<string> { "VK_KHR_surface", "VK_KHR_win32_surface", "VK_KHR_get_surface_capabilities2"};
                var optional = new List<string> { "VK_EXT_debug_utils" };

                uint extCount = 0;
                vkEnumerateInstanceExtensionProperties(null, &extCount, null);
                var available = new HashSet<string>();
                var props = new VkExtensionProperties[extCount];
                fixed (VkExtensionProperties* pProps = props)
                    vkEnumerateInstanceExtensionProperties(null, &extCount, pProps);
                foreach (var p in props)
                {
                    ReadOnlySpan<sbyte> nameSpan = MemoryMarshal.CreateReadOnlySpan(
                        ref System.Runtime.CompilerServices.Unsafe.AsRef(in p.extensionName[0]), 256);

                    int len = nameSpan.IndexOf((sbyte)0);
                    if (len < 0) len = nameSpan.Length;

                    // Reinterpret sbyte span as byte span for UTF8 decoding
                    ReadOnlySpan<byte> byteSpan = MemoryMarshal.Cast<sbyte, byte>(nameSpan.Slice(0, len));
                    available.Add(Encoding.UTF8.GetString(byteSpan));
                }

                var toEnable = new List<string>();
                if (windowHandle is X11WindowHandle || windowHandle is WaylandWindowHandle)
                {
                    foreach (var r in requiredLinux)
                    {
                        if (!available.Contains(r))
                            throw new Exceptions.FailedToInitializeVulkanException($"Required Vulkan extension missing: {r}");
                        toEnable.Add(r);
                    }
                }
                else if (windowHandle is MicrosoftWindowHandle)
                {
                    foreach (var r in requiredWindows)
                    {
                        if (!available.Contains(r))
                            throw new Exceptions.FailedToInitializeVulkanException($"Required Vulkan extension missing: {r}");
                        toEnable.Add(r);
                    }
                }
                foreach (var o in optional)
                {
                    if (available.Contains(o))
                        toEnable.Add(o);
                }

                foreach (var e in ExtraExtensions)
                {
                    if (!available.Contains(e))
                        throw new Exceptions.FailedToInitializeVulkanException(
                            $"OpenXR-required Vulkan instance extension missing: {e}");

                    if (!toEnable.Contains(e))
                        toEnable.Add(e);
                }

                byte[][] extBytes = toEnable.Select(s => Encoding.UTF8.GetBytes(s + "\0")).ToArray();
                int extCountFinal = extBytes.Length;

                // Pin each string and collect handles so they stay alive across the native call
                var handles = new GCHandle[extCountFinal];
                var extPointers = new byte*[extCountFinal];
#endregion
#region Instance Creation (_vkInstance)
                IntPtr instanceHandle;

                try
                {
                    for (int i = 0; i < extCountFinal; i++)
                    {
                        handles[i] = GCHandle.Alloc(extBytes[i], GCHandleType.Pinned);
                        extPointers[i] = (byte*)handles[i].AddrOfPinnedObject();
                    }

                    fixed (byte** ppEnabledExtensionNames = extPointers)
                    {
                        createInfo = new VkInstanceCreateInfo
                        {
                            sType = VkStructureType.VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO,
                            pApplicationInfo = &appInfo,
                            enabledExtensionCount = (uint)extCountFinal,
                            ppEnabledExtensionNames = (sbyte**)ppEnabledExtensionNames
                        };

                        if (UseOpenXR)
                        {
                            var r = CallExternalFunc("CreateVulkanInstance", new object[] { (IntPtr)(&createInfo), pfnGipa });
                            instanceHandle = (IntPtr)r;
                        }
                        else
                        {
                            result = vkCreateInstance(&createInfo, null, out instanceHandle);
                            if (result != VkResult.VK_SUCCESS)
                                throw new Exception($"Failed to create Vulkan instance: {result}");
                        }
                    }
                }
                finally
                {
                    foreach (var h in handles)
                        if (h.IsAllocated) h.Free();
                }

                // new instance
                _vkInstance = instanceHandle;
#endregion
#region Debug Messenger
            // Load function pointers
            IntPtr pfnCreate = (IntPtr)vkGetInstanceProcAddr(_vkInstance, (sbyte*)createDebugUtilsPtr);
            IntPtr pfnDestroy = (IntPtr)vkGetInstanceProcAddr(_vkInstance, (sbyte*)destroyDebugUtilsPtr);
            if (pfnCreate == IntPtr.Zero || pfnDestroy == IntPtr.Zero)
                throw new Exception("Debug utils extension functions not available");

            delegate* unmanaged[Cdecl]<IntPtr, VkDebugUtilsMessengerCreateInfoEXT*, VkAllocationCallbacks*, IntPtr*, VkResult> createFunc =
                (delegate* unmanaged[Cdecl]<IntPtr, VkDebugUtilsMessengerCreateInfoEXT*, VkAllocationCallbacks*, IntPtr*, VkResult>)pfnCreate;

            delegate* unmanaged[Cdecl]<IntPtr, IntPtr, VkAllocationCallbacks*, void> destroyFunc =
                (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, VkAllocationCallbacks*, void>)pfnDestroy;

            // Create messenger
            VkDebugUtilsMessengerCreateInfoEXT messengerInfo = new VkDebugUtilsMessengerCreateInfoEXT
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_DEBUG_UTILS_MESSENGER_CREATE_INFO_EXT,
                messageSeverity = (uint)(VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT |
                                        VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT),
                messageType = (uint)(VkDebugUtilsMessageTypeFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_TYPE_GENERAL_BIT_EXT |
                                    VkDebugUtilsMessageTypeFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_TYPE_VALIDATION_BIT_EXT),
                pfnUserCallback = &DebugCallback
            };

            IntPtr debugMessenger;
            result = createFunc(_vkInstance, &messengerInfo, null, &debugMessenger);
            if (result != VkResult.VK_SUCCESS)
                throw new Exception("Failed to create debug messenger");

            _createFunc = createFunc;
            _destroyFunc = destroyFunc;

            _debugMessenger = debugMessenger;
#endregion
#region Surface Creation (_vkSurfaceKHR)
#region XLib & Wayland
                if (windowHandle is X11WindowHandle a)
                {
                    IntPtr surface = IntPtr.Zero;
                    VkXlibSurfaceCreateInfoKHR create_info = new VkXlibSurfaceCreateInfoKHR
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_XLIB_SURFACE_CREATE_INFO_KHR,
                        pNext = null,
                        flags = 0,
                        dpy = (void**)a.Display,
                        window = (nuint)_hwnd
                    };

                    functionPointerName = Marshal.StringToHGlobalAnsi("vkCreateXcbSurfaceKHR");

                    result = vkCreateXlibSurfaceKHR(instanceHandle, &create_info, null, &surface);
                    if (result != VkResult.VK_SUCCESS)
                    {
                        throw new Exceptions.FailedToInitializeVulkanException($"Failed to create Vulkan surface: {result}");
                    }
                    _vkSurfaceKHR = surface;
                }
                else if (windowHandle is WaylandWindowHandle b)
                {
                    IntPtr surface = IntPtr.Zero;
                    VkWaylandSurfaceCreateInfoKHR create_info = new VkWaylandSurfaceCreateInfoKHR
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_WAYLAND_SURFACE_CREATE_INFO_KHR,
                        pNext = null,
                        flags = 0,
                        dpy = (void**)b.Display,
                        window = (nuint)_hwnd
                    };

                    functionPointerName = Marshal.StringToHGlobalAnsi("vkCreateWaylandSurfaceKHR");

                    result = vkCreateWaylandSurfaceKHR(instanceHandle, &create_info, null, &surface);
                    if (result != VkResult.VK_SUCCESS)
                    {
                        throw new Exceptions.FailedToInitializeVulkanException($"Failed to create Vulkan surface: {result}");
                    }
                    _vkSurfaceKHR = surface;
                }

#endregion
#region Windows
                else if (windowHandle is MicrosoftWindowHandle MWindowHandle)
                {
                    IntPtr surface = IntPtr.Zero;
                    VkWin32SurfaceCreateInfoKHR create_info = new VkWin32SurfaceCreateInfoKHR
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_WIN32_SURFACE_CREATE_INFO_KHR,
                        pNext = null,
                        flags = 0,
                        hinstance = (void*)Kernel32.GetModuleHandle(null),
                        hwnd = (void*)MWindowHandle.Hwnd
                    };

                    functionPointerName = Marshal.StringToHGlobalAnsi("vkCreateWin32SurfaceKHR");

                    result = vkCreateWin32SurfaceKHR(instanceHandle, &create_info, null, &surface);
                    if (result != VkResult.VK_SUCCESS)
                        throw new Exceptions.FailedToInitializeVulkanException($"Failed to create Vulkan surface: {result}");
                    _vkSurfaceKHR = surface;
                }
#endregion
#endregion
#region Select physical device (_vkPhysicalDevice) + logical device (_device) + graphics queue (_vkQueue)
                IntPtr _physicalDevice = IntPtr.Zero;
                IntPtr _device = IntPtr.Zero;
                IntPtr _graphicsQueue = IntPtr.Zero;
                
                uint xrQueueFamily = 0;
                if (UseOpenXR)
                {
                    _physicalDevice = (IntPtr)CallExternalFunc("GetVulkanPhysicalDevice", new object[] { _vkInstance });

                    IntPtr pd = _physicalDevice;
                    contextHelpers.CreateDevice(pd, Array.Empty<string>(),
                        ci => (IntPtr)CallExternalFunc("CreateVulkanDevice", new object[] { pd, ci, pfnGipa }),
                        out _device, out _graphicsQueue, out xrQueueFamily);
                }
                else
                    contextHelpers.SelectPhysicalDeviceAndLogicalDevice(_vkInstance, out _physicalDevice, out _device, out _graphicsQueue);
                
                _vkPhysicalDevice = _physicalDevice;
                _vkDevice = _device;
                _vkQueue = _graphicsQueue;
#endregion
#region (OPENXR) XRSession (XRSession)
                QueueFamilyIndices queueFamilyIndices = (QueueFamilyIndices)contextHelpers.findQueueFamilies(_physicalDevice, _vkSurfaceKHR);
                this.queueFamilyIndices = queueFamilyIndices;

                IntPtr XRSession;
                if (UseOpenXR)
                {
                    object ret = CallExternalFunc("CreateSessionS2", new object[] { _vkInstance, _vkDevice, UseOpenXR ? xrQueueFamily : queueFamilyIndices.graphicsFamily.Value });

                    XRSession = (IntPtr)ret;
                    
                    CallExternalFunc("createSpace", new object[] { new Vec3(0, 0, 0), new Quaternion(0, 0, 0, 1) });
                    
                    BindXr();
                }
#endregion
#region Vulkan Memory Allocator (VMA)
            // 1. Create the allocator once, after you have instance/physicalDevice/device
            VmaAllocatorCreateInfo allocatorInfo = new VmaAllocatorCreateInfo
            {
                instance = _vkInstance,
                physicalDevice = _vkPhysicalDevice,
                device = _vkDevice,
                vulkanApiVersion = vmaApiVersion,
                // pVulkanFunctions = ... required by most bindings, fill with vkGetInstanceProcAddr/vkGetDeviceProcAddr
            };

            IntPtr localAllocator;
            result = vmaCreateAllocator(&allocatorInfo, &localAllocator);
            if (result != VkResult.VK_SUCCESS)
                throw new Exception($"Failed to create VMA allocator: {result}");

            // 2. Describe the buffer
            VkBufferCreateInfo bufferInfo = new VkBufferCreateInfo
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO,
                size = 1024 * 1024,
                usage = (uint)VK_BUFFER_USAGE_2_VERTEX_BUFFER_BIT,
                sharingMode = VkSharingMode.VK_SHARING_MODE_EXCLUSIVE
            };

            // 3. Describe how VMA should allocate memory for it
            VmaAllocationCreateInfo VmaAllocInfo = new VmaAllocationCreateInfo
            {
                usage = VmaMemoryUsage.VMA_MEMORY_USAGE_AUTO
            };

            // 4. Let VMA create the buffer AND its backing memory
            IntPtr localBuffer;
            IntPtr localVmaAllocation;
            result = vmaCreateBuffer(localAllocator, &bufferInfo, &VmaAllocInfo, &localBuffer, &localVmaAllocation, null);
            if (result != VkResult.VK_SUCCESS)
                throw new Exceptions.FailedToInitializeVulkanException($"Failed to create buffer via VMA: {result}");

            _vma_VkBuffer = localBuffer;
            _vmaAllocation = localVmaAllocation;
            _vmaAllocator = localAllocator;
#endregion
#region Shader Handling
                Shaders = Shaders.OrderBy(x => (int)x.Queue + x.id).ToArray();

                for (int i = 0; i < Shaders.Count(); i++)
                {
                    VkShader shader = Shaders[i];
                    fixed (byte* pCode = shader.byteCode)
                    {
                        var shaderModuleCreateInfo = new VkShaderModuleCreateInfo
                        {
                            sType = VkStructureType.VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO,
                            codeSize = (nuint)shader.byteCode.Length,
                            pCode = (uint*)pCode
                        };

                        IntPtr module;
                        result = vkCreateShaderModule(_device, &shaderModuleCreateInfo, null, &module);
                        if (result != VkResult.VK_SUCCESS)
                            throw new AngeneException($"Failed to create shader module for '{shader.Name}': {result}");
                        else
                            Logger.LogImportant($"Creating shader module for shader '{shader.Name}' succeeded.", LoggingTarget.Graphics);
                        
                        
                        shader.NativeShaderModule = module;
                        shaderModules.Add(module);
                    }
                }
#endregion
#region Swapchain (_vkSwapchainKHR), (_surfaceCapabilities)
                VkSurfaceCapabilitiesKHR _surfaceCapabilities = new VkSurfaceCapabilitiesKHR();
                result = vkGetPhysicalDeviceSurfaceCapabilitiesKHR(_physicalDevice, _vkSurfaceKHR, &_surfaceCapabilities);
                if (result != VkResult.VK_SUCCESS)
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to create swapchain (vkGetPhysicalDeviceSurfaceCapabilitiesKHR): {result}");

                _vkSurfaceCapabilities = _surfaceCapabilities;

                if (UseOpenXR)
                {
                    object ret = CallExternalFunc("createSwapchainsAndActionSet", new object[] {} );

                    XrSwapchains = ((XrSwapchain, XrSwapchain))ret;
                    _xrRenderPass = CreateRenderPass(XrSwapchains.Item1.format,
                        VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL);

                    for (int eye = 0; eye < 2; eye++)
                    {
                        var sc = eye == 0 ? XrSwapchains.Item1 : XrSwapchains.Item2;
                        _xrDepth[eye] = CreateDepth(sc.width, sc.height);
                        var imgsObj = CallExternalFunc("getSwapchainImages", new object[] { sc });
                        var imgs = (List<XrSwapchainImageVulkanKHR>)imgsObj;
                        _xrViews[eye] = new IntPtr[imgs.Count];
                        _xrFramebuffers[eye] = new IntPtr[imgs.Count];
                        _xrExtent[eye] = new VkExtent2D { width = sc.width, height = sc.height };

                        for (int i = 0; i < imgs.Count; i++)
                        {
                            _xrViews[eye][i] = contextHelpers.CreateImageView(_vkDevice, imgs[i].image, sc.format,
                                VkImageAspectFlagBits.VK_IMAGE_ASPECT_COLOR_BIT, VkImageViewType.VK_IMAGE_VIEW_TYPE_2D, 1, 1);
                            _xrFramebuffers[eye][i] = CreateFramebuffer(_xrRenderPass, _xrViews[eye][i],
                                _xrDepth[eye].view, sc.width, sc.height);
                        }
                    }
                }
                
                VkExtent2D chosenExtent;
                if (_surfaceCapabilities.currentExtent.width == uint.MaxValue)
                {
                    // platform decides
                    chosenExtent = new VkExtent2D
                    {
                        width = (uint)System.Math.Clamp(width,
                            (int)_surfaceCapabilities.minImageExtent.width,
                            (int)_surfaceCapabilities.maxImageExtent.width),
                        height = (uint)System.Math.Clamp(height,
                            (int)_surfaceCapabilities.minImageExtent.height,
                            (int)_surfaceCapabilities.maxImageExtent.height)
                    };
                    _vkSurfaceCapabilities.currentExtent = chosenExtent;
                }
                else
                {
                    chosenExtent = _surfaceCapabilities.currentExtent;
                }

                _vkExtent2D = chosenExtent;

                _depth = CreateDepth(chosenExtent.width, chosenExtent.height);
                
                // get surface format
                uint surfaceFormatCount;
                vkGetPhysicalDeviceSurfaceFormatsKHR(_physicalDevice, _vkSurfaceKHR, &surfaceFormatCount, null);

                VkSurfaceFormatKHR[] surfaceFormats = new VkSurfaceFormatKHR[surfaceFormatCount];
                fixed (VkSurfaceFormatKHR* pSurfaceFormats = surfaceFormats)
                    vkGetPhysicalDeviceSurfaceFormatsKHR(_physicalDevice, _vkSurfaceKHR, &surfaceFormatCount, pSurfaceFormats);
                
                VkSurfaceFormatKHR SurfaceFormat = contextHelpers.ChooseSurfaceFormatAndColorSpace(surfaceFormats);

                _surfaceFormat = SurfaceFormat;
                _vkFormat = SurfaceFormat.format;

                // get present modes
                uint presentModeCount;
                vkGetPhysicalDeviceSurfacePresentModesKHR(_physicalDevice, _vkSurfaceKHR, &presentModeCount, null);

                VkPresentModeKHR[] presentModes = new VkPresentModeKHR[presentModeCount];
                fixed (VkPresentModeKHR* pPresentModes = presentModes)
                    vkGetPhysicalDeviceSurfacePresentModesKHR(_physicalDevice, _vkSurfaceKHR, &presentModeCount, pPresentModes);

                _presentMode = contextHelpers.ChoosePresentationMode(presentModes, wantedPresentationMode);

                // create swapchain
                VkSwapchainCreateInfoKHR swapchainCreateInfo = new VkSwapchainCreateInfoKHR
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_SWAPCHAIN_CREATE_INFO_KHR,
                    pNext = null,
                    flags = 0,
                    surface = (VkSurfaceKHR*)_vkSurfaceKHR,
                    minImageCount = contextHelpers.ChooseNumImages(_surfaceCapabilities),
                    imageFormat = SurfaceFormat.format,
                    imageColorSpace = SurfaceFormat.colorSpace,
                    imageExtent = chosenExtent,
                    imageArrayLayers = 1,
                    imageUsage = (uint)(VkImageUsageFlagBits.VK_IMAGE_USAGE_COLOR_ATTACHMENT_BIT | VkImageUsageFlagBits.VK_IMAGE_USAGE_TRANSFER_DST_BIT), // 1 is for basic rendering, 2 is for post processing
                    imageSharingMode = VkSharingMode.VK_SHARING_MODE_EXCLUSIVE,
                    queueFamilyIndexCount = 0,
                    pQueueFamilyIndices = null, 
                    preTransform = _surfaceCapabilities.currentTransform,
                    compositeAlpha = VkCompositeAlphaFlagBitsKHR.VK_COMPOSITE_ALPHA_OPAQUE_BIT_KHR, // ignore alpha channel
                    presentMode = contextHelpers.ChoosePresentationMode(presentModes, wantedPresentationMode),
                    clipped = 1
                };
                IntPtr _localSwapchain = IntPtr.Zero;
                result = vkCreateSwapchainKHR(_device, &swapchainCreateInfo, null, &_localSwapchain);
                if (result != VkResult.VK_SUCCESS)
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to create swapchain (vkCreateSwapchainKHR): {result}");

                _vkSwapchainKHR = _localSwapchain;
#endregion
#region Image Views (_currentImageIndex), (_swapchainImageCount), (_vkImages), (_vkImageViews)
                // If we are here, success! Now time to get swapchain images
                uint numswapchainImages = 0;
                result = vkGetSwapchainImagesKHR(_device, _vkSwapchainKHR, &numswapchainImages, null);
                if (result != VkResult.VK_SUCCESS)
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to get swapchain images (vkGetSwapchainImagesKHR): {result}");

                _vkImages = new IntPtr[numswapchainImages];
                _vkImageViews = new IntPtr[numswapchainImages];

                fixed (IntPtr* images = _vkImages)
                {
                    result = vkGetSwapchainImagesKHR(_device, _vkSwapchainKHR, &numswapchainImages, images);
                    if (result != VkResult.VK_SUCCESS)
                        throw new Exceptions.FailedToInitializeVulkanException($"Failed to get swapchain images (vkGetSwapchainImagesKHR): {result}");
                }

                // Aaaaaand create the views
                int layerCount = 1;
                int mipLevels = 1;
                for (uint i = 0; i < numswapchainImages; i++)
                    _vkImageViews[i] = contextHelpers.CreateImageView(_device, _vkImages[i], SurfaceFormat.format, VkImageAspectFlagBits.VK_IMAGE_ASPECT_COLOR_BIT, VkImageViewType.VK_IMAGE_VIEW_TYPE_2D, (uint)layerCount, (uint)mipLevels);

#endregion
#region Render Pass (_vkRenderPass), (_vkPipelineLayout)
                VkAttachmentDescription colorAttachment = new VkAttachmentDescription
                {
                    format = SurfaceFormat.format,
                    samples = VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT,
                    loadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_CLEAR,
                    storeOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_STORE,
                    stencilLoadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_DONT_CARE,
                    stencilStoreOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_DONT_CARE,
                    initialLayout = VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED,
                    finalLayout = VkImageLayout.VK_IMAGE_LAYOUT_PRESENT_SRC_KHR
                };
                VkAttachmentDescription* atts = stackalloc VkAttachmentDescription[2];
                atts[0] = colorAttachment;
                atts[1] = new VkAttachmentDescription {
                    format = DepthFormat,
                    samples = VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT,
                    loadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_CLEAR,
                    storeOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_DONT_CARE,
                    stencilLoadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_DONT_CARE,
                    stencilStoreOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_DONT_CARE,
                    initialLayout = VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED,
                    finalLayout = VkImageLayout.VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL
                };
                VkAttachmentReference colorAttachmentRef = new VkAttachmentReference
                {
                    attachment = 0,
                    layout = VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL
                };
                var depthRef = new VkAttachmentReference {
                    attachment = 1,
                    layout = VkImageLayout.VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL };
                VkSubpassDescription subpass = new VkSubpassDescription
                {
                    pipelineBindPoint = VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS,
                    colorAttachmentCount = 1,
                    pColorAttachments = &colorAttachmentRef,
                    pDepthStencilAttachment = &depthRef
                };

                IntPtr renderPass = IntPtr.Zero;
                VkSubpassDependency dependency = new VkSubpassDependency
                {
                    srcSubpass = uint.MaxValue,
                    dstSubpass = 0,
                    srcStageMask = (uint)(VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT | VkPipelineStageFlagBits.VK_PIPELINE_STAGE_EARLY_FRAGMENT_TESTS_BIT | VkPipelineStageFlagBits.VK_PIPELINE_STAGE_LATE_FRAGMENT_TESTS_BIT),
                    srcAccessMask = 0,
                    dstStageMask = (uint)(VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT | VkPipelineStageFlagBits.VK_PIPELINE_STAGE_EARLY_FRAGMENT_TESTS_BIT | VkPipelineStageFlagBits.VK_PIPELINE_STAGE_LATE_FRAGMENT_TESTS_BIT),
                    dstAccessMask = (uint)(VkAccessFlagBits.VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT | VkAccessFlagBits.VK_ACCESS_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT)
                };
                
                VkRenderPassCreateInfo renderPassInfo = new VkRenderPassCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO,
                    attachmentCount = 2,
                    pAttachments = atts,
                    subpassCount = 1,
                    pSubpasses = &subpass,
                    dependencyCount = 1,
                    pDependencies = &dependency
                };
                result = vkCreateRenderPass(_device, &renderPassInfo, null, &renderPass);
                if (result != VkResult.VK_SUCCESS)
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to create render pass (vkCreateRenderPass): {result}");

                _vkRenderPass = renderPass;
#endregion
#region Fixed Functions
                // Dynamic State
                VkDynamicState[] dynamicStates = new VkDynamicState[]
                {
                    VkDynamicState.VK_DYNAMIC_STATE_VIEWPORT,
                    VkDynamicState.VK_DYNAMIC_STATE_SCISSOR
                };
                VkPipelineDynamicStateCreateInfo dynamicState;
                fixed (VkDynamicState* pDynamicStates = dynamicStates)
                {
                    dynamicState = new VkPipelineDynamicStateCreateInfo
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_DYNAMIC_STATE_CREATE_INFO,
                        dynamicStateCount = (uint)dynamicStates.Count(),
                        pDynamicStates = pDynamicStates
                    };
                }

                // Vertex Input
                VkPipelineVertexInputStateCreateInfo vertexInputInfo = new VkPipelineVertexInputStateCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_STATE_CREATE_INFO,
                    vertexBindingDescriptionCount = 0,
                    pVertexBindingDescriptions = null, // optional
                    vertexAttributeDescriptionCount = 0,
                    pVertexAttributeDescriptions = null // optional
                };

                // Input Assembly
                VkPipelineInputAssemblyStateCreateInfo inputAssembly = new VkPipelineInputAssemblyStateCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_INPUT_ASSEMBLY_STATE_CREATE_INFO,
                    topology = VkPrimitiveTopology.VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST,
                    primitiveRestartEnable = 0 // false
                };

                // Viewports & scissors
                VkViewport viewport = new VkViewport
                {
                    x = 0.0f,
                    y = 0.0f,
                    width = _surfaceCapabilities.currentExtent.width,
                    height = _surfaceCapabilities.currentExtent.height,
                    minDepth = 0.0f,
                    maxDepth = 1.0f
                };
                VkRect2D scissor = new VkRect2D
                {
                    offset = new VkOffset2D
                    {
                        x = 0,
                        y = 0
                    },
                    extent = _surfaceCapabilities.currentExtent
                };
                VkPipelineViewportStateCreateInfo viewportState = new VkPipelineViewportStateCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_STATE_CREATE_INFO,
                    viewportCount = 1,
                    pViewports = &viewport,
                    scissorCount = 1,
                    pScissors = &scissor
                };


                // Rasterizer
                VkPipelineRasterizationStateCreateInfo rasterizer = new VkPipelineRasterizationStateCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_CREATE_INFO,
                    depthClampEnable = 0, // False
                    polygonMode = VkPolygonMode.VK_POLYGON_MODE_FILL,
                    lineWidth = 1.0f,
                    cullMode = (uint)VkCullModeFlagBits.VK_CULL_MODE_BACK_BIT,
                    frontFace = VkFrontFace.VK_FRONT_FACE_CLOCKWISE,
                    depthBiasEnable = 0, // False, can be used for shadow mapping
                    depthBiasConstantFactor = 0.0f, // optional
                    depthBiasClamp = 0.0f, // optional
                    depthBiasSlopeFactor = 0.0f // optional
                };


                // Multisampling
                VkPipelineMultisampleStateCreateInfo multisampling = new VkPipelineMultisampleStateCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_MULTISAMPLE_STATE_CREATE_INFO,
                    sampleShadingEnable = 0, // false
                    rasterizationSamples = VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT,
                    minSampleShading = 1.0f, // optional
                    pSampleMask = null, // optional
                    alphaToCoverageEnable = 0, // optional
                    alphaToOneEnable = 0 // optional
                };


                // Color Blending
                VkPipelineColorBlendAttachmentState colorBlendAttachment = new VkPipelineColorBlendAttachmentState
                {
                    colorWriteMask = (uint)(VkColorComponentFlagBits.VK_COLOR_COMPONENT_R_BIT | VkColorComponentFlagBits.VK_COLOR_COMPONENT_G_BIT | VkColorComponentFlagBits.VK_COLOR_COMPONENT_B_BIT | VkColorComponentFlagBits.VK_COLOR_COMPONENT_A_BIT),
                    blendEnable = 0, // false
                    srcColorBlendFactor = VkBlendFactor.VK_BLEND_FACTOR_ONE, // Optional
                    dstColorBlendFactor = VkBlendFactor.VK_BLEND_FACTOR_ZERO, // Optional
                    colorBlendOp = VkBlendOp.VK_BLEND_OP_ADD, // Optional
                    srcAlphaBlendFactor = VkBlendFactor.VK_BLEND_FACTOR_ONE, // Optional
                    dstAlphaBlendFactor = VkBlendFactor.VK_BLEND_FACTOR_ZERO, // Optional
                    alphaBlendOp = VkBlendOp.VK_BLEND_OP_ADD // Optional
                };
                VkPipelineColorBlendStateCreateInfo colorBlending = new VkPipelineColorBlendStateCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_COLOR_BLEND_STATE_CREATE_INFO,
                    logicOpEnable = 0, // false
                    logicOp = VkLogicOp.VK_LOGIC_OP_COPY, // Optional
                    attachmentCount = 1,
                    pAttachments = &colorBlendAttachment
                };


                // Pipeline Layout
                IntPtr pipelineLayout = IntPtr.Zero;

                VkPushConstantRange range = new()
                {
                    stageFlags = (uint)VkShaderStageFlagBits.VK_SHADER_STAGE_VERTEX_BIT,
                    offset = 0,
                    size = 128
                };

                VkPipelineLayoutCreateInfo pipelineLayoutInfo = new VkPipelineLayoutCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_LAYOUT_CREATE_INFO,
                    setLayoutCount = 0, // Optional
                    pSetLayouts = null, // Optional
                    pushConstantRangeCount = 1,
                    pPushConstantRanges = &range
                };
                result = vkCreatePipelineLayout(_device, &pipelineLayoutInfo, null, &pipelineLayout);
                if (result != VkResult.VK_SUCCESS)
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to create pipeline layout (vkCreatePipelineLayout): {result}");

                _vkPipelineLayout = pipelineLayout;
#endregion
#region Framebuffer (_vkFramebuffer)
                _vkFramebuffers = new IntPtr[_vkImageViews.Length];
                for (int i = 0; i < _vkImageViews.Length; i++)
                    _vkFramebuffers[i] = CreateFramebuffer(_vkRenderPass, _vkImageViews[i], _depth.view,
                        chosenExtent.width, chosenExtent.height);
#endregion
#region Command Pool (_vkCommandPool)
                IntPtr commandPool;
                
                VkCommandPoolCreateInfo poolInfo = new VkCommandPoolCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO,
                    flags = (uint)VkCommandPoolCreateFlagBits.VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT,
                    queueFamilyIndex = UseOpenXR ? xrQueueFamily : queueFamilyIndices.graphicsFamily.Value
                };
                
                result = vkCreateCommandPool(_device, &poolInfo, null, &commandPool);

                if (result != VkResult.VK_SUCCESS)
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to create command pool (vkCreateCommandPool): {result}");

                _vkCommandPool = commandPool;
#endregion
#region Command Buffers (_vkCommandBuffer)
                IntPtr commandBuffer;

                VkCommandBufferAllocateInfo commandBufferAllocInfo = new VkCommandBufferAllocateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_BUFFER_ALLOCATE_INFO,
                    commandPool = commandPool,
                    level = VkCommandBufferLevel.VK_COMMAND_BUFFER_LEVEL_PRIMARY,
                    commandBufferCount = 1
                };
                result = vkAllocateCommandBuffers(_device, &commandBufferAllocInfo, &commandBuffer);

                if (result != VkResult.VK_SUCCESS)
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to allocate command buffers (vkAllocateCommandBuffers): {result}");

                IntPtr xrCb;
                result = vkAllocateCommandBuffers(_device, &commandBufferAllocInfo, &xrCb);
                _xrCommandBuffer = xrCb;
                
                _vkCommandBuffer = commandBuffer;
#endregion
#region Sync Objects
                VkSemaphoreCreateInfo semaphoreInfo = new VkSemaphoreCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_SEMAPHORE_CREATE_INFO
                };
                VkFenceCreateInfo fenceInfo = new VkFenceCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_FENCE_CREATE_INFO,
                    flags = (uint)VkFenceCreateFlagBits.VK_FENCE_CREATE_SIGNALED_BIT,
                };
                IntPtr imageAvailableSemaphore = IntPtr.Zero;
                IntPtr renderFinishedSemaphore = IntPtr.Zero;
                IntPtr inFlightFence = IntPtr.Zero;

                if (vkCreateSemaphore(_device, &semaphoreInfo, null, &imageAvailableSemaphore) != VkResult.VK_SUCCESS || vkCreateSemaphore(_device, &semaphoreInfo, null, &renderFinishedSemaphore) != VkResult.VK_SUCCESS || vkCreateFence(_device, &fenceInfo, null, &inFlightFence) != VkResult.VK_SUCCESS)
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to create semaphores (vkCreateSemaphore): {result}");

                IntPtr xrFence;
                vkCreateFence(_device, &fenceInfo, null, &xrFence);
                _xrFence = xrFence;
                
                _vkSemaphoreImageAvailable = imageAvailableSemaphore;
                _vkSemaphoreRenderFinished = renderFinishedSemaphore;
                _vkFenceInFlight = inFlightFence;
#endregion
                // If we are here, WE FUCKING DID IT YEAHHHHHHHHHHHHH

            }
            finally
            {
                Marshal.FreeHGlobal(appNamePtr);
                Marshal.FreeHGlobal(engineNamePtr);
                Marshal.FreeHGlobal(functionPointerName);
            }
        }
        catch (Exception ex)
        {
            Logger.LogCritical($"[Vulkan] Initialization failed: {ex.Message}", LoggingTarget.Engine, ex);
            throw;
        }
    }

    public void Clear(uint color) { }
    public byte[] GetRawPixels() => Array.Empty<byte>();
    public void Present(IntPtr windowHandle) { }
    
    private IntPtr CreateFramebuffer(IntPtr rp, IntPtr color, IntPtr depth, uint w, uint h)
    {
        IntPtr* at = stackalloc IntPtr[] { color, depth };
        var info = new VkFramebufferCreateInfo {
            sType = VkStructureType.VK_STRUCTURE_TYPE_FRAMEBUFFER_CREATE_INFO,
            renderPass = rp, attachmentCount = 2, pAttachments = at,
            width = w, height = h, layers = 1 };
        IntPtr fb;
        var r = vkCreateFramebuffer(_vkDevice, &info, null, &fb);
        if (r != VkResult.VK_SUCCESS) throw new Exceptions.FailedToInitializeVulkanException($"Framebuffer failed: {r}");
        return fb;
    }

    public IntPtr CreateVertexBuffer(byte[] data, uint strideBytes)
    {
        VkBufferCreateInfo bufferInfo = new VkBufferCreateInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO,
            size = (ulong)data.Length,
            usage = (uint)VkBufferUsageFlagBits.VK_BUFFER_USAGE_VERTEX_BUFFER_BIT,
            sharingMode = VkSharingMode.VK_SHARING_MODE_EXCLUSIVE
        };
        VmaAllocationCreateInfo allocInfo = new VmaAllocationCreateInfo
        {
            usage = VmaMemoryUsage.VMA_MEMORY_USAGE_AUTO,
            flags = (uint)(VmaAllocationCreateFlagBits.VMA_ALLOCATION_CREATE_HOST_ACCESS_SEQUENTIAL_WRITE_BIT
                        | VmaAllocationCreateFlagBits.VMA_ALLOCATION_CREATE_MAPPED_BIT)
        };

        IntPtr buffer;
        IntPtr allocation;
        VmaAllocationInfo allocationInfo;
        lock (_allocatorLock)
        {
            if (_disposed || shuttingDown || _vmaAllocator == IntPtr.Zero)
            {
                // Abort the operation. The engine is shutting down.
                return IntPtr.Zero; 
            }

            VkResult result = vmaCreateBuffer(_vmaAllocator, &bufferInfo, &allocInfo, &buffer, &allocation, &allocationInfo);
            if (result != VkResult.VK_SUCCESS)
                throw new Exception($"Failed to create buffer: {result}");
        }

        fixed (byte* pData = data)
            Buffer.MemoryCopy(pData, allocationInfo.pMappedData, (ulong)data.Length, (ulong)data.Length);

        IntPtr handle = (IntPtr)buffer;

        _vmaBuffers[handle] = new VmaBufferHandle { Buffer = buffer, Allocation = allocation };
        return handle;
    }

    public IntPtr CreateIndexBuffer(uint[] indices)
    {
        byte[] bytes = new byte[indices.Length * sizeof(uint)];
        Buffer.BlockCopy(indices, 0, bytes, 0, bytes.Length);

        VkBufferCreateInfo bufferInfo = new VkBufferCreateInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO,
            size = (ulong)bytes.Length,
            usage = (uint)VkBufferUsageFlagBits.VK_BUFFER_USAGE_INDEX_BUFFER_BIT,
            sharingMode = VkSharingMode.VK_SHARING_MODE_EXCLUSIVE
        };
        VmaAllocationCreateInfo allocInfo = new VmaAllocationCreateInfo
        {
            usage = VmaMemoryUsage.VMA_MEMORY_USAGE_AUTO,
            flags = (uint)(VmaAllocationCreateFlagBits.VMA_ALLOCATION_CREATE_HOST_ACCESS_SEQUENTIAL_WRITE_BIT
                        | VmaAllocationCreateFlagBits.VMA_ALLOCATION_CREATE_MAPPED_BIT)
        };

        IntPtr buffer;
        IntPtr allocation;
        VmaAllocationInfo allocationInfo;
        lock (_allocatorLock)
        {
            if (_disposed || shuttingDown || _vmaAllocator == IntPtr.Zero)
            {
                // Abort the operation. The engine is shutting down.
                return IntPtr.Zero; 
            }

            VkResult result = vmaCreateBuffer(_vmaAllocator, &bufferInfo, &allocInfo, &buffer, &allocation, &allocationInfo);
            if (result != VkResult.VK_SUCCESS)
                throw new Exception($"Failed to create buffer: {result}");
        }

        fixed (byte* pData = bytes)
            Buffer.MemoryCopy(pData, allocationInfo.pMappedData, (ulong)bytes.Length, (ulong)bytes.Length);

        IntPtr handle = (IntPtr)buffer;
        _vmaBuffers[handle] = new VmaBufferHandle { Buffer = buffer, Allocation = allocation };
        return handle;
    }

    public void DestroyBuffer(IntPtr bufferHandle)
    {
        lock (_allocatorLock)
        {
            if (_disposed || shuttingDown || _vmaAllocator == IntPtr.Zero)
                return; 

            vmaDestroyBuffer(_vmaAllocator, _vmaBuffers[bufferHandle].Buffer, _vmaBuffers[bufferHandle].Allocation);
        }
        _vmaBuffers.Remove(bufferHandle);
    }

    public void UpdateBuffer(IntPtr oldBufferHandle, IntPtr newBufferHandle)
    {
        lock (_allocatorLock)
        {
            if (_disposed || shuttingDown || _vmaAllocator == IntPtr.Zero)
                return;

            vmaDestroyBuffer(_vmaAllocator, _vmaBuffers[oldBufferHandle].Buffer, _vmaBuffers[oldBufferHandle].Allocation);
        }

        _vmaBuffers[oldBufferHandle] = _vmaBuffers[newBufferHandle];
        _vmaBuffers.Remove(newBufferHandle);
    }

    public void UpdateVertexBuffer(IntPtr bufferHandle, byte[] data, uint offset = 0)
    {
        lock (_allocatorLock)
        {
            if (_disposed || shuttingDown || _vmaAllocator == IntPtr.Zero || !_vmaBuffers.TryGetValue(bufferHandle, out var handle))
                return;

            VmaAllocationInfo allocInfo;
            vmaGetAllocationInfo(_vmaAllocator, handle.Allocation, &allocInfo);

            if ((ulong)(offset + data.Length) > allocInfo.size)
                throw new AngeneException("[VkGraphicsContext | UpdateVertexBuffer] Data exceeds buffer size. Recreate the buffer with a larger size.");

            fixed (byte* pData = data)
            {
                Buffer.MemoryCopy(pData, (byte*)allocInfo.pMappedData + offset, data.Length, data.Length);
            }

            // flush range, just in case
            vmaFlushAllocation(_vmaAllocator, handle.Allocation, offset, (ulong)data.Length);
        }
    }

    public IntPtr CreateRenderPass(VkFormat format, VkImageLayout finallayout)
    {
        VkResult result;
        VkAttachmentDescription colorAttachment = new VkAttachmentDescription
        {
            format = format,
            samples = VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT,
            loadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_CLEAR,
            storeOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_STORE,
            stencilLoadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_DONT_CARE,
            stencilStoreOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_DONT_CARE,
            initialLayout = VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED,
            finalLayout = finallayout
        };
        var depthRef = new VkAttachmentReference { attachment = 1,
            layout = VkImageLayout.VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL };
        VkAttachmentReference colorAttachmentRef = new VkAttachmentReference
        {
            attachment = 0,
            layout = VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL
        };
        VkSubpassDescription subpass = new VkSubpassDescription
        {
            pipelineBindPoint = VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS,
            colorAttachmentCount = 1,
            pColorAttachments = &colorAttachmentRef,
            pDepthStencilAttachment = &depthRef
        };
        VkAttachmentDescription* atts = stackalloc VkAttachmentDescription[2];
        atts[0] = colorAttachment;
        atts[1] = new VkAttachmentDescription {
            format = DepthFormat,
            samples = VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT,
            loadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_CLEAR,
            storeOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_DONT_CARE,
            stencilLoadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_DONT_CARE,
            stencilStoreOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_DONT_CARE,
            initialLayout = VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED,
            finalLayout = VkImageLayout.VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL };

        IntPtr renderPass = IntPtr.Zero;
        
        VkSubpassDependency dependency = new VkSubpassDependency
        {
            srcSubpass = uint.MaxValue,
            dstSubpass = 0,
            srcStageMask = (uint)VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT,
            srcAccessMask = 0,
            dstStageMask = (uint)VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT,
            dstAccessMask = (uint)VkAccessFlagBits.VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT
        };

        VkRenderPassCreateInfo renderPassInfo = new VkRenderPassCreateInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO,
            attachmentCount = 2,
            pAttachments = atts,
            subpassCount = 1,
            pSubpasses = &subpass,
            dependencyCount = 1,
            pDependencies = &dependency
        };
        result = vkCreateRenderPass(_vkDevice, &renderPassInfo, null, &renderPass);
        if (result != VkResult.VK_SUCCESS)
            throw new Exceptions.FailedToInitializeVulkanException($"Failed to create render pass: {result}");
        return renderPass;
    }

    public IntPtr CreatePipeline(VkVertexInputAttributeDescription[] attributes, uint strideBytes)
    {
        IntPtr entryPointPtr = Marshal.StringToHGlobalAnsi("main");
        try
        {
            sbyte* entryPoint = (sbyte*)entryPointPtr;

            List<VkPipelineShaderStageCreateInfo> stages = new List<VkPipelineShaderStageCreateInfo>{};

            foreach (VkShader shader in Shaders)
            {
                switch (shader.Type)
                {
                    case SlangShaderResources.ShaderType.Vertex:
                        stages.Add(new VkPipelineShaderStageCreateInfo()
                        {
                            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO,
                            stage = VkShaderStageFlagBits.VK_SHADER_STAGE_VERTEX_BIT,
                            module = shader.NativeShaderModule,
                            pName = entryPoint
                        });
                        break;
                    case SlangShaderResources.ShaderType.Fragment:
                        stages.Add(new VkPipelineShaderStageCreateInfo()
                        {
                            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO,
                            stage = VkShaderStageFlagBits.VK_SHADER_STAGE_FRAGMENT_BIT,
                            module = shader.NativeShaderModule,
                            pName = entryPoint
                        });
                        break;
                    case SlangShaderResources.ShaderType.Compute:
                        stages.Add(new VkPipelineShaderStageCreateInfo()
                        {
                            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO,
                            stage = VkShaderStageFlagBits.VK_SHADER_STAGE_COMPUTE_BIT,
                            module = shader.NativeShaderModule,
                            pName = entryPoint
                        });
                        break;
                }
            }

            fixed (VkPipelineShaderStageCreateInfo* pStages = stages.ToArray())
            fixed (VkVertexInputAttributeDescription* pAttrs = attributes)
            {
                VkPipelineVertexInputStateCreateInfo vertexInputInfo;
                if (attributes.Length == 0)
                {
                    vertexInputInfo = new VkPipelineVertexInputStateCreateInfo
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_STATE_CREATE_INFO,
                        vertexBindingDescriptionCount = 0,
                        pVertexBindingDescriptions = null,
                        vertexAttributeDescriptionCount = 0,
                        pVertexAttributeDescriptions = null
                    };
                }
                else
                {
                    VkVertexInputBindingDescription binding = new VkVertexInputBindingDescription
                    {
                        binding = 0,
                        stride = strideBytes,
                        inputRate = VkVertexInputRate.VK_VERTEX_INPUT_RATE_VERTEX
                    };
                    fixed (VkVertexInputAttributeDescription* pAttrs1 = attributes)
                    {
                        vertexInputInfo = new VkPipelineVertexInputStateCreateInfo
                        {
                            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_STATE_CREATE_INFO,
                            vertexBindingDescriptionCount = 1,
                            pVertexBindingDescriptions = &binding,
                            vertexAttributeDescriptionCount = (uint)attributes.Length,
                            pVertexAttributeDescriptions = pAttrs1
                        };
                    }
                }

                VkPipelineInputAssemblyStateCreateInfo inputAssembly = new VkPipelineInputAssemblyStateCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_INPUT_ASSEMBLY_STATE_CREATE_INFO,
                    topology = VkPrimitiveTopology.VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST,
                    primitiveRestartEnable = 0
                };

                VkViewport[] viewport = new VkViewport[]
                { new VkViewport {
                    x = 0.0f, y = 0.0f,
                    width = _vkSurfaceCapabilities.currentExtent.width,
                    height = _vkSurfaceCapabilities.currentExtent.height,
                    minDepth = 0.0f, maxDepth = 1.0f
                } };

                VkRect2D[] scissor = new VkRect2D[]
                { new VkRect2D {
                    offset = new VkOffset2D { x = 0, y = 0 },
                    extent = _vkSurfaceCapabilities.currentExtent
                } };

                VkPipelineViewportStateCreateInfo viewportState;
                fixed (VkViewport* pViewport = viewport)
                {
                    fixed (VkRect2D* pScissor = scissor)
                    {
                        viewportState = new VkPipelineViewportStateCreateInfo
                        {
                            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_STATE_CREATE_INFO,
                            viewportCount = 1,
                            scissorCount = 1,
                            pViewports = pViewport,
                            pScissors = pScissor
                        };
                    }
                }

                VkPipelineRasterizationStateCreateInfo rasterizer = new VkPipelineRasterizationStateCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_CREATE_INFO,
                    polygonMode = VkPolygonMode.VK_POLYGON_MODE_FILL,
                    lineWidth = 1.0f,
                    cullMode = (uint)VkCullModeFlagBits.VK_CULL_MODE_NONE,
                    frontFace = VkFrontFace.VK_FRONT_FACE_CLOCKWISE
                };

                VkPipelineMultisampleStateCreateInfo multisampling = new VkPipelineMultisampleStateCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_MULTISAMPLE_STATE_CREATE_INFO,
                    rasterizationSamples = VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT,
                    minSampleShading = 1.0f
                };

                VkPipelineColorBlendAttachmentState colorBlendAttachment = new VkPipelineColorBlendAttachmentState
                {
                    colorWriteMask = (uint)(VkColorComponentFlagBits.VK_COLOR_COMPONENT_R_BIT
                        | VkColorComponentFlagBits.VK_COLOR_COMPONENT_G_BIT
                        | VkColorComponentFlagBits.VK_COLOR_COMPONENT_B_BIT
                        | VkColorComponentFlagBits.VK_COLOR_COMPONENT_A_BIT),
                    blendEnable = 0
                };

                VkPipelineColorBlendStateCreateInfo colorBlending = new VkPipelineColorBlendStateCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_COLOR_BLEND_STATE_CREATE_INFO,
                    attachmentCount = 1,
                    pAttachments = &colorBlendAttachment
                };

                VkDynamicState[] dynamicStates = new VkDynamicState[]
                {
                    VkDynamicState.VK_DYNAMIC_STATE_VIEWPORT,
                    VkDynamicState.VK_DYNAMIC_STATE_SCISSOR
                };
                VkPipelineDynamicStateCreateInfo dynamicState;
                VkGraphicsPipelineCreateInfo pipelineInfo;
                fixed (VkDynamicState* pDynamicStates = dynamicStates)
                {
                    dynamicState = new VkPipelineDynamicStateCreateInfo
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_DYNAMIC_STATE_CREATE_INFO,
                        dynamicStateCount = (uint)dynamicStates.Count(),
                        pDynamicStates = pDynamicStates
                    };

                    VkPipelineDepthStencilStateCreateInfo pDepthStencilStateCreateInfo = new VkPipelineDepthStencilStateCreateInfo()
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_DEPTH_STENCIL_STATE_CREATE_INFO,
                        depthTestEnable = 1,
                        depthWriteEnable = 1,
                        depthCompareOp = VkCompareOp.VK_COMPARE_OP_LESS,
                        depthBoundsTestEnable = 0,
                        stencilTestEnable = 0,
                    };

                    pipelineInfo = new VkGraphicsPipelineCreateInfo
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_CREATE_INFO,
                        stageCount = (uint)stages.Count(),
                        pStages = pStages,
                        pVertexInputState = &vertexInputInfo,
                        pInputAssemblyState = &inputAssembly,
                        pDepthStencilState = &pDepthStencilStateCreateInfo,
                        pViewportState = &viewportState,
                        pRasterizationState = &rasterizer,
                        pMultisampleState = &multisampling,
                        pColorBlendState = &colorBlending,
                        pDynamicState = &dynamicState,
                        layout = _vkPipelineLayout,
                        renderPass = _xrRenderPass != IntPtr.Zero ? _xrRenderPass : _vkRenderPass,
                        subpass = 0,
                        basePipelineIndex = -1
                    };
                    IntPtr pipeline;
                    VkResult result = vkCreateGraphicsPipelines(_vkDevice, IntPtr.Zero, 1, &pipelineInfo, null, &pipeline);
                    if (result != VkResult.VK_SUCCESS)
                        throw new Exceptions.FailedToInitializeVulkanException($"Failed to create graphics pipeline: {result}");
                    if (UseOpenXR)
                    {
                        IntPtr OXRPipeline;
                        result = vkCreateGraphicsPipelines(_vkDevice, IntPtr.Zero, 1, &pipelineInfo, null,
                            &OXRPipeline);
                        if (result != VkResult.VK_SUCCESS)
                            throw new Exceptions.FailedToInitializeVulkanException($"Failed to create graphics pipeline for OpenXR: {result}");
                        _xrPipeline = OXRPipeline;
                    }
                    
                    _vkPipeline = pipeline;
                    return pipeline;
                }
            }
        }
        finally
        {
            Marshal.FreeHGlobal(entryPointPtr);
        }
    }

    private void RecreateViewport()
    {
        // Viewports & scissors
        VkViewport viewport = new VkViewport
        {
            x = 0.0f,
            y = 0.0f,
            width = _vkSurfaceCapabilities.currentExtent.width,
            height = _vkSurfaceCapabilities.currentExtent.height,
            minDepth = 0.0f,
            maxDepth = 1.0f
        };
        VkRect2D scissor = new VkRect2D
        {
            offset = new VkOffset2D
            {
                x = 0,
                y = 0
            },
            extent = _vkSurfaceCapabilities.currentExtent
        };
        vkCmdSetViewport(_vkCommandBuffer, 0, 1, &viewport);
        vkCmdSetScissor(_vkCommandBuffer, 0, 1, &scissor);
    }

    public void SetXrObjects(OpenXRController leftController, OpenXRController rightController)
    {
        leftOXRController = leftController;
        rightOXRController = rightController;
    }

    public void RenderXrFrame(
        Vec3 rigpos,
        VulkanCamera camera,
        Action<int, Matrix4x4, Matrix4x4> drawScene)
    {
        if (shuttingDown || _disposed)
            return;
        
        CallExternalFunc("PollEvents", new object[] {  } );
        
        if (_xrRunning == null)
            throw new Exception("XR Running delegate is null.");

        if (_xrBeginFrame == null)
            throw new Exception("XR BeginFrame delegate is null.");

        if (_xrAcquire == null)
            throw new Exception("XR Acquire delegate is null.");

        if (_xrRelease == null)
            throw new Exception("XR Release delegate is null.");

        if (_xrEndFrame == null)
            throw new Exception("XR EndFrame delegate is null.");

        if (!_xrRunning())
            return;
        
        XrFrameInfo frame = _xrBeginFrame();

        if (frame.shouldRender)
        {
            if (camera == null)
                throw new Exception("RenderXrFrame received a null VulkanCamera.");
            Matrix4x4 camWorld = _scene.GetWorldMatrix(_scene.MainCamera);
            Vec3 pos = Matrix4x4.WorldPosition(camWorld);

            for (int eye = 0; eye < 2; eye++)
            {
                XrEyeView ev =
                    eye == 0
                        ? frame.leftEye
                        : frame.rightEye;

                var (view, proj) =
                    XrCameraMath.ForEye(
                        pos,
                        camera,
                        ev
                    );

                uint img = _xrAcquire(eye);

                RecordAndSubmitEye(
                    eye,
                    img,
                    () => drawScene(eye, view, proj)
                );

                _xrRelease(eye);
            }

            if (leftOXRController != null)
            {
                Vec3 p = (Vec3)GetPreservedVariable("leftHandPos");
                Quaternion r = (Quaternion)GetPreservedVariable("leftHandRot");
                bool leftControllerGrabbed = (bool)GetPreservedVariable("leftControllerGrab");
            
                r = new Quaternion(-r.X, -r.Y, r.Z, r.W);
            
                leftOXRController.SetControllerData(leftControllerGrabbed,
                    new Transform3D(XrCameraMath.PosToWorld(pos, _scene.MainCamera.GetComponent<VulkanCamera>(), p), r.ToEuler(), leftOXRController.ControllerTransform.scale));
            }
            if (rightOXRController != null)
            {
                Vec3 p = (Vec3)GetPreservedVariable("rightHandPos");
                Quaternion r = (Quaternion)GetPreservedVariable("rightHandRot");
                bool rightControllerGrabbed = (bool)GetPreservedVariable("rightControllerGrab");
            
                r = new Quaternion(-r.X, -r.Y, r.Z, r.W);
            
                rightOXRController.SetControllerData(rightControllerGrabbed,
                    new Transform3D(XrCameraMath.PosToWorld(pos, _scene.MainCamera.GetComponent<VulkanCamera>(), p), r.ToEuler(), rightOXRController.ControllerTransform.scale));
            }
            
            Vec3 left = new Vec3(
                frame.leftEye.px,
                frame.leftEye.py,
                frame.leftEye.pz);

            Vec3 right = new Vec3(
                frame.rightEye.px,
                frame.rightEye.py,
                frame.rightEye.pz);

            Vec3 headPos = (left + right) * 0.5f;
            Quaternion headRot = new Quaternion()
            {
                W = frame.leftEye.qw,
                X = frame.leftEye.qx,
                Y = frame.leftEye.qy,
                Z = frame.leftEye.qz,
            };
            _scene.MainCamera.Transform.rot = headRot.ToEuler();
            _scene.MainCamera.Transform.pos = headPos;
        }
        _xrEndFrame(frame.shouldRender);
    }
    
    public void SetCameraMatrices(Matrix4x4 view, Matrix4x4 proj)
    {
        var pc = new VkGraphicscontextHelpers.CameraPushConstants { View = view, Proj = proj };
        vkCmdPushConstants(_vkCommandBuffer, _vkPipelineLayout,
            (uint)VkShaderStageFlagBits.VK_SHADER_STAGE_VERTEX_BIT, 0, 128, &pc);
    }

    private const bool XrClearTest = false;

    private void RecordAndSubmitEye(int eye, uint img, Action draw)
    {
        IntPtr fence = _xrFence, cb = _xrCommandBuffer;
        var prev = _activeCmd;
        _activeCmd = cb;

        vkWaitForFences(_vkDevice, 1, &fence, 1, ulong.MaxValue);
        vkResetCommandBuffer(cb, 0);

        var begin = new VkCommandBufferBeginInfo { sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_BUFFER_BEGIN_INFO };
        vkBeginCommandBuffer(cb, &begin);

        VkClearValue* clear = stackalloc VkClearValue[2];
        var c = new VkClearColorValue();
        c.float32[3] = 1f;
        clear[0] = new VkClearValue { color = c };
        clear[1] = new VkClearValue { depthStencil = new VkClearDepthStencilValue { depth = 1f, stencil = 0 } };
        var rp = new VkRenderPassBeginInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_RENDER_PASS_BEGIN_INFO,
            renderPass = _xrRenderPass,
            framebuffer = _xrFramebuffers[eye][img],
            renderArea = new VkRect2D { extent = _xrExtent[eye] },
            clearValueCount = 2,
            pClearValues = clear
        };
        vkCmdBeginRenderPass(cb, &rp, VkSubpassContents.VK_SUBPASS_CONTENTS_INLINE);

        var vp = new VkViewport { width = _xrExtent[eye].width, height = _xrExtent[eye].height, maxDepth = 1f };
        var sc = new VkRect2D { extent = _xrExtent[eye] };
        vkCmdSetViewport(cb, 0, 1, &vp);
        vkCmdSetScissor(cb, 0, 1, &sc);

        draw();

        vkCmdEndRenderPass(cb);
        vkEndCommandBuffer(cb);

        var submit = new VkSubmitInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_SUBMIT_INFO,
            commandBufferCount = 1,
            pCommandBuffers = &cb
        };

        vkResetFences(_vkDevice, 1, &fence);
        var r = vkQueueSubmit(_vkQueue, 1, &submit, fence);
        if (r != VkResult.VK_SUCCESS)
        {
            Logger.LogError($"[OpenXR] vkQueueSubmit failed: {r}", LoggingTarget.Graphics);
            vkQueueWaitIdle(_vkQueue);
        }
        else
            vkWaitForFences(_vkDevice, 1, &fence, 1, ulong.MaxValue);

        _activeCmd = prev;
    }

    private void RecreateSwapchain()
    {
        VkGraphicscontextHelpers contextHelpers = new VkGraphicscontextHelpers();
        IntPtr vkSwapchainKHR = _vkSwapchainKHR;
        // Wait for device to finish
        vkDeviceWaitIdle(_vkDevice);

        // Destroy old resources
        foreach (var fb in _vkFramebuffers)
            vkDestroyFramebuffer(_vkDevice, fb, null);
        foreach (var iv in _vkImageViews)
            vkDestroyImageView(_vkDevice, iv, null);
        vmaDestroyImage(_vmaAllocator, _depth.img, _depth.alloc);
        vkDestroyImageView(_vkDevice, _depth.view, null);
        vkDestroySwapchainKHR(_vkDevice, _vkSwapchainKHR, null);

        // Query new surface capabilities
        VkSurfaceCapabilitiesKHR caps;
        vkGetPhysicalDeviceSurfaceCapabilitiesKHR(_vkPhysicalDevice, _vkSurfaceKHR, &caps);
        _vkSurfaceCapabilities = caps;
        
        VkExtent2D chosenExtent;
        if (caps.currentExtent.width == uint.MaxValue)
        {
            int w = _pendingWidth  > 0 ? _pendingWidth  : _w;
            int h = _pendingHeight > 0 ? _pendingHeight : _h;
            chosenExtent = new VkExtent2D
            {
                width  = (uint)System.Math.Clamp(w, (int)caps.minImageExtent.width,  (int)caps.maxImageExtent.width),
                height = (uint)System.Math.Clamp(h, (int)caps.minImageExtent.height, (int)caps.maxImageExtent.height)
            };
            caps.currentExtent = chosenExtent;
        }
        else
        {
            chosenExtent = caps.currentExtent;
        }
        
        _depth = CreateDepth(chosenExtent.width, chosenExtent.height);

        _vkSurfaceCapabilities = caps;
        _vkExtent2D = chosenExtent;

        // Recreate swapchain
        var swapchainInfo = new VkSwapchainCreateInfoKHR
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_SWAPCHAIN_CREATE_INFO_KHR,
            surface = (VkSurfaceKHR*)_vkSurfaceKHR,
            minImageCount = contextHelpers.ChooseNumImages(caps),
            imageFormat = _vkFormat,
            imageColorSpace = _surfaceFormat.colorSpace,
            imageExtent = caps.currentExtent,
            imageArrayLayers = 1,
            imageUsage = (uint)(VkImageUsageFlagBits.VK_IMAGE_USAGE_COLOR_ATTACHMENT_BIT | VkImageUsageFlagBits.VK_IMAGE_USAGE_TRANSFER_DST_BIT),
            imageSharingMode = VkSharingMode.VK_SHARING_MODE_EXCLUSIVE,
            preTransform = caps.currentTransform,
            compositeAlpha = VkCompositeAlphaFlagBitsKHR.VK_COMPOSITE_ALPHA_OPAQUE_BIT_KHR,
            presentMode = _presentMode,
            clipped = 1
        };
        vkCreateSwapchainKHR(_vkDevice, &swapchainInfo, null, &vkSwapchainKHR);

        _vkSwapchainKHR = vkSwapchainKHR;

        // Get new images
        uint imageCount;
        VkResult result;
        result = vkGetSwapchainImagesKHR(_vkDevice, _vkSwapchainKHR, &imageCount, null);
        if (result != VkResult.VK_SUCCESS)
            throw new Exceptions.FailedToInitializeVulkanException($"Failed to get swapchain images (vkGetSwapchainImagesKHR): {result}");

        _vkImages = new IntPtr[imageCount];
        _vkImageViews = new IntPtr[imageCount];

        fixed (IntPtr* images = _vkImages)
        {
            result = vkGetSwapchainImagesKHR(_vkDevice, _vkSwapchainKHR, &imageCount, images);
            if (result != VkResult.VK_SUCCESS)
                throw new Exceptions.FailedToInitializeVulkanException($"Failed to get swapchain images (vkGetSwapchainImagesKHR): {result}");
        }

        // Create new image views
        for (uint i = 0; i < imageCount; i++)
            _vkImageViews[i] = contextHelpers.CreateImageView(_vkDevice, _vkImages[i], _surfaceFormat.format,
                VkImageAspectFlagBits.VK_IMAGE_ASPECT_COLOR_BIT, VkImageViewType.VK_IMAGE_VIEW_TYPE_2D, 1, 1);

        // Recreate framebuffers
        _vkFramebuffers = new IntPtr[_vkImageViews.Length];
        for (int idx = 0; idx < _vkImageViews.Length; idx++)
            _vkFramebuffers[idx] = CreateFramebuffer(_vkRenderPass, _vkImageViews[idx], _depth.view,
                chosenExtent.width, chosenExtent.height);

        _vkExtent2D = caps.currentExtent;
    }

    public void SetVertexBuffer(IntPtr buffer, uint strideBytes, uint offset = 0)
    {
        _currentVertexBuffer = buffer;
        ulong off = offset;
        vkCmdBindVertexBuffers(_activeCmd, 0, 1, &buffer, &off);
    }

    public void SetIndexBuffer(IntPtr buffer, uint offset = 0) => vkCmdBindIndexBuffer(_activeCmd, buffer, offset, VkIndexType.VK_INDEX_TYPE_UINT32);

    public void SetPipeline(IntPtr pipeline)
    {
        _currentPipeline = pipeline;
        vkCmdBindPipeline(_activeCmd, VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS, pipeline);
    }

    public void Draw(uint vertexCount, uint startVertex = 0) => vkCmdDraw(_activeCmd, vertexCount, 1, startVertex, 0);

    public void DrawIndexed(uint indexCount, uint startIndex = 0, int baseVertex = 0) => vkCmdDrawIndexed(_activeCmd, indexCount, 1, startIndex, baseVertex, 0);

    private readonly List<DrawItem> _drawItems = new();
    private readonly List<(DrawItem item, Matrix4x4 mv, float z)> _sorted = new();
    
    private void GatherDrawItems()
    {
        _drawItems.Clear();
        
        if (_scene == null)
            throw new InvalidOperationException("GatherDrawItems: _scene is null");

        if (_scene.Entities == null)
            throw new InvalidOperationException("GatherDrawItems: _scene.Entities is null");
        
        foreach (Entity e in _scene.Entities)
        {
            if (!e.TryGetComponent<Mesh>(out var mesh) || mesh == null) continue;
            _drawItems.Add(new DrawItem
            {
                Mesh = mesh,
                World = _scene.GetWorldMatrix(e)
            });
            if (mesh.vertexBuffer == IntPtr.Zero || mesh.geometryDirty)
            {
                if (mesh.vertexBuffer != IntPtr.Zero) DestroyBuffer(mesh.vertexBuffer);
                if (mesh.indexBuffer  != IntPtr.Zero) DestroyBuffer(mesh.indexBuffer);
                BuildStaticMesh(mesh);
                mesh.geometryDirty = false;
            }
        }
    }
    
    (IntPtr image, IntPtr alloc, IntPtr view) CreateDepth(uint w, uint h)
    {
        var ci = new VkImageCreateInfo {
            sType = VkStructureType.VK_STRUCTURE_TYPE_IMAGE_CREATE_INFO,
            imageType = VkImageType.VK_IMAGE_TYPE_2D,
            format = VkFormat.VK_FORMAT_D32_SFLOAT,
            extent = new VkExtent3D { width = w, height = h, depth = 1 },
            mipLevels = 1, arrayLayers = 1,
            samples = VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT,
            tiling = VkImageTiling.VK_IMAGE_TILING_OPTIMAL,
            usage = (uint)VkImageUsageFlagBits.VK_IMAGE_USAGE_DEPTH_STENCIL_ATTACHMENT_BIT,
            sharingMode = VkSharingMode.VK_SHARING_MODE_EXCLUSIVE,
            initialLayout = VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED
        };
        var ai = new VmaAllocationCreateInfo { usage = VmaMemoryUsage.VMA_MEMORY_USAGE_AUTO };
        IntPtr img, a;
        VkResult res = vmaCreateImage(_vmaAllocator, &ci, &ai, &img, &a, null);
        if (res != VkResult.VK_SUCCESS)
            throw new AngeneException($"Failed to create Vulkan image with VMA: {res}");
        var view = contextHelpers.CreateImageView(_vkDevice, img, VkFormat.VK_FORMAT_D32_SFLOAT,
            VkImageAspectFlagBits.VK_IMAGE_ASPECT_DEPTH_BIT, VkImageViewType.VK_IMAGE_VIEW_TYPE_2D, 1, 1);
        return (img, a, view);
    }
    
    public void BeginFrame(uint clearColor)
    {
        if (shuttingDown || _disposed) return;
        VkResult result;
        IntPtr fence = _vkFenceInFlight;
        uint imageIndex;
        
        vkWaitForFences(_vkDevice, 1, &fence, 1, ulong.MaxValue);

        GatherDrawItems();

        result = vkAcquireNextImageKHR(_vkDevice, _vkSwapchainKHR, ulong.MaxValue,
            _vkSemaphoreImageAvailable, IntPtr.Zero, &imageIndex);
        if (result == VkResult.VK_ERROR_OUT_OF_DATE_KHR)
        {
            RecreateSwapchain();

            result = vkAcquireNextImageKHR(_vkDevice, _vkSwapchainKHR, ulong.MaxValue, _vkSemaphoreImageAvailable, IntPtr.Zero, &imageIndex);
        }

        if (result != VkResult.VK_SUCCESS && result != VkResult.VK_SUBOPTIMAL_KHR)
            throw new Exception($"Failed to acquire next image (vkAcquireNextImageKHR): {result}");

        _currentImageIndex = (int)imageIndex;

        vkResetCommandBuffer(_vkCommandBuffer, 0);

        VkCommandBufferBeginInfo beginInfo = new VkCommandBufferBeginInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_BUFFER_BEGIN_INFO
        };
        result = vkBeginCommandBuffer(_vkCommandBuffer, &beginInfo);
        if (result != VkResult.VK_SUCCESS)
            throw new Exception($"Failed to begin recording command buffer (vkBeginCommandBuffer): {result}");

        _activeCmd = _vkCommandBuffer;

        VkClearColorValue clearColorValue = new VkClearColorValue();
        clearColorValue.float32[0] = ((clearColor >> 16) & 0xFF) / 255.0f; // R
        clearColorValue.float32[1] = ((clearColor >> 8) & 0xFF) / 255.0f;  // G
        clearColorValue.float32[2] = (clearColor & 0xFF) / 255.0f;         // B
        clearColorValue.float32[3] = ((clearColor >> 24) & 0xFF) / 255.0f; // A
        VkClearValue* clear = stackalloc VkClearValue[2];
        clear[0] = new VkClearValue { color = clearColorValue };
        clear[1] = new VkClearValue { depthStencil = new VkClearDepthStencilValue { depth = 1f, stencil = 0 } };

        VkRenderPassBeginInfo renderPassInfo = new VkRenderPassBeginInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_RENDER_PASS_BEGIN_INFO,
            renderPass = _vkRenderPass,
            framebuffer = _vkFramebuffers[_currentImageIndex],
            renderArea = new VkRect2D
            {
                offset = new VkOffset2D { x = 0, y = 0 },
                extent = _vkSurfaceCapabilities.currentExtent
            },
            clearValueCount = 2,
            pClearValues = clear
        };
        vkCmdBeginRenderPass(_vkCommandBuffer, &renderPassInfo, VkSubpassContents.VK_SUBPASS_CONTENTS_INLINE);

        VkViewport viewport = new VkViewport
        {
            x = 0.0f, y = 0.0f,
            width = _vkSurfaceCapabilities.currentExtent.width,
            height = _vkSurfaceCapabilities.currentExtent.height,
            minDepth = 0.0f, maxDepth = 1.0f
        };
        vkCmdSetViewport(_vkCommandBuffer, 0, 1, &viewport);

        VkRect2D scissor = new VkRect2D
        {
            offset = new VkOffset2D { x = 0, y = 0 },
            extent = _vkSurfaceCapabilities.currentExtent
        };
        vkCmdSetScissor(_vkCommandBuffer, 0, 1, &scissor);

        VulkanCamera cam = _scene.MainCamera.GetComponent<VulkanCamera>();
        if (UseOpenXR)
        {
            Matrix4x4? headView = null;
            RenderXrFrame(_scene.MainCamera.Transform.pos, cam, (eye, view, proj) =>
            {
                if (eye == 0) headView = view;
                DrawScene(view, proj, cam);
            });
        }
        else
        {
            var m = cam.GetMatrices(_scene.GetWorldMatrix(_scene.MainCamera));
            DrawScene(m.View, m.Projection, cam);
        }
    }
    
    private void DrawScene(Matrix4x4 view, Matrix4x4 proj, VulkanCamera cam)
    {
        if (_vkPipeline == IntPtr.Zero)
            throw new AngeneException("No pipeline");

        SetPipeline(VkPipeline);

        _sorted.Clear();

        foreach (DrawItem item in _drawItems)
        {
            if (item.Mesh == null)
                throw new AngeneException(
                    "DrawScene: A DrawItem has a null Mesh reference.");

            if (item.Mesh.Shader == null)
                throw new AngeneException(
                    $"DrawScene: Mesh '{item.Mesh.targetEnt.name}' has a null Shader reference.");

            Matrix4x4 mv = view * item.World;
            float depth = cam.TransformPoint(mv, new Vec3(0, 0, 0)).Z;

            _sorted.Add((item, mv, depth));
        }

        _sorted.Sort((a, b) =>
        {
            int aQueue = (int)a.item.Mesh.Shader.Queue
                         + a.item.Mesh.Shader.id;

            int bQueue = (int)b.item.Mesh.Shader.Queue
                         + b.item.Mesh.Shader.id;

            int queueCompare = aQueue.CompareTo(bQueue);

            if (queueCompare != 0)
                return queueCompare;

            return a.Item3.CompareTo(b.Item3);
        });

        foreach (var (item, mv, _) in _sorted)
            DrawMesh(item.Mesh, mv, proj);
    }

    private void DrawMesh(Mesh mesh, Matrix4x4 modelView, Matrix4x4 proj)
    {
        var pc = new VkGraphicscontextHelpers.CameraPushConstants { Proj = proj, View = modelView };
        vkCmdPushConstants(_activeCmd, _vkPipelineLayout,
            (uint)VkShaderStageFlagBits.VK_SHADER_STAGE_VERTEX_BIT, 0, 128, &pc);
        SetVertexBuffer(mesh.vertexBuffer, 28);
        SetIndexBuffer(mesh.indexBuffer);
        DrawIndexed((uint)mesh.indexCount);
    }
    
    private void BuildStaticMesh(Mesh mesh)
    {
        var v = new List<float>(); var idx = new List<uint>();
        foreach (var f in mesh.Faces)
        {
            uint b = (uint)(v.Count / 7);
            foreach (var ci in new[]{f.a, f.b, f.c, f.d})
            {
                var p = mesh.Corners[ci]; var c = f.material.Value; // FaceColor
                v.AddRange(new[]{ p.X, p.Y, p.Z, c.R, c.G, c.B, c.A });
            }
            idx.AddRange(new[]{ b, b+1, b+2,  b, b+2, b+3 });
        }
        mesh.vertexBuffer = CreateVertexBuffer(MemoryMarshal.AsBytes(CollectionsMarshal.AsSpan(v)).ToArray(), 28);
        mesh.indexBuffer  = CreateIndexBuffer(idx.ToArray());
        mesh.indexCount   = idx.Count;
    }

    public void EndFrame()
    {
        if (shuttingDown || _disposed) return;

        vkCmdEndRenderPass(_vkCommandBuffer);
        VkResult result = vkEndCommandBuffer(_vkCommandBuffer);
        if (result != VkResult.VK_SUCCESS)
            throw new Exception($"Failed to record command buffer (vkEndCommandBuffer): {result}");

        IntPtr waitSemaphore = _vkSemaphoreImageAvailable;
        IntPtr signalSemaphore = _vkSemaphoreRenderFinished;
        IntPtr commandBuffer = _vkCommandBuffer;
        VkPipelineStageFlagBits waitStage = VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT;

        VkSubmitInfo submitInfo = new VkSubmitInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_SUBMIT_INFO,
            waitSemaphoreCount = 1,
            pWaitSemaphores = &waitSemaphore,
            pWaitDstStageMask = (uint*)&waitStage,
            commandBufferCount = 1,
            pCommandBuffers = &commandBuffer,
            signalSemaphoreCount = 1,
            pSignalSemaphores = &signalSemaphore
        };

        IntPtr fence = _vkFenceInFlight;
        vkResetFences(_vkDevice, 1, &fence);
        result = vkQueueSubmit(_vkQueue, 1, &submitInfo, _vkFenceInFlight);
        if (result != VkResult.VK_SUCCESS)
            throw new Exception($"Failed to submit draw command buffer (vkQueueSubmit): {result}");

        IntPtr swapchain = _vkSwapchainKHR;
        uint imageIndex = (uint)_currentImageIndex;
        VkPresentInfoKHR presentInfo = new VkPresentInfoKHR
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_PRESENT_INFO_KHR,
            waitSemaphoreCount = 1,
            pWaitSemaphores = &signalSemaphore,
            swapchainCount = 1,
            pSwapchains = (VkSwapchainKHR**)&swapchain,
            pImageIndices = &imageIndex
        };

        result = vkQueuePresentKHR(_vkQueue, &presentInfo);
        if (result == VkResult.VK_ERROR_OUT_OF_DATE_KHR || result == VkResult.VK_SUBOPTIMAL_KHR)
            RecreateSwapchain();
        else if (result == VkResult.VK_ERROR_DEVICE_LOST)
            return;
        else if (result != VkResult.VK_SUCCESS && result != VkResult.VK_SUBOPTIMAL_KHR)
            throw new Exception($"Failed to present (vkQueuePresentKHR): {result}");

        if (_needsRecreateSwapchain)
        {
            _needsRecreateSwapchain = false;
            RecreateSwapchain();
        }
    }
    
    private int _pendingWidth, _pendingHeight; // new fields

    public void Resize(int width, int height)
    {
        if (width == 0 || height == 0) return;
        _pendingWidth = width;
        _pendingHeight = height;
        _needsRecreateSwapchain = true;
    }

    private void BindXr()
    {
        var t = Assembly
                    .LoadFrom(xrDll)
                    .GetType("Angene.Extensions.XR.OpenXR")
                ?? throw new Exception("Could not find OpenXR type.");

        T Bind<T>(string name) where T : Delegate =>
            (T)t.GetMethod(
                name,
                BindingFlags.Static | BindingFlags.Public
            )!.CreateDelegate(typeof(T));

        _xrBeginFrame = Bind<Func<Types.XrFrameInfo>>("BeginXrFrame");
        _xrAcquire    = Bind<Func<int, uint>>("AcquireEyeImage");
        _xrRelease    = Bind<Action<int>>("ReleaseEyeImage");
        _xrEndFrame   = Bind<Action<bool>>("EndXrFrame");
        _xrRunning    = Bind<Func<bool>>("get_Running");

        Logger.LogDebug(
            "[OpenXR] XR delegates successfully bound.",
            LoggingTarget.External
        );
    }

    public void Cleanup()
    {
        if (_disposed) return;

        shuttingDown = true;
        if (_vkDevice != IntPtr.Zero)
        {
            vkDeviceWaitIdle(_vkDevice);
        }

        if (UseOpenXR)
        {
            CallExternalFunc("Cleanup", new object[] { });
            if (_destroyFunc != null && _debugMessenger != IntPtr.Zero)
                _destroyFunc(_vkInstance, _debugMessenger, null);
        }
        // destroy vma
        foreach (var entry in _vmaBuffers.Values)
            vmaDestroyBuffer(_vmaAllocator, entry.Buffer, entry.Allocation);
        _vmaBuffers.Clear();
        
        vkDestroyImageView(_vkDevice, _depth.view, null);
        vmaDestroyImage(_vmaAllocator, _depth.img, _depth.alloc);
        if (UseOpenXR)
        {
            for (int eye = 0; eye < 2; eye++)
            {
                var depth = _xrDepth[eye];
                vkDestroyImageView(_vkDevice, depth.view, null);
                vmaDestroyImage(_vmaAllocator, depth.img, depth.alloc);
            }
        }
        
        // destroy memory allocators
        lock (_allocatorLock)
        {
            if (_vmaAllocator != null)
            {
                vmaDestroyBuffer(_vmaAllocator, _vma_VkBuffer, _vmaAllocation);
                vmaDestroyAllocator(_vmaAllocator);
                _vmaAllocator = IntPtr.Zero;
            }
        }
        // destroy shaders
        foreach (IntPtr module in shaderModules)
            vkDestroyShaderModule(_vkDevice, module, null);
        // destroy command pool
        vkDestroyCommandPool(_vkDevice, _vkCommandPool, null);
        // destroy image views
        foreach (IntPtr imageView in _vkImageViews)
            vkDestroyImageView(_vkDevice, imageView, null);
        // destroy semaphores and fence
        vkDestroySemaphore(_vkDevice, _vkSemaphoreImageAvailable, null);
        vkDestroySemaphore(_vkDevice, _vkSemaphoreRenderFinished, null);
        vkDestroyFence(_vkDevice, _vkFenceInFlight, null);
        // destroy swapchain
        vkDestroySwapchainKHR(_vkDevice, _vkSwapchainKHR, null);
        // destroy framebuffers
        foreach (IntPtr framebuffer in _vkFramebuffers)
            vkDestroyFramebuffer(_vkDevice, framebuffer, null);
        // destroy pipeline layout
        vkDestroyPipeline(_vkDevice, _vkPipeline, null);
        vkDestroyPipelineLayout(_vkDevice, _vkPipelineLayout, null);
        vkDestroyRenderPass(_vkDevice, _vkRenderPass, null);
        // destroy device
        if (!_sharingDevice)
        {
            if (_vkDevice != IntPtr.Zero)
                vkDestroyDevice(_vkDevice, null);
            // kill surface
            if (_vkSurfaceKHR != IntPtr.Zero)
                vkDestroySurfaceKHR(_vkInstance, _vkSurfaceKHR, null);
            // kill instance
            if (_vkInstance != IntPtr.Zero)
                vkDestroyInstance(_vkInstance, null);
        }
        _vkDevice = IntPtr.Zero;
        _vkInstance = IntPtr.Zero;
        _vkSurfaceKHR = IntPtr.Zero;
        _disposed = true;

        GC.SuppressFinalize(this);
    }

    public bool isDisposed() => _disposed;

    public void Dispose()
    {
        Cleanup();
        GC.SuppressFinalize(this);
    }

    ~VkGraphicsContext()
    {
        Cleanup();
    }
}

public unsafe class VkGraphicscontextHelpers
{
    public static uint XrToVkVersion(ulong xr, uint cap = (1u << 22) | (3u << 12))
    {
        ulong major = (xr >> 48) & 0xFFFF;
        ulong minor = (xr >> 32) & 0xFFFF;
        uint patch  = (uint)(xr & 0xFFF);

        if (major > 1) return cap;
        uint v = (1u << 22) | ((uint)System.Math.Min(minor, 0x3FFul) << 12) | patch;
        return System.Math.Min(v, cap);
    }
    
    public struct CameraPushConstants
    {
        public Matrix4x4 View;
        public Matrix4x4 Proj;
    }
    public void recordCommandBuffer(IntPtr commandBuffer, int imageIndex, IntPtr renderPass, IntPtr[] framebuffers,  VkSurfaceCapabilitiesKHR _surfaceCapabilities, IntPtr _vkPipeline, int vertices, Matrix4x4 viewMatrix, Matrix4x4 projMatrix, IntPtr vkPipelineLayout)
    {
        VkCommandBufferBeginInfo beginInfo = new VkCommandBufferBeginInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_BUFFER_BEGIN_INFO,
            flags = 0, // Optional
            pInheritanceInfo = null // Optional
        };

        VkResult result = vkBeginCommandBuffer(commandBuffer, &beginInfo);
        if (result != VkResult.VK_SUCCESS)
            throw new Exceptions.FailedToInitializeVulkanException($"Failed to begin recording command buffer (vkBeginCommandBuffer): {result}");

        // buh colors
        VkClearColorValue clearColorValue = new VkClearColorValue();
        clearColorValue.float32[0] = 0.0f; // R
        clearColorValue.float32[1] = 0.0f; // G
        clearColorValue.float32[2] = 0.0f; // B
        clearColorValue.float32[3] = 1.0f; // A
        VkClearValue clearColor = new VkClearValue
        {
            color = clearColorValue
        };

        // new render pass
        VkRenderPassBeginInfo renderPassInfo = new VkRenderPassBeginInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_RENDER_PASS_BEGIN_INFO,
            renderPass = renderPass,
            framebuffer = framebuffers[imageIndex],
            renderArea = new VkRect2D
            {
                offset = new VkOffset2D
                {
                    x = 0,
                    y = 0
                },
                extent = _surfaceCapabilities.currentExtent,
            },
            clearValueCount = 1,
            pClearValues = &clearColor
        };
        vkCmdBeginRenderPass(commandBuffer, &renderPassInfo, VkSubpassContents.VK_SUBPASS_CONTENTS_INLINE);

        vkCmdBindPipeline(commandBuffer, VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS, _vkPipeline);

        VkViewport viewport = new VkViewport
        {
            x = 0.0f,
            y = 0.0f,
            width = _surfaceCapabilities.currentExtent.width,
            height = _surfaceCapabilities.currentExtent.height,
            minDepth = 0.0f,
            maxDepth = 1.0f,
        };
        vkCmdSetViewport(commandBuffer, 0, 1, &viewport);

        VkRect2D scissor = new VkRect2D
        {
            offset = new VkOffset2D
            {
                x = 0,
                y = 0
            },
            extent = _surfaceCapabilities.currentExtent
        };
        vkCmdSetScissor(commandBuffer, 0, 1, &scissor);

        CameraPushConstants pc = new CameraPushConstants { View = viewMatrix, Proj = projMatrix };
        vkCmdPushConstants(commandBuffer, vkPipelineLayout, (uint)VkShaderStageFlagBits.VK_SHADER_STAGE_VERTEX_BIT, 0, (uint)sizeof(CameraPushConstants), &pc);

        vkCmdDraw(commandBuffer, (uint)vertices, 1, 0, 0);

    }
    public QueueFamilyIndices? findQueueFamilies(IntPtr device, IntPtr surface)
    {
        QueueFamilyIndices indices = new QueueFamilyIndices();

        uint queueFamilyCount = 0;
        vkGetPhysicalDeviceQueueFamilyProperties(device, &queueFamilyCount, null);

        VkQueueFamilyProperties[] queueFamilies = new VkQueueFamilyProperties[queueFamilyCount];
        fixed (VkQueueFamilyProperties* pQueueFamilies = queueFamilies)
            vkGetPhysicalDeviceQueueFamilyProperties(device, &queueFamilyCount, pQueueFamilies);

        int i = 0;
        foreach (VkQueueFamilyProperties queueFamily in queueFamilies)
        {
            if ((queueFamily.queueFlags & (uint)VkQueueFlagBits.VK_QUEUE_GRAPHICS_BIT) != 0)
                indices.graphicsFamily = (uint)i;

            uint presentSupport = 0;
            vkGetPhysicalDeviceSurfaceSupportKHR(device, (uint)i, surface, &presentSupport);
            if (presentSupport != 0)
                indices.presentFamily = (uint)i;

            if (indices.isComplete())
                break;

            i++;
        }

        if (!indices.isComplete())
            return null;

        return indices;
    }
    public VkSurfaceFormatKHR ChooseSurfaceFormatAndColorSpace(VkSurfaceFormatKHR[] surfaceFormats)
    {
        for (int i = 0; i < surfaceFormats.Count(); i++)
            if ((surfaceFormats[i].format == VkFormat.VK_FORMAT_B8G8R8A8_SRGB) && (surfaceFormats[i].colorSpace == VkColorSpaceKHR.VK_COLOR_SPACE_SRGB_NONLINEAR_KHR))
                return surfaceFormats[i];

        return surfaceFormats[0];
    }
    public IntPtr CreateImageView(IntPtr device, IntPtr image, VkFormat format, VkImageAspectFlagBits aspectFlags, VkImageViewType viewType, uint layerCount, uint mipLevels)
    {
        
        VkImageViewCreateInfo viewInfo = new VkImageViewCreateInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_IMAGE_VIEW_CREATE_INFO,
            pNext = null,
            flags = 0,
            image = image,
            viewType = viewType,
            format = format,
            components =
            {
                r = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY,
                g = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY,
                b = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY,
                a = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY
            },
            subresourceRange =
            {
                aspectMask = (uint)aspectFlags,
                baseMipLevel = 0,
                levelCount = mipLevels,
                baseArrayLayer = 0,
                layerCount = layerCount
            }
        };
        IntPtr imageView = IntPtr.Zero;
        VkResult res = vkCreateImageView(device, &viewInfo, null, &imageView);
        if (res != VkResult.VK_SUCCESS)
            throw new Exceptions.FailedToInitializeVulkanException($"Failed to create image view (vkCreateImageView): {res}");
        return imageView;
    }
    public VkPresentModeKHR ChoosePresentationMode(VkPresentModeKHR[] presentModes, VkPresentModeKHR wantedPresentationMode)
    {
        if (presentModes.Contains(wantedPresentationMode)) // check for developer's chosen presentation mode
            return wantedPresentationMode;

        for (int i = 0; i < presentModes.Count(); i++)
            if (presentModes[i] == VkPresentModeKHR.VK_PRESENT_MODE_MAILBOX_KHR)
                return presentModes[i];

        // Default to FIFO because it is always supported
        return VkPresentModeKHR.VK_PRESENT_MODE_FIFO_KHR;
    }
    public uint ChooseNumImages(VkSurfaceCapabilitiesKHR caps)
    {
        uint requestedNumImages = caps.minImageCount + 1;

        uint finalNumImages = 0;

        if ((caps.maxImageCount > 0) && (requestedNumImages > caps.maxImageCount))
            finalNumImages = caps.maxImageCount;
        else
            finalNumImages = requestedNumImages;
        return finalNumImages;
    }
    public void SelectPhysicalDeviceAndLogicalDevice(
        IntPtr instance,
        out IntPtr physicalDevice,
        out IntPtr device,
        out IntPtr graphicsQueue)
    {
        // Enumerate physical devices
        uint deviceCount = 0;
        VkResult enumResult = vkEnumeratePhysicalDevices(instance, &deviceCount, null);
        if (enumResult != VkResult.VK_SUCCESS)
            throw new Exception($"Failed to enumerate physical devices: {enumResult}");
        if (deviceCount == 0)
            throw new Exception("No Vulkan-compatible GPUs found.");

        IntPtr* devices = stackalloc IntPtr[(int)deviceCount];
        enumResult = vkEnumeratePhysicalDevices(instance, &deviceCount, devices);
        if (enumResult != VkResult.VK_SUCCESS)
            throw new Exception($"Failed to enumerate physical devices: {enumResult}");

        // Pick the first available physical device
        physicalDevice = devices[0];

        // Find queue families
        uint queueFamilyCount = 0;
        vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice, &queueFamilyCount, null);
        if (queueFamilyCount == 0)
            throw new Exception("Physical device reports no queue families.");

        VkQueueFamilyProperties* queueFamilies = stackalloc VkQueueFamilyProperties[(int)queueFamilyCount];
        vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice, &queueFamilyCount, queueFamilies);

        int graphicsFamilyIndex = -1;
        for (uint i = 0; i < queueFamilyCount; i++)
        {
            if ((queueFamilies[i].queueFlags & (uint)VkQueueFlagBits.VK_QUEUE_GRAPHICS_BIT) != 0)
            {
                graphicsFamilyIndex = (int)i;
                break;
            }
        }

        if (graphicsFamilyIndex == -1)
            throw new Exception("Failed to find a valid graphics queue family.");

        // Create logical device
        float queuePriority = 1.0f;
        VkDeviceQueueCreateInfo queueCreateInfo = new VkDeviceQueueCreateInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO,
            queueFamilyIndex = (uint)graphicsFamilyIndex,
            queueCount = 1,
            pQueuePriorities = &queuePriority
        };
        
        IntPtr deviceExtensionPtr = Marshal.StringToHGlobalAnsi("VK_KHR_swapchain");
        try
        {
            sbyte* deviceExtension = (sbyte*)deviceExtensionPtr;

            VkDeviceCreateInfo deviceCreateInfo = new VkDeviceCreateInfo
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO,
                queueCreateInfoCount = 1,
                pQueueCreateInfos = &queueCreateInfo,
                enabledExtensionCount = 1,
                ppEnabledExtensionNames = &deviceExtension
            };

            IntPtr deviceOut;
            VkResult result = vkCreateDevice(physicalDevice, &deviceCreateInfo, null, out deviceOut);
            if (result != VkResult.VK_SUCCESS)
                throw new Exception($"Failed to create logical device: {result}");

            device = deviceOut;
        }
        finally
        {
            Marshal.FreeHGlobal(deviceExtensionPtr);
        }

        // Retrieve the command queue handle
        IntPtr queueOut;
        vkGetDeviceQueue(device, (uint)graphicsFamilyIndex, 0, out queueOut);
        graphicsQueue = queueOut;
    }

    public void CreateDevice(
        IntPtr physicalDevice,
        string[] deviceExtensions,
        Func<IntPtr, IntPtr> deviceFactory,
        out IntPtr device,
        out IntPtr graphicsQueue,
        out uint queueFamily
    )
    {
        uint queueFamilyCount = 0;
        vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice, &queueFamilyCount, null);
        if (queueFamilyCount == 0)
            throw new Exception("Physical device reports no queue families.");

        VkQueueFamilyProperties* queueFamilies = stackalloc VkQueueFamilyProperties[(int)queueFamilyCount];
        vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice, &queueFamilyCount, queueFamilies);

        int graphicsFamilyIndex = -1;
        for (uint i = 0; i < queueFamilyCount; i++)
        {
            if ((queueFamilies[i].queueFlags & (uint)VkQueueFlagBits.VK_QUEUE_GRAPHICS_BIT) != 0)
            {
                graphicsFamilyIndex = (int)i;
                break;
            }
        }

        if (graphicsFamilyIndex == -1)
            throw new Exception("Failed to find a valid graphics queue family.");
        
        // Create logical device
        float queuePriority = 1.0f;
        VkDeviceQueueCreateInfo queueCreateInfo = new VkDeviceQueueCreateInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO,
            queueFamilyIndex = (uint)graphicsFamilyIndex,
            queueCount = 1,
            pQueuePriorities = &queuePriority
        };
        
        queueFamily = (uint)graphicsFamilyIndex;
        IntPtr deviceExtensionPtr = Marshal.StringToHGlobalAnsi("VK_KHR_swapchain");
        try
        {
            sbyte* deviceExtension = (sbyte*)deviceExtensionPtr;
            VkDeviceCreateInfo deviceCreateInfo = new VkDeviceCreateInfo
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO,
                queueCreateInfoCount = 1,
                pQueueCreateInfos = &queueCreateInfo,
                enabledExtensionCount = 1,
                ppEnabledExtensionNames = &deviceExtension
            };

            if (deviceFactory != null)
                device = deviceFactory((IntPtr)(&deviceCreateInfo));
            else
            {
                VkResult result = vkCreateDevice(physicalDevice, &deviceCreateInfo, null, out IntPtr d);
                if (result != VkResult.VK_SUCCESS) throw new Exception($"Failed to create logical device: {result}");
                device = d;
            }
        }
        finally { Marshal.FreeHGlobal(deviceExtensionPtr); }

        vkGetDeviceQueue(device, queueFamily, 0, out IntPtr q);
        graphicsQueue = q;
    }
}
