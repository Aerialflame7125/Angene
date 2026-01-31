using System;
using System.Threading;
using Angene.Main;
using Angene.Platform;

namespace Game
{
    /// <summary>
    /// Entry point for CLR hosting.
    /// CRITICAL: The Main method MUST have this EXACT signature:
    ///   public static int Main(string args)
    /// 
    /// Note: It's "string args" (singular), NOT "string[] args" (array)
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// CLR host entry point.
        /// DO NOT CHANGE THIS SIGNATURE - it must be exactly:
        ///   public static int Main(string args)
        /// </summary>
        public static int Main(string args)
        {
            try
            {
                Console.WriteLine("========================================");
                Console.WriteLine("  Angene Test Game");
                Console.WriteLine("  Starting from native host...");
                Console.WriteLine($"  Platform: {PlatformDetection.CurrentPlatform}");
                Console.WriteLine("========================================\n");

                // Parse args if needed (args is a single string, not an array)
                // For example: args might be "arg1 arg2 arg3"
                // You can split it: var argArray = args?.Split(' ');

                if (!string.IsNullOrEmpty(args))
                {
                    Console.WriteLine($"Arguments received: {args}\n");
                }

                // Call your game logic
                RunGame();

                Console.WriteLine("\n========================================");
                Console.WriteLine("  Game completed successfully");
                Console.WriteLine("========================================");

                return 0; // Success
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n========================================");
                Console.WriteLine("  FATAL ERROR");
                Console.WriteLine("========================================");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"\nStack Trace:\n{ex.StackTrace}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"\nInner Exception: {ex.InnerException.Message}");
                }

                Console.ResetColor();
                return 1; // Error
            }
        }

        /// <summary>
        /// Your actual game logic - now platform-agnostic!
        /// </summary>
        private static void RunGame()
        {
            double dto = 0.0d;
            double dtl = 0.0d;

            Console.WriteLine($"Detected platform: {PlatformDetection.CurrentPlatform}");
            Console.WriteLine("Creating game window...");
            var window = new Window("Angene - Test Game", 800, 600, use3D: false);

            Console.WriteLine("Initializing scene...");
            var scene = new PackageTest(window);
            window.SetScene(scene);

            Console.WriteLine("Starting game...\n");
            scene.Start();

            // Main game loop - platform-specific message handling
#if WINDOWS
            Console.WriteLine("Using Windows message loop");
            RunWindowsMessageLoop(window, scene, ref dto, ref dtl);
#else
            Console.WriteLine("Using X11 message loop");
            RunX11MessageLoop(window, scene, ref dto, ref dtl);
#endif

            // Cleanup
            Console.WriteLine("\nCleaning up...");
            window.Cleanup();
            Console.WriteLine("Cleanup complete.");
        }

#if WINDOWS
        /// <summary>
        /// Windows-specific message loop using Win32 APIs
        /// </summary>
        private static void RunWindowsMessageLoop(Window window, IScene scene, ref double dto, ref double dtl)
        {
            bool running = true;
            while (running)
            {
                Win32.MSG msg;
                while (Win32.PeekMessageW(out msg, IntPtr.Zero, 0, 0, Win32.PM_REMOVE))
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

                // Update / Draw
                try
                {
                    scene.Update(dto);
                    scene.LateUpdate(dtl);
                    scene.OnDraw();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Frame error: {ex.Message}");
                    // Continue running even if a frame fails
                }

                // Simple framerate cap ~60fps
                Thread.Sleep(16);
            }
        }
#else
        /// <summary>
        /// X11-specific message loop using the Window's ProcessMessages method
        /// </summary>
        private static void RunX11MessageLoop(Window window, IScene scene, ref double dto, ref double dtl)
        {
            bool running = true;
            while (running)
            {
                // Process X11 events using the window's instance method
                if (!window.ProcessMessages())
                {
                    running = false;
                    break;
                }

                // Update / Draw
                try
                {
                    scene.Update(dto);
                    scene.LateUpdate(dtl);
                    scene.OnDraw();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Frame error: {ex.Message}");
                    // Continue running even if a frame fails
                }

                // Simple framerate cap ~60fps
                Thread.Sleep(16);
            }
        }
#endif
    }
}