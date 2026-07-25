using AngeneEditor.Commands;
using AngeneEditor.Documents;

namespace AngeneEditor.Tests.Commands;

public sealed class SceneCommandTests
{
    [Fact]
    public void CommandHistorySupportsCreateUndoAndRedo()
    {
        var scene = new SceneDocument();
        var history = new CommandHistory();
        var entity = new SceneEntity { Name = "Camera" };

        history.Execute(new AddEntityCommand(scene, entity));
        Assert.Single(scene.Entities);

        history.Undo();
        Assert.Empty(scene.Entities);

        history.Redo();
        Assert.Equal("Camera", Assert.Single(scene.Entities).Name);
    }

    [Fact]
    public void DeleteEntityRemovesAndRestoresItsSubtreeInOrder()
    {
        var parent = new SceneEntity { Name = "Parent" };
        var child = new SceneEntity { Name = "Child", ParentId = parent.Id };
        var sibling = new SceneEntity { Name = "Sibling" };
        var scene = new SceneDocument
        {
            Entities = { parent, child, sibling },
        };
        var history = new CommandHistory();

        history.Execute(new DeleteEntityCommand(scene, parent.Id));
        Assert.Equal("Sibling", Assert.Single(scene.Entities).Name);

        history.Undo();
        Assert.Equal(new[] { "Parent", "Child", "Sibling" }, scene.Entities.Select(entity => entity.Name));
    }

    [Fact]
    public void ReparentCommandPreventsHierarchyCycles()
    {
        var parent = new SceneEntity { Name = "Parent" };
        var child = new SceneEntity { Name = "Child", ParentId = parent.Id };
        var scene = new SceneDocument
        {
            Entities = { parent, child },
        };

        var command = new ReparentEntityCommand(scene, parent.Id, child.Id);

        Assert.Throws<InvalidOperationException>(command.Execute);
        Assert.Null(parent.ParentId);
    }

    [Fact]
    public void TransformCommandRestoresPreviousValue()
    {
        var entity = new SceneEntity { Name = "Player" };
        var scene = new SceneDocument { Entities = { entity } };
        var history = new CommandHistory();

        history.Execute(new SetTransformCommand(
            scene,
            entity.Id,
            new TransformDocument
            {
                Position = new SceneVector3(4f, 5f, 6f),
                Rotation = new SceneVector3(0f, 45f, 0f),
                Scale = new SceneVector3(2f, 2f, 2f),
            }));

        Assert.Equal(5f, entity.Transform.Position.Y);
        history.Undo();
        Assert.Equal(0f, entity.Transform.Position.Y);
        Assert.Equal(1f, entity.Transform.Scale.X);
    }
}
