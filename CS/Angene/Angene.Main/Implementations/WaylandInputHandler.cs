using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Angene.Common;
using Angene.Linux.Wayland;
using static Angene.Linux.Wayland.WaylandClient;
using static Angene.Linux.Wayland.xkbcommon.Methods;
using static Angene.Linux.Wayland.xkbcommon;
using System.IO.MemoryMappedFiles;

namespace Angene.Input;

public unsafe class WaylandInputHandler : IDisposable
{
    // libc
    [DllImport("libc", SetLastError = true)]
    private static extern IntPtr mmap(IntPtr addr, nuint length, int prot, int flags, int fd, long offset);

    [DllImport("libc", SetLastError = true)]
    private static extern int munmap(IntPtr addr, nuint length);

    [DllImport("libc", SetLastError = true)]
    private static extern int close(int fd);
    
    private const int PROT_READ = 0x1;
    private const int MAP_PRIVATE = 0x2;
    
    private static readonly WaylandClient.wl_seat_listener SeatListener = new()
    {
        capabilities = &OnCapabilities,
        name = &OnName
    };

    private static readonly WaylandClient.wl_keyboard_listener KeyboardListener = new()
    {
        keymap = &OnKeymap,
        enter = &OnKeyboardEnter,
        leave = &OnKeyboardLeave,
        key = &OnKey,
        modifiers = &OnModifiers,
        repeat_info = &OnRepeatInfo
    };

    private static readonly WaylandClient.wl_pointer_listener PointerListener = new()
    {
        motion = &OnMotion,
        enter = &OnEnter,
        leave = &OnLeave,
        button = &OnButton,
        axis = &OnAxis,
        frame = &OnFrame,
        axis_source = &OnAxisSource,
        axis_stop = &OnAxisStop,
        axis_discrete = &OnAxisDiscrete
    };

    private readonly HashSet<uint> _downKeys = new();
    private readonly HashSet<uint> _downMouseButtons = new();
    public readonly static WaylandInputHandler instance = new();
    private readonly object _lock = new();
    private GCHandle _gcHandle;
    private bool _disposed;

    // ---- new state ----
    private IntPtr _xkbContext;
    private IntPtr _xkbState;
    private IntPtr _seatListenerPtr;
    private static IntPtr _keyboardListenerPtr;
    private static IntPtr _pointerListenerPtr;
    private static int _mouseX, _mouseY;
    private static bool _mouseInWindow;
    
