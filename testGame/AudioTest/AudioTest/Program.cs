using Angene.Common;
using Angene.Common.Settings;
using Angene.Essentials;
using Angene.Main;
using Angene.Platform;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using AudioTest;

namespace Game
{
    public static class Program
    {
        private static Engine? _engine;
        private static Settings? _settings;
        private static Window? _window;

        [UnmanagedCallersOnly]
        public static int Main(IntPtr args, int argc)
        {
            bool verbose = false;

            try
            {
                // --- Parse args ---
                if (args != IntPtr.Zero && argc > 0)
                {
                    unsafe
                    {
                        IntPtr* pArgs = (IntPtr*)args;
                        for (int i = 0; i < argc; i++)
                        {
                            var arg = Marshal.PtrToStringUni(pArgs[i]) ?? string.Empty;
                            if (arg == "--verbose") verbose = true;
                        }
                    }
                }

                // --- Engine init ---
                _engine = Engine.Instance;
                _engine.Init(verbose);
                _settings = _engine.SettingHandlerInstanced;

                Logger.LogInfo("AudioTest: Engine initialized.", LoggingTarget.MainConstructor);

                // --- Window ---
                var config = new WindowConfig();
                config.Title = "Angene | Audio Test";
                config.Width = 640;
                config.Height = 480;

                _window = new Window(config);

                Logger.LogInfo("AudioTest: Window created.", LoggingTarget.MainConstructor);

                // --- Scene ---
                AudioTestScene? scene = null;
                try
                {
                    scene = new AudioTestScene(_window);
                    scene.Initialize();
                    _window.SetScene(scene);
                }
                catch (Exception ex)
                {
                    Logger.LogCritical(
                        $"AudioTest: Scene init failed — {ex.Message}",
                        LoggingTarget.MainConstructor, ex);
                    return 1;
                }

                Logger.LogInfo(
                    "AudioTest: Scene loaded. Starting message loop.",
                    LoggingTarget.MainConstructor);

                // --- Message loop ---
                RunMessageLoop(_window);

                // --- Cleanup ---
                scene?.Cleanup();
                _window.Cleanup();
                Logger.LogInfo("AudioTest: Clean exit.", LoggingTarget.MainConstructor);

                return 0;
            }
            catch (Exception ex)
            {
                Logger.LogCritical(
                    $"AudioTest: FATAL — {ex.Message}",
                    LoggingTarget.MainConstructor, ex);
                return 1;
            }
        }

        private static void RunMessageLoop(Window window)
        {
            bool running = true;
            var lastFrame = DateTime.Now;

            while (running)
            {
                // Drain Win32 message queue
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

                // Tick and draw every loaded scene
                double dt = (DateTime.Now - lastFrame).TotalSeconds;
                lastFrame = DateTime.Now;

                foreach (var scene in window.Scenes)
                {
                    ScriptBinding.Lifecycle.Tick(scene, dt, EngineMode.Play);
                    ScriptBinding.Lifecycle.Draw(scene, EngineMode.Play);
                    scene?.Render();
                }

                // 60 fps cap
                Thread.Sleep(16);
            }
        }
    }
}