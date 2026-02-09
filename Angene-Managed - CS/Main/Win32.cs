using System;
using System.Runtime.InteropServices;

namespace Angene.Main
{
    public static class Win32
    {
        /// <summary>
        /// Window style flags for CreateWindowExW
        /// </summary>
        [Flags]
        public enum WindowStyle : uint
        {
            Overlapped = 0x00000000,
            Popup = 0x80000000,
            Child = 0x40000000,
            Minimize = 0x20000000,
            Visible = 0x10000000,
            Disabled = 0x08000000,
            ClipSiblings = 0x04000000,
            ClipChildren = 0x02000000,
            Maximize = 0x01000000,
            Caption = 0x00C00000,
            Border = 0x00800000,
            DialogFrame = 0x00400000,
            VScroll = 0x00200000,
            HScroll = 0x00100000,
            SysMenu = 0x00080000,
            ThickFrame = 0x00040000,
            Group = 0x00020000,
            TabStop = 0x00010000,
            MinimizeBox = 0x00020000,
            MaximizeBox = 0x00010000,

            // Common combinations
            OverlappedWindow = Overlapped | Caption | SysMenu | ThickFrame | MinimizeBox | MaximizeBox,
            PopupWindow = Popup | Border | SysMenu
        }

        /// <summary>
        /// Extended window style flags for CreateWindowExW
        /// </summary>
        [Flags]
        public enum WindowStyleEx : uint
        {
            None = 0x00000000,
            DlgModalFrame = 0x00000001,
            NoParentNotify = 0x00000004,
            Topmost = 0x00000008,
            AcceptFiles = 0x00000010,
            Transparent = 0x00000020,
            MdiChild = 0x00000040,
            ToolWindow = 0x00000080,
            WindowEdge = 0x00000100,
            ClientEdge = 0x00000200,
            ContextHelp = 0x00000400,
            Right = 0x00001000,
            Left = 0x00000000,
            RtlReading = 0x00002000,
            LtrReading = 0x00000000,
            LeftScrollBar = 0x00004000,
            RightScrollBar = 0x00000000,
            ControlParent = 0x00010000,
            StaticEdge = 0x00020000,
            AppWindow = 0x00040000,
            Layered = 0x00080000,
            NoInheritLayout = 0x00100000,
            NoRedirectionBitmap = 0x00200000,
            LayoutRtl = 0x00400000,
            Composited = 0x02000000,
            NoActivate = 0x08000000,

            // Common combinations
            OverlappedWindow = WindowEdge | ClientEdge,
            PaletteWindow = WindowEdge | ToolWindow | Topmost
        }

        /// <summary>
        /// Configuration for window transparency and overlay behavior
        /// </summary>
        public struct WindowTransparency
        {
            public bool Enabled;
            public byte Alpha;  // 0 = fully transparent, 255 = fully opaque
            public bool ClickThrough;  // WS_EX_TRANSPARENT flag

            public static WindowTransparency None => new WindowTransparency { Enabled = false, Alpha = 255, ClickThrough = false };
            public static WindowTransparency Opaque => new WindowTransparency { Enabled = true, Alpha = 255, ClickThrough = false };
            public static WindowTransparency SemiTransparent => new WindowTransparency { Enabled = true, Alpha = 128, ClickThrough = false };
            public static WindowTransparency FullyTransparent => new WindowTransparency { Enabled = true, Alpha = 0, ClickThrough = true };
        }

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

        // Add after the existing constants
        public const uint WS_POPUP = 0x80000000;
        public const uint WS_EX_LAYERED = 0x00080000;
        public const uint WS_EX_TRANSPARENT = 0x00000020;
        public const uint WS_EX_TOPMOST = 0x00000008;

        public const int LWA_COLORKEY = 0x1;
        public const int LWA_ALPHA = 0x2;

        public const int GWL_EXSTYLE = -20;

        // Add this new import
        [DllImport("user32.dll")]
        public static extern bool SetLayeredWindowAttributes(
            IntPtr hwnd,
            uint crKey,
            byte bAlpha,
            uint dwFlags
        );

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    }
}
