using Angene.Common;
using Angene.Essentials;
using Angene.Graphics;
using Angene.Main;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Windows.Forms;

using AngeneWindow = Angene.Main.Window;

namespace AngeneEditor.Runtime
{
    /// <summary>
    /// Hosts a game scene in-process, rendering directly into an editor Panel.
    /// </summary>
    public sealed class EditorSceneHost : IDisposable
    {
        private AssemblyLoadContext? _loadContext;
        private IScene? _scene;
        private IGraphicsContext? _gfx;
        private Panel? _target;
        private System.Windows.Forms.Timer? _renderTimer;

        private DateTime _lastTick = DateTime.Now;
        private EngineMode _mode = EngineMode.Edit;
        private Entity? _selectedEntity;

        private const int GizmoSize = 24;

        public IScene? Scene => _scene;
        public bool IsLoaded => _scene != null;

        public event Action<string>? Log;
        public event Action? SceneUpdated;

        // ── Load ─────────────────────────────────────────────────────────────

        public void Load(string projectDir, Panel targetPanel)
        {
            Unload();

            _target = targetPanel;
            _loadContext = new AssemblyLoadContext("GameScene", isCollectible: true);

            string? dllPath = FindGameDll(projectDir);
            if (dllPath == null)
            {
                Log?.Invoke("[EditorHost] Game DLL not found — build the project first.");
                return;
            }

            try
            {
                // Load all dependency DLLs from the same output folder first
                string dllDir = Path.GetDirectoryName(dllPath)!;
                foreach (var dep in Directory.GetFiles(dllDir, "Angene*.dll"))
                {
                    try { _loadContext.LoadFromAssemblyPath(dep); }
                    catch { /* ignore — may already be loaded */ }
                }

                var asm = _loadContext.LoadFromAssemblyPath(dllPath);
                _scene = CreateScene(asm, targetPanel);

                if (_scene == null)
                {
                    Log?.Invoke("[EditorHost] No IScene implementation found in game DLL.");
                    Log?.Invoke("[EditorHost] Make sure your scene class is public and implements IScene.");
                    return;
                }

                _gfx = new GdiGraphicsContext(
                    targetPanel.Handle,
                    targetPanel.Width,
                    targetPanel.Height);

                _scene.Initialize();
                Log?.Invoke($"[EditorHost] Scene '{_scene.GetType().Name}' loaded (WYSIWYG mode).");

                StartRenderLoop();
            }
            catch (Exception ex)
            {
                Log?.Invoke($"[EditorHost] Load failed: {ex.GetType().Name}: {ex.Message}");
                if (ex.InnerException != null)
                    Log?.Invoke($"[EditorHost] Inner: {ex.InnerException.Message}");
            }
        }

        // ── Render loop ───────────────────────────────────────────────────────

        private void StartRenderLoop()
        {
            _renderTimer = new System.Windows.Forms.Timer { Interval = 16 };
            _renderTimer.Tick += Tick;
            _renderTimer.Start();
        }

        private void Tick(object? s, EventArgs e)
        {
            if (_scene == null || _target == null) return;

            double dt = (DateTime.Now - _lastTick).TotalSeconds;
            _lastTick = DateTime.Now;

            try
            {
                Lifecycle.ScriptBinding.Tick(_scene, dt, _mode);
                Lifecycle.ScriptBinding.Draw(_scene, _mode);
                _scene.Render();

                if (_mode == EngineMode.Edit && _selectedEntity != null)
                    DrawSelectionGizmo(_selectedEntity);

                _gfx?.Present(_target.Handle);
                SceneUpdated?.Invoke();
            }
            catch (Exception ex)
            {
                Log?.Invoke($"[EditorHost] Tick error: {ex.Message}");
            }
        }

        private void DrawSelectionGizmo(Entity entity)
        {
            int half = GizmoSize / 2;
            _gfx?.DrawRectangle(
                (int)(entity.x - half - 2),
                (int)(entity.y - half - 2),
                GizmoSize + 4,
                GizmoSize + 4,
                0xFF00AAFF);
        }

