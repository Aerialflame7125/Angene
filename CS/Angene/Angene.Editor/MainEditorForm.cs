using System.Diagnostics;
using System.Text;

namespace Angene.Editor;

public sealed class MainEditorForm : Form
{
    private readonly TreeView _hierarchy = new() { Dock = DockStyle.Fill };
    private readonly PropertyGrid _inspector = new() { Dock = DockStyle.Fill };
    private readonly ListView _assetView = new() { Dock = DockStyle.Fill, View = View.Details, FullRowSelect = true };
    private readonly RichTextBox _console = new() { Dock = DockStyle.Fill, ReadOnly = true };
    private readonly ListBox _scriptList = new() { Dock = DockStyle.Fill };

    public MainEditorForm()
    {
        Text = "Angene Editor";
        Width = 1700;
        Height = 950;
        StartPosition = FormStartPosition.CenterScreen;

        BuildWorkspace();
        SeedStarterContent();
        Log("Editor initialized.");
    }

    private void BuildWorkspace()
    {
        var topBar = BuildTopBar();

        var layout = new SplitContainer
        {
            Dock = DockStyle.Fill,
            SplitterDistance = 320
        };

        var rightLayout = new SplitContainer
        {
            Dock = DockStyle.Fill,
            Orientation = Orientation.Horizontal,
            SplitterDistance = 660
        };

        layout.Panel1.Controls.Add(BuildHierarchyAndAssetsTabs());
        layout.Panel2.Controls.Add(rightLayout);

        rightLayout.Panel1.Controls.Add(BuildSceneAndInspectorLayout());
        rightLayout.Panel2.Controls.Add(BuildConsoleAndScriptsTabs());

        Controls.Add(layout);
        Controls.Add(topBar);
    }

    private Control BuildTopBar()
    {
        var toolStrip = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, Dock = DockStyle.Top };

        var openVs = new ToolStripButton("Open in Visual Studio");
        openVs.Click += (_, _) => OpenVisualStudio();

        var createScript = new ToolStripButton("Create ScreenPlay Script");
        createScript.Click += (_, _) => CreateScreenPlayScript();

        var refreshAssets = new ToolStripButton("Refresh Assets");
        refreshAssets.Click += (_, _) => RefreshAssets();

        toolStrip.Items.Add(openVs);
        toolStrip.Items.Add(createScript);
        toolStrip.Items.Add(refreshAssets);

