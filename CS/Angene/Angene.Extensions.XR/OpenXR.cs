using System.Runtime.InteropServices;
using System.Text;
using Angene.Common;
using Angene.Common.Settings;
using Angene.Essentials;
using Angene.Essentials.GraphicsContexts;
using Angene.Vulkan.Interop;
using static Angene.Extensions.XR.Interop.OpenXR;
using static Angene.Extensions.XR.Interop.OpenXR.Methods;
namespace Angene.Extensions.XR;

public unsafe class OpenXR // corresponding to https://amini-allight.org/post/openxr-tutorial-part-1
{
#region Vars
    public static IntPtr OpenXRInstance;
    public static IntPtr OXRSession;
    public static OpenXR Instance;
    public static ulong systemID = 0;
    private List<string> layerNames = new();
    private List<string> extensionNames = new();

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
        Logger.LogDebug("--- CreateSessionS1 (OpenXR) ---", LoggingTarget.Graphics);
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
        Logger.LogDebug("--- END CreateInstanceS1 (OpenXR) ---",  LoggingTarget.Graphics);
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
                    type = XrStructureType.XR_TYPE_INSTANCE_CREATE_INFO,
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

                XrResult res = xrCreateInstance(&instanceCreateInfo, &instance);

                if (res != XrResult.XR_SUCCESS)
                    throw new Exceptions.FailedToInitializeOpenXRException(
                        $"Failed to create OpenXR instance: {res}");
                
                Logger.LogDebug(
                    $"xrCreateInstance returned {res}, instance = 0x{(instance):X}",
                    LoggingTarget.Graphics);

                OpenXRInstance = instance;

