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
    private static List<string> layerNames = new();
    private static List<string> extensionNames = new();
    public static bool running { get; private set; } = false;
    public static bool init = true;
    public static bool _disposing = false;
    public static bool Running => running;
    public static IntPtr OXRSpace { get; private set; }
    private static IntPtr[] XrSwapchains = new []{ IntPtr.Zero, IntPtr.Zero }; 
    private static Types.XrSwapchainImageVulkanKHR[] XrSwapchainImages = new Types.XrSwapchainImageVulkanKHR[]{};
    private static bool sessionFocused;

    // Instances
    public static IntPtr OpenXRInstance;
    public static IntPtr OXRSession;
    private static long predictedDisplayTime;
    
    // Windows
#if WINDOWS
    private static IDX11GraphicsContext dx11GraphicsContext = null;
    private static XrGraphicsRequirementsD3D11KHR D3D11Reqs;
#endif
    
    // Input
    private static IntPtr OXRActionSet;
    private static IntPtr leftHandAction;
    private static IntPtr rightHandAction;
    private static IntPtr leftGrabAction;
    private static IntPtr rightGrabAction;
    private static IntPtr leftHandSpace;
    private static IntPtr rightHandSpace;
    public static bool leftControllerGrab;
    public static bool rightControllerGrab;
    public static Vec3 leftHandPos, rightHandPos;
    public static Quaternion leftHandRot, rightHandRot;
    public static Vec3 headPos;
    public static Quaternion headRot;
    
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
        switch (usedContext)
        {
            case IVkGraphicsContext vk:
                vulkanGraphicsContext = vk;
                extensionNames.Add("XR_KHR_vulkan_enable2");
                
                CreateInstance(appInfo);
                getSystem();
                getVulkanInstanceRequirements();
                break;
#if WINDOWS
            case IDX11GraphicsContext dx1:
                dx11GraphicsContext = dx1;
                extensionNames.Add("XR_KHR_D3D11_enable");
                
                CreateInstance(appInfo);
                getSystem();
                getD3D11InstanceRequirements();
                break;
#endif
            default:
                throw new Exceptions.FailedToInitializeOpenXRException(
                    $"Graphics context of type '{usedContext.GetType()}' is not supported.");
        }
        Logger.LogDebug("--- END CreateInstanceS1 (OpenXR) ---",  LoggingTarget.External);
    }

    private static void CreateInstance(Types.AppInfo appInfo)
    {
        IntPtr instance = IntPtr.Zero;
        
        IntPtr[] extensionPtrs = new IntPtr[extensionNames.Count];
        for (int i = 0; i < extensionNames.Count; i++)
            extensionPtrs[i] = Marshal.StringToHGlobalAnsi(extensionNames[i]);
        
        IntPtr[] layerPtrs = new IntPtr[layerNames.Count];
        for (int i = 0; i < layerNames.Count; i++)
            layerPtrs[i] = Marshal.StringToHGlobalAnsi(layerNames[i]);

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
                    enabledApiLayerCount = (uint)layerNames.Count,
                    enabledApiLayerNames = (byte**)layerArrayPtr,
                    enabledExtensionCount = (uint)extensionNames.Count,
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

    private static void getSystem()
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
    
#if WINDOWS
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
    }
