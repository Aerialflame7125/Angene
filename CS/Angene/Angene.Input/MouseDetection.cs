using System.Diagnostics;
using Angene.Common;
using Angene.Essentials;
using Angene.Main;
using Angene.Management;
using Angene.Windows;
using System.Runtime.InteropServices;
using Angene.Linux.X11;
using Angene.Graphics;

namespace Angene.Input
{
    internal class MouseDetectionScript : IScreenPlay
    {
        private float xpos = 0f;
        private float ypos = 0f;
        private bool isInWindow = false;

        private readonly HashSet<uint> _heldButtons = new();
        private XLib._XEvent xevent;

        public unsafe void Start()
        {
#if LINUX
            if (Engine.Instance.OpenWindows[0].Handle is X11WindowHandle handle)
            {
                Logger.LogDebug("xselectinput", LoggingTarget.Engine);
                XLib.Methods.XSelectInput(Engine.Instance.SharedX11Display,
                    (nuint)handle.Window,
                    (IntPtr)(XLib.XEventMask.ExposureMask
                             | XLib.XEventMask.KeyPressMask
                             | XLib.XEventMask.PointerMotionMask
                             | XLib.XEventMask.ButtonPressMask
                             | XLib.XEventMask.ButtonReleaseMask
                             | XLib.XEventMask.EnterWindowMask
                             | XLib.XEventMask.LeaveWindowMask));
                XLib.Methods.XMapWindow(Engine.Instance.SharedX11Display,
                    (nuint)handle.Window);
            }
#endif
        }
        public void OnMessage(IntPtr msgPtr)
        {
#if WINDOWS
            if (msgPtr == IntPtr.Zero) return;
            var msg = Marshal.PtrToStructure<WindowManagement.MSG>(msgPtr);

            switch (msg.message)
            {
                case (uint)WM.LBUTTONDOWN:
                    _heldButtons.Add((uint)Keys.IKeyCodeMouseWin.LMouse);
                    break;
                case (uint)WM.LBUTTONUP:
                    _heldButtons.Remove((uint)Keys.IKeyCodeMouseWin.LMouse);
                    break;
                case (uint)WM.RBUTTONDOWN:
                    _heldButtons.Add((uint)Keys.IKeyCodeMouseWin.RMouse);
                    break;
                case (uint)WM.RBUTTONUP:
                    _heldButtons.Remove((uint)Keys.IKeyCodeMouseWin.RMouse);
                    break;
                case (uint)WM.MOUSEMOVE:
                    xpos = (short)(msg.lParam.ToInt64() & 0xFFFF);
                    ypos = (short)((msg.lParam.ToInt64() >> 16) & 0xFFFF);
                    if (!isInWindow)
                    {
                        isInWindow = true;
                        // trackmouseevent because windows is fucking stinky and wont send mouseleave without it
                        var tme = new WindowManagement.TRACKMOUSEEVENT
                        {
                            cbSize = (uint)Marshal.SizeOf<WindowManagement.TRACKMOUSEEVENT>(),
                            dwFlags = 0x00000002, // TME_LEAVE
                            hwndTrack = msg.hwnd,
                            dwHoverTime = 0
                        };
                        User32.TrackMouseEvent(ref tme);
                    }
                    break;
                case (uint)WM.MOUSELEAVE:
                    isInWindow = false;
                    break;
            }
#endif
        }

#if LINUX
        public unsafe void Update(double dt)
        {
            if (Engine.Instance.OpenWindows[0].Handle is X11WindowHandle && Engine.Instance.SharedX11Display != null)
            {
                while (XLib.Methods.XPending(Engine.Instance.SharedX11Display) > 0)
                {
                    XLib._XEvent xeventptr = xevent;
                    XLib.Methods.XNextEvent(Engine.Instance.SharedX11Display, &xeventptr);
                    switch (xeventptr.type)
                    {
                        case 6: // MotionNotify
                            xpos = xeventptr.xmotion.x;
                            ypos = xeventptr.xmotion.y;
                            break;
                        case 4: // ButtonPress
                            switch (xeventptr.xbutton.button)
                            {
                                case 1:
                                    _heldButtons.Add((uint)Keys.IKeyCodeMouseLinux.Button1Left);
                                    break;
                                case 2:
                                    _heldButtons.Add((uint)Keys.IKeyCodeMouseLinux.Button2Middle);
                                    break;
                                case 3:
                                    _heldButtons.Add((uint)Keys.IKeyCodeMouseLinux.Button3Right);
                                    break;
                                case 4:
                                    _heldButtons.Add((uint)Keys.IKeyCodeMouseLinux.Button4ScrUp);
                                    break;
                                case 5:
                                    _heldButtons.Add((uint)Keys.IKeyCodeMouseLinux.Button5ScrDown);
                                    break;
                                case 6:
                                    _heldButtons.Add((uint)Keys.IKeyCodeMouseLinux.Button6);
                                    break;
                                case 7:
                                    _heldButtons.Add((uint)Keys.IKeyCodeMouseLinux.Button7);
                                    break;
                                case 8:
                                    _heldButtons.Add((uint)Keys.IKeyCodeMouseLinux.Button8);
                                    break;
                                case 9:
                                    _heldButtons.Add((uint)Keys.IKeyCodeMouseLinux.Button9);
                                    break;
                            }

                            break;
                        case 5: // ButtonRelease
                            switch (xeventptr.xbutton.button)
                            {
                                case 1:
                                    _heldButtons.Remove((uint)Keys.IKeyCodeMouseLinux.Button1Left);
                                    break;
                                case 2:
                                    _heldButtons.Remove((uint)Keys.IKeyCodeMouseLinux.Button2Middle);
                                    break;
                                case 3:
                                    _heldButtons.Remove((uint)Keys.IKeyCodeMouseLinux.Button3Right);
                                    break;
                                case 4:
                                    _heldButtons.Remove((uint)Keys.IKeyCodeMouseLinux.Button4ScrUp);
                                    break;
                                case 5:
                                    _heldButtons.Remove((uint)Keys.IKeyCodeMouseLinux.Button5ScrDown);
                                    break;
                                case 6:
                                    _heldButtons.Remove((uint)Keys.IKeyCodeMouseLinux.Button6);
                                    break;
                                case 7:
                                    _heldButtons.Remove((uint)Keys.IKeyCodeMouseLinux.Button7);
                                    break;
                                case 8:
                                    _heldButtons.Remove((uint)Keys.IKeyCodeMouseLinux.Button8);
                                    break;
                                case 9:
                                    _heldButtons.Remove((uint)Keys.IKeyCodeMouseLinux.Button9);
                                    break;
                            }

                            break;

                        case 7: // EnterNotify
                            isInWindow = true;
                            break;

                        case 8: // LeaveNotify
                            isInWindow = false;
                            break;

                    }
                }
            }
            else if (Engine.Instance.OpenWindows[0].Handle is WaylandWindowHandle)
            {
                var currentFrameKeys = new HashSet<uint>(WaylandInputHandler.instance.GetPressedButtons());

                _heldButtons.RemoveWhere(k => !currentFrameKeys.Contains(k));
                
                if (currentFrameKeys.Count > 0)
                    foreach (uint k in currentFrameKeys)
                        _heldButtons.Add(k);
                (xpos, ypos) = WaylandInputHandler.instance.GetMousePos();
                isInWindow = WaylandInputHandler.instance.IsMouseInWindow();
            }
        }
#endif

