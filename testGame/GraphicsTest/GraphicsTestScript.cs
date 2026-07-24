using Angene.Common;
using Angene.Essentials;
using Angene.Graphics.Angraphics;
using Angene.Math.GraphicsMath;
using Angene.Windows;
using System;

namespace Game
{
    /// <summary>
    /// Graphics rendering test using Bresenham line algorithm.
    /// 
    /// Demonstrates:
    ///   - Line drawing via GetPointsOnLine (Bresenham algorithm)
    ///   - Pixel-by-pixel rendering to framebuffer
    ///   - Window integration with AnGraphicsContext
    ///   - Color manipulation and drawing primitives
    /// 
    /// Visual Output:
    ///   - Grid pattern (axis lines)
    ///   - Diagonal lines in different colors
    ///   - Animated rotating line
    /// </summary>
    internal class GraphicsTestScript : IScreenPlay
    {
        private Window? _window;
        private AnGraphicsContext? _gfx;
        private double _elapsed = 0;
        private const int WIDTH = 800;
        private const int HEIGHT = 600;

        public void Start()
        {
            Logger.LogInfo("GraphicsTestScript: Initializing graphics test.", LoggingTarget.MainGame);
            
            // Create window
            _window = new Window("Angraphics Line Test", WIDTH, HEIGHT);
            if (_window == null)
                throw new AngeneException("Failed to create window.");

            // Create graphics context
            _gfx = new AnGraphicsContext(_window.Handle, WIDTH, HEIGHT);
            if (_gfx == null)
                throw new AngeneException("Failed to create graphics context.");

            Logger.LogInfo("GraphicsTestScript: Graphics context created successfully.", LoggingTarget.MainGame);
            Logger.LogInfo("GraphicsTestScript: Drawing grid, diagonals, and animated line. ESC to close.", LoggingTarget.MainGame);
        }

        public void Update(double dt)
        {
            _elapsed += dt;

            // Clear screen with dark blue
            uint bgColor = 0xFF1A1A2E;
            _gfx!.Clear(bgColor);

            // Draw center crosshair (white grid lines)
            DrawCrosshair(WIDTH / 2, HEIGHT / 2, 100, 0xFFFFFFFF);

            // Draw diagonal lines (red)
            DrawLine(50, 50, WIDTH - 50, HEIGHT - 50, 0xFF0000FF);
            DrawLine(WIDTH - 50, 50, 50, HEIGHT - 50, 0xFF0000FF);

            // Draw quadrant dividers (gray)
            DrawLine(0, HEIGHT / 2, WIDTH, HEIGHT / 2, 0xFF808080);
            DrawLine(WIDTH / 2, 0, WIDTH / 2, HEIGHT, 0xFF808080);

            // Draw animated rotating line (green)
            double angle = _elapsed * 2.0; // radians per second
            int centerX = WIDTH / 2;
            int centerY = HEIGHT / 2;
            int radius = 150;
            int endX = centerX + (int)(radius * Math.Cos(angle));
            int endY = centerY + (int)(radius * Math.Sin(angle));
            DrawLine(centerX, centerY, endX, endY, 0xFF00FF00);

            // Draw sine wave (cyan)
            DrawSineWave(0xFF00FFFF);

            // Draw circle outline using lines (yellow)
            DrawCircleOutline(WIDTH - 100, 100, 50, 0xFFFFFF00);

            // Present to screen
            _gfx!.Present(_window!.Handle);
        }

        /// <summary>Draw a line from (x0, y0) to (x1, y1) using Bresenham algorithm.</summary>
        private void DrawLine(int x0, int y0, int x1, int y1, uint color)
        {
            foreach (var point in GraphicsMath.GetPointsOnLine(x0, y0, x1, y1))
            {
                if (point.X >= 0 && point.X < WIDTH && point.Y >= 0 && point.Y < HEIGHT)
                {
                    DrawPixel(point.X, point.Y, color);
                }
            }
        }

        /// <summary>Draw a crosshair centered at (cx, cy) with given size.</summary>
        private void DrawCrosshair(int cx, int cy, int size, uint color)
        {
            DrawLine(cx - size, cy, cx + size, cy, color);
            DrawLine(cx, cy - size, cx, cy + size, color);
        }

        /// <summary>Draw a circle outline using Bresenham circles (approximated via lines).</summary>
        private void DrawCircleOutline(int cx, int cy, int radius, uint color)
        {
            int segments = 32;
            for (int i = 0; i < segments; i++)
            {
                double angle1 = (2.0 * Math.PI * i) / segments;
                double angle2 = (2.0 * Math.PI * (i + 1)) / segments;

                int x1 = cx + (int)(radius * Math.Cos(angle1));
                int y1 = cy + (int)(radius * Math.Sin(angle1));
                int x2 = cx + (int)(radius * Math.Cos(angle2));
                int y2 = cy + (int)(radius * Math.Sin(angle2));

                DrawLine(x1, y1, x2, y2, color);
            }
        }

        /// <summary>Draw a sine wave across the screen (blue).</summary>
        private void DrawSineWave(uint color)
        {
            int waveAmplitude = 50;
            int waveFrequency = 2;
            int centerY = HEIGHT / 2;

            for (int x = 0; x < WIDTH - 1; x++)
            {
                int y1 = centerY + (int)(waveAmplitude * Math.Sin((x * waveFrequency) * Math.PI / WIDTH));
                int y2 = centerY + (int)(waveAmplitude * Math.Sin(((x + 1) * waveFrequency) * Math.PI / WIDTH));

                DrawLine(x, y1, x + 1, y2, color);
            }
        }

        /// <summary>Set a single pixel directly to the framebuffer.</summary>
        private void DrawPixel(int x, int y, uint color)
        {
            // Direct framebuffer access via the graphics context
            byte[] pixels = _gfx!.GetRawPixels();
            int stride = WIDTH * 4; // BGRA32
            int idx = y * stride + x * 4;

            if (idx >= 0 && idx + 3 < pixels.Length)
            {
                pixels[idx]     = (byte)(color & 0xFF);         // B
                pixels[idx + 1] = (byte)((color >> 8) & 0xFF);  // G
                pixels[idx + 2] = (byte)((color >> 16) & 0xFF); // R
                pixels[idx + 3] = (byte)((color >> 24) & 0xFF); // A
            }
        }

        public void OnDestroy()
        {
            Logger.LogInfo("GraphicsTestScript: Cleaning up graphics resources.", LoggingTarget.MainGame);
            _gfx?.Cleanup();
            _window?.Dispose();
        }
    }
}
