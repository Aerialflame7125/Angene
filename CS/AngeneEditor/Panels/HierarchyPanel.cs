using System;
using System.Drawing;
using System.Windows.Forms;
using AngeneEditor.Project;
using AngeneEditor.Theme;

namespace AngeneEditor.Panels
{
    /// <summary>
    /// Left panel: scene hierarchy tree.
    /// Shows all entities in the current project.
    /// Right-click for add/remove/rename context menu.
    /// </summary>
    public sealed class HierarchyPanel : Panel
    {
        private Label _header;
        private TreeView _tree;
        private Button _addEntityBtn;

        public event Action<EntityDefinition>? EntitySelected;
        public event Action<EntityDefinition>? EntityDoubleClicked;

        public HierarchyPanel()
        {
            BackColor = EditorTheme.Panel;
            Dock = DockStyle.Left;
            Width = 240;

            BuildUI();
            WireEvents();
        }

        private void BuildUI()
        {
            _header = new Label
            {
                Text = "SCENE HIERARCHY",
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
                Height = 32,
                BackColor = EditorTheme.BackgroundAlt,
            };

            _addEntityBtn = new Button
            {
                Text = "+ Entity",
                FlatStyle = FlatStyle.Flat,
                BackColor = EditorTheme.AccentDim,
                ForeColor = EditorTheme.TextPrimary,
                Font = EditorTheme.FontUISmall,
                Location = new Point(4, 4),
                Size = new Size(72, 24),
                FlatAppearance = { BorderColor = EditorTheme.Accent }
            };
            toolbar.Controls.Add(_addEntityBtn);

            _tree = new TreeView
            {
                Dock = DockStyle.Fill,
                BackColor = EditorTheme.Panel,
                ForeColor = EditorTheme.TextPrimary,
                Font = EditorTheme.FontUI,
                BorderStyle = BorderStyle.None,
                ShowLines = true,
                ShowRootLines = true,
                ShowPlusMinus = true,
                FullRowSelect = true,
                HideSelection = false,
                DrawMode = TreeViewDrawMode.OwnerDrawAll,
            };
            _tree.DrawNode += DrawTreeNode;

            // Context menu
            var ctx = new ContextMenuStrip();
            ctx.Renderer = EditorTheme.MenuRenderer();
            ctx.BackColor = EditorTheme.Panel;
            ctx.ForeColor = EditorTheme.TextPrimary;

            AddMenuItem(ctx, "➕ Add Script", OnAddScript);
            AddMenuItem(ctx, "✏ Rename", OnRename);
            ctx.Items.Add(new ToolStripSeparator());
            AddMenuItem(ctx, "🗑 Delete Entity", OnDeleteEntity);

            _tree.ContextMenuStrip = ctx;

            Controls.Add(_tree);
            Controls.Add(toolbar);
            Controls.Add(_header);
        }

        private void WireEvents()
        {
            _addEntityBtn.Click += AddEntity;
            _tree.AfterSelect += OnNodeSelected;
            _tree.NodeMouseDoubleClick += OnNodeDoubleClick;

            var pm = ProjectManager.Instance;
            pm.ProjectOpened += OnProjectOpened;
            pm.EntityAdded += OnEntityAdded;
            pm.ScriptAdded += OnScriptAdded;
        }

        // ── Project events ────────────────────────────────────────────────────────

        private void OnProjectOpened(AngeneProject project)
        {
            if (InvokeRequired) { Invoke(() => OnProjectOpened(project)); return; }

            _tree.Nodes.Clear();

            var sceneNode = new TreeNode("Init  [Scene]")
            {
                ForeColor = EditorTheme.TextAccent,
                Tag = "scene",
            };
            _tree.Nodes.Add(sceneNode);

            foreach (var entity in project.Entities)
                sceneNode.Nodes.Add(MakeEntityNode(entity));

            sceneNode.Expand();
        }

        private void OnEntityAdded(EntityDefinition entity)
        {
            if (InvokeRequired) { Invoke(() => OnEntityAdded(entity)); return; }

            if (_tree.Nodes.Count == 0) return;
            _tree.Nodes[0].Nodes.Add(MakeEntityNode(entity));
            _tree.Nodes[0].Expand();
        }

        private void OnScriptAdded(EntityDefinition entity, string script)
        {
            if (InvokeRequired) { Invoke(() => OnScriptAdded(entity, script)); return; }

            // Find the entity node and add script as child
            if (_tree.Nodes.Count == 0) return;
            foreach (TreeNode node in _tree.Nodes[0].Nodes)
            {
                if (node.Tag is EntityDefinition e && e == entity)
                {
                    node.Nodes.Add(new TreeNode($"  ⬡ {script}")
                    {
                        ForeColor = EditorTheme.TextSecondary,
                        Tag = script
                    });
                    node.Expand();
                    break;
                }
            }
        }

        // ── Add entity ────────────────────────────────────────────────────────────

