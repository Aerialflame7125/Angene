using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using Angene.Main;
using Angene.Globals;
using Angene.Platform;
using Org.BouncyCastle.Security;
using Angene.Common;
using Angene.Essentials;

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
                    script.Initialize(entities, _window);
                    a.SetEnabled(true);
                }
            }
        }

        public void OnMessage(IntPtr msgPtr)
        {
            if (msgPtr == IntPtr.Zero) return;

#if WINDOWS
            var msg = Marshal.PtrToStructure<Win32.MSG>(msgPtr);
            if (msg.message == Win32.WM_CLOSE)
            {
                Angene.Main.Console.WriteLine("[PackageTest] Received WM_CLOSE");
            }
#else
            var msg = Marshal.PtrToStructure<Window.PlatformMessage>(msgPtr);
            if (msg.message == 33) // ClientMessage
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
                    a.GetScriptByType<TextHandler>().DrawWindows();
#else
                    a.GetScriptByType<TextHandler>().DrawLinux();
#endif
                }

            }
        }

        public List<Entity> GetEntities() => entities;

        public void Cleanup() { }

    }
}