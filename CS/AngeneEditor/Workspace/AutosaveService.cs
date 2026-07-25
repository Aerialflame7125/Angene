using AngeneEditor.Project;
using System;
using System.Windows.Forms;

namespace AngeneEditor.Workspace
{
    public sealed class AutosaveService : IDisposable
    {
        private readonly Timer _timer;
        private readonly ProjectManager _projectManager;

        public AutosaveService(
            ProjectManager projectManager,
            TimeSpan? interval = null)
        {
            _projectManager = projectManager;
            TimeSpan autosaveInterval = interval ?? TimeSpan.FromSeconds(60);
            _timer = new Timer
            {
                Interval = Math.Max(1000, (int)autosaveInterval.TotalMilliseconds),
            };
            _timer.Tick += OnTick;
        }

        public event Action? SnapshotSaved;
        public event Action<Exception>? SnapshotFailed;

        public void Start() => _timer.Start();

        public void Stop() => _timer.Stop();

        public bool SaveNow()
        {
            try
            {
                bool saved = _projectManager.SaveRecoverySnapshot();
                if (saved)
                    SnapshotSaved?.Invoke();
                return saved;
            }
            catch (Exception error)
            {
                SnapshotFailed?.Invoke(error);
                return false;
            }
        }

        private void OnTick(object? sender, EventArgs e)
        {
            SaveNow();
        }

        public void Dispose()
        {
            _timer.Stop();
            _timer.Tick -= OnTick;
            _timer.Dispose();
        }
    }
}