                Logger.LogDebug(
                    $"OpenXRInstance = 0x{(OpenXRInstance):X}",
                    LoggingTarget.Graphics);
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
            type = XrStructureType.XR_TYPE_SYSTEM_GET_INFO,
            formFactor = XrFormFactor.XR_FORM_FACTOR_HEAD_MOUNTED_DISPLAY
        };
        
        Logger.LogDebug(
            $"xrGetSystem instance = 0x{(OpenXRInstance):X}",
            LoggingTarget.Graphics);

        XrResult res = xrGetSystem(OpenXRInstance, &systemGetInfo, &systemId);

        if (res != XrResult.XR_SUCCESS)
            throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get OpenXR system: '{res}'");
        
        systemID = systemId;
    }

    public static IntPtr CreateVulkanInstance(IntPtr vkInstanceCreateInfo, IntPtr pfnGetInstanceProcAddr)
    {
        var fn = (delegate* unmanaged[Cdecl]<IntPtr, XrVulkanInstanceCreateInfoKHR*, IntPtr*, int*, XrResult>)
            getXrFunction("xrCreateVulkanInstanceKHR");

        var info = new XrVulkanInstanceCreateInfoKHR
        {
            type = XrStructureType.XR_TYPE_VULKAN_INSTANCE_CREATE_INFO_KHR,
            systemId = systemID,
            pfnGetInstanceProcAddr = pfnGetInstanceProcAddr,
            vulkanCreateInfo = (void*)vkInstanceCreateInfo
        };

        IntPtr vkInstance; int vkRes;
        var res = fn(OpenXRInstance, &info, &vkInstance, &vkRes);
        if (res != XrResult.XR_SUCCESS || vkRes != 0)
            throw new Exceptions.FailedToInitializeOpenXRException(
                $"xrCreateVulkanInstanceKHR failed: xr={res}, vk={vkRes}");
        return vkInstance;
    }

    public static IntPtr GetVulkanPhysicalDevice(IntPtr vkInstance)
    {
        var fn = (delegate* unmanaged[Cdecl]<IntPtr, XrVulkanGraphicsDeviceGetInfoKHR*, IntPtr*, XrResult>)
            getXrFunction("xrGetVulkanGraphicsDevice2KHR");

        var info = new XrVulkanGraphicsDeviceGetInfoKHR
        {
            type = XrStructureType.XR_TYPE_VULKAN_GRAPHICS_DEVICE_GET_INFO_KHR,
            systemId = systemID,
            vulkanInstance = vkInstance        // the VkInstance, not the XrInstance
        };

        IntPtr pd;
        var res = fn(OpenXRInstance, &info, &pd);
        if (res != XrResult.XR_SUCCESS || pd == IntPtr.Zero)
            throw new Exceptions.FailedToInitializeOpenXRException($"xrGetVulkanGraphicsDevice2KHR failed: {res}");
        VkPhysicalDevice = pd;
        return pd;
    }

    public static IntPtr CreateVulkanDevice(IntPtr physicalDevice, IntPtr vkDeviceCreateInfo, IntPtr pfnGetInstanceProcAddr)
    {
        var fn = (delegate* unmanaged[Cdecl]<IntPtr, XrVulkanDeviceCreateInfoKHR*, IntPtr*, int*, XrResult>)
            getXrFunction("xrCreateVulkanDeviceKHR");

        var info = new XrVulkanDeviceCreateInfoKHR
        {
            type = XrStructureType.XR_TYPE_VULKAN_DEVICE_CREATE_INFO_KHR,
            systemId = systemID,
            pfnGetInstanceProcAddr = pfnGetInstanceProcAddr,
            vulkanPhysicalDevice = physicalDevice,
            vulkanCreateInfo = (void*)vkDeviceCreateInfo
        };

        IntPtr device; int vkRes;
        var res = fn(OpenXRInstance, &info, &device, &vkRes);
        if (res != XrResult.XR_SUCCESS || vkRes != 0)
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
                XrResult>)
            getXrFunction("xrGetVulkanGraphicsRequirements2KHR");

        VulkanReqs = new XrGraphicsRequirementsVulkanKHR
        {
            type = XrStructureType.XR_TYPE_GRAPHICS_REQUIREMENTS_VULKAN_KHR,
            next = IntPtr.Zero
        };

        fixed (XrGraphicsRequirementsVulkanKHR* reqs = &VulkanReqs)
        {
            XrResult res = getReqs(
                OpenXRInstance,
                systemID,
                reqs);

            if (res != XrResult.XR_SUCCESS)
            {
                throw new Exceptions.FailedToInitializeOpenXRException(
                    $"Failed to get Vulkan requirements for OpenXR: {res}");
            }
        }

        Logger.LogDebug(
            $"OpenXR Vulkan API range: " +
            $"min=0x{VulkanReqs.minApiVersionSupported:X}, " +
            $"max=0x{VulkanReqs.maxApiVersionSupported:X}",
            LoggingTarget.Graphics);
    }
    
    private static void getD3D11InstanceRequirements()
    {
        var getReqs = (delegate* unmanaged[Cdecl]<IntPtr, ulong, XrGraphicsRequirementsD3D11KHR*, XrResult>)
            getXrFunction("xrGetD3D11GraphicsRequirementsKHR");
        var getExts = (delegate* unmanaged[Cdecl]<IntPtr, ulong, uint, uint*, byte*, XrResult>)
            getXrFunction("xrGetD3D11InstanceExtensionsKHR");

        D3D11Reqs = new XrGraphicsRequirementsD3D11KHR { type = XrStructureType.XR_TYPE_GRAPHICS_REQUIREMENTS_D3D11_KHR };
        fixed (XrGraphicsRequirementsD3D11KHR* r = &D3D11Reqs)
        {
            var res = getReqs(OpenXRInstance, systemID, r);
            if (res != XrResult.XR_SUCCESS) throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get D3D11 Instance requirements for OpenXR: {res}");
        }

        uint size;
        var res2 = getExts(OpenXRInstance, systemID, 0, &size, null);
        if (res2 != XrResult.XR_SUCCESS) throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get D3D11 Instance requirements for OpenXR: {res2}");

        var buf = new byte[size];
        fixed (byte* p = buf)
            res2 = getExts(OpenXRInstance, systemID, size, &size, p);
        if (res2 != XrResult.XR_SUCCESS) throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get D3D11 instance requirements for OpenXR: {res2}");

        instanceExtensions = System.Text.Encoding.ASCII
            .GetString(buf, 0, (int)size).TrimEnd('\0')
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }
    
