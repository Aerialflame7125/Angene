using System;
using Angene.Graphics;
using Angene.Main;
using Angene.Windows;

namespace Angene.Platform
{
    public enum OSType { Microsoft, Linux, Unknown }
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
        public int X { get; set; } = Consts.CW_USEDEFAULT;

        /// <summary>Y position (CW_USEDEFAULT for system default)</summary>
        public int Y { get; set; } = Consts.CW_USEDEFAULT;

        /// <summary>
        /// convertToInterface bool
        /// </summary>
        public bool cTI { internal get; set; } = false;

        /// <summary>
        /// connectToSocket string
        /// Contains socket type as string
        /// </summary>
        public string cTS { internal get; set; } = "";
        /// <summary>
        /// convertToType string
        /// Can be [ "Websocket" ]
        /// </summary>
        public string cTT { internal get; set; } = "";

        /// <summary>
        /// Changes the render mode for the window, defaults to GDI unless changed. Chooses between GDI, OpenGL, and DX11
        /// </summary>
        public RenderType renderMode;
        public static OSType OS = OSType.Unknown;

        /// <summary>Window style flags</summary>
        public WindowManagement.WindowStyle Style { get; set; } = WindowManagement.WindowStyle.OverlappedWindow;

        /// <summary>Extended window style flags</summary>
        public WindowManagement.WindowStyleEx StyleEx { get; set; } = WindowManagement.WindowStyleEx.None;

        /// <summary>Transparency settings</summary>
        public WindowManagement.WindowTransparency Transparency { get; set; } = WindowManagement.WindowTransparency.None;

        /// <summary>Whether window should be shown immediately</summary>
        public bool ShowOnCreate { get; set; } = true;

        /// <summary>Whether window should be topmost</summary>
        public bool AlwaysOnTop
        {
            get => StyleEx.HasFlag(WindowManagement.WindowStyleEx.Topmost);
            set
            {
                if (value)
                    StyleEx |= WindowManagement.WindowStyleEx.Topmost;
                else
                    StyleEx &= ~WindowManagement.WindowStyleEx.Topmost;
            }
        }

        public WindowConfig()
        {
            switch (Environment.OSVersion.Platform)
            {
                case (PlatformID.Win32NT):
                    OS = OSType.Microsoft;
                    break;
                case (PlatformID.Unix):
                    OS = OSType.Linux;
                    break;
                default:
                    OS = OSType.Unknown;
                    break;
            }
        }

        /// <summary>
        /// Creates a standard desktop window configuration
        /// </summary>
        public static WindowConfig Standard(string title, int width, int height)
        {
            RenderType b = RenderType.GDI;
            switch (Environment.OSVersion.Platform)
            {
                case (PlatformID.Win32NT):
                    b = RenderType.GDI;
                    break;
                case (PlatformID.Unix):
                    b = RenderType.Vulkan;
                    break;
                default:
                    throw new Exception("PlatformID cannot be found. WindowConfig creation is not possible.");
            }
            if (b == RenderType.GDI)
                return new WindowConfig
                {
                    Title = title,
                    Width = width,
                    Height = height,
                    Style = WindowManagement.WindowStyle.OverlappedWindow,
                    StyleEx = WindowManagement.WindowStyleEx.None,
                    Transparency = WindowManagement.WindowTransparency.None,
                    renderMode = b
                };
            else
                return new WindowConfig
                {
                    Title = title,
                    Width = width,
                    Height = height,
                    Transparency = WindowManagement.WindowTransparency.None,
                    renderMode = b
                };
        }

        /// <summary>
        /// Creates a transparent overlay window configuration (for Discord overlay, etc.)
        /// </summary>
        public static WindowConfig TransparentOverlay(string title, int width, int height, bool clickThrough = true)
        {
            RenderType b = RenderType.GDI;
            switch (Environment.OSVersion.Platform)
            {
                case (PlatformID.Win32NT):
                    b = RenderType.GDI;
                    break;
                case (PlatformID.Unix):
                    b = RenderType.Vulkan;
                    break;
                default:
                    throw new Exception("PlatformID cannot be found. WindowConfig creation is not possible.");
            }
            if (b == RenderType.GDI)
                return new WindowConfig
            {
                Title = title,
                Width = width,
                Height = height,
                X = 0,
                Y = 0,
                Style = WindowManagement.WindowStyle.Popup,
                StyleEx = WindowManagement.WindowStyleEx.Layered | WindowManagement.WindowStyleEx.Topmost |
                         (clickThrough ? WindowManagement.WindowStyleEx.Transparent : WindowManagement.WindowStyleEx.None),
                Transparency = new WindowManagement.WindowTransparency
                {
                    Enabled = true,
                    Alpha = 255,  // Window alpha (we use OpenGL alpha for per-pixel)
                    ClickThrough = clickThrough
                },
                renderMode = b
            };
            else
                return new WindowConfig
                {
                    Title = title,
                    Width = width,
                    Height = height,
                    Transparency = new WindowManagement.WindowTransparency
                    {
                        Enabled = true,
                        Alpha = 255, // no idea if vulkan even supports this
                        ClickThrough = clickThrough
                    },
                    renderMode = b
                };
        }

        /// <summary>
        /// Creates a borderless window configuration
        /// </summary>
        public static WindowConfig Borderless(string title, int width, int height)
        {
            RenderType b = RenderType.GDI;
            switch (Environment.OSVersion.Platform)
            {
                case (PlatformID.Win32NT):
                    b = RenderType.GDI;
                    break;
                case (PlatformID.Unix):
                    b = RenderType.Vulkan;
                    break;
                default:
                    throw new Exception("PlatformID cannot be found. WindowConfig creation is not possible.");
            }
            if (b == RenderType.GDI)
                return new WindowConfig
            {
                Title = title,
                Width = width,
                Height = height,
                Style = WindowManagement.WindowStyle.Popup,
                StyleEx = WindowManagement.WindowStyleEx.None,
                Transparency = WindowManagement.WindowTransparency.None,
                renderMode = b
            };
            else
                return new WindowConfig
                {
                    Title = title,
                    Width = width,
                    Height = height,
                    Transparency = WindowManagement.WindowTransparency.None,
                    renderMode = b
                };
        }

        /// <summary>
        /// Creates a 3D rendering window configuration
        /// </summary>
        public static WindowConfig Rendering3D(string title, int width, int height)
        {
            RenderType b = RenderType.D3D11;
            switch (Environment.OSVersion.Platform)
            {
                case (PlatformID.Win32NT):
                    b = RenderType.D3D11;
                    break;
                case (PlatformID.Unix):
                    b = RenderType.Vulkan;
                    break;
                default:
                    throw new Exception("PlatformID cannot be found. WindowConfig creation is not possible.");
            }
            if (b == RenderType.D3D11)
                return new WindowConfig
            {
                Title = title,
                Width = width,
                Height = height,
                Style = WindowManagement.WindowStyle.OverlappedWindow,
                StyleEx = WindowManagement.WindowStyleEx.None,
                Transparency = WindowManagement.WindowTransparency.None,
                renderMode = b
            };
            else
                return new WindowConfig
                {
                    Title = title,
                    Width = width,
                    Height = height,
                    Transparency = WindowManagement.WindowTransparency.None,
                    renderMode = b
                };
        }
    }
}