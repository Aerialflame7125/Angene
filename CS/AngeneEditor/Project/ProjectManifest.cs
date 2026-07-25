using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace AngeneEditor.Project
{
    public sealed class ProjectManifest
    {
        public const int CurrentSchemaVersion = 1;

        public int SchemaVersion { get; set; } = CurrentSchemaVersion;
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public string DefaultScene { get; set; } = "Scenes/Main.angscene";
        public DateTimeOffset CreatedUtc { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset ModifiedUtc { get; set; } = DateTimeOffset.UtcNow;
    }

    public sealed class ProjectManifestStore
    {
        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
        };

        public ProjectManifest Load(string path)
        {
            string json = File.ReadAllText(path, Encoding.UTF8);
            ProjectManifest manifest = JsonSerializer.Deserialize<ProjectManifest>(json, _options)
                ?? throw new InvalidDataException("Project manifest could not be deserialized.");

            if (manifest.SchemaVersion <= 0 ||
                manifest.SchemaVersion > ProjectManifest.CurrentSchemaVersion)
            {
                throw new InvalidDataException(
                    $"Unsupported project schema version {manifest.SchemaVersion}.");
            }

            if (manifest.Id == Guid.Empty)
                throw new InvalidDataException("Project manifest ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(manifest.Name))
                throw new InvalidDataException("Project manifest name cannot be empty.");

            return manifest;
        }

        public void SaveAtomic(string path, ProjectManifest manifest)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(path);
            ArgumentNullException.ThrowIfNull(manifest);

            manifest.ModifiedUtc = DateTimeOffset.UtcNow;
            string fullPath = Path.GetFullPath(path);
            string directory = Path.GetDirectoryName(fullPath)
                ?? throw new InvalidOperationException("Manifest path has no parent directory.");
            Directory.CreateDirectory(directory);

            string tempPath = Path.Combine(
                directory,
                $".{Path.GetFileName(fullPath)}.{Guid.NewGuid():N}.tmp");

            try
            {
                string json = JsonSerializer.Serialize(manifest, _options);
                File.WriteAllText(tempPath, json, new UTF8Encoding(false));
                File.Move(tempPath, fullPath, overwrite: true);
            }
            finally
            {
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }
        }
    }
}
