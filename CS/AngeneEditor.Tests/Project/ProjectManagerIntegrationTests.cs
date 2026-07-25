using AngeneEditor.Project;
using AngeneEditor.Documents;

namespace AngeneEditor.Tests.Project;

public sealed class ProjectManagerIntegrationTests
{
    [Fact]
    public void ProjectWorkflowPersistsStableHierarchyAndTransforms()
    {
        string parentDirectory = Path.Combine(
            Path.GetTempPath(),
            $"angene-workflow-tests-{Guid.NewGuid():N}");

        try
        {
            ProjectManager manager = ProjectManager.Instance;
            AngeneProject project = manager.CreateProject("EditorWorkflow", parentDirectory);
            EntityDefinition parent = manager.AddEntity("Parent", x: 10, y: 20);
            EntityDefinition child = manager.AddEntity("Child", parentId: parent.Id);

            child = manager.UpdateEntity(child, "Set 3D transform", entity =>
            {
                entity.Z = 30f;
                entity.RotationY = 45f;
                entity.ScaleX = 2f;
            });
            manager.AddScript(child, "Spinner");
            manager.SaveProject();

            Assert.True(File.Exists(project.ManifestPath));
            Assert.True(File.Exists(project.MainScenePath));

            Guid parentId = parent.Id;
            Guid childId = child.Id;
            AngeneProject? reopened = manager.OpenProject(project.CsprojPath);

            Assert.NotNull(reopened);
            EntityDefinition restoredParent =
                Assert.Single(reopened.Entities, entity => entity.Id == parentId);
            EntityDefinition restoredChild =
                Assert.Single(reopened.Entities, entity => entity.Id == childId);
            Assert.Equal(restoredParent.Id, restoredChild.ParentId);
            Assert.Equal(30f, restoredChild.Z);
            Assert.Equal(45f, restoredChild.RotationY);
            Assert.Equal(2f, restoredChild.ScaleX);
            Assert.Contains("Spinner", restoredChild.Scripts);
        }
        finally
        {
            if (Directory.Exists(parentDirectory))
                Directory.Delete(parentDirectory, recursive: true);
        }
    }

    [Fact]
    public void ProjectMutationsCanBeUndoneAndRedone()
    {
        string parentDirectory = Path.Combine(
            Path.GetTempPath(),
            $"angene-history-tests-{Guid.NewGuid():N}");

        try
        {
            ProjectManager manager = ProjectManager.Instance;
            manager.CreateProject("HistoryWorkflow", parentDirectory);
            EntityDefinition entity = manager.AddEntity("Entity");
            manager.RenameEntity(entity, "Renamed");

            Assert.Equal("Renamed", Assert.Single(manager.CurrentProject!.Entities).Name);
            manager.Undo();
            Assert.Equal("Entity", Assert.Single(manager.CurrentProject.Entities).Name);
            manager.Redo();
            Assert.Equal("Renamed", Assert.Single(manager.CurrentProject.Entities).Name);
        }
        finally
        {
            if (Directory.Exists(parentDirectory))
                Directory.Delete(parentDirectory, recursive: true);
        }
    }

    [Fact]
    public void RecoverySnapshotRestoresDirtySceneAndIsRemovedBySave()
    {
        string parentDirectory = Path.Combine(
            Path.GetTempPath(),
            $"angene-recovery-tests-{Guid.NewGuid():N}");

        try
        {
            ProjectManager manager = ProjectManager.Instance;
            AngeneProject project = manager.CreateProject("RecoveryWorkflow", parentDirectory);
            EntityDefinition entity = manager.AddEntity("Recover Me", x: 12, y: 24);

            Assert.True(manager.SaveRecoverySnapshot());
            Assert.True(File.Exists(project.RecoveryPath));

            manager.UpdateEntity(entity, "Move after autosave", target =>
            {
                target.X = 400;
                target.Y = 500;
            });

            Assert.True(manager.RestoreRecoverySnapshot());
            EntityDefinition restored = Assert.Single(manager.CurrentProject!.Entities);
            Assert.Equal(12, restored.X);
            Assert.Equal(24, restored.Y);
            Assert.True(manager.IsDirty);

            manager.SaveProject();
            Assert.False(File.Exists(project.RecoveryPath));
            Assert.False(manager.IsDirty);
        }
        finally
        {
            if (Directory.Exists(parentDirectory))
                Directory.Delete(parentDirectory, recursive: true);
        }
    }

    [Fact]
    public void RepeatedSavesPreserveScriptComponentIdentity()
    {
        string parentDirectory = Path.Combine(
            Path.GetTempPath(),
            $"angene-component-id-tests-{Guid.NewGuid():N}");

        try
        {
            ProjectManager manager = ProjectManager.Instance;
            AngeneProject project = manager.CreateProject("ComponentIdentity", parentDirectory);
            EntityDefinition entity = manager.AddEntity("Scripted");
            manager.AddScript(entity, "Spinner");
            manager.SaveProject();

            var serializer = new SceneSerializer();
            Guid firstId = Assert.Single(
                Assert.Single(serializer.Load(project.MainScenePath).Entities).Components).Id;

            manager.SaveProject();
            Guid secondId = Assert.Single(
                Assert.Single(serializer.Load(project.MainScenePath).Entities).Components).Id;

            Assert.Equal(firstId, secondId);
        }
        finally
        {
            if (Directory.Exists(parentDirectory))
                Directory.Delete(parentDirectory, recursive: true);
        }
    }

    [Fact]
    public void GenericComponentsRoundTripWithStableIdentityAndProperties()
    {
        string parentDirectory = Path.Combine(
            Path.GetTempPath(),
            $"angene-generic-component-tests-{Guid.NewGuid():N}");

        try
        {
            ProjectManager manager = ProjectManager.Instance;
            AngeneProject project = manager.CreateProject("GenericComponents", parentDirectory);
            EntityDefinition entity = manager.AddEntity("Camera Rig");
            ComponentDefinition camera = manager.AddComponent(
                entity,
                "Camera",
                new Dictionary<string, string>
                {
                    ["Orthographic Size"] = "5",
                    ["Priority"] = "0",
                });
            manager.UpdateComponent(
                entity,
                camera.Id,
                "Change camera size",
                component => component.Properties["Orthographic Size"] = "8");
            manager.SaveProject();

            AngeneProject reopened = Assert.IsType<AngeneProject>(
                manager.OpenProject(project.CsprojPath));
            ComponentDefinition restored = Assert.Single(
                Assert.Single(reopened.Entities).Components);
            Assert.Equal(camera.Id, restored.Id);
            Assert.Equal("Camera", restored.Type);
            Assert.Equal("8", restored.Properties["Orthographic Size"]);
        }
        finally
        {
            if (Directory.Exists(parentDirectory))
                Directory.Delete(parentDirectory, recursive: true);
        }
    }
}
