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
    public IntPtr VkPipeline => _vkPipeline;
    public IntPtr VkPipelineLayout => _vkPipelineLayout;
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

    public VkGraphicsContext(IntPtr hwnd, XLib._XDisplay* display, int width, int height, IntPtr existingDevice, IntPtr existingContext, VkPipelineShaderStageCreateInfo[] shaderStages, Types.AppInfo? currentAppInfo = null, VkPresentModeKHR wantedPresentationMode = VkPresentModeKHR.VK_PRESENT_MODE_MAILBOX_KHR)
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
                VmaAllocationCreateInfo VmaAllocInfo = new VmaAllocationCreateInfo
                {
                    usage = VmaMemoryUsage.VMA_MEMORY_USAGE_AUTO
                };

                // 4. Let VMA create the buffer AND its backing memory
                VkBuffer* localBuffer;
                VmaAllocation* localVmaAllocation;
                result = vmaCreateBuffer(localAllocator, &bufferInfo, &VmaAllocInfo, &localBuffer, &localVmaAllocation, null);
                if (result != VkResult.VK_SUCCESS)
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to create buffer via VMA: {result}");

                _vma_VkBuffer = localBuffer;
                _vmaAllocation = localVmaAllocation;
                _vmaAllocator = localAllocator;
#endregion
#region Swapchain (_vkSwapchainKHR), (_surfaceCapabilities)
                VkSurfaceCapabilitiesKHR _surfaceCapabilities = new VkSurfaceCapabilitiesKHR();
                result = vkGetPhysicalDeviceSurfaceCapabilitiesKHR(_physicalDevice, _vkSurfaceKHR, &_surfaceCapabilities);
                if (result != VkResult.VK_SUCCESS)
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to create swapchain (vkGetPhysicalDeviceSurfaceCapabilitiesKHR): {result}");
                
                _vkSurfaceCapabilities = _surfaceCapabilities;
                _vkExtent2D = _surfaceCapabilities.currentExtent;

                // get surface format
                uint surfaceFormatCount;
                vkGetPhysicalDeviceSurfaceFormatsKHR(_physicalDevice, _vkSurfaceKHR, &surfaceFormatCount, null);

                VkSurfaceFormatKHR[] surfaceFormats = new VkSurfaceFormatKHR[surfaceFormatCount];
                fixed (VkSurfaceFormatKHR* pSurfaceFormats = surfaceFormats)
                    vkGetPhysicalDeviceSurfaceFormatsKHR(_physicalDevice, _vkSurfaceKHR, &surfaceFormatCount, pSurfaceFormats);
                
                VkSurfaceFormatKHR SurfaceFormat = ContextHelpers.ChooseSurfaceFormatAndColorSpace(surfaceFormats);
                _vkFormat = SurfaceFormat.format;

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
                VkAttachmentReference colorAttachmentRef = new VkAttachmentReference
                {
                    attachment = 0,
                    layout = VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL
                };
                VkSubpassDescription subpass = new VkSubpassDescription
                {
                    pipelineBindPoint = VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS,
                    colorAttachmentCount = 1,
                    pColorAttachments = &colorAttachmentRef
                };

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
                    attachmentCount = 1,
                    pAttachments = &colorAttachment,
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
                VkPipelineDynamicStateCreateInfo dynamicState;
                VkDynamicState[] dynamicStates = [ VkDynamicState.VK_DYNAMIC_STATE_VIEWPORT, VkDynamicState.VK_DYNAMIC_STATE_SCISSOR ];
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

                VkPipelineLayoutCreateInfo pipelineLayoutInfo = new VkPipelineLayoutCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_LAYOUT_CREATE_INFO,
                    setLayoutCount = 0, // Optional
                    pSetLayouts = null, // Optional
                    pushConstantRangeCount = 0, // Optional
                    pPushConstantRanges = null // Optional
                };
                result = vkCreatePipelineLayout(_device, &pipelineLayoutInfo, null, &pipelineLayout);
                if (result != VkResult.VK_SUCCESS)
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to create pipeline layout (vkCreatePipelineLayout): {result}");

                _vkPipelineLayout = pipelineLayout;
