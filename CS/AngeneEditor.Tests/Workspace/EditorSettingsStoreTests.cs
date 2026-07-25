using AngeneEditor.Workspace;

namespace AngeneEditor.Tests.Workspace;

public sealed class EditorSettingsStoreTests
{
    [Fact]
    public void SettingsRoundTripAndCorruptContentFallsBackSafely()
    {
        string directory = Path.Combine(
            Path.GetTempPath(),
            $"angene-settings-tests-{Guid.NewGuid():N}");
        string path = Path.Combine(directory, "settings.json");

        try
        {
            var store = new EditorSettingsStore(path);
            var settings = new EditorSettings
            {
                DotnetHostPath = @"C:\SDK\dotnet.exe",
                LastProjectPath = @"C:\Projects\Game\Game.csproj",
            };

            store.Save(settings);
            EditorSettings restored = Assert.IsType<EditorSettings>(store.Load());
            Assert.Equal(settings.DotnetHostPath, restored.DotnetHostPath);
            Assert.Equal(settings.LastProjectPath, restored.LastProjectPath);

            File.WriteAllText(path, "not-json");
            Assert.Null(store.Load());
        }
        finally
        {
            if (Directory.Exists(directory))
                Directory.Delete(directory, recursive: true);
        }
    }
}