        // ── Selection ─────────────────────────────────────────────────────────

        public void SelectEntity(Entity? entity) => _selectedEntity = entity;

        public Entity? FindEntity(string name)
        {
            if (_scene == null) return null;
            foreach (var e in _scene.GetEntities())
                if (e.name == name) return e;
            return null;
        }

        // ── Live sync ─────────────────────────────────────────────────────────

        public void SyncEntity(string name, int x, int y, bool enabled)
        {
            if (_scene == null) return;
            foreach (var entity in _scene.GetEntities())
            {
                if (entity.name != name) continue;
                entity.x = x;
                entity.y = y;
                entity.SetEnabled(enabled);
                return;
            }
        }

        // ── Mode ──────────────────────────────────────────────────────────────

        public void SetMode(EngineMode mode)
        {
            _mode = mode;
            Log?.Invoke($"[EditorHost] Mode → {mode}");
        }

        public EngineMode GetMode() => _mode;

        // ── Hot reload ────────────────────────────────────────────────────────

        public void Reload(string projectDir)
        {
            Log?.Invoke("[EditorHost] Hot-reloading scene...");
            var panel = _target;
            Unload();
            if (panel != null) Load(projectDir, panel);
        }

        // ── Unload ────────────────────────────────────────────────────────────

        public void Unload()
        {
            _renderTimer?.Stop();
            _renderTimer?.Dispose();
            _renderTimer = null;
            _selectedEntity = null;

            try { _scene?.Cleanup(); } catch { }
            _scene = null;

            _gfx?.Cleanup();
            _gfx = null;

            _loadContext?.Unload();
            _loadContext = null;
        }

        // ── Helpers ───────────────────────────────────────────────────────────

        private static string? FindGameDll(string projectDir)
        {
            // Check Debug then Release output
            string[] searchDirs =
            {
                Path.Combine(projectDir, "bin", "Debug", "net8.0"),
                Path.Combine(projectDir, "bin", "Release", "net8.0"),
            };

            foreach (string dir in searchDirs)
            {
                if (!Directory.Exists(dir)) continue;

                foreach (var dll in Directory.GetFiles(dir, "*.dll"))
                {
                    string name = Path.GetFileNameWithoutExtension(dll);
                    // Skip engine / framework / third-party DLLs
                    if (name.StartsWith("Angene", StringComparison.OrdinalIgnoreCase) ||
                        name.StartsWith("System", StringComparison.OrdinalIgnoreCase) ||
                        name.StartsWith("Microsoft", StringComparison.OrdinalIgnoreCase) ||
                        name.StartsWith("Newtonsoft", StringComparison.OrdinalIgnoreCase) ||
                        name.StartsWith("DiscordRPC", StringComparison.OrdinalIgnoreCase) ||
                        name.StartsWith("BouncyCastle", StringComparison.OrdinalIgnoreCase) ||
                        name.StartsWith("netstandard", StringComparison.OrdinalIgnoreCase))
                        continue;

                    return dll; // first non-engine DLL is the game
                }
            }

            return null;
        }

        private static IScene? CreateScene(Assembly asm, Panel targetPanel)
        {
            foreach (var type in asm.GetTypes())
            {
                if (!typeof(IScene).IsAssignableFrom(type) || type.IsInterface || type.IsAbstract)
                    continue;

                // 1. Parameterless constructor
                try
                {
                    var inst = (IScene?)Activator.CreateInstance(type);
                    if (inst != null) return inst;
                }
                catch { }

                // 2. Constructor that accepts null (Window parameter — passes null safely)
                try
                {
                    var inst = (IScene?)Activator.CreateInstance(type, new object?[] { null });
                    if (inst != null) return inst;
                }
                catch { }

                // 3. Constructor that accepts a HeadlessWindow
                try
                {
                    var inst = (IScene?)Activator.CreateInstance(
                        type,
                        new HeadlessWindow(targetPanel.Width, targetPanel.Height));
                    if (inst != null) return inst;
                }
                catch { }
            }

            return null;
        }

        public void Dispose() => Unload();
    }
}