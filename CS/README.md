![Angene Logo](https://github.com/Aerialflame7125/Angene/blob/main/AngeneLogoBig.png?raw=true)

# Angene

(pronounced 'engine')
Last updated 2026/07/25

The C# library/variant of Angene. If you want to see the tree for the engine, refer to FunctionTree.md

# Examples

## Engine

The engine is instantiated whenever you call upon the 'Engine.Instance.Init()' function.
This sits at the top of the runtime, providing the log window, lifetime instantiation, Window definitions, everything.

```cs
// You can do this if you want, but it's easier in my opinion to make instances.
public class Instances
{
  public Engine engine;
  public Settings settings;

  public Instances() { }
  public void MakeInstances(bool verbose)
  {
    engine = Engine.Instance; // Engine instance for references later
    engine.Init(verbose); // Initialize engine with logger var, defines window and shown below.
    settings = engine.SettingHandlerInstanced;  // DO NOT FORGET TO INSTANCE THE SETTINGS, LOGGER WILL LITERALLY SHIT ITSELF IF NOT
  }
}
Instances i = new Instances();
i.MakeInstances(true);
```

This is just an example of instantiation, and yes, the logger is required to be initialized.
Later using this Engine class, you are able to create a new window:

```cs
WindowConfig conf = new WindowConfig();
conf.Title = "Angene | Demo Code";
conf.Transparency = Win32.WindowTransparency.SemiTransparent; // Not required, nice touch though
conf.Width = 1280; conf.Height = 720;
config.renderType = RenderType.DX11
window = new Window(conf);
Logger.LogDebug("New window, yaey!", LoggingTarget.Engine);
```

// 7/25/26
You can either create your own WindowConfig definition, or use the built in ones. For more information please refer to WindowConfig in Angene.Main.
As an example, for D3D11, use .Rendering3D:
```cs
WindowConfig confg = WindowConfig.Rendering3D("Angene | Rendering3D", 1280, 720);
Window win = new Window(config);
```

Then add a scene to said window:

```cs
DemoScene scene = null;
try
{
  scene = new DemoScene.Init(window); // Example in my case, I add a Init() call to my scenes so I can set vars before instantiation into the window.
  window.SetScene(scene); // Clears all scenes at runtime, not like there would be any.
} catch (Exception ex)
{
  Debug.LogCritical($"Error in scene instantiation: {ex.GetType().Name}: {ex.Message}", LoggingTarget.MainScene, exception: ex); // just in case
}
```

I find it somewhat intuitive, but sometimes a pain. testGame is accessible in the root of this repo, so you can see how I initialize the engine.

## Logger

The logger is instantiated by the engine when 'Engine.Init(bool)' is called.
I hate logs as much as the next guy, but it makes debugging or helping users so much easier.
At least its better than placing it in 'LocalLow{Dev}{Game}Player.log' where NO ORDINARY USER WILL BE ABLE TO FIND IT.

```cs
engine = Engine.Instance;
engine.Init(true); // If true, opens a new log window

Logger.LogDebug("Hey i'm a debug log!", LoggingTarget.MainGame); // Logs to file, logLevel is optional as so:
Logger.LogError("Woah I'm an error, be scared.", LoggingTarget.Class);
```

But there is even easier:

```cs
try
{
  Logger.LogError("I'm already an error, no need for logLevel!", LoggingTarget.MainScene);
}
catch (Exception ex) {
  Logger.LogCritical("I'm a critical error, I require a stack trace along with an exception.", LoggingTarget.MainConstructor, exception: ex);
} // not that the logger would ever call an exception, just an example.
```

There are more examples of this logger, above shows the calls. Below is the hierarchy for importance, top is most important.

* LogCritical
* LogError
* LogWarning
* LogImportant
* LogInfo
* LogDebug
This logger already pre-writes a new file to a folder called "Log", picking everything up from the engine and game stack. Debug is written here instead of window when log window instance exists.

## Windows message loop (Win32)

Please, please, please, do not forget the message loop.
The message loop is what keeps the entire lifecycle in check, as well as triggering every tick.
This is left open for the developer in case they want anything in between ticks or draw. Use the below as a template if you want:

```cs
private static void RunWindowsMessageLoop(ref double dt)
{
    bool running = true;
    while (running)
    {
        while (User32.PeekMessageW(out var msg, IntPtr.Zero, 0, 0, Consts.PM_REMOVE))
        {
            if (msg.message == (uint)WM.QUIT)
            {
                running = false;
                break;
            }
            User32.TranslateMessage(ref msg);
            User32.DispatchMessageW(ref msg);
        }
        if (!running) break;
        dt = (DateTime.Now - lastFrame).TotalSeconds;
        lastFrame = DateTime.Now;
        foreach (var win in Engine.Instance.OpenWindows)
        {
            foreach (var scene in win.Scenes)
            {
                Lifecycle.ScriptBinding.Tick(scene, dt, EngineMode.Play);
                Lifecycle.ScriptBinding.Draw(scene, EngineMode.Play);
            }
            win.RenderFrame();
            win._screenPlay?.LateUpdate(dt);
        }
        Thread.Sleep(16);
    }
}
```

Sure, it's a little counter-intuitive, but it leaves the lifecycle as a choice for the developer, maybe even allowing some funky shit later.
Just remember, if you detatch the tick method, no scene or script will run. Everything is reliant on ticks and OnDraw.

// 7/25/26
Another thing, for rendering ever since D3D11 came out, you need a specific window pump in order to properly render windows:
```cs
private static void PumpOpenWindows()
{
    while (User32.PeekMessageW(out var msg, IntPtr.Zero, 0, 0, Consts.PM_REMOVE))
    {
        if (msg.message == (uint)WM.QUIT) break;
        User32.TranslateMessage(ref msg);
        User32.DispatchMessageW(ref msg);
    }
    foreach (var win in Engine.Instance.OpenWindows.ToArray())
    {
        win.RenderFrame();
        Engine.Instance.FlushPendingCloses();
    }
}
```

## Package Handler (Angene.PkgHandler)

This loads angpkg files that are compiled from the packer in the root of this repo. If you aren't familiar, it is the equivelant of a unitypackage file or assetbundle.
It is designed to be instantiated at runtime for easier usage. Scripts may not work in this, at the time of writing (2/21/26), it hasn't been tested.

```cs
try
{
  private string _packagePath = Path.Combine(AppContext.BaseDirectory, "game.angpkg");
  if (File.Exists(_packagePath))
  {
    _package = Angene.Main.Package.Open(_packagePath, key: null); // Key is used if encrypted with a key at package time.
    foreach (var e in _package.Entries)
      _entryNames.Add(e.Path);

    // Use known path
    var target = _entryNames.FirstOrDefault(p => p.EndsWith("text/hello.txt", StringComparison.OrdinalIgnoreCase))
                ?? _entryNames.FirstOrDefault();

    if (target != null)
    {
      var entry = _package.Entries.FirstOrDefault(x => string.Equals(x.Path, target, StringComparison.OrdinalIgnoreCase));
      if (entry != null)
      {
        using var s = _package.OpenStream(entry);
        using var sr = new StreamReader(s, Encoding.UTF8);
        _loadedText = sr.ReadToEnd();
      };
    }
    else
    {
      _loadedText = "Package opened, but no entries found.";
    }
  }
  else
  {
    _loadedText = $"Package not found at '{_packagePath}'.";
  }
}
catch (Exception ex)
{
    // Keep the scene functional; show error text
    _loadedText = $"Error opening package: {ex.Message}";
}
```

Sadly incredibly fraile, will fall apart if path is not met up to standard.
This example shows loading text from a package to be used later, this is the exact same thing as in TextHandler in testGame.
If it has hexadecimal in the actual file, it can be packed. The same can't be said about loading, but whatever.
This can also be used for OTA (Over The Air) updates, download a package, load and 'unzip' it, then you have a new version!

## ScreenPlay scripts (Essentials.IScreenPlay)

These are scripts that load at runtime as children of entities.
I attempted to make this cleaner than it really is, sorry for that.
You can use these to instantiate new objects, handle other entities, or even Discord RPC if you feel inclined to do.

```cs
internal class ScriptExample : IScreenPlay
{
  private int num;
  public void Initialize(int _num)
  {
    num = _num;
  }

  public void Start()
  {
    Logger.LogImportant("Hey this script is set up with the lifecycle!", LoggingTarget.MainGame);
    if (num != null)
    {
      Logger.LogDebug($"The number is {num}.", LoggingTarget.Class);
    }
  }
  void Cleanup()
  {
    //Dispose of anything you need to, is required by spec.
  }
}
```

This is just an example script, but you still have to set it up with the lifecycle:

```cs
var script = Entity.AddScript<ScriptExample>();
script.Initialize(46); // Following example from earlier
Entity.SetEnabled(true); // Start entity, sets up script with lifecycle.
```

I find this really cool to be honest, you (the developer) do not have to touch the lifecycle at all. (Unless you are setting up OnMessage handlers in the message loop.)

## Scenes (Essentials.IScene)

The nitty gritty, how games work and how things are instantiated and ran in lifetime.
The scene spec is simple, very few things to add.

```cs
public class DemoScene : IScene
{
  // The following 3 vars are not required, but are recommended.
  public object Instance {get; private set;} 
  public List<Entity> entities {get; private set;}
  public Window _window;

  internal DemoScene(Window window) // Again, not needed by spec, but useful.
  {
    _window = window;
    Instance = this;
  }

  public void Initialize()
  {
    entities = new List<Entity>();
    Logger.LogInfo($"Running on {PlatformDetection.CurrentPlatform}", LoggingTarget.MainGame);
    // ... do entity mumbo jumbo here i guess
  }

  public void OnMessage(IntPtr msgPtr)
  {
    if (msgPtr = IntPtr.Zero) return;
    // Handle messages here, keyboard input, mouse movement, yatta yatta.

#if WINDOWS
    var msg = Marshal.PtrToStructure<Win32.MSG>(msgPtr);
    if (msg.message == Win32.WM_CLOSE)
    {
      Angene.Main.Console.WriteLine("[PackageTest] Received WM_CLOSE");
    }
#else
    Logger.LogError("Other platforms are not supported at the moment.", LoggingTarget.MainGame);
    throw new AngeneException("Platform Incompatibility, Please run on Windows.");
#endif
  }

  public void Render() { }
  public List<Entity> GetEntities() => entities;
  public void Cleanup() { }
```

Really long exerpt, but it was worth it. Take note of how there is an OnMessage scene call, Messages are also distributed to scenes handled by window lifetime.

## Window Configs (Platform.WindowConfig)

Honestly one of the more easier parts of this engine. This defines the construct that the window is based off of.
You (the developer) have a plethora of options for the window, and I honestly recommend that you actually read the (C# spec for yourself)[https://github.com/Aerialflame7125/Angene/blob/main/CS/Angene/Angene.Main/Platform/WindowConfig.cs].
Here is a really basic window config, along with instantiation:

```cs
WindowConfig winconf = new WindowConfig();
winconf.Title = "Angene | Demo";
winconf.Width = 1280; winconf.Height = 720;
Window win = new Window(winconf);
```

It just creates a new 720p window showing nothing. Everything else is handled by lifetime.

## Rich Presence (External.DiscordRichPresence)

Leverages an already made library, but adjusted it within my engine so it is easier on the developer.

```cs
internal class RPC : IScreenPlay
{
  private RichPresence presence = new RichPresence
  {
    Assets = new Assets {SmallImageKey = "angene_logo", SmallImageText = $"Running on Angene"}
  };
  private DiscordRichPresence? _rpc = new ("1467308284322254862");
  public void Start()
  {
    presence.State = "woah demo rpc!?!?!?";
    presence.Assets.LargeImageKey = "g_khlbfbmaec9sq";
    presence.Assets.LargeImageText = "SHOT DEAD IN THE BRONX";
    presence.Buttons = new[]
      {
      new Button
      {
        Label = "join me twin",
        Url = "https://amretar.com"
      }
    };
    _rpc.SetPresence(presence);
  }
  void Cleanup()
  {
    _rpc?.Dispose();
    _rpc = null;
  }
}
```

Again really long exerpt, but essentially initializes RPC. I am aware I put an app id in there. It's the same one in testGame, its not special.

## Websocket Windows

Not recommended, this forwards all window graphics (gdi) to a websocket to be interpreted by an http connection. There is NO CERTIFICATE.
Just to initialize is simple as can be:

```cs
instances.settings.SetSetting("Main.getIsGameAllowedForWebsockets", true);
WindowConfig config = new WindowConfig();
config.cTI = true;       // enable connection type injection
config.cTS = "ws";       // set type to websocket
config.cTT = "ws";       // set transport type
config.Title = "Angene | exampleGame";
config.Transparency = Win32.WindowTransparency.SemiTransparent;
config.Width = 1280; config.Height = 720;
window = new Window(config);
Logger.LogDebug("Window created successfully", LoggingTarget.Engine);
```

Simple right? Well the implementation isn't.
If you want an example for a http server via html5, [reach out here](https://github.com/Aerialflame7125/Angene/blob/main/testGame/WebsocketServer/index.html)

There are lots of other obscure methods, but if you want the easiest example, just use [the text handler from there](https://github.com/Aerialflame7125/Angene/blob/main/testGame/WebsocketServer/TextHandler.cs) or refer to the graphics context at the top listing.

## Example CSProj

Not really a helper to provide an example but whatever
The CPP host file is really picky on namespaces, so here is an example:

```csproj
<PropertyGroup>
	<TargetFramework>net8.0</TargetFramework>
	<OutputType>Library</OutputType>
	<AssemblyName>Game</AssemblyName>
	<RootNamespace>Game</RootNamespace>
	<AllowUnsafeBlocks>true</AllowUnsafeBlocks>
	<Nullable>enable</Nullable>
	<LangVersion>latest</LangVersion>

	<!-- Generate runtime config file -->
	<GenerateRuntimeConfigurationFiles>true</GenerateRuntimeConfigurationFiles>

	<!-- Copy dependencies to output -->
	<CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
</PropertyGroup>

<!-- Platform-specific defines -->
<PropertyGroup Condition="'$(OS)' == 'Windows_NT'">
	<DefineConstants>WINDOWS</DefineConstants>
</PropertyGroup>
<PropertyGroup Condition="'$(OS)' != 'Windows_NT'">
	<DefineConstants>LINUX</DefineConstants>
</PropertyGroup>
```

This literally is the simplest you need if you want to at least compile.
Next the entry point:

## Entry point

The engine's host cpp file has a very specific entry point definition as well:

```cs
[UnmanagedCallersOnly]
public static int Main(IntPtr args, int argc)
{
    bool verbose = false;
    try
    {
        // Parse command-line arguments if provided
        string[] argArray = Array.Empty<string>();
        if (args != IntPtr.Zero && argc > 0)
        {
            argArray = new string[argc];
            unsafe
            {
                IntPtr* pArgs = (IntPtr*)args;
                for (int i = 0; i < argc; i++)
                {
                    argArray[i] = Marshal.PtrToStringUni(pArgs[i]) ?? string.Empty;
                }
            }
            foreach (string arg in argArray)
            {
                if (arg.Length > 0 && arg == "--verbose" && !verbose)
                {
                    verbose = true;
                }
            }
            Logger.LogInfo($"Arguments received ({argc}):", LoggingTarget.MainConstructor);
            for (int i = 0; i < argArray.Length; i++)
            {
                Logger.LogInfo($"  [{i}] {argArray[i]}", LoggingTarget.MainConstructor);
            }
            Logger.LogInfo("", LoggingTarget.MainConstructor);
        }

        Logger.LogDebug("Calling RunGame...", LoggingTarget.MainConstructor);
        RunGame(verbose);

        return 0;
    }
    catch (Exception ex)
    {
        Logger.LogCritical($"nFATAL EXCEPTION in Main:", LoggingTarget.MainConstructor, exception: ex);
        return 1; // Error
    }
}
```

Again just an example, but the arguments are as follows. If a log directory is not created after launching the host, something is incorrect with the entry point or the engine hasn't initialized.

// 7/25/26
Ever since D3D11, prior to actually rendering or creating Windows with initializing the WindowConfig add this to somewhere before creating your windows:
```cs
Logger.LogImportant("Waiting for shader precompilation to finish...", LoggingTarget.MainGame);
while (Engine.Instance.IsCompilingShaders)
{
    PumpOpenWindows();
    Thread.Sleep(16);
}
Logger.LogImportant("Shader precompilation finished.", LoggingTarget.MainGame);
```


## Audio

Audio is really strange, but I attempted to have this as simple as possible. You first need to create an AudioFile() var:

```cs
// In scene Initialize() or inside a script:

var audio = new AudioFile(
  packagePath: "assets.angpkg",
  path: "audio/music/myAudioFile.wav", // currently at writing (2/28/26), only support wav files.
  loadType: AudioFile.LoadType.loadOnInstantiate // Loads on scene/script instantiation, other enum values are listed in tree for Angene.Audio.
  );
```

Then create an audio manager, this is handled in its own thread to save the original game threads:

```cs
var audioManager = new AudioManager(
  file: audio,
  playOnLoad: true, // Play the audio once the file is loaded
  loop: true, // Your choice of looping the audio when it finishes
  volume: 0.3f // A float value between 0 and 1, no higher or lower.
);
```

This creates a new AudioManager thread, able and ready to be called.

### Audio calls

You can make many different calls towards audio, it's just a matter of how you use them. Here's an example of a function call:

```cs
public void OnGunFire()
{
  // For this example, loadOnGetThenDestroy is ideal, starts reading bytes, plays, then disposes file handle to save resources.
  var sfxFile = new AudioFile(
    "assets.angpkg",
    "audio/sfx/shoot.wav",
    AudioFile.LoadType.loadOnGetThenDestroy
  );

  var sfx = new AudioManager(sfxFile, playOnLoad: true, loop: false, volume: 0.7f);
  // Then track it elsewhere if you need to Dispose() later.
}
```

Or you can have it idle to be played later:

```cs
public void CreateAudio()
{
  var file = new AudioFile(
    "assets.angpkg",
    "audio/sfx.wav",
    AudioFile.LoadType.loadOnInstantiate
  );

  var manager = new AudioManager(file, playOnLoad: false, loop: false, volume: 1f);

  // nobody would ever do this but here:
  manager.Play(); // start playing audio
  manager.Pause(); // pause audio
  manager.Resume(); // resume
  manager.SetLooping(true); // start looping
  manager.SetVolume(0f); // silence
  manager.Stop(); // stop
  manager.Dispose(); // and just remove it
}
```

Now if your package has a key on it, you have to define a key:

```cs
byte[] key; //just set your key later
// ...

var file = new AudioFile(
  packagePath: "assets_enc.angpkg",
  path: "audio/music/theme.wav",
  loadType: AudioFile.LoadType.loadOnInstantiate,
  key: key
);
// then do the same as usual
```

## Math

This entire math library includes a fuck ton of Vectors, Interpolation, randomisation, and gpu-acceleration.

### Vectors

```cs
var a = new Vec2(3f, 4f);
var b = new Vec2(1f, 2f);

float len  = a.Length;           // 5
float dot  = Vec2.Dot(a, b);     // 11
Vec2 norm  = a.Normalized;       // (0.6, 0.8)
Vec2 lerp  = Vec2.Lerp(a, b, 0.5f);
Vec2 refl  = Vec2.Reflect(a, Vec2.Up);

var x = new Vec3(1f, 0f, 0f);
var y = new Vec3(0f, 1f, 0f);
Vec3 cross = Vec3.Cross(x, y);   // (0, 0, 1)

var rect = new Rect(10f, 10f, 100f, 50f);
bool hit  = rect.Contains(new Vec2(50f, 30f)); // true

var translate = Matrix3x3.Translation(10f, 20f);
Vec2 moved = translate * new Vec2(5f, 3f);     // (15, 23)
```

### Interpolation (Mathf)

```cs
float clamped   = Mathf.Clamp(5f, 0f, 3f);           // 3
float remapped  = Mathf.Remap(5f, 0f, 10f, 0f, 100f); // 50
float lerped    = Mathf.Lerp(0f, 100f, 0.25f);         // 25
float smooth    = Mathf.SmoothStep(0f, 1f, 0.5f);      // 0.5
float delta     = Mathf.DeltaAngle(10f, 350f);         // -20 (shortest arc)

float vel = 0f;
float damped = Mathf.SmoothDamp(0f, 100f, ref vel, smoothTime: 0.5f, dt: 0.016);

// Easing — all take t in [0,1]
float eased = Mathf.Ease.OutBack(0.5f);   // overshoots past 1
float bounce = Mathf.Ease.OutBounce(0.5f);
```

### Randomisation (Rand)

```cs
Rand.SetSeed(42); // deterministic from here on

float f   = Rand.Value;               // [0, 1)
float r   = Rand.Range(-5f, 5f);
int   i   = Rand.Range(0, 10);
Vec2  inC = Rand.InsideUnitCircle;    // |v| ≤ 1
Vec2  onC = Rand.OnUnitCircle;        // |v| ≈ 1
bool  hit = Rand.Chance(0.3f);        // ~30% true

string picked = Rand.Pick(new[] { "alpha", "beta", "gamma" });

var list = new List { 1, 2, 3, 4, 5 };
Rand.Shuffle(list);
```

### GpuMath (bulk ops, CPU fallback below threshold)

```cs
// Requires an IComputeBackend — pass a real D3D11/Vulkan backend for GPU dispatch.
// Arrays smaller than GpuMath.GpuThreshold (default 512) fall back to CPU automatically.
var gpu = new Angene.Math.GPU.Math(myComputeBackend);

Vec2[] a = /* ... */;
Vec2[] b = /* ... */;

Vec2[]  added    = gpu.Add(a, b);
Vec2[]  normed   = gpu.Normalize(a);
float[] dots     = gpu.Dot(a, b);
Vec2[]  lerped   = gpu.Lerp(a, b, 0.5f);     // uniform t
Vec2[]  lerped2  = gpu.Lerp(a, b, tArray);   // per-element t

float[] clamped  = gpu.Clamp(values, 0f, 1f);
float[] remapped = gpu.Remap(values, 0f, 100f, 0f, 1f);
float   sum      = gpu.Sum(values);
float   max      = gpu.Max(values);
Vec2    vecAvg   = gpu.Average(vec2Array);

gpu.Dispose();
```

An example of all of these is in [testGame/MathTest](https://github.com/Aerialflame7125/Angene/tree/main/testGame/MathTest).

## Key Detection
  
```cs
bool held = KeyDetection.IsKeyDown(key);

uint bg = held ? 0x003A6E3Au : 0x00222233u;
uint fg = held ? 0x0000FF00u : 0x00AAAAAAu;
uint border = held ? 0x0000CC00u : 0x00444466u;
```

This example takes in if a key is down and decides uint color values when a key is down.
The specifications show exactly what you are able to call, as well as how to return a list of down keys.
You need to register the key detection script seperately. This is by design to save performance.
You can do it like so:

```cs
_keyDetection.Register(_window.ManagementScene as ManagementScene);
// Or you can do it like this, not needing an argument at all:
_keyDetection.Register();
```
IsKeyDown() returns a boolean based upon if the key given is down.

## DX11
Finally long awaited, and still here to ruin peoples lifes. Lets walk through this.

```cs
public class DX11ExampleScene : IScene
{
  public object Instance { get; private set; }
  public List<Entity> Entities { get; private set; } = new List<Entity>();
  public string Name => "DX11ExampleScene";

  private readonly Window _window;
  private IDX11GraphicsContext _gfx;

  private IntPtr _vertexBuffer;
  private IntPtr _inputLayout;
  private SlangShaderResources.IShader _vertexShader;
  private SlangShaderResources.IShader _pixelShader;

  private Vertex[] vertices = new Vertex[] { };
  private uint vertexStride;
  private int vertexCount;
  private int totalByteSize;

  public DX11ExampleScene(Window window)
  {
    _window = window ?? throw new ArgumentNullException(nameof(window));
  }
  public void Initialize()
  {
      Instance = this;
      _gfx = _window.Graphics as IDX11GraphicsContext;
      if (_gfx == null)
      {
          Logger.LogCritical("Window is not using the D3D11 backend — use WindowConfig.Rendering3D(...).", LoggingTarget.Graphics, new AngeneException("Window is not using the D3D11 rendering backend."));
          return;
      }

      if (Engine.Instance.ShaderCache == null
          || !Engine.Instance.ShaderCache.TryGetValue(1, out _vertexShader)
          || !Engine.Instance.ShaderCache.TryGetValue(2, out _pixelShader))
      {
          Logger.LogCritical("[ShaderCompileTestScene] TestVS/TestPS were not found in Engine.Instance.ShaderCache. Precompilation did not run or failed silently.", LoggingTarget.Graphics, new AngeneException("Shader cache missing expected entries."));
          return;
      }
      Logger.LogImportant($"{_vertexShader.Name} = VertexShader, {_pixelShader.Name} = PixelShader", LoggingTarget.Graphics);
      Logger.LogImportant("[ShaderCompileTestScene] Found compiled shaders in ShaderCache — Slang compilation pipeline produced usable shaders.", LoggingTarget.Graphics);

      // Define data cleanly using the struct
      vertices = new[]{
        new Vertex { X =  0.0f, Y =  0.5f, Z = 0.0f, R = 1f, G = 0f, B = 0f, A = 1f },
        new Vertex { X =  0.5f, Y = -0.5f, Z = 0.0f, R = 0f, G = 1f, B = 0f, A = 1f },
        new Vertex { X = -0.5f, Y = -0.5f, Z = 0.0f, R = 0f, G = 0f, B = 1f, A = 1f }
      }
    
      vertexStride = (uint)Marshal.SizeOf<Vertex>();
      vertexCount = vertices.Length;
      totalByteSize = (int)(vertexStride * vertexCount);

      byte[] vertexBytes = MemoryMarshal.AsBytes(vertices.AsSpan()).ToArray();
      totalByteSize = vertexBytes.Length;

      _vertexBuffer = _gfx.CreateVertexBuffer(vertexBytes, vertexStride);

      var elements = new[]
      {
          new InputElement { SemanticName = "POSITION", SemanticIndex = 0, Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT,    ByteOffset = 0  },
          new InputElement { SemanticName = "COLOR",    SemanticIndex = 0, Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT, ByteOffset = 12 },
      };

      if (_vertexShader.byteCode == null)
          Logger.LogCritical("Vertex shader bytecode is null. Compilation did not succeed.", LoggingTarget.MainGame, new AngeneException("Bytecode is null."), true);

      _inputLayout = _gfx.CreateInputLayout(elements, _vertexShader.byteCode);
  }

  public void OnMessage(IntPtr msgPtr) { }

  public void Render() { }

  public void Render(ID3D11GraphicsContext _gfx)
  {
      _gfx.Render(_vertexShader, _pixelShader, _inputLayout, _vertexBuffer, vertexStride, (uint)vertexCount);
  }

  public void Cleanup()
  {
      // Don't dispose shaders here, they are owned by Engine.Instance.
      if (_vertexBuffer != IntPtr.Zero) Marshal.Release(_vertexBuffer);
      if (_inputLayout != IntPtr.Zero) Marshal.Release(_inputLayout);
  }
}
```
I know, its a really long exerpt; it's a page taken out of ShaderCompileTestScene.
It's a beautiful sight aint it? I plan to get this smaller as time goes on for rendering.

## Dx11Shader classes
Okay, it's the meat and bones of DirectX, stay with me here.
I tried to get this to a point that even I can understand it, so please be patient with them.
(I did not crash both of my GPUs twice while making this btw)
```cs
[Attributes.Precompile]
public class TestVertexShader : SlangShaderResources.IShader
{
  public string Name => "TestVS";
  public int id => 1;
  public string Extension => "hlsl";
  public string EntryPoint { get; set; } = "main";
  public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
  public bool compileToFile { get; } = true;
  public bool IsDisposed { get; private set; }

  SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

  public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

  public byte[] byteCode => null;

  public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

  public string OutputDebugInfo(bool log = true)
  {
      string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
      if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
      return info;
  }

  public void Dispose() => IsDisposed = true;
}

[Attributes.Precompile]
public class TestPixelShader : SlangShaderResources.IShader
{
  public string Name => "TestPS";
  public int id => 2;
  public string Extension => "hlsl";
  public string Path { get; set; } = System.IO.Path.Combine(AppContext.BaseDirectory, "Shaders", "PixelShader.hlsl");
  public string EntryPoint { get; set; } = "main";
  public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Pixel;
  public bool compileToFile { get; } = false;
  public bool IsDisposed { get; private set; }

  public string Code => @"struct PSInput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

float4 main(PSInput input) : SV_TARGET
{
    return input.Color;
}
";

  public byte[] byteCode => null;

  SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

  public void Bind() { }

  public string OutputDebugInfo(bool log = true)
  {
      string info = $"{{'Name':'{Name}','Type':'{Type}','Path':'{Path}'}}";
      if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
      return info;
  }

  public void Dispose() => IsDisposed = true;
}
```
This is an example of a Pixel shader and a Vertex shader. Notice some distinctions:
1. They do not take after Dx11Shader and instead inherit a class called 'SlangShaderResources.IShader'
2. They both have a [Attributes.Precompile] attribute. This is an attribute made specifically for shaders for compiling before the window is created.
3. They both are hlsl. I didn't feel like anything else was necessary.
4. compileToFile boolean. This boolean is checked at compile time to be caching files inside whichever matches your operating system. Refer to Engine.cs in Angene.Main.

This sucked to get working, but Slang is the primary compiler that is responsible for compiling and the library is about 30 MB. I'm not happy about it either.
The Slang interop is currently only on the windows platform, for I plan to get this added for Linux too. MacOS users can respectfully, not get this engine.

# QnA

  ## Have you [vibecoded](http://vibe-coded.urbanup.com/18530338) any part of this engine?

  Sadly, yes. There are major parts within this game engine that are vibe coded. Most of that is the partial lack of interest and lack of thinking that I would ever use it in the future.
  If you need to know which parts are vibe coded, I will list them here:

  ### Angene.Math

  * Angene.Math

    * Rand
  * Angene.Math.Defs

    * IComputeBackend
    * IComputeJob
  * Angene.Math.GPU

    * Math
  * Angene.Math.Interpolation

    * Mathf
  * Angene.Math.Vectors

    * Vectors

  ### Angene.Common

  * Globals

    * IRenderer3D (Partial, literally just a header to differentiate renderer types.)

  ### Angene.Audio

  * All of the above.

    * I state this because the entire audio library is vibecoded. Windows audio formats suck and are horrible to work with.
    * If you wish to fact check me, just remember that the audio libraries are all in CPP and C, requiring importing.
    * Another thing, Windows audio derives from older versions that still exist in newer systems (Windows 11) still completely being deprecated and dead code. Microslop has yet to remove these older versions, causing discrepancies in what library users should use.

  ### Angene (main library)

  * Main
    * WS
    * PkgHandler
  * Crypto
    * Literally just a conversion wrapper. Too lazy to change all of the references, so why not make it yourself to shut the console up!

  ### Angene.Windows

  * Kernel32
  * Gdi32
  * Win32Messages
  * All of the listed libraries is vibe coded. This primarilly consists of Win32 messages and headers pertaining to specific windows implementations. Microsoft documentation is correct and actually helped a lot when writing python implementations, but I will refer you to the [definitions file](https://github.com/Aerialflame7125/Angene/blob/main/Python/Angene/Main/definitions.py) written in python, and you tell me if you want to implement that in C#.
  * Most of this is also at the hands of bad implementations, very generously providing a great help when it comes to conversions to other languages :thumbs_up: (sarcasm.)

  Also, this entire readme is written by hand before you ask. I'm not going to document a game engine I am working on with AI. What kind of person do you take me for?

  ## Why is this Windows-Only (for now)?

  This engine is windows only because of how I just couldn't find documentation. Not to mention, I started this project on Windows 10 and will continue working on it in Windows.
Before yall Linux nerds and soul-less Fedora users come in here and rip on me for not using "ThE BEsT OpERaTiNG sYsTEm eVeR!" Just remember that C# is made by Microsoft, not to mention Visual-fucking-Studio is not on any Linux system other than of-fucking course MacOS. (other than VSCode, but respectfully I'm not using VSC for C#.)

  ## Who all is working on this?

  Me, myself, and fucking I. Sure, some coding agents and slop AI was slapped into here as a temporary bandage, but as of now, [I am the only contributor](https://github.com/Aerialflame7125/Angene/commits/main/).

  ## Why do you still work on this?

  Passion project. Next!

  ## Can you explain ALL OF THAT again?

  I would rather work for [CrowdStrike](https://www.cisa.gov/news-events/alerts/2024/07/19/widespread-it-outage-due-crowdstrike-update) than that.

# Conclusion

  i'm really fucking tired, see yall next commit.

