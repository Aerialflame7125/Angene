using System.Runtime.InteropServices;

namespace Angene.Input;

public unsafe class WaylandInput
{
    [StructLayout(LayoutKind.Sequential)]
    public struct wl_pointer_listener
    {
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, uint, IntPtr, int, int, void> Enter;
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, uint, IntPtr, void> Leave;
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, uint, int, int, void> Motion;
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, uint, uint, uint, uint, void> Button;
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, uint, uint, int, void> Axis;
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> Frame;
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, uint, uint, void> AxisSource;
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, uint, void> AxisStop;
        public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, uint, int, void> AxisDiscrete;
    }

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