        return toolStrip;
    }

    private Control BuildHierarchyAndAssetsTabs()
    {
        _assetView.Columns.Add("Asset", 200);
        _assetView.Columns.Add("Type", 90);
        _assetView.Columns.Add("Path", 420);

        _hierarchy.AfterSelect += (_, e) => _inspector.SelectedObject = new { Name = e.Node.Text, Kind = "GameObject" };

        var tabs = new TabControl { Dock = DockStyle.Fill };
        tabs.TabPages.Add(new TabPage("Hierarchy") { Controls = { _hierarchy } });
        tabs.TabPages.Add(new TabPage("Assets") { Controls = { _assetView } });
        return tabs;
    }

    private Control BuildSceneAndInspectorLayout()
    {
        var splitter = new SplitContainer
        {
            Dock = DockStyle.Fill,
            Orientation = Orientation.Vertical,
            SplitterDistance = 980
        };

        var viewport = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(29, 32, 37) };
        viewport.Paint += (_, e) =>
        {
            using var font = new Font("Segoe UI", 18, FontStyle.Bold);
            using var brush = new SolidBrush(Color.FromArgb(220, 220, 220));
            e.Graphics.DrawString("Scene View", font, brush, 20, 20);
            e.Graphics.DrawString("Runtime preview placeholder.", SystemFonts.DefaultFont, brush, 22, 56);
        };

        splitter.Panel1.Controls.Add(viewport);
        splitter.Panel2.Controls.Add(_inspector);

        return splitter;
    }

    private Control BuildConsoleAndScriptsTabs()
    {
        var tabs = new TabControl { Dock = DockStyle.Fill };

        var scriptsPage = new TabPage("ScreenPlay Scripts");
        var scriptActions = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 42, AutoSize = false };
        var openScript = new Button { Text = "Open Selected Script", AutoSize = true };
        openScript.Click += (_, _) => OpenSelectedScript();
        scriptActions.Controls.Add(openScript);
        scriptsPage.Controls.Add(_scriptList);
        scriptsPage.Controls.Add(scriptActions);

        tabs.TabPages.Add(new TabPage("Console") { Controls = { _console } });
        tabs.TabPages.Add(scriptsPage);
        return tabs;
    }

    private void SeedStarterContent()
    {
        var root = _hierarchy.Nodes.Add("Scene");
        root.Nodes.Add("Main Camera");
        root.Nodes.Add("Directional Light");
        root.Nodes.Add("Environment");
        root.Expand();

        RefreshAssets();
        RefreshScripts();
    }

    private void RefreshAssets()
    {
        _assetView.BeginUpdate();
        _assetView.Items.Clear();

        var repoRoot = ResolveRepositoryRoot();
        var roots = new[] { "assets", "Assets", "ScreenPlayScripts" }
            .Select(path => Path.Combine(repoRoot, path))
            .Where(Directory.Exists)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();

        foreach (var root in roots)
        {
            foreach (var file in Directory.EnumerateFiles(root, "*", SearchOption.AllDirectories))
            {
                var type = Path.GetExtension(file).TrimStart('.').ToLowerInvariant();
                var item = new ListViewItem(new[] { Path.GetFileName(file), type, file });
                _assetView.Items.Add(item);
            }
        }

        _assetView.EndUpdate();
        Log($"Assets refreshed. {_assetView.Items.Count} items found.");
    }

    private void RefreshScripts()
    {
        _scriptList.Items.Clear();
        var scriptsDir = ResolveScriptDirectory();
        Directory.CreateDirectory(scriptsDir);

        foreach (var script in Directory.EnumerateFiles(scriptsDir, "*.cs", SearchOption.TopDirectoryOnly).OrderBy(x => x))
        {
            _scriptList.Items.Add(script);
        }

        Log($"Scripts refreshed. {_scriptList.Items.Count} scripts found.");
    }

    private string ResolveRepositoryRoot()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);
        while (directory is not null)
        {
            if (File.Exists(Path.Combine(directory.FullName, "Angene.GameWorkspace.csproj")))
            {
                return directory.FullName;
            }

            directory = directory.Parent;
        }

        return Environment.CurrentDirectory;
    }

    private string ResolveScriptDirectory() => Path.Combine(ResolveRepositoryRoot(), "ScreenPlayScripts");

    private void CreateScreenPlayScript()
    {
        var name = Prompt.Show("Script name", "Create ScreenPlay Script", "NewScreenPlay");
        if (string.IsNullOrWhiteSpace(name))
        {
            return;
        }

        var safeName = string.Concat(name.Where(ch => char.IsLetterOrDigit(ch) || ch == '_'));
        if (string.IsNullOrWhiteSpace(safeName))
        {
            MessageBox.Show("Invalid script name.", "Angene Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var path = Path.Combine(ResolveScriptDirectory(), $"{safeName}.cs");
        if (File.Exists(path))
        {
            MessageBox.Show("A script with this name already exists.", "Angene Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var template = $$"""
using Angene.Essentials;

namespace ScreenPlayScripts;

public sealed class {{safeName}} : IScreenPlay
{
    public void Start()
    {
    }

    public void Update(double dt)
    {
    }

    public void Render()
    {
    }

    public void Cleanup()
    {
    }
}
""";

        File.WriteAllText(path, template, Encoding.UTF8);
        Log($"Created script: {path}");
        RefreshScripts();
    }

    private void OpenSelectedScript()
    {
        if (_scriptList.SelectedItem is not string selected)
        {
            MessageBox.Show("Select a script first.", "Angene Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        OpenVisualStudio(selected);
    }

    private void OpenVisualStudio(string? selectedScript = null)
    {
        var root = ResolveRepositoryRoot();
        var workspace = Path.Combine(root, "Angene.GameWorkspace.csproj");

        var candidates = new[] { "devenv.exe", "code.cmd", "code" };
        foreach (var candidate in candidates)
        {
            try
            {
                var args = selectedScript is null ? $"\"{workspace}\"" : $"\"{workspace}\" \"{selectedScript}\"";
                var psi = new ProcessStartInfo(candidate, args)
                {
                    UseShellExecute = true,
                    WorkingDirectory = root
                };

                Process.Start(psi);
                Log($"Opened workspace via {candidate}.");
                return;
            }
            catch
            {
                // try next candidate
            }
        }

        MessageBox.Show("Unable to open Visual Studio automatically. Open Angene.GameWorkspace.csproj manually.",
            "Angene Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void Log(string message)
    {
        _console.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
    }

    private static class Prompt
    {
        public static string? Show(string labelText, string caption, string defaultValue)
        {
            using var form = new Form
            {
                Width = 420,
                Height = 170,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false
            };

            var label = new Label { Left = 16, Top = 18, Text = labelText, AutoSize = true };
            var textBox = new TextBox { Left = 16, Top = 44, Width = 368, Text = defaultValue };
            var okButton = new Button { Text = "OK", Left = 228, Width = 75, Top = 82, DialogResult = DialogResult.OK };
            var cancelButton = new Button { Text = "Cancel", Left = 309, Width = 75, Top = 82, DialogResult = DialogResult.Cancel };

            form.Controls.Add(label);
            form.Controls.Add(textBox);
            form.Controls.Add(okButton);
            form.Controls.Add(cancelButton);
            form.AcceptButton = okButton;
            form.CancelButton = cancelButton;

            return form.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }
    }
}
