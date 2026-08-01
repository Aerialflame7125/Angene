using System;
using System.Runtime.InteropServices;

public static class VulkanResolver
{
    public const string LibName = "vulkan";

    public static IntPtr ResolveVulkanLib(string libraryName, System.Reflection.Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (libraryName == LibName)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Windows requires the -1 suffix
                return NativeLibrary.Load("vulkan-1.dll", assembly, searchPath);
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // Linux standard system library name
                return NativeLibrary.Load("libvulkan.so.1", assembly, searchPath);
            }
        }
        // Fallback to default loading behavior for other libraries
        return IntPtr.Zero; 
    }
}