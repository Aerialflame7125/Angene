using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using Angene.Common;
using Angene.Common.Settings;
using Angene.Essentials;
using Angene.Essentials.GraphicsContexts;
using Angene.Math.Vectors;
using Angene.Vulkan.Interop;
using static Angene.Extensions.XR.Interop.OpenXR;
using static Angene.Extensions.XR.Interop.OpenXR.Methods;
namespace Angene.Extensions.XR;

public unsafe class OpenXR // corresponding to https://amini-allight.org/post/openxr-tutorial-part-1
{
#region Vars
    public static ulong systemID = 0;
    private List<string> layerNames = new();
    private List<string> extensionNames = new();
    public bool running { get; private set; } = false;
    public static bool Running => Instance.running;
    public static IntPtr OXRSpace { get; private set; }
    private static IntPtr[] XrSwapchains = new []{ IntPtr.Zero, IntPtr.Zero }; 
    private static Types.XrSwapchainImageVulkanKHR[] XrSwapchainImages = new Types.XrSwapchainImageVulkanKHR[]{};

    // Instances
    public static IntPtr OpenXRInstance;
    public static OpenXR Instance;
    public static IntPtr OXRSession;
    public static string[] instanceExtensions;
    private static IDX11GraphicsContext dx11GraphicsContext = null;
    private static XrGraphicsRequirementsD3D11KHR D3D11Reqs;
    
    // Vulkan
    private static IVkGraphicsContext vulkanGraphicsContext = null;
    private static XrGraphicsRequirementsVulkanKHR VulkanReqs;
    private static IntPtr VkPhysicalDevice;
    private static IntPtr VkInstance;
    private static IntPtr VkDevice;
    
#endregion
#region Instance Creation
    public static void CreateInstanceS1(object usedContext, Types.AppInfo appInfo) // Used in VkGraphicsContext under the section labeled "OpenXR Init".
    {
        Logger.LogDebug("--- CreateSessionS1 (OpenXR) ---", LoggingTarget.External);
        Instance = new OpenXR();
        switch (usedContext)
        {
            case IVkGraphicsContext vk:
                vulkanGraphicsContext = vk;
                Instance.extensionNames.Add("XR_KHR_vulkan_enable2");
                
                Instance.CreateInstance(appInfo);
                Instance.getSystem();
                getVulkanInstanceRequirements();
                break;
            case IDX11GraphicsContext dx1:
                dx11GraphicsContext = dx1;
                Instance.extensionNames.Add("XR_KHR_D3D11_enable");
                
                Instance.CreateInstance(appInfo);
                Instance.getSystem();
                getD3D11InstanceRequirements();
                break;
            default:
                throw new Exceptions.FailedToInitializeOpenXRException(
                    $"Graphics context of type '{usedContext.GetType()}' is not supported.");
        }
        Logger.LogDebug("--- END CreateInstanceS1 (OpenXR) ---",  LoggingTarget.External);
    }

