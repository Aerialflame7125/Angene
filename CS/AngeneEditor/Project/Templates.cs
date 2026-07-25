using Angene.Graphics;
using Angene.Main;

namespace AngeneEditor.Project
{
    public static class Templates
    {
        // ── .csproj ──────────────────────────────────────────────────────────────
        public static string CsProj(string rootNamespace) => $@"<Project Sdk=""Microsoft.NET.Sdk"">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <OutputType>Library</OutputType>
    <AssemblyName>Game</AssemblyName>
    <RootNamespace>{rootNamespace}</RootNamespace>
    <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
    <Nullable>enable</Nullable>
    <LangVersion>latest</LangVersion>
    <GenerateRuntimeConfigurationFiles>true</GenerateRuntimeConfigurationFiles>
    <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
  </PropertyGroup>

  <PropertyGroup Condition=""'$(OS)' == 'Windows_NT'"">
    <DefineConstants>WINDOWS</DefineConstants>
  </PropertyGroup>
  <PropertyGroup Condition=""'$(OS)' != 'Windows_NT'"">
    <DefineConstants>LINUX</DefineConstants>
  </PropertyGroup>

  <ItemGroup>
    <Reference Include=""Angene"">
      <HintPath>Libs\Angene.dll</HintPath>
    </Reference>
    <Reference Include=""Angene.Common"">
      <HintPath>Libs\Angene.Common.dll</HintPath>
    </Reference>
    <Reference Include=""Angene.Essentials"">
      <HintPath>Libs\Angene.Essentials.dll</HintPath>
    </Reference>
    <Reference Include=""Angene.Windows"">
      <HintPath>Libs\Angene.Windows.dll</HintPath>
    </Reference>
    <Reference Include=""Angene.Graphics"">
      <HintPath>Libs\Angene.Graphics.dll</HintPath>
    </Reference>
    <Reference Include=""Angene.Audio"">
      <HintPath>Libs\Angene.Audio.dll</HintPath>
    </Reference>
    <Reference Include=""Angene.Management"">
      <HintPath>Libs\Angene.Management.dll</HintPath>
    </Reference>
    <Reference Include=""Angene.Math"">
      <HintPath>Libs\Angene.Math.dll</HintPath>
    </Reference>
    <Reference Include=""BouncyCastle.Crypto"">
      <HintPath>Libs\BouncyCastle.Crypto.dll</HintPath>
    </Reference>
    <Reference Include=""DiscordRPC"">
      <HintPath>Libs\DiscordRPC.dll</HintPath>
    </Reference>
    <Reference Include=""Newtonsoft.Json"">
      <HintPath>Libs\Newtonsoft.Json.dll</HintPath>
    </Reference>
    <Reference Include=""System.Security.Permissions"">
      <HintPath>Libs\System.Security.Permissions.dll</HintPath>
    </Reference>
    <Reference Include=""System.Windows.Extensions"">
      <HintPath>Libs\System.Windows.Extensions.dll</HintPath>
    </Reference>
  </ItemGroup>
</Project>
";

        // ── Program.cs ───────────────────────────────────────────────────────────
        public static string ProgramCs(string rootNamespace, RenderType renderType) => $@"using Angene.Common;
using Angene.Common.Settings;
using Angene.Essentials;
using Angene.Main;
using Angene.Platform;
using Angene.Windows;
using {rootNamespace}.Scenes;
using {rootNamespace};
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Game
{{
    public class Instances
    {{
        public Engine engine = null!;
        public Settings settings = null!;

        public Instances() {{ }}
        public void MakeInstances(bool verbose)
        {{
            engine = Engine.Instance;
            engine.Init(verbose);
            settings = engine.SettingHandlerInstanced;
        }}
    }}

    public static class Program
    {{
        public static Instances? instances;
        private static DateTime lastFrame = DateTime.Now;

        [UnmanagedCallersOnly]
        public static int Main(IntPtr args, int argc)
        {{
            bool verbose = false;
            try
            {{
                string[] argArray = Array.Empty<string>();
                if (args != IntPtr.Zero && argc > 0)
                {{
                    argArray = new string[argc];
                    unsafe
                    {{
                        IntPtr* pArgs = (IntPtr*)args;
                        for (int i = 0; i < argc; i++)
                            argArray[i] = Marshal.PtrToStringUni(pArgs[i]) ?? string.Empty;
                        foreach (string arg in argArray)
                            if (arg == ""--verbose"") verbose = true;
                    }}
                }}

                RunGame(verbose);
                return 0;
            }}
            catch (Exception ex)
            {{
                Logger.LogCritical(
                    $""FATAL EXCEPTION: {{ex.Message}}"",
                    LoggingTarget.MainConstructor,
                    ex,
                    enginePanic: true);
                return 1;
            }}
        }}

        private static void RunGame(bool verbose)
        {{
            instances = new Instances();
            instances.MakeInstances(verbose);

            WindowConfig config = new WindowConfig();
            config.Title  = ""{rootNamespace}"";
            config.Width  = 1280;
            config.Height = 720;
            config.renderType = Graphics.RenderType.{renderType};
            Window window = new Window(config);

            var scene = new Init(window);
            window.SetScene(scene);

            bool running = true;
            while (running)
            {{
                running = Window.ProcessMessages();
                if (!running || !Engine.Instance.OpenWindows.Contains(window))
                    break;

                foreach (var s in window.Scenes)
                {{
                    double dt = (DateTime.Now - lastFrame).TotalSeconds;
                    Lifecycle.ScriptBinding.Tick(s, dt, EngineMode.Play);
                    Lifecycle.ScriptBinding.Draw(s, EngineMode.Play);
                    s?.Render();
                }}
                lastFrame = DateTime.Now;
                Thread.Sleep(16);
            }}

            window.Cleanup();
        }}
    }}
}}
";

