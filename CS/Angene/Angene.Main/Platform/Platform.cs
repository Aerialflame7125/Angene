using System;
using System.Runtime.InteropServices;

namespace Angene.Platform
{
    public static class PlatformDetection
    {
        public static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static bool IsLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        public static bool IsMacOS => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        
        public static string CurrentPlatform
        {
            get
            {
                if (IsWindows) return "Windows";
                if (IsLinux) return "Linux";
                if (IsMacOS) return "macOS";
                return "Unknown";
            }
        }
    }
}