using Angene.External;
using Angene.Globals;
using Angene.Graphics;
using Angene.Platform;
using Angene.Essentials;
using Angene.Common;
using Angene.Common.Settings;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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

    public class Console
    {
        public static void WriteLine(string text)
        {
            Logger.Log("Call to WriteLine() is incorrect in this engine. Please use Logger.Log.", LoggingTarget.MainGame, LogLevel.Warning);
            Logger.Log(text, LoggingTarget.MainGame, LogLevel.Info);
        }
        public static void ReadLine(string text)
        {
            Logger.Log("Call to ReadLine() is incorrect in this engine. Console input is not available, nor supported.", LoggingTarget.MainGame, LogLevel.Warning);
        }
        public static void Write(string text)
        {
            Logger.Log("Call to Write() is incorrect in this engine. Please use Logger.Log.", LoggingTarget.MainGame, LogLevel.Warning);
            Logger.Log(text, LoggingTarget.MainGame, LogLevel.Info);
        }
    }

    public class Engine
    {
        private Settings _settingHandlerInstanced;
        private LogConsoleWindow? _logConsole; // log window keepalive

        public Settings SettingHandlerInstanced
        {
            get
            {
                if (_settingHandlerInstanced == null)
                {
                    throw new AngeneException(
                        "Settings handler not initialized. Please call Engine.Init() before accessing settings."
                    );
                }

                return _settingHandlerInstanced;
            }
            private set
            {
                _settingHandlerInstanced = value;
            }
        }

        public static Engine Instance { get; } = new Engine();
        public void Init(bool verbose = false)
        {
            SettingHandlerInstanced = new Settings();
            SettingHandlerInstanced.LoadDefaults();
            Logger.Instance.Init(verbose);

            if (verbose)
            {
                _logConsole = new LogConsoleWindow();

                Logger.Instance.OnLog += (message, target, level, time, exception) =>
                {
                    if (exception != null)
                        _logConsole.AppendLine($"[{level}] {target} ({time}) {message}\n{exception}");
                    else
                        _logConsole.AppendLine($"[{level}] {target} ({time}) {message}");
                };

                Logger.Log("Verbose log console initialized.", LoggingTarget.Engine, LogLevel.Important);
            }
        }
    }

    public class Window
    {
        public IntPtr Hwnd { get; private set; }

        public List<IScene> Scenes { get; private set; } = new List<IScene>();
        public IScene? PrimaryScene { get; private set; }

        public int Width { get; }
        public int Height { get; }

        private IGraphicsContext? graphicsContext;
        private bool is3D;
        
        // Engine mode tracking
        private EngineMode _engineMode = EngineMode.Edit;

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

        public Window(WindowConfig config)
        {
            Width = config.Width;
            Height = config.Height;
            is3D = config.Use3D;

#if WINDOWS
            Hwnd = CreateWindowWindows(config);
            WindowMap[Hwnd] = this;

            if (!config.Use3D)
            {
                graphicsContext = GraphicsContextFactory.Create(Hwnd, config.Width, config.Height);
            }
#else
            CreateWindowX11(config.Title, config.Width, config.Height);
            WindowMap[Hwnd] = this;

            if (!config.Use3D)
            {
                graphicsContext = GraphicsContextFactory.CreateX11(display, Hwnd, config.Width, config.Height);
            }
#endif

            Logger.Log("Window created successfully", LoggingTarget.Engine, LogLevel.Important);
        }

        /// <summary>
        /// Set the primary scene and clear all other scenes.
        /// </summary>
        public void SetScene(IScene scene)
        {
            if (scene == null)
            {
                Logger.Log("Attempted to set null scene", LoggingTarget.Engine, LogLevel.Error);
                return;
            }

            // Clean up existing scenes
            foreach (var existingScene in Scenes)
            {
                existingScene?.Cleanup();
            }

            Scenes.Clear();
            Scenes.Add(scene);
            PrimaryScene = scene;

            // Initialize the scene
            scene.Initialize();

            Logger.Log($"Primary scene set to '{scene.GetType().Name}'", LoggingTarget.Engine, LogLevel.Important);
        }

        /// <summary>
        /// Add an additional scene to the window.
        /// </summary>
        public void AddScene(IScene scene)
        {
            if (scene == null)
            {
                Logger.Log("Attempted to add null scene", LoggingTarget.Engine, LogLevel.Error);
                return;
            }

            Scenes.Add(scene);
            scene.Initialize();

            Logger.Log($"Scene '{scene.GetType().Name}' added to window", LoggingTarget.Engine, LogLevel.Info);
        }

        /// <summary>
        /// Remove a scene from the window.
        /// </summary>
        public void RemoveScene(IScene scene)
        {
            if (scene == null)
            {
                Logger.Log("Attempted to remove null scene", LoggingTarget.Engine, LogLevel.Warning);
                return;
            }

            int index = Scenes.IndexOf(scene);
            if (index == -1)
            {
                Logger.Log("The scene to be removed was not found in the current scene list", LoggingTarget.Engine, LogLevel.Warning);
                return;
            }

            Scenes.RemoveAt(index);
            scene.Cleanup();

            if (PrimaryScene == scene)
            {
                PrimaryScene = Scenes.Count > 0 ? Scenes[0] : null;
            }

            Logger.Log($"Scene '{scene.GetType().Name}' removed from window", LoggingTarget.Engine, LogLevel.Info);
        }

        /// <summary>
        /// Set the engine mode (Edit, Play, Paused).
        /// This affects which lifecycle methods are executed.
        /// </summary>
        public void SetEngineMode(EngineMode mode)
        {
            if (_engineMode != mode)
            {
                _engineMode = mode;
                Logger.Log($"Engine mode changed to: {mode}", LoggingTarget.Engine, LogLevel.Important);
            }
        }

        /// <summary>
        /// Get the current engine mode.
        /// </summary>
        public EngineMode GetEngineMode()
        {
            return _engineMode;
        }

        public void Cleanup()
        {
            Logger.Log("Cleaning up window resources", LoggingTarget.Engine, LogLevel.Important);

            if (!is3D && graphicsContext != null)
            {
                graphicsContext.Cleanup();
            }

            foreach (IScene scene in Scenes)
            {
                scene?.Renderer3D?.Cleanup();
                scene?.Cleanup();
            }
        }

#if WINDOWS
        // windows apis
        private static IntPtr CreateWindowWindows(WindowConfig config)
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
                (uint)config.StyleEx,
                "AngeneClass",
                config.Title,
                (uint)config.Style,
                config.X,
                config.Y,
                config.Width,
                config.Height,
                IntPtr.Zero,
                IntPtr.Zero,
                hInstance,
                IntPtr.Zero
            );

            if (hwnd == IntPtr.Zero)
                throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());

            Win32.ShowWindow(hwnd, Win32.SW_SHOW);
            Logger.Log($"Window({hwnd}) shown", LoggingTarget.Engine);
            Win32.UpdateWindow(hwnd);
            return hwnd;
        }

        private static IntPtr DefaultWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            // Forward message to scenes if window found
            if (WindowMap.TryGetValue(hWnd, out var win) && win.PrimaryScene != null)
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
                        // Forward to all scenes (in reverse order for event bubbling)
                        for (int i = win.Scenes.Count - 1; i >= 0; i--)
                        {
                            win.Scenes[i].OnMessage(msgPtr);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(
                            $"Exception in scene OnMessage: {ex.Message}",
                            LoggingTarget.Engine,
                            LogLevel.Error
                        );
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

        /// <summary>
        /// Process Windows messages.
        /// Returns false when WM_QUIT is received.
        /// </summary>
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

            Platform.Linux.X11.XStoreName(display, Hwnd, title);

            wmDeleteWindow = Platform.Linux.X11.XInternAtom(display, "WM_DELETE_WINDOW", false);
            Platform.Linux.X11.XSetWMProtocols(display, Hwnd, new[] { wmDeleteWindow }, 1);

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

                // Forward to scenes
                if (PrimaryScene != null)
                {
                    IntPtr msgPtr = Marshal.AllocHGlobal(Marshal.SizeOf<PlatformMessage>());
                    try
                    {
                        Marshal.StructureToPtr(msg, msgPtr, false);
                        try
                        {
                            for (int i = Scenes.Count - 1; i >= 0; i--)
                            {
                                Scenes[i].OnMessage(msgPtr);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Log(
                                $"Exception in scene OnMessage: {ex.Message}",
                                LoggingTarget.Engine,
                                LogLevel.Error
                            );
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

        // platform messages
        [StructLayout(LayoutKind.Sequential)]
        public struct PlatformMessage
        {
            public IntPtr hwnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
        }

        // graphics context
        public IGraphicsContext? Graphics => graphicsContext;
    }
}