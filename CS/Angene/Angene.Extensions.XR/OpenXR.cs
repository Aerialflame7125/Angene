using System.Runtime.InteropServices;
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
    public static XrInstance OpenXRInstance;
    public static OpenXR Instance;
    public static ulong systemID = 0;
    private static List<string> layerNames = new List<string>() { "XR_APILAYER_LUNARG_core_validation" };
    private static List<string> extensionNames = new List<string>(){ };

    public static string[] instanceExtensions;
    public static string[] deviceExtensions;
    private static IVkGraphicsContext vulkanGraphicsContext = null;
    private static IDX11GraphicsContext dx11GraphicsContext = null;
    private static XrGraphicsRequirementsVulkanKHR VulkanReqs;
    private static XrGraphicsRequirementsD3D11KHR D3D11Reqs;
#endregion
#region Instance Creation
    public static void CreateInstanceS1(object usedContext, Types.AppInfo appInfo)
    {
        Instance = new OpenXR();
        switch (usedContext)
        {
            case IVkGraphicsContext vk:
                vulkanGraphicsContext = vk;
                extensionNames.Add("XR_KHR_vulkan_enable");
                extensionNames.Add("XR_KHR_vulkan_enable2");
                
                Instance.CreateInstance(appInfo);
                Instance.getSystem();
                getVulkanInstanceRequirements();
                break;
            case IDX11GraphicsContext dx1:
                dx11GraphicsContext = dx1;
                extensionNames.Add("XR_KHR_D3D11_enable");
                
                Instance.CreateInstance(appInfo);
                Instance.getSystem();
                getD3D11InstanceRequirements();
                break;
            default:
                throw new Exceptions.FailedToInitializeOpenXRException(
                    $"Graphics context of type '{usedContext.GetType()}' is not supported.");
        }
    }

    private void CreateInstance(Types.AppInfo appInfo)
    {
        XrInstance instance;
        
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
                    type = XrStructureType.XR_TYPE_INSTANCE_CREATE_INFO,
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

                XrResult res = xrCreateInstance(&instanceCreateInfo, &instance);

                if (res != XrResult.XR_SUCCESS)
                    throw new Exceptions.FailedToInitializeOpenXRException(
                        $"Failed to create OpenXR instance: {res}");
            }
        }
        finally
        {
            foreach (var ptr in extensionPtrs)
                Marshal.FreeHGlobal(ptr);
            foreach (var ptr in layerPtrs)
                Marshal.FreeHGlobal(ptr);
        }
        OpenXRInstance = instance;
    }

    private void getSystem()
    {
        ulong systemId;

        XrSystemGetInfo systemGetInfo = new XrSystemGetInfo()
        {
            type = XrStructureType.XR_TYPE_SYSTEM_GET_INFO,
            formFactor = XrFormFactor.XR_FORM_FACTOR_HEAD_MOUNTED_DISPLAY
        };

        fixed (XrInstance* xrInstancePtr = &OpenXRInstance)
        {
            XrResult res = xrGetSystem(xrInstancePtr, &systemGetInfo, &systemId);

            if (res != XrResult.XR_SUCCESS)
                throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get OpenXR system: '{res}'");
            
            systemID = systemId;
        }
    }

    private static void getVulkanInstanceRequirements()
    {
        var getReqs = (delegate* unmanaged[Cdecl]<XrInstance, ulong, XrGraphicsRequirementsVulkanKHR*, XrResult>)
            getXrFunction("xrGetVulkanGraphicsRequirementsKHR");
        var getExts = (delegate* unmanaged[Cdecl]<XrInstance, ulong, uint, uint*, byte*, XrResult>)
            getXrFunction("xrGetVulkanInstanceExtensionsKHR");

        VulkanReqs = new XrGraphicsRequirementsVulkanKHR { type = XrStructureType.XR_TYPE_GRAPHICS_REQUIREMENTS_VULKAN_KHR };
        fixed (XrGraphicsRequirementsVulkanKHR* r = &VulkanReqs)
        {
            var res = getReqs(OpenXRInstance, systemID, r);
            if (res != XrResult.XR_SUCCESS) throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get Vulkan Instance requirements for OpenXR: {res}");
        }

        uint size;
        var res2 = getExts(OpenXRInstance, systemID, 0, &size, null);
        if (res2 != XrResult.XR_SUCCESS) throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get Vulkan Instance requirements for OpenXR: {res2}");

        var buf = new byte[size];
        fixed (byte* p = buf)
            res2 = getExts(OpenXRInstance, systemID, size, &size, p);
        if (res2 != XrResult.XR_SUCCESS) throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get Vulkan Instance requirements for OpenXR: {res2}");

        instanceExtensions = System.Text.Encoding.ASCII
            .GetString(buf, 0, (int)size).TrimEnd('\0')
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }
    
    private static void getD3D11InstanceRequirements()
    {
        var getReqs = (delegate* unmanaged[Cdecl]<XrInstance, ulong, XrGraphicsRequirementsD3D11KHR*, XrResult>)
            getXrFunction("xrGetD3D11GraphicsRequirementsKHR");
        var getExts = (delegate* unmanaged[Cdecl]<XrInstance, ulong, uint, uint*, byte*, XrResult>)
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
    
    public static (IntPtr, string[]) getVulkanDeviceRequirements()
    {
        var getGraphicsDevice = (delegate* unmanaged[Cdecl]<XrInstance, ulong, IntPtr, IntPtr*, XrResult>)
            getXrFunction("xrGetVulkanGraphicsDeviceKHR");
        var getExts = (delegate* unmanaged[Cdecl]<XrInstance, ulong, uint, uint*, byte*, XrResult>)
            getXrFunction("xrGetVulkanDeviceExtensionsKHR");

        IntPtr physicalDevice;

        XrResult res = getGraphicsDevice(OpenXRInstance, systemID, vulkanGraphicsContext.VkInstance, &physicalDevice);
        if (res != XrResult.XR_SUCCESS)
            throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get Vulkan graphics device for OpenXR: '{res}'");

        uint deviceExtensionsSize;
        
        res = getExts(OpenXRInstance, systemID, 0, &deviceExtensionsSize, null);
        if (res != XrResult.XR_SUCCESS)
            throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get Vulkan device extensions for OpenXR: '{res}'");
        
        var buf = new byte[deviceExtensionsSize];
        fixed (byte* p = buf)
        {
            res = getExts(OpenXRInstance, systemID, deviceExtensionsSize, &deviceExtensionsSize, p);
            if (res != XrResult.XR_SUCCESS)
                throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get Vulkan device extensions for OpenXR: '{res}'");
        }

        return (physicalDevice, deviceExtensions);
    }
#endregion
#region Cleanup

    public void Cleanup()
    {
        // Instance
        fixed (XrInstance* xrInstancePtr = &OpenXRInstance)
            xrDestroyInstance(xrInstancePtr);
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

        fixed (XrInstance* xrInstancePtr = &OpenXRInstance)
        {
            XrResult res = xrGetInstanceProcAddr(xrInstancePtr, (byte*)Convert.ToSByte(name), (delegate*unmanaged[Cdecl]<void>*)&func);
            
            if (res != XrResult.XR_SUCCESS)
                throw new Exceptions.FailedToInitializeOpenXRException($"Failed to get OpenXR instance: {res}");

            return func;
        }
    }
#endregion
}