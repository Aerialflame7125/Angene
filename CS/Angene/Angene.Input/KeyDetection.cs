using Angene.Common;
using Angene.Essentials;
using Angene.Main;
using Angene.Management;
using Angene.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Angene.Graphics;
using Angene.Input;
using Angene.Linux;
using Angene.Linux.Wayland;
using Angene.Linux.X11;
using static Angene.Linux.X11.XLib;

namespace Angene.Input
{
    internal class KeyDetectionScript : IScreenPlay
    {
        private readonly HashSet<uint> _heldKeys = new();

        public Action _fullscreenAction = null;
        private bool holdingFullscreen = false;
        private bool anyKeyDown = false;

        public unsafe void OnMessage(object msgPtr)
        {
#if WINDOWS
            if (msgPtr is IntPtr winmsgptr)
            {
                var msg = Marshal.PtrToStructure<WindowManagement.MSG>(winmsgptr);
                
                switch (msg.message)
                {
                    case (uint)WM.KEYDOWN:
                        uint downKey = (uint)KeyResolver.TryNInt(msg.wParam);
                        if (downKey != 0)
                            _heldKeys.Add(downKey);
                        break;

                    case (uint)WM.KEYUP:
                        uint upKey = (uint)KeyResolver.TryNInt(msg.wParam);
                        if (upKey != 0)
                        {
                            _heldKeys.Remove(upKey);
                        }
                        break;  
                }
                if (_heldKeys.Contains((uint)WinInputKeys.IKeyCodeModWin.RAlt) && _heldKeys.Contains((uint)WinInputKeys.IKeyCodeModWin.Return))
                {
                    if (!holdingFullscreen)
                    {
                        //Engine.Instance.OpenWindows[0].set_fullscreen();
                        Logger.LogDebug("Setting fullscreen status", LoggingTarget.Engine);
                        holdingFullscreen = true;
                    }
                }
                else
                {
                    holdingFullscreen = false;
                }
            }
#endif
#if LINUX
            if (msgPtr is _XEvent msg)
            {
                foreach (Window win in Engine.Instance.OpenWindows)
                {
                    IntPtr XWin;
                    int revertTo;
                    Methods.XGetInputFocus(Engine.Instance.SharedX11Display, (nuint*)&XWin, &revertTo);

                    nuint keysym = XLib.Methods.XKeycodeToKeysym(Engine.Instance.SharedX11Display, (byte)msg.xkey.keycode, 0);
                    if (win.Handle is X11WindowHandle handle && XWin == handle.Window)
                    {
                        switch (msg.type)
                        {
                            case 2: // KeyPress
                                uint downKey = KeyResolver.TryLinuxKeysym(keysym);
                                if (downKey != 0)
                                    _heldKeys.Add(downKey);
                                break;
                            case 3: // KeyRelease
                                uint upKey = KeyResolver.TryLinuxKeysym(keysym);
                                if (upKey != 0)
                                    _heldKeys.Remove(upKey);
                                break;
                        }

                        if (_heldKeys.Contains((uint)X11InputKeys.IKeyCodeModLinux.Alt_R) &&
                        _heldKeys.Contains((uint)X11InputKeys.IKeyCodeModLinux.Return))
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
            }
#endif
        }

#if LINUX
        public unsafe void Update(double dt)
        {
            if (Engine.Instance.OpenWindows.Count >= 1)
            {
                if (Engine.Instance.OpenWindows[0].Handle is WaylandWindowHandle)
                {
                    var currentFrameKeys = new HashSet<uint>(WaylandInputHandler.instance.GetPressedKeys());

                    _heldKeys.RemoveWhere(k => !currentFrameKeys.Contains(k));
                    
                    if (currentFrameKeys.Count > 0)
                    {
                        foreach (uint k in currentFrameKeys)
                            _heldKeys.Add(k);
                    }
                    else
                        _heldKeys.Clear();

                    if (_heldKeys.Contains((uint)X11InputKeys.IKeyCodeModLinux.Alt_R) &&
                        _heldKeys.Contains((uint)X11InputKeys.IKeyCodeModLinux.Return))
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

            if (_heldKeys.Count > 0)
                anyKeyDown = true;
            else
                anyKeyDown = false;
        }
#endif

        public bool IsKeyDown(uint key) => _heldKeys.Contains(key);

        public bool IsAnyKeyDown() => anyKeyDown;

        public HashSet<uint> GetDownKeys() => _heldKeys;
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

            Logger.LogDebug($"[KeyDetection] Added {Engine.Instance.OpenWindows.Count} new Entities",
                LoggingTarget.Engine);
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
        public void Register(ManagementScene managementScene, bool waylandkeys)
        {
            if (managementScene == null)
                throw new ArgumentNullException(nameof(managementScene));

            Entity? defaultEnt = managementScene.GetDefaultEntity();
            if (defaultEnt == null)
            {
                Logger.LogError("[KeyDetection] GetDefaultEntity() returned null. " +
                                "Please refer to Angene spec. (Is the management scene instantiated?)",
                    LoggingTarget.Engine);
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
                throw new InvalidOperationException(
                    "KeyDetection not registered. Call KeyDetection.Register() first.");

            return _script.IsKeyDown(key);
        }

        public static bool IsAnyKeyDown()
        {
            if (_script == null)
                throw new InvalidOperationException(
                    "KeyDetection not registered. Call KeyDetection.Register() first.");

            return _script.IsAnyKeyDown();
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

        public static HashSet<uint> GetDownKeys => _script?.GetDownKeys() ??
                                                   throw new InvalidOperationException(
                                                       "KeyDetection not registered.");
    }
}
