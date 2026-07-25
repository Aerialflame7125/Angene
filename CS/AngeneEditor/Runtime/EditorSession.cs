using AngeneEditor.Commands;
using AngeneEditor.Documents;
using System;

namespace AngeneEditor.Runtime
{
    public enum EditorSessionMode
    {
        Edit,
        Play,
        Paused,
    }

    public sealed class EditorSession
    {
        private SceneDocument _editScene;
        private SceneDocument? _playScene;

        public EditorSession(SceneDocument scene)
        {
            _editScene = scene?.DeepClone() ?? throw new ArgumentNullException(nameof(scene));
            _editScene.EnsureValid();
            History = new CommandHistory();
        }

        public event Action<EditorSessionMode>? ModeChanged;
        public event Action? SceneChanged;
        public event Action<SceneDocument>? StepRequested;

        public CommandHistory History { get; }
        public EditorSessionMode Mode { get; private set; } = EditorSessionMode.Edit;
        public bool IsDirty { get; private set; }
        public SceneDocument EditScene => _editScene;
        public SceneDocument ActiveScene => _playScene ?? _editScene;

        public void Execute(IEditorCommand command)
        {
            EnsureEditMode();
            History.Execute(command);
            IsDirty = true;
            SceneChanged?.Invoke();
        }

        public void Undo()
        {
            EnsureEditMode();
            if (!History.CanUndo)
                return;

            History.Undo();
            IsDirty = true;
            SceneChanged?.Invoke();
        }

        public void Redo()
        {
            EnsureEditMode();
            if (!History.CanRedo)
                return;

            History.Redo();
            IsDirty = true;
            SceneChanged?.Invoke();
        }

        public void EnterPlayMode()
        {
            if (Mode != EditorSessionMode.Edit)
                return;

            _editScene.EnsureValid();
            _playScene = _editScene.DeepClone();
            SetMode(EditorSessionMode.Play);
            SceneChanged?.Invoke();
        }

        public void Pause()
        {
            if (Mode == EditorSessionMode.Play)
                SetMode(EditorSessionMode.Paused);
        }

        public void Resume()
        {
            if (Mode == EditorSessionMode.Paused)
                SetMode(EditorSessionMode.Play);
        }

        public void Step()
        {
            if (Mode != EditorSessionMode.Paused || _playScene == null)
                throw new InvalidOperationException("Step is only available while play mode is paused.");

            StepRequested?.Invoke(_playScene);
        }

        public void Stop()
        {
            if (Mode == EditorSessionMode.Edit)
                return;

            _playScene = null;
            SetMode(EditorSessionMode.Edit);
            SceneChanged?.Invoke();
        }

        public void ReplaceEditScene(SceneDocument scene)
        {
            EnsureEditMode();
            _editScene = scene?.DeepClone() ?? throw new ArgumentNullException(nameof(scene));
            _editScene.EnsureValid();
            History.Clear();
            IsDirty = false;
            SceneChanged?.Invoke();
        }

        public void MarkSaved() => IsDirty = false;

        private void EnsureEditMode()
        {
            if (Mode != EditorSessionMode.Edit)
                throw new InvalidOperationException("Edit-time commands are disabled during play mode.");
        }

        private void SetMode(EditorSessionMode mode)
        {
            Mode = mode;
            ModeChanged?.Invoke(mode);
        }
    }
}
