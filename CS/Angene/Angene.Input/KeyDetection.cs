using Angene.Common;
using Angene.Essentials;
using Angene.Main;
using Angene.Management;
using Angene.Windows;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Angene.Input
{
    internal class KeyDetectionScript : IScreenPlay
    {
        private readonly HashSet<uint> _heldKeys = new();

        public Action _fullscreenAction = null;
        private bool holdingFullscreen = false;
        public void Start() { }
        public unsafe void OnMessage(IntPtr msgPtr)
        {
            if (Engine.Instance.SharedX11Display == null)
            {
                if (msgPtr == IntPtr.Zero) return;
                var msg = Marshal.PtrToStructure<WindowManagement.MSG>(msgPtr);

                switch (msg.message)
                {
                    case (uint)WM.KEYDOWN:
                        uint downKey = (uint)Key.TryNInt(msg.wParam);
                        if (downKey != 0)
                            _heldKeys.Add(downKey);
                        break;

                    case (uint)WM.KEYUP:
                        uint upKey = (uint)Key.TryNInt(msg.wParam);
                        if (upKey != 0)
                        {
                            _heldKeys.Remove(upKey);
                        }
                        break;  
                }
            }
        }

        public unsafe void Update(double dt)
        {
            if (Engine.Instance.SharedX11Display != null)
            {
                if (X11Keyboard.IsKeyDown())
                {
                    List<nuint> rawDownKeys = X11Keyboard.GetPressedKeys();
                    var currentFrameKeys = new HashSet<uint>();

                    foreach (nuint k in rawDownKeys)
                    {
                        uint downKey = Key.TryXKeysym(k);
                        if (downKey != 0)
                            currentFrameKeys.Add(downKey);
                    }

                    _heldKeys.RemoveWhere(k => !currentFrameKeys.Contains(k));

                    foreach (uint k in currentFrameKeys)
                        _heldKeys.Add(k);
                }
                else
                {
                    _heldKeys.Clear();
                }
                if (_heldKeys.Contains((uint)Keys.IKeyCodeModX.Alt_R) && _heldKeys.Contains((uint)Keys.IKeyCodeModX.Return))
                {
                    if (!holdingFullscreen)
                    {
                        Engine.Instance.OpenWindows[0].set_fullscreen();
                        Logger.LogDebug("Setting fullscreen status", LoggingTarget.Engine);
                        holdingFullscreen = true;
                    }
                }
                else
                {
                    holdingFullscreen = false;
                }
            }
        }

        public bool IsKeyDown(uint key) => _heldKeys.Contains(key);

        public HashSet<uint> GetDownKeys() => _heldKeys;
        
        public void Render() { }
        public void Cleanup() { }
    }

    public class KeyDetection
    {
        private static KeyDetectionScript? _script;

        /// <summary>
        /// Collection of all entities that have KeyDetection instances on them.
        /// </summary>
        public List<Entity> Instances = new List<Entity>();

        /// <summary>
        /// Takes default ManagementScene object entities of all open windows and registers a new KeyDetection Entity on them.
        /// NOTICE: This method is not recommended for performance. It WILL iterate through all open windows and ManagementScene objects.
        /// </summary>
        public void Register()
        {
            if (_script != null)
            {
                Logger.LogWarning("[KeyDetection] Already registered — skipping duplicate Register() call.",
                    LoggingTarget.Engine);
                return;
            }

            foreach (Window w in Engine.Instance.OpenWindows)
            {
                Entity DetectionEntity = new Entity("KeyDetection");
                _script = new KeyDetectionScript();
                ManagementScene? a = w.ManagementScene as ManagementScene;
                Entity b = a.AddEntity(DetectionEntity);
                Instances.Add(b);
                b.AddScript(_script);
            }

            Logger.LogDebug($"[KeyDetection] Added {Engine.Instance.OpenWindows.Count} new Entities", LoggingTarget.Engine);
        }

        /// <summary>
        /// Takes in entity that the user specifies and registers a new KeyDetection object on it.
        /// If you wish to not create a new entity yourself, use Register().
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Register(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (_script != null)
            {
                Logger.LogWarning("[KeyDetection] Already registered — skipping duplicate Register() call.",
                    LoggingTarget.Engine);
                return;
            }

            _script = new KeyDetectionScript();
            entity.AddScript(_script);
            Instances.Add(entity);

            Logger.LogDebug($"[KeyDetection] Registered on entity '{entity.name}'.",
                LoggingTarget.Engine);
        }

        /// <summary>
        /// Registers KeyDetection on the default entity of the provided management scene.
        /// The scene provided must be instantiated and attached to runtime for registering to work.
        /// This scene should be a scene of the user's choice, otherwise use Register(Entity) instead.
        /// </summary>
        /// <param name="managementScene"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Register(ManagementScene managementScene)
        {
            if (managementScene == null)
                throw new ArgumentNullException(nameof(managementScene));

            Entity? defaultEnt = managementScene.GetDefaultEntity();
            if (defaultEnt == null)
            {
                Logger.LogError("[KeyDetection] GetDefaultEntity() returned null. " +
                    "Please refer to Angene spec. (Is the management scene instantiated?)", LoggingTarget.Engine);
                return;
            }

            Register(defaultEnt);
        }

        /// <summary>
        /// Checks if the specified key is currently held down. Requires KeyDetection to be registered first.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static bool IsKeyDown(uint key)
        {
            if (_script == null)
                throw new InvalidOperationException("KeyDetection not registered. Call KeyDetection.Register() first.");

            return _script.IsKeyDown(key);
        }

        /// <summary>
        /// Nullifies script instance, deregistering it from lifetime.
        /// </summary>
        public void Deregister()
        {
            foreach (Entity e in Instances)
            {
                e.RemoveScript(_script);
            }
            _script = null;
            Logger.LogDebug("[KeyDetection] Unregistered.", LoggingTarget.Engine);
        }

        public static HashSet<uint> GetDownKeys => _script?.GetDownKeys() ?? throw new InvalidOperationException("KeyDetection not registered.");
    }
}