    private void CreateInstance(Types.AppInfo appInfo)
    {
        IntPtr instance = IntPtr.Zero;
        
        IntPtr[] extensionPtrs = new IntPtr[Instance.extensionNames.Count];
        for (int i = 0; i < Instance.extensionNames.Count; i++)
            extensionPtrs[i] = Marshal.StringToHGlobalAnsi(Instance.extensionNames[i]);
        
        IntPtr[] layerPtrs = new IntPtr[Instance.layerNames.Count];
        for (int i = 0; i < Instance.layerNames.Count; i++)
            layerPtrs[i] = Marshal.StringToHGlobalAnsi(Instance.layerNames[i]);

        try
        {
            fixed (IntPtr* layerArrayPtr = layerPtrs)
            fixed (IntPtr* extensionArrayPtr = extensionPtrs)
            {
                XrInstanceCreateInfo instanceCreateInfo = new XrInstanceCreateInfo
                {
                    type = Types.XrStructureType.XR_TYPE_INSTANCE_CREATE_INFO,
                    next = null,
                    createFlags = 0,
                    enabledApiLayerCount = (uint)Instance.layerNames.Count,
                    enabledApiLayerNames = (byte**)layerArrayPtr,
                    enabledExtensionCount = (uint)Instance.extensionNames.Count,
                    enabledExtensionNames = (byte**)extensionArrayPtr
                };

                SetFixedString(&instanceCreateInfo.applicationInfo.applicationName[0],
                    128, appInfo.AppName);
                SetFixedString(&instanceCreateInfo.applicationInfo.engineName[0],
                    128, "Angene");

                instanceCreateInfo.applicationInfo.applicationVersion = (uint)appInfo.AppVersion;
                instanceCreateInfo.applicationInfo.engineVersion =
                    (uint)Settings.Instance.GetSetting<float>("Main.VersionFloat");
                instanceCreateInfo.applicationInfo.apiVersion = (1UL << 48) | (0UL << 32) | 34UL;

                Types.XrResult res = xrCreateInstance(&instanceCreateInfo, &instance);

                if (res != Types.XrResult.XR_SUCCESS)
                    throw new Exceptions.FailedToInitializeOpenXRException(
                        $"Failed to create OpenXR instance: {res}");
                
                Logger.LogDebug(
                    $"xrCreateInstance returned {res}, instance = 0x{(instance):X}",
                    LoggingTarget.External);

                OpenXRInstance = instance;

                Logger.LogDebug(
                    $"OpenXRInstance = 0x{(OpenXRInstance):X}",
                    LoggingTarget.External);
            }
        }
        finally
        {
            foreach (var ptr in extensionPtrs)
                Marshal.FreeHGlobal(ptr);
            foreach (var ptr in layerPtrs)
                Marshal.FreeHGlobal(ptr);
        }
    }

    private void getSystem()
    {
        ulong systemId;

        XrSystemGetInfo systemGetInfo = new XrSystemGetInfo()
        {
            type = Types.XrStructureType.XR_TYPE_SYSTEM_GET_INFO,
            formFactor = XrFormFactor.XR_FORM_FACTOR_HEAD_MOUNTED_DISPLAY
        };
        
        Logger.LogDebug(
            $"xrGetSystem instance = 0x{(OpenXRInstance):X}",
            LoggingTarget.External);

        Types.XrResult res = xrGetSystem(OpenXRInstance, &systemGetInfo, &systemId);

        if (res != Types.XrResult.XR_SUCCESS)
            throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get OpenXR system: '{res}'");
        
        systemID = systemId;
    }

    public static IntPtr CreateVulkanInstance(IntPtr vkInstanceCreateInfo, IntPtr pfnGetInstanceProcAddr)
    {
        var fn = (delegate* unmanaged[Cdecl]<IntPtr, XrVulkanInstanceCreateInfoKHR*, IntPtr*, int*, Types.XrResult>)
            getXrFunction("xrCreateVulkanInstanceKHR");

        var info = new XrVulkanInstanceCreateInfoKHR
        {
            type = Types.XrStructureType.XR_TYPE_VULKAN_INSTANCE_CREATE_INFO_KHR,
            systemId = systemID,
            pfnGetInstanceProcAddr = pfnGetInstanceProcAddr,
            vulkanCreateInfo = (void*)vkInstanceCreateInfo
        };

        IntPtr vkInstance; int vkRes;
        var res = fn(OpenXRInstance, &info, &vkInstance, &vkRes);
        if (res != Types.XrResult.XR_SUCCESS || vkRes != 0)
            throw new Exceptions.FailedToInitializeOpenXRException(
                $"xrCreateVulkanInstanceKHR failed: xr={res}, vk={vkRes}");
        return vkInstance;
    }

    public static IntPtr GetVulkanPhysicalDevice(IntPtr vkInstance)
    {
        var fn = (delegate* unmanaged[Cdecl]<IntPtr, XrVulkanGraphicsDeviceGetInfoKHR*, IntPtr*, Types.XrResult>)
            getXrFunction("xrGetVulkanGraphicsDevice2KHR");

        var info = new XrVulkanGraphicsDeviceGetInfoKHR
        {
            type = Types.XrStructureType.XR_TYPE_VULKAN_GRAPHICS_DEVICE_GET_INFO_KHR,
            systemId = systemID,
            vulkanInstance = vkInstance        // the VkInstance, not the XrInstance
        };

        IntPtr pd;
        var res = fn(OpenXRInstance, &info, &pd);
        if (res != Types.XrResult.XR_SUCCESS || pd == IntPtr.Zero)
            throw new Exceptions.FailedToInitializeOpenXRException($"xrGetVulkanGraphicsDevice2KHR failed: {res}");
        VkPhysicalDevice = pd;
        return pd;
    }

