using AngeneEditor.Project;
using AngeneEditor.Theme;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AngeneEditor.Panels
{
    /// <summary>
    /// Searchable scene hierarchy with multi-selection, nesting, duplication,
    /// reordering, and drag-to-parent behavior.
    /// </summary>
    public sealed class HierarchyPanel : Panel
    {
        private readonly HashSet<Guid> _selectedIds = new();
        private Label _header = null!;
        private TreeView _tree = null!;
        private TextBox _searchBox = null!;
        private Button _addEntityButton = null!;
        private Guid? _selectionAnchor;
        private bool _rebuilding;
        private bool _handlingMouseSelection;

        public event Action<EntityDefinition>? EntitySelected;
        public event Action<IReadOnlyList<EntityDefinition>>? EntitiesSelected;
        public event Action<EntityDefinition>? EntityDoubleClicked;

        public HierarchyPanel()
        {
            BackColor = EditorTheme.Panel;
            Dock = DockStyle.Left;
            Width = 270;

            BuildUi();
            WireEvents();
        }

        private void BuildUi()
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
                Height = 62,
                BackColor = EditorTheme.BackgroundAlt,
            };

            _addEntityButton = ToolbarButton("+ Entity", new Point(4, 4), 74);
            var duplicateButton = ToolbarButton("Duplicate", new Point(82, 4), 76);
            var rootButton = ToolbarButton("To Root", new Point(162, 4), 70);

            duplicateButton.Click += (_, _) => DuplicateSelected();
            rootButton.Click += (_, _) => ReparentSelectedToRoot();

            _searchBox = new TextBox
            {
                PlaceholderText = "Search entities and scripts…",
                Location = new Point(4, 34),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                Size = new Size(Width - 10, 23),
                BackColor = EditorTheme.Background,
                ForeColor = EditorTheme.TextPrimary,
                BorderStyle = BorderStyle.FixedSingle,
                Font = EditorTheme.FontUISmall,
            };

            toolbar.Controls.AddRange(
                new Control[] { _addEntityButton, duplicateButton, rootButton, _searchBox });

            _tree = new TreeView
            {
                Dock = DockStyle.Fill,
                AllowDrop = true,
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
            _tree.ContextMenuStrip = BuildContextMenu();

            Controls.Add(_tree);
            Controls.Add(toolbar);
            Controls.Add(_header);
        }

        private void WireEvents()
        {
            _addEntityButton.Click += AddEntity;
            _searchBox.TextChanged += (_, _) => Rebuild();

            _tree.NodeMouseClick += OnNodeMouseClick;
            _tree.AfterSelect += OnAfterSelect;
            _tree.NodeMouseDoubleClick += OnNodeDoubleClick;
            _tree.KeyDown += OnTreeKeyDown;
            _tree.ItemDrag += OnItemDrag;
            _tree.DragOver += OnDragOver;
            _tree.DragDrop += OnDragDrop;

            ProjectManager manager = ProjectManager.Instance;
            manager.ProjectOpened += _ => Rebuild();
            manager.EntitiesChanged += Rebuild;
        }

        public void SelectEntity(Guid? entityId)
        {
            if (entityId == null)
            {
                _selectedIds.Clear();
                _selectionAnchor = null;
                _tree.SelectedNode = null;
                RaiseSelectionChanged();
                return;
            }

            TreeNode? node = EnumerateNodes(_tree.Nodes)
                .FirstOrDefault(candidate =>
                    candidate.Tag is EntityDefinition entity &&
                    entity.Id == entityId.Value);
            if (node == null)
                return;

            _selectedIds.Clear();
            _selectedIds.Add(entityId.Value);
            _selectionAnchor = entityId.Value;
            _tree.SelectedNode = node;
            node.EnsureVisible();
            RaiseSelectionChanged();
        }

        private ContextMenuStrip BuildContextMenu()
        {
            var menu = new ContextMenuStrip
            {
                Renderer = EditorTheme.MenuRenderer(),
                BackColor = EditorTheme.Panel,
                ForeColor = EditorTheme.TextPrimary,
            };

            AddMenuItem(menu, "Add Child Entity", OnAddChild);
            AddMenuItem(menu, "Add Script", OnAddScript);
            menu.Items.Add(new ToolStripSeparator());
            AddMenuItem(menu, "Duplicate", (_, _) => DuplicateSelected());
            AddMenuItem(menu, "Rename", OnRename);
            AddMenuItem(menu, "Move Up", (_, _) => MoveSelected(-1));
            AddMenuItem(menu, "Move Down", (_, _) => MoveSelected(1));
            AddMenuItem(menu, "Move To Root", (_, _) => ReparentSelectedToRoot());
            menu.Items.Add(new ToolStripSeparator());
            AddMenuItem(menu, "Delete", (_, _) => DeleteSelected());

            return menu;
        }

        private void Rebuild()
        {
            if (InvokeRequired)
            {
                Invoke(Rebuild);
                return;
            }

            _rebuilding = true;
            try
            {
                var expandedIds = EnumerateNodes(_tree.Nodes)
                    .Where(node => node.IsExpanded && node.Tag is EntityDefinition)
                    .Select(node => ((EntityDefinition)node.Tag!).Id)
                    .ToHashSet();

                _tree.BeginUpdate();
                _tree.Nodes.Clear();

                AngeneProject? project = ProjectManager.Instance.CurrentProject;
                if (project == null)
                    return;

                _selectedIds.RemoveWhere(id => project.Entities.All(entity => entity.Id != id));

                var sceneNode = new TreeNode($"{project.Scene.Name}  [Scene]")
                {
                    ForeColor = EditorTheme.TextAccent,
                    Tag = SceneRootTag.Instance,
                };
                _tree.Nodes.Add(sceneNode);

                string filter = _searchBox.Text.Trim();
                var byParent = project.Entities
                    .Where(entity => entity.ParentId.HasValue)
                    .GroupBy(entity => entity.ParentId!.Value)
                    .ToDictionary(group => group.Key, group => group.ToList());

                var visited = new HashSet<Guid>();
                foreach (EntityDefinition root in project.Entities.Where(entity =>
                             entity.ParentId == null ||
                             project.Entities.All(candidate => candidate.Id != entity.ParentId)))
                {
                    TreeNode? node = MakeEntityNode(root, byParent, visited, filter);
                    if (node != null)
                        sceneNode.Nodes.Add(node);
                }

                // Invalid/cyclic data should remain visible rather than disappearing.
                foreach (EntityDefinition orphan in project.Entities.Where(entity => !visited.Contains(entity.Id)))
                {
                    TreeNode? node = MakeEntityNode(orphan, byParent, visited, filter);
                    if (node != null)
                        sceneNode.Nodes.Add(node);
                }

                sceneNode.Expand();
                RestoreExpandedState(sceneNode.Nodes, expandedIds);
            }
            finally
            {
                _tree.EndUpdate();
                _rebuilding = false;
                _tree.Invalidate();
            }
        }

        private TreeNode? MakeEntityNode(
            EntityDefinition entity,
            IReadOnlyDictionary<Guid, List<EntityDefinition>> byParent,
            HashSet<Guid> visited,
            string filter)
        {
            if (!visited.Add(entity.Id))
                return null;

            var childNodes = new List<TreeNode>();
            if (byParent.TryGetValue(entity.Id, out List<EntityDefinition>? children))
            {
                foreach (EntityDefinition child in children)
                {
                    TreeNode? childNode = MakeEntityNode(child, byParent, visited, filter);
                    if (childNode != null)
                        childNodes.Add(childNode);
                }
            }

            bool matches = filter.Length == 0 ||
                           entity.Name.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                           entity.Scripts.Any(script =>
                               script.Contains(filter, StringComparison.OrdinalIgnoreCase));

            if (!matches && childNodes.Count == 0)
                return null;

            var node = new TreeNode(FormatEntityLabel(entity))
            {
                Tag = entity,
                ForeColor = entity.Enabled
                    ? EditorTheme.TextPrimary
                    : EditorTheme.TextDisabled,
            };

            foreach (string script in entity.Scripts)
            {
                if (filter.Length > 0 &&
                    !matches &&
                    !script.Contains(filter, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                node.Nodes.Add(new TreeNode($"  ◇ {script}")
                {
                    ForeColor = EditorTheme.TextSecondary,
                    Tag = new ScriptNodeTag(entity.Id, script),
                });
            }

            node.Nodes.AddRange(childNodes.ToArray());
            if (filter.Length > 0)
                node.Expand();

            return node;
        }

        private void AddEntity(object? sender, EventArgs e)
        {
            if (ProjectManager.Instance.CurrentProject == null)
                return;

            using var dialog = new RenameDialog("New Entity", "Entity");
            if (dialog.ShowDialog() != DialogResult.OK || dialog.Value.Length == 0)
                return;

            EntityDefinition entity = ProjectManager.Instance.AddEntity(dialog.Value);
            SelectOnly(entity.Id);
        }

        private void OnAddChild(object? sender, EventArgs e)
        {
            EntityDefinition? parent = PrimarySelectedEntity();
            if (parent == null)
                return;

            using var dialog = new RenameDialog("New Child Entity", "Entity");
            if (dialog.ShowDialog() != DialogResult.OK || dialog.Value.Length == 0)
                return;

            EntityDefinition entity = ProjectManager.Instance.AddEntity(
                dialog.Value,
                parentId: parent.Id);
            SelectOnly(entity.Id);
        }

        private void OnAddScript(object? sender, EventArgs e)
        {
            EntityDefinition? entity = PrimarySelectedEntity();
            if (entity == null)
                return;

            using var dialog = new RenameDialog("New Script Name", "MyScript");
            if (dialog.ShowDialog() != DialogResult.OK || dialog.Value.Length == 0)
                return;

            ProjectManager.Instance.AddScript(entity, dialog.Value);
        }

        private void OnRename(object? sender, EventArgs e)
        {
            EntityDefinition? entity = PrimarySelectedEntity();
            if (entity == null)
                return;

            using var dialog = new RenameDialog("Rename Entity", entity.Name);
            if (dialog.ShowDialog() != DialogResult.OK || dialog.Value.Length == 0)
                return;

            ProjectManager.Instance.RenameEntity(entity, dialog.Value);
        }

        private void DuplicateSelected()
        {
            EntityDefinition? source = PrimarySelectedEntity();
            if (source == null)
                return;

            EntityDefinition duplicate = ProjectManager.Instance.DuplicateEntity(source);
            SelectOnly(duplicate.Id);
        }

        private void DeleteSelected()
        {
            IReadOnlyList<EntityDefinition> selected = SelectedEntities();
            if (selected.Count == 0)
                return;

            DialogResult confirmation = MessageBox.Show(
                selected.Count == 1
                    ? $"Delete entity '{selected[0].Name}' and its children?"
                    : $"Delete {selected.Count} selected entities and their children?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmation != DialogResult.Yes)
                return;

            ProjectManager.Instance.RemoveEntities(selected);
            _selectedIds.Clear();
            RaiseSelectionChanged();
        }

        private void ReparentSelectedToRoot()
        {
            foreach (EntityDefinition entity in SelectedEntities())
                ProjectManager.Instance.ReparentEntity(entity, null);
        }

        private void MoveSelected(int direction)
        {
            AngeneProject? project = ProjectManager.Instance.CurrentProject;
            EntityDefinition? entity = PrimarySelectedEntity();
            if (project == null || entity == null)
                return;

            int index = project.Entities.FindIndex(candidate => candidate.Id == entity.Id);
            if (index < 0)
                return;

            ProjectManager.Instance.MoveEntity(entity, index + direction);
        }

        private void OnNodeMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                _tree.SelectedNode = e.Node;

            if (e.Node.Tag is not EntityDefinition entity)
                return;

            _handlingMouseSelection = true;
            try
            {
                if ((ModifierKeys & Keys.Control) == Keys.Control)
                {
                    if (!_selectedIds.Add(entity.Id))
                        _selectedIds.Remove(entity.Id);
                }
                else if ((ModifierKeys & Keys.Shift) == Keys.Shift &&
                         _selectionAnchor is Guid anchorId)
                {
                    SelectRange(anchorId, entity.Id);
                }
                else
                {
                    _selectedIds.Clear();
                    _selectedIds.Add(entity.Id);
                }

                _selectionAnchor = entity.Id;
                _tree.SelectedNode = e.Node;
                RaiseSelectionChanged();
            }
            finally
            {
                _handlingMouseSelection = false;
            }
        }

        private void OnAfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (_rebuilding || _handlingMouseSelection ||
                e.Node?.Tag is not EntityDefinition entity)
            {
                return;
            }

            SelectOnly(entity.Id);
        }

        private void OnNodeDoubleClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is EntityDefinition entity)
                EntityDoubleClicked?.Invoke(entity);
        }

        private void OnTreeKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelected();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F2)
            {
                OnRename(sender, EventArgs.Empty);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                DuplicateSelected();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Z)
            {
                ProjectManager.Instance.Undo();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Y)
            {
                ProjectManager.Instance.Redo();
                e.Handled = true;
            }
        }

        private void OnItemDrag(object? sender, ItemDragEventArgs e)
        {
            if (e.Item is TreeNode { Tag: EntityDefinition } node)
                _tree.DoDragDrop(node, DragDropEffects.Move);
        }

        private void OnDragOver(object? sender, DragEventArgs e)
        {
            if (!e.Data!.GetDataPresent(typeof(TreeNode)))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            Point point = _tree.PointToClient(new Point(e.X, e.Y));
            _tree.SelectedNode = _tree.GetNodeAt(point);
            e.Effect = DragDropEffects.Move;
        }

        private void OnDragDrop(object? sender, DragEventArgs e)
        {
            if (e.Data!.GetData(typeof(TreeNode)) is not TreeNode
                {
                    Tag: EntityDefinition source,
                })
            {
                return;
            }

            Point point = _tree.PointToClient(new Point(e.X, e.Y));
            TreeNode? destinationNode = _tree.GetNodeAt(point);
            EntityDefinition? destination = destinationNode?.Tag as EntityDefinition;

            try
            {
                ProjectManager.Instance.ReparentEntity(source, destination);
                _selectedIds.Clear();
                _selectedIds.Add(source.Id);
                RaiseSelectionChanged();
            }
            catch (InvalidOperationException error)
            {
                MessageBox.Show(
                    error.Message,
                    "Cannot Reparent Entity",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void SelectRange(Guid anchorId, Guid destinationId)
        {
            List<Guid> visibleIds = EnumerateNodes(_tree.Nodes)
                .Where(node => node.Tag is EntityDefinition)
                .Select(node => ((EntityDefinition)node.Tag!).Id)
                .ToList();

            int anchorIndex = visibleIds.IndexOf(anchorId);
            int destinationIndex = visibleIds.IndexOf(destinationId);
            if (anchorIndex < 0 || destinationIndex < 0)
            {
                SelectOnly(destinationId);
                return;
            }

            _selectedIds.Clear();
            int start = Math.Min(anchorIndex, destinationIndex);
            int end = Math.Max(anchorIndex, destinationIndex);
            for (int index = start; index <= end; index++)
                _selectedIds.Add(visibleIds[index]);
        }

        private void SelectOnly(Guid id)
        {
            _selectedIds.Clear();
            _selectedIds.Add(id);
            _selectionAnchor = id;
            RaiseSelectionChanged();
        }

        private void RaiseSelectionChanged()
        {
            IReadOnlyList<EntityDefinition> selected = SelectedEntities();
            EntitiesSelected?.Invoke(selected);
            if (selected.Count > 0)
                EntitySelected?.Invoke(selected[0]);

            _tree.Invalidate();
        }

        private IReadOnlyList<EntityDefinition> SelectedEntities()
        {
            AngeneProject? project = ProjectManager.Instance.CurrentProject;
            return project?.Entities
                       .Where(entity => _selectedIds.Contains(entity.Id))
                       .ToArray()
                   ?? Array.Empty<EntityDefinition>();
        }

        private EntityDefinition? PrimarySelectedEntity()
        {
            if (_tree.SelectedNode?.Tag is EntityDefinition selected &&
                _selectedIds.Contains(selected.Id))
            {
                return ProjectManager.Instance.CurrentProject?.Entities
                    .FirstOrDefault(entity => entity.Id == selected.Id);
            }

            return SelectedEntities().FirstOrDefault();
        }

        private void DrawTreeNode(object? sender, DrawTreeNodeEventArgs e)
        {
            bool selected = e.Node?.Tag is EntityDefinition entity &&
                            _selectedIds.Contains(entity.Id);
            Color background = selected ? EditorTheme.Selection : EditorTheme.Panel;
            using var brush = new SolidBrush(background);
            e.Graphics.FillRectangle(brush, e.Bounds);

            Color foreground = e.Node!.ForeColor == Color.Empty
                ? EditorTheme.TextPrimary
                : e.Node.ForeColor;
            if (selected)
                foreground = EditorTheme.SelectionText;

            TextRenderer.DrawText(
                e.Graphics,
                e.Node.Text,
                e.Node.TreeView!.Font,
                new Point(e.Bounds.X + 4, e.Bounds.Y + 2),
                foreground);
        }

        private Button ToolbarButton(string text, Point location, int width)
        {
            return new Button
            {
                Text = text,
                FlatStyle = FlatStyle.Flat,
                BackColor = EditorTheme.PanelHeader,
                ForeColor = EditorTheme.TextSecondary,
                Font = EditorTheme.FontUISmall,
                Location = location,
                Size = new Size(width, 24),
                FlatAppearance = { BorderColor = EditorTheme.PanelBorder },
            };
        }

        private static string FormatEntityLabel(EntityDefinition entity)
            => $"  ◈ {entity.Name}  ({entity.X}, {entity.Y}, {entity.Z:0.##})";

        private static IEnumerable<TreeNode> EnumerateNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                yield return node;
                foreach (TreeNode child in EnumerateNodes(node.Nodes))
                    yield return child;
            }
        }

        private static void RestoreExpandedState(
            TreeNodeCollection nodes,
            IReadOnlySet<Guid> expandedIds)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag is EntityDefinition entity && expandedIds.Contains(entity.Id))
                    node.Expand();

                RestoreExpandedState(node.Nodes, expandedIds);
            }
        }

        private static void AddMenuItem(
            ContextMenuStrip menu,
            string text,
            EventHandler handler)
        {
            var item = new ToolStripMenuItem(text)
            {
                BackColor = EditorTheme.Panel,
                ForeColor = EditorTheme.TextPrimary,
            };
            item.Click += handler;
            menu.Items.Add(item);
        }

        private sealed record ScriptNodeTag(Guid EntityId, string ScriptName);

        private sealed class SceneRootTag
        {
            public static SceneRootTag Instance { get; } = new();
        }
    }

    internal sealed class RenameDialog : Form
    {
        private readonly TextBox _box;

        public RenameDialog(string title, string current)
        {
            Text = title;
            Size = new Size(320, 120);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = EditorTheme.Panel;
            MaximizeBox = false;
            MinimizeBox = false;

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
            ok.Click += (_, _) =>
            {
                Value = _box.Text.Trim();
                DialogResult = Value.Length == 0 ? DialogResult.None : DialogResult.OK;
                if (DialogResult == DialogResult.OK)
                    Close();
            };

            AcceptButton = ok;
            Controls.AddRange(new Control[] { _box, ok });
        }

        public string Value { get; private set; } = "";
    }
}
