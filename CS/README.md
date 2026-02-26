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
  - enum WindowStyle : uint
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

  - enum WindowStyleEx : uint
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

  - struct WindowTransparency
  {
      - bool Enabled;
      - byte Alpha;
      - bool ClickThrough;

      - WindowTransparency None => new WindowTransparency { Enabled = false, Alpha = 255, ClickThrough = false };
      - WindowTransparency Opaque => new WindowTransparency { Enabled = true, Alpha = 255, ClickThrough = false };
      - WindowTransparency SemiTransparent => new WindowTransparency { Enabled = true, Alpha = 128, ClickThrough = false };
      - WindowTransparency FullyTransparent => new WindowTransparency { Enabled = true, Alpha = 0, ClickThrough = true };
  }

  - const uint GR_GDIOBJECTS = 0;
  - const int PM_REMOVE = 0x0001;

  - const uint WM_CLOSE = 0x0010;
  - const uint WM_DESTROY = 0x0002;
  - const uint WM_ERASEBKGND = 0x0014;
  - const uint WM_QUIT = 0x0012;

  - const uint WS_OVERLAPPEDWINDOW = 0x00CF0000;
  - const int CW_USEDEFAULT = unchecked((int)0x80000000);
  - const int SW_SHOW = 5;

  - delegate IntPtr WndProcDelegate(
      IntPtr hWnd,
      uint msg,
      IntPtr wParam,
      IntPtr lParam
  );

  - const uint IMAGE_ICON = 1;
  - const uint LR_DEFAULTSIZE = 0x00000040;
  - const uint LR_LOADFROMFILE = 0x00000010;
  - const uint WM_SETICON = 0x0080;
  - const int ICON_SMALL = 0;
  - const int ICON_BIG = 1;

  - IntPtr LoadImage(
      IntPtr hInst,
      string lpszName,
      uint uType,
      int cxDesired,
      int cyDesired,
      uint fuLoad
  );

  - IntPtr SendMessage(
      IntPtr hWnd,
      uint Msg,
      IntPtr wParam,
      IntPtr lParam
  );

  - IntPtr CreateIconFromResourceEx(
      IntPtr presbits,
      uint dwResSize,
      bool fIcon,
      uint dwVer,
      int cxDesired,
      int cyDesired,
      uint Flags
  );

  - const uint LR_DEFAULTCOLOR = 0x00000000;
  - bool DestroyIcon(IntPtr hIcon);
  - struct WNDCLASSEX
  {
      - uint cbSize;
      - uint style;
      - WndProcDelegate lpfnWndProc;
      - int cbClsExtra;
      - int cbWndExtra;
      - IntPtr hInstance;
      - IntPtr hIcon;
      - IntPtr hCursor;
      - IntPtr hbrBackground;
      - string lpszMenuName;
      - string lpszClassName;
      - IntPtr hIconSm;
  }
  - struct MSG
  {
      - IntPtr hwnd;
      - uint message;
      - IntPtr wParam;
      - IntPtr lParam;
      - uint time;
      - int pt_x;
      - int pt_y;
  }

  - uint GetGuiResources(IntPtr hProcess, uint uiFlags);
  - IntPtr GetDC(IntPtr hWnd);
  - int ReleaseDC(IntPtr hWnd, IntPtr hDC);
  - IntPtr CreateWindowExW(
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
  - bool PeekMessageW(
      out MSG lpMsg,
      IntPtr hWnd,
      uint wMsgFilterMin,
      uint wMsgFilterMax,
      int wRemoveMsg
  );
  - bool TranslateMessage(ref MSG lpMsg);
  - IntPtr DispatchMessageW(ref MSG lpMsg);
  - IntPtr DefWindowProcW(
      IntPtr hWnd,
      uint message,
      IntPtr wParam,
      IntPtr lParam
  );

  - IntPtr BeginPaint(IntPtr hWnd, out PAINTSTRUCT lpPaint);
  - bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT lpPaint);
  - bool DestroyWindow(IntPtr hWnd);
  - void PostQuitMessage(int nExitCode);
  - IntPtr LoadCursorW(IntPtr hInstance, IntPtr lpCursorName);
  - ushort RegisterClassExW(ref WNDCLASSEX lpwcx);
  - bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
  - bool ShowWindow(IntPtr hWnd, int nCmdShow);
  - bool UpdateWindow(IntPtr hWnd);

  - struct PAINTSTRUCT
  {
      - IntPtr hdc;
      - bool fErase;
      - RECT rcPaint;
      - bool fRestore;
      - bool fIncUpdate;
      - byte[] rgbReserved;
  }

  - struct RECT
  {
      - int left;
      - int top;
      - int right;
      - int bottom;
  }

  - const uint WS_POPUP = 0x80000000;
  - const uint WS_EX_LAYERED = 0x00080000;
  - const uint WS_EX_TRANSPARENT = 0x00000020;
  - const uint WS_EX_TOPMOST = 0x00000008;
  - const int LWA_COLORKEY = 0x1;
  - const int LWA_ALPHA = 0x2;
  - const int GWL_EXSTYLE = -20;

  - bool SetLayeredWindowAttributes(
      IntPtr hwnd,
      uint crKey,
      byte bAlpha,
      uint dwFlags
  );
  - int GetWindowLong(IntPtr hWnd, int nIndex);
  - int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

