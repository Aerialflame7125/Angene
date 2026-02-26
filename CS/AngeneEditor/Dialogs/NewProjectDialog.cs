using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AngeneEditor.Theme;

namespace AngeneEditor.Dialogs
{
    public sealed class NewProjectDialog : Form
    {
        public string ProjectName { get; private set; } = "";
        public string ProjectDir { get; private set; } = "";

        private TextBox _nameBox;
        private TextBox _dirBox;
        private Label _previewLabel;

        public NewProjectDialog()
        {
            Text = "New Angene Project";
            Size = new Size(520, 280);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = EditorTheme.Panel;
            ForeColor = EditorTheme.TextPrimary;
            Font = EditorTheme.FontUI;

            int y = 20;

            // Title
            AddLabel("Project Name:", new Point(20, y));
            _nameBox = AddTextBox(new Point(20, y + 20), 380);
            _nameBox.Text = "MyGame";
            _nameBox.TextChanged += (_, _) => UpdatePreview();

            y += 64;
            AddLabel("Project Directory:", new Point(20, y));

            _dirBox = new TextBox
            {
                Location = new Point(20, y + 20),
                Size = new Size(340, 24),
                BackColor = EditorTheme.BackgroundAlt,
                ForeColor = EditorTheme.TextPrimary,
                BorderStyle = BorderStyle.FixedSingle,
                Font = EditorTheme.FontUI,
            };
            _dirBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _dirBox.TextChanged += (_, _) => UpdatePreview();
            Controls.Add(_dirBox);

            var browseBtn = new Button
            {
                Text = "...",
                Location = new Point(368, y + 19),
                Size = new Size(32, 26),
                BackColor = EditorTheme.Highlight,
                ForeColor = EditorTheme.TextPrimary,
                FlatStyle = FlatStyle.Flat,
                Font = EditorTheme.FontUIBold,
            };
            browseBtn.Click += BrowseDir;
            Controls.Add(browseBtn);

            y += 64;
            _previewLabel = new Label
            {
                Location = new Point(20, y),
                Size = new Size(460, 20),
                ForeColor = EditorTheme.TextSecondary,
                Font = EditorTheme.FontCodeSmall,
            };
            Controls.Add(_previewLabel);
            UpdatePreview();

            y += 36;
            var createBtn = new Button
            {
                Text = "Create Project",
                Location = new Point(20, y),
                Size = new Size(150, 34),
                BackColor = EditorTheme.Accent,
                ForeColor = EditorTheme.TextPrimary,
                FlatStyle = FlatStyle.Flat,
                Font = EditorTheme.FontUIBold,
                FlatAppearance = { BorderColor = EditorTheme.AccentHover }
            };
            createBtn.Click += Create;
            Controls.Add(createBtn);

            var cancelBtn = new Button
            {
                Text = "Cancel",
                Location = new Point(180, y),
                Size = new Size(100, 34),
                BackColor = EditorTheme.PanelHeader,
                ForeColor = EditorTheme.TextSecondary,
                FlatStyle = FlatStyle.Flat,
                Font = EditorTheme.FontUI,
            };
            cancelBtn.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };
            Controls.Add(cancelBtn);
        }

        private void UpdatePreview()
        {
            string full = Path.Combine(_dirBox.Text.Trim(), _nameBox.Text.Trim());
            _previewLabel.Text = $"→ {full}";
        }

        private void BrowseDir(object? s, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog
            {
                Description = "Select project parent directory",
                UseDescriptionForTitle = true,
                SelectedPath = _dirBox.Text,
            };
            if (dlg.ShowDialog() == DialogResult.OK)
                _dirBox.Text = dlg.SelectedPath;
        }

        private void Create(object? s, EventArgs e)
        {
            string name = _nameBox.Text.Trim();
            string dir = _dirBox.Text.Trim();

            if (string.IsNullOrEmpty(name))
            { MessageBox.Show("Project name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!Directory.Exists(dir))
            { MessageBox.Show("Directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            ProjectName = name;
            ProjectDir = dir;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void AddLabel(string text, Point loc)
        {
            Controls.Add(new Label
            {
                Text = text,
                Location = loc,
                Size = new Size(300, 18),
                ForeColor = EditorTheme.TextSecondary,
                Font = EditorTheme.FontUISmall,
            });
        }

        private TextBox AddTextBox(Point loc, int width)
        {
            var tb = new TextBox
            {
                Location = loc,
                Size = new Size(width, 24),
                BackColor = EditorTheme.BackgroundAlt,
                ForeColor = EditorTheme.TextPrimary,
                BorderStyle = BorderStyle.FixedSingle,
                Font = EditorTheme.FontUI,
            };
            Controls.Add(tb);
            return tb;
        }
    }
}