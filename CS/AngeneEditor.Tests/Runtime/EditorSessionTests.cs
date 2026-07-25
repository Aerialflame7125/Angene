using AngeneEditor.Commands;
using AngeneEditor.Documents;
using AngeneEditor.Runtime;

namespace AngeneEditor.Tests.Runtime;

public sealed class EditorSessionTests
{
    [Fact]
    public void PlayModeUsesAnIsolatedSceneCopy()
    {
        var entity = new SceneEntity { Name = "Original" };
        var session = new EditorSession(new SceneDocument { Entities = { entity } });

        session.EnterPlayMode();
        session.ActiveScene.Entities[0].Name = "Runtime mutation";
        session.Stop();

        Assert.Equal(EditorSessionMode.Edit, session.Mode);
        Assert.Equal("Original", session.EditScene.Entities[0].Name);
    }

    [Fact]
    public void PauseResumeAndStepHaveExplicitTransitions()
    {
        var session = new EditorSession(new SceneDocument());
        int stepCount = 0;
        session.StepRequested += _ => stepCount++;

        session.EnterPlayMode();
        session.Pause();
        session.Step();
        session.Resume();

        Assert.Equal(1, stepCount);
        Assert.Equal(EditorSessionMode.Play, session.Mode);
    }

    [Fact]
    public void EditCommandsAreDisabledDuringPlayMode()
    {
        var session = new EditorSession(new SceneDocument());
        session.EnterPlayMode();

        Assert.Throws<InvalidOperationException>(() =>
            session.Execute(new AddEntityCommand(
                session.EditScene,
                new SceneEntity { Name = "Not allowed" })));
    }

    [Fact]
    public void UndoRedoMarksSessionDirty()
    {
        var session = new EditorSession(new SceneDocument());
        var entity = new SceneEntity { Name = "Light" };

        session.Execute(new AddEntityCommand(session.EditScene, entity));
        session.MarkSaved();
        session.Undo();

        Assert.True(session.IsDirty);
        Assert.Empty(session.EditScene.Entities);

        session.Redo();
        Assert.Single(session.EditScene.Entities);
    }
}
