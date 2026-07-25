using AngeneEditor.Project;

namespace AngeneEditor.Tests.Project;

public sealed class TemplatesTests
{
    [Fact]
    public void GeneratedProjectTargetsCurrentPublicEngineContracts()
    {
        string program = Templates.ProgramCs("TemplateGame");
        string scene = Templates.InitSceneCs("TemplateGame");

        Assert.Contains("Window.ProcessMessages()", program);
        Assert.Contains("Logger.LogCritical(", program);
        Assert.DoesNotContain("Win32.", program);
        Assert.DoesNotContain("Logger.Log(", program);

        Assert.Contains("public object Instance => this;", scene);
        Assert.Contains("public List<Entity> Entities", scene);
        Assert.Contains("Logger.LogImportant(", scene);
        Assert.DoesNotContain("IRenderer3D", scene);
        Assert.DoesNotContain("_entities", scene);
    }
}
