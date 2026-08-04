using Angene.Common;
using Angene.Graphics;
using Angene.Windows;
using Angene.X11.Interop;
using static Angene.Vulkan.Interop.Methods;
using static Angene.Vulkan.Interop.Structs;
using static Angene.Vulkan.Interop.Enumerators;
using static Angene.Vulkan.Interop.VulkanMemoryAllocator;
using static Angene.Vulkan.Interop.VulkanMemoryAllocator.Methods;
using System.Runtime.InteropServices;
using System.Text;

public unsafe class VkGraphicsContext : IVkGraphicsContext, IDisposable
{
    private IntPtr _vkInstance;
    private IntPtr _vkPhysicalDevice;
    private IntPtr _vkDevice;
    private IntPtr _vkQueue;
    private IntPtr _vkSurfaceKHR;
    private IntPtr _vkSwapchainKHR;
    private VkFormat _vkFormat;
    private VkExtent2D _vkExtent2D;
    private int _swapchainImageCount;
    private int _currentImageIndex;
    private IntPtr _vkCommandPool;
    private IntPtr _vkCommandBuffer;
    private IntPtr _vkRenderPass;
    private IntPtr _vkFramebuffer;
    private IntPtr _vkPipeline;
    private IntPtr _vkSemaphoreImageAvailable;
    private IntPtr _vkSemaphoreRenderFinished;
    private IntPtr _vkFenceInFlight;
    private bool _disposed;
    private bool _sharingDevice;

    public IntPtr VkPhysicalDevice => _vkPhysicalDevice;
    public IntPtr VkDevice => _vkDevice;
    public IntPtr VkQueue => _vkQueue;
    public IntPtr VkSurfaceKHR => _vkSurfaceKHR;
    public IntPtr VkInstance => _vkInstance;
    public IntPtr VkSwapchainKHR => _vkSwapchainKHR;
    public VkFormat VkFormat => _vkFormat;
    public VkExtent2D VkExtent2D => _vkExtent2D;
    public int SwapchainImageCount => _swapchainImageCount;
    public int CurrentImageIndex => _currentImageIndex;
    public IntPtr VkCommandPool => _vkCommandPool;
    public IntPtr VkCommandBuffer => _vkCommandBuffer;
    public IntPtr VkRenderPass => _vkRenderPass;
    public IntPtr VkFramebuffer => _vkFramebuffer;
    public IntPtr VkPipeline => _vkPipeline;
    public IntPtr VkSemaphoreImageAvailable => _vkSemaphoreImageAvailable;
    public IntPtr VkSemaphoreRenderFinished => _vkSemaphoreRenderFinished;
    public IntPtr VkFenceInFlight => _vkFenceInFlight;

    public IntPtr Handle => _vkDevice;
    public IntPtr ContextHandle => _vkInstance;


    private VmaAllocator* _vmaAllocator;
    private VkBuffer* _vma_VkBuffer;
    private VmaAllocation* _vmaAllocation;
    private readonly IntPtr _hwnd;
    private readonly int _w, _h;

