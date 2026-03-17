using AngeneEditor.Theme;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AngeneEditor.Runtime
{
    /// <summary>
    /// Floating window that streams build and host log output in real time.
    /// Opens automatically when a build starts, stays open until dismissed.
    /// </summary>
    public sealed class BuildLogWindow : Form
    {
        private RichTextBox _output;
        private Button _clearBtn;
        private Button _closeBtn;
        private Label _statusLabel;
        private int _lineCount;
        private const int MaxLines = 5000;

        // Colour map matching Angene logger levels
        private static readonly Color ColDefault = Color.FromArgb(200, 200, 215);
        private static readonly Color ColInfo = Color.FromArgb(140, 200, 140);
        private static readonly Color ColWarning = Color.FromArgb(220, 180, 60);
        private static readonly Color ColError = Color.FromArgb(220, 80, 80);
        private static readonly Color ColCritical = Color.FromArgb(255, 60, 60);
        private static readonly Color ColBuild = Color.FromArgb(100, 160, 255);
        private static readonly Color ColEditor = Color.FromArgb(140, 140, 180);
        private static readonly Color ColTime = Color.FromArgb(80, 80, 100);

        public BuildLogWindow()
        {
            Text = "Angene — Build & Runtime Log";
            Size = new Size(860, 500);
            MinimumSize = new Size(500, 300);
            StartPosition = FormStartPosition.Manual;

            // Anchor to bottom-right of screen
            var screen = Screen.PrimaryScreen?.WorkingArea ?? new Rectangle(0, 0, 1920, 1080);
            Location = new Point(screen.Right - Width - 20, screen.Bottom - Height - 20);

            BackColor = EditorTheme.Background;
            ForeColor = EditorTheme.TextPrimary;
            Font = EditorTheme.FontUI;
            ShowInTaskbar = false; // attached to the editor, no separate taskbar entry

            BuildUI();
        }

        // ── UI ────────────────────────────────────────────────────────────────────

        private void BuildUI()
        {
            var toolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 32,
                BackColor = EditorTheme.PanelHeader,
            };

            var titleLbl = new Label
            {
                Text = "BUILD / RUNTIME LOG",
                Location = new Point(10, 7),
                Size = new Size(160, 18),
                Font = EditorTheme.FontUISmall,
                ForeColor = EditorTheme.TextSecondary,
            };

            _statusLabel = new Label
            {
                Text = "Idle",
                Location = new Point(178, 7),
                Size = new Size(200, 18),
                Font = EditorTheme.FontUISmall,
                ForeColor = EditorTheme.TextDisabled,
            };

            _clearBtn = new Button
            {
                Text = "Clear",
                Location = new Point(700, 4),
                Size = new Size(60, 24),
                FlatStyle = FlatStyle.Flat,
                BackColor = EditorTheme.PanelHeader,
                ForeColor = EditorTheme.TextSecondary,
                Font = EditorTheme.FontUISmall,
                FlatAppearance = { BorderColor = EditorTheme.PanelBorder },
            };
            _clearBtn.Click += (_, _) => { _output.Clear(); _lineCount = 0; };

            _closeBtn = new Button
            {
                Text = "Hide",
                Location = new Point(764, 4),
                Size = new Size(60, 24),
                FlatStyle = FlatStyle.Flat,
                BackColor = EditorTheme.PanelHeader,
                ForeColor = EditorTheme.TextSecondary,
                Font = EditorTheme.FontUISmall,
                FlatAppearance = { BorderColor = EditorTheme.PanelBorder },
            };
            _closeBtn.Click += (_, _) => Hide();

            toolbar.Controls.AddRange(
                new Control[] { titleLbl, _statusLabel, _clearBtn, _closeBtn });

            _output = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(12, 12, 18),
                ForeColor = ColDefault,
                Font = EditorTheme.FontCodeSmall,
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                ScrollBars = RichTextBoxScrollBars.Both,
                WordWrap = false,
            };

            Controls.Add(_output);
            Controls.Add(toolbar);
        }

        // ── Public API ────────────────────────────────────────────────────────────

        /// <summary>Call this before kicking off a build.</summary>
        public void BeginBuild(string projectName)
        {
            ShowAndFocus();
            SetStatus($"Building {projectName}…", ColWarning);
            AppendLine($"── Build started: {projectName}  {DateTime.Now:HH:mm:ss} ──", ColBuild);
        }

        /// <summary>Call when dotnet build exits.</summary>
        public void EndBuild(bool success, int exitCode)
        {
            if (success)
            {
                AppendLine($"── Build succeeded  {DateTime.Now:HH:mm:ss} ──", ColInfo);
                SetStatus("Build succeeded", ColInfo);
            }
            else
            {
                AppendLine($"── Build FAILED (exit {exitCode})  {DateTime.Now:HH:mm:ss} ──", ColError);
                SetStatus($"Build failed (exit {exitCode})", ColError);
            }
        }

        /// <summary>Append a raw line (stdout / stderr from dotnet build or the scene host).</summary>
        public void AppendLine(string line) => AppendLine(line, Classify(line));

        /// <summary>Show the window and bring it to the front.</summary>
        public void ShowAndFocus()
        {
            Show();
            BringToFront();
        }

        // ── Internal append ───────────────────────────────────────────────────────

        private void AppendLine(string line, Color color)
        {
            if (_output.InvokeRequired)
            {
                _output.BeginInvoke(() => AppendLine(line, color));
                return;
            }

            // Trim oldest line when over limit
            if (_lineCount >= MaxLines)
            {
                int nl = _output.Text.IndexOf('\n');
                if (nl >= 0)
                {
                    _output.Select(0, nl + 1);
                    _output.SelectedText = "";
                    _lineCount--;
                }
            }

            // Timestamp in muted colour
            _output.SelectionStart = _output.TextLength;
            _output.SelectionColor = ColTime;
            _output.AppendText($"[{DateTime.Now:HH:mm:ss.fff}] ");

            _output.SelectionColor = color;
            _output.AppendText(line + "\n");
            _output.SelectionColor = ColDefault;

            _lineCount++;
            _output.ScrollToCaret();
        }

        private void SetStatus(string text, Color color)
        {
            if (_statusLabel.InvokeRequired)
            { _statusLabel.BeginInvoke(() => SetStatus(text, color)); return; }
            _statusLabel.Text = text;
            _statusLabel.ForeColor = color;
        }

        // ── Line classification ───────────────────────────────────────────────────

        private static Color Classify(string line)
        {
            if (string.IsNullOrEmpty(line)) return ColDefault;

            // Angene logger prefixes
            if (line.Contains("[Critical]") || line.Contains("FATAL")) return ColCritical;
            if (line.Contains("[Error]") || line.Contains("[ERR]")) return ColError;
            if (line.Contains("[Warning]") || line.Contains("warning")) return ColWarning;
            if (line.Contains("[Editor]") || line.Contains("[Build]")) return ColEditor;
            if (line.Contains("[Info]") || line.Contains("succeeded")) return ColInfo;

            // dotnet build output
            if (line.TrimStart().StartsWith("error") || line.Contains(": error CS")) return ColError;
            if (line.TrimStart().StartsWith("warning") || line.Contains(": warning")) return ColWarning;
            if (line.Contains("Build succeeded")) return ColInfo;
            if (line.Contains("Build FAILED")) return ColError;

            return ColDefault;
        }

        // Prevent accidental close — just hide so log history is preserved
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                return;
            }
            base.OnFormClosing(e);
        }
    }
}