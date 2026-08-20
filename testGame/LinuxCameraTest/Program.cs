using Angene.Common;
using Angene.Common.Settings;
using Angene.Essentials;
using Angene.Input;
using Angene.Main;
using Angene.Platform;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using static Angene.Vulkan.Interop.Enumerators;

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
            engine.Init(new Types.AppInfo("CameraTest Angene", 0.1f, "Aerial", "Aerial", VkPresentModeKHR.VK_PRESENT_MODE_IMMEDIATE_KHR), verbose); // scans this assembly for [Precompile] shaders (Shaders.cs) and starts compiling them
            settings = engine.settingsInstance;
        }
    }

    public class Program
    {
        public static KeyDetection _keyDetection = new KeyDetection();
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

                Logger.LogImportant("Waiting for shader precompilation to finish...", LoggingTarget.MainGame);
                while (Engine.Instance.IsCompilingShaders)
                {
                    foreach (Window window in Engine.Instance.OpenWindows)
                        window.RenderFrame();
                }
                Logger.LogImportant("Shader precompilation finished.", LoggingTarget.MainGame);

                double dt = 0.0d;
                WindowConfig config = new WindowConfig()
                {
                    Width = 1280,
                    Height = 720,
                    Title = "Angene Camera Test",
                    renderMode = Angene.Graphics.RenderType.Vulkan
                };
                Window win = new Window(config);

                string materialsPackagePath = Path.Combine(AppContext.BaseDirectory, "Assets", "CameraMaterials.angpkg");
                var scene = new Game.Scenes.CameraTestScene(win, materialsPackagePath);
                win.SetScene(scene);
                Logger.LogDebug($"OpenWindows count after creation: {Engine.Instance.OpenWindows.Count}", LoggingTarget.Engine);

                RunMessageLoop(ref dt, win, scene);
                Logger.LogInfo("Cleanup complete.", LoggingTarget.Engine);
            }
            catch (Exception e)
            {
                Logger.LogCritical($"Error in main constructor: {e.Message}", LoggingTarget.MainConstructor, e, true);
            }
        }

        private static void RunMessageLoop(ref double dt, Window win, IScene scene)
        {
            while (!Engine.Instance.ShouldShutdown)
            {
                bool a = win.ProcessMessages(win.Handle);

                dt = (DateTime.Now - lastFrame).TotalSeconds;
                lastFrame = DateTime.Now;

                Lifecycle.ScriptBinding.Tick(scene, dt, EngineMode.Play);
                Lifecycle.ScriptBinding.Draw(scene, EngineMode.Play);
                win.RenderFrame();
            }
            win.Cleanup();
            Lifecycle.ScriptBinding.ShutdownEngine();
        }
    }
}
