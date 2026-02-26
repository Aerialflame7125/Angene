using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AngeneEditor.Dialogs;
using AngeneEditor.Panels;
using AngeneEditor.Project;
using AngeneEditor.Runtime;
using AngeneEditor.Theme;

namespace AngeneEditor
{
    /// <summary>
    /// Main editor window.
    /// Layout (left→right, top→bottom):
    ///   MenuBar + Toolbar
    ///   [HierarchyPanel] | [PreviewPanel] | [InspectorPanel]
    ///   [ConsolePanel — full width bottom]
    /// </summary>
    public sealed class EditorWindow : Form
    {
        // ── Panels ────────────────────────────────────────────────────────────────
        private HierarchyPanel _hierarchy;
        private InspectorPanel _inspector;
        private ConsolePanel _console;
        private Panel _preview;
        private Panel _previewLabel;

        // ── Toolbar ───────────────────────────────────────────────────────────────
        private Button _playBtn;
        private Button _stopBtn;
        private Label _projectLabel;
        private Label _statusLabel;

        // ── Runtime ───────────────────────────────────────────────────────────────
        private GameHost _host;
        private bool _multiWindowEnabled = true;

        public EditorWindow()
        {
            _host = new GameHost();

            Text = "Angene Editor";
            Size = new Size(1440, 860);
            MinimumSize = new Size(1000, 600);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = EditorTheme.Background;
            ForeColor = EditorTheme.TextPrimary;
            Font = EditorTheme.FontUI;

            BuildMenu();
            BuildToolbar();
            BuildPanels();
            WireEvents();

            _console.AppendEditorLine("Angene Editor initialized.");
            _console.AppendEditorLine("Create or open a project to begin.");
        }

        // ── Menu ──────────────────────────────────────────────────────────────────

        private void BuildMenu()
        {
            var menu = new MenuStrip { Renderer = EditorTheme.MenuRenderer(), BackColor = EditorTheme.PanelHeader };

            var file = AddMenu(menu, "File");
            AddItem(file, "New Project...", Shortcut.CtrlN, OnNewProject);
            AddItem(file, "Open Project...", Shortcut.CtrlO, OnOpenProject);
            file.DropDownItems.Add(new ToolStripSeparator());
            AddItem(file, "Save Scene", Shortcut.CtrlS, (_, _) => ProjectManager.Instance.SaveProject());
            file.DropDownItems.Add(new ToolStripSeparator());
            AddItem(file, "Exit", Shortcut.AltF4, (_, _) => Close());

            var edit = AddMenu(menu, "Edit");
            AddItem(edit, "Add Entity", Shortcut.None, (_, _) => AddEntityPrompt());
            AddItem(edit, "Add Script...", Shortcut.None, (_, _) => AddScriptPrompt());

            var run = AddMenu(menu, "Run");
            AddItem(run, "▶  Play", Shortcut.F5, (_, _) => Play());
            AddItem(run, "■  Stop", Shortcut.ShiftF5, (_, _) => Stop());
            run.DropDownItems.Add(new ToolStripSeparator());
            AddItem(run, "Play with --verbose", Shortcut.None, (_, _) => Play(verbose: true));

            var view = AddMenu(menu, "View");
            var mwItem = new ToolStripMenuItem("Multi-Window Mode") { Checked = true, CheckOnClick = true };
            mwItem.CheckedChanged += (_, _) => _multiWindowEnabled = mwItem.Checked;
            view.DropDownItems.Add(mwItem);

            Controls.Add(menu);
            MainMenuStrip = menu;
        }

        // ── Toolbar ───────────────────────────────────────────────────────────────

        private void BuildToolbar()
        {
            var toolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 42,
                BackColor = EditorTheme.PanelHeader,
                Padding = new Padding(6, 6, 6, 0),
            };

            _playBtn = ToolBtn("▶  Play", EditorTheme.Success, new Point(6, 6));
            _playBtn.Click += (_, _) => Play();

            _stopBtn = ToolBtn("■  Stop", EditorTheme.Error, new Point(116, 6));
            _stopBtn.Enabled = false;
            _stopBtn.Click += (_, _) => Stop();

