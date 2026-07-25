using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace AngeneEditor.Workspace
{
    public sealed class EditorSettings
    {
        public const int CurrentSchemaVersion = 1;

        public int SchemaVersion { get; set; } = CurrentSchemaVersion;
        public string? DotnetHostPath { get; set; }
        public string? LastProjectPath { get; set; }
    }

    public sealed class EditorSettingsStore
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
        };

        public EditorSettingsStore(string? path = null)
        {
            Path = path ?? System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "AngeneEditor",
                "settings.json");
        }

        public string Path { get; }

        public EditorSettings? Load()
        {
            if (!File.Exists(Path))
                return null;

            try
            {
                EditorSettings? settings = JsonSerializer.Deserialize<EditorSettings>(
                    File.ReadAllText(Path),
                    JsonOptions);
                return settings?.SchemaVersion == EditorSettings.CurrentSchemaVersion
                    ? settings
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

        public void Save(EditorSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);
            string directory = System.IO.Path.GetDirectoryName(Path)
                ?? throw new InvalidOperationException("Settings path has no directory.");
            Directory.CreateDirectory(directory);

            string temporaryPath = $"{Path}.{Guid.NewGuid():N}.tmp";
            File.WriteAllText(
                temporaryPath,
                JsonSerializer.Serialize(settings, JsonOptions));

            if (File.Exists(Path))
                File.Replace(temporaryPath, Path, null);
            else
                File.Move(temporaryPath, Path);
        }
    }

    public static class DotnetSdkLocator
    {
        public static string? Resolve(string? configuredPath)
        {
            foreach (string candidate in CandidatePaths(configuredPath))
            {
                if (File.Exists(candidate) && HasSdk(candidate))
                    return candidate;
            }

            return null;
        }

        public static bool HasSdk(string dotnetHostPath)
        {
            if (!File.Exists(dotnetHostPath))
                return false;

            try
            {
                var info = new ProcessStartInfo
                {
                    FileName = dotnetHostPath,
                    Arguments = "--list-sdks",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                };

                using var process = Process.Start(info);
                if (process == null)
                    return false;

                string output = process.StandardOutput.ReadToEnd();
                if (!process.WaitForExit(5000))
                {
                    process.Kill(entireProcessTree: true);
                    return false;
                }

                return process.ExitCode == 0 && !string.IsNullOrWhiteSpace(output);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                return false;
            }
        }

        private static IEnumerable<string> CandidatePaths(string? configuredPath)
        {
            var paths = new List<string?>();
            paths.Add(configuredPath);
            paths.Add(Environment.GetEnvironmentVariable("ANGENE_DOTNET_HOST"));
            paths.Add(Environment.GetEnvironmentVariable("DOTNET_HOST_PATH"));

            foreach (string variable in new[] { "DOTNET_ROOT", "DOTNET_ROOT_X64" })
            {
                string? root = Environment.GetEnvironmentVariable(variable);
                if (!string.IsNullOrWhiteSpace(root))
                    paths.Add(System.IO.Path.Combine(root, "dotnet.exe"));
            }

            string programFiles = Environment.GetFolderPath(
                Environment.SpecialFolder.ProgramFiles);
            if (!string.IsNullOrWhiteSpace(programFiles))
                paths.Add(System.IO.Path.Combine(programFiles, "dotnet", "dotnet.exe"));

            string userProfile = Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile);
            if (!string.IsNullOrWhiteSpace(userProfile))
                paths.Add(System.IO.Path.Combine(userProfile, ".dotnet", "dotnet.exe"));

            string? pathVariable = Environment.GetEnvironmentVariable("PATH");
            if (!string.IsNullOrWhiteSpace(pathVariable))
            {
                paths.AddRange(pathVariable
                    .Split(System.IO.Path.PathSeparator, StringSplitOptions.RemoveEmptyEntries)
                    .Select(path => System.IO.Path.Combine(
                        path.Trim().Trim('"'),
                        "dotnet.exe")));
            }

            return paths
                .Where(path => !string.IsNullOrWhiteSpace(path))
                .Select(path => System.IO.Path.GetFullPath(path!))
                .Distinct(StringComparer.OrdinalIgnoreCase);
        }
    }
}
