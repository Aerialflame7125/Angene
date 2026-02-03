using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Angene.Globals;
using Angene.Graphics;
using Angene.External;
using System.Security.Permissions;

namespace Angene.Main
{
    public class AngeneException : Exception
    {
        // 1. Default constructor
        public AngeneException()
        {
        }

        // 2. Constructor with a message
        public AngeneException(string message)
            : base(message)
        {
        }

        // 3. Constructor with a message and an inner exception
        public AngeneException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public interface IScene
    {
        public void Start() { }
        public void Update(double dt) { }
        public void LateUpdate(double dt) { }
        public void OnMessage(IntPtr msgPtr) { }
        public void OnDraw() { }
        public void Render() { }
        public void Cleanup() { }
        IRenderer3D? Renderer3D { get; }
    }

    public class Window
    {
        public IntPtr Hwnd { get; private set; }

        public List<bool> ScenesStarted { get; private set; } = new List<bool>();
        public List<IScene> Scenes { get; private set; } = new List<IScene>();
        public IScene? PrimScene { get; private set; }

        public int Width { get; }
        public int Height { get; }

        private IGraphicsContext? graphicsContext;
        private bool sceneStarted;
        private bool is3D;

        // Global map of windows
        public static readonly Dictionary<IntPtr, Window> WindowMap = new();

#if WINDOWS
        // Windows-specific fields
        private static readonly Win32.WndProcDelegate s_wndProc = DefaultWndProc;
        private static bool s_classRegistered;
#else
        // Linux/macOS-specific fields
        private IntPtr display;
        private IntPtr wmDeleteWindow;
        private bool shouldClose;
#endif

        public Window(string title, int width, int height, bool use3D = false)
        {
            Width = width;
            Height = height;
            is3D = use3D;

#if WINDOWS
            Hwnd = CreateWindowWindows(title, width, height);
            WindowMap[Hwnd] = this;

            if (!use3D)
            {
                graphicsContext = GraphicsContextFactory.Create(Hwnd, width, height);
            }
#else
            CreateWindowX11(title, width, height);
            WindowMap[Hwnd] = this;

            if (!use3D)
            {
                graphicsContext = GraphicsContextFactory.CreateX11(display, Hwnd, width, height);
            }
#endif
        }

        public void SetScene(IScene scene)
        {
            Scenes.Clear();
            ScenesStarted.Clear();
            Scenes.Add(scene);
            ScenesStarted.Add(false);
            PrimScene = scene;
        }

        public void AddScene(IScene scene)
        {
            if (Scenes.Count != ScenesStarted.Count)
            {
                throw new AngeneException("The number of 'Scenes' and 'ScenesStarted' are not equivalent. Please do not edit these variables manually and instead use AddScene() or SetScene()");
            }
            Scenes.Add(scene);
            ScenesStarted.Add(false);
        }

        public void RemScene(IScene scene)
        {
            int index = Scenes.IndexOf(scene);
            if (index == -1)
            {
                throw new AngeneException("The scene to be removed was not found in the current scene list.");
            }
            Scenes.RemoveAt(index);
            ScenesStarted.RemoveAt(index);
        }

        public void Cleanup()
        {
            if (!is3D && graphicsContext != null)
            {
                graphicsContext.Cleanup();
            }

            foreach (IScene Scene in Scenes)
            {
                Scene?.Renderer3D?.Cleanup();
                Scene?.Cleanup();
            }
        }

#if WINDOWS
        // ==================== WINDOWS IMPLEMENTATION ====================