        // ── Scenes/Init.cs ───────────────────────────────────────────────────────
        // NOTE: No commented-out example entity — ParseInitScene would match it
        public static string InitSceneCs(string rootNamespace, RenderType renderType)
        {
            if (renderType == RenderType.D3D11)
                return $@"using System.Collections.Generic;
using Angene.Common;
using Angene.Essentials;
using Angene.Main;
using Angene.Windows;

namespace {rootNamespace}.Scenes
{{
    /// <summary>
    /// Initial scene — generated by AngeneEditor.
    /// Add entities and scripts in Initialize(), or use the editor hierarchy.
    /// </summary>
    public sealed class Init : IScene
    {{
        private readonly Window _window;
        public object Instance => this;
        public string Name => ""Init"";
        public List<Entity> Entities {{ get; private set; }} = new();

        public Init(Window window)
        {{
            _window = window;
        }}

        public void Initialize()
        {{
            Entities = new List<Entity>();
            Logger.LogImportant(""Init scene loaded."", LoggingTarget.MainGame);

            // ── Add your entities here ───────────────────────────────────────────
        }}

        public void Render() {{ }}
        public void OnMessage(System.IntPtr msgPtr) {{ }}
        public List<Entity> GetEntities() => Entities;
        public void Cleanup()
        {{
            foreach (var e in Entities) e?.Destroy();
            Entities.Clear();
        }}
    }}
}}
";
            else
                return $@"using System.Collections.Generic;
using Angene.Common;
using Angene.Essentials;
using Angene.Main;
using Angene.Windows;

namespace {rootNamespace}.Scenes
{{
    /// <summary>
    /// Initial scene — generated by AngeneEditor.
    /// Add entities and scripts in Initialize(), or use the editor hierarchy.
    /// </summary>
    public sealed class Init : IScene
    {{
        private readonly Window _window;
        public object Instance => this;
        public string Name => ""Init"";
        public List<Entity> Entities {{ get; private set; }} = new();

        public Init(Window window)
        {{
            _window = window;
        }}

        public void Initialize()
        {{
            Entities = new List<Entity>();
            Logger.LogImportant(""Init scene loaded."", LoggingTarget.MainGame);

            // ── Add your entities here ───────────────────────────────────────────
        }}

        public void Render() {{ }}
        public void OnMessage(System.IntPtr msgPtr) {{ }}
        public List<Entity> GetEntities() => Entities;
        public void Cleanup()
        {{
            foreach (var e in Entities) e?.Destroy();
            Entities.Clear();
        }}
    }}
}}
";
        } 

        // ── Scripts/NewScript.cs ─────────────────────────────────────────────────
        public static string NewScriptCs(string rootNamespace, string scriptName) => $@"
using Angene.Essentials;
using Angene.Common;
using Angene.Main;
using System;

namespace {rootNamespace}.Scripts
{{
    public class {scriptName} : IScreenPlay
    {{
        public void Start()
        {{
            Logger.LogInfo($""Loaded script '{scriptName}' in scene '{{Engine.Instance.OpenWindows[0].PrimaryScene.Name}}'."", LoggingTarget.MainConstructor);
        }}

        public void Update(double dt)
        {{
        }}

        public void LateUpdate(double dt) {{ }}
        public void OnDraw() {{ }}
        public void Render() {{ }}
        public void Cleanup() {{ }}
        public void OnMessage(System.IntPtr msg) {{ }}
    }}
}}
";

        // ── Entity stub for Init.cs injection ────────────────────────────────────
        public static string EntityStub(string entityName, int x, int y, string[] scriptNames)
        {
            var sb = new System.Text.StringBuilder();
            string varName = SanitizeName(entityName);
            sb.AppendLine($"            // Entity: {entityName}");
            sb.AppendLine($"            Entity {varName} = new Entity({x}, {y}, \"{entityName}\");");
            foreach (var s in scriptNames)
                sb.AppendLine($"            {varName}.AddScript<Scripts.{s}>();");
            sb.AppendLine($"            {varName}.SetEnabled(true);");
            sb.AppendLine($"            Entities.Add({varName});");
            return sb.ToString();
        }

        private static string SanitizeName(string name)
            => System.Text.RegularExpressions.Regex.Replace(name, @"[^a-zA-Z0-9_]", "_").ToLower();
    }
}
