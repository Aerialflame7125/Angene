using Angene.Common;
using Angene.Essentials;
using Angene.Globals;
using Angene.Main;
using Angene.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class MathTestScene : IScene
    {
        public object Instance { get; private set; }
        public List<Entity> entities { get; private set; } = new();
        public Window _window;

        // No 3D renderer needed — math test is headless
        public IRenderer3D? Renderer3D => null;

        internal MathTestScene(Window window)
        {
            _window = window;
            Instance = this;
        }

        public void Initialize()
        {
            entities = new List<Entity>();

            Logger.LogInfo("MathTestScene: Initializing.", LoggingTarget.MasterScene);

            var mathEntity = new Entity(0, 0, "MathTester");
            mathEntity.AddScript<MathTestScript>();
            mathEntity.SetEnabled(true);

            entities.Add(mathEntity);

            Logger.LogInfo(
                "MathTestScene: Entity 'MathTester' created with MathTestScript.",
                LoggingTarget.MasterScene);
        }

        public void OnMessage(IntPtr msgPtr)
        {
            if (msgPtr == IntPtr.Zero) return;

#if WINDOWS
            var msg = Marshal.PtrToStructure<Win32.MSG>(msgPtr);

            if (msg.message == (uint)WM.KEYDOWN && (int)msg.wParam == 0x1B)
            {
                Logger.LogInfo(
                    "MathTestScene: ESC pressed, requesting close.",
                    LoggingTarget.MasterScene);
                Win32.PostQuitMessage(0);
            }

            if (msg.message == Win32.WM_CLOSE)
            {
                Logger.LogInfo("MathTestScene: WM_CLOSE received.", LoggingTarget.MasterScene);
            }
#else
            Logger.LogError(
                "MathTestScene: Non-Windows platforms not supported yet.",
                LoggingTarget.MasterScene);
            throw new AngeneException("Platform incompatibility.");
#endif
        }

        public void Render()
        {
            // Math tests are headless — all output goes through Logger.
        }

        public List<Entity> GetEntities() => entities;

        public void Cleanup()
        {
            Logger.LogInfo("MathTestScene: Cleanup.", LoggingTarget.MasterScene);
            foreach (var e in entities)
                e.Destroy();
            entities.Clear();
        }
    }
}