- Angene.Win32Messages (WM, EM, not a global namespace.)
  - enum WM : uint
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

  - enum EM : uint
  {
      GETSEL          = 0x00B0,
      SETSEL          = 0x00B1,
      GETRECT         = 0x00B2,
      SETRECT         = 0x00B3,
      REPLACESEL      = 0x00C2,
      GETLINE         = 0x00C4,
  }

  - class WS
  {
      - const uint OVERLAPPED       = 0x00000000;
      - const uint POPUP            = 0x80000000;
      - const uint CHILD            = 0x40000000;
      - const uint VISIBLE          = 0x10000000;
      - const uint DISABLED         = 0x08000000;
      - const uint CLIPSIBLINGS     = 0x04000000;
      - const uint CLIPCHILDREN     = 0x02000000;
      - const uint SYSMENU          = 0x00080000;
      - const uint THICKFRAME       = 0x00040000;
  }

  - class WS_EX
  {
      - const uint TOPMOST           = 0x00000008;
      - const uint TOOLWINDOW        = 0x00000080;
      - const uint APPWINDOW         = 0x00040000;
      - const uint LAYERED           = 0x00080000;
      - const uint NOACTIVATE        = 0x08000000;
  }

  - class SWP
  {
      - const uint NOSIZE        = 0x0001;
      - const uint NOMOVE        = 0x0002;
      - const uint NOZORDER      = 0x0004;
      - const uint NOACTIVATE    = 0x0010;
      - const uint SHOWWINDOW    = 0x0040;
  }

- Angene.Gdi32
  - SRCCOPY = 0x00CC0020;
  - CreateCompatibleDC(IntPtr hdc);
  - CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
  - SelectObject(IntPtr hdc, IntPtr hObject);
  - DeleteObject(IntPtr hObject);
  - DeleteDC(IntPtr hdc);
  - BitBlt(
      IntPtr hdcDest,
      int nXDest,
      int nYDest,
      int nWidth,
      int nHeight,
      IntPtr hdcSrc,
      int nXSrc,
      int nYSrc,
      uint dwRop);
  - CreateSolidBrush(uint crColor);
  - GetStockObject(int fnObject);
  - Rectangle(IntPtr hdc, int left, int top, int right, int bottom);
  - SetBkMode(IntPtr hdc, int mode);
  - SetTextColor(IntPtr hdc, uint color);
  - TextOutW(IntPtr hdc, int nXStart, int nYStart, string lpString, int cchString);
  - BITMAPINFOHEADER
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
  - BITMAPINFO
  {
     BITMAPINFOHEADER bmiHeader;
     uint bmiColors; // Just enough for the header
  }
  - GetDIBits(IntPtr hdc, IntPtr hbmp, uint uStartScan, uint cScanLines, [Out] byte[] lpvBits, ref BITMAPINFO lpbi, uint uUsage);

- Angene.Graphics
  - GraphicsBackend
    - interface IGraphicsContext
    {
        IntPtr Handle { get; }
        void Clear(uint color);
        void DrawRectangle(int x, int y, int width, int height, uint color);
        void DrawText(string text, int x, int y, uint color);
        void Present(IntPtr windowHandle);
        void Cleanup();
        byte[] GetRawPixels();
    }
    
    - class GdiGraphicsContext : IGraphicsContext        
        - IntPtr Handle => memDc;
        
        - GdiGraphicsContext(IntPtr hwnd, int w, int h)
        - void Clear(uint color)
        - void DrawRectangle(int x, int y, int w, int h, uint color)
        - void DrawText(string text, int x, int y, uint color)
        - void Present(IntPtr hwnd)
        
        - byte[] GetRawPixels() { return null; }

    - class WSGraphicsContext : IGraphicsContext
      - IntPtr Handle => memDc;

      - WSGraphicsContext(string hwnd, int w, int h)
      - void Clear(uint color)
      - void DrawRectangle(int x, int y, int w, int h, uint color)
      - void DrawText(string text, int x, int y, uint color)
      - byte[] GetRawPixels()

    - class GraphicsContextFactory
      - IGraphicsContext Create(IntPtr windowHandle, int width, int height)
- Angene.External
  - External.DiscordRichPresence
    - (partial class) DiscordRichPresence
      - DiscordRichPresence(clientId) # New RPC Instance
      - SetPresence(RichPresence) # Sets new RPC
      - Clear() # Clears RPC
      - schedule() # Schedules Cts token debounce
      - Dispose() # Clears client