#endregion
#region Graphics Pipeline (_vkPipeline)
                VkGraphicsPipelineCreateInfo pipelineInfo;
                if (shaderStages == null)
                    shaderStages = new VkPipelineShaderStageCreateInfo[]{};
                fixed (VkPipelineShaderStageCreateInfo* pShaderStages = shaderStages)
                {
                    pipelineInfo = new VkGraphicsPipelineCreateInfo
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_CREATE_INFO,
                        stageCount = (uint)shaderStages.Length,
                        pStages = pShaderStages,
                        pVertexInputState = &vertexInputInfo,
                        pInputAssemblyState = &inputAssembly,
                        pViewportState = &viewportState,
                        pRasterizationState = &rasterizer,
                        pMultisampleState = &multisampling,
                        pDepthStencilState = null,
                        pColorBlendState = &colorBlending,
                        pDynamicState = &dynamicState,
                        layout = (VkPipelineLayout*)pipelineLayout,
                        renderPass = (VkRenderPass*)renderPass,
                        subpass = 0,
                        basePipelineHandle = null,
                        basePipelineIndex = -1
                    };
                }

                IntPtr graphicsPipeline;

                result = vkCreateGraphicsPipelines(_device, IntPtr.Zero, 1, &pipelineInfo, null, &graphicsPipeline);
                if (result != VkResult.VK_SUCCESS)
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to create graphics pipelines (vkCreateGraphicsPipelines): {result}");

                _vkPipeline = graphicsPipeline;
                // If we are here, WE FUCKING DID IT YEAHHHHHHHHHHHHH
#endregion
#region Framebuffer (_vkFramebuffer)
                _vkFramebuffers = new IntPtr[_vkImageViews.Length];
                for (int idx = 0; idx < _vkImageViews.Length; idx++)
                {
                    IntPtr[] attachments = { _vkImageViews[idx] };
                    VkFramebufferCreateInfo framebufferInfo;

                    fixed (IntPtr* imageView = attachments)
                    {
                        framebufferInfo = new VkFramebufferCreateInfo
                        {
                            sType = VkStructureType.VK_STRUCTURE_TYPE_FRAMEBUFFER_CREATE_INFO,
                            renderPass = (VkRenderPass*)_vkRenderPass,
                            attachmentCount = 1,
                            pAttachments = (VkImageView**)imageView,
                            width = _surfaceCapabilities.currentExtent.width,
                            height = _surfaceCapabilities.currentExtent.height,
                            layers = 1
                        };

                        IntPtr framebuffer;
                        result = vkCreateFramebuffer(_device, &framebufferInfo, null, &framebuffer);
                        if (result != VkResult.VK_SUCCESS)
                            throw new Exceptions.FailedToInitializeVulkanException($"Failed to create framebuffer (vkCreateFramebuffer): {result}");

                        _vkFramebuffers[idx] = framebuffer;
                    }
                }

