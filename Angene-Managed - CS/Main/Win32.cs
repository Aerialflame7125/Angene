using System;
using System.Runtime.InteropServices;

namespace Angene.Main
{
    public static class Win32
    {
        // constants
        public const uint GR_GDIOBJECTS = 0;
        public const int PM_REMOVE = 0x0001;

        public const uint WM_CLOSE = 0x0010;
        public const uint WM_DESTROY = 0x0002;
        public const uint WM_ERASEBKGND = 0x0014;
        public const uint WM_QUIT = 0x0012;

        public const uint WS_OVERLAPPEDWINDOW = 0x00CF0000;
        public const int CW_USEDEFAULT = unchecked((int)0x80000000);
        public const int SW_SHOW = 5;

        // delegates
        public delegate IntPtr WndProcDelegate(
            IntPtr hWnd,
            uint msg,
            IntPtr wParam,
            IntPtr lParam
        );

        // icon related constants
        public const uint IMAGE_ICON = 1;
        public const uint LR_DEFAULTSIZE = 0x00000040;
        public const uint LR_LOADFROMFILE = 0x00000010;
        public const uint WM_SETICON = 0x0080;
        public const int ICON_SMALL = 0;
        public const int ICON_BIG = 1;

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr LoadImage(
            IntPtr hInst,
            string lpszName,
            uint uType,
            int cxDesired,
            int cyDesired,
            uint fuLoad
        );

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(
            IntPtr hWnd,
            uint Msg,
            IntPtr wParam,
            IntPtr lParam
        );
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr CreateIconFromResourceEx(
            IntPtr presbits,
            uint dwResSize,
            bool fIcon,
            uint dwVer,
            int cxDesired,
            int cyDesired,
            uint Flags
        );

        public const uint LR_DEFAULTCOLOR = 0x00000000;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool DestroyIcon(IntPtr hIcon);

        // structs
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WNDCLASSEX
        {
            public uint cbSize;
            public uint style;
            public WndProcDelegate lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public string lpszMenuName;
            public string lpszClassName;
            public IntPtr hIconSm;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            public IntPtr hwnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public int pt_x;
            public int pt_y;
        }

        // god windows sucks (user32.dll imports)
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetGuiResources(IntPtr hProcess, uint uiFlags);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr CreateWindowExW(
            uint dwExStyle,
            string lpClassName,
            string lpWindowName,
            uint dwStyle,
            int X,
            int Y,
            int nWidth,
            int nHeight,
            IntPtr hWndParent,
            IntPtr hMenu,
            IntPtr hInstance,
            IntPtr lpParam
        );

        [DllImport("user32.dll")]
        public static extern bool PeekMessageW(
            out MSG lpMsg,
            IntPtr hWnd,
            uint wMsgFilterMin,
            uint wMsgFilterMax,
            int wRemoveMsg
        );

        [DllImport("user32.dll")]
        public static extern bool TranslateMessage(ref MSG lpMsg);

        [DllImport("user32.dll")]
        public static extern IntPtr DispatchMessageW(ref MSG lpMsg);

        [DllImport("user32.dll")]
        public static extern IntPtr DefWindowProcW(
            IntPtr hWnd,
            uint message,
            IntPtr wParam,
            IntPtr lParam
        );

        [DllImport("user32.dll")]
        public static extern IntPtr BeginPaint(IntPtr hWnd, out PAINTSTRUCT lpPaint);

        [DllImport("user32.dll")]
        public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT lpPaint);

        [DllImport("user32.dll")]
        public static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern void PostQuitMessage(int nExitCode);

        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursorW(IntPtr hInstance, IntPtr lpCursorName);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern ushort RegisterClassExW(ref WNDCLASSEX lpwcx);

        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern bool UpdateWindow(IntPtr hWnd);

        // =========================
        // Paint struct
        // =========================
        [StructLayout(LayoutKind.Sequential)]
        public struct PAINTSTRUCT
        {
            public IntPtr hdc;
            public bool fErase;
            public RECT rcPaint;
            public bool fRestore;
            public bool fIncUpdate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] rgbReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
    }
}