#endif
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
    public static (Types.XrSwapchain, Types.XrSwapchain) createSwapchainsAndActionSet()
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
        
        createActionSet();

        leftHandAction = createAction("left-hand", XrActionType.XR_ACTION_TYPE_POSE_INPUT);
        rightHandAction = createAction( "right-hand", XrActionType.XR_ACTION_TYPE_POSE_INPUT);
        leftGrabAction = createAction("left-grab", XrActionType.XR_ACTION_TYPE_BOOLEAN_INPUT);
        rightGrabAction = createAction( "right-grab", XrActionType.XR_ACTION_TYPE_BOOLEAN_INPUT);

        suggestBindings();
        leftHandSpace = createActionSpace(leftHandAction);
        rightHandSpace = createActionSpace(rightHandAction);
        attachActionSet(OXRActionSet);
        
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
        if (!running && !init || _disposing) return;
        
        while (true)
        {
            if (_disposing) return;
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
        if (sessionFocused && predictedDisplayTime != 0)
            ControllerInput(OXRActionSet, OXRSpace, predictedDisplayTime);
    }

    private static void HandleSessionState(XrSessionState state)
    {
        Logger.LogImportant($"[OpenXR] Session state -> {state}", LoggingTarget.External);
        sessionFocused = state == XrSessionState.XR_SESSION_STATE_FOCUSED;
        switch (state)
        {
            case XrSessionState.XR_SESSION_STATE_READY:
                XrSessionBeginInfo bi = new()
                {
                    type = Types.XrStructureType.XR_TYPE_SESSION_BEGIN_INFO,
                    primaryViewConfigurationType = XrViewConfigurationType.XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO
                };
                Check(xrBeginSession(OXRSession, &bi), "xrBeginSession");
                running = true;
                break;
            case XrSessionState.XR_SESSION_STATE_SYNCHRONIZED:
            case XrSessionState.XR_SESSION_STATE_VISIBLE:
            case XrSessionState.XR_SESSION_STATE_FOCUSED:
                running = true;
                break;
            case XrSessionState.XR_SESSION_STATE_STOPPING:
                running = false;
                Check(xrEndSession(OXRSession), "xrEndSession");
                break;
            case XrSessionState.XR_SESSION_STATE_IDLE:
                running = false;
                break;
            case XrSessionState.XR_SESSION_STATE_LOSS_PENDING:
            case XrSessionState.XR_SESSION_STATE_EXITING:
                running = false;
                if (!_disposing)
                {
                    _disposing = true;
                    cleanupCall?.Invoke();
                }
                break;
        }
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

    public static bool isRunning() => running;
    
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
        predictedDisplayTime = state.predictedDisplayTime;
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
        if (!running) return;
        
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
#region Input
    private static void createActionSet()
    {
        IntPtr actionSet;
        Types.XrResult res;

        XrActionSetCreateInfo actionSetCreateInfo = new XrActionSetCreateInfo()
        {
            type = Types.XrStructureType.XR_TYPE_ACTION_SET_CREATE_INFO,
            priority = 0
        };
        WriteFixedString(ref actionSetCreateInfo.actionSetName, "angene");
        WriteFixedString(ref actionSetCreateInfo.localizedActionSetName, vulkanGraphicsContext.CurrentAppInfo.AppName.ToLower());
        
        res = xrCreateActionSet(OpenXRInstance, &actionSetCreateInfo, &actionSet);

        if (res != Types.XrResult.XR_SUCCESS)
            throw new Exceptions.OpenXRSessionException($"Failed to create OpenXR action set: {res}");

        OXRActionSet = actionSet;
    }

    private static IntPtr createAction(string name, XrActionType type)
    {
        IntPtr action;

        XrActionCreateInfo actionCreateInfo = new XrActionCreateInfo()
        {
            type = Types.XrStructureType.XR_TYPE_ACTION_CREATE_INFO,
            actionType = type
        };
        WriteFixedString(ref actionCreateInfo.actionName, name.ToLower());
        WriteFixedString(ref actionCreateInfo.localizedActionName, name.ToLower());

        Types.XrResult res = xrCreateAction(OXRActionSet, &actionCreateInfo, &action);
        if (res != Types.XrResult.XR_SUCCESS)
            throw new Exceptions.OpenXRSessionException($"Failed to create OpenXR action set: {res}");

        return action;
    }

    private static IntPtr createActionSpace(IntPtr action)
    {
        IntPtr actionSpace = IntPtr.Zero;

        XrActionSpaceCreateInfo actionSpaceCreateInfo = new XrActionSpaceCreateInfo()
        {
            type = Types.XrStructureType.XR_TYPE_ACTION_SPACE_CREATE_INFO,
            poseInActionSpace = new XrPosef()
            {
                position = new XrVector3f()
                {
                    x = 0,
                    y = 0,
                    z = 0
                },
                orientation = new XrQuaternionf()
                {
                    w = 1,
                    x = 0,
                    y = 0,
                    z = 0
                }
            },
            action = action
        };

        Types.XrResult res = xrCreateActionSpace(OXRSession, &actionSpaceCreateInfo, &actionSpace);
        if (res != Types.XrResult.XR_SUCCESS)
            throw new Exceptions.OpenXRSessionException($"Failed to create OpenXR action space: {res}");

        return actionSpace;
    }

    private static void suggestBindings()
    {
        suggestFor("/interaction_profiles/khr/simple_controller",
            (leftHandAction,  "/user/hand/left/input/aim/pose"),
            (rightHandAction, "/user/hand/right/input/aim/pose"),
            (leftGrabAction,  "/user/hand/left/input/select/click"),
            (rightGrabAction, "/user/hand/right/input/select/click"));

        suggestFor("/interaction_profiles/oculus/touch_controller",
            (leftHandAction,  "/user/hand/left/input/aim/pose"),
            (rightHandAction, "/user/hand/right/input/aim/pose"),
            (leftGrabAction,  "/user/hand/left/input/squeeze/value"),
            (rightGrabAction, "/user/hand/right/input/squeeze/value"));

        suggestFor("/interaction_profiles/valve/index_controller",
            (leftHandAction,  "/user/hand/left/input/aim/pose"),
            (rightHandAction, "/user/hand/right/input/aim/pose"),
            (leftGrabAction,  "/user/hand/left/input/squeeze/value"),
            (rightGrabAction, "/user/hand/right/input/squeeze/value"));
    }

    private static void suggestFor(string profile, params (IntPtr action, string path)[] b)
    {
        try
        {
            var arr = new XrActionSuggestedBinding[b.Length];
            for (int i = 0; i < b.Length; i++)
                arr[i] = new XrActionSuggestedBinding { action = b[i].action, binding = getPath(b[i].path) };

            fixed (XrActionSuggestedBinding* p = arr)
            {
                var s = new XrInteractionProfileSuggestedBinding
                {
                    type = Types.XrStructureType.XR_TYPE_INTERACTION_PROFILE_SUGGESTED_BINDING,
                    interactionProfile = getPath(profile),
                    countSuggestedBindings = (uint)arr.Length,
                    suggestedBindings = p
                };
                var res = xrSuggestInteractionProfileBindings(OpenXRInstance, &s);
                if ((int)res < 0) throw new Exceptions.OpenXRSessionException($"{profile}: {res}");
            }
        }
        catch (Exception e)
        {
            Logger.LogWarning($"[OpenXR] Skipping binding profile: {e.Message}", LoggingTarget.External);
        }
    }
    
    private static void attachActionSet(IntPtr actionSet)
    {
        XrSessionActionSetsAttachInfo actionSetsAttachInfo = new XrSessionActionSetsAttachInfo()
        {
            type = Types.XrStructureType.XR_TYPE_SESSION_ACTION_SETS_ATTACH_INFO,
            countActionSets = 1,
            actionSets = &actionSet
        };

        Types.XrResult res = xrAttachSessionActionSets(OXRSession, &actionSetsAttachInfo);
        if (res != Types.XrResult.XR_SUCCESS)
            throw new Exceptions.OpenXRSessionException($"Failed to attach OpenXR action set: {res}");
    }

    private static bool getActionBoolean(IntPtr action)
    {
        XrActionStateGetInfo getInfo = new XrActionStateGetInfo()
        {
            type = Types.XrStructureType.XR_TYPE_ACTION_STATE_GET_INFO,
            action = action
        };

        XrActionStateBoolean state = new XrActionStateBoolean()
        {
            type = Types.XrStructureType.XR_TYPE_ACTION_STATE_BOOLEAN
        };

        Types.XrResult res = xrGetActionStateBoolean(OXRSession, &getInfo, &state);
        if ((int)res < 0)
            throw new Exceptions.OpenXRSessionException($"Failed to get boolean action state for OpenXR: {res}");
        return state.isActive != 0 && state.currentState != 0;
    }

    private static bool getActionPose(IntPtr action, IntPtr space, IntPtr roomSpace, long time, out XrPosef pose)
    {
        pose = default;

        var getInfo = new XrActionStateGetInfo
        {
            type = Types.XrStructureType.XR_TYPE_ACTION_STATE_GET_INFO,
            action = action
        };
        var state = new XrActionStatePose { type = Types.XrStructureType.XR_TYPE_ACTION_STATE_POSE };
        if ((int)xrGetActionStatePose(OXRSession, &getInfo, &state) < 0 || state.isActive == 0)
            return false;

        var loc = new XrSpaceLocation { type = Types.XrStructureType.XR_TYPE_SPACE_LOCATION };
        if ((int)xrLocateSpace(space, roomSpace, time, &loc) < 0) return false;

        const ulong need = XR_SPACE_LOCATION_POSITION_VALID_BIT | XR_SPACE_LOCATION_ORIENTATION_VALID_BIT;
        if ((loc.locationFlags & need) != need) return false;

        pose = loc.pose;
        return true;
    }
    
    private static void ControllerInput(IntPtr actionSet, IntPtr roomSpace, long predictedDisplayTime)
    {
        XrActiveActionSet activeActionSet = new XrActiveActionSet()
        {
            actionSet = actionSet,
            subactionPath = 0
        };

        XrActionsSyncInfo syncInfo = new XrActionsSyncInfo()
        {
            type = Types.XrStructureType.XR_TYPE_ACTIONS_SYNC_INFO,
            countActiveActionSets = 1,
            activeActionSets = &activeActionSet
        };
        
        Types.XrResult res = xrSyncActions(OXRSession, &syncInfo);
        if ((int)res < 0)
            throw new Exceptions.OpenXRSessionException($"Failed to synchronize OpenXR actions: {res}");
        if (res == Types.XrResult.XR_SESSION_NOT_FOCUSED) return;
        
        if (getActionPose(leftHandAction, leftHandSpace, roomSpace, predictedDisplayTime, out var leftHand))
        {
            leftHandPos = new Vec3(leftHand.position.x, leftHand.position.y, leftHand.position.z);
            leftHandRot = new Quaternion(leftHand.orientation.x, leftHand.orientation.y, leftHand.orientation.z, leftHand.orientation.w);
        }
        if (getActionPose(rightHandAction, rightHandSpace, roomSpace, predictedDisplayTime, out var rightHand))
        {
            rightHandPos = new Vec3(rightHand.position.x, rightHand.position.y, rightHand.position.z);
            rightHandRot = new Quaternion(rightHand.orientation.x, rightHand.orientation.y, rightHand.orientation.z, rightHand.orientation.w);
        }

        leftControllerGrab = getActionBoolean(leftGrabAction);
        rightControllerGrab = getActionBoolean(rightGrabAction);
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
    
    private static void WriteFixedString<TBuffer>(ref TBuffer buffer, string value) where TBuffer : unmanaged
    {
        fixed (TBuffer* p = &buffer)
        {
            Span<byte> dest = new Span<byte>(p, sizeof(TBuffer));
            dest.Clear();
            
            int max = dest.Length - 1;
            int written = Encoding.UTF8.GetBytes(value.AsSpan(), dest.Slice(0, max));
        }
    }

    private static ulong getPath(string name)
    {
        ulong path;
        
        byte[] bytes = Encoding.UTF8.GetBytes(name + '\0');

        fixed (byte* pBytes = bytes)
        {
            Types.XrResult res = xrStringToPath(OpenXRInstance, pBytes, &path);
            if (res  != Types.XrResult.XR_SUCCESS)
                throw new Exceptions.OpenXRSessionException($"Failed to get OpenXR path: {res}");
        }

        return path;
    }
#endregion
#region Cleanup

    private static Action cleanupCall = null;
    public static void SetCleanupCall(Action action) => cleanupCall = action;
    public static void Cleanup()
    {
        if (OpenXRInstance == IntPtr.Zero) return;
        xrDestroySpace(rightHandSpace);
        xrDestroySpace(leftHandSpace);

        xrDestroyAction(rightGrabAction);
        xrDestroyAction(leftGrabAction);
        xrDestroyAction(rightHandAction);
        xrDestroyAction(leftHandAction);

        xrDestroyActionSet(OXRActionSet);
        xrDestroySpace(OXRSpace);
        xrDestroySession(OXRSession);

        // Instance
        xrDestroyInstance(OpenXRInstance);
    }
#endregion
}