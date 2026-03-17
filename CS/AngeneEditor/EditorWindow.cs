using Angene.Essentials;
using AngeneEditor.Dialogs;
using AngeneEditor.Panels;
using AngeneEditor.Project;
using AngeneEditor.Runtime;
using AngeneEditor.Theme;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngeneEditor
{
    public sealed class EditorWindow : Form
    {
        // ── Panels ────────────────────────────────────────────────────────────────
        private HierarchyPanel? _hierarchy;
        private InspectorPanel? _inspector;
        private ConsolePanel? _console;
        private Panel? _preview;
        private Panel? _previewLabel;

        // ── Toolbar ───────────────────────────────────────────────────────────────
        private Button? _playBtn;
        private Button? _stopBtn;
        private Label? _projectLabel;
        private Label? _statusLabel;

        // ── Runtime ───────────────────────────────────────────────────────────────
        private readonly EditorSceneHost _sceneHost = new();
        private readonly BuildLogWindow _buildLog = new();

        public EditorWindow()
        {
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

            _console?.AppendEditorLine("Angene Editor initialized.");
            _console?.AppendEditorLine("Create or open a project to begin.");
        }

        // ── Menu ──────────────────────────────────────────────────────────────────

        private void BuildMenu()
        {
            var menu = new MenuStrip
            {
                Renderer = EditorTheme.MenuRenderer(),
                BackColor = EditorTheme.PanelHeader,
            };

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
            AddItem(run, "▶  Play", Shortcut.F5, (_, _) => _ = PlayAsync());
            AddItem(run, "■  Stop", Shortcut.ShiftF5, (_, _) => Stop());
            run.DropDownItems.Add(new ToolStripSeparator());
            AddItem(run, "▶  Edit Preview", Shortcut.None, (_, _) => _ = LoadEditPreviewAsync());

            var view = AddMenu(menu, "View");
            AddItem(view, "Build Log", Shortcut.None, (_, _) => _buildLog.ShowAndFocus());

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
            _playBtn.Click += (_, _) => _ = PlayAsync();

            _stopBtn = ToolBtn("■  Stop", EditorTheme.Error, new Point(116, 6));
            _stopBtn.Enabled = false;
            _stopBtn.Click += (_, _) => Stop();

            var saveBtn = ToolBtn("💾 Save", EditorTheme.AccentDim, new Point(226, 6));
            saveBtn.Click += (_, _) => ProjectManager.Instance.SaveProject();

            var logBtn = ToolBtn("📋 Log", EditorTheme.PanelHeader, new Point(336, 6));
            logBtn.ForeColor = EditorTheme.TextSecondary;
            logBtn.Click += (_, _) => _buildLog.ShowAndFocus();

            _projectLabel = new Label
            {
                Text = "No project",
                Location = new Point(450, 12),
                Size = new Size(400, 18),
                ForeColor = EditorTheme.TextSecondary,
                Font = EditorTheme.FontUI,
            };

            _statusLabel = new Label
            {
                Text = "",
                Location = new Point(860, 12),
                Size = new Size(300, 18),
                ForeColor = EditorTheme.TextDisabled,
                Font = EditorTheme.FontUISmall,
            };

            toolbar.Controls.AddRange(
                new Control[] { _playBtn, _stopBtn, saveBtn, logBtn, _projectLabel, _statusLabel });
            Controls.Add(toolbar);
        }

        // ── Panels ────────────────────────────────────────────────────────────────

        private void BuildPanels()
        {
            _console = new ConsolePanel();
            _hierarchy = new HierarchyPanel();
            _inspector = new InspectorPanel();

            var splitterL = new Splitter { Dock = DockStyle.Left, Width = 4, BackColor = EditorTheme.PanelBorder };
            var splitterR = new Splitter { Dock = DockStyle.Right, Width = 4, BackColor = EditorTheme.PanelBorder };
            var splitterB = new Splitter { Dock = DockStyle.Bottom, Height = 4, BackColor = EditorTheme.PanelBorder };

            _preview = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(10, 10, 14) };

            _previewLabel = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(10, 10, 14) };
            _previewLabel.Controls.Add(new Label
            {
                Text = "No game running\n\nPress ▶ Play to launch",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = EditorTheme.TextDisabled,
                Font = new Font("Segoe UI", 13f),
                BackColor = Color.Transparent,
            });
            _preview.Controls.Add(_previewLabel);

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

            _inspector.SetHost(_sceneHost);

            // Route scene host log to both the bottom console panel and the floating log window
            _sceneHost.Log += line =>
            {
                _console.AppendLine(line);
                _buildLog.AppendLine(line);
            };
        }

        // ── Event wiring ──────────────────────────────────────────────────────────

        private void WireEvents()
        {
            _hierarchy!.EntitySelected += entity =>
            {
                _inspector!.ShowEntity(entity);
                _sceneHost.SelectEntity(_sceneHost.FindEntity(entity.Name));
            };

            _hierarchy.EntityDoubleClicked += OnEntityDoubleClicked;

            var pm = ProjectManager.Instance;
            pm.ProjectOpened += p =>
            {
                _projectLabel!.Text = $"Project: {p.Name}  ({p.RootPath})";
                _console!.AppendEditorLine($"Project opened: {p.Name}");
            };
            pm.ProjectSaved += () =>
            {
                _console!.AppendEditorLine("Scene saved to Init.cs.");
                SetStatus("Saved.");
            };

            FormClosing += (_, _) => _sceneHost.Dispose();
        }

        // ── File actions ──────────────────────────────────────────────────────────

        private void OnNewProject(object? s, EventArgs e)
        {
            using var dlg = new NewProjectDialog();
            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                var p = ProjectManager.Instance.CreateProject(dlg.ProjectName, dlg.ProjectDir);
                _console!.AppendEditorLine($"Project created: {p.RootPath}");
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
            if (ProjectManager.Instance.OpenProject(dlg.FileName) == null)
                MessageBox.Show("Failed to open project.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AddEntityPrompt()
        {
            if (ProjectManager.Instance.CurrentProject == null)
            { MessageBox.Show("No project open.", "Error"); return; }
            using var dlg = new RenameDialog("New Entity Name", "Entity");
            if (dlg.ShowDialog() == DialogResult.OK)
                ProjectManager.Instance.AddEntity(dlg.Value);
        }

        private void AddScriptPrompt() =>
            _console!.AppendEditorLine("Select an entity in the hierarchy, then use its context menu to add a script.");

        private void OnEntityDoubleClicked(EntityDefinition entity)
        {
            if (entity.Scripts.Count == 0) return;
            string? path = FindScriptPath(entity.Scripts[0]);
            if (path != null) new ScriptEditor.ScriptEditorWindow(path).Show(this);
        }

        private string? FindScriptPath(string scriptName)
        {
            var project = ProjectManager.Instance.CurrentProject;
            if (project == null) return null;
            string path = Path.Combine(project.ScriptsPath, $"{scriptName}.cs");
            return File.Exists(path) ? path : null;
        }

        // ── Play / Stop ───────────────────────────────────────────────────────────

        private async Task PlayAsync()
        {
            var project = ProjectManager.Instance.CurrentProject;
            if (project == null) { MessageBox.Show("No project open.", "Error"); return; }

            SetPlayButtonsEnabled(false);
            SetStatus("Building…");
            ProjectManager.Instance.SaveProject();

            bool ok = await BuildAsync(project.RootPath);
            if (!ok) { SetPlayButtonsEnabled(true); return; }

            _previewLabel!.Visible = false;
            _sceneHost.Load(project.RootPath, _preview!);
            _sceneHost.SetMode(EngineMode.Play);

            _playBtn!.Enabled = false;
            _stopBtn!.Enabled = true;
            SetStatus("Running");
        }

        private async Task LoadEditPreviewAsync()
        {
            var project = ProjectManager.Instance.CurrentProject;
            if (project == null) { MessageBox.Show("No project open.", "Error"); return; }

            SetPlayButtonsEnabled(false);
            SetStatus("Building…");
            ProjectManager.Instance.SaveProject();

            bool ok = await BuildAsync(project.RootPath);
            if (!ok) { SetPlayButtonsEnabled(true); return; }

            _previewLabel!.Visible = false;
            _sceneHost.Load(project.RootPath, _preview!);
            _sceneHost.SetMode(EngineMode.Edit);

            _playBtn!.Enabled = true;
            _stopBtn!.Enabled = true;
            SetStatus("Editing (Preview)");
        }

        private void Stop()
        {
            _sceneHost.Unload();
            _previewLabel!.Visible = true;
            SetPlayButtonsEnabled(true);
            _stopBtn!.Enabled = false;
            SetStatus("Stopped");
        }

        private void SetPlayButtonsEnabled(bool enabled)
        {
            if (InvokeRequired) { BeginInvoke(() => SetPlayButtonsEnabled(enabled)); return; }
            if (_playBtn != null) _playBtn.Enabled = enabled;
        }

        // ── Async build ───────────────────────────────────────────────────────────

        /// <summary>
        /// Builds the project on a background thread so the UI never freezes.
        /// Every stdout/stderr line is forwarded live to the BuildLogWindow.
        /// </summary>
        private async Task<bool> BuildAsync(string projectDir)
        {
            var project = ProjectManager.Instance.CurrentProject;
            _buildLog.BeginBuild(project?.Name ?? Path.GetFileName(projectDir));

            var psi = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "build --configuration Debug",
                WorkingDirectory = projectDir,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,

                // Force UTF-8 output so Japanese / CJK characters aren't mojibaked
                StandardOutputEncoding = System.Text.Encoding.UTF8,
                StandardErrorEncoding = System.Text.Encoding.UTF8,
            };

            // Tell dotnet to use UTF-8 console output regardless of system locale
            psi.Environment["DOTNET_CLI_UI_LANGUAGE"] = "en-US";
            psi.Environment["DOTNET_SYSTEM_CONSOLE_ALLOW_ANSI_COLOR_REDIRECTION"] = "1";
            psi.Environment["TERM"] = "xterm-256color";

            int exitCode = -1;

            await Task.Run(() =>
            {
                using var proc = new Process { StartInfo = psi };

                proc.OutputDataReceived += (_, e) =>
                {
                    if (e.Data == null) return;
                    _buildLog.AppendLine(e.Data);
                    _console!.AppendLine(e.Data);
                };
                proc.ErrorDataReceived += (_, e) =>
                {
                    if (e.Data == null) return;
                    _buildLog.AppendLine($"[ERR] {e.Data}");
                    _console!.AppendLine($"[ERR] {e.Data}");
                };

                proc.Start();
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
                proc.WaitForExit();
                exitCode = proc.ExitCode;
            });

            bool success = exitCode == 0;
            _buildLog.EndBuild(success, exitCode);
            SetStatus(success ? "Build succeeded" : "Build failed — see Log");
            return success;
        }

        // ── Helpers ───────────────────────────────────────────────────────────────

        private void SetStatus(string text)
        {
            if (InvokeRequired) { BeginInvoke(() => SetStatus(text)); return; }
            _statusLabel!.Text = $"● {text}  {DateTime.Now:HH:mm:ss}";
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
            _sceneHost.Dispose();
            base.OnFormClosed(e);
        }
    }
}