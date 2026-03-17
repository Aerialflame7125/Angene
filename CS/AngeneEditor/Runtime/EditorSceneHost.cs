// Runtime/EditorSceneHost.cs
using Angene.Common;
using Angene.Essentials;
using Angene.Graphics;
using Angene.Main;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Windows.Forms;
using static Angene.Essentials.Lifecycle;


// Explicit alias to avoid ambiguity with System.Windows.Forms.VisualStyles.VisualStyleElement.Window
using AngeneWindow = Angene.Main.Window;

namespace AngeneEditor.Runtime
{
    /// <summary>
    /// Hosts a game scene in-process, rendering directly into an editor Panel.
    /// This is the WYSIWYG core — no subprocess, no window embedding.
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

        // Selected entity for gizmo drawing — set via SelectEntity()
        private Entity? _selectedEntity;

        // Gizmo display size in pixels (entities have no intrinsic size yet)
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
                Log?.Invoke("[EditorHost] Game DLL not found — build first.");
                return;
            }

            try
            {
                var asm = _loadContext.LoadFromAssemblyPath(dllPath);
                _scene = CreateScene(asm, targetPanel);

                if (_scene == null)
                {
                    Log?.Invoke("[EditorHost] Could not find IScene implementation in game DLL.");
                    return;
                }

                _gfx = new GdiGraphicsContext(
                    targetPanel.Handle,
                    targetPanel.Width,
                    targetPanel.Height);

                _scene.Initialize();
                Log?.Invoke("[EditorHost] Scene loaded in-process (WYSIWYG mode).");

                StartRenderLoop();
            }
            catch (Exception ex)
            {
                Log?.Invoke($"[EditorHost] Load failed: {ex.Message}");
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

        /// <summary>
        /// Draws a fixed-size cyan outline around the selected entity's position.
        /// Entities have no intrinsic size in Angene, so GizmoSize is used.
        /// </summary>
        private void DrawSelectionGizmo(Entity entity)
        {
            int half = GizmoSize / 2;
            _gfx?.DrawRectangle(
                entity.x - half - 2,
                entity.y - half - 2,
                GizmoSize + 4,
                GizmoSize + 4,
                0xFF00AAFF); // ARGB cyan outline
        }

        // ── Selection ─────────────────────────────────────────────────────────

        /// <summary>
        /// Sets the entity that receives the selection gizmo in Edit mode.
        /// Pass null to clear the selection.
        /// </summary>
        public void SelectEntity(Entity? entity)
        {
            _selectedEntity = entity;
        }

        /// <summary>
        /// Finds a live Entity by name so the inspector can select it after
        /// the scene is loaded.
        /// </summary>
        public Entity? FindEntity(string name)
        {
            if (_scene == null) return null;
            foreach (var e in _scene.GetEntities())
                if (e.name == name) return e;
            return null;
        }

        // ── Live entity sync ──────────────────────────────────────────────────

        /// <summary>
        /// Called by the Inspector whenever a property changes.
        /// Updates the live Entity directly — no rebuild required.
        /// </summary>
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

        // ── Mode switching ────────────────────────────────────────────────────

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
            string debugOut = Path.Combine(projectDir, "bin", "Debug", "net8.0");
            if (!Directory.Exists(debugOut)) return null;

            foreach (var dll in Directory.GetFiles(debugOut, "*.dll"))
            {
                string name = Path.GetFileNameWithoutExtension(dll);
                if (!name.StartsWith("Angene") &&
                    !name.StartsWith("System") &&
                    !name.StartsWith("Microsoft") &&
                    !name.StartsWith("Newtonsoft") &&
                    !name.StartsWith("DiscordRPC") &&
                    !name.StartsWith("BouncyCastle"))
                    return dll;
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
                    return (IScene?)Activator.CreateInstance(type);
                }
                catch { /* fall through */ }

                // 2. Constructor that accepts a HeadlessWindow
                try
                {
                    return (IScene?)Activator.CreateInstance(
                        type,
                        new HeadlessWindow(targetPanel.Width, targetPanel.Height));
                }
                catch { /* fall through */ }
            }
            return null;
        }

        public void Dispose() => Unload();
    }
}