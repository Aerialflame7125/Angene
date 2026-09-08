using System;
using System.Runtime.InteropServices;

namespace Angene.Input;

public unsafe class WaylandInput
{
    [Flags]
    public enum WlSeatCapability : uint
    {
        Pointer = 1,
        Keyboard = 2,
        Touch = 4
    }

    public struct UnmanagedString
    {
        public IntPtr Ptr;
        public static implicit operator string(UnmanagedString us) => Marshal.PtrToStringAnsi(us.Ptr);
    }
}