using AngeneEditor.Assets;

namespace AngeneEditor.Tests.Assets;

public sealed class AssetDatabaseTests
{
    [Fact]
    public void RefreshCreatesStableMetadataAndClassifiesAssets()
    {
        string root = Path.Combine(Path.GetTempPath(), $"angene-assets-{Guid.NewGuid():N}");
        string texturePath = Path.Combine(root, "Textures", "player.png");

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(texturePath)!);
            File.WriteAllBytes(texturePath, new byte[] { 1, 2, 3, 4 });

            var database = new AssetDatabase(root);
            AssetRecord first = Assert.Single(database.Refresh());
            AssetRecord second = Assert.Single(database.Refresh());

            Assert.Equal("Texture", first.Importer);
            Assert.Equal("Textures/player.png", first.RelativePath);
            Assert.Equal(first.Id, second.Id);
            Assert.True(File.Exists(texturePath + ".meta"));
        }
        finally
        {
            if (Directory.Exists(root))
                Directory.Delete(root, recursive: true);
        }
    }

    [Fact]
    public void RefreshDetectsChangedSourceContent()
    {
        string root = Path.Combine(Path.GetTempPath(), $"angene-assets-{Guid.NewGuid():N}");
        string assetPath = Path.Combine(root, "data.json");

        try
        {
            Directory.CreateDirectory(root);
            File.WriteAllText(assetPath, "{\"value\":1}");

            var database = new AssetDatabase(root);
            AssetRecord original = Assert.Single(database.Refresh());
            File.WriteAllText(assetPath, "{\"value\":2}");

            AssetRecord changed = Assert.Single(database.Refresh());

            Assert.True(changed.Changed);
            Assert.NotEqual(original.SourceHash, changed.SourceHash);
            Assert.Equal(original.Id, changed.Id);
        }
        finally
        {
            if (Directory.Exists(root))
                Directory.Delete(root, recursive: true);
        }
    }
}
