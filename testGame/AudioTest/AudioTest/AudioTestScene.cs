using Angene.Common;
using Angene.Essentials;
using Angene.Globals;
using Angene.Main;
using Angene.Platform;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AudioTest
{
    internal class AudioTestScene : IScene
    {
        public object Instance { get; private set; }
        public List<Entity> entities { get; private set; } = new();
        public Window _window;

        // Not using 3D rendering
        public IRenderer3D? Renderer3D => null;

        internal AudioTestScene(Window window)
        {
            _window = window;
            Instance = this;
        }

        public void Initialize()
        {
            entities = new List<Entity>();

            Logger.LogInfo("AudioTestScene: Initializing.", LoggingTarget.MasterScene);

            // Create a single entity to host the audio test script
            var audioEntity = new Entity(0, 0, "AudioTester");

            // Add the test script and initialize it
            var script = audioEntity.AddScript<AudioTestScript>();

            // Enable the entity — this registers it with the lifecycle
            // and triggers Awake/OnEnable/Start in order
            audioEntity.SetEnabled(true);

            entities.Add(audioEntity);

            Logger.LogInfo(
                "AudioTestScene: Entity 'AudioTester' created with AudioTestScript.",
                LoggingTarget.MasterScene);
        }

        public void OnMessage(IntPtr msgPtr)
        {
            if (msgPtr == IntPtr.Zero) return;

#if WINDOWS
            var msg = Marshal.PtrToStructure<Win32.MSG>(msgPtr);

            // Allow ESC to close the window early
            if (msg.message == (uint)WM.KEYDOWN && (int)msg.wParam == 0x1B)
            {
                Logger.LogInfo(
                    "AudioTestScene: ESC pressed, requesting close.",
                    LoggingTarget.MasterScene);
                Win32.PostQuitMessage(0);
            }

            if (msg.message == Win32.WM_CLOSE)
            {
                Logger.LogInfo(
                    "AudioTestScene: WM_CLOSE received.",
                    LoggingTarget.MasterScene);
            }
#else
            Logger.LogError(
                "AudioTestScene: Non-Windows platforms not supported yet.",
                LoggingTarget.MasterScene);
            throw new AngeneException("Platform incompatibility.");
#endif
        }

        public void Render()
        {
            // Nothing to render — this is an audio-only test
        }

        public List<Entity> GetEntities() => entities;

        public void Cleanup()
        {
            Logger.LogInfo("AudioTestScene: Cleanup.", LoggingTarget.MasterScene);
            foreach (var e in entities)
                e.Destroy();
            entities.Clear();
        }
    }
}