using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Angene = AngeneEditor; // avoid namespace clash

namespace AngeneEditor.Project
{
    /// <summary>
    /// Represents a loaded Angene project.
    /// </summary>
    public sealed class AngeneProject
    {
        public string Name { get; set; } = "";
        public string RootPath { get; set; } = "";
        public string Namespace { get; set; } = "";
        public string CsprojPath { get; set; } = "";
        public string ScenesPath => Path.Combine(RootPath, "Scenes");
        public string ScriptsPath => Path.Combine(RootPath, "Scripts");
        public string LibsPath => Path.Combine(RootPath, "Libs");

        public List<EntityDefinition> Entities { get; set; } = new();
    }

    /// <summary>
    /// In-editor representation of a game entity and its scripts.
    /// </summary>
    public sealed class EntityDefinition
    {
        public string Name { get; set; } = "Entity";
        public int X { get; set; }
        public int Y { get; set; }
        public List<string> Scripts { get; set; } = new();
        public bool Enabled { get; set; } = true;
    }

    /// <summary>
    /// Manages project lifecycle: creation, opening, saving, scaffolding.
    /// </summary>
    public sealed class ProjectManager
    {
        public static ProjectManager Instance { get; } = new();

        public AngeneProject? CurrentProject { get; private set; }
        public event Action<AngeneProject>? ProjectOpened;
        public event Action<EntityDefinition>? EntityAdded;
        public event Action<EntityDefinition, string>? ScriptAdded;
        public event Action? ProjectSaved;

        // Editor's own Libs\ directory (source for copying to new projects)
        private string EditorLibsPath =>
            Path.Combine(AppContext.BaseDirectory, "Libs");

        private ProjectManager() { }

        // ── Create ───────────────────────────────────────────────────────────────

        /// <summary>
        /// Scaffolds a brand new project at the given path.
        /// Creates: .csproj, Libs\, Program.cs, Scenes\Init.cs, Scripts\
        /// </summary>
        public AngeneProject CreateProject(string projectName, string parentDir)
        {
            string ns = SanitizeNamespace(projectName);
            string root = Path.Combine(parentDir, projectName);

            Directory.CreateDirectory(root);
            Directory.CreateDirectory(Path.Combine(root, "Scenes"));
            Directory.CreateDirectory(Path.Combine(root, "Scripts"));
            Directory.CreateDirectory(Path.Combine(root, "Libs"));

            // Write .csproj
            string csprojPath = Path.Combine(root, $"{projectName}.csproj");
            File.WriteAllText(csprojPath, Templates.CsProj(projectName, ns));

            // Write Program.cs
            File.WriteAllText(Path.Combine(root, "Program.cs"), Templates.ProgramCs(ns));

            // Write Scenes\Init.cs
            File.WriteAllText(
                Path.Combine(root, "Scenes", "Init.cs"),
                Templates.InitSceneCs(ns));

            // Copy Libs from editor directory
            CopyLibs(Path.Combine(root, "Libs"));

            var project = new AngeneProject
            {
                Name = projectName,
                RootPath = root,
                Namespace = ns,
                CsprojPath = csprojPath,
            };

            CurrentProject = project;
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
            };

            // Parse existing Init.cs entities (best-effort)
            ParseInitScene(project);

            CurrentProject = project;
            ProjectOpened?.Invoke(project);
            return project;
        }

        // ── Entity management ─────────────────────────────────────────────────────

        public EntityDefinition AddEntity(string name, int x = 0, int y = 0)
        {
            if (CurrentProject == null) throw new InvalidOperationException("No project open.");

            var entity = new EntityDefinition { Name = name, X = x, Y = y };
            CurrentProject.Entities.Add(entity);
            EntityAdded?.Invoke(entity);
            return entity;
        }

        public void RemoveEntity(EntityDefinition entity)
        {
            CurrentProject?.Entities.Remove(entity);
        }

        /// <summary>
        /// Creates a new script file and registers it on the entity.
        /// </summary>
        public string AddScript(EntityDefinition entity, string scriptName)
        {
            if (CurrentProject == null) throw new InvalidOperationException("No project open.");

            string safe = SanitizeIdentifier(scriptName);
            string path = Path.Combine(CurrentProject.ScriptsPath, $"{safe}.cs");

            if (!File.Exists(path))
                File.WriteAllText(path, Templates.NewScriptCs(CurrentProject.Namespace, safe));

            if (!entity.Scripts.Contains(safe))
            {
                entity.Scripts.Add(safe);
                ScriptAdded?.Invoke(entity, safe);
            }

            return path;
        }

