using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.Json;
using AngeneEditor.Assets;
using AngeneEditor.Commands;
using AngeneEditor.Documents;
using Angene = AngeneEditor;

namespace AngeneEditor.Project
{
    public sealed class AngeneProject
    {
        public string Name { get; set; } = "";
        public string RootPath { get; set; } = "";
        public string Namespace { get; set; } = "";
        public string CsprojPath { get; set; } = "";
        public string ScenesPath => Path.Combine(RootPath, "Scenes");
        public string ScriptsPath => Path.Combine(RootPath, "Scripts");
        public string LibsPath => Path.Combine(RootPath, "Libs");
        public string AssetsPath => Path.Combine(RootPath, "Assets");
        public string EditorDataPath => Path.Combine(RootPath, ".angene");
        public string SceneDocumentsPath => Path.Combine(EditorDataPath, "Scenes");
        public string RecoveryPath => Path.Combine(EditorDataPath, "Recovery", "Main.autosave.angscene");
        public string ManifestPath => Path.Combine(EditorDataPath, "project.json");
        public string MainScenePath => Path.Combine(EditorDataPath, "Scenes", "Main.angscene");

        public List<EntityDefinition> Entities { get; set; } = new();
        public SceneDocument Scene { get; set; } = new();
        public ProjectManifest Manifest { get; set; } = new();
        public AssetDatabase? Assets { get; set; }
    }