    public VkGraphicsContext(IntPtr hwnd, XLib._XDisplay* display, int width, int height, IntPtr existingDevice, IntPtr existingContext, Types.AppInfo? currentAppInfo = null)
    {
        _hwnd = hwnd;
        _w = width;
        _h = height;

        try
        {
            if (existingDevice != IntPtr.Zero && existingContext != IntPtr.Zero)
            {
                _vkDevice = existingDevice;
                _vkInstance = existingContext;
                _sharingDevice = true;
                return;
            }

            VkGraphicsContextHelpers ContextHelpers = new VkGraphicsContextHelpers();

            IntPtr appNamePtr = IntPtr.Zero;
            IntPtr functionPointerName = IntPtr.Zero;
            IntPtr engineNamePtr = Marshal.StringToHGlobalAnsi("Angene");


            VkApplicationInfo appInfo;
            VkInstanceCreateInfo createInfo;
            VkResult result;

#region App Info (appInfo)
            try
            {
                if (currentAppInfo != null)
                {
                    appNamePtr = Marshal.StringToHGlobalAnsi(currentAppInfo.AppName);
                    appInfo = new VkApplicationInfo
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_APPLICATION_INFO,
                        pApplicationName = (sbyte*)appNamePtr,
                        applicationVersion = (uint)Math.Round(currentAppInfo.AppVersion),
                        pEngineName = (sbyte*)engineNamePtr,
                        engineVersion = (uint)Math.Round(Angene.Common.Settings.Settings.Instance.GetSetting<float>("Main.VersionFloat")), // cancer
                        apiVersion = (uint)((1 << 22) | (3 << 12) | 0)
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
                        engineVersion = (uint)Math.Round(Angene.Common.Settings.Settings.Instance.GetSetting<float>("Main.VersionFloat")), // cancer
                        apiVersion = (uint)((1 << 22) | (3 << 12) | 0)
                    };
                }
#endregion
#region Extensions
                // Extensions //
                var required = new List<string> { "VK_KHR_surface", "VK_KHR_xlib_surface", "VK_KHR_get_surface_capabilities2", "VK_EXT_surface_maintenance1" };
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
                foreach (var r in required)
                {
                    if (!available.Contains(r))
                        throw new Exception($"Required Vulkan extension missing: {r}");
                    toEnable.Add(r);
                }
                foreach (var o in optional)
                {
                    if (available.Contains(o))
                        toEnable.Add(o);
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

                        // vkCreateInstance(...) must be called HERE, inside this fixed block,
                        // since ppEnabledExtensionNames is only valid within it
                        result = vkCreateInstance(&createInfo, null, out instanceHandle);
                        if (result != VkResult.VK_SUCCESS)
                            throw new Exception($"Failed to create Vulkan instance: {result}");
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
#region Surface Creation (_vkSurfaceKHR) (XLib)
                IntPtr surface = IntPtr.Zero;
                VkXlibSurfaceCreateInfoKHR create_info = new VkXlibSurfaceCreateInfoKHR
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_XLIB_SURFACE_CREATE_INFO_KHR,
                    pNext = null,
                    flags = 0,
                    dpy = (void**)display,
                    window = (nuint)hwnd
                };

                functionPointerName = Marshal.StringToHGlobalAnsi("vkCreateXcbSurfaceKHR");

                result = vkCreateXlibSurfaceKHR(instanceHandle, &create_info, null, &surface);
                if (result != VkResult.VK_SUCCESS)
                {
                    throw new Exception($"Failed to create Vulkan surface: {result}");
                }
                _vkSurfaceKHR = surface;
#endregion
#region Select physical device (_vkPhysicalDevice) + logical device (_device) + graphics queue (_vkQueue)
                IntPtr _physicalDevice = IntPtr.Zero;
                IntPtr _device = IntPtr.Zero;
                IntPtr _graphicsQueue = IntPtr.Zero;
                
                ContextHelpers.SelectPhysicalDeviceAndLogicalDevice(_vkInstance, out _physicalDevice, out _device, out _graphicsQueue);

                _vkPhysicalDevice = _physicalDevice;
                _vkDevice = _device;
                _vkQueue = _graphicsQueue;
#endregion
#region Vulkan Memory Allocator (VMA) 
                // 1. Create the allocator once, after you have instance/physicalDevice/device
                VmaAllocatorCreateInfo allocatorInfo = new VmaAllocatorCreateInfo
                {
                    instance = (VkInstance*)_vkInstance,
                    physicalDevice = (VkPhysicalDevice*)_vkPhysicalDevice,
                    device = (VkDevice*)_vkDevice,
                    vulkanApiVersion = VK_MAKE_API_VERSION(0, 1, 3, 0),
                    // pVulkanFunctions = ... required by most bindings, fill with vkGetInstanceProcAddr/vkGetDeviceProcAddr
                };

                VmaAllocator* localAllocator;
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
                VmaAllocationCreateInfo allocInfo = new VmaAllocationCreateInfo
                {
                    usage = VmaMemoryUsage.VMA_MEMORY_USAGE_AUTO
                };

                // 4. Let VMA create the buffer AND its backing memory
                VkBuffer* localBuffer;
                VmaAllocation* localVmaAllocation;
                result = vmaCreateBuffer(localAllocator, &bufferInfo, &allocInfo, &localBuffer, &localVmaAllocation, null);
                if (result != VkResult.VK_SUCCESS)
                    throw new Exception($"Failed to create buffer via VMA: {result}");

                _vma_VkBuffer = localBuffer;
                _vmaAllocation = localVmaAllocation;
                _vmaAllocator = localAllocator;
#endregion
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

    public void BeginFrame() { }
    public void Clear(uint color) { }
    public void EndFrame() { }
    public byte[] GetRawPixels() => Array.Empty<byte>();
    public void Present(IntPtr windowHandle) { }
    public void Render() { }
    public void Resize(int width, int height) { }

    public void Cleanup()
    {
        if (_disposed) return;

        if (_vkDevice != IntPtr.Zero)
        {
            vkDeviceWaitIdle(_vkDevice);
        }

        // TODO: destroy swapchain, render pass, framebuffers, pipeline,
        // command pool, semaphores, fence — in that dependency order —
        // before destroying the device and (if not sharing) the instance.
        if (_vmaAllocator != null)
        {
            vmaDestroyBuffer(_vmaAllocator, _vma_VkBuffer, _vmaAllocation);
            vmaDestroyAllocator(_vmaAllocator);
            _vmaAllocator = null;
            _vma_VkBuffer = null;
            _vmaAllocation = null;
        }

        if (!_sharingDevice)
        {
            if (_vkDevice != IntPtr.Zero)
            {
                vkDestroyDevice(_vkDevice, null);
            }
            if (_vkInstance != IntPtr.Zero)
            {
                vkDestroyInstance(_vkInstance, null);
            }
        }
        _vkDevice = IntPtr.Zero;
        _vkInstance = IntPtr.Zero;
        _disposed = true;

        GC.SuppressFinalize(this);
    }

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

public unsafe class VkGraphicsContextHelpers
{
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
}
