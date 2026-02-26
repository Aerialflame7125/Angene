using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AngeneEditor.Project;
using AngeneEditor.ScriptEditor;
using AngeneEditor.Theme;

namespace AngeneEditor.Panels
{
    /// <summary>
    /// Right panel: entity inspector.
    /// Shows selected entity name, position, enabled state,
    /// and lists all attached scripts with open/remove actions.
    /// </summary>
    public sealed class InspectorPanel : Panel
    {
        private Label _header;
        private Panel _content;
        private EntityDefinition? _entity;

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

        public void Refresh()
        {
            if (_entity != null) ShowEntity(_entity);
        }

        // ── Build ─────────────────────────────────────────────────────────────────

        private void ShowEmpty()
        {
            _content.Controls.Clear();
            var lbl = new Label
            {
                Text = "Select an entity\nin the hierarchy.",
                ForeColor = EditorTheme.TextDisabled,
                Font = EditorTheme.FontUI,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
            };
            _content.Controls.Add(lbl);
        }

        private void Rebuild()
        {
            if (_entity == null) { ShowEmpty(); return; }
            _content.Controls.Clear();

            int y = 10;

            // ── Entity name ───────────────────────────────────────────────────────
            SectionHeader("Entity", ref y);

            AddField("Name", _entity.Name, ref y, editable: true, onChange: v => _entity.Name = v);
            AddField("X", _entity.X.ToString(), ref y, editable: true, onChange: v => { if (int.TryParse(v, out int x)) _entity.X = x; });
            AddField("Y", _entity.Y.ToString(), ref y, editable: true, onChange: v => { if (int.TryParse(v, out int yy)) _entity.Y = yy; });

            // Enabled toggle
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
            enabledCheck.CheckedChanged += (_, _) => _entity.Enabled = enabledCheck.Checked;
            _content.Controls.Add(enabledCheck);
            y += 28;

            Divider(ref y);

            // ── Scripts ───────────────────────────────────────────────────────────
            SectionHeader("Scripts", ref y);

            foreach (var script in _entity.Scripts)
                AddScriptRow(script, ref y);

            // Add script button
            var addBtn = new Button
            {
                Text = "+ Add Script",
                Location = new Point(10, y),
                Size = new Size(120, 26),
                BackColor = EditorTheme.AccentDim,
                ForeColor = EditorTheme.TextPrimary,
                FlatStyle = FlatStyle.Flat,
                Font = EditorTheme.FontUISmall,
                FlatAppearance = { BorderColor = EditorTheme.Accent },
            };
            addBtn.Click += AddScript;
            _content.Controls.Add(addBtn);
            y += 32;

            Divider(ref y);

            // ── Save to Init.cs button ────────────────────────────────────────────
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
            var row = new Panel
            {
                Location = new Point(10, y),
                Size = new Size(230, 28),
                BackColor = EditorTheme.BackgroundAlt,
            };

            var icon = new Label
            {
                Text = "⬡",
                Location = new Point(2, 4),
                Size = new Size(18, 20),
                ForeColor = EditorTheme.Accent,
                Font = EditorTheme.FontUI,
            };

            var nameLbl = new Label
            {
                Text = scriptName,
                Location = new Point(22, 5),
                Size = new Size(140, 18),
                ForeColor = EditorTheme.TextPrimary,
                Font = EditorTheme.FontUI,
            };

            var openBtn = new Button
            {
                Text = "✎",
                Location = new Point(168, 2),
                Size = new Size(26, 24),
                FlatStyle = FlatStyle.Flat,
                BackColor = EditorTheme.Panel,
                ForeColor = EditorTheme.TextAccent,
                Font = EditorTheme.FontUI,
                FlatAppearance = { BorderSize = 0 },
            };
            openBtn.Click += (_, _) => OpenScript(scriptName);

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

            row.Controls.AddRange(new Control[] { icon, nameLbl, openBtn, removeBtn });
            _content.Controls.Add(row);
            y += 34;
        }

        // ── Actions ───────────────────────────────────────────────────────────────

        private void AddScript(object? s, EventArgs e)
        {
            if (_entity == null) return;

            using var dlg = new RenameDialog("Script Name", "MyScript");
            if (dlg.ShowDialog() != DialogResult.OK) return;

            ProjectManager.Instance.AddScript(_entity, dlg.Value);
            Rebuild();
        }

        private void RemoveScript(string scriptName)
        {
            if (_entity == null) return;

            var confirm = MessageBox.Show(
                $"Remove script '{scriptName}' from entity?\n(File will not be deleted.)",
                "Remove Script",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            _entity.Scripts.Remove(scriptName);
            Rebuild();
        }

        private void OpenScript(string scriptName)
        {
            string? scriptPath = FindScriptPath(scriptName);
            if (scriptPath == null)
            {
                MessageBox.Show($"Script file '{scriptName}.cs' not found.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var editor = new ScriptEditorWindow(scriptPath);
            editor.Show(FindForm());
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
            var lbl = new Label
            {
                Text = text.ToUpper(),
                Location = new Point(10, y),
                Size = new Size(220, 18),
                Font = EditorTheme.FontUISmall,
                ForeColor = EditorTheme.TextSecondary,
            };
            _content.Controls.Add(lbl);
            y += 22;
        }

        private void AddField(string label, string value, ref int y,
            bool editable = false, Action<string>? onChange = null)
        {
            var lbl = new Label
            {
                Text = label,
                Location = new Point(10, y + 3),
                Size = new Size(60, 18),
                ForeColor = EditorTheme.TextSecondary,
                Font = EditorTheme.FontUISmall,
            };

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
                box.TextChanged += (_, _) => onChange?.Invoke(box.Text);
                _content.Controls.Add(box);
            }
            else
            {
                var val = new Label
                {
                    Text = value,
                    Location = new Point(74, y + 3),
                    Size = new Size(160, 18),
                    ForeColor = EditorTheme.TextPrimary,
                    Font = EditorTheme.FontUI,
                };
                _content.Controls.Add(val);
            }

            _content.Controls.Add(lbl);
            y += 28;
        }

        private void Divider(ref int y)
        {
            var line = new Panel
            {
                Location = new Point(0, y),
                Size = new Size(Width, 1),
                BackColor = EditorTheme.PanelBorder,
            };
            _content.Controls.Add(line);
            y += 10;
        }
    }
}