using AngeneEditor.Project;
using AngeneEditor.Theme;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AngeneEditor.ScriptEditor
{
    /// <summary>
    /// Built-in script editor window.
    /// Provides basic C# syntax highlighting via RichTextBox coloring.
    /// Offers options to open in Visual Studio or VS Code.
    /// Auto-saves on close back to the source file.
    /// </summary>
    public sealed class ScriptEditorWindow : Form
    {
        private readonly string _filePath;
        private RichTextBox? _editor;
        private Label? _statusLabel;
        private bool _modified;

        // Initialized AFTER BuildUI+LoadFile so OnTextChanged must null-check it
        private System.Windows.Forms.Timer? _highlightDebounce;

        public ScriptEditorWindow(string filePath)
        {
            _filePath = filePath;

            Text = $"Script Editor — {Path.GetFileName(filePath)}";
            Size = new Size(900, 650);
            MinimumSize = new Size(600, 400);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = EditorTheme.Background;
            ForeColor = EditorTheme.TextPrimary;
            Font = EditorTheme.FontUI;

            BuildUI();
            LoadFile();

            // Timer must be created AFTER LoadFile() so the TextChanged
            // fired by setting _editor.Text doesn't dereference a null timer
            _highlightDebounce = new System.Windows.Forms.Timer { Interval = 300 };
            _highlightDebounce.Tick += (_, _) =>
            {
                _highlightDebounce.Stop();
                ApplySyntaxHighlight();
            };

            FormClosing += OnClosing;
        }

        // ── Static factory helpers ────────────────────────────────────────────────

        /// <summary>
        /// Opens the project's Program.cs in the editor.
        /// </summary>
        public static void OpenProgramCs(Form owner)
        {
            var project = ProjectManager.Instance.CurrentProject;
            if (project == null)
            { MessageBox.Show("No project open.", "Error"); return; }

            string path = Path.Combine(project.RootPath, "Program.cs");
            if (!File.Exists(path))
            { MessageBox.Show($"Program.cs not found at:\n{path}", "Not Found"); return; }

            new ScriptEditorWindow(path).Show(owner);
        }

        /// <summary>
        /// Opens the project's .csproj in Visual Studio (searches common install paths).
        /// Falls back to a message if VS is not found.
        /// </summary>
        public static void OpenCsprojInVs(Form owner)
        {
            var project = ProjectManager.Instance.CurrentProject;
            if (project == null)
            { MessageBox.Show("No project open.", "Error"); return; }

            string csproj = project.CsprojPath;
            if (!File.Exists(csproj))
            { MessageBox.Show($"csproj not found at:\n{csproj}", "Not Found"); return; }

            string? vsPath = FindVisualStudio();
            if (vsPath == null)
            {
                MessageBox.Show(
                    "Visual Studio 2019/2022 not found.\n" +
                    "Make sure it is installed in the default location.",
                    "Visual Studio Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Launch VS with the csproj — VS opens the project and you can navigate to any file
            Process.Start(vsPath, $"\"{csproj}\"");
        }

        /// <summary>
        /// Opens a specific file in Visual Studio via devenv /edit.
        /// VS must already be open with the project, or it opens a new instance.
        /// </summary>
        public static void OpenFileInVs(string filePath, Form owner)
        {
            string? vsPath = FindVisualStudio();
            if (vsPath == null)
            {
                // Fall back to built-in editor
                if (File.Exists(filePath))
                    new ScriptEditorWindow(filePath).Show(owner);
                return;
            }

            Process.Start(vsPath, $"/edit \"{filePath}\"");
        }

        private static string? FindVisualStudio()
        {
            string[] candidates = {
                @"C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.exe",
                @"C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\devenv.exe",
                @"C:\Program Files\Microsoft Visual Studio\2022\Enterprise\Common7\IDE\devenv.exe",
                @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\devenv.exe",
                @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\IDE\devenv.exe",
                @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\devenv.exe",
            };

            foreach (var p in candidates)
                if (File.Exists(p)) return p;

            return null;
        }

        // ── UI ────────────────────────────────────────────────────────────────────

        private void BuildUI()
        {
            var toolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 38,
                BackColor = EditorTheme.PanelHeader,
            };

            var saveBtn = MakeToolButton("💾 Save", EditorTheme.Accent, new Point(8, 4));
            saveBtn.Click += (_, _) => SaveFile();

            var openVsBtn = MakeToolButton("Open in Visual Studio", EditorTheme.PanelHeader, new Point(110, 4));
            openVsBtn.ForeColor = EditorTheme.TextSecondary;
            openVsBtn.Click += OpenInVs;

            var openVsCodeBtn = MakeToolButton("Open in VS Code", EditorTheme.PanelHeader, new Point(290, 4));
            openVsCodeBtn.ForeColor = EditorTheme.TextSecondary;
            openVsCodeBtn.Click += OpenInVsCode;

            toolbar.Controls.AddRange(new Control[] { saveBtn, openVsBtn, openVsCodeBtn });

            var gutter = new Panel
            {
                Dock = DockStyle.Left,
                Width = 44,
                BackColor = EditorTheme.BackgroundAlt,
            };
            gutter.Paint += DrawGutter;

            _editor = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = EditorTheme.Background,
                ForeColor = EditorTheme.TextPrimary,
                Font = EditorTheme.FontCode,
                BorderStyle = BorderStyle.None,
                ScrollBars = RichTextBoxScrollBars.Both,
                WordWrap = false,
                DetectUrls = false,
                AcceptsTab = true,
            };
            _editor.TextChanged += OnTextChanged;
            _editor.KeyDown += OnKeyDown;
            _editor.VScroll += (_, _) => gutter.Invalidate();

            var status = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 24,
                BackColor = EditorTheme.PanelHeader,
            };
            _statusLabel = new Label
            {
                Location = new Point(8, 4),
                Size = new Size(600, 18),
                ForeColor = EditorTheme.TextSecondary,
                Font = EditorTheme.FontUISmall,
            };
            status.Controls.Add(_statusLabel);
            UpdateStatus();

            Controls.Add(_editor);
            Controls.Add(gutter);
            Controls.Add(toolbar);
            Controls.Add(status);
        }

        // ── File operations ───────────────────────────────────────────────────────

        private void LoadFile()
        {
            if (_editor == null || !File.Exists(_filePath)) return;
            _editor.Text = File.ReadAllText(_filePath);
            ApplySyntaxHighlight();
            _modified = false;
            UpdateStatus();
        }

        private void SaveFile()
        {
            if (_editor == null) return;
            File.WriteAllText(_filePath, _editor.Text);
            _modified = false;
            if (_statusLabel != null)
                _statusLabel.Text = $"Saved — {Path.GetFileName(_filePath)}";
        }

        private void OnClosing(object? s, FormClosingEventArgs e)
        {
            if (!_modified) return;

            var result = MessageBox.Show(
                "Save changes before closing?",
                "Unsaved Changes",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes) SaveFile();
            else if (result == DialogResult.Cancel) e.Cancel = true;
        }

        // ── Open externally ───────────────────────────────────────────────────────

        private void OpenInVs(object? s, EventArgs e)
        {
            string? vsPath = FindVisualStudio();
            if (vsPath != null)
            {
                Process.Start(vsPath, $"/edit \"{_filePath}\"");
                return;
            }

            MessageBox.Show(
                "Visual Studio 2019/2022 not found.\nMake sure it is installed.",
                "Visual Studio not found",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OpenInVsCode(object? s, EventArgs e)
        {
            try { Process.Start("code", $"\"{_filePath}\""); }
            catch
            {
                MessageBox.Show("VS Code not found in PATH.", "VS Code not found",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ── Syntax highlighting ───────────────────────────────────────────────────

        private static readonly Color ColKeyword = Color.FromArgb(86, 156, 214);
        private static readonly Color ColType = Color.FromArgb(78, 201, 176);
        private static readonly Color ColString = Color.FromArgb(206, 145, 120);
        private static readonly Color ColComment = Color.FromArgb(106, 153, 85);
        private static readonly Color ColNumber = Color.FromArgb(181, 206, 168);
        private static readonly Color ColAttribute = Color.FromArgb(220, 220, 170);
        private static readonly Color ColDefault = EditorTheme.TextPrimary;

        private static readonly string[] Keywords = {
            "public", "private", "protected", "internal", "sealed", "static", "readonly",
            "class", "interface", "struct", "enum", "namespace", "using",
            "void", "return", "new", "null", "true", "false", "this", "base",
            "if", "else", "for", "foreach", "while", "do", "switch", "case", "break", "continue",
            "throw", "try", "catch", "finally", "var", "in", "out", "ref",
            "override", "virtual", "abstract", "partial", "event", "delegate",
            "get", "set", "value", "async", "await",
        };

        private static readonly string[] TypeKeywords = {
            "int", "float", "double", "bool", "string", "byte", "short", "long",
            "uint", "char", "object", "IntPtr", "DateTime",
        };

        private void ApplySyntaxHighlight()
        {
            if (_editor == null) return;

            _editor.SuspendLayout();
            int selStart = _editor.SelectionStart;
            int selLength = _editor.SelectionLength;

            _editor.SelectAll();
            _editor.SelectionColor = ColDefault;

            ColorPattern(@"//[^\n]*", ColComment);
            ColorPattern(@"""(?:[^""\\]|\\.)*""", ColString);
            ColorPattern(@"'(?:[^'\\]|\\.)*'", ColString);
            ColorPattern(@"\[.*?\]", ColAttribute);
            ColorPattern(@"\b\d+\.?\d*[fFdDuUlL]?\b", ColNumber);

            foreach (var kw in TypeKeywords)
                ColorPattern($@"\b{Regex.Escape(kw)}\b", ColType);

            foreach (var kw in Keywords)
                ColorPattern($@"\b{Regex.Escape(kw)}\b", ColKeyword);

            _editor.SelectionStart = selStart;
            _editor.SelectionLength = selLength;
            _editor.SelectionColor = ColDefault;
            _editor.ResumeLayout();
        }

        private void ColorPattern(string pattern, Color color)
        {
            if (_editor == null) return;
            string text = _editor.Text;
            foreach (Match m in Regex.Matches(text, pattern, RegexOptions.Multiline))
            {
                _editor.SelectionStart = m.Index;
                _editor.SelectionLength = m.Length;
                _editor.SelectionColor = color;
            }
        }

        // ── Gutter ────────────────────────────────────────────────────────────────

        private void DrawGutter(object? s, PaintEventArgs e)
        {
            if (s is not Panel gutter || _editor == null) return;
            e.Graphics.Clear(EditorTheme.BackgroundAlt);

            int lineHeight = _editor.Font.Height + 2;
            int firstLine = _editor.GetLineFromCharIndex(
                _editor.GetCharIndexFromPosition(new Point(0, 0)));
            int lastLine = _editor.GetLineFromCharIndex(
                _editor.GetCharIndexFromPosition(new Point(0, _editor.ClientSize.Height)));

            for (int i = firstLine; i <= Math.Min(lastLine + 1, _editor.Lines.Length - 1); i++)
            {
                int charIdx = _editor.GetFirstCharIndexFromLine(i);
                Point pos = _editor.GetPositionFromCharIndex(charIdx);
                e.Graphics.DrawString(
                    (i + 1).ToString(),
                    EditorTheme.FontCodeSmall,
                    new SolidBrush(EditorTheme.TextDisabled),
                    new RectangleF(0, pos.Y, 40f, lineHeight),
                    new StringFormat { Alignment = StringAlignment.Far });
            }
        }

        // ── Events ────────────────────────────────────────────────────────────────

        private void OnTextChanged(object? s, EventArgs e)
        {
            _modified = true;
            UpdateStatus();

            // _highlightDebounce is null during LoadFile() — skip safely
            if (_highlightDebounce == null) return;

            _highlightDebounce.Stop();
            _highlightDebounce.Start();
        }

        private void OnKeyDown(object? s, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveFile();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Tab && !e.Shift)
            {
                if (_editor == null) return;
                int sel = _editor.SelectionStart;
                _editor.SelectedText = "    ";
                _editor.SelectionStart = sel + 4;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void UpdateStatus()
        {
            if (_statusLabel == null || _editor == null) return;
            string modified = _modified ? "● " : "";
            int line = _editor.GetLineFromCharIndex(_editor.SelectionStart) + 1;
            int col = _editor.SelectionStart - _editor.GetFirstCharIndexOfCurrentLine() + 1;
            _statusLabel.Text = $"{modified}{Path.GetFileName(_filePath)}   Ln {line}, Col {col}   C#";
        }

        private static Button MakeToolButton(string text, Color back, Point loc)
        {
            return new Button
            {
                Text = text,
                BackColor = back,
                ForeColor = EditorTheme.TextPrimary,
                FlatStyle = FlatStyle.Flat,
                Location = loc,
                Size = new Size(text.Length * 7 + 20, 28),
                Font = EditorTheme.FontUISmall,
                FlatAppearance = { BorderColor = EditorTheme.PanelBorder }
            };
        }
    }
}