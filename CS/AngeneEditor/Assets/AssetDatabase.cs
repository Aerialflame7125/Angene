using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace AngeneEditor.Assets
{
    public sealed class AssetDatabase
    {
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
        };
        private readonly List<AssetRecord> _assets = new();

        public AssetDatabase(string rootPath)
        {
            RootPath = Path.GetFullPath(rootPath);
        }

        public event Action? Refreshed;
        public string RootPath { get; }
        public IReadOnlyList<AssetRecord> Assets => _assets;

        public IReadOnlyList<AssetRecord> Refresh(bool createMissingMetadata = true)
        {
            Directory.CreateDirectory(RootPath);
            _assets.Clear();

            foreach (string sourcePath in Directory
                         .EnumerateFiles(RootPath, "*", SearchOption.AllDirectories)
                         .Where(path => !path.EndsWith(".meta", StringComparison.OrdinalIgnoreCase))
                         .OrderBy(path => path, StringComparer.OrdinalIgnoreCase))
            {
                string relativePath = NormalizeRelativePath(
                    Path.GetRelativePath(RootPath, sourcePath));
                string metadataPath = sourcePath + ".meta";
                string hash = ComputeHash(sourcePath);

                AssetMetadata metadata;
                if (File.Exists(metadataPath))
                {
                    metadata = LoadMetadata(metadataPath);
                }
                else
                {
                    metadata = new AssetMetadata
                    {
                        Importer = InferImporter(sourcePath),
                        SourceHash = hash,
                    };
                    if (createMissingMetadata)
                        SaveMetadataAtomic(metadataPath, metadata);
                }

                bool changed = !string.Equals(
                    metadata.SourceHash,
                    hash,
                    StringComparison.OrdinalIgnoreCase);

                if (changed && createMissingMetadata)
                {
                    metadata.SourceHash = hash;
                    metadata.ImportedUtc = DateTimeOffset.UtcNow;
                    SaveMetadataAtomic(metadataPath, metadata);
                }

                _assets.Add(new AssetRecord(
                    metadata.Id,
                    relativePath,
                    sourcePath,
                    metadataPath,
                    metadata.Importer,
                    hash,
                    changed));
            }

            Refreshed?.Invoke();
            return _assets;
        }

        public AssetRecord? Find(Guid id)
            => _assets.FirstOrDefault(asset => asset.Id == id);

        public AssetRecord? FindByRelativePath(string relativePath)
        {
            string normalized = NormalizeRelativePath(relativePath);
            return _assets.FirstOrDefault(asset =>
                string.Equals(
                    asset.RelativePath,
                    normalized,
                    StringComparison.OrdinalIgnoreCase));
        }

        public IReadOnlyList<AssetRecord> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return _assets.ToArray();

            string term = query.Trim();
            return _assets.Where(asset =>
                    asset.RelativePath.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    asset.Importer.Contains(term, StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        private AssetMetadata LoadMetadata(string path)
        {
            AssetMetadata metadata = JsonSerializer.Deserialize<AssetMetadata>(
                                         File.ReadAllText(path, Encoding.UTF8),
                                         _jsonOptions)
                                     ?? throw new InvalidDataException(
                                         $"Asset metadata '{path}' could not be read.");

            if (metadata.SchemaVersion != AssetMetadata.CurrentSchemaVersion)
                throw new InvalidDataException(
                    $"Unsupported asset metadata schema {metadata.SchemaVersion} in '{path}'.");
            if (metadata.Id == Guid.Empty)
                throw new InvalidDataException($"Asset metadata '{path}' has an empty ID.");

            return metadata;
        }

        private void SaveMetadataAtomic(string path, AssetMetadata metadata)
        {
            string directory = Path.GetDirectoryName(path)
                ?? throw new InvalidOperationException("Asset metadata path has no parent.");
            Directory.CreateDirectory(directory);

            string tempPath = Path.Combine(
                directory,
                $".{Path.GetFileName(path)}.{Guid.NewGuid():N}.tmp");
            try
            {
                File.WriteAllText(
                    tempPath,
                    JsonSerializer.Serialize(metadata, _jsonOptions),
                    new UTF8Encoding(false));
                File.Move(tempPath, path, overwrite: true);
            }
            finally
            {
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }
        }

        private static string ComputeHash(string path)
        {
            using FileStream stream = File.OpenRead(path);
            return Convert.ToHexString(SHA256.HashData(stream));
        }

        private static string InferImporter(string path)
        {
            return Path.GetExtension(path).ToLowerInvariant() switch
            {
                ".png" or ".jpg" or ".jpeg" or ".bmp" or ".gif" or ".webp" => "Texture",
                ".wav" or ".mp3" or ".ogg" or ".flac" => "Audio",
                ".hlsl" or ".slang" or ".glsl" => "Shader",
                ".cs" => "Script",
                ".json" or ".txt" or ".md" or ".xml" or ".yaml" or ".yml" => "Text",
                ".angpkg" => "Package",
                _ => "Binary",
            };
        }

        private static string NormalizeRelativePath(string path)
            => path.Replace('\\', '/').TrimStart('/');
    }

    public sealed class AssetMetadata
    {
        public const int CurrentSchemaVersion = 1;

        public int SchemaVersion { get; set; } = CurrentSchemaVersion;
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Importer { get; set; } = "Binary";
        public string SourceHash { get; set; } = "";
        public DateTimeOffset ImportedUtc { get; set; } = DateTimeOffset.UtcNow;
        public Dictionary<string, string> Settings { get; set; } =
            new(StringComparer.Ordinal);
    }

    public sealed record AssetRecord(
        Guid Id,
        string RelativePath,
        string SourcePath,
        string MetadataPath,
        string Importer,
        string SourceHash,
        bool Changed);
}