        public bool IsButtonDown(uint button) => _heldButtons.Contains(button);

        public HashSet<uint> GetDownButtons() => _heldButtons;

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
                Logger.LogWarning("[MouseDetection] Already registered — skipping duplicate Register() call.",
                    LoggingTarget.Engine);
                return;
            }

            foreach (Window w in Engine.Instance.OpenWindows)
            {
                Entity DetectionEntity = new Entity("MouseDetection");
                _script = new MouseDetectionScript();
                ManagementScene? a = w.ManagementScene as ManagementScene;
                Entity b = a.AddEntity(DetectionEntity);
                Instances.Add(b);
                b.AddScript(_script);
            }

            Logger.LogDebug($"[MouseDetection] Added {Engine.Instance.OpenWindows.Count} new Entities", LoggingTarget.Engine);
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
                Logger.LogWarning("[MouseDetection] Already registered — skipping duplicate Register() call.",
                    LoggingTarget.Engine);
                return;
            }

            _script = new MouseDetectionScript();
            entity.AddScript(_script);
            Instances.Add(entity);

            Logger.LogDebug($"[MouseDetection] Registered on entity '{entity.name}'.",
                LoggingTarget.Engine);
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
        public static bool IsButtonDown(uint button)
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
            Logger.LogDebug("[MouseDetection] Unregistered.", LoggingTarget.Engine);
        }

        public static HashSet<uint> GetDownButtons => _script?.GetDownButtons() ?? throw new InvalidOperationException("MouseDetection not registered.");
        public static (float, float) GetPosition() => _script?.GetPosition() ?? throw new InvalidOperationException("MouseDetection not registered.");
        public static bool IsInWindow() => _script?.IsInWindow() ?? throw new InvalidOperationException("MouseDetection not registered.");
    }
}
