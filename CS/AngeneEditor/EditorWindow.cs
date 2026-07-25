using Angene.Essentials;
using AngeneEditor.Dialogs;
using AngeneEditor.Panels;
using AngeneEditor.Project;
using AngeneEditor.Runtime;
using AngeneEditor.Theme;
using AngeneEditor.Workspace;
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
        private SolutionExplorerPanel? _solutionExplorer;
        private Panel? _preview;
        private SceneViewportPanel? _sceneViewport;
        private Panel? _gamePreview;
        private Panel? _gamePreviewLabel;
        private TabControl? _viewTabs;

        // ── Toolbar ───────────────────────────────────────────────────────────────
        private Button? _playBtn;
        private Button? _pauseBtn;
        private Button? _stepBtn;
        private Button? _stopBtn;
        private Label? _projectLabel;
        private Label? _statusLabel;

        // ── Runtime ───────────────────────────────────────────────────────────────
        private readonly EditorSceneHost _sceneHost = new();
        private readonly BuildLogWindow _buildLog = new();
        private readonly EditorLayoutStore _layoutStore = new();
        private readonly EditorSettingsStore _settingsStore = new();
        private EditorSettings _settings = new();
        private ToolStripMenuItem? _openRecentItem;
        private AutosaveService? _autosave;
        private Process? _externalProcess;
        private bool _isPlaying;
        private bool _isPaused;
        private bool _closingConfirmed;

        public EditorWindow()
        {
            Text = "Angene Editor";
            Size = new Size(1600, 900);
            MinimumSize = new Size(1100, 650);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = EditorTheme.Background;
            ForeColor = EditorTheme.TextPrimary;
            Font = EditorTheme.FontUI;

            _settings = _settingsStore.Load() ?? new EditorSettings();
            BuildMenu();
            BuildToolbar();
            BuildPanels();
            ApplySavedLayout();
            WireEvents();

            _console?.AppendEditorLine("Angene Editor initialized.");
            _console?.AppendEditorLine("Create or open a project to begin.");

            _autosave = new AutosaveService(ProjectManager.Instance);
            _autosave.SnapshotSaved += () => SetStatus("Recovery snapshot saved");
            _autosave.SnapshotFailed += error =>
                _console?.AppendEditorLine($"Autosave failed: {error.Message}");
            _autosave.Start();
        }

        // ── Menu ──────────────────────────────────────────────────────────────────

        private void BuildMenu()
        {
            var menu = new MenuStrip
            {
                Renderer = EditorTheme.MenuRenderer(),
                BackColor = EditorTheme.PanelHeader,
            };

            // File
            var file = AddMenu(menu, "File");
            AddItem(file, "New Project...", Shortcut.CtrlN, OnNewProject);
            AddItem(file, "Open Project...", Shortcut.CtrlO, OnOpenProject);
            _openRecentItem = AddItem(
                file,
                "Open Recent",
                Shortcut.None,
                (_, _) => OpenRecentProject());
            UpdateRecentMenu();
            file.DropDownItems.Add(new ToolStripSeparator());
            AddItem(file, "Save Scene", Shortcut.CtrlS, (_, _) => ProjectManager.Instance.SaveProject());
            file.DropDownItems.Add(new ToolStripSeparator());
            AddItem(file, "Exit", Shortcut.AltF4, (_, _) => Close());

            // Edit
            var edit = AddMenu(menu, "Edit");
            AddItem(edit, "Undo", Shortcut.CtrlZ, (_, _) => ProjectManager.Instance.Undo());
            AddItem(edit, "Redo", Shortcut.CtrlY, (_, _) => ProjectManager.Instance.Redo());
            edit.DropDownItems.Add(new ToolStripSeparator());
            AddItem(edit, "Add Entity", Shortcut.None, (_, _) => AddEntityPrompt());
            AddItem(edit, "Add Script...", Shortcut.None, (_, _) => AddScriptPrompt());

            // Run
            var run = AddMenu(menu, "Run");
            AddItem(run, "Play In Editor", Shortcut.F5, (_, _) => _ = PlayAsync());
            AddItem(run, "Pause / Resume", Shortcut.None, (_, _) => PauseOrResume());
            AddItem(run, "Step One Frame", Shortcut.None, (_, _) => StepFrame());
            AddItem(run, "Stop", Shortcut.ShiftF5, (_, _) => Stop());
            run.DropDownItems.Add(new ToolStripSeparator());
            AddItem(run, "Edit Preview", Shortcut.None, (_, _) => _ = LoadEditPreviewAsync());
            AddItem(run, "Run External Build...", Shortcut.None, (_, _) => _ = RunExternalAsync());

            // Open In (formerly scattered around Inspector)
            var openIn = AddMenu(menu, "Open In");
            AddItem(openIn, "Program.cs in Script Editor", Shortcut.None,
                (_, _) => ScriptEditor.ScriptEditorWindow.OpenProgramCs(this));
            AddItem(openIn, "Init.cs in Script Editor", Shortcut.None, OpenInitCs);
            openIn.DropDownItems.Add(new ToolStripSeparator());
            AddItem(openIn, "Open Project in Visual Studio", Shortcut.None,
                (_, _) => ScriptEditor.ScriptEditorWindow.OpenCsprojInVs(this));
            AddItem(openIn, "Open Project Folder in Explorer", Shortcut.None, OpenProjectFolder);

            // View
            var view = AddMenu(menu, "View");
            AddItem(view, "Build Log", Shortcut.None, (_, _) => _buildLog.ShowAndFocus());
            AddItem(view, "Refresh Solution Explorer", Shortcut.None, (_, _) => _solutionExplorer?.Refresh());
            view.DropDownItems.Add(new ToolStripSeparator());
            AddItem(view, "Frame Selected", Shortcut.None, (_, _) => _sceneViewport?.FrameSelected());
            AddItem(view, "Frame All", Shortcut.None, (_, _) => _sceneViewport?.FrameAll());
            AddItem(view, "Toggle Grid", Shortcut.None, (_, _) => _sceneViewport?.ToggleGrid());
            AddItem(view, "Toggle Snapping", Shortcut.None, (_, _) => _sceneViewport?.ToggleSnap());
            view.DropDownItems.Add(new ToolStripSeparator());
            AddItem(view, "Reset Layout", Shortcut.None, (_, _) => ResetLayout());

            var tools = AddMenu(menu, "Tools");
            AddItem(tools, "Select .NET SDK...", Shortcut.None, (_, _) => SelectDotnetSdk());
            AddItem(tools, "Auto-detect .NET SDK", Shortcut.None, (_, _) => AutoDetectDotnetSdk());

            Controls.Add(menu);
            MainMenuStrip = menu;
        }

        private void OpenInitCs(object? s, EventArgs e)
        {
            var project = ProjectManager.Instance.CurrentProject;
            if (project == null) { MessageBox.Show("No project open.", "Error"); return; }
            string path = Path.Combine(project.ScenesPath, "Init.cs");
            if (!File.Exists(path)) { MessageBox.Show("Init.cs not found.", "Not Found"); return; }
            new ScriptEditor.ScriptEditorWindow(path).Show(this);
        }

        private void OpenProjectFolder(object? s, EventArgs e)
        {
            var project = ProjectManager.Instance.CurrentProject;
            if (project == null || !Directory.Exists(project.RootPath)) return;
            Process.Start("explorer.exe", project.RootPath);
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

            _playBtn = ToolBtn("Play", EditorTheme.Success, new Point(6, 6));
            _playBtn.Click += (_, _) => _ = PlayAsync();

            _pauseBtn = ToolBtn("Pause", EditorTheme.AccentDim, new Point(112, 6));
            _pauseBtn.Enabled = false;
            _pauseBtn.Click += (_, _) => PauseOrResume();

            _stepBtn = ToolBtn("Step", EditorTheme.PanelHeader, new Point(218, 6));
            _stepBtn.Enabled = false;
            _stepBtn.Click += (_, _) => StepFrame();

            _stopBtn = ToolBtn("Stop", EditorTheme.Error, new Point(324, 6));
            _stopBtn.Enabled = false;
            _stopBtn.Click += (_, _) => Stop();

            var saveBtn = ToolBtn("Save", EditorTheme.AccentDim, new Point(430, 6));
            saveBtn.Click += (_, _) => ProjectManager.Instance.SaveProject();

            var logBtn = ToolBtn("Log", EditorTheme.PanelHeader, new Point(536, 6));
            logBtn.ForeColor = EditorTheme.TextSecondary;
            logBtn.Click += (_, _) => _buildLog.ShowAndFocus();

            _projectLabel = new Label
            {
                Text = "No project",
                Location = new Point(648, 12),
                Size = new Size(460, 18),
                ForeColor = EditorTheme.TextSecondary,
                Font = EditorTheme.FontUI,
            };

            _statusLabel = new Label
            {
                Text = "",
                Location = new Point(1110, 12),
                Size = new Size(300, 18),
                ForeColor = EditorTheme.TextDisabled,
                Font = EditorTheme.FontUISmall,
            };

            toolbar.Controls.AddRange(
                new Control[]
                {
                    _playBtn,
                    _pauseBtn,
                    _stepBtn,
                    _stopBtn,
                    saveBtn,
                    logBtn,
                    _projectLabel,
                    _statusLabel,
                });
            Controls.Add(toolbar);
        }

        // ── Panels ────────────────────────────────────────────────────────────────

        private void BuildPanels()
        {
            _console = new ConsolePanel();
            _hierarchy = new HierarchyPanel();
            _inspector = new InspectorPanel();
            _solutionExplorer = new SolutionExplorerPanel();

            var splitterL1 = new Splitter { Dock = DockStyle.Left, Width = 4, BackColor = EditorTheme.PanelBorder };
            var splitterL2 = new Splitter { Dock = DockStyle.Left, Width = 4, BackColor = EditorTheme.PanelBorder };
            var splitterR = new Splitter { Dock = DockStyle.Right, Width = 4, BackColor = EditorTheme.PanelBorder };
            var splitterB = new Splitter { Dock = DockStyle.Bottom, Height = 4, BackColor = EditorTheme.PanelBorder };

            _viewTabs = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = EditorTheme.FontUI,
            };

            var sceneTab = new TabPage("Scene View")
            {
                BackColor = Color.FromArgb(10, 10, 14),
                Padding = new Padding(0),
            };
            var gameTab = new TabPage("Game View")
            {
                BackColor = Color.FromArgb(10, 10, 14),
                Padding = new Padding(0),
            };

            _preview = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(10, 10, 14) };
            _sceneViewport = new SceneViewportPanel();
            _preview.Controls.Add(_sceneViewport);
            sceneTab.Controls.Add(_preview);

            _gamePreview = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(10, 10, 14) };
            _gamePreviewLabel = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(10, 10, 14) };
            _gamePreviewLabel.Controls.Add(new Label
            {
                Text = "GAME VIEW\n\nPress Play to build and run an isolated scene copy.",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = EditorTheme.TextDisabled,
                Font = new Font("Segoe UI", 13f),
                BackColor = Color.Transparent,
            });
            _gamePreview.Controls.Add(_gamePreviewLabel);
            gameTab.Controls.Add(_gamePreview);

            _viewTabs.TabPages.Add(sceneTab);
            _viewTabs.TabPages.Add(gameTab);

            _preview.Paint += (_, e) =>
            {
                using var pen = new Pen(EditorTheme.PanelBorder, 1);
                e.Graphics.DrawRectangle(pen, 0, 0, _preview.Width - 1, _preview.Height - 1);
            };

            _gamePreview.Paint += (_, e) =>
            {
                using var pen = new Pen(EditorTheme.PanelBorder, 1);
                e.Graphics.DrawRectangle(pen, 0, 0, _gamePreview.Width - 1, _gamePreview.Height - 1);
            };

            Controls.Add(_viewTabs);
            Controls.Add(splitterR);
            Controls.Add(_inspector);
            Controls.Add(splitterL2);
            Controls.Add(_hierarchy);
            Controls.Add(splitterL1);
            Controls.Add(_solutionExplorer);
            Controls.Add(splitterB);
            Controls.Add(_console);

            _inspector.SetHost(_sceneHost);

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
                _sceneViewport!.SelectEntity(entity);
                _sceneHost.SelectEntity(_sceneHost.FindEntity(entity.Name));
            };

            _hierarchy.EntityDoubleClicked += OnEntityDoubleClicked;
            _sceneViewport!.EntitySelected += entity =>
            {
                _hierarchy.SelectEntity(entity?.Id);
                if (entity != null)
                    _inspector!.ShowEntity(entity);
            };

            var pm = ProjectManager.Instance;
            pm.ProjectOpened += p =>
            {
                _projectLabel!.Text = $"Project: {p.Name}  ({p.RootPath})";
                _console!.AppendEditorLine($"Project opened: {p.Name}");
                Text = $"Angene Editor — {p.Name}";
                SetPlaybackState(isPlaying: false, isPaused: false);
                _sceneViewport.FrameAll();
                OfferRecoveryRestore();
            };
            pm.ProjectSaved += () =>
            {
                _console!.AppendEditorLine("Scene and generated Init.cs saved.");
                SetStatus("Saved.");
            };
            pm.DirtyStateChanged += dirty =>
            {
                AngeneProject? project = pm.CurrentProject;
                Text = project == null
                    ? "Angene Editor"
                    : $"Angene Editor — {project.Name}{(dirty ? " *" : "")}";
            };

            FormClosing += OnEditorFormClosing;
        }

        // ── File actions ──────────────────────────────────────────────────────────

        private void OnNewProject(object? s, EventArgs e)
        {
            using var dlg = new NewProjectDialog();
            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                var p = ProjectManager.Instance.CreateProject(dlg.ProjectName, dlg.ProjectDir);
                RememberProject(p.CsprojPath);
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
            else
                RememberProject(dlg.FileName);
        }

        private void OpenRecentProject()
        {
            string? path = _settings.LastProjectPath;
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                MessageBox.Show(
                    "The recent project is no longer available.",
                    "Open Recent",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _settings.LastProjectPath = null;
                _settingsStore.Save(_settings);
                UpdateRecentMenu();
                return;
            }

            if (ProjectManager.Instance.OpenProject(path) == null)
            {
                MessageBox.Show(
                    "Failed to open the recent project.",
                    "Open Recent",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            RememberProject(path);
        }

        private void RememberProject(string csprojPath)
        {
            _settings.LastProjectPath = Path.GetFullPath(csprojPath);
            _settingsStore.Save(_settings);
            UpdateRecentMenu();
        }

        private void UpdateRecentMenu()
        {
            if (_openRecentItem == null)
                return;

            string? path = _settings.LastProjectPath;
            bool available = !string.IsNullOrWhiteSpace(path) && File.Exists(path);
            _openRecentItem.Enabled = available;
            _openRecentItem.Text = available
                ? $"Open Recent — {Path.GetFileNameWithoutExtension(path)}"
                : "Open Recent";
        }

        private void SelectDotnetSdk()
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Select the .NET SDK host",
                Filter = ".NET host (dotnet.exe)|dotnet.exe|Executables (*.exe)|*.exe",
                FileName = "dotnet.exe",
            };
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            if (!DotnetSdkLocator.HasSdk(dialog.FileName))
            {
                MessageBox.Show(
                    "That dotnet host does not report an installed SDK.",
                    ".NET SDK Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _settings.DotnetHostPath = Path.GetFullPath(dialog.FileName);
            _settingsStore.Save(_settings);
            SetStatus($".NET SDK: {_settings.DotnetHostPath}");
        }

        private void AutoDetectDotnetSdk()
        {
            _settings.DotnetHostPath = null;
            string? resolved = DotnetSdkLocator.Resolve(null);
            if (resolved == null)
            {
                MessageBox.Show(
                    "No .NET SDK was detected. Use Tools → Select .NET SDK to choose dotnet.exe.",
                    ".NET SDK Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            _settings.DotnetHostPath = resolved;
            _settingsStore.Save(_settings);
            SetStatus($".NET SDK: {resolved}");
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
            AngeneProject? project = ProjectManager.Instance.CurrentProject;
            if (project == null)
            {
                MessageBox.Show("No project open.", "Error");
                return;
            }

            if (_isPlaying)
            {
                if (_isPaused)
                    PauseOrResume();
                return;
            }

            SetPlayButtonsEnabled(false);
            SetStatus("Building isolated play scene…");
            ProjectManager.Instance.SaveProject();

            bool built = await BuildAsync(project.RootPath);
            if (!built)
            {
                SetPlaybackState(isPlaying: false, isPaused: false);
                return;
            }

            _sceneHost.Unload();
            _gamePreviewLabel!.Visible = false;
            _sceneHost.Load(project.RootPath, _gamePreview!);
            if (!_sceneHost.IsLoaded)
            {
                _gamePreviewLabel.Visible = true;
                SetPlaybackState(isPlaying: false, isPaused: false);
                SetStatus("Play scene failed to load");
                return;
            }

            _sceneHost.SetMode(EngineMode.Play);
            _viewTabs!.SelectedIndex = 1;
            SetPlaybackState(isPlaying: true, isPaused: false);
            SetStatus("Playing (isolated)");
            _console?.AppendEditorLine(
                "Entered Play mode using a separate runtime scene instance.");
        }

        private async Task RunExternalAsync()
        {
            var project = ProjectManager.Instance.CurrentProject;
            if (project == null) { MessageBox.Show("No project open.", "Error"); return; }

            SetPlayButtonsEnabled(false);
            SetStatus("Building…");
            ProjectManager.Instance.SaveProject();

            bool ok = await BuildAsync(project.RootPath);
            if (!ok) { SetPlayButtonsEnabled(true); return; }

            // Find the native host executable next to the editor binary
            string? hostExe = FindHostExe();
            if (hostExe == null)
            {
                MessageBox.Show(
                    "AngenHost.exe not found.\n\nMake sure AngenHost.exe is in the same folder as the editor.",
                    "Host Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                SetPlayButtonsEnabled(true);
                return;
            }

            string outputDir = Path.Combine(project.RootPath, "bin", "Debug", "net8.0");

            _console?.AppendEditorLine($"Launching host: {hostExe}");
            _console?.AppendEditorLine($"Working directory: {outputDir}");

            var psi = new ProcessStartInfo
            {
                FileName = hostExe,
                Arguments = "--verbose",
                WorkingDirectory = outputDir,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = false,       // Show the game window
                StandardOutputEncoding = System.Text.Encoding.UTF8,
                StandardErrorEncoding = System.Text.Encoding.UTF8,
            };

            var proc = new Process { StartInfo = psi, EnableRaisingEvents = true };
            _externalProcess = proc;

            proc.OutputDataReceived += (_, e) =>
            {
                if (e.Data == null) return;
                _buildLog.AppendLine(e.Data);
                _console?.AppendLine(e.Data);
            };
            proc.ErrorDataReceived += (_, e) =>
            {
                if (e.Data == null) return;
                _buildLog.AppendLine($"[ERR] {e.Data}");
                _console?.AppendLine($"[ERR] {e.Data}");
            };
            proc.Exited += (_, _) =>
            {
                BeginInvoke(() =>
                {
                    SetPlayButtonsEnabled(true);
                    _stopBtn!.Enabled = false;
                    SetStatus($"Stopped (exit {proc.ExitCode})");
                    _console?.AppendEditorLine($"Host exited with code {proc.ExitCode}.");
                    _externalProcess = null;
                    proc.Dispose();
                });
            };

            proc.Start();
            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();

            _playBtn!.Enabled = false;
            _stopBtn!.Enabled = true;

            SetStatus("Running (host)");
        }

        /// <summary>
        /// Looks for AngenHost.exe next to the editor, then one directory up (Build\).
        /// </summary>
        private static string? FindHostExe()
        {
            string editorDir = AppContext.BaseDirectory;

            string[] candidates =
            {
                Path.Combine(editorDir, "AngeneHost.exe"),
                Path.Combine(editorDir, "..", "AngeneHost.exe"),
                Path.Combine(editorDir, "..", "Build", "AngeneHost.exe"),
            };

            foreach (string path in candidates)
            {
                string full = Path.GetFullPath(path);
                if (File.Exists(full)) return full;
            }

            return null;
        }

        private async Task LoadEditPreviewAsync()
        {
            var project = ProjectManager.Instance.CurrentProject;
            if (project == null) { MessageBox.Show("No project open.", "Error"); return; }

            _sceneHost.Unload();
            SetPlaybackState(isPlaying: false, isPaused: false);
            SetPlayButtonsEnabled(false);
            SetStatus("Building…");
            ProjectManager.Instance.SaveProject();

            bool ok = await BuildAsync(project.RootPath);
            if (!ok) { SetPlayButtonsEnabled(true); return; }

            _sceneViewport!.Visible = false;
            _sceneHost.Load(project.RootPath, _preview!);
            if (!_sceneHost.IsLoaded)
            {
                _sceneViewport.Visible = true;
                SetPlaybackState(isPlaying: false, isPaused: false);
                SetStatus("Edit preview failed to load");
                return;
            }

            _sceneHost.SetMode(EngineMode.Edit);
            _viewTabs!.SelectedIndex = 0;

            _playBtn!.Enabled = true;
            _stopBtn!.Enabled = true;
            SetStatus("Editing (Preview)");
        }

        private void Stop()
        {
            if (_externalProcess != null)
            {
                try
                {
                    if (!_externalProcess.HasExited)
                        _externalProcess.Kill(entireProcessTree: true);
                }
                catch (InvalidOperationException) { }
                catch (System.ComponentModel.Win32Exception) { }
                return;
            }

            _sceneHost.Unload();
            _gamePreviewLabel!.Visible = true;
            SetPlaybackState(isPlaying: false, isPaused: false);
            _sceneViewport!.Visible = true;
            _viewTabs!.SelectedIndex = 0;
            SetStatus("Returned to Edit mode");
            _console?.AppendEditorLine(
                "Stopped Play mode; runtime changes were discarded.");
        }

        private void PauseOrResume()
        {
            if (!_isPlaying)
                return;

            _isPaused = !_isPaused;
            _sceneHost.SetMode(_isPaused ? EngineMode.Paused : EngineMode.Play);
            SetPlaybackState(isPlaying: true, isPaused: _isPaused);
            SetStatus(_isPaused ? "Paused" : "Playing (isolated)");
        }

        private void StepFrame()
        {
            if (!_isPlaying || !_isPaused)
                return;

            _sceneHost.StepOnce();
            SetStatus("Advanced one frame");
        }

        private void SetPlaybackState(bool isPlaying, bool isPaused)
        {
            _isPlaying = isPlaying;
            _isPaused = isPlaying && isPaused;

            if (_playBtn != null)
                _playBtn.Enabled = !isPlaying;
            if (_pauseBtn != null)
            {
                _pauseBtn.Enabled = isPlaying;
                _pauseBtn.Text = _isPaused ? "Resume" : "Pause";
            }
            if (_stepBtn != null)
                _stepBtn.Enabled = isPlaying && _isPaused;
            if (_stopBtn != null)
                _stopBtn.Enabled = isPlaying || _externalProcess != null;
        }

        private void SetPlayButtonsEnabled(bool enabled)
        {
            if (InvokeRequired) { BeginInvoke(() => SetPlayButtonsEnabled(enabled)); return; }
            if (_playBtn != null) _playBtn.Enabled = enabled;
        }

        // ── Async build ───────────────────────────────────────────────────────────

        private async Task<bool> BuildAsync(string projectDir)
        {
            var project = ProjectManager.Instance.CurrentProject;
            _buildLog.BeginBuild(project?.Name ?? Path.GetFileName(projectDir));
            _buildLog.ShowAndFocus();

            string? dotnetHost = DotnetSdkLocator.Resolve(_settings.DotnetHostPath);
            if (dotnetHost == null)
            {
                const string message =
                    "No .NET SDK was detected. Use Tools → Select .NET SDK, then try again.";
                _buildLog.AppendLine($"[ERR] {message}");
                _buildLog.EndBuild(false, -1);
                SetStatus("Build failed — .NET SDK not found");
                MessageBox.Show(
                    message,
                    ".NET SDK Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var psi = new ProcessStartInfo
            {
                FileName = dotnetHost,
                Arguments = "build --configuration Debug",
                WorkingDirectory = projectDir,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                StandardOutputEncoding = System.Text.Encoding.UTF8,
                StandardErrorEncoding = System.Text.Encoding.UTF8,
            };

            psi.Environment["DOTNET_CLI_UI_LANGUAGE"] = "en-US";
            psi.Environment["DOTNET_SYSTEM_CONSOLE_ALLOW_ANSI_COLOR_REDIRECTION"] = "1";
            psi.Environment["TERM"] = "xterm-256color";

            int exitCode = -1;

            try
            {
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
            }
            catch (Exception error)
            {
                _buildLog.AppendLine($"[ERR] Failed to start .NET SDK: {error.Message}");
                _buildLog.EndBuild(false, -1);
                SetStatus("Build failed — see Log");
                return false;
            }

            bool success = exitCode == 0;
            _buildLog.EndBuild(success, exitCode);

            // Refresh solution explorer after build (bin/ folder changes)
            if (success)
                _solutionExplorer?.Refresh();

            SetStatus(success ? "Build succeeded" : "Build failed — see Log");
            return success;
        }

        // ── Recovery and workspace layout ─────────────────────────────────────────

        private void OfferRecoveryRestore()
        {
            ProjectManager manager = ProjectManager.Instance;
            if (!manager.HasRecoverySnapshot())
                return;

            DialogResult result = MessageBox.Show(
                "A newer autosave recovery snapshot was found.\n\n" +
                "Restore it? The recovered scene will remain unsaved until you choose Save.",
                "Restore Autosave",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (manager.RestoreRecoverySnapshot())
                {
                    _console?.AppendEditorLine("Recovered scene from the latest autosave snapshot.");
                    SetStatus("Autosave restored");
                }
            }
            else
            {
                manager.DeleteRecoverySnapshot();
                _console?.AppendEditorLine("Discarded the stale autosave snapshot.");
            }
        }

        private void ApplySavedLayout()
        {
            EditorLayout? layout = _layoutStore.Load();
            if (layout == null)
                return;

            StartPosition = FormStartPosition.Manual;
            Bounds = EditorLayoutStore.ClampToVisibleWorkArea(layout.WindowBounds);
            _solutionExplorer!.Width = Math.Clamp(layout.ProjectPanelWidth, 170, 520);
            _hierarchy!.Width = Math.Clamp(layout.HierarchyPanelWidth, 190, 560);
            _inspector!.Width = Math.Clamp(layout.InspectorPanelWidth, 220, 620);
            _console!.Height = Math.Clamp(layout.ConsolePanelHeight, 100, 460);
            _viewTabs!.SelectedIndex = Math.Clamp(
                layout.ActiveViewIndex,
                0,
                _viewTabs.TabPages.Count - 1);

            if (layout.Maximized)
                WindowState = FormWindowState.Maximized;
        }

        private void SaveLayout()
        {
            Rectangle bounds = WindowState == FormWindowState.Normal
                ? Bounds
                : RestoreBounds;
            var layout = new EditorLayout
            {
                WindowBounds = bounds,
                Maximized = WindowState == FormWindowState.Maximized,
                ProjectPanelWidth = _solutionExplorer?.Width ?? 240,
                HierarchyPanelWidth = _hierarchy?.Width ?? 270,
                InspectorPanelWidth = _inspector?.Width ?? 280,
                ConsolePanelHeight = _console?.Height ?? 190,
                ActiveViewIndex = _viewTabs?.SelectedIndex ?? 0,
            };

            _layoutStore.Save(layout);
        }

        private void ResetLayout()
        {
            _layoutStore.Delete();
            _solutionExplorer!.Width = 240;
            _hierarchy!.Width = 270;
            _inspector!.Width = 280;
            _console!.Height = 190;
            _viewTabs!.SelectedIndex = 0;
            WindowState = FormWindowState.Normal;

            Rectangle workArea = Screen.FromControl(this).WorkingArea;
            Size = new Size(
                Math.Min(1600, workArea.Width),
                Math.Min(900, workArea.Height));
            Location = new Point(
                workArea.Left + Math.Max(0, (workArea.Width - Width) / 2),
                workArea.Top + Math.Max(0, (workArea.Height - Height) / 2));
            _sceneViewport?.ResetCamera();
            SetStatus("Layout reset");
        }

        private void OnEditorFormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!_closingConfirmed && ProjectManager.Instance.IsDirty)
            {
                DialogResult result = MessageBox.Show(
                    "Save changes to the current scene before closing?",
                    "Unsaved Scene",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

                if (result == DialogResult.Yes)
                    ProjectManager.Instance.SaveProject();
                else
                    ProjectManager.Instance.DeleteRecoverySnapshot();
            }

            _closingConfirmed = true;
            try
            {
                SaveLayout();
            }
            catch (Exception error)
            {
                Debug.WriteLine($"Failed to save editor layout: {error}");
            }

            _autosave?.Dispose();
            _autosave = null;
            _sceneHost.Dispose();
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

        private static ToolStripMenuItem AddItem(ToolStripMenuItem parent, string text,
            Shortcut shortcut, EventHandler handler)
        {
            var item = new ToolStripMenuItem(text, null, handler)
            {
                BackColor = EditorTheme.Panel,
                ForeColor = EditorTheme.TextPrimary,
                ShortcutKeys = (Keys)shortcut,
            };
            parent.DropDownItems.Add(item);
            return item;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _sceneHost.Dispose();
            base.OnFormClosed(e);
        }
    }
}