#endregion
#region Command Pool (_vkCommandPool)
                IntPtr commandPool;
    
                VkGraphicsContextHelpers.QueueFamilyIndices queueFamilyIndices = (VkGraphicsContextHelpers.QueueFamilyIndices)ContextHelpers.findQueueFamilies(_physicalDevice, _vkSurfaceKHR);
                VkCommandPoolCreateInfo poolInfo = new VkCommandPoolCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO,
                    flags = (uint)VkCommandPoolCreateFlagBits.VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT,
                    queueFamilyIndex = queueFamilyIndices.graphicsFamily.Value
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
                    commandPool = (VkCommandPool*)commandPool,
                    level = VkCommandBufferLevel.VK_COMMAND_BUFFER_LEVEL_PRIMARY,
                    commandBufferCount = 1
                };
                result = vkAllocateCommandBuffers(_device, &commandBufferAllocInfo, &commandBuffer);

                if (result != VkResult.VK_SUCCESS)
                    throw new Exceptions.FailedToInitializeVulkanException($"Failed to allocate command buffers (vkAllocateCommandBuffers): {result}");

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

                _vkSemaphoreImageAvailable = imageAvailableSemaphore;
                _vkSemaphoreRenderFinished = renderFinishedSemaphore;
                _vkFenceInFlight = inFlightFence;
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

    public void Clear(uint color) { }
    public byte[] GetRawPixels() => Array.Empty<byte>();
    public void Present(IntPtr windowHandle) { }

    public IntPtr CreateShaderModule(byte[] spirvBytecode)
    {
        fixed (byte* pCode = spirvBytecode)
        {
            VkShaderModuleCreateInfo createInfo = new VkShaderModuleCreateInfo
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO,
                codeSize = (nuint)spirvBytecode.Length,
                pCode = (uint*)pCode
            };

            IntPtr module;
            VkResult result = vkCreateShaderModule(_vkDevice, &createInfo, null, &module);
            if (result != VkResult.VK_SUCCESS)
                throw new Exceptions.FailedToInitializeVulkanException($"Failed to create shader module: {result}");
            return module;
        }
    }

    public IntPtr CreateVertexBuffer(byte[] data, uint strideBytes)
    {
        VkBufferCreateInfo bufferInfo = new VkBufferCreateInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO,
            size = (ulong)data.Length,
            usage = (uint)VK_BUFFER_USAGE_2_VERTEX_BUFFER_BIT,
            sharingMode = VkSharingMode.VK_SHARING_MODE_EXCLUSIVE
        };
        VmaAllocationCreateInfo allocInfo = new VmaAllocationCreateInfo
        {
            usage = VmaMemoryUsage.VMA_MEMORY_USAGE_AUTO,
            flags = (uint)(VmaAllocationCreateFlagBits.VMA_ALLOCATION_CREATE_HOST_ACCESS_SEQUENTIAL_WRITE_BIT
                        | VmaAllocationCreateFlagBits.VMA_ALLOCATION_CREATE_MAPPED_BIT)
        };

        VkBuffer* buffer;
        VmaAllocation* allocation;
        VmaAllocationInfo allocationInfo;
        VkResult result = vmaCreateBuffer(_vmaAllocator, &bufferInfo, &allocInfo, &buffer, &allocation, &allocationInfo);
        if (result != VkResult.VK_SUCCESS)
            throw new Exceptions.FailedToInitializeVulkanException($"Failed to create vertex buffer: {result}");

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

        VkBuffer* buffer;
        VmaAllocation* allocation;
        VmaAllocationInfo allocationInfo;
        VkResult result = vmaCreateBuffer(_vmaAllocator, &bufferInfo, &allocInfo, &buffer, &allocation, &allocationInfo);
        if (result != VkResult.VK_SUCCESS)
            throw new Exceptions.FailedToInitializeVulkanException($"Failed to create index buffer: {result}");

        fixed (byte* pData = bytes)
            Buffer.MemoryCopy(pData, allocationInfo.pMappedData, (ulong)bytes.Length, (ulong)bytes.Length);

        IntPtr handle = (IntPtr)buffer;
        _vmaBuffers[handle] = new VmaBufferHandle { Buffer = buffer, Allocation = allocation };
        return handle;
    }

    public IntPtr CreatePipeline(IntPtr vertexShaderModule, IntPtr fragmentShaderModule,
                                VkVertexInputAttributeDescription[] attributes, uint strideBytes)
    {
        IntPtr entryPointPtr = Marshal.StringToHGlobalAnsi("main");
        try
        {
            sbyte* entryPoint = (sbyte*)entryPointPtr;

            VkPipelineShaderStageCreateInfo[] stages = new VkPipelineShaderStageCreateInfo[]
            {
                new VkPipelineShaderStageCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO,
                    stage = VkShaderStageFlagBits.VK_SHADER_STAGE_VERTEX_BIT,
                    module = (VkShaderModule*)vertexShaderModule,
                    pName = entryPoint
                },
                new VkPipelineShaderStageCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO,
                    stage = VkShaderStageFlagBits.VK_SHADER_STAGE_FRAGMENT_BIT,
                    module = (VkShaderModule*)fragmentShaderModule,
                    pName = entryPoint
                }
            };

            VkVertexInputBindingDescription binding = new VkVertexInputBindingDescription
            {
                binding = 0,
                stride = strideBytes,
                inputRate = VkVertexInputRate.VK_VERTEX_INPUT_RATE_VERTEX
            };

            fixed (VkPipelineShaderStageCreateInfo* pStages = stages)
            fixed (VkVertexInputAttributeDescription* pAttrs = attributes)
            {
                VkPipelineVertexInputStateCreateInfo vertexInputInfo = new VkPipelineVertexInputStateCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_STATE_CREATE_INFO,
                    vertexBindingDescriptionCount = 1,
                    pVertexBindingDescriptions = &binding,
                    vertexAttributeDescriptionCount = (uint)attributes.Length,
                    pVertexAttributeDescriptions = pAttrs
                };

                VkPipelineInputAssemblyStateCreateInfo inputAssembly = new VkPipelineInputAssemblyStateCreateInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_INPUT_ASSEMBLY_STATE_CREATE_INFO,
                    topology = VkPrimitiveTopology.VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST,
                    primitiveRestartEnable = 0
                };

                VkDynamicState[] dynamicStates = { VkDynamicState.VK_DYNAMIC_STATE_VIEWPORT, VkDynamicState.VK_DYNAMIC_STATE_SCISSOR };
                fixed (VkDynamicState* pDynamicStates = dynamicStates)
                {
                    VkPipelineDynamicStateCreateInfo dynamicState = new VkPipelineDynamicStateCreateInfo
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_DYNAMIC_STATE_CREATE_INFO,
                        dynamicStateCount = (uint)dynamicStates.Length,
                        pDynamicStates = pDynamicStates
                    };

                    VkPipelineViewportStateCreateInfo viewportState = new VkPipelineViewportStateCreateInfo
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_STATE_CREATE_INFO,
                        viewportCount = 1,
                        scissorCount = 1
                    };

                    VkPipelineRasterizationStateCreateInfo rasterizer = new VkPipelineRasterizationStateCreateInfo
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_CREATE_INFO,
                        polygonMode = VkPolygonMode.VK_POLYGON_MODE_FILL,
                        lineWidth = 1.0f,
                        cullMode = (uint)VkCullModeFlagBits.VK_CULL_MODE_BACK_BIT,
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

                    VkGraphicsPipelineCreateInfo pipelineInfo = new VkGraphicsPipelineCreateInfo
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_CREATE_INFO,
                        stageCount = (uint)stages.Length,
                        pStages = pStages,
                        pVertexInputState = &vertexInputInfo,
                        pInputAssemblyState = &inputAssembly,
                        pViewportState = &viewportState,
                        pRasterizationState = &rasterizer,
                        pMultisampleState = &multisampling,
                        pColorBlendState = &colorBlending,
                        pDynamicState = &dynamicState,
                        layout = (VkPipelineLayout*)_vkPipelineLayout,
                        renderPass = (VkRenderPass*)_vkRenderPass,
                        subpass = 0,
                        basePipelineIndex = -1
                    };

                    IntPtr pipeline;
                    VkResult result = vkCreateGraphicsPipelines(_vkDevice, IntPtr.Zero, 1, &pipelineInfo, null, &pipeline);
                    if (result != VkResult.VK_SUCCESS)
                        throw new Exceptions.FailedToInitializeVulkanException($"Failed to create graphics pipeline: {result}");

                    return pipeline;
                }
            }
        }
        finally
        {
            Marshal.FreeHGlobal(entryPointPtr);
        }
    }

    public void SetVertexBuffer(IntPtr buffer, uint strideBytes, uint offset = 0)
    {
        _currentVertexBuffer = buffer;
        ulong off = offset;
        vkCmdBindVertexBuffers(_vkCommandBuffer, 0, 1, &buffer, &off);
    }

    public void SetIndexBuffer(IntPtr buffer, uint offset = 0)
    {
        vkCmdBindIndexBuffer(_vkCommandBuffer, buffer, offset, VkIndexType.VK_INDEX_TYPE_UINT32);
    }

    public void SetPipeline(IntPtr pipeline)
    {
        _currentPipeline = pipeline;
        vkCmdBindPipeline(_vkCommandBuffer, VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS, pipeline);
    }

    public void Draw(uint vertexCount, uint startVertex = 0)
    {
        vkCmdDraw(_vkCommandBuffer, vertexCount, 1, startVertex, 0);
    }

    public void DrawIndexed(uint indexCount, uint startIndex = 0, int baseVertex = 0)
    {
        vkCmdDrawIndexed(_vkCommandBuffer, indexCount, 1, startIndex, baseVertex, 0);
    }

    public void BeginFrame(uint clearColor)
    {
        IntPtr fence = _vkFenceInFlight;
        vkWaitForFences(_vkDevice, 1, &fence, 1, ulong.MaxValue);
        vkResetFences(_vkDevice, 1, &fence);

        uint imageIndex;
        VkResult result = vkAcquireNextImageKHR(_vkDevice, _vkSwapchainKHR, ulong.MaxValue,
            _vkSemaphoreImageAvailable, IntPtr.Zero, &imageIndex);
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

        VkClearColorValue clearColorValue = new VkClearColorValue();
        clearColorValue.float32[0] = ((clearColor >> 16) & 0xFF) / 255.0f; // R
        clearColorValue.float32[1] = ((clearColor >> 8) & 0xFF) / 255.0f;  // G
        clearColorValue.float32[2] = (clearColor & 0xFF) / 255.0f;         // B
        clearColorValue.float32[3] = ((clearColor >> 24) & 0xFF) / 255.0f; // A
        VkClearValue clearValue = new VkClearValue { color = clearColorValue };

        VkRenderPassBeginInfo renderPassInfo = new VkRenderPassBeginInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_RENDER_PASS_BEGIN_INFO,
            renderPass = (VkRenderPass*)_vkRenderPass,
            framebuffer = (VkFramebuffer*)_vkFramebuffers[_currentImageIndex],
            renderArea = new VkRect2D
            {
                offset = new VkOffset2D { x = 0, y = 0 },
                extent = _vkSurfaceCapabilities.currentExtent
            },
            clearValueCount = 1,
            pClearValues = &clearValue
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
    }

    public void EndFrame()
    {
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
            pWaitSemaphores = (VkSemaphore**)&waitSemaphore,
            pWaitDstStageMask = (uint*)&waitStage,
            commandBufferCount = 1,
            pCommandBuffers = (VkCommandBuffer**)&commandBuffer,
            signalSemaphoreCount = 1,
            pSignalSemaphores = (VkSemaphore**)&signalSemaphore
        };

        result = vkQueueSubmit(_vkQueue, 1, &submitInfo, _vkFenceInFlight);
        if (result != VkResult.VK_SUCCESS)
            throw new Exception($"Failed to submit draw command buffer (vkQueueSubmit): {result}");

        IntPtr swapchain = _vkSwapchainKHR;
        uint imageIndex = (uint)_currentImageIndex;
        VkPresentInfoKHR presentInfo = new VkPresentInfoKHR
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_PRESENT_INFO_KHR,
            waitSemaphoreCount = 1,
            pWaitSemaphores = (VkSemaphore**)&signalSemaphore,
            swapchainCount = 1,
            pSwapchains = (VkSwapchainKHR**)&swapchain,
            pImageIndices = &imageIndex
        };

        result = vkQueuePresentKHR(_vkQueue, &presentInfo);
        if (result != VkResult.VK_SUCCESS && result != VkResult.VK_SUBOPTIMAL_KHR)
            throw new Exception($"Failed to present (vkQueuePresentKHR): {result}");
    }

    public void Render(int vertices)
    {
        VkResult result;
        VkGraphicsContextHelpers contextHelpers = new VkGraphicsContextHelpers();
        IntPtr fence = _vkFenceInFlight;
        IntPtr commandBuffer = _vkCommandBuffer;
        vkWaitForFences(_vkDevice, 1, &fence, 1, UInt64.MaxValue);
        vkResetFences(_vkDevice, 1, &fence);
        uint _imageIndex = (uint)_currentImageIndex;

        fixed (int* pImageIndex = &_currentImageIndex)
            result = vkAcquireNextImageKHR(_vkDevice, _vkSwapchainKHR, ulong.MaxValue, _vkSemaphoreImageAvailable, IntPtr.Zero, (uint*)pImageIndex);

        if (result != VkResult.VK_SUCCESS)
            throw new Exception($"Failed to acquire next image (vkAcquireNextImageKHR): {result}");

        vkResetCommandBuffer(commandBuffer, 0);
        contextHelpers.recordCommandBuffer(commandBuffer, (int)_imageIndex, _vkRenderPass, _vkFramebuffers, _vkSurfaceCapabilities, _vkPipeline, vertices);

        vkCmdEndRenderPass(_vkCommandBuffer);

        result = vkEndCommandBuffer(_vkCommandBuffer);
        if (result != VkResult.VK_SUCCESS)
            throw new Exception($"Failed to record command buffer (vkEndCommandBuffer): {result}");

        IntPtr[] waitSemaphores = new IntPtr[] { _vkSemaphoreImageAvailable };
        IntPtr[] signalSemaphores = new IntPtr[] { _vkSemaphoreRenderFinished };
        IntPtr[] swapChains = new IntPtr[] { _vkSwapchainKHR };
        VkPipelineStageFlagBits[] waitStages = new VkPipelineStageFlagBits[] { VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT };
        fixed (IntPtr* pWaitSemaphores = waitSemaphores)
        {
            fixed (IntPtr* pSignalSemaphores = signalSemaphores)
            {
                fixed (VkPipelineStageFlagBits* pWaitStages = waitStages) // cancer
                {
                    VkSubmitInfo submitInfo = new VkSubmitInfo
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_SUBMIT_INFO,
                        waitSemaphoreCount = 1,
                        pWaitSemaphores = (VkSemaphore**)pWaitSemaphores,
                        pWaitDstStageMask = (uint*)pWaitStages,
                        commandBufferCount = 1,
                        pCommandBuffers = (VkCommandBuffer**)&commandBuffer,
                        signalSemaphoreCount = 1,
                        pSignalSemaphores = (VkSemaphore**)pSignalSemaphores
                    };

                    result = vkQueueSubmit(_vkQueue, 1, &submitInfo, _vkFenceInFlight);
                }
                fixed (IntPtr* swapchain = swapChains)
                {
                    VkPresentInfoKHR presentInfo = new VkPresentInfoKHR
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_PRESENT_INFO_KHR,
                        waitSemaphoreCount = 1,
                        pWaitSemaphores = (VkSemaphore**)pSignalSemaphores,
                        swapchainCount = 1,
                        pSwapchains = (VkSwapchainKHR**)swapchain,
                        pImageIndices = &_imageIndex,
                        pResults = null // Optional, allows to check if every swap chain presentation was successful
                    };

                    vkQueuePresentKHR(_vkQueue, &presentInfo);
                }
            }
        }
    }
    public void Resize(int width, int height) { }

    public void Cleanup()
    {
        if (_disposed) return;

        if (_vkDevice != IntPtr.Zero)
        {
            vkDeviceWaitIdle(_vkDevice);
        }
        
        foreach (var entry in _vmaBuffers.Values)
            vmaDestroyBuffer(_vmaAllocator, entry.Buffer, entry.Allocation);
        _vmaBuffers.Clear();

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
    public void recordCommandBuffer(IntPtr commandBuffer, int imageIndex, IntPtr renderPass, IntPtr[] framebuffers,  VkSurfaceCapabilitiesKHR _surfaceCapabilities, IntPtr _vkPipeline, int vertices)
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
            renderPass = (VkRenderPass*)renderPass,
            framebuffer = (VkFramebuffer*)framebuffers[imageIndex],
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

        vkCmdDraw(commandBuffer, (uint)vertices, 1, 0, 0);

    }
    public struct QueueFamilyIndices {
        public uint? graphicsFamily = null;
        public uint? presentFamily = null;

        public bool isComplete() {
            return graphicsFamily != null && presentFamily != null;
        }

        public QueueFamilyIndices(uint? graphicsFamily = null, uint? presentFamily = null)
        {
            this.graphicsFamily = graphicsFamily;
            this.presentFamily = presentFamily;
        }
    };
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
