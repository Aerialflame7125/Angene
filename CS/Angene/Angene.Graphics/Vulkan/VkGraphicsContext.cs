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
    private IntPtr[] _vkImages = new IntPtr[0];
    private IntPtr[] _vkImageViews = new IntPtr[0];
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
    public IntPtr[] VkImages => _vkImages;
    public IntPtr[] VkImageViews => _vkImageViews;
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

    public VkGraphicsContext(IntPtr hwnd, XLib._XDisplay* display, int width, int height, IntPtr existingDevice, IntPtr existingContext, Types.AppInfo? currentAppInfo = null, VkPresentModeKHR wantedPresentationMode = VkPresentModeKHR.VK_PRESENT_MODE_MAILBOX_KHR)
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
                        throw new Exceptions.FailedToInitializeVulkanException($"Required Vulkan extension missing: {r}");
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
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to create Vulkan surface: {result}");
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
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to create buffer via VMA: {result}");

                _vma_VkBuffer = localBuffer;
                _vmaAllocation = localVmaAllocation;
                _vmaAllocator = localAllocator;
#endregion
#region Swapchain (_vkSwapchainKHR)
                VkSurfaceCapabilitiesKHR _surfaceCapabilities = new VkSurfaceCapabilitiesKHR();
                result = vkGetPhysicalDeviceSurfaceCapabilitiesKHR(_physicalDevice, _vkSurfaceKHR, &_surfaceCapabilities);
                if (result != VkResult.VK_SUCCESS)
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to create swapchain (vkGetPhysicalDeviceSurfaceCapabilitiesKHR): {result}");
                
                // get surface format
                uint surfaceFormatCount;
                vkGetPhysicalDeviceSurfaceFormatsKHR(_physicalDevice, _vkSurfaceKHR, &surfaceFormatCount, null);

                VkSurfaceFormatKHR[] surfaceFormats = new VkSurfaceFormatKHR[surfaceFormatCount];
                fixed (VkSurfaceFormatKHR* pSurfaceFormats = surfaceFormats)
                    vkGetPhysicalDeviceSurfaceFormatsKHR(_physicalDevice, _vkSurfaceKHR, &surfaceFormatCount, pSurfaceFormats);
                
                VkSurfaceFormatKHR SurfaceFormat = ContextHelpers.ChooseSurfaceFormatAndColorSpace(surfaceFormats);

                // get present modes
                uint presentModeCount;
                vkGetPhysicalDeviceSurfacePresentModesKHR(_physicalDevice, _vkSurfaceKHR, &presentModeCount, null);

                VkPresentModeKHR[] presentModes = new VkPresentModeKHR[presentModeCount];
                fixed (VkPresentModeKHR* pPresentModes = presentModes)
                    vkGetPhysicalDeviceSurfacePresentModesKHR(_physicalDevice, _vkSurfaceKHR, &presentModeCount, pPresentModes);

                // create swapchain
                VkSwapchainCreateInfoKHR swapchainCreateInfo = new VkSwapchainCreateInfoKHR
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_SWAPCHAIN_CREATE_INFO_KHR,
                    pNext = null,
                    flags = 0,
                    surface = (VkSurfaceKHR*)_vkSurfaceKHR,
                    minImageCount = ContextHelpers.ChooseNumImages(_surfaceCapabilities),
                    imageFormat = SurfaceFormat.format,
                    imageColorSpace = SurfaceFormat.colorSpace,
                    imageExtent = _surfaceCapabilities.currentExtent,
                    imageArrayLayers = 1,
                    imageUsage = (uint)(VkImageUsageFlagBits.VK_IMAGE_USAGE_COLOR_ATTACHMENT_BIT | VkImageUsageFlagBits.VK_IMAGE_USAGE_TRANSFER_DST_BIT), // 1 is for basic rendering, 2 is for post processing
                    imageSharingMode = VkSharingMode.VK_SHARING_MODE_EXCLUSIVE,
                    queueFamilyIndexCount = 0,
                    pQueueFamilyIndices = null, 
                    preTransform = _surfaceCapabilities.currentTransform,
                    compositeAlpha = VkCompositeAlphaFlagBitsKHR.VK_COMPOSITE_ALPHA_OPAQUE_BIT_KHR, // ignore alpha channel
                    presentMode = ContextHelpers.ChoosePresentationMode(presentModes, wantedPresentationMode),
                    clipped = 1
                };
                IntPtr _localSwapchain = IntPtr.Zero;
                result = vkCreateSwapchainKHR(_device, &swapchainCreateInfo, null, &_localSwapchain);
                if (result != VkResult.VK_SUCCESS)
                    throw new Exceptions.FailedToInitializeVulkanException("Failed to create swapchain (vkCreateSwapchainKHR): {result}");

                _vkSwapchainKHR = _localSwapchain;
#endregion
#region Image Views (_currentImageIndex), (_swapchainImageCount), (_vkImages), (_vkImageViews)
                // If we are here, success! Now time to get swapchain images
                uint numswapchainImages = 0;
                result = vkGetSwapchainImagesKHR(_device, _vkSwapchainKHR, &numswapchainImages, null);
                if (result != VkResult.VK_SUCCESS)
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to get swapchain images (vkGetSwapchainImagesKHR): {result}");

                _swapchainImageCount = (int)numswapchainImages;

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
                    _vkImageViews[i] = ContextHelpers.CreateImageView(_device, _vkImages[i], SurfaceFormat.format, VkImageAspectFlagBits.VK_IMAGE_ASPECT_COLOR_BIT, VkImageViewType.VK_IMAGE_VIEW_TYPE_2D, (uint)layerCount, (uint)mipLevels);

#endregion
#region Render Pass

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
        
        // destroy image views
        foreach (IntPtr imageView in _vkImageViews)
            vkDestroyImageView(_vkDevice, imageView, null);
        
        // destroy swapchain
        vkDestroySwapchainKHR(_vkDevice, _vkSwapchainKHR, null);

        // destroy memory allocators
        if (_vmaAllocator != null)
        {
            vmaDestroyBuffer(_vmaAllocator, _vma_VkBuffer, _vmaAllocation);
            vmaDestroyAllocator(_vmaAllocator);
            _vmaAllocator = null;
            _vma_VkBuffer = null;
            _vmaAllocation = null;
        }

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
            image = (VkImage*)image,
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
}
