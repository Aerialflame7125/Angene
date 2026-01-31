using Angene.Globals;
using System;
using System.Collections.Generic;
using static Angene.Main.Win32;
using static Angene.Main.Gdi32;

namespace Angene.Graphics
{
    public sealed class GdiRenderer : IRenderer, IDisposable
    {
        private readonly IntPtr _hdc;

        private static readonly Dictionary<uint, IntPtr> BrushCache = new();
        private static IntPtr _nullPen;

        // Backbuffer state
        private IntPtr _memDc = IntPtr.Zero;
        private IntPtr _backBufferBitmap = IntPtr.Zero;
        private IntPtr _oldBitmap = IntPtr.Zero;
        private bool _frameBegun;

        private const int TRANSPARENT = 1;
        private const int NULL_PEN = 8;
        private const uint SRCCOPY = 0x00CC0020;

        public GdiRenderer(IntPtr hdc)
        {
            _hdc = hdc;

            if (_nullPen == IntPtr.Zero)
                _nullPen = GetStockObject(NULL_PEN);
        }

        // Create a memory DC/backbuffer and set it as the target for all draw calls.
        public void BeginFrame(int width, int height)
        {
            if (_frameBegun)
                return;

            // Create compatible DC and bitmap for double buffering
            _memDc = CreateCompatibleDC(_hdc);
            if (_memDc == IntPtr.Zero)
            {
                // fallback: use actual hdc if we can't create memDC
                _memDc = IntPtr.Zero;
                _frameBegun = true;
                return;
            }

            _backBufferBitmap = CreateCompatibleBitmap(_hdc, Math.Max(1, width), Math.Max(1, height));
            if (_backBufferBitmap == IntPtr.Zero)
            {
                DeleteDC(_memDc);
                _memDc = IntPtr.Zero;
                _frameBegun = true;
                return;
            }

            _oldBitmap = SelectObject(_memDc, _backBufferBitmap);
            _frameBegun = true;
        }

        // Clear/draw methods use the active target DC (backbuffer if available)
        public void Clear(float r, float g, float b, float a)
        {
            var target = GetTargetDc();
            if (target == IntPtr.Zero)
                return;

            uint color = RGB(
                (byte)(r * 255),
                (byte)(g * 255),
                (byte)(b * 255)
            );

            var brush = GetBrush(color);
            var oldPen = SelectObject(target, _nullPen);
            var oldBrush = SelectObject(target, brush);

            Rectangle(target, -1, -1, 10000, 10000);

            Restore(target, oldPen, oldBrush);
        }

        public void DrawRect(float x, float y, float w, float h, uint color)
        {
            var target = GetTargetDc();
            if (target == IntPtr.Zero)
                return;

            var brush = GetBrush(color);

            var oldPen = SelectObject(target, _nullPen);
            var oldBrush = SelectObject(target, brush);

            Rectangle(
                target,
                (int)x,
                (int)y,
                (int)(x + w),
                (int)(y + h)
            );

            Restore(target, oldPen, oldBrush);
        }

        public void DrawText(float x, float y, string text, uint color)
        {
            var target = GetTargetDc();
            if (target == IntPtr.Zero)
                return;

            SetBkMode(target, TRANSPARENT);
            SetTextColor(target, color);

            if (text.Length > 256)
                text = text.Substring(0, 256);

            TextOutW(
                target,
                (int)x,
                (int)y,
                text,
                text.Length
            );
        }

        // Present the backbuffer (if any) to the window DC and clean up backbuffer objects.
        public void EndFrame()
        {
            if (!_frameBegun)
                return;

            try
            {
                if (_memDc != IntPtr.Zero && _backBufferBitmap != IntPtr.Zero)
                {
                    // BitBlt from memory DC to window DC
                    // Use the full area of the bitmap: use GetObject fallback if needed, but simple SRCCOPY is used here.
                    BitBlt(_hdc, 0, 0, 32767, 32767, _memDc, 0, 0, SRCCOPY);
                }
            }
            finally
            {
                // restore and free the backbuffer resources
                if (_memDc != IntPtr.Zero)
                {
                    if (_oldBitmap != IntPtr.Zero)
                    {
                        SelectObject(_memDc, _oldBitmap);
                        _oldBitmap = IntPtr.Zero;
                    }

                    if (_backBufferBitmap != IntPtr.Zero)
                    {
                        DeleteObject(_backBufferBitmap);
                        _backBufferBitmap = IntPtr.Zero;
                    }

                    DeleteDC(_memDc);
                    _memDc = IntPtr.Zero;
                }

                _frameBegun = false;
            }
        }

        public void Dispose()
        {
            // free per-instance backbuffer if still present
            EndFrame();

            foreach (var brush in BrushCache.Values)
                DeleteObject(brush);

            BrushCache.Clear();
        }

        // helpers

        private IntPtr GetTargetDc() => _memDc != IntPtr.Zero ? _memDc : _hdc;

        private static IntPtr GetBrush(uint color)
        {
            if (!BrushCache.TryGetValue(color, out var brush))
            {
                brush = CreateSolidBrush(color);
                BrushCache[color] = brush;
            }

            return brush;
        }

        // Restore the provided DC's selected pen/brush
        private static void Restore(IntPtr hdc, IntPtr oldPen, IntPtr oldBrush)
        {
            if (oldBrush != IntPtr.Zero)
                SelectObject(hdc, oldBrush);

            if (oldPen != IntPtr.Zero)
                SelectObject(hdc, oldPen);
        }

        private static uint RGB(byte r, byte g, byte b)
        {
            return (uint)(r | (g << 8) | (b << 16));
        }
    }
}