using System.Runtime.InteropServices;

namespace Angene.Vulkan.Prereq;

public class Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_ATTRIBUTES
    {
        public int nLength;
        public IntPtr lpSecurityDescriptor;
        public int bInheritHandle;
    }
}