        // ── Save (regenerate Init.cs) ─────────────────────────────────────────────

        /// <summary>
        /// Regenerates Scenes\Init.cs to match the current entity list.
        /// Preserves any manual code outside the auto-generated region.
        /// </summary>
        public void SaveProject()
        {
            if (CurrentProject == null) return;

            RegenerateInitScene(CurrentProject);
            ProjectSaved?.Invoke();
        }

        // ── Init.cs code generation ───────────────────────────────────────────────

        private void RegenerateInitScene(AngeneProject project)
        {
            string initPath = Path.Combine(project.ScenesPath, "Init.cs");

            // Build entity block
            var entityBlock = new System.Text.StringBuilder();
            entityBlock.AppendLine("            // ── ANGENE EDITOR — AUTO GENERATED BEGIN ────────────────────────────");
            foreach (var e in project.Entities)
                entityBlock.Append(Templates.EntityStub(e.Name, e.X, e.Y, e.Scripts.ToArray()));
            entityBlock.AppendLine("            // ── ANGENE EDITOR — AUTO GENERATED END ──────────────────────────────");

            if (!File.Exists(initPath))
            {
                File.WriteAllText(initPath, Templates.InitSceneCs(project.Namespace));
            }

            string content = File.ReadAllText(initPath);

            // Replace between markers if they exist, else inject before closing comment
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
                // Inject before closing comment in Initialize()
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
            string initPath = Path.Combine(project.ScenesPath, "Init.cs");
            if (!File.Exists(initPath)) return;

            string content = File.ReadAllText(initPath);

            // Look for: Entity <name> = new Entity(<x>, <y>, "<label>");
            var matches = Regex.Matches(content,
                @"Entity\s+(\w+)\s*=\s*new\s+Entity\s*\(\s*(-?\d+)\s*,\s*(-?\d+)\s*,\s*""([^""]+)""\s*\)");

            foreach (Match m in matches)
            {
                var def = new EntityDefinition
                {
                    Name = m.Groups[4].Value,
                    X = int.Parse(m.Groups[2].Value),
                    Y = int.Parse(m.Groups[3].Value),
                };

                // Find AddScript calls following this entity
                int pos = m.Index;
                int nextEntity = content.IndexOf("new Entity(", pos + 1);
                string slice = nextEntity > 0 ? content[pos..nextEntity] : content[pos..];

                var scriptMatches = Regex.Matches(slice, @"AddScript<(?:Scripts\.)?(\w+)>\(\)");
                foreach (Match sm in scriptMatches)
                    def.Scripts.Add(sm.Groups[1].Value);

                project.Entities.Add(def);
            }
        }

        // ── Lib copying ───────────────────────────────────────────────────────────

        private void CopyLibs(string destLibsPath)
        {
            Directory.CreateDirectory(destLibsPath);

            string editorDir = AppContext.BaseDirectory;

            // Names the generated .csproj references in its <Reference> items
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
                {
                    // Also check a Libs\ subfolder in case the editor was installed that way
                    src = Path.Combine(editorDir, "Libs", lib);
                }

                if (!File.Exists(src)) continue;

                string dest = Path.Combine(destLibsPath, lib);
                File.Copy(src, dest, overwrite: true);
                copied++;
            }

            // If none of the named files were found, fall back to copying everything
            // from the editor directory that looks like an engine DLL
            if (copied == 0)
            {
                foreach (var dll in Directory.GetFiles(editorDir, "*.dll"))
                {
                    string name = Path.GetFileName(dll);
                    // Skip framework / WinForms internals
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
        /// <summary>
        /// Registers a script that already exists on disk with an entity,
        /// firing the ScriptAdded event so the hierarchy panel updates.
        /// Called when the user picks an existing .cs file via the inspector.
        /// </summary>
        public void ScriptAddedExternal(EntityDefinition entity, string scriptName)
        {
            ScriptAdded?.Invoke(entity, scriptName);
        }
    }
}