    public sealed class EntityDefinition
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "Entity";
        public Guid? ParentId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public float Z { get; set; }
        public float RotationX { get; set; }
        public float RotationY { get; set; }
        public float RotationZ { get; set; }
        public float ScaleX { get; set; } = 1f;
        public float ScaleY { get; set; } = 1f;
        public float ScaleZ { get; set; } = 1f;
        public List<ComponentDefinition> Components { get; set; } = new();
        public List<string> Scripts { get; set; } = new();
        public bool Enabled { get; set; } = true;
    }

    public sealed class ComponentDefinition
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Type { get; set; } = "Component";
        public bool Enabled { get; set; } = true;
        public Dictionary<string, string> Properties { get; set; } =
            new(StringComparer.Ordinal);
    }

    public sealed class ProjectManager
    {
        public static ProjectManager Instance { get; } = new();

        public AngeneProject? CurrentProject { get; private set; }
        public event Action<AngeneProject>? ProjectOpened;
        public event Action<EntityDefinition>? EntityAdded;
        public event Action<EntityDefinition, string>? ScriptAdded;
        public event Action? EntitiesChanged;
        public event Action<bool>? DirtyStateChanged;
        public event Action? ProjectSaved;

        private readonly SceneSerializer _sceneSerializer = new();
        private readonly ProjectManifestStore _manifestStore = new();
        public CommandHistory History { get; } = new();
        public bool IsDirty { get; private set; }

        private string EditorLibsPath =>
            Path.Combine(AppContext.BaseDirectory, "Libs");

        private ProjectManager() { }

        // ── Create ───────────────────────────────────────────────────────────────

        public AngeneProject CreateProject(string projectName, string parentDir)
        {
            string ns = SanitizeNamespace(projectName);
            string root = Path.Combine(parentDir, projectName);

            Directory.CreateDirectory(root);
            Directory.CreateDirectory(Path.Combine(root, "Scenes"));
            Directory.CreateDirectory(Path.Combine(root, "Scripts"));
            Directory.CreateDirectory(Path.Combine(root, "Libs"));
            Directory.CreateDirectory(Path.Combine(root, "Assets"));
            Directory.CreateDirectory(Path.Combine(root, ".angene", "Scenes"));

            string csprojPath = Path.Combine(root, $"{projectName}.csproj");
            File.WriteAllText(csprojPath, Templates.CsProj(ns));
            File.WriteAllText(Path.Combine(root, "Program.cs"), Templates.ProgramCs(ns));
            File.WriteAllText(Path.Combine(root, "Scenes", "Init.cs"), Templates.InitSceneCs(ns)); // ask user what renderer

            CopyLibs(Path.Combine(root, "Libs"));

            var project = new AngeneProject
            {
                Name = projectName,
                RootPath = root,
                Namespace = ns,
                CsprojPath = csprojPath,
                Scene = new SceneDocument { Name = "Main" },
                Manifest = new ProjectManifest { Name = projectName },
                Assets = new AssetDatabase(Path.Combine(root, "Assets")),
            };

            project.Assets.Refresh();
            _manifestStore.SaveAtomic(project.ManifestPath, project.Manifest);
            _sceneSerializer.SaveAtomic(project.MainScenePath, project.Scene);

            CurrentProject = project;
            History.Clear();
            SetDirty(false);
            ProjectOpened?.Invoke(project);
            return project;
        }

        // ── Open ─────────────────────────────────────────────────────────────────

        public AngeneProject? OpenProject(string csprojPath)
        {
            if (!File.Exists(csprojPath)) return null;

            string root = Path.GetDirectoryName(csprojPath)!;
            string name = Path.GetFileNameWithoutExtension(csprojPath);
            string ns = SanitizeNamespace(name);

            var project = new AngeneProject
            {
                Name = name,
                RootPath = root,
                Namespace = ns,
                CsprojPath = csprojPath,
                Entities = new List<EntityDefinition>(), // always start fresh
                Manifest = LoadOrCreateManifest(root, name),
                Assets = new AssetDatabase(Path.Combine(root, "Assets")),
            };

            project.Assets.Refresh();
            string scenePath = Path.Combine(project.EditorDataPath, project.Manifest.DefaultScene);
            if (File.Exists(scenePath))
            {
                project.Scene = _sceneSerializer.Load(scenePath);
                SyncEntitiesFromScene(project);
            }
            else
            {
                ParseInitScene(project);
                SyncSceneFromEntities(project);
            }

            CurrentProject = project;
            History.Clear();
            SetDirty(false);
            ProjectOpened?.Invoke(project);
            return project;
        }

        // ── Entity management ─────────────────────────────────────────────────────

        public EntityDefinition AddEntity(string name, int x = 0, int y = 0, Guid? parentId = null)
        {
            if (CurrentProject == null) throw new InvalidOperationException("No project open.");

            var entity = new EntityDefinition
            {
                Name = UniqueEntityName(name),
                ParentId = parentId,
                X = x,
                Y = y,
            };

            ExecuteEntityMutation($"Create {entity.Name}", entities =>
                entities.Add(CloneEntity(entity)));

            EntityDefinition added = CurrentProject.Entities.Single(item => item.Id == entity.Id);
            EntityAdded?.Invoke(added);
            return added;
        }

        public void RemoveEntity(EntityDefinition entity)
        {
            RemoveEntities(new[] { entity });
        }

        public void RemoveEntities(IEnumerable<EntityDefinition> entities)
        {
            if (CurrentProject == null) return;

            var ids = entities.Select(entity => entity.Id).ToHashSet();
            bool added;
            do
            {
                added = false;
                foreach (EntityDefinition candidate in CurrentProject.Entities)
                {
                    if (candidate.ParentId is Guid parentId &&
                        ids.Contains(parentId) &&
                        ids.Add(candidate.Id))
                    {
                        added = true;
                    }
                }
            } while (added);

            ExecuteEntityMutation("Delete entities", projectEntities =>
                projectEntities.RemoveAll(candidate => ids.Contains(candidate.Id)));
        }

        public EntityDefinition DuplicateEntity(EntityDefinition source)
        {
            if (CurrentProject == null) throw new InvalidOperationException("No project open.");

            EntityDefinition duplicate = CloneEntity(source);
            duplicate.Id = Guid.NewGuid();
            duplicate.Name = UniqueEntityName($"{source.Name} Copy");

            ExecuteEntityMutation($"Duplicate {source.Name}", entities =>
            {
                int sourceIndex = entities.FindIndex(entity => entity.Id == source.Id);
                entities.Insert(
                    sourceIndex < 0 ? entities.Count : sourceIndex + 1,
                    CloneEntity(duplicate));
            });

            return CurrentProject.Entities.Single(entity => entity.Id == duplicate.Id);
        }

        public void RenameEntity(EntityDefinition entity, string name)
        {
            string trimmed = name.Trim();
            if (trimmed.Length == 0)
                throw new ArgumentException("Entity name cannot be empty.", nameof(name));

            ExecuteEntityMutation($"Rename {entity.Name}", entities =>
            {
                EntityDefinition target = RequireEntity(entities, entity.Id);
                target.Name = UniqueEntityName(trimmed, entity.Id);
            });
        }

        public void ReparentEntity(EntityDefinition entity, EntityDefinition? newParent)
        {
            if (newParent?.Id == entity.Id)
                throw new InvalidOperationException("An entity cannot parent itself.");

            if (newParent != null && IsDescendant(entity.Id, newParent.Id))
                throw new InvalidOperationException("Reparenting would create a hierarchy cycle.");

            ExecuteEntityMutation($"Reparent {entity.Name}", entities =>
            {
                RequireEntity(entities, entity.Id).ParentId = newParent?.Id;
            });
        }

        public void MoveEntity(EntityDefinition entity, int destinationIndex)
        {
            ExecuteEntityMutation($"Reorder {entity.Name}", entities =>
            {
                int sourceIndex = entities.FindIndex(item => item.Id == entity.Id);
                if (sourceIndex < 0) return;

                EntityDefinition moving = entities[sourceIndex];
                entities.RemoveAt(sourceIndex);
                entities.Insert(Math.Clamp(destinationIndex, 0, entities.Count), moving);
            });
        }

        public EntityDefinition UpdateEntity(
            EntityDefinition entity,
            string description,
            Action<EntityDefinition> update)
        {
            ArgumentNullException.ThrowIfNull(update);
            ExecuteEntityMutation(description, entities =>
                update(RequireEntity(entities, entity.Id)));

            return CurrentProject!.Entities.Single(candidate => candidate.Id == entity.Id);
        }

        public void UpdateSceneSettings(
            string description,
            Action<SceneSettings> update)
        {
            ArgumentNullException.ThrowIfNull(update);
            if (CurrentProject == null)
                throw new InvalidOperationException("No project open.");

            History.Execute(new SceneSettingsMutationCommand(
                CurrentProject,
                description,
                update));
            AfterEntityMutation();
        }

        public void Undo()
        {
            if (!History.CanUndo) return;
            History.Undo();
            AfterEntityMutation();
        }

        public void Redo()
        {
            if (!History.CanRedo) return;
            History.Redo();
            AfterEntityMutation();
        }

        public string AddScript(EntityDefinition entity, string scriptName)
        {
            if (CurrentProject == null) throw new InvalidOperationException("No project open.");

            string safe = SanitizeIdentifier(scriptName);
            string path = Path.Combine(CurrentProject.ScriptsPath, $"{safe}.cs");

            if (!File.Exists(path))
                File.WriteAllText(path, Templates.NewScriptCs(CurrentProject.Namespace, safe));

            AttachScript(entity, safe);

            return path;
        }

        public void AttachScript(EntityDefinition entity, string scriptName)
        {
            if (CurrentProject == null)
                throw new InvalidOperationException("No project open.");

            EntityDefinition current = CurrentProject.Entities
                .Single(item => item.Id == entity.Id);
            if (current.Scripts.Contains(scriptName, StringComparer.OrdinalIgnoreCase))
                return;

            ExecuteEntityMutation($"Attach {scriptName}", entities =>
                RequireEntity(entities, entity.Id).Scripts.Add(scriptName));

            current = CurrentProject.Entities.Single(item => item.Id == entity.Id);
            ScriptAdded?.Invoke(current, scriptName);
        }

        public void DetachScript(EntityDefinition entity, string scriptName)
        {
            ExecuteEntityMutation($"Detach {scriptName}", entities =>
                RequireEntity(entities, entity.Id).Scripts.RemoveAll(script =>
                    string.Equals(script, scriptName, StringComparison.OrdinalIgnoreCase)));
        }

        public ComponentDefinition AddComponent(
            EntityDefinition entity,
            string type,
            IReadOnlyDictionary<string, string>? defaultProperties = null)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Component type cannot be empty.", nameof(type));

            var component = new ComponentDefinition
            {
                Type = type.Trim(),
                Properties = defaultProperties?.ToDictionary(
                    pair => pair.Key,
                    pair => pair.Value,
                    StringComparer.Ordinal)
                    ?? new Dictionary<string, string>(StringComparer.Ordinal),
            };

            ExecuteEntityMutation($"Add {component.Type}", entities =>
                RequireEntity(entities, entity.Id).Components.Add(CloneComponent(component)));

            return CurrentProject!.Entities
                .Single(candidate => candidate.Id == entity.Id)
                .Components.Single(candidate => candidate.Id == component.Id);
        }

        public void RemoveComponent(EntityDefinition entity, Guid componentId)
        {
            ExecuteEntityMutation("Remove component", entities =>
                RequireEntity(entities, entity.Id).Components.RemoveAll(
                    component => component.Id == componentId));
        }

        public ComponentDefinition UpdateComponent(
            EntityDefinition entity,
            Guid componentId,
            string description,
            Action<ComponentDefinition> update)
        {
            ArgumentNullException.ThrowIfNull(update);
            ExecuteEntityMutation(description, entities =>
            {
                ComponentDefinition component = RequireEntity(entities, entity.Id)
                    .Components.FirstOrDefault(candidate => candidate.Id == componentId)
                    ?? throw new InvalidOperationException(
                        $"Component '{componentId}' does not exist.");
                update(component);
            });

            return CurrentProject!.Entities
                .Single(candidate => candidate.Id == entity.Id)
                .Components.Single(candidate => candidate.Id == componentId);
        }

        // ── Save ─────────────────────────────────────────────────────────────────

        public void SaveProject()
        {
            if (CurrentProject == null) return;
            SyncSceneFromEntities(CurrentProject);
            _manifestStore.SaveAtomic(CurrentProject.ManifestPath, CurrentProject.Manifest);
            _sceneSerializer.SaveAtomic(CurrentProject.MainScenePath, CurrentProject.Scene);
            RegenerateInitScene(CurrentProject);
            DeleteRecoverySnapshot();
            SetDirty(false);
            ProjectSaved?.Invoke();
        }

        public bool SaveRecoverySnapshot()
        {
            if (CurrentProject == null || !IsDirty)
                return false;

            SyncSceneFromEntities(CurrentProject);
            Directory.CreateDirectory(Path.GetDirectoryName(CurrentProject.RecoveryPath)!);
            _sceneSerializer.SaveAtomic(CurrentProject.RecoveryPath, CurrentProject.Scene);
            return true;
        }

        public bool HasRecoverySnapshot()
        {
            if (CurrentProject == null || !File.Exists(CurrentProject.RecoveryPath))
                return false;

            if (!File.Exists(CurrentProject.MainScenePath))
                return true;

            return File.GetLastWriteTimeUtc(CurrentProject.RecoveryPath) >
                   File.GetLastWriteTimeUtc(CurrentProject.MainScenePath);
        }

        public bool RestoreRecoverySnapshot()
        {
            if (CurrentProject == null || !File.Exists(CurrentProject.RecoveryPath))
                return false;

            CurrentProject.Scene = _sceneSerializer.Load(CurrentProject.RecoveryPath);
            SyncEntitiesFromScene(CurrentProject);
            History.Clear();
            SetDirty(true);
            EntitiesChanged?.Invoke();
            return true;
        }

        public void DeleteRecoverySnapshot()
        {
            if (CurrentProject == null || !File.Exists(CurrentProject.RecoveryPath))
                return;

            File.Delete(CurrentProject.RecoveryPath);
        }

        private void ExecuteEntityMutation(
            string name,
            Action<List<EntityDefinition>> mutation)
        {
            if (CurrentProject == null)
                throw new InvalidOperationException("No project open.");

            History.Execute(new EntityMutationCommand(CurrentProject, name, mutation));
            AfterEntityMutation();
        }

        private void AfterEntityMutation()
        {
            if (CurrentProject == null) return;
            SyncSceneFromEntities(CurrentProject);
            SetDirty(true);
            EntitiesChanged?.Invoke();
        }

        private void SetDirty(bool value)
        {
            if (IsDirty == value) return;
            IsDirty = value;
            DirtyStateChanged?.Invoke(value);
        }

        private bool IsDescendant(Guid ancestorId, Guid possibleDescendantId)
        {
            if (CurrentProject == null) return false;

            EntityDefinition? current = CurrentProject.Entities
                .FirstOrDefault(entity => entity.Id == possibleDescendantId);
            while (current?.ParentId is Guid parentId)
            {
                if (parentId == ancestorId)
                    return true;

                current = CurrentProject.Entities
                    .FirstOrDefault(entity => entity.Id == parentId);
            }

            return false;
        }

        private string UniqueEntityName(string requested, Guid? exceptId = null)
        {
            if (CurrentProject == null) return requested.Trim();

            string root = string.IsNullOrWhiteSpace(requested) ? "Entity" : requested.Trim();
            string candidate = root;
            int suffix = 2;

            while (CurrentProject.Entities.Any(entity =>
                       entity.Id != exceptId &&
                       string.Equals(entity.Name, candidate, StringComparison.OrdinalIgnoreCase)))
            {
                candidate = $"{root} {suffix++}";
            }

            return candidate;
        }

        private static EntityDefinition RequireEntity(
            IEnumerable<EntityDefinition> entities,
            Guid id)
        {
            return entities.FirstOrDefault(entity => entity.Id == id)
                ?? throw new InvalidOperationException($"Entity '{id}' does not exist.");
        }

        private static EntityDefinition CloneEntity(EntityDefinition entity)
        {
            return new EntityDefinition
            {
                Id = entity.Id,
                Name = entity.Name,
                ParentId = entity.ParentId,
                X = entity.X,
                Y = entity.Y,
                Z = entity.Z,
                RotationX = entity.RotationX,
                RotationY = entity.RotationY,
                RotationZ = entity.RotationZ,
                ScaleX = entity.ScaleX,
                ScaleY = entity.ScaleY,
                ScaleZ = entity.ScaleZ,
                Enabled = entity.Enabled,
                Components = entity.Components.Select(CloneComponent).ToList(),
                Scripts = new List<string>(entity.Scripts),
            };
        }

        private static ComponentDefinition CloneComponent(ComponentDefinition component)
        {
            return new ComponentDefinition
            {
                Id = component.Id,
                Type = component.Type,
                Enabled = component.Enabled,
                Properties = new Dictionary<string, string>(
                    component.Properties,
                    StringComparer.Ordinal),
            };
        }

        private sealed class EntityMutationCommand : IEditorCommand
        {
            private readonly AngeneProject _project;
            private readonly Action<List<EntityDefinition>> _mutation;
            private List<EntityDefinition>? _before;
            private List<EntityDefinition>? _after;

            public EntityMutationCommand(
                AngeneProject project,
                string name,
                Action<List<EntityDefinition>> mutation)
            {
                _project = project;
                Name = name;
                _mutation = mutation;
            }

            public string Name { get; }

            public void Execute()
            {
                if (_after == null)
                {
                    _before = _project.Entities.Select(CloneEntity).ToList();
                    _mutation(_project.Entities);
                    _after = _project.Entities.Select(CloneEntity).ToList();
                }
                else
                {
                    _project.Entities = _after.Select(CloneEntity).ToList();
                }
            }

            public void Undo()
            {
                if (_before != null)
                    _project.Entities = _before.Select(CloneEntity).ToList();
            }
        }

        private sealed class SceneSettingsMutationCommand : IEditorCommand
        {
            private readonly AngeneProject _project;
            private readonly Action<SceneSettings> _mutation;
            private SceneSettings? _before;
            private SceneSettings? _after;

            public SceneSettingsMutationCommand(
                AngeneProject project,
                string name,
                Action<SceneSettings> mutation)
            {
                _project = project;
                Name = name;
                _mutation = mutation;
            }

            public string Name { get; }

            public void Execute()
            {
                if (_after == null)
                {
                    _before = _project.Scene.Settings.DeepClone();
                    _mutation(_project.Scene.Settings);
                    _after = _project.Scene.Settings.DeepClone();
                }
                else
                {
                    _project.Scene.Settings = _after.DeepClone();
                }
            }

            public void Undo()
            {
                if (_before != null)
                    _project.Scene.Settings = _before.DeepClone();
            }
        }

        private ProjectManifest LoadOrCreateManifest(string root, string name)
        {
            string path = Path.Combine(root, ".angene", "project.json");
            return File.Exists(path)
                ? _manifestStore.Load(path)
                : new ProjectManifest { Name = name };
        }

        private static void SyncSceneFromEntities(AngeneProject project)
        {
            var previous = project.Scene.Entities.ToDictionary(entity => entity.Id);
            var synchronized = new List<SceneEntity>(project.Entities.Count);

            foreach (EntityDefinition definition in project.Entities)
            {
                SceneEntity entity = previous.TryGetValue(definition.Id, out SceneEntity? existing)
                    ? existing.DeepClone()
                    : new SceneEntity { Id = definition.Id };

                entity.Name = definition.Name;
                entity.ParentId = definition.ParentId;
                entity.Enabled = definition.Enabled;
                entity.Transform.Position = new SceneVector3(definition.X, definition.Y, definition.Z);
                entity.Transform.Rotation = new SceneVector3(
                    definition.RotationX,
                    definition.RotationY,
                    definition.RotationZ);
                entity.Transform.Scale = new SceneVector3(
                    definition.ScaleX,
                    definition.ScaleY,
                    definition.ScaleZ);

                var scriptComponents = entity.Components
                    .Where(component =>
                        component.Type.StartsWith("Script:", StringComparison.Ordinal))
                    .GroupBy(component => component.Type, StringComparer.Ordinal)
                    .ToDictionary(
                        group => group.Key,
                        group => group.First(),
                        StringComparer.Ordinal);
                entity.Components.RemoveAll(component =>
                    component.Type.StartsWith("Script:", StringComparison.Ordinal));
                foreach (string script in definition.Scripts)
                {
                    string type = $"Script:{script}";
                    entity.Components.Add(
                        scriptComponents.TryGetValue(type, out SceneComponent? component)
                            ? component
                            : new SceneComponent { Type = type });
                }

                var genericComponents = entity.Components
                    .Where(component =>
                        !component.Type.StartsWith("Script:", StringComparison.Ordinal))
                    .ToDictionary(component => component.Id);
                entity.Components.RemoveAll(component =>
                    !component.Type.StartsWith("Script:", StringComparison.Ordinal));
                foreach (ComponentDefinition definitionComponent in definition.Components)
                {
                    SceneComponent component = genericComponents.TryGetValue(
                        definitionComponent.Id,
                        out SceneComponent? existingComponent)
                        ? existingComponent
                        : new SceneComponent { Id = definitionComponent.Id };
                    component.Type = definitionComponent.Type;
                    component.Enabled = definitionComponent.Enabled;
                    component.Properties = definitionComponent.Properties.ToDictionary(
                        pair => pair.Key,
                        pair => JsonSerializer.SerializeToElement(pair.Value),
                        StringComparer.Ordinal);
                    entity.Components.Add(component);
                }

                synchronized.Add(entity);
            }

            project.Scene.Entities = synchronized;
            project.Scene.EnsureValid();
        }

        private static void SyncEntitiesFromScene(AngeneProject project)
        {
            project.Entities = project.Scene.Entities.Select(entity => new EntityDefinition
            {
                Id = entity.Id,
                Name = entity.Name,
                ParentId = entity.ParentId,
                Enabled = entity.Enabled,
                X = (int)MathF.Round(entity.Transform.Position.X),
                Y = (int)MathF.Round(entity.Transform.Position.Y),
                Z = entity.Transform.Position.Z,
                RotationX = entity.Transform.Rotation.X,
                RotationY = entity.Transform.Rotation.Y,
                RotationZ = entity.Transform.Rotation.Z,
                ScaleX = entity.Transform.Scale.X,
                ScaleY = entity.Transform.Scale.Y,
                ScaleZ = entity.Transform.Scale.Z,
                Components = entity.Components
                    .Where(component =>
                        !component.Type.StartsWith("Script:", StringComparison.Ordinal))
                    .Select(component => new ComponentDefinition
                    {
                        Id = component.Id,
                        Type = component.Type,
                        Enabled = component.Enabled,
                        Properties = component.Properties.ToDictionary(
                            pair => pair.Key,
                            pair => pair.Value.ValueKind == JsonValueKind.String
                                ? pair.Value.GetString() ?? ""
                                : pair.Value.GetRawText(),
                            StringComparer.Ordinal),
                    })
                    .ToList(),
                Scripts = entity.Components
                    .Where(component => component.Type.StartsWith("Script:", StringComparison.Ordinal))
                    .Select(component => component.Type["Script:".Length..])
                    .ToList(),
            }).ToList();
        }

        // ── Init.cs code generation ───────────────────────────────────────────────

        private void RegenerateInitScene(AngeneProject project)
        {
            string initPath = Path.Combine(project.ScenesPath, "Init.cs");

            var entityBlock = new System.Text.StringBuilder();
            entityBlock.AppendLine("            // ── ANGENE EDITOR — AUTO GENERATED BEGIN ────────────────────────────");
            foreach (var e in project.Entities)
                entityBlock.Append(Templates.EntityStub(e.Name, e.X, e.Y, e.Scripts.ToArray()));
            entityBlock.AppendLine("            // ── ANGENE EDITOR — AUTO GENERATED END ──────────────────────────────");

            if (!File.Exists(initPath))
                File.WriteAllText(initPath, Templates.InitSceneCs(project.Namespace));

            string content = File.ReadAllText(initPath);

            const string beginMarker = "// ── ANGENE EDITOR — AUTO GENERATED BEGIN";
            const string endMarker = "// ── ANGENE EDITOR — AUTO GENERATED END";

            int begin = content.IndexOf(beginMarker);
            int end = content.IndexOf(endMarker);

            if (begin >= 0 && end >= 0)
            {
                end = content.IndexOf('\n', end) + 1;
                content = content[..begin] + entityBlock.ToString() + content[end..];
            }
            else
            {
                const string anchor = "// ── Add your entities here";
                int pos = content.IndexOf(anchor);
                if (pos >= 0)
                {
                    int lineEnd = content.IndexOf('\n', pos) + 1;
                    content = content[..lineEnd] + "\n" + entityBlock.ToString() + content[lineEnd..];
                }
            }

            File.WriteAllText(initPath, content);
        }

        // ── Parse existing Init.cs ────────────────────────────────────────────────

        private void ParseInitScene(AngeneProject project)
        {
            project.Entities.Clear(); // always clear before re-parsing

            string initPath = Path.Combine(project.ScenesPath, "Init.cs");
            if (!File.Exists(initPath)) return;

            string content = File.ReadAllText(initPath);

            // Only look inside the auto-generated region if it exists
            const string beginMarker = "// ── ANGENE EDITOR — AUTO GENERATED BEGIN";
            const string endMarker = "// ── ANGENE EDITOR — AUTO GENERATED END";
            int regionStart = content.IndexOf(beginMarker);
            int regionEnd = content.IndexOf(endMarker);

            // If markers exist, only parse the generated region
            // If not (hand-written file), parse the whole file
            string parseTarget = (regionStart >= 0 && regionEnd > regionStart)
                ? content[regionStart..regionEnd]
                : content;

            // Skip commented-out lines before matching
            // Remove all lines that start with optional whitespace followed by //
            string uncommented = Regex.Replace(parseTarget, @"^\s*//.*$", "", RegexOptions.Multiline);

            var matches = Regex.Matches(uncommented,
                @"Entity\s+(\w+)\s*=\s*new\s+Entity\s*\(\s*(-?\d+)\s*,\s*(-?\d+)\s*,\s*""([^""]+)""\s*\)");

            foreach (Match m in matches)
            {
                var def = new EntityDefinition
                {
                    Name = m.Groups[4].Value,
                    X = int.Parse(m.Groups[2].Value),
                    Y = int.Parse(m.Groups[3].Value),
                };

                // Find AddScript calls that follow this entity variable name
                string varName = m.Groups[1].Value;
                int pos = uncommented.IndexOf(m.Value);
                int nextEntity = FindNextEntityPos(uncommented, pos + m.Length);
                string slice = nextEntity > 0 ? uncommented[pos..nextEntity] : uncommented[pos..];

                // Match both namespaced and bare AddScript<T>()
                var scriptMatches = Regex.Matches(slice,
                    @"AddScript<(?:[A-Za-z0-9_]+\.)*([A-Za-z0-9_]+)>\s*\(\s*\)");
                foreach (Match sm in scriptMatches)
                    def.Scripts.Add(sm.Groups[1].Value);

                // Read enabled state: look for .SetEnabled(true/false)
                var enabledMatch = Regex.Match(slice, @"\.SetEnabled\s*\(\s*(true|false)\s*\)");
                def.Enabled = !enabledMatch.Success || enabledMatch.Groups[1].Value == "true";

                project.Entities.Add(def);
            }
        }

        private static int FindNextEntityPos(string content, int after)
        {
            // Find the next "= new Entity(" after the given position
            return content.IndexOf("= new Entity(", after);
        }

        // ── Lib copying ───────────────────────────────────────────────────────────

        private void CopyLibs(string destLibsPath)
        {
            Directory.CreateDirectory(destLibsPath);

            string editorDir = AppContext.BaseDirectory;

            string[] requiredLibs =
            {
                "Angene.dll",
                "Angene.Common.dll",
                "Angene.Essentials.dll",
                "Angene.Audio.dll",
                "Angene.Graphics.dll",
                "Angene.Windows.dll",
                "Angene.Math.dll",
                "BouncyCastle.Crypto.dll",
                "DiscordRPC.dll",
                "Newtonsoft.Json.dll",
                "System.Security.Permissions.dll",
                "System.Windows.Extensions.dll",
            };

            int copied = 0;
            foreach (string lib in requiredLibs)
            {
                string src = Path.Combine(editorDir, lib);
                if (!File.Exists(src))
                    src = Path.Combine(editorDir, "Libs", lib);

                if (!File.Exists(src)) continue;

                string dest = Path.Combine(destLibsPath, lib);
                File.Copy(src, dest, overwrite: true);
                copied++;
            }

            if (copied == 0)
            {
                foreach (var dll in Directory.GetFiles(editorDir, "*.dll"))
                {
                    string name = Path.GetFileName(dll);
                    if (name.StartsWith("System.") ||
                        name.StartsWith("Microsoft.") ||
                        name.StartsWith("netstandard"))
                        continue;

                    File.Copy(dll, Path.Combine(destLibsPath, name), overwrite: true);
                }
            }
        }

        // ── Helpers ──────────────────────────────────────────────────────────────

        private static string SanitizeNamespace(string name)
            => Regex.Replace(name, @"[^a-zA-Z0-9_]", "_");

        private static string SanitizeIdentifier(string name)
        {
            name = Regex.Replace(name, @"[^a-zA-Z0-9_]", "");
            if (name.Length == 0 || char.IsDigit(name[0]))
                name = "_" + name;
            return name;
        }

        public void ScriptAddedExternal(EntityDefinition entity, string scriptName)
        {
            ScriptAdded?.Invoke(entity, scriptName);
        }
    }
}
