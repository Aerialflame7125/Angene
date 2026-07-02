using Angene.Common;
using Angene.Common.Settings;
using Angene.Essentials;
using Angene.External;
using Angene.Globals;
using Angene.Graphics;
using Angene.Platform;
using Angene.Windows;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Angene.Main
{
    public class Console
    {
        public static void WriteLine(string text)
        {
            Logger.Log("Call to WriteLine() is incorrect in this engine. Please use Logger.Log.", LoggingTarget.MainGame, LogLevel.Warning);
            Logger.Log(text, LoggingTarget.MainGame, LogLevel.Info);
        }
        public static void ReadLine(string text)
        {
            Logger.Log("Call to ReadLine() is incorrect in this engine. Console input is not available, nor supported.", LoggingTarget.MainGame, LogLevel.Warning);
        }
        public static void Write(string text)
        {
            Logger.Log("Call to Write() is incorrect in this engine. Please use Logger.Log.", LoggingTarget.MainGame, LogLevel.Warning);
            Logger.Log(text, LoggingTarget.MainGame, LogLevel.Info);
        }
    }

    public class Engine
    {
        private IEnumerable<System.Type> shaderTypes = null;
        private Settings? _settingHandlerInstanced;
        private LogConsoleWindow? _logConsole; // log window keepalive
        public List<Angene.Main.Window> OpenWindows = new List<Angene.Main.Window>();

        public Settings SettingHandlerInstanced
        {
            get
            {
                if (_settingHandlerInstanced == null)
                {
                    throw new AngeneException(
                        "Settings handler not initialized. Please call Engine.Init() before accessing settings."
                    );
                }

                return _settingHandlerInstanced;
            }
            private set
            {
                _settingHandlerInstanced = value;
            }
        }

        private Engine()
        {
            Lifecycle.ScriptBinding.destroyEngineList.Add(destroyInstances);
        }

        public static Engine Instance { get; } = new Engine();

        internal static void destroyInstances()
        {
            Instance._settingHandlerInstanced = null;
            Instance._logConsole = null;
        }

        public void Init(bool verbose = false, [CallerMemberName] string memberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            shaderTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetCustomAttribute<Attributes.PrecompileAttribute>() != null);

            SettingHandlerInstanced = new Settings();
            SettingHandlerInstanced.LoadDefaults();
            Logger.Instance.Init(verbose);
            _settingHandlerInstanced.SetSetting("Main.engineCallerMemberName", memberName);
            _settingHandlerInstanced.SetSetting("Main.engineCallerFilePath", callerFilePath);
            _settingHandlerInstanced.SetSetting("Main.engineCallerLineNumber", sourceLineNumber);

            if (verbose)
            {
                _logConsole = new LogConsoleWindow();

                Logger.Instance.OnLog += (message, target, level, time, exception) =>
                {
                    if (exception == null && (string)message == "[OnQuit] ExitOnException")
                    {
                        destroyInstances();
                        Environment.Exit(1);
                    }
                    if (exception != null)
                        _logConsole.AppendLine($"[{level}] {target} ({time}) {message}\n{exception}");
                    else
                        _logConsole.AppendLine($"[{level}] {target} ({time}) {message}");
                };

                Logger.Log("Verbose log console initialized.", LoggingTarget.Engine, LogLevel.Important);
            }
            if (shaderTypes != null)
            {
                Logger.LogDebug($"Found {shaderTypes.Count()} Shaders. Halting startup and attempting compilation..", LoggingTarget.Graphics);
            }
        }

        public void StartShaderCompilation(bool backgrounded = false)
        {
            // Create a new window
            WindowConfig _w = new WindowConfig();
            _w.Width = 640; _w.Height = 480;
            _w.Style = WindowManagement.WindowStyle.PopupWindow;
            _w.ShowOnCreate = true;
            _w.Title = "Angene Shader Compilation";
            _w.renderMode = RenderType.GDI;

            Window _WindowInstance = new Window(_w);

            IScene scene = new ShaderCompilationScene();
            scene.Initialize();
            _WindowInstance.SetScene(scene);
        }
    }

    internal class ShaderCompilationScene : IScene
    {
        public ShaderCompilationScene() { }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void OnMessage(nint msgPtr)
        {
            throw new NotImplementedException();
        }

        public void Render()
        {
            throw new NotImplementedException();
        }

        public void Cleanup()
        {
            throw new NotImplementedException();
        }
    }

    public class Window
    {
        public object Hwnd { get; private set; }

        public List<IScene> Scenes { get; private set; } = new List<IScene>();
        public IScene? PrimaryScene { get; private set; }
        public IScene ManagementScene { get; internal set; }

        public int Width { get; }
        public int Height { get; }

        private IGraphicsContext? graphicsContext;
        private bool is3D;
        public IScreenPlay? _screenPlay; // for ws method

        // Engine mode tracking
        private EngineMode _engineMode = EngineMode.Edit;

        // Global map of windows
        public static readonly Dictionary<Object, Window> WindowMap = new();

        private string _instanceConnectionString;

        // Windows-specific fields
        private static readonly User32.WndProcDelegate s_wndProc = DefaultWndProc;
        private static bool s_classRegistered;

        [Obsolete("This method is deprecated. Please use the 'WindowConfig' constructor instead.", true)]
        public Window(string Name, int width, int height)
        {
            Logger.LogCritical("The 'Window(string, int, int) constructor is deprecated. Please use the 'WindowConfig' constructor instead.", LoggingTarget.Engine, new AngeneException(""), enginePanic: true);
        }
        public Window(WindowConfig config)
        {
            Width = config.Width;
            Height = config.Height;

            if (config.cTI)
            {
                _instanceConnectionString = config.cTS;
            }
            else
            {
                _instanceConnectionString = null;
            }

#if WINDOWS
            Hwnd = CreateWindowWindows(config, config.cTI, config.cTS, config.cTT);
            
            if (Hwnd.GetType() != typeof(String))
            {
                WindowMap[(IntPtr)Hwnd] = this;
            }
            else
            {
                WindowMap[Hwnd] = this;
            }
            Engine.Instance.OpenWindows.Add(this);

            string initToken = Guid.NewGuid().ToString("N");
            Engine.Instance.SettingHandlerInstanced.SetSetting("Main.OTT", initToken); // One Time Token
            var mgmtScene = new Angene.Management.ManagementScene(initToken);
            AddScene(mgmtScene);

            if (!config.cTI)
            {
                graphicsContext = GraphicsContextFactory.Create((IntPtr)Hwnd, config.Width, config.Height, (int)config.renderMode);
            }
            else
            {
                graphicsContext = GraphicsContextFactory.CreateWS((string)Hwnd, config.Width, config.Height);
                var streamer = new Websocket.WebStreamer(this);
                _screenPlay = streamer;
                RegisterWebSocketInput();
            }
#else
            throw new AngeneException("You are running on a non-Windows system. Please use a windows application wrapper for whichever distribution of system you may be using.");
#endif


            Logger.Log("Window created successfully", LoggingTarget.Engine, LogLevel.Important);
        }

        private int CheckSceneIndexOf(IScene scene)
        {
            if (scene.Instance.Name == "ManagementScene")
            {
                return -2; // ManagementScene will not be able to be removed, therefore not indexed or returned.
            }
            return Scenes.IndexOf(scene);
        }

        /// <summary>
        /// Set the primary scene and clear all other scenes.
        /// </summary>
        public void SetScene(IScene scene)
        {
            if (scene == null)
            {
                Logger.Log("Attempted to set null scene", LoggingTarget.Engine, LogLevel.Error);
                return;
            }

            // Clean up existing scenes
            foreach (var existingScene in Scenes)
            {
                existingScene?.Cleanup();
            }

            Scenes.Clear();
            Scenes.Add(scene);
            PrimaryScene = scene;

            // Initialize the scene
            scene.Initialize();

            Logger.Log($"Primary scene set to '{scene.GetType().Name}'", LoggingTarget.Engine, LogLevel.Important);
        }

        /// <summary>
        /// Add an additional scene to the window.
        /// </summary>
        public void AddScene(IScene scene)
        {
            if (scene == null)
            {
                Logger.Log("Attempted to add nil scene", LoggingTarget.Engine, LogLevel.Error);
                return;
            }

            foreach (var e in Scenes)
            {
                if (e == scene)
                {
                    Logger.Log("Attempted to add a scene that is already in the scene list", LoggingTarget.Engine, LogLevel.Warning);
                    return;
                }
            }

            if (scene is Management.ManagementScene && ManagementScene == null)
            {
                Logger.LogDebug("Recieved a new ManagementScene call. Verifying...", LoggingTarget.Engine);
                // Silently add without logging, but check signatures.
                List<Entity> e = scene.Instance.GetEntities(); // If this throws a new Entity of 'ManagementCheck$o7' (creating entity of this name would fail), then we have passed.
                if (e != null && e.Count == 1)
                {
                    if (e[0].name == Engine.Instance.SettingHandlerInstanced.GetSetting("Main.OTT").ToString())
                    {
                        e[0].name = "Ent1"; // Rename to indicate success, set management scene, and fail on all other occurances of a Management Scene.
                        Engine.Instance.SettingHandlerInstanced.SetSetting("Main.OTT", null); // Clear the one time token to prevent reuse
                        ManagementScene = scene;
                        scene.Initialize();
                        Logger.LogDebug("ManagementScene attached successfully.", LoggingTarget.Engine);
                    }
                }
                return;
            }

            Scenes.Add(scene);
            scene.Initialize();
            Logger.Log($"Scene '{scene.GetType().Name}' added to window", LoggingTarget.Engine, LogLevel.Debug);
        }

        /// <summary>
        /// Remove a scene from the window.
        /// </summary>
        public void RemoveScene(IScene scene)
        {
            if (scene == null)
            {
                Logger.Log("Attempted to remove null scene", LoggingTarget.Engine, LogLevel.Warning);
                return;
            }

            int index = CheckSceneIndexOf(scene);
            if (index == -1)
            {
                Logger.Log("The scene to be removed was not found in the current scene list", LoggingTarget.Engine, LogLevel.Warning);
                return;
            } 
            else if (index == -2)
            {
                Logger.Log($"The scene to be removed is a fundamental part of Angene and cannot be removed. (Attempted to remove '{scene.Instance.Name}'.)", LoggingTarget.Engine, LogLevel.Error);
                return;
            }

            Scenes.RemoveAt(index);
            scene.Cleanup();

            if (PrimaryScene == scene)
            {
                PrimaryScene = Scenes.Count > 0 ? Scenes[0] : null;
            }

            Logger.Log($"Scene '{scene.GetType().Name}' removed from window", LoggingTarget.Engine, LogLevel.Debug);
        }

        /// <summary>
        /// Set the engine mode (Edit, Play, Paused).
        /// This affects which lifecycle methods are executed.
        /// </summary>
        public void SetEngineMode(EngineMode mode)
        {
            if (_engineMode != mode)
            {
                _engineMode = mode;
                Logger.Log($"Engine mode changed to: {mode}", LoggingTarget.Engine, LogLevel.Important);
            }
        }

        /// <summary>
        /// Get the current engine mode.
        /// </summary>
        public EngineMode GetEngineMode()
        {
            return _engineMode;
        }

        private void RegisterWebSocketInput()
        {
            Websocket.OnInputReceived += (json) =>
            {
                try
                {
                    // Minimal JSON parse without needing System.Text.Json or Newtonsoft
                    // Pulls out "type", "keyCode", "button", "x", "y"
                    string type = ExtractJsonString(json, "type");
                    int keyCode = ExtractJsonInt(json, "keyCode");
                    int button = ExtractJsonInt(json, "button");
                    int x = ExtractJsonInt(json, "x");
                    int y = ExtractJsonInt(json, "y");

                    uint message = type switch
                    {
                        "keydown" => (uint)WM.KEYDOWN,
                        "keyup" => (uint)WM.KEYUP,
                        "mousemove" => (uint)WM.MOUSEMOVE,
                        "mousedown" => button == 2 ? (uint)WM.RBUTTONDOWN : (uint)WM.LBUTTONDOWN,
                        "mouseup" => button == 2 ? (uint)WM.RBUTTONUP : (uint)WM.LBUTTONUP,
                        _ => 0
                    };

                    if (message == 0) return;

                    // Pack x/y into lParam the same way Win32 does: high word = y, low word = x
                    IntPtr lParam = new IntPtr((y << 16) | (x & 0xFFFF));
                    IntPtr wParam = new IntPtr(keyCode);

                    var msg = new WindowManagement.MSG
                    {
                        hwnd = Hwnd is IntPtr h ? h : IntPtr.Zero,
                        message = message,
                        wParam = wParam,
                        lParam = lParam
                    };

                    IntPtr msgPtr = Marshal.AllocHGlobal(Marshal.SizeOf<WindowManagement.MSG>());
                    try
                    {
                        Marshal.StructureToPtr(msg, msgPtr, false);
                        for (int i = Scenes.Count - 1; i >= 0; i--)
                            Scenes[i].OnMessage(msgPtr);
                        ManagementScene.OnMessage(msgPtr);
                        Lifecycle.ScriptBinding.Tick(ManagementScene, 0, GetEngineMode());
                    }
                    finally
                    {
                        Marshal.FreeHGlobal(msgPtr);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log($"Failed to process input packet: {ex.Message}", LoggingTarget.Engine, LogLevel.Error);
                }
            };
        }

        private static string ExtractJsonString(string json, string key)
        {
            string search = $"\"{key}\":\"";
            int start = json.IndexOf(search);
            if (start == -1) return "";
            start += search.Length;
            int end = json.IndexOf('"', start);
            return end == -1 ? "" : json.Substring(start, end - start);
        }

        private static int ExtractJsonInt(string json, string key)
        {
            string search = $"\"{key}\":";
            int start = json.IndexOf(search);
            if (start == -1) return 0;
            start += search.Length;
            int end = start;
            while (end < json.Length && (char.IsDigit(json[end]) || json[end] == '-')) end++;
            return int.TryParse(json.Substring(start, end - start), out int val) ? val : 0;
        }
        public void Cleanup()
        {
            Logger.Log("Cleaning up window resources", LoggingTarget.Engine, LogLevel.Important);

            if (!is3D && graphicsContext != null)
            {
                graphicsContext.Cleanup();
            }

            foreach (IScene scene in Scenes)
            {
                scene?.Renderer3D?.Cleanup();
                scene?.Cleanup();
            }
        }
#if !WINDOWS
        private static object CreateWindowWindows(WindowConfig config, bool cTI, string cTS, object type)
        {
            throw new AngeneException("You are running on a non-Windows system. Please use a windows application wrapper for whichever distribution of system you may be using.");
        }
#endif

        // windows apis
        private static object CreateWindowWindows(WindowConfig config, bool cTI, string cTS, object type)
        {
            if (cTI && cTS != null && type != null)
            {
                // use strings to shut up the compiler
                if ((string)type == "ws" || (string)type == "websocket")
                {
                    Logger.Log("\r\n __    __   ______   __     ________ \r\n|  \\  |  \\ /      \\ |  \\   |        \\\r\n| $$  | $$|  $$$$$$\\| $$    \\$$$$$$$$\r\n| $$__| $$| $$__| $$| $$      | $$   \r\n| $$    $$| $$    $$| $$      | $$   \r\n| $$$$$$$$| $$$$$$$$| $$      | $$   \r\n| $$  | $$| $$  | $$| $$_____ | $$   \r\n| $$  | $$| $$  | $$| $$     \\| $$   \r\n \\$$   \\$$ \\$$   \\$$ \\$$$$$$$$ \\$$   ", LoggingTarget.Engine, LogLevel.Important);
                    Logger.LogWarning("You have opted to start a websocket for window streaming. This is highly discouraged but you shall continue. Work with caution fellow developer.", LoggingTarget.Engine);
                    Logger.LogWarning("If the game developer does NOT allow this, the process will be terminated, commencing check.", LoggingTarget.Engine);

                    // check settings
                    Settings settings = Engine.Instance.SettingHandlerInstanced;
                    object? a = settings.GetSetting("Main.getIsGameAllowedForWebsockets");
                    if (!(bool)a)
                    {
                        Logger.LogCritical("You are NOT licensed to run this game. Entitlement Check FAILED.", LoggingTarget.MainGame, new AngeneException("Entitlement Check Failed. You are not licensed to execute binaries of this program."), true);
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }
                    string url = "http://localhost";
                    string port = ":8000";
                    HttpListener listener = new HttpListener();
                    listener.Prefixes.Add($"{url}{port}/");
                    listener.Start();
                    Logger.LogInfo("The websocket streamer has started on 'localhost:8080', best of luck to you developer. o7", LoggingTarget.Engine);
#pragma warning disable CS4014
                    // I'm going to fucking kill the compiler, complains about blocking because it isnt awaited.
                    Websocket.StartWebsocket(listener);
#pragma warning restore CS4014
                    Random rand = new Random();
                    return $"WS{port}[{rand.NextInt64(0, 1000000000)}]";
                }
            }
            else
            {
                // Register class once
                if (!s_classRegistered)
                {
                    var wc = new WindowManagement.WNDCLASSEX
                    {
                        cbSize = (uint)Marshal.SizeOf<WindowManagement.WNDCLASSEX>(),
                        style = 0,
                        lpfnWndProc = s_wndProc,
                        cbClsExtra = 0,
                        cbWndExtra = 0,
                        hInstance = Kernel32.GetModuleHandle(null),
                        hIcon = IntPtr.Zero,
                        hCursor = IntPtr.Zero,
                        hbrBackground = IntPtr.Zero,
                        lpszMenuName = null,
                        lpszClassName = "AngeneClass",
                        hIconSm = IntPtr.Zero
                    };

                    ushort atom = User32.RegisterClassExW(ref wc);
                    if (atom == 0)
                    {
                        throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
                    }

                    s_classRegistered = true;
                }

                IntPtr hInstance = Kernel32.GetModuleHandle(null);
                IntPtr hwnd = User32.CreateWindowExW(
                    (uint)config.StyleEx,
                    "AngeneClass",
                    config.Title,
                    (uint)config.Style,
                    config.X,
                    config.Y,
                    config.Width,
                    config.Height,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    hInstance,
                    IntPtr.Zero
                );

                if (hwnd == IntPtr.Zero)
                    throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());

                User32.ShowWindow(hwnd, Consts.SW_SHOW);
                Logger.Log($"Window({hwnd}) shown", LoggingTarget.Engine);
                User32.UpdateWindow(hwnd);
                return hwnd;

            }
            return IntPtr.Zero;
        }

        private static IntPtr DefaultWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            // Forward message to scenes if window found
            if (WindowMap.TryGetValue(hWnd, out var win) && win.PrimaryScene != null)
            {
                var managedMsg = new WindowManagement.MSG
                {
                    hwnd = hWnd,
                    message = msg,
                    wParam = wParam,
                    lParam = lParam,
                    time = 0,
                    pt_x = 0,
                    pt_y = 0
                };

                IntPtr msgPtr = Marshal.AllocHGlobal(Marshal.SizeOf<WindowManagement.MSG>());
                try
                {
                    Marshal.StructureToPtr(managedMsg, msgPtr, false);
                    try
                    {
                        // Forward to all scenes (in reverse order for event bubbling)
                        for (int i = win.Scenes.Count - 1; i >= 0; i--)
                            win.Scenes[i].OnMessage(msgPtr);
                        // ManagementScene ticking
                        win.ManagementScene.OnMessage(msgPtr);
                        Lifecycle.ScriptBinding.Tick(win.ManagementScene, 0, win.GetEngineMode());
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(
                            $"Exception in scene OnMessage: {ex.Message}",
                            LoggingTarget.Engine,
                            LogLevel.Error
                        );
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(msgPtr);
                }
            }

            if (msg == (uint)WM.CLOSE)
            {
                if (WindowMap.TryGetValue(hWnd, out var w))
                {
                    w.Cleanup();
                }
                User32.DestroyWindow(hWnd);
                return IntPtr.Zero;
            }

            if (msg == (uint)WM.DESTROY)
            {
                User32.PostQuitMessage(0);
                return IntPtr.Zero;
            }

            return User32.DefWindowProcW(hWnd, msg, wParam, lParam);
        }

        /// <summary>
        /// Process Windows messages.
        /// Returns false when WM_QUIT is received.
        /// </summary>
        public static bool ProcessMessages()
        {
            while (User32.PeekMessageW(out var msg, IntPtr.Zero, 0, 0, Consts.PM_REMOVE))
            {
                if (msg.message == (uint)WM.QUIT)
                    return false;

                User32.TranslateMessage(ref msg);
                User32.DispatchMessageW(ref msg);
            }
            return true;
        }

        // platform messages
        [StructLayout(LayoutKind.Sequential)]
        public struct PlatformMessage
        {
            public IntPtr hwnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
        }

        // graphics context
        public IGraphicsContext? Graphics => graphicsContext;
    }
}