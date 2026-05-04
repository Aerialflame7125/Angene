!\[Angene Logo](https://github.com/Aerialflame7125/Angene/blob/main/AngeneLogoBig.png?raw=true)

# Angene

(pronounced 'engine')
Last updated 2026/05/03

The C# library/variant of Angene. If you want to skip the entire tree for the engine, skip to the [examples.](https://github.com/Aerialflame7125/Angene/blob/main/CS/README.md#Examples)

## Angene

* Angene.Engine

  * (Settings) Engine.SettingHandlerInstanced() # Returns the settings instance, do NOT INSTANTIATE NEW SETTINGS AFTER INIT
  * List<Angene.Main.Window> OpenWindows # List of currently open windows for manipulation or reference to their instance.
  * Engine.Console # Ambiguous references to cause compiler errors. Used to prevent the developer from calling wrong functions. :omegalul:

    * Console.WriteLine(string)
    * Console.ReadLine(string)
    * Console.Write(string)
  * Engine.Window(WindowConfig)

    * Window.SetScene(IScene) # Removes all other scenes (besides essential), sets primary scene.
    * Window.AddScene(IScene) # Adds a new scene to loaded scenes
    * Window.RemoveScene(IScene) # Removes scene from loaded scenes array
    * Window.SetEngineMode(EngineMode) # Sets engine mode. 'EngineMode.Play', 'EngineMode.Edit'. (Added for engine flexibility for the actual GUI editor coming up!)
    * Window.Cleanup() # Cleans up window resources
    * Window.ProcessMessages() # Already called by lifecycle (Refer to Angene.Essentials.Lifecycle), processes message meaning and distributes to scenes.
  * Engine.Init(Bool verbose) # Verbose call refers to log window
  * Engine.Instance
* Angene.External

  * External.DiscordRichPresence

    * (partial class) DiscordRichPresence

      * DiscordRichPresence(clientId) # New RPC Instance
      * SetPresence(RichPresence) # Sets new RPC
      * Clear() # Clears RPC
      * schedule() # Schedules Cts token debounce
      * Dispose() # Clears client
* Angene.PkgHandler

  * Package

    * IReadOnlyList<ManifestEntry> Entries => \_manifest.Files;

    private Package(FileStream fs, Manifest manifest, byte\[] key,
bool manifestEncrypted, bool manifestCompressed, byte\[] manifestNonce, long manifestOffset)
{
\_fs = fs;
\_manifest = manifest;
\_key = key;
\_manifestEncrypted = manifestEncrypted;
\_manifestCompressed = manifestCompressed;
\_manifestNonce = manifestNonce;
\_manifestOffset = manifestOffset;
}

    * Package Open(string path, byte\[] key = null)
{
var fs = File.OpenRead(path);
var magic = br.ReadBytes(8);
var magicStr = Encoding.ASCII.GetString(magic);
var version = br.ReadUInt32();
var manifestLength = br.ReadInt64();
var manifestFlags = br.ReadByte();
bool manifestEncrypted = (manifestFlags \& 0x01) != 0;
bool manifestCompressed = (manifestFlags \& 0x02) != 0;
byte\[] manifestNonce = null;
long manifestOffset = fs.Position;
var manifestBytes = new byte\[manifestLength];
int toRead = (int)manifestLength;
int totalRead = 0;
return new Package(fs, manifest, key, manifestEncrypted, manifestCompressed, manifestNonce, manifestOffset);
}
    * void ExtractTo(string relativePath, string outPath)
    * Stream OpenStream(ManifestEntry entry)

    private class Manifest
{
- ManifestEntry\[] Files { get; set; }
- DateTime Created { get; set; }
}

    * class ManifestEntry
{

      * string Path { get; set; }
      * long Offset { get; set; }
      * long Length { get; set; }
      * bool Compressed { get; set; }
      * bool Encrypted { get; set; }
      * string Nonce { get; set; }
      * string Tag { get; set; }
}
}
* Angene.Platform

  * WindowConfig

    * string Title { get; set; } = "Angene Window";
    * int Width { get; set; } = 800;
    * int Height { get; set; } = 600;
    * int X { get; set; } = Win32.CW\_USEDEFAULT;
    * int Y { get; set; } = Win32.CW\_USEDEFAULT;
    * bool cTI { internal get; set; } = false;
    * string cTS { internal get; set; } = "";
    * string cTT { internal get; set; } = "";
    * Win32.WindowStyle Style { get; set; } = Win32.WindowStyle.OverlappedWindow;
    * Win32.WindowStyleEx StyleEx { get; set; } = Win32.WindowStyleEx.None;
    * Win32.WindowTransparency Transparency { get; set; } = Win32.WindowTransparency.None;
    * bool Use3D { get; set; } = false;
    * bool ShowOnCreate { get; set; } = true;
    * bool AlwaysOnTop
{
get => StyleEx.HasFlag(Win32.WindowStyleEx.Topmost);
set
{
if (value)
StyleEx |= Win32.WindowStyleEx.Topmost;
else
StyleEx \&= \~Win32.WindowStyleEx.Topmost;
}
}
    * WindowConfig Standard(string title, int width, int height)
{
return new WindowConfig
{
Title = title,
Width = width,
Height = height,
Style = Win32.WindowStyle.OverlappedWindow,
StyleEx = Win32.WindowStyleEx.None,
Transparency = Win32.WindowTransparency.None,
Use3D = false
};
}
    * WindowConfig TransparentOverlay(string title, int width, int height, bool clickThrough = true)
{
return new WindowConfig
{
Title = title,
Width = width,
Height = height,
X = 0,
Y = 0,
Style = Win32.WindowStyle.Popup,
StyleEx = Win32.WindowStyleEx.Layered | Win32.WindowStyleEx.Topmost |
(clickThrough ? Win32.WindowStyleEx.Transparent : Win32.WindowStyleEx.None),
Transparency = new Win32.WindowTransparency
{
Enabled = true,
Alpha = 255,  
ClickThrough = clickThrough
},
Use3D = false
};
}
    * WindowConfig Borderless(string title, int width, int height)
{
return new WindowConfig
{
Title = title,
Width = width,
Height = height,
Style = Win32.WindowStyle.Popup,
StyleEx = Win32.WindowStyleEx.None,
Transparency = Win32.WindowTransparency.None,
Use3D = false
};
}
    * WindowConfig Rendering3D(string title, int width, int height)
{
return new WindowConfig
{
Title = title,
Width = width,
Height = height,
Style = Win32.WindowStyle.OverlappedWindow,
StyleEx = Win32.WindowStyleEx.None,
Transparency = Win32.WindowTransparency.None,
Use3D = true
};
}

  ## Angene.Essentials

  * Essentials.Entity : IEquatable<Entity> # The ENTIRE FUCKING ENTITY

    * static int Id # Entity ID
    * int x # X axis
    * int y # Y axis
    * int z # Z axis
    * string name # Name of *this* object
    * List<Entity> childEntities # Child entities of *this* entity
    * Entity(int, int, string) # Entity object, child of scene

      * Id # Entity ID
      * x # X axis
      * y # Y axis
      * z = 0 # Z axis (Not implemented, but placeholder and not required.)
      * name # name of object
      * \_scripts # All script objects (List<object>)
      * childEntities # All child entities (List<Entity>)
      * \_parent # Parent object
      * \_enabled # If enabled
    * T AddScript<T>() where T : new() # Add a script component to lifecycle system
    * AddScript(object) # Adds a new script *instance* to hierarchy
    * RemoveScript(object) # Remove a script, does **NOT TRIGGER LIFECYCLE CALLBACKS**
    * IReadOnlyList<Object> GetScripts() # Get all scripts attached to this entity
    * T GetScriptByType<T>() # Gets script from list by type (Cannot return null, returns default(T))
    * T? GetScript<T>() where T : class # Gets script from list by specific type (Can return null)
    * SetEnabled(bool) # Sets *this* entity enabled
    * bool IsEnabled() # Check if enabled
    * AddChild(Entity) # Adds new child to hierarchy
    * RemoveChild(Entity) # Removes entity child from hierarchy
    * bool IsParent(Entity) # Check if entity is parent of this entity
    * Entity? GetParent() # Gets entity parent
    * Destroy() # Destroys entity and all associated children
    * bool Equals(Entity?) # Grabs if entity is equal to *this* entity
    * bool Equals(object?) # Grabs if object is equal to entity
    * int GetHashCode() # Grabs entity id
  * Essentials.IScene

    * interface IScene

      * Initialize() # Initializes scene, required
      * List<Entity> GetEntities() # Grabs entities from scene, required
      * OnMessage(IntPtr) # Calls on every message, required
      * Render() # Calls before OnDraw, but on drawing, required.
      * Cleanup() # Reference to clean up, required
      * IRenderer3D? Renderer3D { get; } # 3D renderer reference, can be null, required.
  * Essentials.Lifecycle # The entire FUCKING LIFECYCLE

    * enum EngineMode

      * Edit # Editing
      * Play # Playing
      * Paused # Paused
    * sealed class Lifecycle

      * object Instance # Binding to Instance
      * Action? Awake # Binding to Awake
      * Action? OnEnable # Binding to OnEnable
      * Action? Start # Binding to Start
      * Action<double>? Update # Binding to Update
      * Action<double>? LateUpdate # Binding to LateUpdate
      * Action? OnDraw # Binding to OnDraw
      * Action? OnDisable # Binding to OnDisable
      * Action? OnDestroy # Binding to OnDistroy
      * Action<IntPtr>? OnMessage # Binding to OnMessage
      * Action? Render # Binding to Render
      * Action? Cleanup # Binding to Cleanup
      * ScriptBinding(object) # Script instancing with binds to lifecycle
      * struct LifecycleInfo

        * bool HasUpdate # If Update() is defined
        * bool HasLateUpdate # If LateUpdate() is defined
        * bool HasOnDraw # If OnDraw() is defined
        * bool HasStart # If Start() is defined
      * ScriptBinding

        * Tick(IScene, double, EngineMode) # Defines a tick, on every tick call Update
        * Draw(IScene, EngineMode) # Draws object to scene
        * HandleEntityCreated(Entity) # On entity created
        * Destroy(Entity) # On entity destroyed
        * Remove(Entity) # Synonym of Destroy()
        * SetEntityEnabled(Entity, bool) # To set an entity as enabled
        * RegisterScript(Entity, object) # Registering a script upon the lifecycle
        * ShutdownEngine() # Shuts down the engine *correctly*.
  * Essentials.ScreenPlay # Scripts

    * interface IScreenPlay (Set up a script with ': IScreenPlay')

      * Start() # When script initializes
      * Cleanup() # Cleans up
      * Render() # Calls before OnDraw, but on drawing.
      * Update(double) # Calls on every frame
      * LateUpdate(double) # Calls *after* every frame
      * OnMessage(IntPtr) # Calls on every message
      * OnDraw() # Calls after Render, but after drawing.

  ## Angene.Common

  * Common.Logger

    * enum LogLevel # Logging levels

      * Debug
      * Info
      * Warning
      * Error
      * Critical
      * Important
    * enum LoggingTarget # Logging targets for logs

      * Network
      * Engine
      * MainConstructor
      * Method
      * Class
      * Definition
      * Call
      * MainGame
      * MasterScene
      * SlaveScene
      * Package
    * Logger

      * readonly Logger Instance # Logger instance
      * StreamWriter? LogInstance # Log instance streamwriter, writes to log file.
      * bool \_verbose # Verbose setting
      * Action<object, object, object, object, object> OnLog { get; set; } # Action per log
      * Init(bool) # Initializes logger, bool defines if new window is created.
      * Log(string, LoggingTarget, LogLevel, Exception, int) # Logs
      * LogDebug(string, LoggingTarget) # Log debug
      * LogInfo(string, LoggingTarget) # Log info
      * LogWarning(string, LoggingTarget) # Log warning
      * LogError(string, LoggingTarget) # Log error
      * LogCritical(string, LoggingTarget, Exception) # Log critical
      * Shutdown() # Shuts down logger
  * Common.Settings

    * List<string> namespaces # Namespaces for settings
    * Dictionary<string, object> consoleSettings # Console settings (Does literally nothing)
    * Action<string, object>\[] OnSettingsChanged # Action that happens when setting changed.
    * Settings() # Literally calls LoadDefaults() when instantiated.
    * LoadDefaults() # Loads setting defaults
    * object GetSetting(string) # Gets a setting, returns an object from setting value
    * SetSetting(string, object) # Sets a setting, returns nothing.
  * Common.Globals

    * IRenderer : IDisposable # GDI Renderer

      * BeginFrame(int, int) # Begins frame
      * Clear(float, float, float, float) # Clears screen
      * DrawRect(float, float, float, float, uint) # Draws a rect using GDI
      * DrawText(float, float, string, uint) # Draws text using GDI
      * EndFrame() # Ends frame
    * IRenderer3D # 3D renderer

      * Cleanup()

  ## Angene.Audio

  * AudioFile

    * LoadType \_loadType;
    * enum LoadType
  {
  loadOnInstantiate = 0,
  loadOnGet = 1,
  streamed = 2,
  loadOnGetThenDestroy = 3
  };
    * AudioFile(string packagePath, string path, LoadType loadType, byte\[] key = null)
    * byte\[] GetAudioBytes()
    * Stream GetAudioStream()
    * void Dispose()
  * AudioManager

    * bool IsPlaying
    * bool IsPaused
    * float Volume
    * bool Looping
    * AudioManager(AudioFile file, bool playOnLoad = true,
  bool loop = false, float volume = 1f)
    * void Play()
    * void Stop()
    * void Pause()
    * void Resume()
    * void SetVolume(float v)
    * void SetLooping(bool loop)
    * void Dispose()
  * interface IAudioPlayer : IDisposable

    * bool IsPlaying { get; }
    * bool IsPaused { get; }
    * float Volume { get; }
    * bool Looping { get; }
    * void Play();
    * void Stop();
    * void Pause();
    * void Resume();
    * void SetVolume(float volume);   // 0.0 - 1.0
    * void SetLooping(bool loop);
  * Common

    * AudioFactory

      * IAudioPlayer Create(AudioFile) # Checks loadtype if is streamed, else provides full audio bytes

  ## Angene.Graphics

  * GraphicsBackend

    * interface IGraphicsContext
  {
  IntPtr Handle { get; }
  void Clear(uint color);
  void DrawRectangle(int x, int y, int width, int height, uint color);
  void DrawText(string text, int x, int y, uint color);
  void Present(IntPtr windowHandle);
  void Cleanup();
  byte\[] GetRawPixels();
  }
    * class GdiGraphicsContext : IGraphicsContext

      * IntPtr Handle => memDc;
      * GdiGraphicsContext(IntPtr hwnd, int w, int h)
      * void Clear(uint color)
      * void DrawRectangle(int x, int y, int w, int h, uint color)
      * void DrawText(string text, int x, int y, uint color)
      * void Present(IntPtr hwnd)
      * byte\[] GetRawPixels() { return null; }
    * class WSGraphicsContext : IGraphicsContext

      * IntPtr Handle => memDc;
      * WSGraphicsContext(string hwnd, int w, int h)
      * void Clear(uint color)
      * void DrawRectangle(int x, int y, int w, int h, uint color)
      * void DrawText(string text, int x, int y, uint color)
      * byte\[] GetRawPixels()
    * class GraphicsContextFactory

      * IGraphicsContext Create(IntPtr windowHandle, int width, int height)

  ## Angene.Windows

  * Angene.Windows.Gdi32

    * SRCCOPY = 0x00CC0020;
    * CreateCompatibleDC(IntPtr hdc);
    * CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
    * SelectObject(IntPtr hdc, IntPtr hObject);
    * DeleteObject(IntPtr hObject);
    * DeleteDC(IntPtr hdc);
    * BitBlt(
  IntPtr hdcDest,
  int nXDest,
  int nYDest,
  int nWidth,
  int nHeight,
  IntPtr hdcSrc,
  int nXSrc,
  int nYSrc,
  uint dwRop);
    * CreateSolidBrush(uint crColor);
    * GetStockObject(int fnObject);
    * Rectangle(IntPtr hdc, int left, int top, int right, int bottom);
    * SetBkMode(IntPtr hdc, int mode);
    * SetTextColor(IntPtr hdc, uint color);
    * TextOutW(IntPtr hdc, int nXStart, int nYStart, string lpString, int cchString);
    * BITMAPINFOHEADER
  {
  uint biSize;
  int biWidth;
  int biHeight;
  ushort biPlanes;
  ushort biBitCount;
  uint biCompression;
  uint biSizeImage;
  int biXPelsPerMeter;
  int biYPelsPerMeter;
  uint biClrUsed;
  uint biClrImportant;
  }
    * BITMAPINFO
  {
  BITMAPINFOHEADER bmiHeader;
  uint bmiColors; // Just enough for the header
  }
    * GetDIBits(IntPtr hdc, IntPtr hbmp, uint uStartScan, uint cScanLines, \[Out] byte\[] lpvBits, ref BITMAPINFO lpbi, uint uUsage);
  * Angene.Windows.Win32

    * enum WindowStyle : uint
  {
  Overlapped = 0x00000000,
  Popup = 0x80000000,
  Child = 0x40000000,
  Minimize = 0x20000000,
  Visible = 0x10000000,
  Disabled = 0x08000000,
  ClipSiblings = 0x04000000,
  ClipChildren = 0x02000000,
  Maximize = 0x01000000,
  Caption = 0x00C00000,
  Border = 0x00800000,
  DialogFrame = 0x00400000,
  VScroll = 0x00200000,
  HScroll = 0x00100000,
  SysMenu = 0x00080000,
  ThickFrame = 0x00040000,
  Group = 0x00020000,
  TabStop = 0x00010000,
  MinimizeBox = 0x00020000,
  MaximizeBox = 0x00010000,

      OverlappedWindow = Overlapped | Caption | SysMenu | ThickFrame | MinimizeBox | MaximizeBox,
  PopupWindow = Popup | Border | SysMenu
  }

    * enum WindowStyleEx : uint
  {
  None = 0x00000000,
  DlgModalFrame = 0x00000001,
  NoParentNotify = 0x00000004,
  Topmost = 0x00000008,
  AcceptFiles = 0x00000010,
  Transparent = 0x00000020,
  MdiChild = 0x00000040,
  ToolWindow = 0x00000080,
  WindowEdge = 0x00000100,
  ClientEdge = 0x00000200,
  ContextHelp = 0x00000400,
  Right = 0x00001000,
  Left = 0x00000000,
  RtlReading = 0x00002000,
  LtrReading = 0x00000000,
  LeftScrollBar = 0x00004000,
  RightScrollBar = 0x00000000,
  ControlParent = 0x00010000,
  StaticEdge = 0x00020000,
  AppWindow = 0x00040000,
  Layered = 0x00080000,
  NoInheritLayout = 0x00100000,
  NoRedirectionBitmap = 0x00200000,
  LayoutRtl = 0x00400000,
  Composited = 0x02000000,
  NoActivate = 0x08000000,

      OverlappedWindow = WindowEdge | ClientEdge,
  PaletteWindow = WindowEdge | ToolWindow | Topmost
  }

    * struct WindowTransparency
  {

      * bool Enabled;
      * byte Alpha;
      * bool ClickThrough;
      * WindowTransparency None => new WindowTransparency { Enabled = false, Alpha = 255, ClickThrough = false };
      * WindowTransparency Opaque => new WindowTransparency { Enabled = true, Alpha = 255, ClickThrough = false };
      * WindowTransparency SemiTransparent => new WindowTransparency { Enabled = true, Alpha = 128, ClickThrough = false };
      * WindowTransparency FullyTransparent => new WindowTransparency { Enabled = true, Alpha = 0, ClickThrough = true };
  }
    * const uint GR\_GDIOBJECTS = 0;
    * const int PM\_REMOVE = 0x0001;
    * const uint WM\_CLOSE = 0x0010;
    * const uint WM\_DESTROY = 0x0002;
    * const uint WM\_ERASEBKGND = 0x0014;
    * const uint WM\_QUIT = 0x0012;
    * const uint WS\_OVERLAPPEDWINDOW = 0x00CF0000;
    * const int CW\_USEDEFAULT = unchecked((int)0x80000000);
    * const int SW\_SHOW = 5;
    * delegate IntPtr WndProcDelegate(
  IntPtr hWnd,
  uint msg,
  IntPtr wParam,
  IntPtr lParam
  );
    * const uint IMAGE\_ICON = 1;
    * const uint LR\_DEFAULTSIZE = 0x00000040;
    * const uint LR\_LOADFROMFILE = 0x00000010;
    * const uint WM\_SETICON = 0x0080;
    * const int ICON\_SMALL = 0;
    * const int ICON\_BIG = 1;
    * IntPtr LoadImage(
  IntPtr hInst,
  string lpszName,
  uint uType,
  int cxDesired,
  int cyDesired,
  uint fuLoad
  );
    * IntPtr SendMessage(
  IntPtr hWnd,
  uint Msg,
  IntPtr wParam,
  IntPtr lParam
  );
    * IntPtr CreateIconFromResourceEx(
  IntPtr presbits,
  uint dwResSize,
  bool fIcon,
  uint dwVer,
  int cxDesired,
  int cyDesired,
  uint Flags
  );
    * const uint LR\_DEFAULTCOLOR = 0x00000000;
    * bool DestroyIcon(IntPtr hIcon);
    * struct WNDCLASSEX
  {

      * uint cbSize;
      * uint style;
      * WndProcDelegate lpfnWndProc;
      * int cbClsExtra;
      * int cbWndExtra;
      * IntPtr hInstance;
      * IntPtr hIcon;
      * IntPtr hCursor;
      * IntPtr hbrBackground;
      * string lpszMenuName;
      * string lpszClassName;
      * IntPtr hIconSm;
  }
    * struct MSG
  {

      * IntPtr hwnd;
      * uint message;
      * IntPtr wParam;
      * IntPtr lParam;
      * uint time;
      * int pt\_x;
      * int pt\_y;
  }
    * uint GetGuiResources(IntPtr hProcess, uint uiFlags);
    * IntPtr GetDC(IntPtr hWnd);
    * int ReleaseDC(IntPtr hWnd, IntPtr hDC);
    * IntPtr CreateWindowExW(
  uint dwExStyle,
  string lpClassName,
  string lpWindowName,
  uint dwStyle,
  int X,
  int Y,
  int nWidth,
  int nHeight,
  IntPtr hWndParent,
  IntPtr hMenu,
  IntPtr hInstance,
  IntPtr lpParam
  );
    * bool PeekMessageW(
  out MSG lpMsg,
  IntPtr hWnd,
  uint wMsgFilterMin,
  uint wMsgFilterMax,
  int wRemoveMsg
  );
    * bool TranslateMessage(ref MSG lpMsg);
    * IntPtr DispatchMessageW(ref MSG lpMsg);
    * IntPtr DefWindowProcW(
  IntPtr hWnd,
  uint message,
  IntPtr wParam,
  IntPtr lParam
  );
    * IntPtr BeginPaint(IntPtr hWnd, out PAINTSTRUCT lpPaint);
    * bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT lpPaint);
    * bool DestroyWindow(IntPtr hWnd);
    * void PostQuitMessage(int nExitCode);
    * IntPtr LoadCursorW(IntPtr hInstance, IntPtr lpCursorName);
    * ushort RegisterClassExW(ref WNDCLASSEX lpwcx);
    * bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
    * bool ShowWindow(IntPtr hWnd, int nCmdShow);
    * bool UpdateWindow(IntPtr hWnd);
    * struct PAINTSTRUCT
  {

      * IntPtr hdc;
      * bool fErase;
      * RECT rcPaint;
      * bool fRestore;
      * bool fIncUpdate;
      * byte\[] rgbReserved;
  }
    * struct RECT
  {

      * int left;
      * int top;
      * int right;
      * int bottom;
  }
    * const uint WS\_POPUP = 0x80000000;
    * const uint WS\_EX\_LAYERED = 0x00080000;
    * const uint WS\_EX\_TRANSPARENT = 0x00000020;
    * const uint WS\_EX\_TOPMOST = 0x00000008;
    * const int LWA\_COLORKEY = 0x1;
    * const int LWA\_ALPHA = 0x2;
    * const int GWL\_EXSTYLE = -20;
    * bool SetLayeredWindowAttributes(
  IntPtr hwnd,
  uint crKey,
  byte bAlpha,
  uint dwFlags
  );
    * int GetWindowLong(IntPtr hWnd, int nIndex);
    * int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
  * Angene.Windows.Win32Messages (WM, EM, not a global namespace.)

    * enum WM : uint
  {
  NULL            = 0x0000,
  CREATE          = 0x0001,
  DESTROY         = 0x0002,
  MOVE            = 0x0003,
  SIZE            = 0x0005,
  SETFOCUS        = 0x0007,
  KILLFOCUS       = 0x0008,
  PAINT           = 0x000F,
  CLOSE           = 0x0010,
  QUIT            = 0x0012,
  ERASEBKGND      = 0x0014,

      KEYDOWN         = 0x0100,
  KEYUP           = 0x0101,
  CHAR            = 0x0102,

      MOUSEMOVE       = 0x0200,
  LBUTTONDOWN     = 0x0201,
  LBUTTONUP       = 0x0202,
  RBUTTONDOWN     = 0x0204,
  RBUTTONUP       = 0x0205,
  MOUSEWHEEL      = 0x020A,

      ENTERSIZEMOVE   = 0x0231,
  EXITSIZEMOVE    = 0x0232,
  }

    * enum EM : uint
  {
  GETSEL          = 0x00B0,
  SETSEL          = 0x00B1,
  GETRECT         = 0x00B2,
  SETRECT         = 0x00B3,
  REPLACESEL      = 0x00C2,
  GETLINE         = 0x00C4,
  }
    * class WS
  {

      * const uint OVERLAPPED       = 0x00000000;
      * const uint POPUP            = 0x80000000;
      * const uint CHILD            = 0x40000000;
      * const uint VISIBLE          = 0x10000000;
      * const uint DISABLED         = 0x08000000;
      * const uint CLIPSIBLINGS     = 0x04000000;
      * const uint CLIPCHILDREN     = 0x02000000;
      * const uint SYSMENU          = 0x00080000;
      * const uint THICKFRAME       = 0x00040000;
  }
    * class WS\_EX
  {

      * const uint TOPMOST           = 0x00000008;
      * const uint TOOLWINDOW        = 0x00000080;
      * const uint APPWINDOW         = 0x00040000;
      * const uint LAYERED           = 0x00080000;
      * const uint NOACTIVATE        = 0x08000000;
  }
    * class SWP
  {

      * const uint NOSIZE        = 0x0001;
      * const uint NOMOVE        = 0x0002;
      * const uint NOZORDER      = 0x0004;
      * const uint NOACTIVATE    = 0x0010;
      * const uint SHOWWINDOW    = 0x0040;
  }

  ## Angene.Math

  * Defs

    * interface IComputeBackend : IDisposable
  {
  IComputeJob<TIn, TOut> CreateJob<TIn, TOut>(string shaderSource, int maxElements)
  where TIn : unmanaged
  where TOut : unmanaged;

      void Flush();

      }

    * interface IComputeJob<TInput, TOutput> : IDisposable
  where TInput : unmanaged
  where TOutput : unmanaged
  {
  void Upload(TInput\[] data);
  void Dispatch();
  TOutput\[] Collect();   // Blocks until done — GPU readback
  bool IsComplete { get; }
  }
  * GPU

    * Math

      * int GpuThreshold { get; set; } = 512; // below this, falls back to CPU
      * Math(IComputeBackend backend)
      * Vec2\[] Add(Vec2\[] a, Vec2\[] b)
      * Vec2\[] Scale(Vec2\[] vectors, float scalar)
      * Vec2\[] Normalize(Vec2\[] vectors)
      * float\[] Dot(Vec2\[] a, Vec2\[] b)
      * float\[] Length(Vec2\[] vectors)
      * Vec2\[] Lerp(Vec2\[] a, Vec2\[] b, float t)
      * Vec2\[] Lerp(Vec2\[] a, Vec2\[] b, float\[] t)
      * Vec3\[] Add(Vec3\[] a, Vec3\[] b)
      * Vec3\[] Cross(Vec3\[] a, Vec3\[] b)
      * Vec3\[] Normalize(Vec3\[] vectors)
      * float\[] Dot(Vec3\[] a, Vec3\[] b)
      * Vec2\[] Transform(Matrix3x3 matrix, Vec2\[] points)
      * Matrix3x3\[] Multiply(Matrix3x3\[] a, Matrix3x3\[] b)
      * float\[] Clamp(float\[] values, float min, float max)
      * float\[] Lerp(float\[] a, float\[] b, float t)
      * float\[] Remap(float\[] values, float inMin, float inMax, float outMin, float outMax)
      * float\[] Sqrt(float\[] values)
      * float\[] Abs(float\[] values)
      * float Sum(float\[] values)
      * float Min(float\[] values)
      * float Max(float\[] values)
      * Vec2 Sum(Vec2\[] vectors)
      * Vec2 Average(Vec2\[] vectors)
  * Interpolation

    * const float PI = MathF.PI;
    * const float Deg2Rad = MathF.PI / 180f;
    * const float Rad2Deg = 180f / MathF.PI;
    * static float Clamp(float v, float min, float max)
    * static float Clamp01(float v)
    * static float Remap(float v, float inMin, float inMax, float outMin, float outMax)
    * static float Lerp(float a, float b, float t)
    * static float LerpUnclamped(float a, float b, float t)
    * static float InverseLerp(float a, float b, float v)
    * static float SmoothStep(float a, float b, float t)
    * static float SmootherStep(float a, float b, float t)
    * static float MoveTowards(float current, float target, float maxDelta)
    * static float SmoothDamp(float current, float target, ref float velocity,
  float smoothTime, double dt)
    * static float DeltaAngle(float from, float to)
    * static float LerpAngle(float a, float b, float t)
    * static class Ease
  {

      * static float InQuad(float t)
      * static float OutQuad(float t)
      * static float InOutQuad(float t)
      * static float InCubic(float t)
      * static float OutCubic(float t)
      * static float InOutCubic(float t)
      * static float InBack(float t)
      * static float InBounce(float t)
      * static float InElastic(float t)
      * static float OutBack(float t)
      * static float OutBounce(float t)
      * static float OutElastic(float t)
  }
  * Vectors

    * struct Vec2(float x = 0, float y = 0)
  {

      * float X = x, Y = y;
      * static Vec2 Zero
      * static Vec2 One
      * static Vec2 Up
      * static Vec2 Down
      * static Vec2 Left
      * static Vec2 Right
      * float Length
      * float LengthSquared
      * Vec2 Normalized
      * static float Dot(Vec2 a, Vec2 b)
      * static float Distance(Vec2 a, Vec2 b)
      * static Vec2 Lerp(Vec2 a, Vec2 b, float t)
      * static Vec2 Reflect(Vec2 v, Vec2 normal)
      * static Vec2 operator +(Vec2 a, Vec2 b)
      * static Vec2 operator -(Vec2 a, Vec2 b)
      * static Vec2 operator \*(Vec2 v, float s)
      * static Vec2 operator \*(float s, Vec2 v)
      * static Vec2 operator /(Vec2 v, float s)
  }
    * struct Vec3(float x = 0, float y = 0, float z = 0)
  {

      * float X = x, Y = y, Z = z;
      * float Length
      * Vec3 Normalized
      * static float Dot(Vec3 a, Vec3 b)
      * static Vec3 Cross(Vec3 a, Vec3 b)
      * static Vec3 Lerp(Vec3 a, Vec3 b, float t)
      * static Vec3 operator +(Vec3 a, Vec3 b)
      * static Vec3 operator -(Vec3 a, Vec3 b)
      * static Vec3 operator \*(Vec3 v, float s)
      * static Vec3 operator /(Vec3 v, float s)
  }
    * struct Rect(float x = 0, float y = 0, float width = 0, float height = 0)
  {

      * float X = x, Y = y, Width = width, Height = height;
      * float Left
      * float Right
      * float Top
      * float Bottom
      * Vec2 Center
      * bool Contains(Vec2 point)
      * bool Intersects(Rect other)
      * Rect Expand(float amount)
  }
    * struct Matrix3x3
  {

      * float M00, M01, M02;
      * float M10, M11, M12;
      * float M20, M21, M22;
      * static Matrix3x3 Identity
      * static Matrix3x3 Translation(float tx, float ty)
      * static Matrix3x3 Rotation(float radians)
      * static Matrix3x3 Scale(float sx, float sy)
      * static Matrix3x3 operator \*(Matrix3x3 a, Matrix3x3 b)
      * static Vec2 operator \*(Matrix3x3 m, Vec2 v)
  }
  * Rand

    * static void SetSeed(int seed)
    * static float Value
    * static float Range(float min, float max)
    * static int Range(int min, int max)
    * static Vec2 InsideUnitCircle
  {
  get
  {
  Vec2 v;
  do { v = new Vec2(Range(-1f, 1f), Range(-1f, 1f)); }
  while (v.LengthSquared > 1f);
  return v;
  }
  }
    * static Vec2 OnUnitCircle
  {
  get
  {
  float angle = Range(0f, Mathf.PI \* 2f);
  return new Vec2(MathF.Cos(angle), MathF.Sin(angle));
  }
  }
    * static bool Chance(float probability)
    * static T Pick<T>(IList<T> items)
    * static void Shuffle<T>(IList<T> items)

  ## Angene.Input
    * KeyDetection
      - List<Entity> Instances # Collection of all entities that have KeyDetection instances on them.

      - void Register() # Takes default ManagementScene object entities of all open windows and registers a new KeyDetection Entity on them. NOTICE: This method is not recommended for performance. It WILL iterate through all open windows and ManagementScene objects.

      - void Register(Entity entity) # Takes in entity that the user specifies and registers a new KeyDetection object on it.

      - void Register(ManagementScene managementScene) # Registers KeyDetection on the default entity of the provided management scene. Please refer to KeyDetection.cs for more info.

      - static bool IsKeyDown(object key) # Checks if the specified key is currently held down. Requires KeyDetection to be registered first.

      - void Deregister() # Nullifies script instance, deregistering it from lifetime.

      - static HashSet<object> GetDownKeys # Returns a list of down keys
    * WinInput.Keys
      - class Key
        - static object TryInt(int n)

        - static object TryNInt(nint n)

        - static object TryByte(byte keyCode)
      - struct Keys
        - enum IKeyCodeASCII : byte
            a = 0x41,
            b = 0x42,
            c = 0x43,
            d = 0x44,
            e = 0x45,
            f = 0x46,
            g = 0x47,
            h = 0x48,
            i = 0x49,
            j = 0x4A,
            k = 0x4B,
            l = 0x4C,
            m = 0x4D,
            n = 0x4E,
            o = 0x4F,
            p = 0x50,
            q = 0x51,
            r = 0x52,
            s = 0x53,
            t = 0x54,
            u = 0x55,
            v = 0x56,
            w = 0x57,
            x = 0x58,
            y = 0x59,
            z = 0x5A,
        - enum IKeyCodeNum : byte
            d0 = 0x30,
            d1 = 0x31,
            d2 = 0x32,
            d3 = 0x33,
            d4 = 0x34,
            d5 = 0x35,
            d6 = 0x36,
            d7 = 0x37,
            d8 = 0x38,
            d9 = 0x39,
        - enum IKeyCodeFunc : byte
            f1 = 0x70,
            f2 = 0x71,
            f3 = 0x72,
            f4 = 0x73,
            f5 = 0x74,
            f6 = 0x75,
            f7 = 0x76,
            f8 = 0x77,
            f9 = 0x78,
            f10 = 0x79,
            f11 = 0x7A,
            f12 = 0x7B,
            f13 = 0x7C,
            f14 = 0x7D,
            f15 = 0x7E,
            f16 = 0x7F,
            f17 = 0x80,
            f18 = 0x81,
            f19 = 0x82,
            f20 = 0x83,
            f21 = 0x84,
            f22 = 0x85,
            f23 = 0x86,
            f24 = 0x87,
        - enum IKeyCodeMod : byte
            Shift = 0x10,
            LShift = 0xA0,
            RShift = 0xA1,
            Ctrl = 0x11,
            LCtrl = 0xA2,
            RCtrl = 0xA3,
            Alt = 0x12,
            LAlt = 0xA4,
            RAlt = 0xA5,
            End = 0x23,
            Escape = 0x1B,
            LWin = 0x5B,
            RWin = 0x5C,
            Space = 0x20,
        - enum IKeyCodeSpecial : byte
            None = 0,
            Cancel = 0x03,
            Apps = 0x5D,
            Help = 0x2F,
            Home = 0x24,
            Zoom = 0xFB,
            CrSel = 0xF3,
            ExSel = 0xF4,
            PA1 = 0xFD,
            IMEConvert = 0x1C,
            IMENonconvert = 0x1D,
            IMEAccept = 0x1E,
            IMEModeChange = 0x1F,
            ProcessKey = 0xE5,
            Packet = 0xE7,
            Attn = 0xF6,
            EraseEof = 0xF5,
        - enum IKeyCodeArrow : byte
            Left = 0x25,
            Up = 0x26,
            Right = 0x27,
            Down = 0x28,
        - enum IKeyCodeNumPad : byte
            NumLock = 0x90,
            Divide = 0x6F,
            Multiply = 0x6A,
            Subtract = 0x6D,
            Add = 0x6B,
            Decimal = 0x6E,
            np0 = 0x60,
            np1 = 0x61,
            np2 = 0x62,
            np3 = 0x63,
            np4 = 0x64,
            np5 = 0x65,
            np6 = 0x66,
            np7 = 0x67,
            np8 = 0x68,
            np9 = 0x69,
        - enum IKeyCodeGamePad : byte
            a = 0xC3,
            b = 0xC4,
            x = 0xC5,
            y = 0xC6,
            leftShoulder = 0xC7,
            rightShoulder = 0xC8,
            leftThumb = 0xC9,
            rightThumb = 0xCA,
            dpadUp = 0xCB,
            dpadDown = 0xCC,
            dpadLeft = 0xCD,
            dpadRight = 0xCE,
            menu = 0xCF,
            view = 0xD0,
            lThumbUp = 0xD1,
            lThumbDown = 0xD2,
            lThumbRight = 0xD3,
            lThumbLeft = 0xD4,
            rThumbUp = 0xD5,
            rThumbDown = 0xD6,
            rThumbRight = 0xD7,
            rThumbLeft = 0xD8,
        - enum IKeyCodeMouse : byte
            LMouse = 0x01,
            RMouse = 0x02,
            XButton1 = 0x05,
            XButton2 = 0x06,
        - enum IKeyCodeOEM : byte // Keys labeled as OEM
            OEM1 = 0xBA,
            OEM2 = 0xBF,
            OEM3 = 0xC0,
            OEM4 = 0xDB,
            OEM5 = 0xDC,
            OEM6 = 0xDD,
            OEM7 = 0xDE,
            OEM8 = 0xDF,
            OEM102 = 0xE2,
            OEMPlus = 0xBB,
            OEMComma = 0xBC,
            OEMMinus = 0xBD,
            OEMPeriod = 0xBE,
            OEMClear = 0xFE,
        - enum IKeyCodeBrowser : byte
            BrowserBack = 0xA6,
            BrowserForward = 0xA7,
            BrowserRefresh = 0xA8,
            BrowserStop = 0xA9,
            BrowserSearch = 0xAA,
            BrowserFavorites = 0xAB,
            BrowserHome = 0xAC,
        - enum IKeyCodeMedia : byte
            Play = 0xFA,
            VolumeMute = 0xAD,
            VolumeDown = 0xAE,
            VolumeUp = 0xAF,
            MediaNextTrack = 0xB0,
            MediaPrevTrack = 0xB1,
            MediaStop = 0xB2,
            MediaPlayPause = 0xB3,



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
At least its better than placing it in 'LocalLow{Dev}{Game}\\Player.log' where NO ORDINARY USER WILL BE ABLE TO FIND IT.

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
private static void RunWindowsMessageLoop(Window window, ref double dto, ref double dtl)
{
  bool running = true;

  while (running)
  {
    while (Win32.PeekMessageW(out var msg, IntPtr.Zero, 0, 0, Win32.PM\_REMOVE))
    {
      if (msg.message == Win32.WM\_QUIT)
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
      Lifecycle.ScriptBinding.Tick(scene, dt, EngineMode.Play);
      Lifecycle.ScriptBinding.Draw(scene, EngineMode.Play);
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
  private string \_packagePath = Path.Combine(AppContext.BaseDirectory, "game.angpkg");
  if (File.Exists(\_packagePath))
  {
    \_package = Angene.Main.Package.Open(\_packagePath, key: null); // Key is used if encrypted with a key at package time.
    foreach (var e in \_package.Entries)
      \_entryNames.Add(e.Path);

    // Use known path
    var target = \_entryNames.FirstOrDefault(p => p.EndsWith("text/hello.txt", StringComparison.OrdinalIgnoreCase))
                ?? \_entryNames.FirstOrDefault();

    if (target != null)
    {
      var entry = \_package.Entries.FirstOrDefault(x => string.Equals(x.Path, target, StringComparison.OrdinalIgnoreCase));
      if (entry != null)
      {
        using var s = \_package.OpenStream(entry);
        using var sr = new StreamReader(s, Encoding.UTF8);
        \_loadedText = sr.ReadToEnd();
      };
    }
    else
    {
      \_loadedText = "Package opened, but no entries found.";
    }
  }
  else
  {
    \_loadedText = $"Package not found at '{\_packagePath}'.";
  }
}
catch (Exception ex)
{
    // Keep the scene functional; show error text
    \_loadedText = $"Error opening package: {ex.Message}";
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
  public void Initialize(int \_num)
  {
    num = \_num;
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
  public Window \_window;

  public IRenderer3D? Renderer3D => null; // Required by spec, not needed if not rendering 3D.

  internal DemoScene(Window window) // Again, not needed by spec, but useful.
  {
    \_window = window;
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
    if (msg.message == Win32.WM\_CLOSE)
    {
      Angene.Main.Console.WriteLine("\[PackageTest] Received WM\_CLOSE");
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
You (the developer) have a plethora of options for the window, and I honestly recommend that you actually read the (C# spec for yourself)\[https://github.com/Aerialflame7125/Angene/blob/main/CS/Angene/Angene.Main/Platform/WindowConfig.cs].
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
    Assets = new Assets {SmallImageKey = "angene\_logo", SmallImageText = $"Running on Angene"}
  };
  private DiscordRichPresence? \_rpc = new ("1467308284322254862");
  public void Start()
  {
    presence.State = "woah demo rpc!?!?!?";
    presence.Assets.LargeImageKey = "g\_khlbfbmaec9sq";
    presence.Assets.LargeImageText = "SHOT DEAD IN THE BRONX";
    presence.Buttons = new\[]
      {
      new Button
      {
        Label = "join me twin",
        Url = "https://amretar.com"
      }
    };
    \_rpc.SetPresence(presence);
  }
  void Cleanup()
  {
    \_rpc?.Dispose();
    \_rpc = null;
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
Logger.Log("Window created successfully", LoggingTarget.Engine);
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
<PropertyGroup Condition="'$(OS)' == 'Windows\_NT'">
	<DefineConstants>WINDOWS</DefineConstants>
</PropertyGroup>
<PropertyGroup Condition="'$(OS)' != 'Windows\_NT'">
	<DefineConstants>LINUX</DefineConstants>
</PropertyGroup>
```

  This literally is the simplest you need if you want to at least compile.
Next the entry point:

  ## Entry point

  The engine's host cpp file has a very specific entry point definition as well:

  ```cs
\[UnmanagedCallersOnly]
public static int Main(IntPtr args, int argc)
{
    bool verbose = false;
    try
    {
        // Parse command-line arguments if provided
        string\[] argArray = Array.Empty<string>();
        if (args != IntPtr.Zero \&\& argc > 0)
        {
            argArray = new string\[argc];
            unsafe
            {
                IntPtr\* pArgs = (IntPtr\*)args;
                for (int i = 0; i < argc; i++)
                {
                    argArray\[i] = Marshal.PtrToStringUni(pArgs\[i]) ?? string.Empty;
                }
            }
            foreach (string arg in argArray)
            {
                if (arg.Length > 0 \&\& arg == "--verbose" \&\& !verbose)
                {
                    verbose = true;
                }
            }
            Logger.Log($"Arguments received ({argc}):", LoggingTarget.MainConstructor);
            for (int i = 0; i < argArray.Length; i++)
            {
                Logger.Log($"  \[{i}] {argArray\[i]}", LoggingTarget.MainConstructor);
            }
            Logger.Log("", LoggingTarget.MainConstructor);
        }

        Logger.Log("Calling RunGame...", LoggingTarget.MainConstructor);
        RunGame(verbose);

        return 0;
    }
    catch (Exception ex)
    {
        Logger.Log($"\\nFATAL EXCEPTION in Main:", LoggingTarget.MainConstructor, logLevel: LogLevel.Critical, exception: ex);
        return 1; // Error
    }
}
```

  Again just an example, but the arguments are as follows. If a log directory is not created after launching the host, something is incorrect with the entry point or the engine hasn't initialized.

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

  Then create an audio manager, this is handled in its own thread to save the original game threads.

  ```cs
var audioManager = new AudioManager(
  file: audio,
  playOnLoad: true, // Play the audio once the file is loaded
  loop: true, // Your choice of looping the audio when it finishes
  volume: 0.3f // A float value between 0 and 1, no higher or lower.
);
```

  This creates a new AudioManager thread, able to be called.

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
byte\[] key; //just set your key later
// ...

var file = new AudioFile(
  packagePath: "assets\_enc.angpkg",
  path: "audio/music/theme.wav",
  loadType: AudioFile.LoadType.loadOnInstantiate,
  key: key
);
// then do the same as usual
```

  ## Math

  This entire math library includes a fuck ton
Vectors, Interpolation, randomisation, and gpu-acceleration.

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
Vec2 moved = translate \* new Vec2(5f, 3f);     // (15, 23)
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

// Easing — all take t in \[0,1]
float eased = Mathf.Ease.OutBack(0.5f);   // overshoots past 1
float bounce = Mathf.Ease.OutBounce(0.5f);
```

  ### Randomisation (Rand)

  ```cs
Rand.SetSeed(42); // deterministic from here on

float f   = Rand.Value;               // \[0, 1)
float r   = Rand.Range(-5f, 5f);
int   i   = Rand.Range(0, 10);
Vec2  inC = Rand.InsideUnitCircle;    // |v| ≤ 1
Vec2  onC = Rand.OnUnitCircle;        // |v| ≈ 1
bool  hit = Rand.Chance(0.3f);        // \~30% true

string picked = Rand.Pick(new\[] { "alpha", "beta", "gamma" });

var list = new List { 1, 2, 3, 4, 5 };
Rand.Shuffle(list);
```

  ### GpuMath (bulk ops, CPU fallback below threshold)

  ```cs
// Requires an IComputeBackend — pass a real D3D11/Vulkan backend for GPU dispatch.
// Arrays smaller than GpuMath.GpuThreshold (default 512) fall back to CPU automatically.
var gpu = new Angene.Math.GPU.Math(myComputeBackend);

Vec2\[] a = /\* ... \*/;
Vec2\[] b = /\* ... \*/;

Vec2\[]  added    = gpu.Add(a, b);
Vec2\[]  normed   = gpu.Normalize(a);
float\[] dots     = gpu.Dot(a, b);
Vec2\[]  lerped   = gpu.Lerp(a, b, 0.5f);     // uniform t
Vec2\[]  lerped2  = gpu.Lerp(a, b, tArray);   // per-element t

float\[] clamped  = gpu.Clamp(values, 0f, 1f);
float\[] remapped = gpu.Remap(values, 0f, 100f, 0f, 1f);
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

# QnA

  ## Have you vibecoded any part of this engine?

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

    ### Angene.Essentials

* Angene.Entity (Partial, logic that is listed carries from human implementation.)
* Angene.IScene (Partial, original logic and implementations carry from Python and older versions. See commit history.)
* Angene.Lifecycle
* Angene.ScreenPlay (Partial, format follows deprecated python version for flexibility, logic roughly sketched by hand.)

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
* Platform

  * X11Native
  * Self-explanatory. Yet to remove it at the time of writing (2026,03,07), considering this is windows-first.
* Crypto

  * Literally just a conversion wrapper. Too lazy to change all of the references, so why not make it yourself to shut the console up!

    ### Angene.Graphics

* Graphics

  * All of the above

    * Not going to rant about microsoft implementations, just that me personally, I have no idea how D3D works, nor does the documentation really help me in the case of using C#.
    * Although I do state all of the above, GDI is the only one that does not adhere to this. The implementation carries from Python, and is human written (for the most part, conversion was AI.)

    ### Angene.Windows

* Kernel32
* Gdi32
* Win32
* Win32Messages
* All of the listed libraries is vibe coded. This primarilly consists of Win32 messages and headers pertaining to specific windows implementations. Microsoft documentation is correct and actually helped a lot when writing python implementations, but I will refer you to the [definitions file](https://github.com/Aerialflame7125/Angene/blob/main/Python/Angene/Main/definitions.py) written in python, and you tell me if you want to implement that in C#.
* Most of this is also at the hands of bad implementations, very generously providing a great help when it comes to conversions to other languages :thumbs\_up: (sarcasm.)

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

