using AngeneEditor.Documents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngeneEditor.Commands
{
    public sealed class AddEntityCommand : IEditorCommand
    {
        private readonly SceneDocument _scene;
        private readonly SceneEntity _entity;
        private readonly int? _index;

        public AddEntityCommand(SceneDocument scene, SceneEntity entity, int? index = null)
        {
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
            _entity = entity?.DeepClone() ?? throw new ArgumentNullException(nameof(entity));
            _index = index;
        }

        public string Name => $"Create {_entity.Name}";
        public Guid EntityId => _entity.Id;

        public void Execute()
        {
            if (_scene.FindEntity(_entity.Id) != null)
                throw new InvalidOperationException($"Entity '{_entity.Id}' already exists.");

            if (_entity.ParentId is Guid parentId && _scene.FindEntity(parentId) == null)
                throw new InvalidOperationException($"Parent entity '{parentId}' does not exist.");

            int insertAt = Math.Clamp(_index ?? _scene.Entities.Count, 0, _scene.Entities.Count);
            _scene.Entities.Insert(insertAt, _entity.DeepClone());
        }

        public void Undo()
        {
            int index = _scene.Entities.FindIndex(entity => entity.Id == _entity.Id);
            if (index >= 0)
                _scene.Entities.RemoveAt(index);
        }
    }

    public sealed class DeleteEntityCommand : IEditorCommand
    {
        private readonly SceneDocument _scene;
        private readonly Guid _entityId;
        private List<(int Index, SceneEntity Entity)>? _removed;

        public DeleteEntityCommand(SceneDocument scene, Guid entityId)
        {
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
            _entityId = entityId;
        }

        public string Name => "Delete entity";

        public void Execute()
        {
            if (_removed == null)
            {
                var ids = new HashSet<Guid> { _entityId };
                bool added;
                do
                {
                    added = false;
                    foreach (SceneEntity entity in _scene.Entities)
                    {
                        if (entity.ParentId is Guid parentId &&
                            ids.Contains(parentId) &&
                            ids.Add(entity.Id))
                        {
                            added = true;
                        }
                    }
                } while (added);

                _removed = _scene.Entities
                    .Select((entity, index) => (Index: index, Entity: entity))
                    .Where(item => ids.Contains(item.Entity.Id))
                    .Select(item => (item.Index, item.Entity.DeepClone()))
                    .ToList();

                if (_removed.Count == 0)
                    throw new InvalidOperationException($"Entity '{_entityId}' does not exist.");
            }

            var removedIds = _removed.Select(item => item.Entity.Id).ToHashSet();
            _scene.Entities.RemoveAll(entity => removedIds.Contains(entity.Id));
        }

        public void Undo()
        {
            if (_removed == null)
                return;

            foreach ((int index, SceneEntity entity) in _removed.OrderBy(item => item.Index))
            {
                int insertAt = Math.Clamp(index, 0, _scene.Entities.Count);
                _scene.Entities.Insert(insertAt, entity.DeepClone());
            }
        }
    }

    public sealed class RenameEntityCommand : IEditorCommand
    {
        private readonly SceneDocument _scene;
        private readonly Guid _entityId;
        private readonly string _newName;
        private string? _oldName;

        public RenameEntityCommand(SceneDocument scene, Guid entityId, string newName)
        {
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
            _entityId = entityId;
            _newName = string.IsNullOrWhiteSpace(newName)
                ? throw new ArgumentException("Entity name cannot be empty.", nameof(newName))
                : newName.Trim();
        }

        public string Name => "Rename entity";

        public void Execute()
        {
            SceneEntity entity = RequireEntity();
            _oldName ??= entity.Name;
            entity.Name = _newName;
        }

        public void Undo()
        {
            if (_oldName != null)
                RequireEntity().Name = _oldName;
        }

        private SceneEntity RequireEntity()
            => _scene.FindEntity(_entityId)
               ?? throw new InvalidOperationException($"Entity '{_entityId}' does not exist.");
    }

    public sealed class SetTransformCommand : IEditorCommand
    {
        private readonly SceneDocument _scene;
        private readonly Guid _entityId;
        private readonly TransformDocument _newTransform;
        private TransformDocument? _oldTransform;

        public SetTransformCommand(
            SceneDocument scene,
            Guid entityId,
            TransformDocument newTransform)
        {
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
            _entityId = entityId;
            _newTransform = newTransform?.DeepClone()
                ?? throw new ArgumentNullException(nameof(newTransform));
        }

        public string Name => "Change transform";

        public void Execute()
        {
            SceneEntity entity = RequireEntity();
            _oldTransform ??= entity.Transform.DeepClone();
            entity.Transform = _newTransform.DeepClone();
        }

        public void Undo()
        {
            if (_oldTransform != null)
                RequireEntity().Transform = _oldTransform.DeepClone();
        }

        private SceneEntity RequireEntity()
            => _scene.FindEntity(_entityId)
               ?? throw new InvalidOperationException($"Entity '{_entityId}' does not exist.");
    }

    public sealed class ReparentEntityCommand : IEditorCommand
    {
        private readonly SceneDocument _scene;
        private readonly Guid _entityId;
        private readonly Guid? _newParentId;
        private Guid? _oldParentId;
        private bool _captured;

        public ReparentEntityCommand(SceneDocument scene, Guid entityId, Guid? newParentId)
        {
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
            _entityId = entityId;
            _newParentId = newParentId;
        }

        public string Name => "Reparent entity";

        public void Execute()
        {
            SceneEntity entity = RequireEntity(_entityId);
            if (!_captured)
            {
                _oldParentId = entity.ParentId;
                _captured = true;
            }

            ValidateParent();
            entity.ParentId = _newParentId;
        }

        public void Undo() => RequireEntity(_entityId).ParentId = _oldParentId;

        private void ValidateParent()
        {
            if (_newParentId == null)
                return;

            if (_newParentId == _entityId)
                throw new InvalidOperationException("An entity cannot parent itself.");

            SceneEntity? current = RequireEntity(_newParentId.Value);
            while (current != null)
            {
                if (current.Id == _entityId)
                    throw new InvalidOperationException("Reparenting would create a hierarchy cycle.");

                current = current.ParentId is Guid parentId
                    ? _scene.FindEntity(parentId)
                    : null;
            }
        }

        private SceneEntity RequireEntity(Guid id)
            => _scene.FindEntity(id)
               ?? throw new InvalidOperationException($"Entity '{id}' does not exist.");
    }
}
