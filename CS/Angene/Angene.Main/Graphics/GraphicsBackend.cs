using Angene.Main;
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
    
#if WINDOWS
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
#else
    // Linux X11 implementation using raw pixel buffer
    public class X11GraphicsContext : IGraphicsContext
    {
        private IntPtr display;
        private IntPtr window;
        private IntPtr gc;
        private int width;
        private int height;
        private byte[] pixelBuffer;
        private IntPtr pixelBufferPtr;
        
        public IntPtr Handle => gc;
        
        public X11GraphicsContext(IntPtr disp, IntPtr win, int w, int h)
        {
            display = disp;
            window = win;
            width = w;
            height = h;
            
            gc = Angene.Platform.Linux.X11.XCreateGC(display, window, 0, IntPtr.Zero);
            
            // Allocate pixel buffer (BGRA format, 4 bytes per pixel)
            pixelBuffer = new byte[width * height * 4];
            pixelBufferPtr = Marshal.AllocHGlobal(pixelBuffer.Length);
        }
        
        public void Clear(uint color)
        {
            // Convert COLORREF (0x00BBGGRR) to BGRA
            byte b = (byte)((color >> 16) & 0xFF);
            byte g = (byte)((color >> 8) & 0xFF);
            byte r = (byte)(color & 0xFF);
            byte a = 0xFF;
            
            for (int i = 0; i < pixelBuffer.Length; i += 4)
            {
                pixelBuffer[i] = b;
                pixelBuffer[i + 1] = g;
                pixelBuffer[i + 2] = r;
                pixelBuffer[i + 3] = a;
            }
        }
        
        public void DrawRectangle(int x, int y, int w, int h, uint color)
        {
            byte b = (byte)((color >> 16) & 0xFF);
            byte g = (byte)((color >> 8) & 0xFF);
            byte r = (byte)(color & 0xFF);
            byte a = 0xFF;
            
            for (int py = y; py < y + h && py < height; py++)
            {
                for (int px = x; px < x + w && px < width; px++)
                {
                    int idx = (py * width + px) * 4;
                    if (idx >= 0 && idx < pixelBuffer.Length - 3)
                    {
                        pixelBuffer[idx] = b;
                        pixelBuffer[idx + 1] = g;
                        pixelBuffer[idx + 2] = r;
                        pixelBuffer[idx + 3] = a;
                    }
                }
            }
        }
        
        public void DrawText(string text, int x, int y, uint color)
        {
            // For basic text, we'd need to load fonts - skip for now
            // or use X11's XDrawString (limited, but works)
            ulong xcolor = ((ulong)(color & 0xFF) << 16) | 
                          ((ulong)((color >> 8) & 0xFF) << 8) | 
                          ((ulong)((color >> 16) & 0xFF));
            
            Angene.Platform.Linux.X11.XSetForeground(display, gc, xcolor);
            Angene.Platform.Linux.X11.XDrawString(display, window, gc, x, y + 12, text, text.Length);
        }
        
        public void Present(IntPtr win)
        {
            // Copy pixel buffer to unmanaged memory
            Marshal.Copy(pixelBuffer, 0, pixelBufferPtr, pixelBuffer.Length);
            
            // Create XImage from pixel buffer
            IntPtr image = Angene.Platform.Linux.X11.XCreateImage(
                display,
                IntPtr.Zero, // default visual
                24, // depth
                Angene.Platform.Linux.X11.ZPixmap,
                0, // offset
                pixelBufferPtr,
                (uint)width,
                (uint)height,
                32, // bitmap_pad
                0); // bytes_per_line (auto-calculate)
            
            if (image != IntPtr.Zero)
            {
                Angene.Platform.Linux.X11.XPutImage(display, window, gc, image, 
                    0, 0, 0, 0, (uint)width, (uint)height);
                
                // Don't destroy image as it references our buffer
                // Angene.Platform.Linux.X11.XDestroyImage(image);
            }
            
            Angene.Platform.Linux.X11.XFlush(display);
        }
        
        public void Cleanup()
        {
            if (pixelBufferPtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(pixelBufferPtr);
                pixelBufferPtr = IntPtr.Zero;
            }
            
            if (gc != IntPtr.Zero)
            {
                Angene.Platform.Linux.X11.XFreeGC(display, gc);
                gc = IntPtr.Zero;
            }
        }
    }
#endif

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
            memDc = Angene.Main.Gdi32.CreateCompatibleDC(hdc);

            // Create a bitmap in RAM that matches the screen's color depth
            bitmap = Angene.Main.Gdi32.CreateCompatibleBitmap(hdc, w, h);

            // Select the bitmap into our DC so GDI functions draw onto the bitmap
            oldBitmap = Angene.Main.Gdi32.SelectObject(memDc, bitmap);

            // We're done with the screen DC reference
            Angene.Main.Win32.ReleaseDC(IntPtr.Zero, hdc);
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

        public void Cleanup()
        {
            if (oldBitmap != IntPtr.Zero)
                Angene.Main.Gdi32.SelectObject(memDc, oldBitmap);
            if (bitmap != IntPtr.Zero)
                Angene.Main.Gdi32.DeleteObject(bitmap);
            if (memDc != IntPtr.Zero)
                Angene.Main.Gdi32.DeleteDC(memDc);
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
#if WINDOWS
            return new GdiGraphicsContext(windowHandle, width, height);
#else
            // For X11, we need display and window separately
            // This will be passed from the Window class
            throw new NotImplementedException("Use CreateX11 for Linux");
#endif
        }
        
#if !WINDOWS
        public static IGraphicsContext CreateX11(IntPtr display, IntPtr window, int width, int height)
        {
            return new X11GraphicsContext(display, window, width, height);
        }
#endif
        public static IGraphicsContext CreateWS(string windowHandle, int width, int height)
        {
#if WINDOWS
            return new WSGraphicsContext(windowHandle, width, height);
#endif
        }
    }
}