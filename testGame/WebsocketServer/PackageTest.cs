using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using Angene.Main;
using Angene.Globals;
using Angene.Platform;
using Angene.Common;
using Angene.Essentials;
using Newtonsoft.Json.Linq;
#if WINDOWS
using Angene.Graphics;
#endif

namespace Game
{
    public class PackageTest : IScene
    {
        public object Instance { get; private set; }
        public List<Entity> entities { get; private set; }
        public Window _window;
        public IRenderer3D? Renderer3D => null;

        // ── Input state ──────────────────────────────────────────
        public int MouseX { get; private set; }
        public int MouseY { get; private set; }
        public string LastKey { get; private set; } = "None";
        public bool LeftMouseDown { get; private set; }
        public bool RightMouseDown { get; private set; }
        // ─────────────────────────────────────────────────────────

        internal PackageTest(Window window, object instance)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
            Instance = instance;
        }

        public void Initialize()
        {
            entities = new List<Entity>();
            Logger.Log($"[PackageTest] Running on {PlatformDetection.CurrentPlatform}", LoggingTarget.MainGame, LogLevel.Info);
            entities.Add(new Entity(0, 0, "RPC"));
            entities.Add(new Entity(0, 0, "Text"));

            if (_window._screenPlay != null)
            {
                var systemEntity = new Entity(0, 0, "__WindowSystem__");
                entities.Add(systemEntity);
                ScriptBinding.Lifecycle.RegisterScript(systemEntity, _window._screenPlay);
                ScriptBinding.Lifecycle.SetEntityEnabled(systemEntity, true);
            }

            foreach (Entity a in entities)
            {
                if (a.name == "RPC")
                {
                    a.AddScript<RPCScript>();
                    a.SetEnabled(true);
                }
                else if (a.name == "Text")
                {
                    var script = a.AddScript<TextHandler>();
                    script.Initialize(entities, _window, this); // pass 'this' so TextHandler can read input state
                    a.SetEnabled(true);
                }
            }
        }

        public void OnMessage(IntPtr msgPtr)
        {
            if (msgPtr == IntPtr.Zero) return;

#if WINDOWS
            var msg = Marshal.PtrToStructure<Win32.MSG>(msgPtr);

            switch (msg.message)
            {
                case (uint)WM.MOUSEMOVE:
                    // Low word = X, high word = Y
                    MouseX = (int)(msg.lParam.ToInt64() & 0xFFFF);
                    MouseY = (int)((msg.lParam.ToInt64() >> 16) & 0xFFFF);
                    break;

                case (uint)WM.LBUTTONDOWN:
                    LeftMouseDown = true;
                    MouseX = (int)(msg.lParam.ToInt64() & 0xFFFF);
                    MouseY = (int)((msg.lParam.ToInt64() >> 16) & 0xFFFF);
                    break;

                case (uint)WM.LBUTTONUP:
                    LeftMouseDown = false;
                    break;

                case (uint)WM.RBUTTONDOWN:
                    RightMouseDown = true;
                    MouseX = (int)(msg.lParam.ToInt64() & 0xFFFF);
                    MouseY = (int)((msg.lParam.ToInt64() >> 16) & 0xFFFF);
                    break;

                case (uint)WM.RBUTTONUP:
                    RightMouseDown = false;
                    break;

                case (uint)WM.KEYDOWN:
                    // wParam is the virtual key code — map common ones to readable names
                    LastKey = VKeyToString((int)msg.wParam.ToInt64());
                    break;

                case (uint)WM.KEYUP:
                    // Optionally clear on key up — comment this out to keep showing last pressed
                    // LastKey = "None";
                    break;

                case (uint)WM.CLOSE:
                    Angene.Main.Console.WriteLine("[PackageTest] Received WM_CLOSE");
                    break;
            }
#else
            var msg = Marshal.PtrToStructure<Window.PlatformMessage>(msgPtr);
            if (msg.message == 33)
            {
                Console.WriteLine("[PackageTest] Received close message");
            }
#endif
        }

        public void Render()
        {
            foreach (Entity a in entities)
            {
                if (a.name == "Text")
                {
#if WINDOWS
                    var handler = a.GetScriptByType<TextHandler>();
                    if (_window.Graphics is WSGraphicsContext)
                        handler.DrawWS();
                    else
                        handler.DrawWindows();
#else
                    a.GetScriptByType<TextHandler>().DrawLinux();
#endif
                }
            }
        }

        public List<Entity> GetEntities() => entities;
        public void Cleanup() { }

        // ── Virtual key code → readable name ─────────────────────
        private static string VKeyToString(int vk) => vk switch
        {
            0x08 => "Backspace",
            0x09 => "Tab",
            0x0D => "Enter",
            0x10 => "Shift",
            0x11 => "Ctrl",
            0x12 => "Alt",
            0x1B => "Escape",
            0x20 => "Space",
            0x25 => "Left",
            0x26 => "Up",
            0x27 => "Right",
            0x28 => "Down",
            0x2E => "Delete",
            >= 0x30 and <= 0x39 => ((char)vk).ToString(),           // 0–9
            >= 0x41 and <= 0x5A => ((char)vk).ToString(),           // A–Z
            >= 0x70 and <= 0x7B => $"F{vk - 0x6F}",                 // F1–F12
            >= 0x60 and <= 0x69 => $"Num{vk - 0x60}",               // Numpad 0–9
            _ => $"0x{vk:X2}"
        };
    }
}