    public static IntPtr CreateVulkanDevice(IntPtr physicalDevice, IntPtr vkDeviceCreateInfo, IntPtr pfnGetInstanceProcAddr)
    {
        var fn = (delegate* unmanaged[Cdecl]<IntPtr, XrVulkanDeviceCreateInfoKHR*, IntPtr*, int*, Types.XrResult>)
            getXrFunction("xrCreateVulkanDeviceKHR");

        var info = new XrVulkanDeviceCreateInfoKHR
        {
            type = Types.XrStructureType.XR_TYPE_VULKAN_DEVICE_CREATE_INFO_KHR,
            systemId = systemID,
            pfnGetInstanceProcAddr = pfnGetInstanceProcAddr,
            vulkanPhysicalDevice = physicalDevice,
            vulkanCreateInfo = (void*)vkDeviceCreateInfo
        };

        IntPtr device; int vkRes;
        var res = fn(OpenXRInstance, &info, &device, &vkRes);
        if (res != Types.XrResult.XR_SUCCESS || vkRes != 0)
            throw new Exceptions.FailedToInitializeOpenXRException(
                $"xrCreateVulkanDeviceKHR failed: xr={res}, vk={vkRes}");
        return device;
    }
    
    private static void getVulkanInstanceRequirements()
    {
        var getReqs =
            (delegate* unmanaged[Cdecl]<
                IntPtr,
                ulong,
                XrGraphicsRequirementsVulkanKHR*,
                Types.XrResult>)
            getXrFunction("xrGetVulkanGraphicsRequirements2KHR");

        VulkanReqs = new XrGraphicsRequirementsVulkanKHR
        {
            type = Types.XrStructureType.XR_TYPE_GRAPHICS_REQUIREMENTS_VULKAN_KHR,
            next = IntPtr.Zero
        };

        fixed (XrGraphicsRequirementsVulkanKHR* reqs = &VulkanReqs)
        {
            Types.XrResult res = getReqs(
                OpenXRInstance,
                systemID,
                reqs);

            if (res != Types.XrResult.XR_SUCCESS)
            {
                throw new Exceptions.FailedToInitializeOpenXRException(
                    $"Failed to get Vulkan requirements for OpenXR: {res}");
            }
        }

        Logger.LogDebug(
            $"OpenXR Vulkan API range: " +
            $"min=0x{VulkanReqs.minApiVersionSupported:X}, " +
            $"max=0x{VulkanReqs.maxApiVersionSupported:X}",
            LoggingTarget.External);
    }
    
