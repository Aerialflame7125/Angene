using System;
using System.Runtime.InteropServices;

namespace Angene.Graphics.Win
{
    public static class Gdi32
    {
        public const uint SRCCOPY = 0x00CC0020;

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern nint CreateCompatibleDC(nint hdc);

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern nint CreateCompatibleBitmap(nint hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern nint SelectObject(nint hdc, nint hObject);

        [DllImport("gdi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(nint hObject);

        [DllImport("gdi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteDC(nint hdc);

        [DllImport("gdi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BitBlt(
            nint hdcDest,
            int nXDest,
            int nYDest,
            int nWidth,
            int nHeight,
            nint hdcSrc,
            int nXSrc,
            int nYSrc,
            uint dwRop);

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern nint CreateSolidBrush(uint crColor);

        [DllImport("gdi32.dll")]
        public static extern nint GetStockObject(int fnObject);

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Rectangle(nint hdc, int left, int top, int right, int bottom);

        [DllImport("gdi32.dll")]
        public static extern int SetBkMode(nint hdc, int mode);

        [DllImport("gdi32.dll")]
        public static extern uint SetTextColor(nint hdc, uint color);

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TextOutW(nint hdc, int nXStart, int nYStart, string lpString, int cchString);

        //bitmap things
        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPINFOHEADER
        {
            public uint biSize;
            public int biWidth;
            public int biHeight;
            public ushort biPlanes;
            public ushort biBitCount;
            public uint biCompression;
            public uint biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public uint biClrUsed;
            public uint biClrImportant;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPINFO
        {
            public BITMAPINFOHEADER bmiHeader;
            public uint bmiColors; // Just enough for the header
        }

        [DllImport("gdi32.dll")]
        public static extern int GetDIBits(nint hdc, nint hbmp, uint uStartScan, uint cScanLines, [Out] byte[] lpvBits, ref BITMAPINFO lpbi, uint uUsage);
    }
}
