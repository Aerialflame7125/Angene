using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using Angene.Main;
using Angene.Globals;
using Angene.Platform;

#if WINDOWS
using Angene.Graphics;
#endif

namespace Game
{
    /// <summary>
    /// Cross-platform demo scene that shows how to use the Package loader (PkgHandler/Package).
    /// Works on both Windows and Linux (X11).
    /// </summary>
    public sealed class PackageTest : IScene
    {
        private readonly Window _window;
        public IRenderer3D? Renderer3D => null;

        private Angene.Main.Package? _package;
        private string _packagePath = "game.angpkg";
        private string? _loadedText;
        private List<string> _entryNames = new();
        private Angene.External.HandleExternal _external;

        public PackageTest(Window window)
        {
            _window = window;
            
            // Initialize Engine if not already initialized
            Engine.Initialize();
            
            // Get the external handler instance
            _external = Engine.GetInstance();
        }

        public void Start()
        {
            Console.WriteLine($"[PackageTest] Running on {PlatformDetection.CurrentPlatform}");
            
            // Try open package (no key). If your package is encrypted pass a key byte[] to Package.Open.
            try
            {
                if (File.Exists(_packagePath))
                {
                    _package = Angene.Main.Package.Open(_packagePath, key: null);
                    foreach (var e in _package.Entries)
                        _entryNames.Add(e.Path);

                    // Prefer a known path inside the package
                    var target = _entryNames.FirstOrDefault(p => p.EndsWith("text/hello.txt", StringComparison.OrdinalIgnoreCase))
                                 ?? _entryNames.FirstOrDefault();

                    _external.SetDiscordRichPresence(
                        Angene.External.DiscordGameSDK.ActivityType.Playing,
                        "Testing Angene Package",
                        $"Platform: {PlatformDetection.CurrentPlatform}",
                        0, 0,
                        "large_image", "Angene Engine", "small_image", "Package Demo",
                        "", "",
                        "", 0, 0, "", "",
                        1 | 2 | 4,
                        useDirectRPC: false, useTimestamps: false, useParty: false, useSecrets: false, usePlatforms: true,
                        verbose: true
                    );

                    if (target != null)
                    {
                        var entry = _package.Entries.FirstOrDefault(x => string.Equals(x.Path, target, StringComparison.OrdinalIgnoreCase));
                        if (entry != null)
                        {
                            using var s = _package.OpenStream(entry);
                            using var sr = new StreamReader(s, Encoding.UTF8);
                            _loadedText = sr.ReadToEnd();
                        }
                    }
                    else
                    {
                        _loadedText = "Package opened, but no entries found.";
                    }
                }
                else
                {
                    _loadedText = $"Package not found at '{_packagePath}'. Put game.angpkg next to the EXE or change the path.";
                }
            }
            catch (Exception ex)
            {
                // Keep the scene functional; show error text
                _loadedText = $"Error opening package: {ex.Message}";
            }
        }

        public void Update(double dt)
        {
            // Example: could animate UI or tick timers using dt
        }

        public void LateUpdate(double dt)
        {
            // nothing here for demo
        }

        public void OnMessage(IntPtr msgPtr)
        {
            if (msgPtr == IntPtr.Zero) return;

#if WINDOWS
            var msg = Marshal.PtrToStructure<Win32.MSG>(msgPtr);
            if (msg.message == Win32.WM_CLOSE)
            {
                Console.WriteLine("[PackageTest] Received WM_CLOSE");
            }
#else
            var msg = Marshal.PtrToStructure<Window.PlatformMessage>(msgPtr);
            if (msg.message == 33) // ClientMessage
            {
                Console.WriteLine("[PackageTest] Received close message");
            }
#endif
        }

        public void OnDraw()
        {
#if WINDOWS
            DrawWindows();
#else
            DrawLinux();
#endif
        }

#if WINDOWS
        private void DrawWindows()
        {
            // Windows GDI rendering
            IntPtr hdc = Win32.GetDC(_window.Hwnd);
            if (hdc == IntPtr.Zero) return;

            try
            {
                using var renderer = new GdiRenderer(hdc);
                renderer.BeginFrame(_window.Width, _window.Height);

                // Background
                renderer.Clear(0.08f, 0.10f, 0.12f, 1.0f);

                // Title
                renderer.DrawText(12, 8, "Angene Package Demo", 0x00FFFF00);

                // Package summary
                renderer.DrawText(12, 32, $"Package: {_packagePath}", 0x00FFFFFF);
                renderer.DrawText(12, 48, $"Entries: {_entryNames.Count}", 0x00FFFFFF);
                renderer.DrawText(12, 64, $"Platform: {PlatformDetection.CurrentPlatform}", 0x00FFFFFF);

                // Loaded text content (wrap simple)
                if (!string.IsNullOrEmpty(_loadedText))
                {
                    var y = 96;
                    var lines = WrapLines(_loadedText, 80);
                    foreach (var line in lines)
                    {
                        renderer.DrawText(12, y, line, 0x00FFFFFF);
                        y += 18;
                        if (y > _window.Height - 20) break;
                    }
                }
                else
                {
                    renderer.DrawText(12, 96, "No text loaded from package.", 0x00FF8080);
                }

                renderer.EndFrame();
            }
            finally
            {
                Win32.ReleaseDC(_window.Hwnd, hdc);
            }
        }
#else
        private void DrawLinux()
        {
            // Linux X11 rendering using the graphics context
            var graphics = _window.Graphics;
            if (graphics == null) return;

            // Background
            graphics.Clear(0x00131A1F); // Dark blue-gray (COLORREF: 0x00BBGGRR)

            // Title
            graphics.DrawText("Angene Package Demo", 12, 20, 0x00FFFF00);

            // Package summary
            graphics.DrawText($"Package: {_packagePath}", 12, 44, 0x00FFFFFF);
            graphics.DrawText($"Entries: {_entryNames.Count}", 12, 60, 0x00FFFFFF);
            graphics.DrawText($"Platform: {PlatformDetection.CurrentPlatform}", 12, 76, 0x00FFFFFF);

            // Loaded text content
            if (!string.IsNullOrEmpty(_loadedText))
            {
                var y = 108;
                var lines = WrapLines(_loadedText, 80);
                foreach (var line in lines)
                {
                    graphics.DrawText(line, 12, y, 0x00FFFFFF);
                    y += 18;
                    if (y > _window.Height - 20) break;
                }
            }
            else
            {
                graphics.DrawText("No text loaded from package.", 12, 108, 0x00FF8080);
            }

            // Present to screen
            graphics.Present(_window.Hwnd);
        }
#endif

        public void Render() { }

        public void Cleanup()
        {
            // Dispose package when scene is destroyed
            _package?.Dispose();
            _package = null;
        }

        // Very small helper to split into lines of approximate width (characters)
        private static IEnumerable<string> WrapLines(string text, int maxChars)
        {
            if (string.IsNullOrEmpty(text)) yield break;
            var words = text.Replace("\r", "").Split('\n').SelectMany(line => line.Split(' '));
            var sb = new StringBuilder();
            int len = 0;
            foreach (var w in words)
            {
                if (len + w.Length + 1 > maxChars)
                {
                    yield return sb.ToString().TrimEnd();
                    sb.Clear();
                    len = 0;
                }
                sb.Append(w);
                sb.Append(' ');
                len += w.Length + 1;
            }
            if (sb.Length > 0) yield return sb.ToString().TrimEnd();
        }
    }
}