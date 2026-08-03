using Angene.Common;
using Angene.Common.Settings;
using Angene.Essentials;
using Angene.Main;
using Angene.X11.Interop;
using Angene.Platform;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Game
{
    public class Instances
    {
        public Engine engine;
        public Settings settings;
        public bool verbose;

        public void MakeInstances(bool verbose)
        {
            engine = Engine.Instance;
            engine.Init(new Types.AppInfo("LinuxTest Angene", 0.1f, "Aerial", "Aerial"), verbose); // scans this assembly for [Precompile] shaders (TestShaders.cs) and starts compiling them
            settings = engine.settingsInstance;
        }
    }

    public class Program
    {
        public static Instances instances;
        private static DateTime lastFrame;

        [UnmanagedCallersOnly]
        public static int Main(IntPtr args, int argc)
        {
            try
            {
                RunGame(false);
                return 0;
            }
            catch (Exception ex)
            {
                Logger.LogCritical("FATAL EXCEPTION in Main:", LoggingTarget.MainConstructor, exception: ex);
                return 1;
            }
        }

        private static void RunGame(bool verbose)
        {
            try
            {
                Stopwatch t = new Stopwatch();
                t.Start();

                instances = new Instances();
                instances.MakeInstances(verbose);

                Logger.LogInfo($"Detected platform: {PlatformDetection.CurrentPlatform}", LoggingTarget.MainGame);

                t.Stop();
                Logger.LogDebug($"Initialized in {t.ElapsedMilliseconds} ms", LoggingTarget.MasterScene);

                double dt = 0.0d;
                WindowConfig config = new WindowConfig()
                {
                    Width = 800,
                    Height = 600,
                    Title = "Angene Engine Test",
                    renderMode = Angene.Graphics.RenderType.Vulkan
                };
                WindowConfig config1 = new WindowConfig()
                {
                    Width = 800,
                    Height = 600,
                    Title = "Angene Engine Test2",
                    renderMode = Angene.Graphics.RenderType.Vulkan
                };
                Window win1 = new Window(config1);
                Window win = new Window(config);
                Logger.LogDebug($"OpenWindows count after creation: {Engine.Instance.OpenWindows.Count}", LoggingTarget.Engine);

                RunMessageLoop(ref dt, win);
                RunMessageLoop(ref dt, win1);
                Logger.LogInfo("Cleanup complete.", LoggingTarget.Engine);
            }
            catch (Exception e)
            {
                Logger.LogCritical($"Error in main constructor: {e.Message}", LoggingTarget.MainConstructor, e, true);
            }
        }

        private unsafe static void RunMessageLoop(ref double dt, Window win)
        {

            while (!Engine.Instance.ShouldShutdown)
            {
                bool runningmaybe = win.ProcessMessages(win.Handle);
                if (!runningmaybe) break;

                dt = (DateTime.Now - lastFrame).TotalSeconds;
                lastFrame = DateTime.Now;

                Lifecycle.ScriptBinding.Tick(new EmptyScene(), dt, EngineMode.Play);
                Lifecycle.ScriptBinding.Draw(new EmptyScene(), EngineMode.Play);
            }
            Lifecycle.ScriptBinding.ShutdownEngine();
        }
    }

    public class EmptyScene : IScene
    {
        public object Instance => this;

        public List<Entity> Entities => new List<Entity>();

        public string Name => "EmptyScene";

        public void Cleanup() { }

        public void Initialize()
        {
            Logger.LogError("EmptyScene.Initialize() called.", LoggingTarget.MasterScene);
        }

        public void OnMessage(nint msgPtr) { }

        public void Render() { }
    }
}
