using System.Drawing;
using System.Windows.Forms;
using AngeneEditor.Theme;

namespace AngeneEditor.Dialogs
{
    /// <summary>
    /// Shown when the game creates more than one window.
    /// Lets the developer choose whether to keep multi-window handling
    /// (secondary window shown outside editor) or disable it.
    /// </summary>
    public sealed class MultiWindowDialog : Form
    {
        public bool KeepMultiWindow { get; private set; } = true;

        public MultiWindowDialog(int windowCount)
        {
            Text = "Multi-Window Detected";
            Size = new Size(480, 220);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = EditorTheme.Panel;
            ForeColor = EditorTheme.TextPrimary;
            Font = EditorTheme.FontUI;

            var icon = new Label
            {
                Text = "⚠",
                Font = new Font("Segoe UI", 28f),
                ForeColor = EditorTheme.Warning,
                Location = new Point(20, 20),
                Size = new Size(50, 50),
                TextAlign = ContentAlignment.MiddleCenter,
            };

            var title = new Label
            {
                Text = $"Multiple windows detected ({windowCount})",
                Font = EditorTheme.FontHeader,
                ForeColor = EditorTheme.Warning,
                Location = new Point(76, 20),
                Size = new Size(380, 24),
            };

            var body = new Label
            {
                Text = "Your game has created more than one window.\n\n" +
                            "Keep Multi-Window: secondary windows open outside the editor.\n" +
                            "Disable: only the primary window is shown in the preview panel.",
                ForeColor = EditorTheme.TextSecondary,
                Location = new Point(20, 60),
                Size = new Size(440, 70),
            };

            var btnKeep = MakeButton("Keep Multi-Window", EditorTheme.Accent, new Point(20, 148));
            btnKeep.Click += (_, _) =>
            {
                KeepMultiWindow = true;
                DialogResult = DialogResult.Yes;
                Close();
            };

            var btnDisable = MakeButton("Disable Multi-Window", EditorTheme.PanelHeader, new Point(210, 148));
            btnDisable.ForeColor = EditorTheme.TextSecondary;
            btnDisable.Click += (_, _) =>
            {
                KeepMultiWindow = false;
                DialogResult = DialogResult.No;
                Close();
            };

            Controls.AddRange(new Control[] { icon, title, body, btnKeep, btnDisable });
        }

        private static Button MakeButton(string text, Color back, Point loc)
        {
            return new Button
            {
                Text = text,
                BackColor = back,
                ForeColor = EditorTheme.TextPrimary,
                FlatStyle = FlatStyle.Flat,
                Location = loc,
                Size = new Size(180, 34),
                Font = EditorTheme.FontUIBold,
                FlatAppearance = { BorderColor = EditorTheme.PanelBorder, BorderSize = 1 }
            };
        }
    }
}