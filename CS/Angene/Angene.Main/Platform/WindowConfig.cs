using System;
using Angene.Main;

namespace Angene.Platform
{
    /// <summary>
    /// Configuration options for window creation
    /// </summary>
    public class WindowConfig
    {
        /// <summary>Window title</summary>
        public string Title { get; set; } = "Angene Window";

        /// <summary>Window width in pixels</summary>
        public int Width { get; set; } = 800;

        /// <summary>Window height in pixels</summary>
        public int Height { get; set; } = 600;

        /// <summary>X position (CW_USEDEFAULT for system default)</summary>
        public int X { get; set; } = Win32.CW_USEDEFAULT;

        /// <summary>Y position (CW_USEDEFAULT for system default)</summary>
        public int Y { get; set; } = Win32.CW_USEDEFAULT;

        public bool cTI { internal get; set; } = false;

        public string cTS { internal get; set; } = "";

        public string cTT { internal get; set; } = "";

        /// <summary>Window style flags</summary>
        public Win32.WindowStyle Style { get; set; } = Win32.WindowStyle.OverlappedWindow;

        /// <summary>Extended window style flags</summary>
        public Win32.WindowStyleEx StyleEx { get; set; } = Win32.WindowStyleEx.None;

        /// <summary>Transparency settings</summary>
        public Win32.WindowTransparency Transparency { get; set; } = Win32.WindowTransparency.None;

        /// <summary>Whether to use 3D rendering (OpenGL)</summary>
        public bool Use3D { get; set; } = false;

        /// <summary>Whether window should be shown immediately</summary>
        public bool ShowOnCreate { get; set; } = true;

        /// <summary>Whether window should be topmost</summary>
        public bool AlwaysOnTop
        {
            get => StyleEx.HasFlag(Win32.WindowStyleEx.Topmost);
            set
            {
                if (value)
                    StyleEx |= Win32.WindowStyleEx.Topmost;
                else
                    StyleEx &= ~Win32.WindowStyleEx.Topmost;
            }
        }

        /// <summary>
        /// Creates a standard desktop window configuration
        /// </summary>
        public static WindowConfig Standard(string title, int width, int height)
        {
            return new WindowConfig
            {
                Title = title,
                Width = width,
                Height = height,
                Style = Win32.WindowStyle.OverlappedWindow,
                StyleEx = Win32.WindowStyleEx.None,
                Transparency = Win32.WindowTransparency.None,
                Use3D = false
            };
        }

        /// <summary>
        /// Creates a transparent overlay window configuration (for Discord overlay, etc.)
        /// </summary>
        public static WindowConfig TransparentOverlay(string title, int width, int height, bool clickThrough = true)
        {
            return new WindowConfig
            {
                Title = title,
                Width = width,
                Height = height,
                X = 0,
                Y = 0,
                Style = Win32.WindowStyle.Popup,
                StyleEx = Win32.WindowStyleEx.Layered | Win32.WindowStyleEx.Topmost |
                         (clickThrough ? Win32.WindowStyleEx.Transparent : Win32.WindowStyleEx.None),
                Transparency = new Win32.WindowTransparency
                {
                    Enabled = true,
                    Alpha = 255,  // Window alpha (we use OpenGL alpha for per-pixel)
                    ClickThrough = clickThrough
                },
                Use3D = false
            };
        }

        /// <summary>
        /// Creates a borderless window configuration
        /// </summary>
        public static WindowConfig Borderless(string title, int width, int height)
        {
            return new WindowConfig
            {
                Title = title,
                Width = width,
                Height = height,
                Style = Win32.WindowStyle.Popup,
                StyleEx = Win32.WindowStyleEx.None,
                Transparency = Win32.WindowTransparency.None,
                Use3D = false
            };
        }

        /// <summary>
        /// Creates a 3D rendering window configuration
        /// </summary>
        public static WindowConfig Rendering3D(string title, int width, int height)
        {
            return new WindowConfig
            {
                Title = title,
                Width = width,
                Height = height,
                Style = Win32.WindowStyle.OverlappedWindow,
                StyleEx = Win32.WindowStyleEx.None,
                Transparency = Win32.WindowTransparency.None,
                Use3D = true
            };
        }
    }
}