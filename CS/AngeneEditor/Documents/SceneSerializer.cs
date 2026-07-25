using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AngeneEditor.Documents
{
    public sealed class SceneSerializer
    {
        private readonly JsonSerializerOptions _options;

        public SceneSerializer()
        {
            _options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                ReadCommentHandling = JsonCommentHandling.Skip,
                WriteIndented = true,
            };
            _options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        }

        public string Serialize(SceneDocument scene)
        {
            ArgumentNullException.ThrowIfNull(scene);
            scene.EnsureValid();
            scene.ModifiedUtc = DateTimeOffset.UtcNow;
            return JsonSerializer.Serialize(scene, _options);
        }

        public SceneDocument Deserialize(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new InvalidDataException("Scene document is empty.");

            SceneDocument scene = JsonSerializer.Deserialize<SceneDocument>(json, _options)
                ?? throw new InvalidDataException("Scene document could not be deserialized.");

            scene.EnsureValid();
            return scene;
        }

        public SceneDocument Load(string path)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(path);
            return Deserialize(File.ReadAllText(path, Encoding.UTF8));
        }

        public void SaveAtomic(string path, SceneDocument scene)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(path);
            ArgumentNullException.ThrowIfNull(scene);

            string fullPath = Path.GetFullPath(path);
            string? directory = Path.GetDirectoryName(fullPath);
            if (string.IsNullOrEmpty(directory))
                throw new InvalidOperationException("Scene path has no parent directory.");

            Directory.CreateDirectory(directory);

            string tempPath = Path.Combine(
                directory,
                $".{Path.GetFileName(fullPath)}.{Guid.NewGuid():N}.tmp");

            try
            {
                string json = Serialize(scene);
                using (var stream = new FileStream(
                    tempPath,
                    FileMode.CreateNew,
                    FileAccess.Write,
                    FileShare.None,
                    16 * 1024,
                    FileOptions.WriteThrough))
                using (var writer = new StreamWriter(stream, new UTF8Encoding(false)))
                {
                    writer.Write(json);
                    writer.Flush();
                    stream.Flush(flushToDisk: true);
                }

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