            var saveBtn = ToolBtn("💾 Save Scene", EditorTheme.AccentDim, new Point(226, 6));
            saveBtn.Click += (_, _) => ProjectManager.Instance.SaveProject();

            _projectLabel = new Label
            {
                Text = "No project",
                Location = new Point(360, 12),
                Size = new Size(400, 18),
                ForeColor = EditorTheme.TextSecondary,
                Font = EditorTheme.FontUI,
            };

            _statusLabel = new Label
            {
                Text = "",
                Location = new Point(800, 12),
                Size = new Size(300, 18),
                ForeColor = EditorTheme.TextDisabled,
                Font = EditorTheme.FontUISmall,
            };

            toolbar.Controls.AddRange(new Control[] { _playBtn, _stopBtn, saveBtn, _projectLabel, _statusLabel });
            Controls.Add(toolbar);
        }

        // ── Panels ────────────────────────────────────────────────────────────────

        private void BuildPanels()
        {
            _console = new ConsolePanel();
            _hierarchy = new HierarchyPanel();
            _inspector = new InspectorPanel();

            // Splitter between hierarchy and preview
            var splitterL = new Splitter { Dock = DockStyle.Left, Width = 4, BackColor = EditorTheme.PanelBorder };
            var splitterR = new Splitter { Dock = DockStyle.Right, Width = 4, BackColor = EditorTheme.PanelBorder };
            var splitterB = new Splitter { Dock = DockStyle.Bottom, Height = 4, BackColor = EditorTheme.PanelBorder };

            // Preview panel (center — game window embeds here)
            _preview = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(10, 10, 14),
            };