    private static void getD3D11InstanceRequirements()
    {
        var getReqs = (delegate* unmanaged[Cdecl]<IntPtr, ulong, XrGraphicsRequirementsD3D11KHR*, Types.XrResult>)
            getXrFunction("xrGetD3D11GraphicsRequirementsKHR");
        var getExts = (delegate* unmanaged[Cdecl]<IntPtr, ulong, uint, uint*, byte*, Types.XrResult>)
            getXrFunction("xrGetD3D11InstanceExtensionsKHR");

        D3D11Reqs = new XrGraphicsRequirementsD3D11KHR { type = Types.XrStructureType.XR_TYPE_GRAPHICS_REQUIREMENTS_D3D11_KHR };
        fixed (XrGraphicsRequirementsD3D11KHR* r = &D3D11Reqs)
        {
            var res = getReqs(OpenXRInstance, systemID, r);
            if (res != Types.XrResult.XR_SUCCESS) throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get D3D11 Instance requirements for OpenXR: {res}");
        }

        uint size;
        var res2 = getExts(OpenXRInstance, systemID, 0, &size, null);
        if (res2 != Types.XrResult.XR_SUCCESS) throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get D3D11 Instance requirements for OpenXR: {res2}");

        var buf = new byte[size];
        fixed (byte* p = buf)
            res2 = getExts(OpenXRInstance, systemID, size, &size, p);
        if (res2 != Types.XrResult.XR_SUCCESS) throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get D3D11 instance requirements for OpenXR: {res2}");

        instanceExtensions = System.Text.Encoding.ASCII
            .GetString(buf, 0, (int)size).TrimEnd('\0')
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }
    
#endregion
#region Session Creation
    public static IntPtr CreateSessionS2(IntPtr VkInstance, IntPtr VkDevice, uint queueFamilyIndex)
    {
        Logger.LogDebug("--- CreateSessionS2 (OpenXR) ---", LoggingTarget.External);
        IntPtr session;

        XrGraphicsBindingVulkanKHR graphicsBinding = new XrGraphicsBindingVulkanKHR()
        {
            type = Types.XrStructureType.XR_TYPE_GRAPHICS_BINDING_VULKAN_KHR,
            instance = VkInstance,
            physicalDevice = VkPhysicalDevice,
            device = VkDevice,
            queueFamilyIndex = queueFamilyIndex,
            queueIndex = 0
        };

        XrSessionCreateInfo sessionCreateInfo = new XrSessionCreateInfo()
        {
            type = Types.XrStructureType.XR_TYPE_SESSION_CREATE_INFO,
            next = &graphicsBinding,
            createFlags = 0,
            systemId = systemID
        };
        
        Types.XrResult res = xrCreateSession(OpenXRInstance, &sessionCreateInfo, &session);
        if (res != Types.XrResult.XR_SUCCESS)
            throw new Exceptions.FailedToInitializeOpenXRException($"Failed to create OpenXR session: {res}");

        Logger.LogDebug("--- END CreateSessionS2 (OpenXR) ---", LoggingTarget.External);
        OXRSession = session;
        return session;
    }
#endregion
#region Swapchain
    public static (Types.XrSwapchain, Types.XrSwapchain) createSwapchains()
    {
        Types.XrResult res;
        uint viewCount = 0;
        res = xrEnumerateViewConfigurationViews(OpenXRInstance, systemID,
            XrViewConfigurationType.XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO,
            0, &viewCount, null);
        if (res != Types.XrResult.XR_SUCCESS) throw new Exceptions.OpenXRSessionException($"Failed to create OpenXR Swapchains: {res}");
        
        XrViewConfigurationView[] configViews = new XrViewConfigurationView[viewCount];
        for (int i = 0; i < configViews.Length; i++)
        {
            configViews[i].type = Types.XrStructureType.XR_TYPE_VIEW_CONFIGURATION_VIEW;
            configViews[i].next = null;
        }

        fixed (XrViewConfigurationView* configViewsPtr = configViews)
        {
            res = xrEnumerateViewConfigurationViews(OpenXRInstance, systemID,
                XrViewConfigurationType.XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO, viewCount, &viewCount,
                configViewsPtr);
            if (res != Types.XrResult.XR_SUCCESS)
                throw new Exceptions.FailedToInitializeOpenXRException(
                    $"Failed to enumerate view configuration views: {res}");
        }


        uint formatCount = 0;
        res = xrEnumerateSwapchainFormats(OXRSession, 0, &formatCount, null);
        if (res != Types.XrResult.XR_SUCCESS)
            throw new Exceptions.FailedToInitializeOpenXRException($"Failed to enumerate swapchain formats: {res}");
        
        long[] formats = new long[formatCount]; // I think this converts

        fixed (long* pformats = formats)
        {
            res = xrEnumerateSwapchainFormats(OXRSession, formatCount, &formatCount, pformats);
            if (res != Types.XrResult.XR_SUCCESS)
                throw new Exceptions.FailedToInitializeOpenXRException($"Failed to enumerate swapchain formats: {res}");
        }

        uint chosenFormat = (uint)formats.First();

        foreach (uint format in formats)
        {
            if (format == (uint)Vulkan.Interop.Enumerators.VkFormat.VK_FORMAT_R8G8B8A8_SRGB)
            {
                chosenFormat = format;
                break;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            XrSwapchainCreateInfo swapchainCreateInfo = new XrSwapchainCreateInfo()
            {
                type = Types.XrStructureType.XR_TYPE_SWAPCHAIN_CREATE_INFO,
                usageFlags = XR_SWAPCHAIN_USAGE_COLOR_ATTACHMENT_BIT,
                format = chosenFormat,
                sampleCount = (uint)Enumerators.VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT,
                width = configViews[i].recommendedImageRectWidth,
                height = configViews[i].recommendedImageRectHeight,
                faceCount = 1,
                arraySize = 1,
                mipCount = 1
            };

            IntPtr swapchain = IntPtr.Zero;
            res = xrCreateSwapchain(OXRSession, &swapchainCreateInfo, &swapchain);
            if (res != Types.XrResult.XR_SUCCESS)
                throw new Exceptions.FailedToInitializeOpenXRException($"Failed to create swapchain on index '{i}': {res}");
            
            XrSwapchains[i] = swapchain;
        }
        for (int i = 0; i < 2; i++) {
            _eyeW[i] = configViews[i].recommendedImageRectWidth;
            _eyeH[i] = configViews[i].recommendedImageRectHeight;
        }
        return (new Types.XrSwapchain(XrSwapchains[0], (Enumerators.VkFormat)chosenFormat, configViews[0].recommendedImageRectWidth, configViews[0].recommendedImageRectHeight), 
            new Types.XrSwapchain(XrSwapchains[1], (Enumerators.VkFormat)chosenFormat, configViews[1].recommendedImageRectWidth, configViews[1].recommendedImageRectHeight));
    }

    public static List<Types.XrSwapchainImageVulkanKHR> getSwapchainImages(Types.XrSwapchain swapchain)
    {
        uint imageCount;

        Types.XrResult res = xrEnumerateSwapchainImages(swapchain.swapchain, 0, &imageCount, IntPtr.Zero);

        if (res != Types.XrResult.XR_SUCCESS || imageCount == 0)
            throw new Exceptions.FailedToEnumerateSwapchainImageOpenXRException(
                $"Failed to enumerate swapchain images: {res}");

        XrSwapchainImages = new Types.XrSwapchainImageVulkanKHR[imageCount];
        
        for (int i = 0; i < imageCount; i++)
            XrSwapchainImages[i].type = Types.XrStructureType.XR_TYPE_SWAPCHAIN_IMAGE_VULKAN_KHR;
        fixed (Types.XrSwapchainImageVulkanKHR* p = XrSwapchainImages)
            res = xrEnumerateSwapchainImages(swapchain.swapchain, imageCount, &imageCount, (IntPtr)p);
        
        if (res != Types.XrResult.XR_SUCCESS)
            throw new Exceptions.FailedToEnumerateSwapchainImageOpenXRException(
                $"Failed to enumerate swapchain images: {res}");
        
        return XrSwapchainImages.ToList();
    }

    public static void createSpace(Vec3 position, Quaternion quaternion)
    {
        IntPtr space;

        XrReferenceSpaceCreateInfo spaceCreateInfo = new XrReferenceSpaceCreateInfo()
        {
            type = Types.XrStructureType.XR_TYPE_REFERENCE_SPACE_CREATE_INFO,
            referenceSpaceType = XrReferenceSpaceType.XR_REFERENCE_SPACE_TYPE_STAGE,
            poseInReferenceSpace = new XrPosef()
            {
                orientation = new XrQuaternionf()
                {
                    w = quaternion.W,
                    x = quaternion.X,
                    y = quaternion.Y,
                    z = quaternion.Z
                },
                position = new XrVector3f()
                {
                    x = position.X,
                    y = position.Y,
                    z = position.Z
                }
            }
        };
        
        Types.XrResult res = xrCreateReferenceSpace(OXRSession, &spaceCreateInfo, &space);
        if (res != Types.XrResult.XR_SUCCESS)
            throw new Exceptions.OpenXRSessionException($"Failed to create OpenXR space: {res}");

        OXRSpace = space;
    }
    
#endregion
#region Session Management
    public static void PollEvents()
    {
        if (OXRSession == IntPtr.Zero) return;
        while (true)
        {
            XrEventDataBuffer ev = new() { type = Types.XrStructureType.XR_TYPE_EVENT_DATA_BUFFER };
            var res = xrPollEvent(OpenXRInstance, &ev);
            if (res == Types.XrResult.XR_EVENT_UNAVAILABLE) break;
            if ((int)res < 0) throw new Exceptions.OpenXRSessionException($"xrPollEvent: {res}");

            switch (ev.type)
            {
                case Types.XrStructureType.XR_TYPE_EVENT_DATA_SESSION_STATE_CHANGED:
                    HandleSessionState(((XrEventDataSessionStateChanged*)&ev)->state);
                    break;
                case Types.XrStructureType.XR_TYPE_EVENT_DATA_EVENTS_LOST:
                    Logger.LogWarning("[OpenXR] Events lost.", LoggingTarget.External);
                    break;
                case Types.XrStructureType.XR_TYPE_EVENT_DATA_INSTANCE_LOSS_PENDING:
                    Logger.LogImportant("[OpenXR] Instance loss pending.", LoggingTarget.External);
                    break;
                default:
                    Logger.LogDebug($"[OpenXR] Event: {ev.type}", LoggingTarget.External);
                    break;
            }
        }
    }

    private static void HandleSessionState(XrSessionState state)
    {
        Logger.LogImportant($"[OpenXR] Session state -> {state}", LoggingTarget.External);
        switch (state)
        {
            case XrSessionState.XR_SESSION_STATE_READY:
                XrSessionBeginInfo bi = new()
                {
                    type = Types.XrStructureType.XR_TYPE_SESSION_BEGIN_INFO,
                    primaryViewConfigurationType = XrViewConfigurationType.XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO
                };
                Check(xrBeginSession(OXRSession, &bi), "xrBeginSession");
                Instance.running = true;
                break;
            case XrSessionState.XR_SESSION_STATE_SYNCHRONIZED:
            case XrSessionState.XR_SESSION_STATE_VISIBLE:
            case XrSessionState.XR_SESSION_STATE_FOCUSED:
                Instance.running = true;
                break;
            case XrSessionState.XR_SESSION_STATE_STOPPING:
                Instance.running = false;               // was missing: next xrWaitFrame would fail
                Check(xrEndSession(OXRSession), "xrEndSession");
                break;
            case XrSessionState.XR_SESSION_STATE_IDLE:
                Instance.running = false;
                break;
            case XrSessionState.XR_SESSION_STATE_LOSS_PENDING:
            case XrSessionState.XR_SESSION_STATE_EXITING:
                Instance.running = false;
                Lifecycle.ScriptBinding.ShutdownEngine();
                break;
        }
    }
#endregion
#region Cleanup
    public void Cleanup()
    {
        xrDestroySpace(OXRSpace);
        xrDestroySession(OXRSession);

        // Instance
        xrDestroyInstance(OpenXRInstance);
    }
#endregion
#region Rendering
    private static XrView[] _views = new XrView[2];
    private static long _displayTime;
    private static uint[] _eyeW = new uint[2], _eyeH = new uint[2]; // fill in createSwapchains

    private static void Check(Types.XrResult r, string what)
    {
        if (r != Types.XrResult.XR_SUCCESS)
            throw new Exceptions.OpenXRSessionException($"{what} failed: {r}");
    }

    public static Types.XrFrameInfo BeginXrFrame()
    {
        XrFrameWaitInfo waitInfo = new() { type = Types.XrStructureType.XR_TYPE_FRAME_WAIT_INFO };
        XrFrameState state = new() { type = Types.XrStructureType.XR_TYPE_FRAME_STATE };
        Check(xrWaitFrame(OXRSession, &waitInfo, &state), "xrWaitFrame");

        XrFrameBeginInfo beginInfo = new() { type = Types.XrStructureType.XR_TYPE_FRAME_BEGIN_INFO };
        Check(xrBeginFrame(OXRSession, &beginInfo), "xrBeginFrame");

        _displayTime = state.predictedDisplayTime;
        var info = new Types.XrFrameInfo { shouldRender = state.shouldRender != 0 };
        if (!info.shouldRender) return info;

        XrViewLocateInfo locate = new()
        {
            type = Types.XrStructureType.XR_TYPE_VIEW_LOCATE_INFO,
            viewConfigurationType = XrViewConfigurationType.XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO,
            displayTime = _displayTime,
            space = OXRSpace
        };
        XrViewState viewState = new() { type = Types.XrStructureType.XR_TYPE_VIEW_STATE };
        uint count = 2;
        for (int i = 0; i < 2; i++) _views[i] = new XrView { type = Types.XrStructureType.XR_TYPE_VIEW };

        fixed (XrView* v = _views)
            Check(xrLocateViews(OXRSession, &locate, &viewState, 2, &count, v), "xrLocateViews");

        info.leftEye  = ToEye(_views[0]);
        info.rightEye = ToEye(_views[1]);
        return info;
    }

    private static Types.XrEyeView ToEye(XrView v) => new()
    {
        px = v.pose.position.x, py = v.pose.position.y, pz = v.pose.position.z,
        qx = v.pose.orientation.x, qy = v.pose.orientation.y,
        qz = v.pose.orientation.z, qw = v.pose.orientation.w,
        left = v.fov.angleLeft, right = v.fov.angleRight,
        up = v.fov.angleUp, down = v.fov.angleDown
    };

    public static uint AcquireEyeImage(int eye)
    {
        XrSwapchainImageAcquireInfo acq = new() { type = Types.XrStructureType.XR_TYPE_SWAPCHAIN_IMAGE_ACQUIRE_INFO };
        uint idx;
        Check(xrAcquireSwapchainImage(XrSwapchains[eye], &acq, &idx), "xrAcquireSwapchainImage");

        XrSwapchainImageWaitInfo wait = new()
        {
            type = Types.XrStructureType.XR_TYPE_SWAPCHAIN_IMAGE_WAIT_INFO,
            timeout = long.MaxValue
        };
        Check(xrWaitSwapchainImage(XrSwapchains[eye], &wait), "xrWaitSwapchainImage");
        return idx;
    }

    public static void ReleaseEyeImage(int eye)
    {
        XrSwapchainImageReleaseInfo rel = new() { type = Types.XrStructureType.XR_TYPE_SWAPCHAIN_IMAGE_RELEASE_INFO };
        Check(xrReleaseSwapchainImage(XrSwapchains[eye], &rel), "xrReleaseSwapchainImage");
    }

    public static void EndXrFrame(bool rendered)
    {
        XrCompositionLayerProjectionView* pv = stackalloc XrCompositionLayerProjectionView[2];
        for (int i = 0; i < 2; i++)
        {
            pv[i] = new XrCompositionLayerProjectionView
            {
                type = Types.XrStructureType.XR_TYPE_COMPOSITION_LAYER_PROJECTION_VIEW,
                pose = _views[i].pose,
                fov = _views[i].fov
            };
            pv[i].subImage.swapchain = XrSwapchains[i];
            pv[i].subImage.imageRect.offset.x = 0;
            pv[i].subImage.imageRect.offset.y = 0;
            pv[i].subImage.imageRect.extent.width  = (int)_eyeW[i];
            pv[i].subImage.imageRect.extent.height = (int)_eyeH[i];
            pv[i].subImage.imageArrayIndex = 0;
        }

        XrCompositionLayerProjection layer = new()
        {
            type = Types.XrStructureType.XR_TYPE_COMPOSITION_LAYER_PROJECTION,
            space = OXRSpace,
            viewCount = 2,
            views = pv
        };
        XrCompositionLayerBaseHeader* layerPtr = (XrCompositionLayerBaseHeader*)&layer;

        XrFrameEndInfo end = new()
        {
            type = Types.XrStructureType.XR_TYPE_FRAME_END_INFO,
            displayTime = _displayTime,
            environmentBlendMode = XrEnvironmentBlendMode.XR_ENVIRONMENT_BLEND_MODE_OPAQUE,
            layerCount = rendered ? 1u : 0u,
            layers = rendered ? &layerPtr : null
        };
        Check(xrEndFrame(OXRSession, &end), "xrEndFrame");
    }
#endregion
#region Helpers
    private static void SetFixedString(byte* dest, int maxLength, string value)
    {
        byte[] bytes = System.Text.Encoding.ASCII.GetBytes(value ?? string.Empty);
        int len = System.Math.Min(bytes.Length, maxLength - 1);
        for (int i = 0; i < len; i++)
            dest[i] = bytes[i];
        dest[len] = 0;
    }
    
    private static IntPtr getXrFunction(string name)
    {
        IntPtr func;
        byte[] nameBytes =
            Encoding.ASCII.GetBytes(name + '\0');


        fixed (byte* namePtr = nameBytes)
        {
            Types.XrResult res = xrGetInstanceProcAddr(OpenXRInstance, namePtr,
                (delegate*unmanaged[Cdecl]<void>*)&func);
            if (res != Types.XrResult.XR_SUCCESS)
                throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get OpenXR instance: {res}");
        }
        
        return func;
    }

    public static (ulong, ulong) getMinMaxSupportedVulkan()
    {
        return (VulkanReqs.minApiVersionSupported, VulkanReqs.maxApiVersionSupported);
    }
#endregion
}