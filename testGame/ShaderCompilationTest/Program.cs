using Angene.Common;
using Angene.Common.Settings;
using Angene.Essentials;
using Angene.Main;
using Angene.Platform;
using Angene.Windows;
using System;
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
            engine.Init(new Types.AppInfo("ShaderCompilationTest", 0.1f, "Aerial", "Aerial"), verbose); // scans this assembly for [Precompile] shaders (TestShaders.cs) and starts compiling them
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
                RunGame(verbose: true);
                return 0;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("FATAL EXCEPTION in Main:");
                System.Console.WriteLine(ex.ToString());   // full type + message + stack trace, no Logger involved
                try { Logger.LogCritical("FATAL EXCEPTION in Main:", LoggingTarget.MainConstructor, exception: ex); }
                catch { /* Logger itself may be broken; we already printed the real exception above */ }
                return 1;
            }
        }

        private static void RunGame(bool verbose)
        {
            try
            {
                System.Console.WriteLine("New stopwatch");
                Stopwatch t = new Stopwatch();
                System.Console.WriteLine("Start stopwatch");
                t.Start();

                Logger.LogDebug($"Creating instances.", LoggingTarget.MainGame);
                instances = new Instances();
                instances.MakeInstances(verbose);

                Logger.LogInfo($"Detected platform: {PlatformDetection.CurrentPlatform}", LoggingTarget.MainGame);

                Logger.LogImportant("Waiting for shader precompilation to finish...", LoggingTarget.MainGame);
                while (Engine.Instance.IsCompilingShaders)
                {
                    PumpOpenWindows();
                    Thread.Sleep(16);
                }
                Logger.LogImportant("Shader precompilation finished.", LoggingTarget.MainGame);

                Window window = null;
                try
                {
                    WindowConfig config = WindowConfig.Rendering3D("Angene | Shader Compile Test", 1280, 720);
                    window = new Window(config);
                }
                catch (Exception e)
                {
                    Logger.LogCritical($"Error creating window: {e.Message}", LoggingTarget.MainConstructor, exception: e, true);
                }

                var scene = new ShaderCompileTestScene(window);
                window.SetScene(scene);

                t.Stop();
                Logger.LogDebug($"Initialized in {t.ElapsedMilliseconds} ms", LoggingTarget.MasterScene);

                double dt = 0.0d;
                RunWindowsMessageLoop(ref dt);

                Logger.LogDebug("Cleaning up...", LoggingTarget.Engine);
                window.Cleanup();
                Logger.LogInfo("Cleanup complete.", LoggingTarget.Engine);
            }
            catch (Exception e)
            {
                Logger.LogCritical($"Error in main constructor: {e.Message}", LoggingTarget.MainConstructor, e, true);
            }
        }

        private static void PumpOpenWindows()
        {
            while (User32.PeekMessageW(out var msg, IntPtr.Zero, 0, 0, Consts.PM_REMOVE))
            {
                if (msg.message == (uint)WM.QUIT) break;
                User32.TranslateMessage(ref msg);
                User32.DispatchMessageW(ref msg);
            }

            foreach (var win in Engine.Instance.OpenWindows.ToArray())
            {
                win.RenderFrame();
                Engine.Instance.FlushPendingCloses();
            }
        }

        private static void RunWindowsMessageLoop(ref double dt)
        {
            bool running = true;

            while (running)
            {
                while (User32.PeekMessageW(out var msg, IntPtr.Zero, 0, 0, Consts.PM_REMOVE))
                {
                    if (msg.message == (uint)WM.QUIT)
                    {
                        running = false;
                        break;
                    }

                    User32.TranslateMessage(ref msg);
                    User32.DispatchMessageW(ref msg);
                }

                if (!running) break;

                dt = (DateTime.Now - lastFrame).TotalSeconds;
                lastFrame = DateTime.Now;

                foreach (var win in Engine.Instance.OpenWindows)
                {
                    foreach (var scene in win.Scenes)
                    {
                        Lifecycle.ScriptBinding.Tick(scene, dt, EngineMode.Play);
                        Lifecycle.ScriptBinding.Draw(scene, EngineMode.Play);
                    }

                    win.RenderFrame();
                    win._screenPlay?.LateUpdate(dt);
                }

                Thread.Sleep(16);
            }
        }
    }
}
