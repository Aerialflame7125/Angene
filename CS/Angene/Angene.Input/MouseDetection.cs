using Angene.Common;
using Angene.Essentials;
using Angene.Input.WinInput;
using Angene.Main;
using Angene.Management;
using Angene.Windows;
using System.Runtime.InteropServices;

namespace Angene.Input
{
    internal class MouseDetectionScript : IScreenPlay
    {
        private float xpos = 0f;
        private float ypos = 0f;
        private bool isInWindow = false;

        private readonly HashSet<Keys.IKeyCodeMouse> _heldButtons = new();

        public void Start() { }
        public void OnMessage(IntPtr msgPtr)
        {
            if (msgPtr == IntPtr.Zero) return;
            var msg = Marshal.PtrToStructure<Win32.MSG>(msgPtr);

            switch (msg.message)
            {
                case (uint)WM.LBUTTONDOWN:
                    _heldButtons.Add(WinInput.Keys.IKeyCodeMouse.LMouse);
                    break;
                case (uint)WM.LBUTTONUP:
                    _heldButtons.Remove(WinInput.Keys.IKeyCodeMouse.LMouse);
                    break;
                case (uint)WM.RBUTTONDOWN:
                    _heldButtons.Add(WinInput.Keys.IKeyCodeMouse.RMouse);
                    break;
                case (uint)WM.RBUTTONUP:
                    _heldButtons.Remove(WinInput.Keys.IKeyCodeMouse.RMouse);
                    break;
                case (uint)WM.MOUSEMOVE:
                    xpos = (short)(msg.lParam.ToInt64() & 0xFFFF);
                    ypos = (short)((msg.lParam.ToInt64() >> 16) & 0xFFFF);
                    if (!isInWindow)
                    {
                        isInWindow = true;
                        // trackmouseevent because windows is fucking stinky and wont send mouseleave without it
                        var tme = new Win32.TRACKMOUSEEVENT
                        {
                            cbSize = (uint)Marshal.SizeOf<Win32.TRACKMOUSEEVENT>(),
                            dwFlags = 0x00000002, // TME_LEAVE
                            hwndTrack = msg.hwnd,
                            dwHoverTime = 0
                        };
                        Win32.TrackMouseEvent(ref tme);
                    }
                    break;
                case (uint)WM.MOUSELEAVE:
                    isInWindow = false;
                    break;
            }
        }

        public bool IsButtonDown(Keys.IKeyCodeMouse button) => _heldButtons.Contains(button);

        public HashSet<Keys.IKeyCodeMouse> GetDownButtons() => _heldButtons;

        public (float, float) GetPosition() => (xpos, ypos);

        public bool IsInWindow() => isInWindow;

        public void Render() { }
        public void Cleanup() { }
    }

    public class MouseDetection
    {
        private static MouseDetectionScript? _script;

        /// <summary>
        /// Collection of all entities that have MouseDetection instances on them.
        /// </summary>
        public List<Entity> Instances = new List<Entity>();

        /// <summary>
        /// Takes default ManagementScene object entities of all open windows and registers a new MouseDetection Entity on them.
        /// NOTICE: This method is not recommended for performance. It WILL iterate through all open windows and ManagementScene objects.
        /// </summary>
        public void Register()
        {
            if (_script != null)
            {
                Logger.Log("[MouseDetection] Already registered — skipping duplicate Register() call.",
                    LoggingTarget.Engine, LogLevel.Warning);
                return;
            }

            foreach (Window w in Engine.Instance.OpenWindows)
            {
                Entity DetectionEntity = new Entity(0, 0, "MouseDetection");
                _script = new MouseDetectionScript();
                ManagementScene? a = w.ManagementScene as ManagementScene;
                Entity b = a.AddEntity(DetectionEntity);
                Instances.Add(b);
                b.AddScript(_script);
            }

            Logger.Log($"[MouseDetection] Added {Engine.Instance.OpenWindows.Count} new Entities", LoggingTarget.Engine, LogLevel.Debug);
        }

        /// <summary>
        /// Takes in entity that the user specifies and registers a new MouseDetection object on it.
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
                Logger.Log("[MouseDetection] Already registered — skipping duplicate Register() call.",
                    LoggingTarget.Engine, LogLevel.Warning);
                return;
            }

            _script = new MouseDetectionScript();
            entity.AddScript(_script);
            Instances.Add(entity);

            Logger.Log($"[MouseDetection] Registered on entity '{entity.name}'.",
                LoggingTarget.Engine, LogLevel.Debug);
        }

        /// <summary>
        /// Registers MouseDetection on the default entity of the provided management scene.
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
                Logger.LogError("[MouseDetection] GetDefaultEntity() returned null. " +
                    "Please refer to Angene spec. (Is the management scene instantiated?)", LoggingTarget.Engine);
                return;
            }

            Register(defaultEnt);
        }

        /// <summary>
        /// Checks if the specified key is currently held down. Requires MouseDetection to be registered first.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static bool IsButtonDown(Keys.IKeyCodeMouse button)
        {
            if (_script == null)
                throw new InvalidOperationException("MouseDetection not registered. Call MouseDetection.Register() first.");

            return _script.IsButtonDown(button);
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
            Logger.Log("[MouseDetection] Unregistered.", LoggingTarget.Engine, LogLevel.Debug);
        }

        public static HashSet<Keys.IKeyCodeMouse> GetDownButtons => _script?.GetDownButtons() ?? throw new InvalidOperationException("MouseDetection not registered.");
        public static (float, float) GetPosition() => (_script?.GetPosition() ?? throw new InvalidOperationException("MouseDetection not registered."));
        public static bool IsInWindow() => _script?.IsInWindow() ?? throw new InvalidOperationException("MouseDetection not registered.");
    }
}
