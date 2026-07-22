using Angene.Common;
using Angene.Common.Settings;
using Angene.Essentials;
using Angene.Main;
using Angene.Platform;
using Angene.Windows;
using DiscordRPC.Logging;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Game
{
    public class Instances
    {
        public Engine engine;
        public Settings settings;
        public bool verbose;

        public Instances() { }
        public void MakeInstances(bool verbose)
        {
            engine = Engine.Instance;
            engine.Init(verbose);
            settings = engine.SettingHandlerInstanced;
        }
    }

    public class Program
    {
        public static Instances? instances;
        private static DateTime lastFrame;

        [UnmanagedCallersOnly]
        public static int Main(IntPtr args, int argc)
        {
            bool verbose = false;
            try
            {
                string[] argArray = Array.Empty<string>();
                if (args != IntPtr.Zero && argc > 0)
                {
                    argArray = new string[argc];
                    unsafe
                    {
                        IntPtr* pArgs = (IntPtr*)args;
                        for (int i = 0; i < argc; i++)
                        {
                            argArray[i] = Marshal.PtrToStringUni(pArgs[i]) ?? string.Empty;
                        }
                    }
                    foreach (string arg in argArray)
                    {
                        if (arg.Length > 0 && arg == "--verbose" && !verbose)
                        {
                            verbose = true;
                        }
                    }
                    Logger.LogDebug($"Arguments received ({argc}):", LoggingTarget.MainConstructor);
                    for (int i = 0; i < argArray.Length; i++)
                    {
                        Logger.LogDebug($"  [{i}] {argArray[i]}", LoggingTarget.MainConstructor);
                    }
                    Logger.LogDebug("", LoggingTarget.MainConstructor);
                }

                Logger.LogDebug("Calling RunGame...", LoggingTarget.MainConstructor);
                RunGame(verbose);

                return 0;
            }
            catch (Exception ex)
            {
                Logger.LogCritical($"nFATAL EXCEPTION in Main:", LoggingTarget.MainConstructor, exception: ex);
                return 1; // Error
            }
        }

        private static void RunGame(bool verbose)
        {
            try
            {
                Logger.LogDebug("RunGame() called", LoggingTarget.Engine);

                Stopwatch t = new Stopwatch();
                t.Start();

                instances = new Instances();
                instances.MakeInstances(verbose);
                instances.verbose = verbose;

                double dto = 0.0d;
                double dtl = 0.0d;

                Logger.LogInfo($"Detected platform: {PlatformDetection.CurrentPlatform}", LoggingTarget.MainGame);
                Logger.LogDebug("Attempting to create window..", LoggingTarget.MainGame);

                Window? window = null;
                Window? window2 = null;
                try
                {
                    WindowConfig config = WindowConfig.Rendering3D("Angene | DX11 Triangle Test", 1280, 720);
                    window = new Window(config);
                    Logger.LogDebug("Created window.", LoggingTarget.Engine);
                    WindowConfig config2 = WindowConfig.Rendering3D("Angene | DX11 Cube Test", 1280, 720);
                    window2 = new Window(config2);
                }
                catch (Exception e)
                {
                    Logger.LogCritical($"Error creating window: {e.Message}", LoggingTarget.MainConstructor, exception: e, true);
                }

                var scene = new DX11TriangleTestScene(window);
                window.SetScene(scene);
                var scene2 = new DX11CubeTestScene(window2);
                window2.SetScene(scene2);

                Logger.LogImportant("Using Windows message loop", LoggingTarget.Engine);
                t.Stop();
                Logger.LogDebug($"Initialized in {t.ElapsedMilliseconds} ms", LoggingTarget.MasterScene);

                RunWindowsMessageLoop(ref dto, ref dtl);

                // Cleanup
                Logger.LogDebug("\nCleaning up...", LoggingTarget.Engine);
                window.Cleanup();
                window2.Cleanup();
                Logger.LogInfo("Cleanup complete.", LoggingTarget.Engine);
            } catch (Exception e)
            {
                Logger.LogCritical($"Error in main constructor: {e.Message}", LoggingTarget.MainConstructor, e, true);
            }
        }

        private static void RunWindowsMessageLoop(ref double dto, ref double dtl)
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

                double dt = (DateTime.Now - lastFrame).TotalSeconds;
                lastFrame = DateTime.Now;

                foreach (var win in Engine.Instance.OpenWindows)
                {
                    foreach (var scene in win.Scenes)
                    {
                        Lifecycle.ScriptBinding.Tick(scene, dt, EngineMode.Play);
                        Lifecycle.ScriptBinding.Draw(scene, EngineMode.Play);
                        scene?.Render();
                    }

                    win._screenPlay?.LateUpdate(dt);
                }

                Thread.Sleep(16);
            }
        }
    }
}