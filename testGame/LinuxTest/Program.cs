using Angene.Common;
using Angene.Common.Settings;
using Angene.Essentials;
using Angene.Main;
using Angene.Platform;
using System;
using System.Collections.Generic;
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
            engine.Init(verbose); // scans this assembly for [Precompile] shaders (TestShaders.cs) and starts compiling them
            settings = engine.SettingHandlerInstanced;
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

                double dt = 0.0d;
                RunMessageLoop(ref dt);
                Logger.LogInfo("Cleanup complete.", LoggingTarget.Engine);
            }
            catch (Exception e)
            {
                Logger.LogCritical($"Error in main constructor: {e.Message}", LoggingTarget.MainConstructor, e, true);
            }
        }

        private static void RunMessageLoop(ref double dt)
        {
            bool running = true;

            while (running)
            {
                if (!running) break;

                dt = (DateTime.Now - lastFrame).TotalSeconds;
                lastFrame = DateTime.Now;

                Lifecycle.ScriptBinding.Tick(new EmptyScene(), dt, EngineMode.Play);
                Lifecycle.ScriptBinding.Draw(new EmptyScene(), EngineMode.Play);
            }
        }
    }

    public class EmptyScene : IScene
    {
        public object Instance => this;

        public List<Entity> Entities => new List<Entity>();

        public string Name => "EmptyScene";

        public void Cleanup() { }

        public void Initialize()
        {
            Logger.LogError("EmptyScene.Initialize() called.", LoggingTarget.MasterScene);
        }

        public void OnMessage(nint msgPtr) { }

        public void Render() { }
    }
}
