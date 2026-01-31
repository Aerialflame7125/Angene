using System;
using System.Runtime.InteropServices;

namespace Angene.Main
{
    public static class Kernel32
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetCurrentProcess();
    }
}

