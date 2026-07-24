using System.Drawing;

namespace AngeneEditor.Theme
{
    /// <summary>
    /// Angene Editor visual theme.
    /// Dark industrial aesthetic matching the engine's personality.
    /// </summary>
    public static class EditorTheme
    {
        // ── Base palette ─────────────────────────────────────────────────────────
        public static readonly Color Background = Color.FromArgb(18, 18, 24);
        public static readonly Color BackgroundAlt = Color.FromArgb(24, 24, 32);
        public static readonly Color Panel = Color.FromArgb(28, 28, 38);
        public static readonly Color PanelBorder = Color.FromArgb(45, 45, 60);
        public static readonly Color PanelHeader = Color.FromArgb(35, 35, 50);
        public static readonly Color Highlight = Color.FromArgb(55, 55, 80);
        public static readonly Color Selection = Color.FromArgb(50, 80, 130);
        public static readonly Color SelectionText = Color.FromArgb(200, 220, 255);

        // ── Accent colors ────────────────────────────────────────────────────────
        public static readonly Color Accent = Color.FromArgb(80, 120, 220);
        public static readonly Color AccentHover = Color.FromArgb(100, 150, 255);
        public static readonly Color AccentDim = Color.FromArgb(50, 75, 140);
        public static readonly Color Warning = Color.FromArgb(220, 160, 50);
        public static readonly Color Error = Color.FromArgb(200, 60, 60);
        public static readonly Color Success = Color.FromArgb(60, 180, 100);

        // ── Text ─────────────────────────────────────────────────────────────────
        public static readonly Color TextPrimary = Color.FromArgb(220, 220, 235);
        public static readonly Color TextSecondary = Color.FromArgb(140, 140, 165);
        public static readonly Color TextDisabled = Color.FromArgb(80, 80, 100);
        public static readonly Color TextAccent = Color.FromArgb(120, 160, 255);

        // ── Log level colors ─────────────────────────────────────────────────────
        public static readonly Color LogDebug = Color.FromArgb(100, 100, 130);
        public static readonly Color LogInfo = Color.FromArgb(180, 180, 200);
        public static readonly Color LogWarning = Color.FromArgb(220, 170, 60);
        public static readonly Color LogError = Color.FromArgb(220, 80, 80);
        public static readonly Color LogCritical = Color.FromArgb(255, 60, 60);
        public static readonly Color LogImportant = Color.FromArgb(80, 180, 255);

        // ── Fonts ────────────────────────────────────────────────────────────────
        public static readonly Font FontUI = new Font("Segoe UI", 9f, FontStyle.Regular);
        public static readonly Font FontUIBold = new Font("Segoe UI", 9f, FontStyle.Bold);
        public static readonly Font FontUISmall = new Font("Segoe UI", 8f, FontStyle.Regular);
        public static readonly Font FontHeader = new Font("Segoe UI", 10f, FontStyle.Bold);
        public static readonly Font FontCode = new Font("Consolas", 9.5f, FontStyle.Regular);
        public static readonly Font FontCodeSmall = new Font("Consolas", 8.5f, FontStyle.Regular);
        public static readonly Font FontTitle = new Font("Segoe UI", 11f, FontStyle.Bold);

        // ── Apply dark mode to a control tree ────────────────────────────────────
        public static void Apply(System.Windows.Forms.Control root)
        {
            root.BackColor = Background;
            root.ForeColor = TextPrimary;
            root.Font = FontUI;

            foreach (System.Windows.Forms.Control c in root.Controls)
                Apply(c);
        }

        public static System.Windows.Forms.ToolStripRenderer MenuRenderer()
            => new DarkMenuRenderer();
    }

    /// <summary>Custom renderer for dark menu strips.</summary>
    internal class DarkMenuRenderer : System.Windows.Forms.ToolStripProfessionalRenderer
    {
        public DarkMenuRenderer() : base(new DarkColorTable()) { }
    }

    internal class DarkColorTable : System.Windows.Forms.ProfessionalColorTable
    {
        public override Color MenuItemSelected => EditorTheme.Highlight;
        public override Color MenuItemBorder => EditorTheme.PanelBorder;
        public override Color MenuBorder => EditorTheme.PanelBorder;
        public override Color ToolStripDropDownBackground => EditorTheme.Panel;
        public override Color MenuItemSelectedGradientBegin => EditorTheme.Highlight;
        public override Color MenuItemSelectedGradientEnd => EditorTheme.Highlight;
        public override Color MenuStripGradientBegin => EditorTheme.PanelHeader;
        public override Color MenuStripGradientEnd => EditorTheme.PanelHeader;
        public override Color SeparatorDark => EditorTheme.PanelBorder;
        public override Color SeparatorLight => EditorTheme.PanelBorder;
        public override Color ImageMarginGradientBegin => EditorTheme.Panel;
        public override Color ImageMarginGradientMiddle => EditorTheme.Panel;
        public override Color ImageMarginGradientEnd => EditorTheme.Panel;
    }
}
