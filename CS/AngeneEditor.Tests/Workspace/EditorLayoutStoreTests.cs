using AngeneEditor.Workspace;
using System.Drawing;

namespace AngeneEditor.Tests.Workspace;

public sealed class EditorLayoutStoreTests
{
    [Fact]
    public void LayoutRoundTripsAndCorruptContentFallsBackSafely()
    {
        string directory = Path.Combine(
            Path.GetTempPath(),
            $"angene-layout-tests-{Guid.NewGuid():N}");
        string path = Path.Combine(directory, "layout.json");

        try
        {
            var store = new EditorLayoutStore(path);
            var layout = new EditorLayout
            {
                WindowBounds = new Rectangle(30, 40, 1400, 800),
                Maximized = true,
                ProjectPanelWidth = 260,
                HierarchyPanelWidth = 310,
                InspectorPanelWidth = 330,
                ConsolePanelHeight = 220,
                ActiveViewIndex = 1,
            };

            store.Save(layout);
            EditorLayout restored = Assert.IsType<EditorLayout>(store.Load());
            Assert.Equal(layout.WindowBounds, restored.WindowBounds);
            Assert.True(restored.Maximized);
            Assert.Equal(310, restored.HierarchyPanelWidth);
            Assert.Equal(1, restored.ActiveViewIndex);

            File.WriteAllText(path, "{ definitely not valid json");
            Assert.Null(store.Load());
        }
        finally
        {
            if (Directory.Exists(directory))
                Directory.Delete(directory, recursive: true);
        }
    }
}
