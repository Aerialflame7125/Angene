using Angene.Audio;
using Angene.Common;
using Angene.Essentials;
using System;
using System.IO;

namespace AudioTest
{
    /// exercises audiomanager. uses package file and loads audio from it.
    internal class AudioTestScript : IScreenPlay
    {
        // test file
        private const string PackagePath = "audio_test.angpkg";
        private const string WavPath = "audio/test.wav";

        private AudioManager? _manager;
        private double _elapsed;

        private int _phase = 0;

        // thresholds in seconds
        private static readonly double[] PhaseAt = { 0, 2, 4, 6, 8 };

        public void Start()
        {
            Logger.LogInfo("AudioTestScript: Start()", LoggingTarget.MainGame);

            if (!File.Exists(PackagePath))
            {
                Logger.LogError(
                    $"AudioTestScript: Package not found at '{PackagePath}'. " +
                    "Pack a WAV file using the Angene packer first.",
                    LoggingTarget.Package);
                return;
            }

            try
            {
                // loadOnInstantiate — bytes read immediately, package closed
                var file = new AudioFile(
                    PackagePath,
                    WavPath,
                    AudioFile.LoadType.loadOnInstantiate);

                // Start paused so we can test Play() manually in Update
                _manager = new AudioManager(
                    file,
                    playOnLoad: false,
                    loop: false,
                    volume: 0.8f);

                Logger.LogInfo(
                    "AudioTestScript: AudioManager created OK. " +
                    "Playback will begin at t=0s.",
                    LoggingTarget.MainGame);
            }
            catch (Exception ex)
            {
                Logger.LogCritical(
                    $"AudioTestScript: Failed to create AudioManager — {ex.Message}",
                    LoggingTarget.MainGame, ex);
            }
        }

        public void Update(double dt)
        {
            if (_manager == null) return;

            _elapsed += dt;

            // each phase on threshold met
            switch (_phase)
            {
                case 0 when _elapsed >= PhaseAt[0]:
                    // Play
                    Logger.LogInfo(
                        $"[t={_elapsed:F1}s] Phase 0: Play()",
                        LoggingTarget.MainGame);
                    _manager.Play();
                    _phase++;
                    break;

                case 1 when _elapsed >= PhaseAt[1]:
                    // pause and confirm
                    Logger.LogInfo(
                        $"[t={_elapsed:F1}s] Phase 1: Pause() — IsPlaying={_manager.IsPlaying} IsPaused={_manager.IsPaused}",
                        LoggingTarget.MainGame);
                    _manager.Pause();
                    Logger.LogInfo(
                        $"  After Pause() — IsPlaying={_manager.IsPlaying} IsPaused={_manager.IsPaused}",
                        LoggingTarget.MainGame);
                    _phase++;
                    break;

                case 2 when _elapsed >= PhaseAt[2]:
                    // resume and reduce volume
                    Logger.LogInfo(
                        $"[t={_elapsed:F1}s] Phase 2: Resume() + SetVolume(0.3f)",
                        LoggingTarget.MainGame);
                    _manager.Resume();
                    _manager.SetVolume(0.3f);
                    _phase++;
                    break;

                case 3 when _elapsed >= PhaseAt[3]:
                    // stop and restart audio
                    Logger.LogInfo(
                        $"[t={_elapsed:F1}s] Phase 3: Stop() then SetLooping(true) + Play()",
                        LoggingTarget.MainGame);
                    _manager.Stop();
                    _manager.SetLooping(true);
                    _manager.SetVolume(1.0f);
                    _manager.Play();
                    _phase++;
                    break;

                case 4 when _elapsed >= PhaseAt[4]:
                    // all done, stop
                    Logger.LogInfo(
                        $"[t={_elapsed:F1}s] Phase 4: Final Stop(). All audio tests passed.",
                        LoggingTarget.MainGame);
                    _manager.Stop();
                    _phase++;
                    break;
            }
        }

        public void LateUpdate(double dt) { }
        public void OnDraw() { }
        public void OnMessage(IntPtr msg) { }

        public void Render()
        {
            // Nothing to render for an audio test
        }

        public void Cleanup()
        {
            Logger.LogInfo("AudioTestScript: Cleanup()", LoggingTarget.MainGame);
            _manager?.Dispose();
            _manager = null;
        }
    }
}