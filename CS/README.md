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