        private void AddEntity(object? s, EventArgs e)
        {
            if (ProjectManager.Instance.CurrentProject == null) return;

            using var dlg = new RenameDialog("New Entity", "Entity");
            if (dlg.ShowDialog() != DialogResult.OK) return;

            ProjectManager.Instance.AddEntity(dlg.Value);
        }

        // ── Context actions ───────────────────────────────────────────────────────

        private void OnAddScript(object? s, EventArgs e)
        {
            var entity = SelectedEntity();
            if (entity == null) return;

            using var dlg = new RenameDialog("New Script Name", "MyScript");
            if (dlg.ShowDialog() != DialogResult.OK) return;

            ProjectManager.Instance.AddScript(entity, dlg.Value);
        }

        private void OnRename(object? s, EventArgs e)
        {
            var entity = SelectedEntity();
            if (entity == null) return;

            using var dlg = new RenameDialog("Rename Entity", entity.Name);
            if (dlg.ShowDialog() != DialogResult.OK) return;

            entity.Name = dlg.Value;
            _tree.SelectedNode!.Text = FormatEntityLabel(entity);
        }

        private void OnDeleteEntity(object? s, EventArgs e)
        {
            var entity = SelectedEntity();
            if (entity == null) return;

            var confirm = MessageBox.Show(
                $"Delete entity '{entity.Name}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            ProjectManager.Instance.RemoveEntity(entity);
            _tree.Nodes[0].Nodes.Remove(_tree.SelectedNode!);
        }

        // ── Selection ─────────────────────────────────────────────────────────────

        private void OnNodeSelected(object? s, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is EntityDefinition entity)
                EntitySelected?.Invoke(entity);
        }

        private void OnNodeDoubleClick(object? s, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node?.Tag is EntityDefinition entity)
                EntityDoubleClicked?.Invoke(entity);
        }

        private EntityDefinition? SelectedEntity()
            => _tree.SelectedNode?.Tag as EntityDefinition;

        // ── Custom draw ──────────────────────────────────────────────────────────

        private void DrawTreeNode(object? s, DrawTreeNodeEventArgs e)
        {
            bool selected = (e.State & TreeNodeStates.Selected) != 0;
            var bg = selected ? EditorTheme.Selection : EditorTheme.Panel;
            e.Graphics.FillRectangle(new SolidBrush(bg), e.Bounds);

            Color fg = e.Node!.ForeColor == Color.Empty ? EditorTheme.TextPrimary : e.Node.ForeColor;
            if (selected) fg = EditorTheme.SelectionText;

            TextRenderer.DrawText(e.Graphics, e.Node.Text, e.Node.TreeView!.Font,
                new Point(e.Bounds.X + 4, e.Bounds.Y + 2), fg);
        }

        // ── Helpers ──────────────────────────────────────────────────────────────

        private static TreeNode MakeEntityNode(EntityDefinition entity)
        {
            var node = new TreeNode(FormatEntityLabel(entity)) { Tag = entity };
            foreach (var s in entity.Scripts)
                node.Nodes.Add(new TreeNode($"  ⬡ {s}") { ForeColor = EditorTheme.TextSecondary, Tag = s });
            return node;
        }

        private static string FormatEntityLabel(EntityDefinition e)
            => $"  ◈ {e.Name}  ({e.X}, {e.Y})";

        private static void AddMenuItem(ContextMenuStrip ctx, string text, EventHandler handler)
        {
            var item = new ToolStripMenuItem(text) { BackColor = EditorTheme.Panel, ForeColor = EditorTheme.TextPrimary };
            item.Click += handler;
            ctx.Items.Add(item);
        }
    }

    /// <summary>Simple inline rename/name dialog.</summary>
    internal sealed class RenameDialog : Form
    {
        public string Value { get; private set; } = "";
        private TextBox _box;

        public RenameDialog(string title, string current)
        {
            Text = title;
            Size = new Size(320, 120);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = EditorTheme.Panel;
            MaximizeBox = false; MinimizeBox = false;

            _box = new TextBox
            {
                Location = new Point(10, 12),
                Size = new Size(280, 24),
                Text = current,
                BackColor = EditorTheme.BackgroundAlt,
                ForeColor = EditorTheme.TextPrimary,
                BorderStyle = BorderStyle.FixedSingle,
                Font = EditorTheme.FontUI,
            };
            _box.SelectAll();

            var ok = new Button
            {
                Text = "OK",
                Location = new Point(10, 46),
                Size = new Size(80, 28),
                BackColor = EditorTheme.Accent,
                ForeColor = EditorTheme.TextPrimary,
                FlatStyle = FlatStyle.Flat,
                Font = EditorTheme.FontUI,
            };
            ok.Click += (_, _) => { Value = _box.Text.Trim(); DialogResult = DialogResult.OK; Close(); };

            AcceptButton = ok;
            Controls.AddRange(new Control[] { _box, ok });
        }
    }
}