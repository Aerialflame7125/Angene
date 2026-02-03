using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Angene.Main;
using Angene.Platform;

namespace Game
{
    /// <summary>
    /// Entry point for CLR hosting.
    /// </summary>
    public static class Program
    {
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

                double dto = 0.0d;
                double dtl = 0.0d;

                Logger.Log($"Detected platform: {PlatformDetection.CurrentPlatform}", LoggingTarget.Engine);
                Logger.Log("Creating game window...", LoggingTarget.Engine);

                Window? window = null;
                try
                {
                    window = new Window("Angene - Test Game", 800, 600, use3D: false);
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
                    scene = new PackageTest();
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

                Logger.Log("Starting scene...", LoggingTarget.Engine);
                try
                {
                    scene.Start();
                    Logger.Log("Scene started successfully", LoggingTarget.Engine);
                }
                catch (Exception ex)
                {
                    Logger.Log($"ERROR starting scene: {ex.GetType().Name}: {ex.Message}", LoggingTarget.Engine, logLevel: LogLevel.Critical, exception: ex);
                    throw;
                }

                // Main game loop - platform-specific message handling
#if WINDOWS
                Logger.Log("Using Windows message loop", LoggingTarget.Engine, LogLevel.Important);
                RunWindowsMessageLoop(window, scene, ref dto, ref dtl);
#else
                Logger.Log("Using X11 message loop");
                RunX11MessageLoop(window, scene, ref dto, ref dtl);
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
        private static void RunWindowsMessageLoop(Window window, IScene scene, ref double dto, ref double dtl)
        {
            bool running = true;
            int frameCount = 0;

            Logger.Log("Entering message loop...", LoggingTarget.Engine);

            while (running)
            {
                Win32.MSG msg;
                while (Win32.PeekMessageW(out msg, IntPtr.Zero, 0, 0, Win32.PM_REMOVE))
                {
                    if (msg.message == Win32.WM_QUIT)
                    {
                        Logger.LogInfo("Received WM_QUIT", LoggingTarget.Engine);
                        running = false;
                        break;
                    }

                    Win32.TranslateMessage(ref msg);
                    Win32.DispatchMessageW(ref msg);
                }

                if (!running) break;

                // Update / Draw
                try
                {
                    scene.Update(dto);
                    scene.LateUpdate(dtl);
                    scene.OnDraw();

                    frameCount++;
                    if (frameCount == 1 || frameCount % 60 == 0)
                    {
                        Logger.LogDebug($"Frame {frameCount} rendered", LoggingTarget.Engine);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log($"Frame error: {ex.Message}", LoggingTarget.Engine, LogLevel.Important, exception: ex);
                    // Continue running even if a frame fails
                }

                // Simple framerate cap ~60fps
                Thread.Sleep(16);
            }

            Logger.Log($"Message loop exited after {frameCount} frames", LoggingTarget.Engine);
        }
#else
        /// <summary>
        /// X11-specific message loop using the Window's ProcessMessages method
        /// </summary>
        private static void RunX11MessageLoop(Window window, IScene scene, ref double dto, ref double dtl)
        {
            bool running = true;
            int frameCount = 0;

            Logger.Log("Entering X11 message loop...");

            while (running)
            {
                // Process X11 events using the window's instance method
                if (!window.ProcessMessages())
                {
                    Logger.Log("ProcessMessages returned false, exiting loop");
                    running = false;
                    break;
                }

                // Update / Draw
                try
                {
                    scene.Update(dto);
                    scene.LateUpdate(dtl);
                    scene.OnDraw();

                    frameCount++;
                    if (frameCount == 1 || frameCount % 60 == 0)
                    {
                        Logger.Log($"Frame {frameCount} rendered");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log($"Frame error: {ex.Message}");
                    // Continue running even if a frame fails
                }

                // Simple framerate cap ~60fps
                Thread.Sleep(16);
            }

            Logger.Log($"X11 message loop exited after {frameCount} frames");
        }
#endif
    }
}