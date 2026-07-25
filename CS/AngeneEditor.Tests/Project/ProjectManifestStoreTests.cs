using AngeneEditor.Project;

namespace AngeneEditor.Tests.Project;

public sealed class ProjectManifestStoreTests
{
    [Fact]
    public void ManifestRoundTripsAndCanBeReplaced()
    {
        string directory = Path.Combine(Path.GetTempPath(), $"angene-project-tests-{Guid.NewGuid():N}");
        string path = Path.Combine(directory, "project.json");

        try
        {
            var store = new ProjectManifestStore();
            var manifest = new ProjectManifest { Name = "Example" };
            store.SaveAtomic(path, manifest);

            ProjectManifest restored = store.Load(path);
            Assert.Equal(manifest.Id, restored.Id);
            Assert.Equal("Scenes/Main.angscene", restored.DefaultScene);

            restored.Name = "Renamed";
            store.SaveAtomic(path, restored);
            Assert.Equal("Renamed", store.Load(path).Name);
        }
        finally
        {
            if (Directory.Exists(directory))
                Directory.Delete(directory, recursive: true);
        }
    }
}
