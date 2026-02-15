using Angene.Common;
using Angene.Common.Settings;
using Angene.Essentials;
using Angene.Main;
using Angene.Platform;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using static System.Formats.Asn1.AsnWriter;

namespace Game
{
    public class Instances
    {
        public static Instances Instance { get; } = new Instances();
        public Engine engine;
        public Settings settings;
        public Instances() { }
        public void MakeInstances()
        {
            engine = Engine.Instance;
            engine.Init();
            settings = engine.SettingHandlerInstanced;
        }
    }


    /// <summary>
    /// Entry point for CLR hosting.
    /// </summary>
    public static class Program
    {
        private static DateTime lastFrame;

        /// <summary>
        /// CLR host entry point - called by the C++ native host.
        /// </summary>
        [UnmanagedCallersOnly]
        public static int Main(IntPtr args, int argc)
        {
            try
            {
                Logger.Log("========================================", LoggingTarget.MainConstructor);
                Logger.Log("  Angene Test Game (Managed)", LoggingTarget.MainConstructor);
                Logger.Log("  Starting from native host...", LoggingTarget.MainConstructor);
                Logger.Log($"  Platform: {PlatformDetection.CurrentPlatform}", LoggingTarget.MainConstructor);
                Logger.Log("========================================\n", LoggingTarget.MainConstructor);

                // Parse command-line arguments if provided
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

                    Logger.Log($"Arguments received ({argc}):", LoggingTarget.MainConstructor);
                    for (int i = 0; i < argArray.Length; i++)
                    {
                        Logger.Log($"  [{i}] {argArray[i]}", LoggingTarget.MainConstructor);
                    }
                    Logger.Log("", LoggingTarget.MainConstructor);
                }

                Logger.Log("Calling RunGame()...", LoggingTarget.MainConstructor);

                // Call your game Logger.Logic
                RunGame();

                Logger.Log("\n========================================", LoggingTarget.MainConstructor);
                Logger.Log("  Game completed successfully", LoggingTarget.MainConstructor);
                Logger.Log("========================================", LoggingTarget.MainConstructor);

                return 0; // Success
            }
            catch (Exception ex)
            {
                Logger.Log($"\nFATAL EXCEPTION in Main:", LoggingTarget.MainConstructor, logLevel:LogLevel.Critical, exception: ex);
                return 1; // Error
            }
        }

        private static void RunGame()
        {
            try
            {
                Logger.Log("RunGame() started", LoggingTarget.Engine);

                var instances = new Instances();
                instances.MakeInstances();

                double dto = 0.0d;
                double dtl = 0.0d;

                Logger.Log($"Detected platform: {PlatformDetection.CurrentPlatform}", LoggingTarget.Engine);
                Logger.Log("Creating game window...", LoggingTarget.Engine);

                Window? window = null;
                try
                {
                    WindowConfig config = new WindowConfig();
                    config.Title = "Angene | WindowTest";
                    config.Transparency = Win32.WindowTransparency.SemiTransparent;
                    config.Width = 1280; config.Height = 720;
                    window = new Window(config);
                    Logger.Log("Window created successfully", LoggingTarget.Engine);
                }
                catch (Exception ex)
                {
                    Logger.Log($"ERROR creating window: {ex.GetType().Name}: {ex.Message}", LoggingTarget.Engine, logLevel: LogLevel.Critical, exception: ex);
                    throw;
                }

                Logger.Log("Initializing scene...", LoggingTarget.Engine);
                PackageTest? scene = null;
                try
                {
                    scene = new PackageTest(window, new object());
                    Logger.Log("Scene created successfully", LoggingTarget.Engine);
                }
                catch (Exception ex)
                {
                    Logger.Log($"ERROR creating scene: {ex.GetType().Name}: {ex.Message}", LoggingTarget.Engine, logLevel: LogLevel.Critical, exception: ex);
                    throw;
                }

                try
                {
                    window.SetScene(scene);
                    Logger.Log("Scene set on window", LoggingTarget.Engine);
                }
                catch (Exception ex)
                {
                    Logger.Log($"ERROR setting scene: {ex.GetType().Name}: {ex.Message}", LoggingTarget.Engine, LogLevel.Critical, exception: ex);
                    throw;
                }

                // Main game loop - platform-specific message handling
#if WINDOWS
                Logger.Log("Using Windows message loop", LoggingTarget.Engine, LogLevel.Important);
                RunWindowsMessageLoop(window, ref dto, ref dtl);
#else
                Logger.Log("Using X11 message loop");
                RunX11MessageLoop(window, ref dto, ref dtl);
#endif

                // Cleanup
                Logger.Log("\nCleaning up...", LoggingTarget.Engine);
                window.Cleanup();
                Logger.Log("Cleanup complete.", LoggingTarget.Engine);
            }
            catch (Exception ex)
            {
                Logger.Log($"\nEXCEPTION in RunGame:", LoggingTarget.Engine, LogLevel.Critical, exception: ex);
                throw; // Re-throw to be caught by Main
            }
        }

#if WINDOWS
        /// <summary>
        /// Windows-specific message loop using Win32 APIs
        /// </summary>
        private static void RunWindowsMessageLoop(Window window, ref double dto, ref double dtl)
        {
            bool running = true;

            while (running)
            {
                while (Win32.PeekMessageW(out var msg, IntPtr.Zero, 0, 0, Win32.PM_REMOVE))
                {
                    if (msg.message == Win32.WM_QUIT)
                    {
                        running = false;
                        break;
                    }

                    Win32.TranslateMessage(ref msg);
                    Win32.DispatchMessageW(ref msg);
                }

                if (!running) break;

                foreach (var scene in window.Scenes)
                {
                    double dt = (DateTime.Now - lastFrame).TotalSeconds;
                    ScriptBinding.Lifecycle.Tick(scene, dt, EngineMode.Play);
                    ScriptBinding.Lifecycle.Draw(scene, EngineMode.Play);
                    scene?.Render();
                }
                

                Thread.Sleep(16);
            }
        }

#else
        /// <summary>
        /// X11-specific message loop using the Window's ProcessMessages method
        /// </summary>
        private static void RunX11MessageLoop(Window window, ref double dto, ref double dtl)
        {
            bool running = true;
            int frameCount = 0;

            Logger.Log("Entering X11 message loop...");

            while (running)
            {
                if (!window.ProcessMessages())
                    break;

                foreach (var s in window.Scenes)
                    s.Update(dto);

                foreach (var s in window.Scenes)
                    s.LateUpdate(dtl);

                foreach (var s in window.Scenes)
                    s.OnDraw();

                Thread.Sleep(16);
            }

            Logger.Log($"X11 message loop exited after {frameCount} frames");
        }
#endif
    }
}