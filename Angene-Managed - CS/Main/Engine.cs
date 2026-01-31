using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Angene.Globals;

namespace Angene.Main
{
    public interface IScene
    {
        void Start();
        void Update(double dt);
        void LateUpdate(double dt);
        void OnMessage(IntPtr msgPtr);
        void OnDraw();
        void Render();
        void Cleanup();

        IRenderer3D? Renderer3D { get; }
    }

    public class Window
    {
        public IntPtr Hwnd { get; private set; }
        public IScene? Scene { get; private set; }

        public int Width { get; }
        public int Height { get; }

        private IntPtr memDc;
        private IntPtr bmp;
        private IntPtr oldBmp;

        private bool sceneStarted;
        private bool is3D;

        // Global map of windows (previous code used unqualified WindowMap)
        public static readonly Dictionary<IntPtr, Window> WindowMap = new();

        // Keep delegate alive for the lifetime of the process
        private static readonly Win32.WndProcDelegate s_wndProc = DefaultWndProc;
        private static bool s_classRegistered;

        public Window(string title, int width, int height, bool use3D = false)
        {
            Hwnd = CreateNewWindow(title, width, height);
            Width = width;
            Height = height;
            is3D = use3D;
            sceneStarted = false;

            WindowMap[Hwnd] = this;

            if (!use3D)
            {
                IntPtr hdc = Win32.GetDC(Hwnd);
                memDc = Gdi32.CreateCompatibleDC(hdc);
                bmp = Gdi32.CreateCompatibleBitmap(hdc, width, height);
                oldBmp = Gdi32.SelectObject(memDc, bmp);
                Win32.ReleaseDC(Hwnd, hdc);
            }
        }

        public void SetScene(IScene scene)
        {
            Scene = scene;
            sceneStarted = false;
        }

        public void Cleanup()
        {
            if (!is3D)
            {
                if (oldBmp != IntPtr.Zero)
                    Gdi32.SelectObject(memDc, oldBmp);

                if (bmp != IntPtr.Zero)
                    Gdi32.DeleteObject(bmp);

                if (memDc != IntPtr.Zero)
                    Gdi32.DeleteDC(memDc);
            }

            Scene?.Renderer3D?.Cleanup();
            Scene?.Cleanup();
        }

        // Minimal CreateNewWindow implementation so unqualified calls compile.
        // Registers a simple window class if needed and creates the window.
        private static IntPtr CreateNewWindow(string title, int width, int height)
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
                    // RegisterClassExW uses SetLastError; propagate the actual Win32 error
                    throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
                }

                s_classRegistered = true;
            }

            // Use no extended style (0) and the normal overlapped window style for dwStyle
            IntPtr hInstance = Kernel32.GetModuleHandle(null);
            IntPtr hwnd = Win32.CreateWindowExW(
                0, // dwExStyle
                "AngeneClass", // lpClassName
                title, // lpWindowName
                Win32.WS_OVERLAPPEDWINDOW, // dwStyle
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

        // simple default wndproc that forwards to DefWindowProcW
        // Now forwards all messages to the scene via unmanaged Win32.MSG pointer
        private static IntPtr DefaultWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            // Forward message to scene if found
            if (WindowMap.TryGetValue(hWnd, out var win) && win.Scene != null)
            {
                // Build a managed MSG
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

                // Marshal to unmanaged memory and send pointer to scene
                IntPtr msgPtr = Marshal.AllocHGlobal(Marshal.SizeOf<Win32.MSG>());
                try
                {
                    Marshal.StructureToPtr(managedMsg, msgPtr, false);
                    try
                    {
                        win.Scene.OnMessage(msgPtr);
                    }
                    catch
                    {
                        // Ignore exceptions from scene message handler to keep OS window procedure stable
                        // Optionally log here
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(msgPtr);
                }
            }

            // Handle window lifecycle messages locally as well
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
                // Ensure WM_QUIT is posted so the message loop can exit
                Win32.PostQuitMessage(0);
                return IntPtr.Zero;
            }

            // Default behavior
            return Win32.DefWindowProcW(hWnd, msg, wParam, lParam);
        }
    }
}