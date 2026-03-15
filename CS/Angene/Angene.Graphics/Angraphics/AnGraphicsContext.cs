using Angene.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Angene.Graphics.Angraphics
{
    public class AnGraphicsContext : IGraphicsContext
    {
        private readonly IntPtr _windowHandle;
        private readonly IntPtr _memDc;
        private readonly IntPtr _bitmap;
        private readonly IntPtr _oldBitmap;
        private readonly Dc _dc;
        private readonly int _width;
        private readonly int _height;

        public IntPtr Handle => _memDc;

        public AnGraphicsContext(IntPtr hwnd, int w, int h)
        {
            _windowHandle = hwnd;
            _width = w;
            _height = h;

            // GDI objects are only used for the final upload (SetDIBits + BitBlt)
            IntPtr hdc = Win32.GetDC(hwnd);
            _memDc = Gdi32.CreateCompatibleDC(hdc);
            _bitmap = Gdi32.CreateCompatibleBitmap(hdc, w, h);
            _oldBitmap = Gdi32.SelectObject(_memDc, _bitmap);
            Win32.ReleaseDC(hwnd, hdc);

            // Our software device context with a double-buffered swapchain
            _dc = new Dc(w, h, useGpu: false, bufferCount: 2);
        }

        public void Clear(uint color)
            => _dc.GetBackBuffer().Clear(color);

        public void DrawRectangle(int x, int y, int width, int height, uint color)
            => _dc.GetBackBuffer().FillRect(x, y, width, height, color);

        public void DrawText(string text, int x, int y, uint color)
        {
            // Software text is hard — delegate to GDI on the memDc for now,
            // or integrate a bitmap font later.
            Gdi32.SetBkMode(_memDc, 1);
            Gdi32.SetTextColor(_memDc, color);
            Gdi32.TextOutW(_memDc, x, y, text, text.Length);
        }

        public void Present(IntPtr hwnd)
        {
            FrameBuffer front = _dc.Swapchain.FrontBuffer; // already-drawn buffer

            // Upload our software pixel array into the GDI bitmap
            var bmi = new Gdi32.BITMAPINFO();
            bmi.bmiHeader.biSize = (uint)Marshal.SizeOf<Gdi32.BITMAPINFOHEADER>();
            bmi.bmiHeader.biWidth = _width;
            bmi.bmiHeader.biHeight = -_height; // top-down
            bmi.bmiHeader.biPlanes = 1;
            bmi.bmiHeader.biBitCount = 32;
            bmi.bmiHeader.biCompression = 0; // BI_RGB

            Gdi32.SetDIBits(_memDc, _bitmap, 0, (uint)_height,
                            front.Pixels, ref bmi, 0);

            // BitBlt the memDc to the real window DC
            IntPtr hdc = Win32.GetDC(hwnd);
            Gdi32.BitBlt(hdc, 0, 0, _width, _height, _memDc, 0, 0, Gdi32.SRCCOPY);
            Win32.ReleaseDC(hwnd, hdc);

            // Advance the swapchain — back becomes front for next Present()
            _dc.SwapBuffers();
        }

        public byte[] GetRawPixels()
            => _dc.Swapchain.FrontBuffer.Pixels;

        public void Cleanup()
        {
            _dc.Dispose();
            if (_oldBitmap != IntPtr.Zero) Gdi32.SelectObject(_memDc, _oldBitmap);
            if (_bitmap != IntPtr.Zero) Gdi32.DeleteObject(_bitmap);
            if (_memDc != IntPtr.Zero) Gdi32.DeleteDC(_memDc);
        }
    }
}
