using Angene.Common;
using Angene.Essentials;
using Angene.External;
using Angene.Graphics;
using Angene.Main;
using Angene.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Game
{
    internal class TextHandler : IScreenPlay
    {
        private Angene.Main.Package? _package;
        private string _packagePath = Path.Combine(AppContext.BaseDirectory, "game.angpkg");
        internal string? _loadedText;
        private List<string> _entryNames = new();
        private Window _window;
        private List<Entity> _entities;
        private PackageTest _scene;

        public void Initialize(List<Entity> entities, Window window, PackageTest scene)
        {
            _entities = entities;
            _window = window;
            _scene = scene;
        }

        public void Start()
        {
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

                    if (target != null)
                    {
                        var entry = _package.Entries.FirstOrDefault(x => string.Equals(x.Path, target, StringComparison.OrdinalIgnoreCase));
                        if (entry != null)
                        {
                            using var s = _package.OpenStream(entry);
                            using var sr = new StreamReader(s, Encoding.UTF8);
                            _loadedText = sr.ReadToEnd();
                            var rpcEntity = _entities.FirstOrDefault(e => e.name == "RPC");
                            if (rpcEntity != null)
                            {
                                RPCScript scr = rpcEntity.GetScriptByType<RPCScript>();
                                if (scr != null)
                                {
                                    scr.SetText(_loadedText);
                                }
                            }
                        }
                        ;
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

#if WINDOWS
        public void DrawWindows()
        {
            // Windows GDI rendering
            IntPtr hdc = Win32.GetDC((IntPtr)_window.Hwnd);
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
                Win32.ReleaseDC((IntPtr)_window.Hwnd, hdc);
            }
        }
#else
        public void DrawLinux()
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

        public void Cleanup()
        {
            // Dispose package when scene is destroyed
            _package?.Dispose();
            _package = null;
        }

#if WINDOWS
        public void DrawWS()
        {
            var graphics = _window.Graphics;
            if (graphics == null) return;

            // ── Background ───────────────────────────────────────────────
            graphics.Clear(0x001F1A13);

            // ── Static UI ────────────────────────────────────────────────
            graphics.DrawText("Angene Input Demo", 12, 8, 0x00FFFF00);
            graphics.DrawText($"Package : {_packagePath}", 12, 32, 0x00AAAAAA);
            graphics.DrawText($"Entries : {_entryNames.Count}", 12, 48, 0x00AAAAAA);
            graphics.DrawText($"Platform: {PlatformDetection.CurrentPlatform}", 12, 64, 0x00AAAAAA);

            // ── Input state display ──────────────────────────────────────
            int mx = _scene.MouseX;
            int my = _scene.MouseY;

            // Choose cursor colour based on which button is held
            uint cursorColor = (_scene.LeftMouseDown, _scene.RightMouseDown) switch
            {
                (true, false) => 0x0000FF00,   // green  — left held
                (false, true) => 0x000000FF,   // red    — right held
                (true, true) => 0x00FFFF00,   // yellow — both held
                _ => 0x00FFFFFF    // white  — nothing held
            };

            // Draw a small crosshair at the current mouse position
            int cs = 10; // crosshair arm length
            graphics.DrawRectangle(mx - cs, my - 1, cs * 2, 3, cursorColor); // horizontal bar
            graphics.DrawRectangle(mx - 1, my - cs, 3, cs * 2, cursorColor); // vertical bar

            // Draw a label next to the cursor showing coordinates
            graphics.DrawText($"({mx},{my})", mx + cs + 4, my - 6, cursorColor);

            // Draw key display in the bottom-left corner
            uint keyColor = _scene.LastKey == "None" ? 0x00555555U : 0x0000FFFFU;
            graphics.DrawText("Last key:", 12, _window.Height - 52, 0x00AAAAAA);
            graphics.DrawText(_scene.LastKey, 12, _window.Height - 34, keyColor);

            // Draw mouse button indicators
            uint lColor = _scene.LeftMouseDown ? 0x0000FF00U : 0x00333333U;
            uint rColor = _scene.RightMouseDown ? 0x000000FFU : 0x00333333U;
            graphics.DrawRectangle(12, _window.Height - 18, 30, 12, lColor);
            graphics.DrawRectangle(48, _window.Height - 18, 30, 12, rColor);
            graphics.DrawText("LMB", 14, _window.Height - 16, 0x00FFFFFF);
            graphics.DrawText("RMB", 50, _window.Height - 16, 0x00FFFFFF);
        }
#endif

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
