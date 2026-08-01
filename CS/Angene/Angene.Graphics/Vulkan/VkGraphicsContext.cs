using Angene.Common;
using Angene.Graphics;
using Angene.Windows;
using Angene.X11.Interop;
using static Angene.Vulkan.Interop.Methods;
using static Angene.Vulkan.Interop.Structs;
using static Angene.Vulkan.Interop.Enumerators;
using System.Runtime.InteropServices;

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

    private readonly IntPtr _hwnd;
    private readonly int _w, _h;

    public VkGraphicsContext(IntPtr hwnd, XLib._XDisplay* display, int width, int height, IntPtr existingDevice, IntPtr existingContext)
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

            IntPtr appNamePtr = Marshal.StringToHGlobalAnsi("Angene Engine");
            IntPtr engineNamePtr = Marshal.StringToHGlobalAnsi("Angene");

            try
            {
                VkApplicationInfo appInfo = new VkApplicationInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_APPLICATION_INFO,
                    pApplicationName = (sbyte*)appNamePtr,
                    applicationVersion = 1,
                    pEngineName = (sbyte*)engineNamePtr,
                    engineVersion = 1,
                    apiVersion = (uint)((1 << 22) | (3 << 12) | 0)
                };

                VkInstanceCreateInfo createInfo = new VkInstanceCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO,
                    pApplicationInfo = &appInfo,
                    enabledExtensionCount = 0,
                    ppEnabledExtensionNames = null
                };

                IntPtr instanceHandle;
                VkResult result = vkCreateInstance(&createInfo, null, out instanceHandle);

                if (result != VkResult.VK_SUCCESS)
                {
                    throw new Exception($"Failed to create Vulkan instance: {result}");
                }

                _vkInstance = instanceHandle;
            }
            finally
            {
                Marshal.FreeHGlobal(appNamePtr);
                Marshal.FreeHGlobal(engineNamePtr);
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