    public WaylandInputHandler()
    {
        _gcHandle = GCHandle.Alloc(this, GCHandleType.Normal);
        _xkbContext = xkb_context_new(xkb_context_flags.XKB_CONTEXT_NO_FLAGS);
    
        _keyboardListenerPtr = Marshal.AllocHGlobal(Marshal.SizeOf<WaylandClient.wl_keyboard_listener>());
        Marshal.StructureToPtr(KeyboardListener, _keyboardListenerPtr, false);
        
        _pointerListenerPtr = Marshal.AllocHGlobal(Marshal.SizeOf<WaylandClient.wl_pointer_listener>());
        Marshal.StructureToPtr(PointerListener, _pointerListenerPtr, false);

        _seatListenerPtr = Marshal.AllocHGlobal(Marshal.SizeOf<WaylandClient.wl_seat_listener>());
        Marshal.StructureToPtr(SeatListener, _seatListenerPtr, false);
    }
    
#region Seat & Constructor
    public void RegisterSeat(IntPtr wlSeatProxy)
    {
        IntPtr nativeHandle = GCHandle.ToIntPtr(_gcHandle);
        _seatListenerPtr = Marshal.AllocHGlobal(Marshal.SizeOf(SeatListener));

        Marshal.StructureToPtr(SeatListener, _seatListenerPtr, false);
        WaylandClient.Methods.wl_proxy_add_listener(wlSeatProxy, _seatListenerPtr, (void*)nativeHandle);
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnCapabilities(void* data, IntPtr seat, uint caps)
    {
        var handler = GCHandle.FromIntPtr((IntPtr)data).Target as WaylandInputHandler;
        if (handler == null) return;

        var capability = (WaylandInput.WlSeatCapability)caps;
        Logger.LogDebug($"Seat Capabilities changed: {capability}", LoggingTarget.Engine);

        if (capability.HasFlag(WaylandInput.WlSeatCapability.Keyboard))
        {
            IntPtr libwayland = NativeLibrary.Load("libwayland-client.so");
            IntPtr wlKeyboardInterface = NativeLibrary.GetExport(libwayland, "wl_keyboard_interface");
            
            IntPtr kbdProxy = WaylandClient.Methods.wl_proxy_marshal_constructor(
                seat,
                1,
                (WaylandClient.wl_interface*)wlKeyboardInterface
            );
            
            if (kbdProxy == IntPtr.Zero)
                Logger.LogError("[WaylandInputHandler] kbdProxy is null.", LoggingTarget.Engine);
            
            if (kbdProxy != IntPtr.Zero)
                WaylandClient.Methods.wl_proxy_add_listener(kbdProxy, _keyboardListenerPtr, data);
        }

        if (capability.HasFlag(WaylandInput.WlSeatCapability.Pointer))
        {
            IntPtr libwayland = NativeLibrary.Load("libwayland-client.so");
            IntPtr wlPointerInterface = NativeLibrary.GetExport(libwayland, "wl_pointer_interface");
            
            IntPtr ptrProxy = WaylandClient.Methods.wl_proxy_marshal_constructor(
                seat,
                0,
                (WaylandClient.wl_interface*)wlPointerInterface
            );
            
            if (ptrProxy == IntPtr.Zero)
                Logger.LogError("[WaylandInputHandler] ptrProxy is null.", LoggingTarget.Engine);
            
            if (ptrProxy != IntPtr.Zero)
                WaylandClient.Methods.wl_proxy_add_listener(ptrProxy, _pointerListenerPtr, data);
        }
    }
#endregion
    
#region Keyboard methods
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnKeymap(void* data, IntPtr keyboard, uint format, int fd, uint size)
    {
        var handler = GCHandle.FromIntPtr((IntPtr)data).Target as WaylandInputHandler;
        if (handler == null || format != 1)
        {
            close(fd);
            return;
        }

        IntPtr map = mmap(IntPtr.Zero, (nuint)size, PROT_READ, MAP_PRIVATE, fd, 0);
        if (map == IntPtr.Zero || map == new IntPtr(-1))
        {
            close(fd);
            return;
        }

        IntPtr newKeymap = xkb_keymap_new_from_string(
            handler._xkbContext, (sbyte*)map, xkb_keymap_format.XKB_KEYMAP_FORMAT_TEXT_V1, xkb_keymap_compile_flags.XKB_KEYMAP_COMPILE_NO_FLAGS);

        munmap(map, (nuint)size);
        close(fd);

        if (newKeymap == IntPtr.Zero)
            return;

        lock (handler._lock)
        {
            if (handler._xkbState != IntPtr.Zero)
                xkb_state_unref(handler._xkbState);

            handler._xkbState = xkb_state_new(newKeymap);
        }

        xkb_keymap_unref(newKeymap);
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnKey(void* data, IntPtr keyboard, uint serial, uint time, uint key, uint state)
    {
        var handler = GCHandle.FromIntPtr((IntPtr)data).Target as WaylandInputHandler;
        if (handler == null) return;

        lock (handler._lock)
        {
            if (handler._xkbState == IntPtr.Zero) return; // keymap hasn't arrived yet

            uint keysym = xkb_state_key_get_one_sym(handler._xkbState, key + 8);
            if (keysym == 0) return;

            if (state == 1) // Pressed
                handler._downKeys.Add(keysym);
            else // Released
                handler._downKeys.Remove(keysym);
        }
    }
    
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnModifiers(void* data, IntPtr keyboard, uint serial,
        uint modsDepressed, uint modsLatched, uint modsLocked, uint group)
    {
        var handler = GCHandle.FromIntPtr((IntPtr)data).Target as WaylandInputHandler;
        if (handler == null || handler._xkbState == IntPtr.Zero) return;

        lock (handler._lock)
        {
            xkb_state_update_mask(handler._xkbState, modsDepressed, modsLatched, modsLocked, 0, 0, group);
        }
    }

    public bool IsKeyDown(uint keycode)
    {
        lock (_lock)
            return _downKeys.Contains(keycode);
    }

    public bool IsAnyKeyDown()
    {
        lock (_lock)
            return _downKeys.Count > 0;
    }

    public List<uint> GetPressedKeys()
    {
        lock (_lock)
            return new List<uint>(_downKeys);
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnName(void* data, IntPtr seat, sbyte* name) 
        => Logger.LogDebug($"Seat Name: {Marshal.PtrToStringAnsi((IntPtr)name)}", LoggingTarget.Engine);
    
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })] private static void OnKeyboardEnter(void* d, IntPtr k, uint s, WaylandClient.wl_surface* sf, WaylandClient.wl_array* a) {}
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })] private static void OnKeyboardLeave(void* d, IntPtr k, uint s, WaylandClient.wl_surface* sf) {}
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })] private static void OnRepeatInfo(void* d, IntPtr k, int r, int d2) {}
#endregion