- Angene.PkgHandler
  - Package
    - IReadOnlyList<ManifestEntry> Entries => _manifest.Files;

    private Package(FileStream fs, Manifest manifest, byte[] key,
        bool manifestEncrypted, bool manifestCompressed, byte[] manifestNonce, long manifestOffset)
    {
        _fs = fs;
        _manifest = manifest;
        _key = key;
        _manifestEncrypted = manifestEncrypted;
        _manifestCompressed = manifestCompressed;
        _manifestNonce = manifestNonce;
        _manifestOffset = manifestOffset;
    }

    - Package Open(string path, byte[] key = null)
    {
        var fs = File.OpenRead(path);
        var magic = br.ReadBytes(8);
        var magicStr = Encoding.ASCII.GetString(magic);
        var version = br.ReadUInt32();
        var manifestLength = br.ReadInt64();
        var manifestFlags = br.ReadByte();
        bool manifestEncrypted = (manifestFlags & 0x01) != 0;
        bool manifestCompressed = (manifestFlags & 0x02) != 0;
        byte[] manifestNonce = null;
        long manifestOffset = fs.Position;
        var manifestBytes = new byte[manifestLength];
        int toRead = (int)manifestLength;
        int totalRead = 0;
        return new Package(fs, manifest, key, manifestEncrypted, manifestCompressed, manifestNonce, manifestOffset);
    }

    
    - void ExtractTo(string relativePath, string outPath)
    
    - Stream OpenStream(ManifestEntry entry)

    private class Manifest
    {
        - ManifestEntry[] Files { get; set; }
        - DateTime Created { get; set; }
    }

    - class ManifestEntry
    {
        - string Path { get; set; }
        - long Offset { get; set; }
        - long Length { get; set; }
        - bool Compressed { get; set; }
        - bool Encrypted { get; set; }
        - string Nonce { get; set; }
        - string Tag { get; set; }
    }
}

- Angene.Platform
  - WindowConfig
    - string Title { get; set; } = "Angene Window";
    - int Width { get; set; } = 800;
    - int Height { get; set; } = 600;
    - int X { get; set; } = Win32.CW_USEDEFAULT;
    - int Y { get; set; } = Win32.CW_USEDEFAULT;
    - bool cTI { internal get; set; } = false;
    - string cTS { internal get; set; } = "";
    - string cTT { internal get; set; } = "";
    - Win32.WindowStyle Style { get; set; } = Win32.WindowStyle.OverlappedWindow;
    - Win32.WindowStyleEx StyleEx { get; set; } = Win32.WindowStyleEx.None;
    - Win32.WindowTransparency Transparency { get; set; } = Win32.WindowTransparency.None;
    - bool Use3D { get; set; } = false;
    - bool ShowOnCreate { get; set; } = true;
    - bool AlwaysOnTop
    {
        get => StyleEx.HasFlag(Win32.WindowStyleEx.Topmost);
        set
        {
            if (value)
                StyleEx |= Win32.WindowStyleEx.Topmost;
            else
                StyleEx &= ~Win32.WindowStyleEx.Topmost;
        }
    }
    - WindowConfig Standard(string title, int width, int height)
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
    - WindowConfig TransparentOverlay(string title, int width, int height, bool clickThrough = true)
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
    - WindowConfig Borderless(string title, int width, int height)
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
    - WindowConfig Rendering3D(string title, int width, int height)
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
      - ShutdownEngine() # Shuts down the engine *correctly*.

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
  - Dictionary<string, object> consoleSettings # Console settings (Does literally nothing)
  - Action<string, object>[] OnSettingsChanged # Action that happens when setting changed.
  - Settings() # Literally calls LoadDefaults() when instantiated.
  - LoadDefaults() # Loads setting defaults
  - object GetSetting(string) # Gets a setting, returns an object from setting value
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
            Logger.Log($"Arguments received ({argc}):", LoggingTarget.MainConstructor);
            for (int i = 0; i < argArray.Length; i++)
            {
                Logger.Log($"  [{i}] {argArray[i]}", LoggingTarget.MainConstructor);
            }
            Logger.Log("", LoggingTarget.MainConstructor);
        }

        Logger.Log("Calling RunGame...", LoggingTarget.MainConstructor);
        RunGame(verbose);

        return 0;
    }
    except (Exception ex)
    {
        Logger.Log($"\nFATAL EXCEPTION in Main:", LoggingTarget.MainConstructor, logLevel: LogLevel.Critical, exception: ex);
        return 1; // Error
    }
}
```
Again just an example, but the arguments are as follows. If a log directory is not created after launching the host, something is incorrect with the entry point or the engine hasn't initialized.

# Conclusion
i'm really fucking tired, see yall next commit.