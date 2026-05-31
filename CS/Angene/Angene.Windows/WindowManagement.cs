using System;
using System.Runtime.InteropServices;

namespace Angene.Windows
{
    public static class WindowManagement
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

        [StructLayout(LayoutKind.Sequential)]
        public struct TRACKMOUSEEVENT
        {
            public uint cbSize;
            public uint dwFlags;
            public IntPtr hwndTrack;
            public uint dwHoverTime;
        }

        // structs
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WNDCLASSEX
        {
            public uint cbSize;
            public uint style;
            public User32.WndProcDelegate lpfnWndProc;
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