        private static IntPtr CreateWindowWindows(string title, int width, int height)
        {
            // Register class once
            if (!s_classRegistered)
            {
                var wc = new Win32.WNDCLASSEX
                {
                    cbSize = (uint)Marshal.SizeOf<Win32.WNDCLASSEX>(),
                    style = 0,
                    lpfnWndProc = s_wndProc,
                    cbClsExtra = 0,
                    cbWndExtra = 0,
                    hInstance = Kernel32.GetModuleHandle(null),
                    hIcon = IntPtr.Zero,
                    hCursor = IntPtr.Zero,
                    hbrBackground = IntPtr.Zero,
                    lpszMenuName = null,
                    lpszClassName = "AngeneClass",
                    hIconSm = IntPtr.Zero
                };

                ushort atom = Win32.RegisterClassExW(ref wc);
                if (atom == 0)
                {
                    throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
                }

                s_classRegistered = true;
            }

            IntPtr hInstance = Kernel32.GetModuleHandle(null);
            IntPtr hwnd = Win32.CreateWindowExW(
                0,
                "AngeneClass",
                title,
                Win32.WS_OVERLAPPEDWINDOW,
                Win32.CW_USEDEFAULT,
                Win32.CW_USEDEFAULT,
                width,
                height,
                IntPtr.Zero,
                IntPtr.Zero,
                hInstance,
                IntPtr.Zero
            );

            if (hwnd == IntPtr.Zero)
                throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());

            Win32.ShowWindow(hwnd, Win32.SW_SHOW);
            Win32.UpdateWindow(hwnd);
            return hwnd;
        }

        private static IntPtr DefaultWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            // Forward message to scene if found
            if (WindowMap.TryGetValue(hWnd, out var win) && win.PrimScene != null)
            {
                var managedMsg = new Win32.MSG
                {
                    hwnd = hWnd,
                    message = msg,
                    wParam = wParam,
                    lParam = lParam,
                    time = 0,
                    pt_x = 0,
                    pt_y = 0
                };

                IntPtr msgPtr = Marshal.AllocHGlobal(Marshal.SizeOf<Win32.MSG>());
                try
                {
                    Marshal.StructureToPtr(managedMsg, msgPtr, false);
                    try
                    {
                        win.PrimScene.OnMessage(msgPtr);
                    }
                    catch
                    {
                        // Ignore exceptions from scene
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(msgPtr);
                }
            }

            if (msg == Win32.WM_CLOSE)
            {
                if (WindowMap.TryGetValue(hWnd, out var w))
                {
                    w.Cleanup();
                }
                Win32.DestroyWindow(hWnd);
                return IntPtr.Zero;
            }

            if (msg == Win32.WM_DESTROY)
            {
                Win32.PostQuitMessage(0);
                return IntPtr.Zero;
            }

            return Win32.DefWindowProcW(hWnd, msg, wParam, lParam);
        }

        public static bool ProcessMessages()
        {
            while (Win32.PeekMessageW(out var msg, IntPtr.Zero, 0, 0, Win32.PM_REMOVE))
            {
                if (msg.message == Win32.WM_QUIT)
                    return false;

                Win32.TranslateMessage(ref msg);
                Win32.DispatchMessageW(ref msg);
            }
            return true;
        }
#else
        // ==================== LINUX/MACOS X11 IMPLEMENTATION ====================

        private void CreateWindowX11(string title, int width, int height)
        {
            // X11 is a static class, no need to instantiate
            display = Platform.Linux.X11.XOpenDisplay(IntPtr.Zero);
            if (display == IntPtr.Zero)
            {
                throw new Exception("Failed to open X11 display");
            }

            int screen = Platform.Linux.X11.XDefaultScreen(display);
            IntPtr rootWindow = Platform.Linux.X11.XRootWindow(display, screen);

            var attributes = new Platform.Linux.X11.XSetWindowAttributes();
            attributes.background_pixel = Platform.Linux.X11.XWhitePixel(display, screen);
            attributes.event_mask =
                Platform.Linux.X11.KeyPressMask |
                Platform.Linux.X11.KeyReleaseMask |
                Platform.Linux.X11.ButtonPressMask |
                Platform.Linux.X11.ButtonReleaseMask |
                Platform.Linux.X11.PointerMotionMask |
                Platform.Linux.X11.ExposureMask |
                Platform.Linux.X11.StructureNotifyMask;

            Hwnd = Platform.Linux.X11.XCreateWindow(
                display,
                rootWindow,
                0, 0,
                (uint)width, (uint)height,
                0,
                24, // depth
                1, // InputOutput class
                IntPtr.Zero, // default visual
                Platform.Linux.X11.CWBackPixel | Platform.Linux.X11.CWEventMask,
                ref attributes
            );

            if (Hwnd == IntPtr.Zero)
            {
                throw new Exception("Failed to create X11 window");
            }

            // Set window title
            Platform.Linux.X11.XStoreName(display, Hwnd, title);

            // Handle window close button
            wmDeleteWindow = Platform.Linux.X11.XInternAtom(display, "WM_DELETE_WINDOW", false);
            Platform.Linux.X11.XSetWMProtocols(display, Hwnd, new[] { wmDeleteWindow }, 1);

            // Show window
            Platform.Linux.X11.XMapWindow(display, Hwnd);
            Platform.Linux.X11.XFlush(display);

            shouldClose = false;
        }

