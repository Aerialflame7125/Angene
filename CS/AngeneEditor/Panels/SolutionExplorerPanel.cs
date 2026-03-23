using AngeneEditor.Project;
using AngeneEditor.ScriptEditor;
using AngeneEditor.Theme;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AngeneEditor.Panels
{
    /// <summary>
    /// Solution Explorer panel — shows the project directory as a navigable tree.
    /// Double-click a .cs file to open it in the script editor.
    /// </summary>
    public sealed class SolutionExplorerPanel : Panel
    {
        private Label _header;
        private TreeView _tree;
        private Label _emptyLabel;

        public SolutionExplorerPanel()
        {
            BackColor = EditorTheme.Panel;
            Dock = DockStyle.Left;
            Width = 240;

            BuildUI();

            var pm = ProjectManager.Instance;
            pm.ProjectOpened += OnProjectOpened;
            pm.ProjectSaved += () => Refresh();
        }

        private void BuildUI()
        {
            _header = new Label
            {
                Text = "SOLUTION EXPLORER",
                Dock = DockStyle.Top,
                Height = 28,
                Font = EditorTheme.FontUISmall,
                ForeColor = EditorTheme.TextSecondary,
                BackColor = EditorTheme.PanelHeader,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
            };

            var toolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 28,
                BackColor = EditorTheme.BackgroundAlt,
            };

            var refreshBtn = new Button
            {
                Text = "↺ Refresh",
                FlatStyle = FlatStyle.Flat,
                BackColor = EditorTheme.PanelHeader,
                ForeColor = EditorTheme.TextSecondary,
                Font = EditorTheme.FontUISmall,
                Location = new Point(4, 3),
                Size = new Size(70, 22),
                FlatAppearance = { BorderColor = EditorTheme.PanelBorder },
            };
            refreshBtn.Click += (_, _) => RefreshTree();
            toolbar.Controls.Add(refreshBtn);

            var openFolderBtn = new Button
            {
                Text = "📁",
                FlatStyle = FlatStyle.Flat,
                BackColor = EditorTheme.PanelHeader,
                ForeColor = EditorTheme.TextSecondary,
                Font = EditorTheme.FontUI,
                Location = new Point(80, 3),
                Size = new Size(28, 22),
                FlatAppearance = { BorderColor = EditorTheme.PanelBorder },
            };
            openFolderBtn.Click += OpenProjectFolder;
            toolbar.Controls.Add(openFolderBtn);

            _tree = new TreeView
            {
                Dock = DockStyle.Fill,
                BackColor = EditorTheme.Panel,
                ForeColor = EditorTheme.TextPrimary,
                Font = EditorTheme.FontCode,
                BorderStyle = BorderStyle.None,
                ShowLines = true,
                ShowRootLines = true,
                ShowPlusMinus = true,
                FullRowSelect = true,
                HideSelection = false,
                DrawMode = TreeViewDrawMode.OwnerDrawAll,
            };
            _tree.DrawNode += DrawTreeNode;
            _tree.NodeMouseDoubleClick += OnNodeDoubleClick;
            _tree.AfterExpand += (_, e) => e.Node.ImageIndex = 1;

            // Context menu
            var ctx = new ContextMenuStrip();
            ctx.Renderer = EditorTheme.MenuRenderer();
            ctx.BackColor = EditorTheme.Panel;
            ctx.ForeColor = EditorTheme.TextPrimary;
            AddMenuItem(ctx, "✎ Open in Script Editor", OnOpenInEditor);
            AddMenuItem(ctx, "Open in Visual Studio", OnOpenInVs);
            ctx.Items.Add(new ToolStripSeparator());
            AddMenuItem(ctx, "📋 Copy Path", OnCopyPath);
            AddMenuItem(ctx, "📁 Show in Explorer", OnShowInExplorer);
            _tree.ContextMenuStrip = ctx;

            _emptyLabel = new Label
            {
                Text = "Open a project\nto see files here.",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = EditorTheme.TextDisabled,
                Font = EditorTheme.FontUI,
                BackColor = EditorTheme.Panel,
            };

            Controls.Add(_emptyLabel);
            Controls.Add(_tree);
            Controls.Add(toolbar);
            Controls.Add(_header);

            _tree.Visible = false;
        }

        // ── Project events ────────────────────────────────────────────────────

        private void OnProjectOpened(AngeneProject project)
        {
            if (InvokeRequired) { Invoke(() => OnProjectOpened(project)); return; }
            RefreshTree();
        }

        public new void Refresh()
        {
            if (InvokeRequired) { Invoke(Refresh); return; }
            RefreshTree();
        }

        private void RefreshTree()
        {
            var project = ProjectManager.Instance.CurrentProject;
            if (project == null)
            {
                _tree.Visible = false;
                _emptyLabel.Visible = true;
                return;
            }

            _tree.BeginUpdate();
            _tree.Nodes.Clear();

            var root = new TreeNode($"📁 {project.Name}")
            {
                Tag = project.RootPath,
                ForeColor = EditorTheme.TextAccent,
            };

            PopulateDirectory(root, project.RootPath, depth: 0, maxDepth: 5);
            _tree.Nodes.Add(root);
            root.Expand();

            // Auto-expand Scenes and Scripts
            ExpandNamed(root, "Scenes");
            ExpandNamed(root, "Scripts");

            _tree.EndUpdate();

            _tree.Visible = true;
            _emptyLabel.Visible = false;
        }

        private static void ExpandNamed(TreeNode parent, string name)
        {
            foreach (TreeNode child in parent.Nodes)
            {
                if (child.Text.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    child.Expand();
                    return;
                }
            }
        }

        private static void PopulateDirectory(TreeNode parent, string dirPath, int depth, int maxDepth)
        {
            if (depth > maxDepth) return;

            // Skip common noise directories
            string dirName = Path.GetFileName(dirPath);
            if (dirName is "obj" or ".git" or ".vs" or "node_modules") return;

            try
            {
                // Subdirectories
                foreach (var sub in Directory.GetDirectories(dirPath))
                {
                    string subName = Path.GetFileName(sub);
                    if (subName is "obj" or ".git" or ".vs") continue;

                    var node = new TreeNode($"📁 {subName}")
                    {
                        Tag = sub,
                        ForeColor = EditorTheme.TextSecondary,
                    };
                    parent.Nodes.Add(node);
                    PopulateDirectory(node, sub, depth + 1, maxDepth);
                }

                // Files
                foreach (var file in Directory.GetFiles(dirPath))
                {
                    string ext = Path.GetExtension(file).ToLower();
                    string icon = ext switch
                    {
                        ".cs" => "C#",
                        ".csproj" => "⚙",
                        ".sln" => "◈",
                        ".json" => "{}",
                        ".txt" => "📄",
                        ".md" => "📝",
                        ".angpkg" => "📦",
                        _ => "·",
                    };

                    Color fileColor = ext switch
                    {
                        ".cs" => EditorTheme.TextPrimary,
                        ".csproj" => EditorTheme.Accent,
                        ".sln" => EditorTheme.TextAccent,
                        ".angpkg" => Color.FromArgb(180, 140, 80),
                        _ => EditorTheme.TextSecondary,
                    };

                    var node = new TreeNode($"{icon} {Path.GetFileName(file)}")
                    {
                        Tag = file,
                        ForeColor = fileColor,
                    };
                    parent.Nodes.Add(node);
                }
            }
            catch { /* ignore permission errors */ }
        }

        // ── Node actions ─────────────────────────────────────────────────────

        private void OnNodeDoubleClick(object? s, TreeNodeMouseClickEventArgs e)
        {
            string? path = e.Node?.Tag as string;
            if (path == null || !File.Exists(path)) return;

            string ext = Path.GetExtension(path).ToLower();
            if (ext == ".cs")
                new ScriptEditorWindow(path).Show(FindForm());
        }

        private void OnOpenInEditor(object? s, EventArgs e)
        {
            string? path = _tree.SelectedNode?.Tag as string;
            if (path == null || !File.Exists(path)) return;
            new ScriptEditorWindow(path).Show(FindForm());
        }

        private void OnOpenInVs(object? s, EventArgs e)
        {
            string? path = _tree.SelectedNode?.Tag as string;
            if (path == null || !File.Exists(path)) return;
            ScriptEditorWindow.OpenFileInVs(path, FindForm()!);
        }

        private void OnCopyPath(object? s, EventArgs e)
        {
            string? path = _tree.SelectedNode?.Tag as string;
            if (path != null)
                Clipboard.SetText(path);
        }

        private void OnShowInExplorer(object? s, EventArgs e)
        {
            string? path = _tree.SelectedNode?.Tag as string;
            if (path == null) return;

            string dir = File.Exists(path) ? Path.GetDirectoryName(path)! : path;
            if (Directory.Exists(dir))
                System.Diagnostics.Process.Start("explorer.exe", dir);
        }

        private void OpenProjectFolder(object? s, EventArgs e)
        {
            var project = ProjectManager.Instance.CurrentProject;
            if (project == null || !Directory.Exists(project.RootPath)) return;
            System.Diagnostics.Process.Start("explorer.exe", project.RootPath);
        }

        // ── Custom draw ───────────────────────────────────────────────────────

        private void DrawTreeNode(object? s, DrawTreeNodeEventArgs e)
        {
            bool selected = (e.State & TreeNodeStates.Selected) != 0;
            var bg = selected ? EditorTheme.Selection : EditorTheme.Panel;
            e.Graphics.FillRectangle(new SolidBrush(bg), e.Bounds);

            Color fg = e.Node!.ForeColor == Color.Empty ? EditorTheme.TextPrimary : e.Node.ForeColor;
            if (selected) fg = EditorTheme.SelectionText;

            TextRenderer.DrawText(e.Graphics, e.Node.Text, _tree.Font,
                new Point(e.Bounds.X + 4, e.Bounds.Y + 2), fg);
        }

        // ── Helpers ───────────────────────────────────────────────────────────

        private static void AddMenuItem(ContextMenuStrip ctx, string text, EventHandler handler)
        {
            var item = new ToolStripMenuItem(text)
            {
                BackColor = EditorTheme.Panel,
                ForeColor = EditorTheme.TextPrimary,
            };
            item.Click += handler;
            ctx.Items.Add(item);
        }
    }
}