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
        private static StreamWriter? _logWriter;

        private static void Log(string message)
        {
            var logMessage = $"[{DateTime.Now:HH:mm:ss.fff}] {message}";
            Console.WriteLine(logMessage);

            try
            {
                if (_logWriter == null)
                {
                    var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    var exeDir = Path.GetDirectoryName(exePath) ?? Environment.CurrentDirectory;
                    var logPath = Path.Combine(exeDir, "game_managed.log");
                    _logWriter = new StreamWriter(logPath, false) { AutoFlush = true };
                    _logWriter.WriteLine($"=== Game Log Started at {DateTime.Now} ===\n");
                }
                _logWriter.WriteLine(logMessage);
            }
            catch
            {
                // If logging fails, continue anyway
            }
        }

        /// <summary>
        /// CLR host entry point - called by the C++ native host.
        /// </summary>
        [UnmanagedCallersOnly]
        public static int Main(IntPtr args, int argc)
        {
            try
            {
                Log("========================================");
                Log("  Angene Test Game (Managed)");
                Log("  Starting from native host...");
                Log($"  Platform: {PlatformDetection.CurrentPlatform}");
                Log("========================================\n");

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

                    Log($"Arguments received ({argc}):");
                    for (int i = 0; i < argArray.Length; i++)
                    {
                        Log($"  [{i}] {argArray[i]}");
                    }
                    Log("");
                }

                Log("Calling RunGame()...");

                // Call your game logic
                RunGame();

                Log("\n========================================");
                Log("  Game completed successfully");
                Log("========================================");

                _logWriter?.Close();
                return 0; // Success
            }
            catch (Exception ex)
            {
                Log("\n========================================");
                Log("  FATAL ERROR IN MAIN");
                Log("========================================");
                Log($"Exception Type: {ex.GetType().FullName}");
                Log($"Message: {ex.Message}");
                Log($"\nStack Trace:\n{ex.StackTrace}");

                if (ex.InnerException != null)
                {
                    Log($"\nInner Exception: {ex.InnerException.GetType().FullName}");
                    Log($"Inner Message: {ex.InnerException.Message}");
                    Log($"Inner Stack:\n{ex.InnerException.StackTrace}");
                }

                _logWriter?.Close();
                return 1; // Error
            }
        }

        private static void RunGame()
        {
            try
            {
                Log("RunGame() started");

                double dto = 0.0d;
                double dtl = 0.0d;

                Log($"Detected platform: {PlatformDetection.CurrentPlatform}");
                Log("Creating game window...");

                Window? window = null;
                try
                {
                    window = new Window("Angene - Test Game", 800, 600, use3D: false);
                    Log("Window created successfully");
                }
                catch (Exception ex)
                {
                    Log($"ERROR creating window: {ex.GetType().Name}: {ex.Message}");
                    Log($"Stack: {ex.StackTrace}");
                    throw;
                }

                Log("Initializing scene...");
                PackageTest? scene = null;
                try
                {
                    scene = new PackageTest(window);
                    Log("Scene created successfully");
                }
                catch (Exception ex)
                {
                    Log($"ERROR creating scene: {ex.GetType().Name}: {ex.Message}");
                    throw;
                }

                try
                {
                    window.SetScene(scene);
                    Log("Scene set on window");
                }
                catch (Exception ex)
                {
                    Log($"ERROR setting scene: {ex.GetType().Name}: {ex.Message}");
                    throw;
                }

                Log("Starting scene...");
                try
                {
                    scene.Start();
                    Log("Scene started successfully");
                }
                catch (Exception ex)
                {
                    Log($"ERROR starting scene: {ex.GetType().Name}: {ex.Message}");
                    Log($"Stack: {ex.StackTrace}");
                    throw;
                }

                // Main game loop - platform-specific message handling
#if WINDOWS
                Log("Using Windows message loop");
                RunWindowsMessageLoop(window, scene, ref dto, ref dtl);
#else
                Log("Using X11 message loop");
                RunX11MessageLoop(window, scene, ref dto, ref dtl);
#endif

                // Cleanup
                Log("\nCleaning up...");
                window.Cleanup();
                Log("Cleanup complete.");
            }
            catch (Exception ex)
            {
                Log($"\nEXCEPTION in RunGame:");
                Log($"  Type: {ex.GetType().FullName}");
                Log($"  Message: {ex.Message}");
                Log($"  Stack:\n{ex.StackTrace}");
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
            
            Log("Entering message loop...");
            
            while (running)
            {
                Win32.MSG msg;
                while (Win32.PeekMessageW(out msg, IntPtr.Zero, 0, 0, Win32.PM_REMOVE))
                {
                    if (msg.message == Win32.WM_QUIT)
                    {
                        Log("Received WM_QUIT");
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
                        Log($"Frame {frameCount} rendered");
                    }
                }
                catch (Exception ex)
                {
                    Log($"Frame error: {ex.Message}");
                    // Continue running even if a frame fails
                }

                // Simple framerate cap ~60fps
                Thread.Sleep(16);
            }
            
            Log($"Message loop exited after {frameCount} frames");
        }
#else
        /// <summary>
        /// X11-specific message loop using the Window's ProcessMessages method
        /// </summary>
        private static void RunX11MessageLoop(Window window, IScene scene, ref double dto, ref double dtl)
        {
            bool running = true;
            int frameCount = 0;

            Log("Entering X11 message loop...");

            while (running)
            {
                // Process X11 events using the window's instance method
                if (!window.ProcessMessages())
                {
                    Log("ProcessMessages returned false, exiting loop");
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
                        Log($"Frame {frameCount} rendered");
                    }
                }
                catch (Exception ex)
                {
                    Log($"Frame error: {ex.Message}");
                    // Continue running even if a frame fails
                }

                // Simple framerate cap ~60fps
                Thread.Sleep(16);
            }

            Log($"X11 message loop exited after {frameCount} frames");
        }
#endif
    }
}