            // Preview placeholder label
            _previewLabel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(10, 10, 14),
            };
            var placeholderLbl = new Label
            {
                Text = "No game running\n\nPress ▶ Play to launch",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = EditorTheme.TextDisabled,
                Font = new Font("Segoe UI", 13f, FontStyle.Regular),
                BackColor = Color.Transparent,
            };
            _previewLabel.Controls.Add(placeholderLbl);
            _preview.Controls.Add(_previewLabel);

            // Border around preview
            _preview.Paint += (_, e) =>
            {
                using var pen = new Pen(EditorTheme.PanelBorder, 1);
                e.Graphics.DrawRectangle(pen, 0, 0, _preview.Width - 1, _preview.Height - 1);
            };

            Controls.Add(_preview);
            Controls.Add(splitterL);
            Controls.Add(_hierarchy);
            Controls.Add(splitterR);
            Controls.Add(_inspector);
            Controls.Add(splitterB);
            Controls.Add(_console);
        }

        // ── Event wiring ──────────────────────────────────────────────────────────

        private void WireEvents()
        {
            _hierarchy.EntitySelected += _inspector.ShowEntity;
            _hierarchy.EntityDoubleClicked += OnEntityDoubleClicked;

            var pm = ProjectManager.Instance;
            pm.ProjectOpened += p =>
            {
                _projectLabel.Text = $"Project: {p.Name}  ({p.RootPath})";
                _console.AppendEditorLine($"Project opened: {p.Name}");
            };
            pm.ProjectSaved += () =>
            {
                _console.AppendEditorLine("Scene saved to Init.cs.");
                SetStatus("Saved.");
            };

            _host.GameStarted += OnGameStarted;
            _host.GameStopped += OnGameStopped;
            _host.LogLine += _console.AppendLine;
            _host.MultiWindowWarning += OnMultiWindow;

            FormClosing += (_, _) => _host.Stop();
        }

        // ── File actions ──────────────────────────────────────────────────────────

        private void OnNewProject(object? s, EventArgs e)
        {
            using var dlg = new NewProjectDialog();
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                var project = ProjectManager.Instance.CreateProject(dlg.ProjectName, dlg.ProjectDir);
                _console.AppendEditorLine($"Project created: {project.RootPath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create project:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnOpenProject(object? s, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Open Angene Project",
                Filter = "C# Project (*.csproj)|*.csproj",
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            var project = ProjectManager.Instance.OpenProject(dlg.FileName);
            if (project == null)
                MessageBox.Show("Failed to open project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ── Entity / script prompts ───────────────────────────────────────────────

        private void AddEntityPrompt()
        {
            if (ProjectManager.Instance.CurrentProject == null)
            { MessageBox.Show("No project open.", "Error"); return; }

            using var dlg = new RenameDialog("New Entity Name", "Entity");
            if (dlg.ShowDialog() == DialogResult.OK)
                ProjectManager.Instance.AddEntity(dlg.Value);
        }

        private void AddScriptPrompt()
        {
            _console.AppendEditorLine("Select an entity in the hierarchy, then use its context menu to add a script.");
        }

        private void OnEntityDoubleClicked(EntityDefinition entity)
        {
            // Double-click entity → open first script if any
            if (entity.Scripts.Count == 0) return;
            string scriptName = entity.Scripts[0];
            string? path = FindScriptPath(scriptName);
            if (path != null)
                new ScriptEditor.ScriptEditorWindow(path).Show(this);
        }

        private string? FindScriptPath(string scriptName)
        {
            var project = ProjectManager.Instance.CurrentProject;
            if (project == null) return null;
            string path = Path.Combine(project.ScriptsPath, $"{scriptName}.cs");
            return File.Exists(path) ? path : null;
        }

        // ── Play / Stop ───────────────────────────────────────────────────────────

        private void Play(bool verbose = false)
        {
            var project = ProjectManager.Instance.CurrentProject;
            if (project == null)
            { MessageBox.Show("No project open.", "Error"); return; }

            // Save before running
            ProjectManager.Instance.SaveProject();

            _previewLabel.Visible = false;
            _host.Launch(project.RootPath, _preview, verbose);
        }

        private void Stop()
        {
            _host.Stop();
            _previewLabel.Visible = true;
        }

        private void OnGameStarted()
        {
            if (InvokeRequired) { Invoke(OnGameStarted); return; }
            _playBtn.Enabled = false;
            _stopBtn.Enabled = true;
            SetStatus("Running");
        }

        private void OnGameStopped()
        {
            if (InvokeRequired) { Invoke(OnGameStopped); return; }
            _playBtn.Enabled = true;
            _stopBtn.Enabled = false;
            _previewLabel.Visible = true;
            SetStatus("Stopped");
        }

        // ── Multi-window warning ──────────────────────────────────────────────────

        private void OnMultiWindow(int count)
        {
            if (InvokeRequired) { Invoke(() => OnMultiWindow(count)); return; }
            if (!_multiWindowEnabled) return;

            using var dlg = new MultiWindowDialog(count);
            if (dlg.ShowDialog(this) == DialogResult.No)
            {
                _multiWindowEnabled = false;
                _console.AppendEditorLine("Multi-window mode disabled. Only primary window shown in preview.");
            }
            else
            {
                _console.AppendEditorLine($"Multi-window mode active. {count} windows detected — secondary shown externally.");
            }
        }

        // ── Helpers ───────────────────────────────────────────────────────────────

        private void SetStatus(string text)
        {
            _statusLabel.Text = $"● {text}  {DateTime.Now:HH:mm:ss}";
        }

        private static Button ToolBtn(string text, Color back, Point loc)
        {
            var btn = new Button
            {
                Text = text,
                BackColor = back,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = loc,
                Size = new Size(100, 28),
                Font = EditorTheme.FontUIBold,
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(back, 0.1f);
            btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(back, 0.1f);

            return btn;
        }

        private static ToolStripMenuItem AddMenu(MenuStrip bar, string text)
        {
            var item = new ToolStripMenuItem(text)
            { BackColor = EditorTheme.PanelHeader, ForeColor = EditorTheme.TextPrimary };
            bar.Items.Add(item);
            return item;
        }

        private static void AddItem(ToolStripMenuItem parent, string text,
            Shortcut shortcut, EventHandler handler)
        {
            var item = new ToolStripMenuItem(text, null, handler)
            {
                BackColor = EditorTheme.Panel,
                ForeColor = EditorTheme.TextPrimary,
                ShortcutKeys = (Keys)shortcut,
            };
            parent.DropDownItems.Add(item);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _host.Dispose();
            base.OnFormClosed(e);
        }
    }
}