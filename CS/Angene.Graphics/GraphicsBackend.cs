using Angene.Graphics.Win;
using System;
using System.Runtime.InteropServices;

namespace Angene.Graphics
{
    // Abstract interface for platform-specific graphics
    public interface IGraphicsContext
    {
        IntPtr Handle { get; }
        void Clear(uint color);
        void DrawRectangle(int x, int y, int width, int height, uint color);
        void DrawText(string text, int x, int y, uint color);
        void Present(IntPtr windowHandle);
        void Cleanup();
        byte[] GetRawPixels();
    }
    // Windows GDI implementation
    public class GdiGraphicsContext : IGraphicsContext
    {
        private IntPtr windowHandle;
        private IntPtr memDc;
        private IntPtr bitmap;
        private IntPtr oldBitmap;
        private int width;
        private int height;
        
        public IntPtr Handle => memDc;
        
        public GdiGraphicsContext(IntPtr hwnd, int w, int h)
        {
            windowHandle = hwnd;
            width = w;
            height = h;
            
            IntPtr hdc = Angene.Main.Win32.GetDC(hwnd);
            memDc = Angene.Main.Gdi32.CreateCompatibleDC(hdc);
            bitmap = Angene.Main.Gdi32.CreateCompatibleBitmap(hdc, w, h);
            oldBitmap = Angene.Main.Gdi32.SelectObject(memDc, bitmap);
            Angene.Main.Win32.ReleaseDC(hwnd, hdc);
        }
        
        public void Clear(uint color)
        {
            IntPtr brush = Angene.Main.Gdi32.CreateSolidBrush(color);
            IntPtr oldBrush = Angene.Main.Gdi32.SelectObject(memDc, brush);
            Angene.Main.Gdi32.Rectangle(memDc, 0, 0, width, height);
            Angene.Main.Gdi32.SelectObject(memDc, oldBrush);
            Angene.Main.Gdi32.DeleteObject(brush);
        }
        
        public void DrawRectangle(int x, int y, int w, int h, uint color)
        {
            IntPtr brush = Angene.Main.Gdi32.CreateSolidBrush(color);
            IntPtr oldBrush = Angene.Main.Gdi32.SelectObject(memDc, brush);
            Angene.Main.Gdi32.Rectangle(memDc, x, y, x + w, y + h);
            Angene.Main.Gdi32.SelectObject(memDc, oldBrush);
            Angene.Main.Gdi32.DeleteObject(brush);
        }
        
        public void DrawText(string text, int x, int y, uint color)
        {
            Angene.Main.Gdi32.SetBkMode(memDc, 1); // TRANSPARENT
            Angene.Main.Gdi32.SetTextColor(memDc, color);
            Angene.Main.Gdi32.TextOutW(memDc, x, y, text, text.Length);
        }
        
        public void Present(IntPtr hwnd)
        {
            IntPtr hdc = Angene.Main.Win32.GetDC(hwnd);
            Angene.Main.Gdi32.BitBlt(hdc, 0, 0, width, height, memDc, 0, 0, Angene.Main.Gdi32.SRCCOPY);
            Angene.Main.Win32.ReleaseDC(hwnd, hdc);
        }
        
        public void Cleanup()
        {
            if (oldBitmap != IntPtr.Zero)
                Angene.Main.Gdi32.SelectObject(memDc, oldBitmap);
            if (bitmap != IntPtr.Zero)
                Angene.Main.Gdi32.DeleteObject(bitmap);
            if (memDc != IntPtr.Zero)
                Angene.Main.Gdi32.DeleteDC(memDc);
        }
        public byte[] GetRawPixels() { return null; }
    }


    public class WSGraphicsContext : IGraphicsContext
    {
        private string windowHandle;
        private IntPtr memDc;
        private IntPtr bitmap;
        private IntPtr oldBitmap;
        private int width;
        private int height;

        public IntPtr Handle => memDc;

        public WSGraphicsContext(string hwnd, int w, int h)
        {
            windowHandle = hwnd; // This is just for your internal mapping
            width = w;
            height = h;

            // Get the Desktop DC as a reference (IntPtr.Zero is the screen)
            IntPtr hdc = Angene.Main.Win32.GetDC(IntPtr.Zero);

            // Create a Memory DC that isn't tied to any window
            memDc = Gdi32.CreateCompatibleDC(hdc);

            // Create a bitmap in RAM that matches the screen's color depth
            bitmap = Gdi32.CreateCompatibleBitmap(hdc, w, h);

            // Select the bitmap into our DC so GDI functions draw onto the bitmap
            oldBitmap = Gdi32.SelectObject(memDc, bitmap);

            // We're done with the screen DC reference
            Angene.Main.Win32.ReleaseDC(IntPtr.Zero, hdc);
        }

        public void Clear(uint color)
        {
            IntPtr brush = Gdi32.CreateSolidBrush(color);
            IntPtr oldBrush = Gdi32.SelectObject(memDc, brush);
            Gdi32.Rectangle(memDc, 0, 0, width, height);
            Gdi32.SelectObject(memDc, oldBrush);
            Gdi32.DeleteObject(brush);
        }

        public void DrawRectangle(int x, int y, int w, int h, uint color)
        {
            IntPtr brush = Gdi32.CreateSolidBrush(color);
            IntPtr oldBrush = Gdi32.SelectObject(memDc, brush);
            Gdi32.Rectangle(memDc, x, y, x + w, y + h);
            Gdi32.SelectObject(memDc, oldBrush);
            Gdi32.DeleteObject(brush);
        }

        public void DrawText(string text, int x, int y, uint color)
        {
            Gdi32.SetBkMode(memDc, 1); // TRANSPARENT
            Gdi32.SetTextColor(memDc, color);
            Gdi32.TextOutW(memDc, x, y, text, text.Length);
        }

        public void Cleanup()
        {
            if (oldBitmap != IntPtr.Zero)
                Gdi32.SelectObject(memDc, oldBitmap);
            if (bitmap != IntPtr.Zero)
                Gdi32.DeleteObject(bitmap);
            if (memDc != IntPtr.Zero)
                Gdi32.DeleteDC(memDc);
        }
        public byte[] GetRawPixels()
        {
            int size = width * height * 4;
            byte[] pixels = new byte[size];

            Gdi32.BITMAPINFO bmi = new Gdi32.BITMAPINFO();
            bmi.bmiHeader.biSize = (uint)Marshal.SizeOf(typeof(Gdi32.BITMAPINFOHEADER));
            bmi.bmiHeader.biWidth = width;
            bmi.bmiHeader.biHeight = -height; // Negative for top-down bitmap
            bmi.bmiHeader.biPlanes = 1;
            bmi.bmiHeader.biBitCount = 32;
            bmi.bmiHeader.biCompression = 0; // BI_RGB

            // Pull the bits from the bitmap into our array
            Gdi32.GetDIBits(memDc, bitmap, 0, (uint)height, pixels, ref bmi, 0);

            return pixels;
        }

        public void Present(nint windowHandle)
        {
            throw new NotImplementedException();
        }
    }

    // Factory for creating platform-specific graphics contexts
    public static class GraphicsContextFactory
    {
        public static IGraphicsContext Create(IntPtr windowHandle, int width, int height)
        {
            return new GdiGraphicsContext(windowHandle, width, height);
        }
        
        public static IGraphicsContext CreateWS(string windowHandle, int width, int height)
        {
            return new WSGraphicsContext(windowHandle, width, height);
        }
    }
}