#endregion
#region Session Creation
    public static IntPtr CreateSessionS2(IntPtr VkInstance, IntPtr VkDevice, uint queueFamilyIndex)
    {
        Logger.LogDebug("--- CreateSessionS2 (OpenXR) ---", LoggingTarget.Graphics);
        IntPtr session;

        XrGraphicsBindingVulkanKHR graphicsBinding = new XrGraphicsBindingVulkanKHR()
        {
            type = XrStructureType.XR_TYPE_GRAPHICS_BINDING_VULKAN_KHR,
            instance = VkInstance,
            physicalDevice = VkPhysicalDevice,
            device = VkDevice,
            queueFamilyIndex = queueFamilyIndex,
            queueIndex = 0
        };

        XrSessionCreateInfo sessionCreateInfo = new XrSessionCreateInfo()
        {
            type = XrStructureType.XR_TYPE_SESSION_CREATE_INFO,
            next = &graphicsBinding,
            createFlags = 0,
            systemId = systemID
        };
        
        XrResult res = xrCreateSession(OpenXRInstance, &sessionCreateInfo, &session);
        if (res != XrResult.XR_SUCCESS)
            throw new Exceptions.FailedToInitializeOpenXRException($"Failed to create OpenXR session: {res}");

        Logger.LogDebug("--- END CreateSessionS2 (OpenXR) ---", LoggingTarget.Graphics);
        OXRSession = session;
        return session;
    }
#endregion
#region Swapchain Creation
    public static (Types.XrSwapchain, Types.XrSwapchain) createSwapchains()
    {
        uint configViewsCount = 2;
        XrViewConfigurationView[] configViews = new XrViewConfigurationView[configViewsCount];

        XrResult res;
        fixed (XrViewConfigurationView* configViewsPtr = configViews)
        {
            res = xrEnumerateViewConfigurationViews(OpenXRInstance, systemID,
                XrViewConfigurationType.XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO, configViewsCount, &configViewsCount,
                configViewsPtr);
            if (res != XrResult.XR_SUCCESS)
                throw new Exceptions.FailedToInitializeOpenXRException(
                    $"Failed to enumerate view configuration views: {res}");
        }


        uint formatCount = 0;
        res = xrEnumerateSwapchainFormats(OXRSession, 0, &formatCount, null);
        if (res != XrResult.XR_SUCCESS)
            throw new Exceptions.FailedToInitializeOpenXRException($"Failed to enumerate swapchain formats: {res}");
        
        long[] formats = new long[formatCount]; // I think this converts

        fixed (long* pformats = formats)
        {
            res = xrEnumerateSwapchainFormats(OXRSession, formatCount, &formatCount, pformats);
            if (res != XrResult.XR_SUCCESS)
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

        IntPtr[] XrSwapchains = new []{ IntPtr.Zero, IntPtr.Zero };

        for (int i = 0; i < 2; i++)
        {
            XrSwapchainCreateInfo swapchainCreateInfo = new XrSwapchainCreateInfo()
            {
                type = XrStructureType.XR_TYPE_SWAPCHAIN_CREATE_INFO,
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
            if (res != XrResult.XR_SUCCESS)
                throw new Exceptions.FailedToInitializeOpenXRException($"Failed to create swapchain on index '{i}': {res}");
            
            XrSwapchains[i] = swapchain;
        }
        return (new Types.XrSwapchain(XrSwapchains[0], (Enumerators.VkFormat)chosenFormat, configViews[0].recommendedImageRectWidth, configViews[0].recommendedImageRectHeight), 
            new Types.XrSwapchain(XrSwapchains[1], (Enumerators.VkFormat)chosenFormat, configViews[1].recommendedImageRectWidth, configViews[1].recommendedImageRectHeight));
    }
#endregion
#region Cleanup

    public void Cleanup()
    {
        xrDestroySession(OXRSession);

        // Instance
        xrDestroyInstance(OpenXRInstance);
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
            XrResult res = xrGetInstanceProcAddr(OpenXRInstance, namePtr,
                (delegate*unmanaged[Cdecl]<void>*)&func);
            if (res != XrResult.XR_SUCCESS)
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