using System.Runtime.InteropServices;
using static Angene.Windows.Dxgi.DxgiInterfaces;

namespace Angene.Windows.Graphics
{
    public class DxgiFunctions
    {
        // DXGI Factories
        [DllImport("dxgi.dll", ExactSpelling = true, PreserveSig = true)] // DXGI 1.0 (https://learn.microsoft.com/en-us/windows/win32/api/DXGI/nf-dxgi-createdxgifactory)
        public static extern uint CreateDXGIFactory(ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IDXGIFactory ppFactory);
        [DllImport("dxgi.dll", ExactSpelling = true, PreserveSig = true)] // DXGI 1.1 (https://learn.microsoft.com/en-us/windows/win32/api/DXGI/nf-dxgi-createdxgifactory1)
        public static extern uint CreateDXGIFactory1(ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IDXGIFactory1 ppFactory); 
        [DllImport("dxgi.dll", ExactSpelling = true, PreserveSig = true)] // DXGI 1.3 (https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-createdxgifactory2)
        public static extern uint CreateDXGIFactory2(uint Flags, // Important!! Only set if DXGIDebug.dll is loaded. Otherwise, do not set.
            ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IDXGIFactory2 ppFactory);

        // Other DXGI Functions
        [DllImport("dxgi.dll", ExactSpelling = true, PreserveSig = true)] // "Process indication that says it is resilient to any graphic devices being removed"
        public static extern uint DXGIDeclareAdapterRemovalSupport(); // https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nf-dxgi1_6-dxgideclareadapterremovalsupport
        [DllImport("dxgi.dll", ExactSpelling = true, PreserveSig = true)] // Allows for APIs to see changing refresh rate, used by "DRR" (dynamic refresh rate)
        public static extern uint DXGIDisableVBlankVirtualization();
        [DllImport("dxgi.dll", ExactSpelling = true, PreserveSig = true)] // Gets Debugging interface
        public static extern uint DXGIGetDebugInterface(ref Guid riid, IntPtr ppDebug);
        [DllImport("dxgi.dll", ExactSpelling = true, PreserveSig = true)] // Gets the debugging interface (But for microsoft store apps)
        public static extern uint DXGIGetDebugInterface1(uint Flags, // not used?? just dont set it or pass 0 ig.
            Guid riid, // guid of interface type
            out IntPtr pDebug // pointer to interface type
        );
    }
}
