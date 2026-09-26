using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Angene.Common;
using Angene.Common.Settings;
using Angene.Essentials;
using Angene.Vulkan.Interop;

namespace Angene.Main;

public class EntryPoint
{
    public static EntryPoint Instance = new EntryPoint();
    public class Instances
    {
        public Engine engine { get; internal set; }
        public Settings settings { get; internal set; }
        public bool verbose { get; }

        public void MakeInstances(bool verbose, Types.AppInfo appInfo)
        {
            engine = Engine.Instance;
            engine.Init(appInfo, verbose, callingAssembly: Assembly.GetCallingAssembly());
            settings = engine.settingsInstance;
        }
    }

    public static void RunMessageLoop(ref double dt, ref DateTime lastFrame, Window[] wins)
    {
        while (!Engine.Instance.ShouldShutdown)
        {
            try
            {
                foreach (Window win in wins)
                {
                    bool a = win.ProcessMessages(win.Handle);
                    dt = (DateTime.Now - lastFrame).TotalSeconds;
                    lastFrame = DateTime.Now;

                    foreach (IScene scene in win.Scenes)
                    {
                        Lifecycle.ScriptBinding.Tick(scene, dt, EngineMode.Play);
                        Lifecycle.ScriptBinding.Draw(scene, EngineMode.Play);
                    }

                    win.RenderFrame();
                }
            }
            catch (Exception e)
            {
                Logger.LogCritical($"Failure while running window message loop: {e.ToString()}", LoggingTarget.Engine, e, true);
            }
        }
        foreach (Window win in wins) win.Cleanup();
        Lifecycle.ScriptBinding.ShutdownEngine();
    }
}