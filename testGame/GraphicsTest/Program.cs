using Angene.Common;
using Angene.Common.Settings;
using Angene.Essentials;
using Angene.Main;
using Angene.Platform;
using Angene.Windows;
using System;
using System.Runtime.InteropServices;
using System.Threading;

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

                _engine = Engine.Instance;
                _engine.Init(verbose);
                _settings = _engine.SettingHandlerInstanced;

                Logger.LogInfo("GraphicsTest: Engine initialized.", LoggingTarget.MainConstructor);

                var config = new WindowConfig();
                config.Title = "Angene | Graphics Test";
                config.Width = 640;
                config.Height = 480;

                _window = new Window(config);

                Logger.LogInfo("GraphicsTest: Window created.", LoggingTarget.MainConstructor);

                GraphicsTestScene? scene = null;
                try
                {
                    scene = new GraphicsTestScene(_window);
                    scene.Initialize();
                    _window.SetScene(scene);
                }
                catch (Exception ex)
                {
                    Logger.LogCritical(
                        $"GraphicsTest: Scene init failed — {ex.Message}",
                        LoggingTarget.MainConstructor, ex);
                    return 1;
                }

                Logger.LogInfo(
                    "GraphicsTest: Scene loaded. Starting message loop.",
                    LoggingTarget.MainConstructor);

                RunMessageLoop(_window);

                scene?.Cleanup();
                _window.Cleanup();
                Logger.LogInfo("GraphicsTest: Clean exit.", LoggingTarget.MainConstructor);

                return 0;
            }
            catch (Exception ex)
            {
                Logger.LogCritical(
                    $"GraphicsTest: FATAL — {ex.Message}",
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
#if WINDOWS
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
#endif

                if (!running) break;

                double dt = (DateTime.Now - lastFrame).TotalSeconds;
                lastFrame = DateTime.Now;

                foreach (var scene in window.Scenes)
                {
                    Lifecycle.ScriptBinding.Tick(scene, dt, EngineMode.Play);
                    Lifecycle.ScriptBinding.Draw(scene, EngineMode.Play);
                    scene?.Render();
                }

                Thread.Sleep(16);
            }
        }
    }
}
