using AngeneEditor.Project;
using AngeneEditor.Runtime;
using AngeneEditor.ScriptEditor;
using AngeneEditor.Theme;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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

            ProjectManager.Instance.EntitiesChanged += RefreshCurrentEntity;
            ShowEmpty();
        }

        public void ShowEntity(EntityDefinition entity)
        {
            _entity = entity;
            Rebuild();
        }

        public new void Refresh()
        {
            if (_entity != null) ShowEntity(_entity);
        }

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
            AddField("Name", _entity.Name, ref y, editable: true, onChange: value =>
            {
                if (_entity != null && value.Length > 0 && value != _entity.Name)
                    ProjectManager.Instance.RenameEntity(_entity, value);
            });

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
                if (_entity == null || _entity.Enabled == enabledCheck.Checked)
                    return;

                _entity = ProjectManager.Instance.UpdateEntity(
                    _entity,
                    enabledCheck.Checked ? "Enable entity" : "Disable entity",
                    entity => entity.Enabled = enabledCheck.Checked);
                SyncRuntimeEntity();
            };
            _content.Controls.Add(enabledCheck);
            y += 28;

            Divider(ref y);

            SectionHeader("Transform", ref y);
            AddNumberField("Position X", _entity.X, ref y, value =>
                UpdateTransform("Move entity", entity => entity.X = (int)MathF.Round(value)));
            AddNumberField("Position Y", _entity.Y, ref y, value =>
                UpdateTransform("Move entity", entity => entity.Y = (int)MathF.Round(value)));
            AddNumberField("Position Z", _entity.Z, ref y, value =>
                UpdateTransform("Move entity", entity => entity.Z = value));
            AddNumberField("Rotation X", _entity.RotationX, ref y, value =>
                UpdateTransform("Rotate entity", entity => entity.RotationX = value));
            AddNumberField("Rotation Y", _entity.RotationY, ref y, value =>
                UpdateTransform("Rotate entity", entity => entity.RotationY = value));
            AddNumberField("Rotation Z", _entity.RotationZ, ref y, value =>
                UpdateTransform("Rotate entity", entity => entity.RotationZ = value));
            AddNumberField("Scale X", _entity.ScaleX, ref y, value =>
                UpdateTransform("Scale entity", entity => entity.ScaleX = value));
            AddNumberField("Scale Y", _entity.ScaleY, ref y, value =>
                UpdateTransform("Scale entity", entity => entity.ScaleY = value));
            AddNumberField("Scale Z", _entity.ScaleZ, ref y, value =>
                UpdateTransform("Scale entity", entity => entity.ScaleZ = value));

            Divider(ref y);

            // ── Components ────────────────────────────────────────────────────────
            SectionHeader("Components", ref y);
            foreach (ComponentDefinition component in _entity.Components)
                AddComponentCard(component, ref y);

            var addComponentButton = new Button
            {
                Text = "+ Add Component",
                Location = new Point(10, y),
                Size = new Size(222, 28),
                BackColor = EditorTheme.PanelHeader,
                ForeColor = EditorTheme.TextAccent,
                FlatStyle = FlatStyle.Flat,
                Font = EditorTheme.FontUISmall,
                FlatAppearance = { BorderColor = EditorTheme.PanelBorder },
            };
            addComponentButton.Click += (_, _) => ShowAddComponentMenu(addComponentButton);
            _content.Controls.Add(addComponentButton);
            y += 34;

            Divider(ref y);

            // ── Scripts ───────────────────────────────────────────────────────────
            SectionHeader("Scripts", ref y);

            foreach (var script in _entity.Scripts)
                AddScriptRow(script, ref y);

            // Add new script
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

            // Add existing script
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

            // Apply to scene
            var saveBtn = new Button
            {
                Text = "💾 Apply to Scene",
                Location = new Point(10, y),
                Size = new Size(222, 28),
                BackColor = EditorTheme.Accent,
                ForeColor = EditorTheme.TextPrimary,
                FlatStyle = FlatStyle.Flat,
                Font = EditorTheme.FontUISmall,
            };
            saveBtn.Click += (_, _) => ProjectManager.Instance.SaveProject();
            _content.Controls.Add(saveBtn);
        }

        // ── Component cards ───────────────────────────────────────────────────────

        private void AddComponentCard(ComponentDefinition component, ref int y)
        {
            if (_content == null || _entity == null)
                return;

            int cardHeight = 34 + Math.Max(0, component.Properties.Count) * 28;
            var card = new Panel
            {
                Location = new Point(10, y),
                Size = new Size(222, cardHeight),
                BackColor = EditorTheme.BackgroundAlt,
            };

            var enabled = new CheckBox
            {
                Checked = component.Enabled,
                Location = new Point(7, 6),
                Size = new Size(20, 20),
                BackColor = EditorTheme.BackgroundAlt,
            };
            enabled.CheckedChanged += (_, _) =>
            {
                if (_entity == null || enabled.Checked == component.Enabled)
                    return;

                ProjectManager.Instance.UpdateComponent(
                    _entity,
                    component.Id,
                    enabled.Checked ? $"Enable {component.Type}" : $"Disable {component.Type}",
                    target => target.Enabled = enabled.Checked);
            };
            card.Controls.Add(enabled);

            card.Controls.Add(new Label
            {
                Text = component.Type,
                Location = new Point(30, 7),
                Size = new Size(154, 18),
                ForeColor = EditorTheme.TextPrimary,
                Font = EditorTheme.FontUIBold,
            });

            var remove = new Button
            {
                Text = "×",
                Location = new Point(190, 3),
                Size = new Size(26, 25),
                BackColor = EditorTheme.BackgroundAlt,
                ForeColor = EditorTheme.Error,
                FlatStyle = FlatStyle.Flat,
                Font = EditorTheme.FontUI,
                FlatAppearance = { BorderSize = 0 },
            };
            remove.Click += (_, _) =>
            {
                if (_entity != null)
                    ProjectManager.Instance.RemoveComponent(_entity, component.Id);
            };
            card.Controls.Add(remove);

            int propertyY = 32;
            foreach ((string propertyName, string propertyValue) in
                     component.Properties.OrderBy(pair => pair.Key))
            {
                card.Controls.Add(new Label
                {
                    Text = propertyName,
                    Location = new Point(8, propertyY + 3),
                    Size = new Size(82, 18),
                    ForeColor = EditorTheme.TextSecondary,
                    Font = EditorTheme.FontUISmall,
                });

                var valueBox = new TextBox
                {
                    Text = propertyValue,
                    Location = new Point(94, propertyY),
                    Size = new Size(120, 22),
                    BackColor = EditorTheme.Panel,
                    ForeColor = EditorTheme.TextPrimary,
                    BorderStyle = BorderStyle.FixedSingle,
                    Font = EditorTheme.FontUISmall,
                };
                string capturedPropertyName = propertyName;
                valueBox.Validated += (_, _) =>
                {
                    if (_entity == null ||
                        component.Properties.TryGetValue(
                            capturedPropertyName,
                            out string? currentValue) &&
                        currentValue == valueBox.Text)
                    {
                        return;
                    }

                    string newValue = valueBox.Text;
                    ProjectManager.Instance.UpdateComponent(
                        _entity,
                        component.Id,
                        $"Edit {component.Type}.{capturedPropertyName}",
                        target => target.Properties[capturedPropertyName] = newValue);
                };
                card.Controls.Add(valueBox);
                propertyY += 28;
            }

            _content.Controls.Add(card);
            y += cardHeight + 6;
        }

        private void ShowAddComponentMenu(Control anchor)
        {
            if (_entity == null)
                return;

            var menu = new ContextMenuStrip
            {
                Renderer = EditorTheme.MenuRenderer(),
                BackColor = EditorTheme.Panel,
                ForeColor = EditorTheme.TextPrimary,
            };

            foreach (string type in new[]
                     {
                         "Sprite Renderer",
                         "Camera",
                         "Audio Source",
                         "Box Collider 2D",
                         "Rigidbody 2D",
                     })
            {
                var item = new ToolStripMenuItem(type)
                {
                    BackColor = EditorTheme.Panel,
                    ForeColor = EditorTheme.TextPrimary,
                };
                item.Click += (_, _) => AddComponent(type);
                menu.Items.Add(item);
            }

            menu.Items.Add(new ToolStripSeparator());
            var custom = new ToolStripMenuItem("Custom Component…")
            {
                BackColor = EditorTheme.Panel,
                ForeColor = EditorTheme.TextPrimary,
            };
            custom.Click += (_, _) =>
            {
                using var dialog = new RenameDialog("Component Type", "My Component");
                if (dialog.ShowDialog() == DialogResult.OK)
                    AddComponent(dialog.Value);
            };
            menu.Items.Add(custom);
            menu.Show(anchor, new Point(0, anchor.Height));
        }

        private void AddComponent(string type)
        {
            if (_entity == null)
                return;

            ProjectManager.Instance.AddComponent(_entity, type, ComponentDefaults(type));
        }

        private static IReadOnlyDictionary<string, string> ComponentDefaults(string type)
        {
            return type switch
            {
                "Sprite Renderer" => new Dictionary<string, string>
                {
                    ["Sprite"] = "",
                    ["Color"] = "#FFFFFFFF",
                    ["Layer"] = "0",
                },
                "Camera" => new Dictionary<string, string>
                {
                    ["Clear Color"] = "#181A20FF",
                    ["Orthographic Size"] = "5",
                    ["Priority"] = "0",
                },
                "Audio Source" => new Dictionary<string, string>
                {
                    ["Clip"] = "",
                    ["Volume"] = "1",
                    ["Loop"] = "false",
                },
                "Box Collider 2D" => new Dictionary<string, string>
                {
                    ["Size X"] = "1",
                    ["Size Y"] = "1",
                    ["Is Trigger"] = "false",
                },
                "Rigidbody 2D" => new Dictionary<string, string>
                {
                    ["Body Type"] = "Dynamic",
                    ["Mass"] = "1",
                    ["Gravity Scale"] = "1",
                },
                _ => new Dictionary<string, string>(),
            };
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
            string dest = Path.Combine(project.ScriptsPath, Path.GetFileName(dlg.FileName));
            if (!File.Exists(dest) && dlg.FileName != dest)
                File.Copy(dlg.FileName, dest);

            if (!_entity.Scripts.Contains(scriptName))
            {
                ProjectManager.Instance.AttachScript(_entity, scriptName);
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

            ProjectManager.Instance.DetachScript(_entity, scriptName);
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
                Size = new Size(78, 18),
                ForeColor = EditorTheme.TextSecondary,
                Font = EditorTheme.FontUISmall,
            });

            if (editable)
            {
                var box = new TextBox
                {
                    Text = value,
                    Location = new Point(92, y),
                    Size = new Size(142, 22),
                    BackColor = EditorTheme.BackgroundAlt,
                    ForeColor = EditorTheme.TextPrimary,
                    BorderStyle = BorderStyle.FixedSingle,
                    Font = EditorTheme.FontUI,
                };
                box.Validated += (_, _) =>
                {
                    onChange?.Invoke(box.Text);
                };
                _content.Controls.Add(box);
            }
            else
            {
                _content.Controls.Add(new Label
                {
                    Text = value,
                    Location = new Point(92, y + 3),
                    Size = new Size(142, 18),
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

        private void AddNumberField(
            string label,
            float value,
            ref int y,
            Action<float> onChange)
        {
            AddField(
                label,
                value.ToString("0.###", System.Globalization.CultureInfo.InvariantCulture),
                ref y,
                editable: true,
                onChange: text =>
                {
                    if (float.TryParse(
                            text,
                            System.Globalization.NumberStyles.Float,
                            System.Globalization.CultureInfo.InvariantCulture,
                            out float parsed))
                    {
                        if (MathF.Abs(parsed - value) > 0.0001f)
                            onChange(parsed);
                    }
                });
        }

        private void UpdateTransform(
            string description,
            Action<EntityDefinition> update)
        {
            if (_entity == null)
                return;

            _entity = ProjectManager.Instance.UpdateEntity(_entity, description, update);
            SyncRuntimeEntity();
        }

        private void SyncRuntimeEntity()
        {
            if (_entity == null)
                return;

            _host?.SyncEntity(_entity.Name, _entity.X, _entity.Y, _entity.Enabled);
        }

        private void RefreshCurrentEntity()
        {
            if (_entity == null)
                return;

            EntityDefinition? current = ProjectManager.Instance.CurrentProject?.Entities
                .Find(entity => entity.Id == _entity.Id);
            if (current == null)
            {
                _entity = null;
                ShowEmpty();
                return;
            }

            _entity = current;
            Rebuild();
        }
    }
}
