using AngeneEditor.Project;
using AngeneEditor.Theme;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AngeneEditor.Panels
{
    /// <summary>
    /// A lightweight, editor-native 2D scene viewport. It is intentionally
    /// independent from the runtime renderer so scenes remain editable even when
    /// the game project has not been built.
    /// </summary>
    public sealed class SceneViewportPanel : Panel
    {
        private const float EntitySize = 24f;
        private const float MinZoom = 0.2f;
        private const float MaxZoom = 8f;
        private static readonly (string Label, int Width, ToolbarAction Action)[] ToolbarItems =
        {
            ("W Move", 66, ToolbarAction.Move),
            ("E Rotate", 70, ToolbarAction.Rotate),
            ("R Scale", 66, ToolbarAction.Scale),
            ("F Frame", 68, ToolbarAction.FrameSelected),
            ("All", 42, ToolbarAction.FrameAll),
            ("Grid", 46, ToolbarAction.Grid),
            ("Snap", 48, ToolbarAction.Snap),
        };

        private readonly Font _overlayFont = new("Segoe UI", 8.5f);
        private readonly Font _labelFont = new("Segoe UI", 8f);
        private readonly StringFormat _centeredText = new()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center,
        };
        private PointF _pan;
        private float _zoom = 1f;
        private Guid? _selectedId;
        private ViewportTool _tool = ViewportTool.Move;
        private ViewportDrag _drag = ViewportDrag.None;
        private Point _dragStartScreen;
        private PointF _panAtDragStart;
        private int _startX;
        private int _startY;
        private float _startRotation;
        private float _startScaleX;
        private float _startScaleY;
        private float _previewX;
        private float _previewY;
        private float _previewRotation;
        private float _previewScaleX;
        private float _previewScaleY;
        private bool _hasPreview;

        public SceneViewportPanel()
        {
            Dock = DockStyle.Fill;
            BackColor = Color.FromArgb(15, 16, 21);
            TabStop = true;
            DoubleBuffered = true;
            ResizeRedraw = true;

            ProjectManager manager = ProjectManager.Instance;
            manager.ProjectOpened += _ =>
            {
                _selectedId = null;
                _pan = PointF.Empty;
                _zoom = 1f;
                NotifyViewportStateChanged();
                Invalidate();
            };
            manager.EntitiesChanged += () =>
            {
                if (_selectedId is Guid id &&
                    manager.CurrentProject?.Entities.All(entity => entity.Id != id) == true)
                {
                    _selectedId = null;
                }

                NotifyViewportStateChanged();
                Invalidate();
            };

            MouseDown += OnViewportMouseDown;
            MouseMove += OnViewportMouseMove;
            MouseUp += OnViewportMouseUp;
            MouseWheel += OnViewportMouseWheel;
            KeyDown += OnViewportKeyDown;
            MouseEnter += (_, _) => Focus();
            NotifyViewportStateChanged();
        }

        public event Action<EntityDefinition?>? EntitySelected;
        public event Action? ViewportStateChanged;
        public int ZoomPercent => (int)Math.Round(_zoom * 100f);
        public bool IsGridVisible =>
            ProjectManager.Instance.CurrentProject?.Scene.Settings.GridVisible == true;
        public bool IsSnapEnabled =>
            ProjectManager.Instance.CurrentProject?.Scene.Settings.SnapEnabled == true;

        public ViewportTool ActiveTool
        {
            get => _tool;
            set
            {
                _tool = value;
                NotifyViewportStateChanged();
                Invalidate();
            }
        }

        public void SelectEntity(EntityDefinition? entity)
        {
            _selectedId = entity?.Id;
            _hasPreview = false;
            Invalidate();
        }

        public void FrameSelected()
        {
            EntityDefinition? entity = SelectedEntity();
            if (entity == null)
                return;

            _pan = new PointF(-entity.X * _zoom, entity.Y * _zoom);
            Invalidate();
        }

        public void FrameAll()
        {
            EntityDefinition[] entities =
                ProjectManager.Instance.CurrentProject?.Entities.ToArray()
                ?? Array.Empty<EntityDefinition>();
            if (entities.Length == 0)
            {
                ResetCamera();
                return;
            }

            float minX = entities.Min(entity => entity.X);
            float maxX = entities.Max(entity => entity.X);
            float minY = entities.Min(entity => entity.Y);
            float maxY = entities.Max(entity => entity.Y);
            float width = Math.Max(64f, maxX - minX + 64f);
            float height = Math.Max(64f, maxY - minY + 64f);

            _zoom = Math.Clamp(
                Math.Min(
                    Math.Max(1f, ClientSize.Width - 100f) / width,
                    Math.Max(1f, ClientSize.Height - 100f) / height),
                MinZoom,
                Math.Min(2.5f, MaxZoom));

            float centerX = (minX + maxX) / 2f;
            float centerY = (minY + maxY) / 2f;
            _pan = new PointF(-centerX * _zoom, centerY * _zoom);
            NotifyViewportStateChanged();
            Invalidate();
        }

        public void ResetCamera()
        {
            _pan = PointF.Empty;
            _zoom = 1f;
            NotifyViewportStateChanged();
            Invalidate();
        }

        public void ToggleGrid()
        {
            AngeneProject? project = ProjectManager.Instance.CurrentProject;
            if (project == null)
                return;

            bool visible = project.Scene.Settings.GridVisible;
            ProjectManager.Instance.UpdateSceneSettings(
                visible ? "Hide grid" : "Show grid",
                settings => settings.GridVisible = !visible);
        }

        public void ToggleSnap()
        {
            AngeneProject? project = ProjectManager.Instance.CurrentProject;
            if (project == null)
                return;

            bool enabled = project.Scene.Settings.SnapEnabled;
            ProjectManager.Instance.UpdateSceneSettings(
                enabled ? "Disable snapping" : "Enable snapping",
                settings => settings.SnapEnabled = !enabled);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            AngeneProject? project = ProjectManager.Instance.CurrentProject;
            if (project == null)
            {
                DrawEmptyState(graphics);
                DrawToolbar(graphics);
                return;
            }

            if (project.Scene.Settings.GridVisible)
                DrawGrid(graphics, project);

            DrawWorldAxes(graphics);
            foreach (EntityDefinition entity in project.Entities)
                DrawEntity(graphics, entity);

            EntityDefinition? selected = SelectedEntity();
            if (selected != null)
                DrawGizmo(graphics, selected);

            DrawToolbar(graphics);
        }

        private void DrawEmptyState(Graphics graphics)
        {
            Rectangle bounds = ClientRectangle;
            using var title = new Font("Segoe UI", 13f);
            using var brush = new SolidBrush(EditorTheme.TextDisabled);
            graphics.DrawString(
                "SCENE VIEW\n\nCreate or open a project to begin.",
                title,
                brush,
                bounds,
                _centeredText);
        }

        private void DrawGrid(Graphics graphics, AngeneProject project)
        {
            float spacing = Math.Max(1f, project.Scene.Settings.GridSize) * _zoom;
            while (spacing < 12f)
                spacing *= 2f;
            while (spacing > 96f)
                spacing /= 2f;

            PointF origin = WorldToScreen(PointF.Empty);
            int verticalIndex = 0;
            for (float x = PositiveModulo(origin.X, spacing); x < Width; x += spacing)
            {
                bool major = Math.Abs(verticalIndex++ % 5) == 0;
                using var pen = new Pen(
                    major ? Color.FromArgb(46, 49, 59) : Color.FromArgb(30, 33, 41),
                    1f);
                graphics.DrawLine(pen, x, 0, x, Height);
            }

            int horizontalIndex = 0;
            for (float y = PositiveModulo(origin.Y, spacing); y < Height; y += spacing)
            {
                bool major = Math.Abs(horizontalIndex++ % 5) == 0;
                using var pen = new Pen(
                    major ? Color.FromArgb(46, 49, 59) : Color.FromArgb(30, 33, 41),
                    1f);
                graphics.DrawLine(pen, 0, y, Width, y);
            }
        }

        private void DrawWorldAxes(Graphics graphics)
        {
            PointF origin = WorldToScreen(PointF.Empty);
            using var xPen = new Pen(Color.FromArgb(90, 190, 75, 75));
            using var yPen = new Pen(Color.FromArgb(90, 75, 190, 105));
            graphics.DrawLine(xPen, 0, origin.Y, Width, origin.Y);
            graphics.DrawLine(yPen, origin.X, 0, origin.X, Height);
        }

        private void DrawEntity(Graphics graphics, EntityDefinition entity)
        {
            PointF center = EntityScreenPosition(entity);
            float scaleX = _hasPreview && entity.Id == _selectedId
                ? _previewScaleX
                : entity.ScaleX;
            float scaleY = _hasPreview && entity.Id == _selectedId
                ? _previewScaleY
                : entity.ScaleY;
            float rotation = _hasPreview && entity.Id == _selectedId
                ? _previewRotation
                : entity.RotationZ;
            float width = Math.Max(8f, EntitySize * Math.Abs(scaleX) * _zoom);
            float height = Math.Max(8f, EntitySize * Math.Abs(scaleY) * _zoom);
            bool selected = entity.Id == _selectedId;

            GraphicsState state = graphics.Save();
            graphics.TranslateTransform(center.X, center.Y);
            graphics.RotateTransform(-rotation);

            using var fill = new SolidBrush(
                selected
                    ? Color.FromArgb(90, EditorTheme.Accent)
                    : Color.FromArgb(entity.Enabled ? 58 : 28, 115, 145, 205));
            using var outline = new Pen(
                selected ? EditorTheme.Accent : EditorTheme.TextSecondary,
                selected ? 2f : 1f);
            if (!entity.Enabled)
                outline.DashStyle = DashStyle.Dash;

            var rectangle = new RectangleF(-width / 2f, -height / 2f, width, height);
            graphics.FillRectangle(fill, rectangle);
            graphics.DrawRectangle(outline, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            graphics.Restore(state);

            using var textBrush = new SolidBrush(
                entity.Enabled ? EditorTheme.TextPrimary : EditorTheme.TextDisabled);
            graphics.DrawString(
                entity.Name,
                _labelFont,
                textBrush,
                center.X + 12f,
                center.Y + 10f);
        }

        private void DrawGizmo(Graphics graphics, EntityDefinition entity)
        {
            PointF center = EntityScreenPosition(entity);
            const float length = 64f;

            switch (_tool)
            {
                case ViewportTool.Move:
                    DrawAxis(graphics, center, new PointF(center.X + length, center.Y),
                        Color.FromArgb(235, 224, 78, 78), "X", arrow: true);
                    DrawAxis(graphics, center, new PointF(center.X, center.Y - length),
                        Color.FromArgb(235, 92, 210, 116), "Y", arrow: true);
                    using (var centerBrush = new SolidBrush(Color.FromArgb(220, 233, 205, 72)))
                        graphics.FillRectangle(centerBrush, center.X - 5f, center.Y - 5f, 10f, 10f);
                    break;

                case ViewportTool.Rotate:
                    using (var pen = new Pen(Color.FromArgb(235, 244, 197, 66), 3f))
                        graphics.DrawEllipse(pen, center.X - 46f, center.Y - 46f, 92f, 92f);
                    break;

                case ViewportTool.Scale:
                    DrawAxis(graphics, center, new PointF(center.X + length, center.Y),
                        Color.FromArgb(235, 224, 78, 78), "X", arrow: false);
                    DrawAxis(graphics, center, new PointF(center.X, center.Y - length),
                        Color.FromArgb(235, 92, 210, 116), "Y", arrow: false);
                    using (var centerBrush = new SolidBrush(Color.FromArgb(220, 233, 205, 72)))
                        graphics.FillRectangle(centerBrush, center.X - 5f, center.Y - 5f, 10f, 10f);
                    break;
            }
        }

        private void DrawAxis(
            Graphics graphics,
            PointF start,
            PointF end,
            Color color,
            string label,
            bool arrow)
        {
            using var pen = new Pen(color, 3f)
            {
                EndCap = arrow ? LineCap.ArrowAnchor : LineCap.Square,
            };
            graphics.DrawLine(pen, start, end);
            using var brush = new SolidBrush(color);
            if (!arrow)
                graphics.FillRectangle(brush, end.X - 5f, end.Y - 5f, 10f, 10f);
            graphics.DrawString(label, _overlayFont, brush, end.X + 5f, end.Y - 9f);
        }

        private void DrawToolbar(Graphics graphics)
        {
            Rectangle bounds = ToolbarBounds();
            using var background = new SolidBrush(Color.FromArgb(29, 31, 39));
            using var border = new Pen(EditorTheme.PanelBorder);
            graphics.FillRectangle(background, bounds);
            graphics.DrawRectangle(border, bounds);

            int x = bounds.X + 2;
            foreach ((string label, int width, ToolbarAction action) in ToolbarItems)
            {
                var buttonBounds = new Rectangle(x, bounds.Y + 3, width, 26);
                bool active = IsToolbarActionActive(action);
                using var fill = new SolidBrush(
                    active ? EditorTheme.AccentDim : Color.FromArgb(45, 48, 59));
                graphics.FillRectangle(fill, buttonBounds);
                TextRenderer.DrawText(
                    graphics,
                    label,
                    _overlayFont,
                    buttonBounds,
                    active ? Color.White : EditorTheme.TextSecondary,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter |
                    TextFormatFlags.NoPadding);
                x += width + 2;
            }

            var zoomBounds = new Rectangle(x, bounds.Y + 3, 55, 26);
            TextRenderer.DrawText(
                graphics,
                $"{ZoomPercent}%",
                _overlayFont,
                zoomBounds,
                EditorTheme.TextSecondary,
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.NoPadding);
        }

        private bool HandleToolbarClick(Point point)
        {
            Rectangle bounds = ToolbarBounds();
            if (!bounds.Contains(point))
                return false;

            int x = bounds.X + 2;
            foreach (var (_, width, action) in ToolbarItems)
            {
                var buttonBounds = new Rectangle(x, bounds.Y + 3, width, 26);
                if (buttonBounds.Contains(point))
                {
                    switch (action)
                    {
                        case ToolbarAction.Move:
                            ActiveTool = ViewportTool.Move;
                            break;
                        case ToolbarAction.Rotate:
                            ActiveTool = ViewportTool.Rotate;
                            break;
                        case ToolbarAction.Scale:
                            ActiveTool = ViewportTool.Scale;
                            break;
                        case ToolbarAction.FrameSelected:
                            FrameSelected();
                            break;
                        case ToolbarAction.FrameAll:
                            FrameAll();
                            break;
                        case ToolbarAction.Grid:
                            ToggleGrid();
                            break;
                        case ToolbarAction.Snap:
                            ToggleSnap();
                            break;
                    }

                    Invalidate();
                    return true;
                }

                x += width + 2;
            }

            return true;
        }

        private bool IsToolbarActionActive(ToolbarAction action)
            => action switch
            {
                ToolbarAction.Move => _tool == ViewportTool.Move,
                ToolbarAction.Rotate => _tool == ViewportTool.Rotate,
                ToolbarAction.Scale => _tool == ViewportTool.Scale,
                ToolbarAction.Grid => IsGridVisible,
                ToolbarAction.Snap => IsSnapEnabled,
                _ => false,
            };

        private static Rectangle ToolbarBounds()
            => new(10, 44, 485, 32);

        private void NotifyViewportStateChanged()
        {
            ViewportStateChanged?.Invoke();
        }

        private void OnViewportMouseDown(object? sender, MouseEventArgs e)
        {
            Focus();

            if (e.Button == MouseButtons.Left && HandleToolbarClick(e.Location))
                return;

            if (e.Button == MouseButtons.Middle ||
                (e.Button == MouseButtons.Left && ModifierKeys.HasFlag(Keys.Space)))
            {
                _drag = ViewportDrag.Pan;
                _dragStartScreen = e.Location;
                _panAtDragStart = _pan;
                Cursor = Cursors.SizeAll;
                return;
            }

            if (e.Button != MouseButtons.Left)
                return;

            EntityDefinition? selected = SelectedEntity();
            ViewportDrag gizmoDrag = selected == null
                ? ViewportDrag.None
                : HitTestGizmo(e.Location, selected);
            if (gizmoDrag != ViewportDrag.None)
            {
                BeginTransformDrag(gizmoDrag, e.Location, selected!);
                return;
            }

            EntityDefinition? hit = HitTestEntity(e.Location);
            _selectedId = hit?.Id;
            _hasPreview = false;
            EntitySelected?.Invoke(hit);
            Invalidate();
        }

        private void OnViewportMouseMove(object? sender, MouseEventArgs e)
        {
            if (_drag == ViewportDrag.Pan)
            {
                _pan = new PointF(
                    _panAtDragStart.X + e.X - _dragStartScreen.X,
                    _panAtDragStart.Y + e.Y - _dragStartScreen.Y);
                Invalidate();
                return;
            }

            EntityDefinition? entity = SelectedEntity();
            if (_drag == ViewportDrag.None || entity == null)
                return;

            float dx = (e.X - _dragStartScreen.X) / _zoom;
            float dy = -(e.Y - _dragStartScreen.Y) / _zoom;
            bool snap = IsSnapActive();

            switch (_drag)
            {
                case ViewportDrag.MoveFree:
                case ViewportDrag.MoveX:
                case ViewportDrag.MoveY:
                    _previewX = _startX + (_drag == ViewportDrag.MoveY ? 0f : dx);
                    _previewY = _startY + (_drag == ViewportDrag.MoveX ? 0f : dy);
                    if (snap)
                    {
                        float grid = Math.Max(
                            1f,
                            ProjectManager.Instance.CurrentProject?.Scene.Settings.GridSize ?? 1f);
                        _previewX = Snap(_previewX, grid);
                        _previewY = Snap(_previewY, grid);
                    }
                    break;

                case ViewportDrag.Rotate:
                    PointF center = EntityScreenPosition(entity);
                    float startAngle = Angle(center, _dragStartScreen);
                    float currentAngle = Angle(center, e.Location);
                    _previewRotation = _startRotation - (currentAngle - startAngle);
                    if (snap)
                        _previewRotation = Snap(_previewRotation, 15f);
                    break;

                case ViewportDrag.ScaleFree:
                case ViewportDrag.ScaleX:
                case ViewportDrag.ScaleY:
                    float scaleDelta = (dx + dy) / 80f;
                    _previewScaleX = _drag == ViewportDrag.ScaleY
                        ? _startScaleX
                        : Math.Max(0.05f, _startScaleX + scaleDelta);
                    _previewScaleY = _drag == ViewportDrag.ScaleX
                        ? _startScaleY
                        : Math.Max(0.05f, _startScaleY + scaleDelta);
                    if (snap)
                    {
                        _previewScaleX = Math.Max(0.05f, Snap(_previewScaleX, 0.1f));
                        _previewScaleY = Math.Max(0.05f, Snap(_previewScaleY, 0.1f));
                    }
                    break;
            }

            _hasPreview = true;
            Invalidate();
        }

        private void OnViewportMouseUp(object? sender, MouseEventArgs e)
        {
            if (_drag == ViewportDrag.Pan)
            {
                _drag = ViewportDrag.None;
                Cursor = Cursors.Default;
                return;
            }

            EntityDefinition? entity = SelectedEntity();
            ViewportDrag completedDrag = _drag;
            _drag = ViewportDrag.None;
            Cursor = Cursors.Default;

            if (!_hasPreview || entity == null)
                return;

            EntityDefinition updated = ProjectManager.Instance.UpdateEntity(
                entity,
                $"{_tool} {entity.Name}",
                target =>
                {
                    if (completedDrag is ViewportDrag.MoveFree or
                        ViewportDrag.MoveX or ViewportDrag.MoveY)
                    {
                        target.X = (int)MathF.Round(_previewX);
                        target.Y = (int)MathF.Round(_previewY);
                    }
                    else if (completedDrag == ViewportDrag.Rotate)
                    {
                        target.RotationZ = NormalizeDegrees(_previewRotation);
                    }
                    else
                    {
                        target.ScaleX = _previewScaleX;
                        target.ScaleY = _previewScaleY;
                    }
                });

            _selectedId = updated.Id;
            _hasPreview = false;
            EntitySelected?.Invoke(updated);
            Invalidate();
        }

        private void OnViewportMouseWheel(object? sender, MouseEventArgs e)
        {
            PointF before = ScreenToWorld(e.Location);
            float factor = e.Delta > 0 ? 1.12f : 1f / 1.12f;
            _zoom = Math.Clamp(_zoom * factor, MinZoom, MaxZoom);
            PointF after = ScreenToWorld(e.Location);
            _pan = new PointF(
                _pan.X + (after.X - before.X) * _zoom,
                _pan.Y - (after.Y - before.Y) * _zoom);
            NotifyViewportStateChanged();
            Invalidate();
        }

        private void OnViewportKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                ActiveTool = ViewportTool.Move;
            else if (e.KeyCode == Keys.E)
                ActiveTool = ViewportTool.Rotate;
            else if (e.KeyCode == Keys.R)
                ActiveTool = ViewportTool.Scale;
            else if (e.KeyCode == Keys.F)
                FrameSelected();
            else if (e.KeyCode == Keys.G)
                ToggleGrid();
            else if (e.KeyCode == Keys.S && !e.Control)
                ToggleSnap();
            else
                return;

            e.Handled = true;
        }

        private void BeginTransformDrag(
            ViewportDrag drag,
            Point location,
            EntityDefinition entity)
        {
            _drag = drag;
            _dragStartScreen = location;
            _startX = entity.X;
            _startY = entity.Y;
            _startRotation = entity.RotationZ;
            _startScaleX = entity.ScaleX;
            _startScaleY = entity.ScaleY;
            _previewX = entity.X;
            _previewY = entity.Y;
            _previewRotation = entity.RotationZ;
            _previewScaleX = entity.ScaleX;
            _previewScaleY = entity.ScaleY;
            _hasPreview = false;
            Cursor = Cursors.SizeAll;
        }

        private ViewportDrag HitTestGizmo(Point location, EntityDefinition entity)
        {
            PointF center = EntityScreenPosition(entity);
            float distance = Distance(center, location);

            if (_tool == ViewportTool.Rotate)
                return Math.Abs(distance - 46f) <= 8f
                    ? ViewportDrag.Rotate
                    : ViewportDrag.None;

            if (Math.Abs(location.X - center.X) <= 9f &&
                Math.Abs(location.Y - center.Y) <= 9f)
            {
                return _tool == ViewportTool.Move
                    ? ViewportDrag.MoveFree
                    : ViewportDrag.ScaleFree;
            }

            if (location.X >= center.X + 8f &&
                location.X <= center.X + 72f &&
                Math.Abs(location.Y - center.Y) <= 8f)
            {
                return _tool == ViewportTool.Move
                    ? ViewportDrag.MoveX
                    : ViewportDrag.ScaleX;
            }

            if (location.Y <= center.Y - 8f &&
                location.Y >= center.Y - 72f &&
                Math.Abs(location.X - center.X) <= 8f)
            {
                return _tool == ViewportTool.Move
                    ? ViewportDrag.MoveY
                    : ViewportDrag.ScaleY;
            }

            return ViewportDrag.None;
        }

        private EntityDefinition? HitTestEntity(Point location)
        {
            AngeneProject? project = ProjectManager.Instance.CurrentProject;
            if (project == null)
                return null;

            return project.Entities
                .AsEnumerable()
                .Reverse()
                .FirstOrDefault(entity =>
                {
                    PointF center = EntityScreenPosition(entity);
                    float halfWidth = Math.Max(8f, EntitySize * Math.Abs(entity.ScaleX) * _zoom) / 2f;
                    float halfHeight = Math.Max(8f, EntitySize * Math.Abs(entity.ScaleY) * _zoom) / 2f;
                    return Math.Abs(location.X - center.X) <= halfWidth + 5f &&
                           Math.Abs(location.Y - center.Y) <= halfHeight + 5f;
                });
        }

        private EntityDefinition? SelectedEntity()
        {
            if (_selectedId is not Guid id)
                return null;

            return ProjectManager.Instance.CurrentProject?.Entities
                .FirstOrDefault(entity => entity.Id == id);
        }

        private PointF EntityScreenPosition(EntityDefinition entity)
        {
            float x = _hasPreview && entity.Id == _selectedId ? _previewX : entity.X;
            float y = _hasPreview && entity.Id == _selectedId ? _previewY : entity.Y;
            return WorldToScreen(new PointF(x, y));
        }

        private PointF WorldToScreen(PointF world)
        {
            return new PointF(
                ClientSize.Width / 2f + _pan.X + world.X * _zoom,
                ClientSize.Height / 2f + _pan.Y - world.Y * _zoom);
        }

        private PointF ScreenToWorld(PointF screen)
        {
            return new PointF(
                (screen.X - ClientSize.Width / 2f - _pan.X) / _zoom,
                -(screen.Y - ClientSize.Height / 2f - _pan.Y) / _zoom);
        }

        private bool IsSnapActive()
        {
            return ModifierKeys.HasFlag(Keys.Control) ||
                   ProjectManager.Instance.CurrentProject?.Scene.Settings.SnapEnabled == true;
        }

        private static float Snap(float value, float interval)
            => MathF.Round(value / interval) * interval;

        private static float Angle(PointF center, Point point)
            => MathF.Atan2(point.Y - center.Y, point.X - center.X) * 180f / MathF.PI;

        private static float Distance(PointF first, PointF second)
        {
            float x = first.X - second.X;
            float y = first.Y - second.Y;
            return MathF.Sqrt(x * x + y * y);
        }

        private static float NormalizeDegrees(float value)
        {
            value %= 360f;
            return value < 0f ? value + 360f : value;
        }

        private static float PositiveModulo(float value, float divisor)
            => (value % divisor + divisor) % divisor;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _overlayFont.Dispose();
                _labelFont.Dispose();
                _centeredText.Dispose();
            }

            base.Dispose(disposing);
        }

        private enum ToolbarAction
        {
            Move,
            Rotate,
            Scale,
            FrameSelected,
            FrameAll,
            Grid,
            Snap,
        }

        private enum ViewportDrag
        {
            None,
            Pan,
            MoveFree,
            MoveX,
            MoveY,
            Rotate,
            ScaleFree,
            ScaleX,
            ScaleY,
        }
    }

    public enum ViewportTool
    {
        Move,
        Rotate,
        Scale,
    }
}
