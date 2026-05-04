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

        public Instances() { }
        public void MakeInstances(bool verbose)
        {
            engine = Engine.Instance;
            engine.Init(verbose);
            settings = engine.SettingHandlerInstanced;
        }
    }

    public static class Program
    {
        public static Instances? instances;
        private static DateTime lastFrame;

        [UnmanagedCallersOnly]
        public static int Main(IntPtr args, int argc)
        {
            bool verbose = false;
            try
            {
                Logger.Log("========================================", LoggingTarget.MainConstructor);
                Logger.Log("  Angene KeyDetection Test", LoggingTarget.MainConstructor);
                Logger.Log("  Starting from native host...", LoggingTarget.MainConstructor);
                Logger.Log($"  Platform: {PlatformDetection.CurrentPlatform}", LoggingTarget.MainConstructor);
                Logger.Log("========================================\n", LoggingTarget.MainConstructor);

                string[] argArray = Array.Empty<string>();
                if (args != IntPtr.Zero && argc > 0)
                {
                    argArray = new string[argc];
                    unsafe
                    {
                        IntPtr* pArgs = (IntPtr*)args;
                        for (int i = 0; i < argc; i++)
                            argArray[i] = Marshal.PtrToStringUni(pArgs[i]) ?? string.Empty;
                    }
                    foreach (string arg in argArray)
                    {
                        if (arg == "--verbose" && !verbose)
                            verbose = true;
                    }
                    Logger.Log($"Arguments received ({argc}):", LoggingTarget.MainConstructor);
                    for (int i = 0; i < argArray.Length; i++)
                        Logger.Log($"  [{i}] {argArray[i]}", LoggingTarget.MainConstructor);
                    Logger.Log("", LoggingTarget.MainConstructor);
                }

                RunGame(verbose);

                Logger.Log("\n========================================", LoggingTarget.MainConstructor);
                Logger.Log("  Test completed successfully", LoggingTarget.MainConstructor);
                Logger.Log("========================================", LoggingTarget.MainConstructor);
                return 0;
            }
            catch (Exception ex)
            {
                Logger.Log($"\nFATAL EXCEPTION in Main:", LoggingTarget.MainConstructor, logLevel: LogLevel.Critical, exception: ex);
                return 1;
            }
        }

        private static void RunGame(bool verbose)
        {
            try
            {
                Logger.Log("RunGame() started", LoggingTarget.Engine);

                Stopwatch t = new Stopwatch();
                t.Start();

                instances = new Instances();
                instances.MakeInstances(verbose);
                instances.verbose = verbose;

                double dto = 0.0d;
                double dtl = 0.0d;

                Logger.Log($"Detected platform: {PlatformDetection.CurrentPlatform}", LoggingTarget.Engine);
                Logger.Log("Creating window...", LoggingTarget.Engine);

                Window window;
                try
                {
                    WindowConfig config = new WindowConfig
                    {
                        Title = "Angene | KeyDetection Test",
                        Transparency = Win32.WindowTransparency.SemiTransparent,
                        Width = 1280,
                        Height = 720
                    };
                    window = new Window(config);
                    Logger.Log("Window created successfully", LoggingTarget.Engine);
                }
                catch (Exception ex)
                {
                    Logger.Log($"ERROR creating window: {ex.GetType().Name}: {ex.Message}",
                        LoggingTarget.Engine, logLevel: LogLevel.Critical, exception: ex);
                    throw;
                }

                Logger.Log("Initializing scene...", LoggingTarget.Engine);
                KeyInputTestScene scene;
                try
                {
                    scene = new KeyInputTestScene(window);
                    Logger.Log("Scene created successfully", LoggingTarget.Engine);
                }
                catch (Exception ex)
                {
                    Logger.Log($"ERROR creating scene: {ex.GetType().Name}: {ex.Message}",
                        LoggingTarget.Engine, logLevel: LogLevel.Critical, exception: ex);
                    throw;
                }

                try
                {
                    window.SetScene(scene);
                    Logger.Log("Scene set on window", LoggingTarget.Engine);
                }
                catch (Exception ex)
                {
                    Logger.Log($"ERROR setting scene: {ex.GetType().Name}: {ex.Message}",
                        LoggingTarget.Engine, LogLevel.Critical, exception: ex);
                    throw;
                }

                t.Stop();
                Logger.Log($"Initialized in {t.ElapsedMilliseconds} ms", LoggingTarget.MasterScene, LogLevel.Debug);

                RunWindowsMessageLoop(window, ref dto, ref dtl);

                Logger.Log("\nCleaning up...", LoggingTarget.Engine);
                window.Cleanup();
                Logger.Log("Cleanup complete.", LoggingTarget.Engine);
            }
            catch (Exception ex)
            {
                Logger.Log($"\nEXCEPTION in RunGame:", LoggingTarget.Engine, LogLevel.Critical, exception: ex);
                throw;
            }
        }

        private static void RunWindowsMessageLoop(Window window, ref double dto, ref double dtl)
        {
            bool running = true;

            while (running)
            {
                while (Win32.PeekMessageW(out var msg, IntPtr.Zero, 0, 0, Win32.PM_REMOVE))
                {
                    if (msg.message == (uint)WM.QUIT)
                    {
                        running = false;
                        break;
                    }

                    Win32.TranslateMessage(ref msg);
                    Win32.DispatchMessageW(ref msg);
                }

                if (!running) break;

                double dt = (DateTime.Now - lastFrame).TotalSeconds;
                lastFrame = DateTime.Now;

                foreach (var scene in window.Scenes)
                {
                    Lifecycle.ScriptBinding.Tick(scene, dt, EngineMode.Play);
                    Lifecycle.ScriptBinding.Draw(scene, EngineMode.Play);
                    scene?.Render();
                }

                window._screenPlay?.LateUpdate(dt);

                Thread.Sleep(16);
            }
        }
    }
}