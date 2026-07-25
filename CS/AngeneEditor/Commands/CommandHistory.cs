using System;
using System.Collections.Generic;
using System.Linq;

namespace AngeneEditor.Commands
{
    public interface IEditorCommand
    {
        string Name { get; }
        void Execute();
        void Undo();
    }

    public sealed class CommandHistory
    {
        private readonly Stack<IEditorCommand> _undo = new();
        private readonly Stack<IEditorCommand> _redo = new();
        private readonly int _capacity;

        public CommandHistory(int capacity = 200)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            _capacity = capacity;
        }

        public event Action? Changed;

        public bool CanUndo => _undo.Count > 0;
        public bool CanRedo => _redo.Count > 0;
        public string? UndoName => CanUndo ? _undo.Peek().Name : null;
        public string? RedoName => CanRedo ? _redo.Peek().Name : null;

        public void Execute(IEditorCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);
            command.Execute();
            _undo.Push(command);
            _redo.Clear();
            TrimUndoStack();
            Changed?.Invoke();
        }

        public void Undo()
        {
            if (!CanUndo)
                return;

            IEditorCommand command = _undo.Pop();
            command.Undo();
            _redo.Push(command);
            Changed?.Invoke();
        }

        public void Redo()
        {
            if (!CanRedo)
                return;

            IEditorCommand command = _redo.Pop();
            command.Execute();
            _undo.Push(command);
            Changed?.Invoke();
        }

        public void Clear()
        {
            _undo.Clear();
            _redo.Clear();
            Changed?.Invoke();
        }

        private void TrimUndoStack()
        {
            if (_undo.Count <= _capacity)
                return;

            IEditorCommand[] newestFirst = _undo.ToArray();
            _undo.Clear();
            for (int index = Math.Min(_capacity, newestFirst.Length) - 1; index >= 0; index--)
                _undo.Push(newestFirst[index]);
        }
    }

    public sealed class CompositeEditorCommand : IEditorCommand
    {
        private readonly IReadOnlyList<IEditorCommand> _commands;

        public CompositeEditorCommand(string name, IEnumerable<IEditorCommand> commands)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Composite command" : name;
            _commands = commands?.ToArray()
                ?? throw new ArgumentNullException(nameof(commands));
        }

        public string Name { get; }

        public void Execute()
        {
            foreach (IEditorCommand command in _commands)
                command.Execute();
        }

        public void Undo()
        {
            for (int index = _commands.Count - 1; index >= 0; index--)
                _commands[index].Undo();
        }
    }
}