        public bool ProcessMessages()
        {
            if (shouldClose)
                return false;

            while (Platform.Linux.X11.XPending(display) > 0)
            {
                Platform.Linux.X11.XNextEvent(display, out var xevent);

                // Create a message structure similar to Win32
                var msg = new PlatformMessage
                {
                    hwnd = Hwnd,
                    message = (uint)xevent.type,
                    wParam = IntPtr.Zero,
                    lParam = IntPtr.Zero
                };

                switch (xevent.type)
                {
                    case Platform.Linux.X11.ClientMessage:
                        if (xevent.xclient.data[0] == wmDeleteWindow)
                        {
                            Cleanup();
                            shouldClose = true;
                            return false;
                        }
                        break;

                    case Platform.Linux.X11.KeyPress:
                        msg.wParam = new IntPtr((int)xevent.xkey.keycode);
                        break;

                    case Platform.Linux.X11.KeyRelease:
                        msg.wParam = new IntPtr((int)xevent.xkey.keycode);
                        break;

                    case Platform.Linux.X11.ButtonPress:
                        msg.wParam = new IntPtr((int)xevent.xbutton.button);
                        msg.lParam = new IntPtr((xevent.xbutton.y << 16) | (xevent.xbutton.x & 0xFFFF));
                        break;

                    case Platform.Linux.X11.ButtonRelease:
                        msg.wParam = new IntPtr((int)xevent.xbutton.button);
                        msg.lParam = new IntPtr((xevent.xbutton.y << 16) | (xevent.xbutton.x & 0xFFFF));
                        break;

                    case Platform.Linux.X11.MotionNotify:
                        msg.lParam = new IntPtr((xevent.xmotion.y << 16) | (xevent.xmotion.x & 0xFFFF));
                        break;

                    case Platform.Linux.X11.Expose:
                        // Repaint request
                        break;
                }

                // Forward to scene
                if (PrimScene != null)
                {
                    IntPtr msgPtr = Marshal.AllocHGlobal(Marshal.SizeOf<PlatformMessage>());
                    try
                    {
                        Marshal.StructureToPtr(msg, msgPtr, false);
                        try
                        {
                            PrimScene.OnMessage(msgPtr);
                        }
                        catch
                        {
                            // Ignore scene exceptions
                        }
                    }
                    finally
                    {
                        Marshal.FreeHGlobal(msgPtr);
                    }
                }
            }

            return true;
        }

        ~Window()
        {
            if (display != IntPtr.Zero)
            {
                if (Hwnd != IntPtr.Zero)
                {
                    Platform.Linux.X11.XDestroyWindow(display, Hwnd);
                }
                Platform.Linux.X11.XCloseDisplay(display);
            }
        }
#endif

        // Platform-agnostic message structure
        [StructLayout(LayoutKind.Sequential)]
        public struct PlatformMessage
        {
            public IntPtr hwnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
        }

        // Public graphics API (platform-agnostic)
        public IGraphicsContext? Graphics => graphicsContext;
    }
}