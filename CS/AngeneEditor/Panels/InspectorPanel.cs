using AngeneEditor.Project;
using AngeneEditor.Runtime;
using AngeneEditor.ScriptEditor;
using AngeneEditor.Theme;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AngeneEditor.Panels
{
    public sealed class InspectorPanel : Panel
    {
        private Label? _header;
        private Panel? _content;
        private EntityDefinition? _entity;
        private EditorSceneHost? _host;

        public void SetHost(EditorSceneHost host) => _host = host;

        public InspectorPanel()
        {
            BackColor = EditorTheme.Panel;
            Dock = DockStyle.Right;
            Width = 260;

            _header = new Label
            {
                Text = "INSPECTOR",
                Dock = DockStyle.Top,
                Height = 28,
                Font = EditorTheme.FontUISmall,
                ForeColor = EditorTheme.TextSecondary,
                BackColor = EditorTheme.PanelHeader,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
            };

            _content = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = EditorTheme.Panel,
                AutoScroll = true,
            };

            Controls.Add(_content);
            Controls.Add(_header);

            ShowEmpty();
        }

        // ── Public API ────────────────────────────────────────────────────────────

        public void ShowEntity(EntityDefinition entity)
        {
            _entity = entity;
            Rebuild();
        }

        public new void Refresh()
        {
            if (_entity != null) ShowEntity(_entity);
        }

        // ── Build ─────────────────────────────────────────────────────────────────

        private void ShowEmpty()
        {
            if (_content == null) return;
            _content.Controls.Clear();
            _content.Controls.Add(new Label
            {
                Text = "Select an entity\nin the hierarchy.",
                ForeColor = EditorTheme.TextDisabled,
                Font = EditorTheme.FontUI,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
            });
        }

        private void Rebuild()
        {
            if (_content == null) return;
            if (_entity == null) { ShowEmpty(); return; }
            _content.Controls.Clear();

            int y = 10;

            SectionHeader("Entity", ref y);
            AddField("Name", _entity.Name, ref y, editable: true, onChange: v => _entity.Name = v);
            AddField("X", _entity.X.ToString(), ref y, editable: true,
                onChange: v => { if (int.TryParse(v, out int x)) _entity.X = x; });
            AddField("Y", _entity.Y.ToString(), ref y, editable: true,
                onChange: v => { if (int.TryParse(v, out int yy)) _entity.Y = yy; });

            var enabledCheck = new CheckBox
            {
                Text = "Enabled",
                Checked = _entity.Enabled,
                Location = new Point(10, y),
                Size = new Size(120, 22),
                ForeColor = EditorTheme.TextPrimary,
                BackColor = EditorTheme.Panel,
                Font = EditorTheme.FontUI,
            };
            enabledCheck.CheckedChanged += (_, _) =>
            {
                _entity.Enabled = enabledCheck.Checked;
                _host?.SyncEntity(_entity.Name, _entity.X, _entity.Y, _entity.Enabled);
            };
            _content.Controls.Add(enabledCheck);
            y += 28;

            Divider(ref y);

            // ── Scripts ───────────────────────────────────────────────────────────
            SectionHeader("Scripts", ref y);

            foreach (var script in _entity.Scripts)
                AddScriptRow(script, ref y);

            // ── New script ────────────────────────────────────────────────────────
            var addNewBtn = new Button
            {
                Text = "+ New Script",
                Location = new Point(10, y),
                Size = new Size(115, 26),
                BackColor = EditorTheme.AccentDim,
                ForeColor = EditorTheme.TextPrimary,
                FlatStyle = FlatStyle.Flat,
                Font = EditorTheme.FontUISmall,
                FlatAppearance = { BorderColor = EditorTheme.Accent },
            };
            addNewBtn.Click += AddNewScript;
            _content.Controls.Add(addNewBtn);

            // ── Add existing script ───────────────────────────────────────────────
            var addExistBtn = new Button
            {
                Text = "+ Existing",
                Location = new Point(132, y),
                Size = new Size(90, 26),
                BackColor = EditorTheme.PanelHeader,
                ForeColor = EditorTheme.TextSecondary,
                FlatStyle = FlatStyle.Flat,
                Font = EditorTheme.FontUISmall,
                FlatAppearance = { BorderColor = EditorTheme.PanelBorder },
            };
            addExistBtn.Click += AddExistingScript;
            _content.Controls.Add(addExistBtn);
            y += 32;

            Divider(ref y);

            // ── Open Program.cs ───────────────────────────────────────────────────
            var programBtn = new Button
            {
                Text = "✎ Program.cs",
                Location = new Point(10, y),
                Size = new Size(115, 26),
                BackColor = EditorTheme.PanelHeader,
                ForeColor = EditorTheme.TextSecondary,
                FlatStyle = FlatStyle.Flat,
                Font = EditorTheme.FontUISmall,
                FlatAppearance = { BorderColor = EditorTheme.PanelBorder },
            };
            programBtn.Click += (_, _) => ScriptEditorWindow.OpenProgramCs(FindForm()!);
            _content.Controls.Add(programBtn);

            // ── Open in Visual Studio ─────────────────────────────────────────────
            var vsBtn = new Button
            {
                Text = "Open in VS",
                Location = new Point(132, y),
                Size = new Size(90, 26),
                BackColor = EditorTheme.PanelHeader,
                ForeColor = EditorTheme.TextSecondary,
                FlatStyle = FlatStyle.Flat,
                Font = EditorTheme.FontUISmall,
                FlatAppearance = { BorderColor = EditorTheme.PanelBorder },
            };
            vsBtn.Click += (_, _) => ScriptEditorWindow.OpenCsprojInVs(FindForm()!);
            _content.Controls.Add(vsBtn);
            y += 32;

            Divider(ref y);

            var saveBtn = new Button
            {
                Text = "💾 Apply to Scene",
                Location = new Point(10, y),
                Size = new Size(150, 28),
                BackColor = EditorTheme.Accent,
                ForeColor = EditorTheme.TextPrimary,
                FlatStyle = FlatStyle.Flat,
                Font = EditorTheme.FontUISmall,
            };
            saveBtn.Click += (_, _) => ProjectManager.Instance.SaveProject();
            _content.Controls.Add(saveBtn);
        }

        // ── Script row ────────────────────────────────────────────────────────────

        private void AddScriptRow(string scriptName, ref int y)
        {
            if (_content == null) return;

            var row = new Panel
            {
                Location = new Point(10, y),
                Size = new Size(230, 28),
                BackColor = EditorTheme.BackgroundAlt,
            };

            row.Controls.Add(new Label
            {
                Text = "⬡",
                Location = new Point(2, 4),
                Size = new Size(18, 20),
                ForeColor = EditorTheme.Accent,
                Font = EditorTheme.FontUI,
            });

            row.Controls.Add(new Label
            {
                Text = scriptName,
                Location = new Point(22, 5),
                Size = new Size(110, 18),
                ForeColor = EditorTheme.TextPrimary,
                Font = EditorTheme.FontUI,
            });

            // Edit in built-in editor
            var editBtn = new Button
            {
                Text = "✎",
                Location = new Point(136, 2),
                Size = new Size(26, 24),
                FlatStyle = FlatStyle.Flat,
                BackColor = EditorTheme.Panel,
                ForeColor = EditorTheme.TextAccent,
                Font = EditorTheme.FontUI,
                FlatAppearance = { BorderSize = 0 },
            };
            editBtn.Click += (_, _) => OpenScriptInEditor(scriptName);
            row.Controls.Add(editBtn);

            // Open in Visual Studio
            var vsBtn = new Button
            {
                Text = "VS",
                Location = new Point(164, 2),
                Size = new Size(30, 24),
                FlatStyle = FlatStyle.Flat,
                BackColor = EditorTheme.Panel,
                ForeColor = EditorTheme.TextSecondary,
                Font = EditorTheme.FontUISmall,
                FlatAppearance = { BorderSize = 0 },
            };
            vsBtn.Click += (_, _) =>
            {
                string? path = FindScriptPath(scriptName);
                if (path != null) ScriptEditorWindow.OpenFileInVs(path, FindForm()!);
            };
            row.Controls.Add(vsBtn);

            // Remove
            var removeBtn = new Button
            {
                Text = "✕",
                Location = new Point(196, 2),
                Size = new Size(26, 24),
                FlatStyle = FlatStyle.Flat,
                BackColor = EditorTheme.Panel,
                ForeColor = EditorTheme.Error,
                Font = EditorTheme.FontUI,
                FlatAppearance = { BorderSize = 0 },
            };
            removeBtn.Click += (_, _) => RemoveScript(scriptName);
            row.Controls.Add(removeBtn);

            _content.Controls.Add(row);
            y += 34;
        }

        // ── Script actions ────────────────────────────────────────────────────────

        private void AddNewScript(object? s, EventArgs e)
        {
            if (_entity == null) return;
            using var dlg = new RenameDialog("New Script Name", "MyScript");
            if (dlg.ShowDialog() != DialogResult.OK) return;
            string path = ProjectManager.Instance.AddScript(_entity, dlg.Value);
            Rebuild();
            // Offer to open it immediately
            new ScriptEditorWindow(path).Show(FindForm());
        }

        private void AddExistingScript(object? s, EventArgs e)
        {
            if (_entity == null) return;

            var project = ProjectManager.Instance.CurrentProject;
            if (project == null) return;

            using var dlg = new OpenFileDialog
            {
                Title = "Select Existing Script",
                Filter = "C# Script (*.cs)|*.cs",
                InitialDirectory = Directory.Exists(project.ScriptsPath)
                    ? project.ScriptsPath
                    : project.RootPath,
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;

            string scriptName = Path.GetFileNameWithoutExtension(dlg.FileName);

            // If the file is outside Scripts\, copy it in
            string dest = Path.Combine(project.ScriptsPath, Path.GetFileName(dlg.FileName));
            if (!File.Exists(dest) && dlg.FileName != dest)
                File.Copy(dlg.FileName, dest);

            if (!_entity.Scripts.Contains(scriptName))
            {
                _entity.Scripts.Add(scriptName);
                ProjectManager.Instance.ScriptAddedExternal(_entity, scriptName);
            }

            Rebuild();
        }

        private void RemoveScript(string scriptName)
        {
            if (_entity == null) return;
            if (MessageBox.Show(
                $"Remove script '{scriptName}' from entity?\n(File will not be deleted.)",
                "Remove Script", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _entity.Scripts.Remove(scriptName);
            Rebuild();
        }

        private void OpenScriptInEditor(string scriptName)
        {
            string? path = FindScriptPath(scriptName);
            if (path == null)
            { MessageBox.Show($"Script '{scriptName}.cs' not found.", "Not Found"); return; }
            new ScriptEditorWindow(path).Show(FindForm());
        }

        private string? FindScriptPath(string scriptName)
        {
            var project = ProjectManager.Instance.CurrentProject;
            if (project == null) return null;
            string path = Path.Combine(project.ScriptsPath, $"{scriptName}.cs");
            return File.Exists(path) ? path : null;
        }

        // ── UI helpers ────────────────────────────────────────────────────────────

        private void SectionHeader(string text, ref int y)
        {
            if (_content == null) return;
            _content.Controls.Add(new Label
            {
                Text = text.ToUpper(),
                Location = new Point(10, y),
                Size = new Size(220, 18),
                Font = EditorTheme.FontUISmall,
                ForeColor = EditorTheme.TextSecondary,
            });
            y += 22;
        }

        private void AddField(string label, string value, ref int y,
            bool editable = false, Action<string>? onChange = null)
        {
            if (_content == null) return;

            _content.Controls.Add(new Label
            {
                Text = label,
                Location = new Point(10, y + 3),
                Size = new Size(60, 18),
                ForeColor = EditorTheme.TextSecondary,
                Font = EditorTheme.FontUISmall,
            });

            if (editable)
            {
                var box = new TextBox
                {
                    Text = value,
                    Location = new Point(74, y),
                    Size = new Size(160, 22),
                    BackColor = EditorTheme.BackgroundAlt,
                    ForeColor = EditorTheme.TextPrimary,
                    BorderStyle = BorderStyle.FixedSingle,
                    Font = EditorTheme.FontUI,
                };
                // Single handler: propagate + WYSIWYG sync
                box.TextChanged += (_, _) =>
                {
                    onChange?.Invoke(box.Text);
                    if (_entity != null && _host != null)
                        _host.SyncEntity(_entity.Name, _entity.X, _entity.Y, _entity.Enabled);
                };
                _content.Controls.Add(box);
            }
            else
            {
                _content.Controls.Add(new Label
                {
                    Text = value,
                    Location = new Point(74, y + 3),
                    Size = new Size(160, 18),
                    ForeColor = EditorTheme.TextPrimary,
                    Font = EditorTheme.FontUI,
                });
            }

            y += 28;
        }

        private void Divider(ref int y)
        {
            if (_content == null) return;
            _content.Controls.Add(new Panel
            {
                Location = new Point(0, y),
                Size = new Size(Width, 1),
                BackColor = EditorTheme.PanelBorder,
            });
            y += 10;
        }
    }
}