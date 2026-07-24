using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AngeneEditor.Theme;

namespace AngeneEditor.Panels
{
    /// <summary>
    /// Bottom panel: log console.
    /// Tails output from the running game process and from the editor itself.
    /// Color-codes log levels matching Angene's Logger output format.
    /// </summary>
    public sealed class ConsolePanel : Panel
    {
        private RichTextBox _output;
        private Button _clearBtn;
        private CheckBox _autoScrollCheck;
        private int _lineCount;
        private const int MaxLines = 2000;

        public ConsolePanel()
        {
            BackColor = EditorTheme.Background;
            Dock = DockStyle.Bottom;
            Height = 180;

            BuildUI();
        }

        private void BuildUI()
        {
            var toolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 28,
                BackColor = EditorTheme.PanelHeader,
            };

            var header = new Label
            {
                Text = "CONSOLE",
                Location = new Point(10, 5),
                Size = new Size(80, 18),
                Font = EditorTheme.FontUISmall,
                ForeColor = EditorTheme.TextSecondary,
            };

            _clearBtn = new Button
            {
                Text = "Clear",
                FlatStyle = FlatStyle.Flat,
                BackColor = EditorTheme.PanelHeader,
                ForeColor = EditorTheme.TextSecondary,
                Font = EditorTheme.FontUISmall,
                Location = new Point(90, 3),
                Size = new Size(50, 22),
                FlatAppearance = { BorderColor = EditorTheme.PanelBorder },
            };
            _clearBtn.Click += (_, _) => { _output.Clear(); _lineCount = 0; };

            _autoScrollCheck = new CheckBox
            {
                Text = "Auto-scroll",
                Checked = true,
                Location = new Point(148, 5),
                Size = new Size(100, 18),
                Font = EditorTheme.FontUISmall,
                ForeColor = EditorTheme.TextSecondary,
                BackColor = EditorTheme.PanelHeader,
            };

            toolbar.Controls.AddRange(new Control[] { header, _clearBtn, _autoScrollCheck });

            _output = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = EditorTheme.Background,
                ForeColor = EditorTheme.TextPrimary,
                Font = EditorTheme.FontCodeSmall,
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                ScrollBars = RichTextBoxScrollBars.Both,
                WordWrap = false,
            };

            Controls.Add(_output);
            Controls.Add(toolbar);
        }

        // ── Public API ─────────────────────────────────────────────────────────

        public void AppendLine(string line)
        {
            if (_output.InvokeRequired) { _output.Invoke(() => AppendLine(line)); return; }

            // Trim to max lines
            if (_lineCount >= MaxLines)
            {
                int newline = _output.Text.IndexOf('\n');
                if (newline >= 0)
                {
                    _output.Select(0, newline + 1);
                    _output.SelectedText = "";
                    _lineCount--;
                }
            }

            Color color = ClassifyLine(line);
            string timestamp = $"[{DateTime.Now:HH:mm:ss}] ";

            _output.SelectionStart = _output.TextLength;
            _output.SelectionLength = 0;
            _output.SelectionColor = EditorTheme.TextDisabled;
            _output.AppendText(timestamp);

            _output.SelectionColor = color;
            _output.AppendText(line + "\n");
            _output.SelectionColor = EditorTheme.TextPrimary;

            _lineCount++;

            if (_autoScrollCheck.Checked)
                _output.ScrollToCaret();
        }

        public void AppendEditorLine(string line)
            => AppendLine($"[Editor] {line}");

        // ── Line classification ────────────────────────────────────────────────

        private static Color ClassifyLine(string line)
        {
            if (line.Contains("[Critical]") || line.Contains("FATAL") || line.Contains("EXCEPTION"))
                return EditorTheme.LogCritical;
            if (line.Contains("[Error]") || line.Contains("[ERR]") || line.Contains("ERROR"))
                return EditorTheme.LogError;
            if (line.Contains("[Warning]") || line.Contains("WARN"))
                return EditorTheme.LogWarning;
            if (line.Contains("[Important]") || line.Contains("[Editor]"))
                return EditorTheme.LogImportant;
            if (line.Contains("[Debug]"))
                return EditorTheme.LogDebug;
            if (line.Contains("Build succeeded"))
                return EditorTheme.Success;
            if (line.Contains("Build failed") || line.Contains("Error"))
                return EditorTheme.LogError;

            return EditorTheme.LogInfo;
        }
    }
}