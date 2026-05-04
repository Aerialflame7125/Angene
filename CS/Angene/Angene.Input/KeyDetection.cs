using Angene.Common;
using Angene.Essentials;
using Angene.Input.WinInput;
using Angene.Main;
using Angene.Management;
using Angene.Windows;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Angene.Input
{
    internal class DetectionScript : IScreenPlay
    {
        private readonly HashSet<object> _heldKeys = new();

        public void Start() { }
        public void OnMessage(IntPtr msgPtr)
        {
            if (msgPtr == IntPtr.Zero) return;
            var msg = Marshal.PtrToStructure<Win32.MSG>(msgPtr);

            switch (msg.message)
            {
                case (uint)WM.KEYDOWN:
                    object downKey = Key.TryNInt(msg.wParam);
                    if (downKey is not 0)
                        _heldKeys.Add(downKey);
                    break;

                case (uint)WM.KEYUP:
                    object upKey = Key.TryNInt(msg.wParam);
                    if (upKey is not 0)
                        _heldKeys.Remove(upKey);
                    break;
            }
        }

        public bool IsKeyDown(object key) => _heldKeys.Contains(key);

        public HashSet<Object> GetDownKeys() => _heldKeys;
        
        public void Render() { }
        public void Cleanup() { }
    }

    public class KeyDetection
    {
        private static DetectionScript? _script;
        private static Engine _engineReference;
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
                Logger.Log("[KeyDetection] Already registered — skipping duplicate Register() call.",
                    LoggingTarget.Engine, LogLevel.Warning);
                return;
            }

            foreach (Window w in Engine.Instance.OpenWindows)
            {
                Entity DetectionEntity = new Entity(0, 0, "KeyDetection");
                _script = new DetectionScript();
                ManagementScene? a = w.ManagementScene as ManagementScene;
                Entity b = a.AddEntity(DetectionEntity);
                Instances.Add(b);
                b.AddScript(_script);
            }

            Logger.Log($"[KeyDetection] Added {Engine.Instance.OpenWindows.Count} new Entities", LoggingTarget.Engine, LogLevel.Debug);
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
                Logger.Log("[KeyDetection] Already registered — skipping duplicate Register() call.",
                    LoggingTarget.Engine, LogLevel.Warning);
                return;
            }

            _script = new DetectionScript();
            entity.AddScript(_script);
            Instances.Add(entity);

            Logger.Log($"[KeyDetection] Registered on entity '{entity.name}'.",
                LoggingTarget.Engine, LogLevel.Debug);
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
        public static bool IsKeyDown(object key)
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
            Logger.Log("[KeyDetection] Unregistered.", LoggingTarget.Engine, LogLevel.Debug);
        }

        public static HashSet<object> GetDownKeys => _script?.GetDownKeys() ?? throw new InvalidOperationException("KeyDetection not registered.");
    }
}
