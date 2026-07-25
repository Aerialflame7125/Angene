using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace AngeneEditor.Workspace
{
    public sealed class EditorLayout
    {
        public const int CurrentSchemaVersion = 1;

        public int SchemaVersion { get; set; } = CurrentSchemaVersion;
        public Rectangle WindowBounds { get; set; } = new(100, 100, 1600, 900);
        public bool Maximized { get; set; }
        public int ProjectPanelWidth { get; set; } = 240;
        public int HierarchyPanelWidth { get; set; } = 270;
        public int InspectorPanelWidth { get; set; } = 280;
        public int ConsolePanelHeight { get; set; } = 190;
        public int ActiveViewIndex { get; set; }
    }

    public sealed class EditorLayoutStore
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
        };

        public EditorLayoutStore(string? path = null)
        {
            Path = path ?? System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "AngeneEditor",
                "layout.json");
        }

        public string Path { get; }

        public EditorLayout? Load()
        {
            if (!File.Exists(Path))
                return null;

            try
            {
                string json = File.ReadAllText(Path);
                EditorLayout? layout = JsonSerializer.Deserialize<EditorLayout>(json, JsonOptions);
                return layout?.SchemaVersion == EditorLayout.CurrentSchemaVersion
                    ? layout
                    : null;
            }
            catch (IOException)
            {
                return null;
            }
            catch (UnauthorizedAccessException)
            {
                return null;
            }
            catch (JsonException)
            {
                return null;
            }
        }

        public void Save(EditorLayout layout)
        {
            ArgumentNullException.ThrowIfNull(layout);
            string directory = System.IO.Path.GetDirectoryName(Path)
                ?? throw new InvalidOperationException("Layout path has no directory.");
            Directory.CreateDirectory(directory);

            string temporaryPath = $"{Path}.{Guid.NewGuid():N}.tmp";
            File.WriteAllText(temporaryPath, JsonSerializer.Serialize(layout, JsonOptions));

            if (File.Exists(Path))
                File.Replace(temporaryPath, Path, null);
            else
                File.Move(temporaryPath, Path);
        }

        public void Delete()
        {
            if (File.Exists(Path))
                File.Delete(Path);
        }

        public static Rectangle ClampToVisibleWorkArea(Rectangle bounds)
        {
            Rectangle workArea = Screen.FromRectangle(bounds).WorkingArea;
            int width = Math.Clamp(bounds.Width, 1100, Math.Max(1100, workArea.Width));
            int height = Math.Clamp(bounds.Height, 650, Math.Max(650, workArea.Height));
            int x = Math.Clamp(bounds.X, workArea.Left, workArea.Right - width);
            int y = Math.Clamp(bounds.Y, workArea.Top, workArea.Bottom - height);
            return new Rectangle(x, y, width, height);
        }
    }
}
