using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace AngeneEditor.Documents
{
    public sealed class SceneDocument
    {
        public const int CurrentSchemaVersion = 1;

        public int SchemaVersion { get; set; } = CurrentSchemaVersion;
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "Main";
        public DateTimeOffset ModifiedUtc { get; set; } = DateTimeOffset.UtcNow;
        public SceneSettings Settings { get; set; } = new();
        public List<SceneEntity> Entities { get; set; } = new();

        public SceneEntity? FindEntity(Guid id)
            => Entities.FirstOrDefault(entity => entity.Id == id);

        public IReadOnlyList<SceneEntity> GetRootEntities()
            => Entities.Where(entity => entity.ParentId == null).ToArray();

        public IReadOnlyList<SceneEntity> GetChildren(Guid parentId)
            => Entities.Where(entity => entity.ParentId == parentId).ToArray();

        public SceneDocument DeepClone()
        {
            return new SceneDocument
            {
                SchemaVersion = SchemaVersion,
                Id = Id,
                Name = Name,
                ModifiedUtc = ModifiedUtc,
                Settings = Settings.DeepClone(),
                Entities = Entities.Select(entity => entity.DeepClone()).ToList(),
            };
        }

        public IReadOnlyList<string> Validate()
        {
            var errors = new List<string>();

            if (SchemaVersion <= 0 || SchemaVersion > CurrentSchemaVersion)
                errors.Add($"Unsupported scene schema version {SchemaVersion}.");

            if (Id == Guid.Empty)
                errors.Add("Scene ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(Name))
                errors.Add("Scene name cannot be empty.");

            var entityIds = new HashSet<Guid>();
            foreach (SceneEntity entity in Entities)
            {
                if (entity.Id == Guid.Empty)
                    errors.Add($"Entity '{entity.Name}' has an empty ID.");
                else if (!entityIds.Add(entity.Id))
                    errors.Add($"Duplicate entity ID '{entity.Id}'.");

                if (string.IsNullOrWhiteSpace(entity.Name))
                    errors.Add($"Entity '{entity.Id}' has an empty name.");

                if (entity.ParentId == entity.Id)
                    errors.Add($"Entity '{entity.Name}' cannot parent itself.");

                var componentIds = new HashSet<Guid>();
                foreach (SceneComponent component in entity.Components)
                {
                    if (component.Id == Guid.Empty)
                        errors.Add($"Component on '{entity.Name}' has an empty ID.");
                    else if (!componentIds.Add(component.Id))
                        errors.Add($"Entity '{entity.Name}' has duplicate component ID '{component.Id}'.");

                    if (string.IsNullOrWhiteSpace(component.Type))
                        errors.Add($"Component '{component.Id}' on '{entity.Name}' has no type.");
                }
            }

            foreach (SceneEntity entity in Entities)
            {
                if (entity.ParentId is Guid parentId && !entityIds.Contains(parentId))
                    errors.Add($"Entity '{entity.Name}' references missing parent '{parentId}'.");
            }

            DetectHierarchyCycles(errors);
            return errors;
        }

        public void EnsureValid()
        {
            IReadOnlyList<string> errors = Validate();
            if (errors.Count > 0)
                throw new SceneDocumentValidationException(errors);
        }

        private void DetectHierarchyCycles(List<string> errors)
        {
            var byId = Entities
                .Where(entity => entity.Id != Guid.Empty)
                .GroupBy(entity => entity.Id)
                .ToDictionary(group => group.Key, group => group.First());

            foreach (SceneEntity origin in Entities)
            {
                var visited = new HashSet<Guid>();
                SceneEntity? current = origin;

                while (current?.ParentId is Guid parentId &&
                       byId.TryGetValue(parentId, out SceneEntity? parent))
                {
                    if (!visited.Add(parentId))
                    {
                        errors.Add($"Hierarchy cycle detected at entity '{origin.Name}'.");
                        break;
                    }

                    current = parent;
                }
            }
        }
    }

    public sealed class SceneSettings
    {
        public SceneColor Background { get; set; } = new(24, 26, 32, 255);
        public float GridSize { get; set; } = 16f;
        public bool GridVisible { get; set; } = true;
        public bool SnapEnabled { get; set; }

        public SceneSettings DeepClone()
        {
            return new SceneSettings
            {
                Background = Background.DeepClone(),
                GridSize = GridSize,
                GridVisible = GridVisible,
                SnapEnabled = SnapEnabled,
            };
        }
    }

    public sealed class SceneEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "Entity";
        public bool Enabled { get; set; } = true;
        public Guid? ParentId { get; set; }
        public TransformDocument Transform { get; set; } = new();
        public List<SceneComponent> Components { get; set; } = new();
        public List<string> Tags { get; set; } = new();

        public SceneEntity DeepClone()
        {
            return new SceneEntity
            {
                Id = Id,
                Name = Name,
                Enabled = Enabled,
                ParentId = ParentId,
                Transform = Transform.DeepClone(),
                Components = Components.Select(component => component.DeepClone()).ToList(),
                Tags = new List<string>(Tags),
            };
        }
    }

    public sealed class SceneComponent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Type { get; set; } = "";
        public bool Enabled { get; set; } = true;
        public Dictionary<string, JsonElement> Properties { get; set; } =
            new(StringComparer.Ordinal);

        public SceneComponent DeepClone()
        {
            return new SceneComponent
            {
                Id = Id,
                Type = Type,
                Enabled = Enabled,
                Properties = Properties.ToDictionary(
                    pair => pair.Key,
                    pair => pair.Value.Clone(),
                    StringComparer.Ordinal),
            };
        }
    }

    public sealed class TransformDocument
    {
        public SceneVector3 Position { get; set; } = new();
        public SceneVector3 Rotation { get; set; } = new();
        public SceneVector3 Scale { get; set; } = new(1f, 1f, 1f);

        public TransformDocument DeepClone()
        {
            return new TransformDocument
            {
                Position = Position.DeepClone(),
                Rotation = Rotation.DeepClone(),
                Scale = Scale.DeepClone(),
            };
        }
    }

    public sealed class SceneVector3
    {
        public SceneVector3() { }

        public SceneVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public SceneVector3 DeepClone() => new(X, Y, Z);
    }

    public sealed class SceneColor
    {
        public SceneColor() { }

        public SceneColor(byte red, byte green, byte blue, byte alpha)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte Alpha { get; set; } = 255;

        public SceneColor DeepClone() => new(Red, Green, Blue, Alpha);
    }

    public sealed class SceneDocumentValidationException : Exception
    {
        public SceneDocumentValidationException(IReadOnlyList<string> errors)
            : base($"Scene document is invalid:{Environment.NewLine}- {string.Join($"{Environment.NewLine}- ", errors)}")
        {
            Errors = errors;
        }

        public IReadOnlyList<string> Errors { get; }
    }
}
