using AngeneEditor.Documents;
using System.Text.Json;

namespace AngeneEditor.Tests.Documents;

public sealed class SceneSerializerTests
{
    [Fact]
    public void RoundTripPreservesHierarchyTransformsAndComponents()
    {
        Guid parentId = Guid.NewGuid();
        using JsonDocument propertyValue = JsonDocument.Parse("42");

        var scene = new SceneDocument
        {
            Name = "Test Scene",
            Entities =
            {
                new SceneEntity
                {
                    Id = parentId,
                    Name = "Parent",
                    Transform = new TransformDocument
                    {
                        Position = new SceneVector3(10f, 20f, 30f),
                    },
                },
                new SceneEntity
                {
                    Name = "Child",
                    ParentId = parentId,
                    Components =
                    {
                        new SceneComponent
                        {
                            Type = "Script:Spinner",
                            Properties =
                            {
                                ["speed"] = propertyValue.RootElement.Clone(),
                            },
                        },
                    },
                },
            },
        };

        var serializer = new SceneSerializer();
        SceneDocument restored = serializer.Deserialize(serializer.Serialize(scene));

        Assert.Equal("Test Scene", restored.Name);
        Assert.Equal(2, restored.Entities.Count);
        Assert.Equal(parentId, restored.Entities[1].ParentId);
        Assert.Equal(30f, restored.Entities[0].Transform.Position.Z);
        Assert.Equal(42, restored.Entities[1].Components[0].Properties["speed"].GetInt32());
    }

    [Fact]
    public void InvalidHierarchyCycleIsRejected()
    {
        Guid firstId = Guid.NewGuid();
        Guid secondId = Guid.NewGuid();
        var scene = new SceneDocument
        {
            Entities =
            {
                new SceneEntity { Id = firstId, Name = "First", ParentId = secondId },
                new SceneEntity { Id = secondId, Name = "Second", ParentId = firstId },
            },
        };

        var serializer = new SceneSerializer();
        SceneDocumentValidationException error =
            Assert.Throws<SceneDocumentValidationException>(() => serializer.Serialize(scene));

        Assert.Contains(error.Errors, message => message.Contains("cycle", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void AtomicSaveCanReplaceAnExistingScene()
    {
        string directory = Path.Combine(Path.GetTempPath(), $"angene-tests-{Guid.NewGuid():N}");
        string path = Path.Combine(directory, "Main.angscene");

        try
        {
            var serializer = new SceneSerializer();
            serializer.SaveAtomic(path, new SceneDocument { Name = "First" });
            serializer.SaveAtomic(path, new SceneDocument { Name = "Second" });

            Assert.Equal("Second", serializer.Load(path).Name);
            Assert.Empty(Directory.GetFiles(directory, "*.tmp"));
        }
        finally
        {
            if (Directory.Exists(directory))
                Directory.Delete(directory, recursive: true);
        }
    }
}