#region Pointer methods
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnMotion(void* data, wl_pointer* wl_pointer, uint time, int surface_x, int surface_y)
    {
        _mouseX = surface_x;
        _mouseY = surface_y;
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnEnter(void* data, wl_pointer* wl_pointer, uint serial, wl_surface* surface, int surface_x,
        int surface_y)
    {
        _mouseX = surface_x;
        _mouseY = surface_y;
        _mouseInWindow = true;
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnLeave(void* data, wl_pointer* wl_pointer, uint serial, wl_surface* surface)
    {
        _mouseInWindow = false;
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnButton(void* data, wl_pointer* wl_pointer, uint serial, uint time, uint button, uint state)
    {
        var handler = GCHandle.FromIntPtr((IntPtr)data).Target as WaylandInputHandler;
        if (handler == null) return;
        lock (handler._lock)
        {
            if (state == (uint)wl_pointer_button_state.WL_POINTER_BUTTON_STATE_PRESSED)
            {
                handler._downMouseButtons.Add(button);
            }
            else
            {
                handler._downMouseButtons.Remove(button);
            }
        }
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnAxis(void* data, wl_pointer* wl_pointer, uint time, uint axis, int value) { }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnFrame(void* data, wl_pointer* wl_pointer) {}

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnAxisDiscrete(void* data, wl_pointer* wl_pointer, uint axis, int discrete) { }
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnAxisStop(void* data, wl_pointer* wl_pointer, uint time, uint value) {}
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnAxisSource(void* data, wl_pointer* wl_pointer, uint source) {}
    
    public bool IsPointerButtonDown(uint keycode)
    {
        lock (_lock)
            return _downMouseButtons.Contains(keycode);
    }

    public bool IsAnyPointerButtonDown()
    {
        lock (_lock)
            return _downMouseButtons.Count > 0;
    }

    public List<uint> GetPressedButtons()
    {
        lock (_lock)
            return new List<uint>(_downMouseButtons);
    }

    public bool IsMouseInWindow()
    {
        lock (_lock)
            return _mouseInWindow;
    }

    public (int, int) GetMousePos()
    {
        lock (_lock)
            return (_mouseX, _mouseY);
    }
#endregion

    public void Dispose()
    {
        if (!_disposed)
        {
            if (_xkbState != IntPtr.Zero) xkb_state_unref(_xkbState);
            if (_xkbContext != IntPtr.Zero) xkb_context_unref(_xkbContext);
            if (_gcHandle.IsAllocated) _gcHandle.Free();
            
            if (_keyboardListenerPtr != IntPtr.Zero) Marshal.FreeHGlobal(_keyboardListenerPtr);
            if (_pointerListenerPtr != IntPtr.Zero) Marshal.FreeHGlobal(_pointerListenerPtr);
            if (_seatListenerPtr != IntPtr.Zero) Marshal.FreeHGlobal(_seatListenerPtr);
        
            _disposed = true;
        }
    }
}