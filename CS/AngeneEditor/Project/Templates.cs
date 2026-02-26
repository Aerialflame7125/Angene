namespace AngeneEditor.Project
{
    /// <summary>
    /// All file templates used when scaffolding a new Angene project.
    /// </summary>
    public static class Templates
    {
        // ── .csproj ──────────────────────────────────────────────────────────────
        public static string CsProj(string assemblyName, string rootNamespace) => $@"<Project Sdk=""Microsoft.NET.Sdk"">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <OutputType>Library</OutputType>
    <AssemblyName>{assemblyName}</AssemblyName>
    <RootNamespace>{rootNamespace}</RootNamespace>
    <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
    <Nullable>enable</Nullable>
    <LangVersion>latest</LangVersion>
    <GenerateRuntimeConfigurationFiles>true</GenerateRuntimeConfigurationFiles>
    <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
  </PropertyGroup>

  <!-- Platform-specific defines -->
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
        public static string ProgramCs(string rootNamespace) => $@"using Angene.Common;
using Angene.Common.Settings;
using Angene.Essentials;
using Angene.Main;
using Angene.Platform;
using {rootNamespace}.Scenes;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace {rootNamespace}
{{
    public class Instances
    {{
        public Engine engine;
        public Settings settings;

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
                Logger.Log($""FATAL EXCEPTION: {{ex.Message}}"", LoggingTarget.MainConstructor, logLevel: LogLevel.Critical, exception: ex);
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
            Window window = new Window(config);

            var scene = new Init(window);
            window.SetScene(scene);

            bool running = true;
            while (running)
            {{
                while (Win32.PeekMessageW(out var msg, IntPtr.Zero, 0, 0, Win32.PM_REMOVE))
                {{
                    if (msg.message == Win32.WM_QUIT) {{ running = false; break; }}
                    Win32.TranslateMessage(ref msg);
                    Win32.DispatchMessageW(ref msg);
                }}
                if (!running) break;

                foreach (var s in window.Scenes)
                {{
                    double dt = (DateTime.Now - lastFrame).TotalSeconds;
                    ScriptBinding.Lifecycle.Tick(s, dt, EngineMode.Play);
                    ScriptBinding.Lifecycle.Draw(s, EngineMode.Play);
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
        public static string InitSceneCs(string rootNamespace) => $@"using System.Collections.Generic;
using Angene.Common;
using Angene.Essentials;
using Angene.Main;

namespace {rootNamespace}.Scenes
{{
    /// <summary>
    /// Initial scene — generated by AngeneEditor.
    /// Add entities and scripts in Initialize().
    /// </summary>
    public sealed class Init : IScene
    {{
        public IRenderer3D? Renderer3D => null;

        private readonly Window _window;
        private List<Entity> _entities = new();

        public Init(Window window)
        {{
            _window = window;
        }}

        public void Initialize()
        {{
            _entities = new List<Entity>();
            Logger.Log(""Init scene loaded."", LoggingTarget.MainGame, LogLevel.Important);

            // ── Add your entities here ───────────────────────────────────────────
            // Entity myEntity = new Entity(0, 0, ""MyEntity"");
            // myEntity.AddScript<Scripts.MyScript>();
            // myEntity.SetEnabled(true);
            // _entities.Add(myEntity);
        }}

        public void Render() {{ }}
        public void OnMessage(System.IntPtr msgPtr) {{ }}
        public List<Entity> GetEntities() => _entities;
        public void Cleanup()
        {{
            foreach (var e in _entities) e?.Destroy();
            _entities.Clear();
        }}
    }}
}}
";

        // ── Scripts/NewScript.cs ─────────────────────────────────────────────────
        public static string NewScriptCs(string rootNamespace, string scriptName) => $@"// This script was auto-generated by AngeneEditor
using Angene.Essentials;
using System;

namespace {rootNamespace}.Scripts
{{
    public class {scriptName} : IScreenPlay
    {{
        public void Start() // On script instantiation
        {{
        
        }}

        public void Update(double dt) // Per tick/windows message
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
            sb.AppendLine($"            // Entity: {entityName}");
            sb.AppendLine($"            Entity {SanitizeName(entityName)} = new Entity({x}, {y}, \"{entityName}\");");
            foreach (var s in scriptNames)
                sb.AppendLine($"            {SanitizeName(entityName)}.AddScript<Scripts.{s}>();");
            sb.AppendLine($"            {SanitizeName(entityName)}.SetEnabled(true);");
            sb.AppendLine($"            _entities.Add({SanitizeName(entityName)});");
            return sb.ToString();
        }

        private static string SanitizeName(string name)
            => System.Text.RegularExpressions.Regex.Replace(name, @"[^a-zA-Z0-9_]", "_").ToLower();
    }
}
