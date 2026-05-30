using Angene.Common;
using Angene.Essentials;
using Angene.Globals;
using Angene.Main;
using Angene.Windows;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Game
{
    internal class GraphicsTestScene : IScene
    {
        public object Instance { get; private set; }
        public List<Entity> entities { get; private set; } = new();
        public Window _window;

        public IRenderer3D? Renderer3D => null;

        internal GraphicsTestScene(Window window)
        {
            _window = window;
            Instance = this;
        }

        public void Initialize()
        {
            entities = new List<Entity>();

            Logger.LogInfo("GraphicsTestScene: Initializing.", LoggingTarget.MasterScene);

            var GraphicsEntity = new Entity(0, 0, "GraphicsTester");
            GraphicsEntity.AddScript<GraphicsTestScript>();
            GraphicsEntity.SetEnabled(true);

            entities.Add(GraphicsEntity);

            Logger.LogInfo(
                "GraphicsTestScene: Entity 'GraphicsTester' created with GraphicsTestScript.",
                LoggingTarget.MasterScene);
        }

        public void OnMessage(IntPtr msgPtr)
        {
            if (msgPtr == IntPtr.Zero) return;

            var msg = Marshal.PtrToStructure<Win32.MSG>(msgPtr);

            if (msg.message == (uint)WM.KEYDOWN && (int)msg.wParam == 0x1B)
            {
                Logger.LogInfo(
                    "GraphicsTestScene: ESC pressed, requesting close.",
                    LoggingTarget.MasterScene);
                Win32.PostQuitMessage(0);
            }

            if (msg.message == (uint)WM.CLOSE)
            {
                Logger.LogInfo("GraphicsTestScene: WM_CLOSE received.", LoggingTarget.MasterScene);
            }
        }

        public void Render()
        {
            // Graphics tests are headless — all output goes through Logger.
        }

        public List<Entity> GetEntities() => entities;

        public void Cleanup()
        {
            Logger.LogInfo("GraphicsTestScene: Cleanup.", LoggingTarget.MasterScene);
            foreach (var e in entities)
                e.Destroy();
            entities.Clear();
        }
    }
}
