using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Angene.Common;
using Angene.Graphics;
using Angene.Linux.Wayland;
using Angene.Main;

namespace Angene.Input;

public unsafe class WaylandInputHandler : IDisposable
{
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

    private readonly HashSet<uint> _downKeys = new();
    public readonly static WaylandInputHandler instance = new();
    private readonly object _lock = new();
    private GCHandle _gcHandle;
    private bool _disposed;

    public WaylandInputHandler()
    {
        _gcHandle = GCHandle.Alloc(this, GCHandleType.Normal);
        Engine.Instance.OnWaylandRegistryChanged += OnWaylandRegistry;
    }

    public void RegisterSeat(IntPtr wlSeatProxy)
    {
        IntPtr nativeHandle = GCHandle.ToIntPtr(_gcHandle);
        
        fixed (WaylandClient.wl_seat_listener* listenerPtr = &SeatListener)
        {
            WaylandClient.Methods.wl_proxy_add_listener(wlSeatProxy, (IntPtr)listenerPtr, (void*)nativeHandle);
        }
    }
    
    void OnWaylandRegistry(IntPtr registry, uint name, IntPtr @interface, uint version)
    {
        string interfaceName = Marshal.PtrToStringAnsi((IntPtr)@interface);
        if (interfaceName == "wl_seat")
        {
            IntPtr _wlSeat =
                WaylandClient.Methods.wl_registry_bind(
                    (IntPtr)registry,
                    name,
                    (WaylandClient.wl_interface*)WaylandClient.Methods.GetWlSeatInterface(),
                    System.Math.Min(version, 7));

            WaylandInputHandler.instance.RegisterSeat(
                _wlSeat);
        }
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
                (WaylandClient.wl_interface*)wlKeyboardInterface,
                __arglist(IntPtr.Zero)
            );

            if (kbdProxy != IntPtr.Zero)
            {
                fixed (WaylandClient.wl_keyboard_listener* kbdListenerPtr = &KeyboardListener)
                {
                    WaylandClient.Methods.wl_proxy_add_listener(kbdProxy, (IntPtr)kbdListenerPtr, data);
                }
            }
        }
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnKey(void* data, IntPtr keyboard, uint serial, uint time, uint key, uint state)
    {
        var handler = GCHandle.FromIntPtr((IntPtr)data).Target as WaylandInputHandler;
        if (handler == null) return;
        
        lock (handler._lock)
        {
            if (state == 1) // Pressed
            {
                handler._downKeys.Add(key);
            }
            else // Released
            {
                handler._downKeys.Remove(key);
            }
        }
    }

    public bool IsKeyDown(uint keycode)
    {
        lock (_lock)
        {
            return _downKeys.Contains(keycode);
        }
    }

    public bool IsAnyKeyDown()
    {
        lock (_lock)
        {
            return _downKeys.Count > 0;
        }
    }

    public List<uint> GetPressedKeys()
    {
        lock (_lock)
        {
            return new List<uint>(_downKeys);
        }
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnName(void* data, IntPtr seat, sbyte* name) 
        => Logger.LogDebug($"Seat Name: {Marshal.PtrToStringAnsi((IntPtr)name)}", LoggingTarget.Engine);

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })] private static void OnKeymap(void* d, IntPtr k, uint f, int fd, uint s) {}
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })] private static void OnKeyboardEnter(void* d, IntPtr k, uint s, WaylandClient.wl_surface* sf, WaylandClient.wl_array* a) {}
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })] private static void OnKeyboardLeave(void* d, IntPtr k, uint s, WaylandClient.wl_surface* sf) {}
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })] private static void OnModifiers(void* d, IntPtr k, uint s, uint m, uint d2, uint g, uint l) {}
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })] private static void OnRepeatInfo(void* d, IntPtr k, int r, int d2) {}

    public void Dispose()
    {
        if (!_disposed)
        {
            if (_gcHandle.IsAllocated)
                _gcHandle.Free();
            _disposed = true;
        }
    }
}