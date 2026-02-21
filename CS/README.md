![Angene Logo](https://github.com/Aerialflame7125/Angene/blob/main/AngeneLogoBig.png?raw=true)
# Angene
(pronounced 'engine')

The C# library/variant of Angene. Functions and calls are described here:
## Angene
- Angene.Engine
  - (Settings) Engine.SettingHandlerInstanced() # Returns the settings instance, do NOT INSTANTIATE NEW SETTINGS AFTER INIT
  
  - Engine.Console # Ambiguous references to cause compiler errors. Used to prevent the developer from calling wrong functions. :omegalul:
      - Console.WriteLine(string)
      - Console.ReadLine(string)
      - Console.Write(string)
   
  - Engine.Window(WindowConfig)
      - Window.SetScene(IScene) # Removes all other scenes (besides essential), sets primary scene.
      - Window.AddScene(IScene) # Adds a new scene to loaded scenes
      - Window.RemoveScene(IScene) # Removes scene from loaded scenes array
      - Window.SetEngineMode(EngineMode) # Sets engine mode. 'EngineMode.Play', 'EngineMode.Edit'. (Added for engine flexibility for the actual GUI editor coming up!)
      - Window.Cleanup() # Cleans up window resources
      - Window.ProcessMessages() # Already called by lifecycle (Refer to Angene.Essentials.Lifecycle), processes message meaning and distributes to scenes.
   
  - Engine.Init(Bool verbose) # Verbose call refers to log window

  - Engine.Instance
- Angene.Win32
  - Win32.WindowStyle : uint
  - Win32.WindowStyleEx : uint
  - (struct) Win32.WindowTransparancy
  - ### being dead honest this file is really fucking big and has a lot of calls. I'm not doing all of that until the engine is done.

- Angene.External
  - External.DiscordRichPresence
    - (partial class) DiscordRichPresence
      - DiscordRichPresence(clientId) # New RPC Instance
      - SetPresence(RichPresence) # Sets new RPC
      - Clear() # Clears RPC
      - schedule() # Schedules Cts token debounce
      - Dispose() # Clears client
     
## Angene.Essentials
- Essentials.Entity : IEquatable<Entity> # The ENTIRE FUCKING ENTITY
  - static int Id # Entity ID
  - int x # X axis
  - int y # Y axis
  - int z # Z axis
  - string name # Name of *this* object
  - List<Entity> childEntities # Child entities of *this* entity

  - Entity(int, int, string) # Entity object, child of scene
    - Id # Entity ID
    - x # X axis
    - y # Y axis
    - z = 0 # Z axis (Not implemented, but placeholder and not required.)
    - name # name of object
    - _scripts # All script objects (List<object>)
    - childEntities # All child entities (List<Entity>)
    - _parent # Parent object
    - _enabled # If enabled

  - T AddScript<T>() where T : new() # Add a script component to lifecycle system
  - AddScript(object) # Adds a new script *instance* to hierarchy
  - RemoveScript(object) # Remove a script, does **NOT TRIGGER LIFECYCLE CALLBACKS**
  - IReadOnlyList<Object> GetScripts() # Get all scripts attached to this entity
  - T GetScriptByType<T>() # Gets script from list by type (Cannot return null, returns default(T))
  - T? GetScript<T>() where T : class # Gets script from list by specific type (Can return null)
  - SetEnabled(bool) # Sets *this* entity enabled
  - bool IsEnabled() # Check if enabled
  - AddChild(Entity) # Adds new child to hierarchy
  - RemoveChild(Entity) # Removes entity child from hierarchy
  - bool IsParent(Entity) # Check if entity is parent of this entity
  - Entity? GetParent() # Gets entity parent
  - Destroy() # Destroys entity and all associated children
  - bool Equals(Entity?) # Grabs if entity is equal to *this* entity
  - bool Equals(object?) # Grabs if object is equal to entity
  - int GetHashCode() # Grabs entity id

- Essentials.IScene
  - interface IScene
    - Initialize() # Initializes scene, required
    - List<Entity> GetEntities() # Grabs entities from scene, required
    - OnMessage(IntPtr) # Calls on every message, required
    - Render() # Calls before OnDraw, but on drawing, required.
    - Cleanup() # Reference to clean up, required
    - IRenderer3D? Renderer3D { get; } # 3D renderer reference, can be null, required.

- Essentials.Lifecycle # The entire FUCKING LIFECYCLE
  - enum EngineMode
    - Edit # Editing
    - Play # Playing
    - Paused # Paused

  - sealed class ScriptBinding
    - object Instance # Binding to Instance
    - Action? Awake # Binding to Awake
    - Action? OnEnable # Binding to OnEnable
    - Action? Start # Binding to Start
    - Action<double>? Update # Binding to Update
    - Action<double>? LateUpdate # Binding to LateUpdate
    - Action? OnDraw # Binding to OnDraw
    - Action? OnDisable # Binding to OnDisable
    - Action? OnDestroy # Binding to OnDistroy
    - Action<IntPtr>? OnMessage # Binding to OnMessage
    - Action? Render # Binding to Render
    - Action? Cleanup # Binding to Cleanup
    - ScriptBinding(object) # Script instancing with binds to lifecycle

    - struct LifecycleInfo
      - bool HasUpdate # If Update() is defined
      - bool HasLateUpdate # If LateUpdate() is defined
      - bool HasOnDraw # If OnDraw() is defined
      - bool HasStart # If Start() is defined

    - Lifecycle
      - Tick(IScene, double, EngineMode) # Defines a tick, on every tick call Update
      - Draw(IScene, EngineMode) # Draws object to scene
      - HandleEntityCreated(Entity) # On entity created
      - HandleEntityDestroyed(Entity) # On entity destroyed
      - SetEntityEnabled(Entity, bool) # To set an entity as enabled
      - RegisterScript(Entity, object) # Registering a script upon the lifecycle

- Essentials.ScreenPlay # Scripts
  - interface IScreenPlay (Set up a script with ': IScreenPlay')
    - Start() # When script initializes
    - Cleanup() # Cleans up
    - Render() # Calls before OnDraw, but on drawing.
    - Update(double) # Calls on every frame
    - LateUpdate(double) # Calls *after* every frame
    - OnMessage(IntPtr) # Calls on every message
    - OnDraw() # Calls after Render, but after drawing.

## Angene.Common
- Common.Logger
  - enum LogLevel # Logging levels
    - Debug
    - Info
    - Warning
    - Error
    - Critical
    - Important

  - enum LoggingTarget # Logging targets for logs
    - Network
    - Engine
    - MainConstructor
    - Method
    - Class
    - Definition
    - Call
    - MainGame
    - MasterScene
    - SlaveScene
    - Package

  - Logger
    - readonly Logger Instance # Logger instance
    - StreamWriter? LogInstance # Log instance streamwriter, writes to log file.
    - bool _verbose # Verbose setting
    - Action<object, object, object, object, object> OnLog { get; set; } # Action per log

    - Init(bool) # Initializes logger, bool defines if new window is created.
    - Log(string, LoggingTarget, LogLevel, Exception, int) # Logs
    - LogDebug(string, LoggingTarget) # Log debug
    - LogInfo(string, LoggingTarget) # Log info
    - LogWarning(string, LoggingTarget) # Log warning
    - LogError(string, LoggingTarget) # Log error
    - LogCritical(string, LoggingTarget, Exception) # Log critical

    - Shutdown() # Shuts down logger

- Common.Settings
  - List<string> namespaces # Namespaces for settings
  - Dictionary<string, int> consoleSettings # Console settings (Does literally nothing)
  - Action<string, int>[] OnSettingsChanged # Action that happens when setting changed.
  - Settings() # Literally calls LoadDefaults() when instantiated.
  - LoadDefaults() # Loads setting defaults
  - string GetSetting(string) # Gets a setting, returns a string
  - SetSetting(string, object) # Sets a setting, returns nothing.

- Common.Globals
  - IRenderer : IDisposable # GDI Renderer
    - BeginFrame(int, int) # Begins frame
    - Clear(float, float, float, float) # Clears screen
    - DrawRect(float, float, float, float, uint) # Draws a rect using GDI
    - DrawText(float, float, string, uint) # Draws text using GDI
    - EndFrame() # Ends frame
  - IRenderer3D # 3D renderer
    - Cleanup()

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
conf.Transparency = Win32.WindowTransparancy.SemiTransparent; // Not required, nice touch though
conf.Width = 1280; conf.Height = 720;
window = new Window(conf);
Logger.Log("New window, yaey!", LoggingTarget.Engine);
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
At least its better than placing it in 'LocalLow\{Dev}\{Game}\Player.log' where NO ORDINARY USER WILL BE ABLE TO FIND IT.
```cs
engine = Engine.Instance;
engine.Init(true); // If true, opens a new log window

Logger.Log("Hey i'm a debug log!", LoggingTarget.MainGame); // Logs to file, logLevel is optional as so:
Logger.Log("Woah I'm an error, be scared.", LoggingTarget.Class, logLevel: LogLevel.Error);
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
- LogCritical
- LogError
- LogWarning
- LogImportant
- LogInfo
- LogDebug
This logger already pre-writes a new file to a folder called "Log", picking everything up from the engine and game stack. Debug is written here instead of window when log window instance exists.

## Windows message loop (Win32)
Please, please, please, do not forget the message loop.
The message loop is what keeps the entire lifecycle in check, as well as triggering every tick.
This is left open for the developer in case they want anything in between ticks or draw. Use the below as a template if you want:
```cs
private static void RunWindowsMessageLoop(Window window, ref double dto, ref double dtl)
{
  bool running = true;

  while (running)
  {
    while (Win32.PeekMessageW(out var msg, IntPtr.Zero, 0, 0, Win32.PM_REMOVE))
    {
      if (msg.message == Win32.WM_QUIT)
      {
        running = false;
        break;
      }

      Win32.TranslateMessage(ref msg);
      Win32.DispatchMessageW(ref msg);
    }

    if (!running) break;

    foreach (var scene in window.Scenes)
    {
      double dt = (DateTime.Now - lastFrame).TotalSeconds;
      ScriptBinding.Lifecycle.Tick(scene, dt, EngineMode.Play);
      ScriptBinding.Lifecycle.Draw(scene, EngineMode.Play);
      scene?.Render();
    }

    Thread.Sleep(16);
  }
}
```
Sure, it's a little counter-intuitive, but it leaves the lifecycle as a choice for the developer, maybe even allowing some funky shit later.
Just remember, if you detatch the tick method, no scene or script will run. Everything is reliant on ticks and OnDraw.

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
      Logger.Log($"The number is {num}.", LoggingTarget.Class);
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
Entity.AddScript<ScriptExample>();
Entity.Initialize(46); // Following example from earlier
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

  public IRenderer3D? Renderer3D => null; // Required by spec, not needed if not rendering 3D.

  internal DemoScene(Window window) // Again, not needed by spec, but useful.
  {
    _window = window;
    Instance = this;
  }

  public void Initialize()
  {
    entities = new List<Entity>();
    Logger.Log($"Running on {PlatformDetection.CurrentPlatform}", LoggingTarget.MainGame, LogLevel.Info);
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

# Conclusion
i'm really fucking tired, see yall next commit.
