global using static Angene.X11.Interop.XLib;
using Angene.Common;
using Angene.Common.Settings;
using Angene.Essentials;
using Angene.External;
using Angene.Globals;
using Angene.Graphics;
using Angene.Graphics.DX11;
using Angene.Graphics.SlangShader;
using Angene.Platform;
using Angene.Windows;
using Angene.Windows.D3D11;
using DiscordRPC.Message;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Angene.Vulkan.Interop.Enumerators;
using static Angene.Vulkan.Interop.Structs;

namespace Angene.Main
{
    public class Console
    {
        public static void WriteLine(string text)
        {
            Logger.LogWarning("Call to WriteLine() is incorrect in this engine. Please use Logger.Log.", LoggingTarget.MainGame);
            Logger.LogInfo(text, LoggingTarget.MainGame);
        }
        public static void ReadLine(string text)
        {
            Logger.LogWarning("Call to ReadLine() is incorrect in this engine. Console input is not available, nor supported.", LoggingTarget.MainGame);
        }
        public static void Write(string text)
        {
            Logger.LogWarning("Call to Write() is incorrect in this engine. Please use Logger.Log.", LoggingTarget.MainGame);
            Logger.LogInfo(text, LoggingTarget.MainGame);
        }
    }

    public class Engine
    {
        public string[] supportedLibs;
        List<SlangShaderResources.IShader> shaderTypes = new List<SlangShaderResources.IShader>();
        public Dictionary<int, SlangShaderResources.IShader> ShaderCache { get; internal set; }
        int shaderCount = 0;
        List<WindowConfig> WindowCreationQueue = new List<WindowConfig>([]);
        public bool IsCompilingShaders = false;
        public bool ShouldShutdown = false;

#if WINDOWS
        private LogConsoleWindow? _logConsole; // log window keepalive
        public IntPtr SharedD3D11Device { get; internal set; } = IntPtr.Zero;
        public IntPtr SharedD3D11Context { get; internal set; } = IntPtr.Zero;
#endif
        public IntPtr SharedVkDevice { get; internal set; } = IntPtr.Zero;
        public IntPtr SharedVkContext { get; internal set; } = IntPtr.Zero;
#if LINUX
        public unsafe _XDisplay* SharedX11Display { get; internal set; } = null;
        public bool InitializedXThreads { get; internal set; } = false;
#endif

        public Types.AppInfo currentAppInfo { get; internal set; }
        internal List<Window> PendingWindowCloses { get; } = new();
        public List<Window> OpenWindows { get; private set; } = new List<Window>();
        public Settings settingsInstance = new Settings();

        private Engine()
        {
            // Check which libraries exist and what are supported.
            Lifecycle.ScriptBinding.destroyEngineList.Add(destroyInstances);
        }

        public static Engine Instance { get; } = new Engine();

        // Check supported libraries
        private static string[] CheckSupportedLibraries()
        {
            List<string> supportedLibs = new List<string>();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Logger.LogDebug("[Engine.cs | CheckSupportedLibraries] Checking for supported libraries on Windows.", LoggingTarget.Engine);
                string[] AllLibs = new[] { "Graphics", "Vulkan", "D3D11", "Input", "Math", "Audio" };
                // Manual checks, most important.
                if (File.Exists(Path.Combine(AppContext.BaseDirectory, "Angene.Windows.dll")))
                    supportedLibs.Add("Windows");
                else
                    Logger.LogCritical("[Engine.cs | CheckSupportedLibraries] Angene.Windows.dll is missing. Please check your installation.", LoggingTarget.Engine, new AngeneException("Angene.Windows.dll is missing. Installation is corrupt or incomplete."), true);

                if (File.Exists(Path.Combine(AppContext.BaseDirectory, "Angene.Common.dll")))
                    supportedLibs.Add("Common");
                else
                    Logger.LogCritical("[Engine.cs | CheckSupportedLibraries] Angene.Common.dll is missing. Please check your installation.", LoggingTarget.Engine, new AngeneException("Angene.Common.dll is missing. Installation is corrupt or incomplete."), true);

                if (File.Exists(Path.Combine(AppContext.BaseDirectory, "Angene.Essentials.dll")))
                    supportedLibs.Add("Essentials");
                else
                    Logger.LogCritical("[Engine.cs | CheckSupportedLibraries] Angene.Essentials.dll is missing. Please check your installation.", LoggingTarget.Engine, new AngeneException("Angene.Essentials.dll is missing. Installation is corrupt or incomplete."), true);

                foreach (string lib in AllLibs)
                    if (File.Exists(Path.Combine(AppContext.BaseDirectory, $"Angene.{lib}.dll")))
                        supportedLibs.Add(lib);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Logger.LogDebug("[Engine.cs | CheckSupportedLibraries] Checking for supported libraries on Linux.", LoggingTarget.Engine);
                string [] AllLibs = new[] { "Graphics", "Vulkan", "Input", "Math", "Audio" };
                if (File.Exists(Path.Combine(AppContext.BaseDirectory, "Angene.X11.dll")))
                    supportedLibs.Add("X11");
                else
                    Logger.LogWarning("[Engine.cs | CheckSupportedLibraries] Angene.X11.dll is missing. If this is intended, please ignore this message.", LoggingTarget.Engine);

                if (File.Exists(Path.Combine(AppContext.BaseDirectory, "Angene.Common.dll")))
                    supportedLibs.Add("Common");
                else
                    Logger.LogCritical("[Engine.cs | CheckSupportedLibraries] Angene.Common.dll is missing. Please check your installation.", LoggingTarget.Engine, new AngeneException("Angene.Common.dll is missing. Installation is corrupt or incomplete."), true);

                if (File.Exists(Path.Combine(AppContext.BaseDirectory, "Angene.Essentials.dll")))
                    supportedLibs.Add("Essentials");
                else
                    Logger.LogCritical("[Engine.cs | CheckSupportedLibraries] Angene.Essentials.dll is missing. Please check your installation.", LoggingTarget.Engine, new AngeneException("Angene.Essentials.dll is missing. Installation is corrupt or incomplete."), true);

                foreach (string lib in AllLibs)
                    if (File.Exists(Path.Combine(AppContext.BaseDirectory, $"Angene.{lib}.dll")))
                        supportedLibs.Add(lib);
            }
            else
                Logger.LogDebug("[Engine.cs | CheckSupportedLibraries] Unsupported OS platform detected. No libraries will be checked for existance. More power to you.", LoggingTarget.Engine);

            Logger.LogDebug($"Evaluated supported libraries: {string.Join(", ", supportedLibs.ToArray())}", LoggingTarget.Engine);
            return supportedLibs.ToArray();
        }

        public unsafe void XInitThreads()
        {
#if LINUX
            if (SharedX11Display == null)
            {
                Logger.LogDebug("[Engine.cs | XInitThreads] Initializing X11 threads..", LoggingTarget.Engine);

                int result = Methods.XInitThreads();
                if (result == 0)
                    Logger.LogCritical("[Engine.cs | XInitThreads] Failed to initialize X11 threads. Please check your installation.", LoggingTarget.Engine, new AngeneException("Failed to initialize X11 threads. Installation is corrupt or incomplete."), true);

                InitializedXThreads = true;
                Logger.LogDebug("[Engine.cs | XInitThreads] Successfully initialized X11 threads.", LoggingTarget.Engine);
            }
#endif
        }
        
        internal unsafe static void destroyInstances()
        {
#if WINDOWS
            if (Instance.SharedD3D11Device != IntPtr.Zero) { Marshal.Release(Instance.SharedD3D11Device); Instance.SharedD3D11Device = IntPtr.Zero; }
            if (Instance.SharedD3D11Context != IntPtr.Zero) { Marshal.Release(Instance.SharedD3D11Context); Instance.SharedD3D11Context = IntPtr.Zero; }
            Instance._logConsole = null;
#endif
            if (Instance.SharedVkContext != IntPtr.Zero)
            {
                Vulkan.Interop.Methods.vkDestroyInstance(Instance.SharedVkContext, null);
                Instance.SharedVkContext = IntPtr.Zero;
            }
            if (Instance.SharedVkDevice != IntPtr.Zero)
            {
                Vulkan.Interop.Methods.vkDeviceWaitIdle(Instance.SharedVkDevice);
                Vulkan.Interop.Methods.vkDestroyDevice(Instance.SharedVkDevice, null);
                Instance.SharedVkDevice = IntPtr.Zero; 
            }
#if LINUX
            if (Instance.SharedX11Display != null)
            {
                Methods.XCloseDisplay(Instance.SharedX11Display);
                Instance.SharedX11Display = null;
            }
#endif
            Instance.settingsInstance = null;
        }

        internal void RequestClose(Window w)
        {
            if (!PendingWindowCloses.Contains(w))
                PendingWindowCloses.Add(w);
        }

        /// <summary>
        /// Actually destroys any windows that called Close() this frame. Must be
        /// called once per frame from OUTSIDE any foreach over OpenWindows.
        /// </summary>
        public void FlushPendingCloses()
        {
            if (PendingWindowCloses.Count == 0) return;

            var toClose = PendingWindowCloses.ToArray(); // snapshot, since ReallyClose mutates OpenWindows
            PendingWindowCloses.Clear();

            foreach (var w in toClose)
                w.ReallyClose();
        }

        public void Init(Types.AppInfo appInfo, bool verbose = false, [CallerMemberName] string memberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Logger.Instance.Init(verbose);
            supportedLibs = CheckSupportedLibraries();
            bool skipGraphics = false;
            currentAppInfo = appInfo;
            
            settingsInstance.SetSetting("Main.engineCallerMemberName", memberName);
            settingsInstance.SetSetting("Main.engineCallerFilePath", callerFilePath);
            settingsInstance.SetSetting("Main.engineCallerLineNumber", sourceLineNumber);

            Logger.LogDebug($"Initializing Angene for '{appInfo.AppName}' with version '{appInfo.AppVersion}'.", LoggingTarget.Engine);
            if (!supportedLibs.Contains("Graphics"))
            {
                Logger.LogWarning("[Engine.cs | Init] Graphics library was not found for this platform. Skipping shader compilation.", LoggingTarget.Engine);
                skipGraphics = true;
            }

            if (!skipGraphics)
            {
                try
                {
                    shaderTypes = Assembly.GetCallingAssembly().GetTypes().Where(t => t.GetCustomAttribute<Attributes.PrecompileAttribute>() != null).Select(t => (SlangShaderResources.IShader)Activator.CreateInstance(t)).ToList();
                    shaderCount = shaderTypes.Count();
                }
                catch(Exception e)
                {
                    Logger.LogCritical("Failed to get shaders via attribute, Failing.", LoggingTarget.Engine, e, true);
                }
#if WINDOWS
                if (verbose)
                {
                    _logConsole = new LogConsoleWindow();

                    Logger.Instance.OnLog += (message, target, level, time, exception) =>
                    {
                        if (exception != null)
                            _logConsole.AppendLine($"[{level}] {target} ({time}) {message}\n{exception}");
                        else
                            _logConsole.AppendLine($"[{level}] {target} ({time}) {message}");
                    };

                    Logger.LogDebug("Verbose log console initialized.", LoggingTarget.Engine);
                }
#endif
            }
            Logger.Instance.OnLog += (message, target, level, time, exception) =>
            {
                if (exception == null && (string)message == "[OnQuit] ExitOnException")
                {
                    destroyInstances();
                    Environment.Exit(1);
                }
            };


            if (shaderTypes != null && shaderCount >= 1 && !skipGraphics)
            {
                Logger.LogImportant($"Found {shaderCount} Shaders. Halting startup and attempting compilation..", LoggingTarget.Graphics);
#if WINDOWS
                // alright im going to fucking hate this
                // To generate d3d shaders, low and behold, you *have* to initialize it.
                // So lets initialize it here then dispose of it after it is done.
                WindowConfig _w = new();
                _w.Width = 100; _w.Height = 100;
                _w.X = -10000; _w.Y = -10000;
                _w.Style = WindowManagement.WindowStyle.PopupWindow;
                _w.ShowOnCreate = true;
                _w.Title = "D3D11 Dummy Window | Ignore.";
                _w.renderMode = RenderType.D3D11;
                Window _window = new(_w);
                IDX11GraphicsContext _graphicscontext = _window.Graphics as IDX11GraphicsContext;
                if (_graphicscontext == null)
                    Logger.LogCritical("[Engine.cs | StartShaderCompilation] Dummy D3D11 window is not using the correct backend. Failing.", LoggingTarget.MainConstructor, new AngeneException("Incorrect backend on D3D11 Window."), true);

                if (SharedD3D11Device == IntPtr.Zero)
                {
                    SharedD3D11Device = _graphicscontext.Handle;
                    SharedD3D11Context = _graphicscontext.ContextHandle;
                    Marshal.AddRef(SharedD3D11Device);
                    Marshal.AddRef(SharedD3D11Context);
                }
#else
                WindowConfig _w = new(); // Im literally copying the above for Vk
                _w.Width = 100; _w.Height = 100;
                _w.X = -10000; _w.Y = -10000;
                _w.ShowOnCreate = true;
                _w.Title = "Vulkan Dummy Window | Ignore.";
                _w.renderMode = RenderType.Vulkan;
                Window _window = new (_w);
                VkGraphicsContext _graphicscontext = _window.Graphics as VkGraphicsContext; // Vulkan n stuff
                if (_graphicscontext == null)
                    Logger.LogCritical("[Engine.cs | StartShaderCompilation] Dummy Vulkan window is not using the correct backend. Failing.", LoggingTarget.MainConstructor, new AngeneException("Incorrect backend on Vulkan Window."), true);
                
                if (SharedVkDevice == IntPtr.Zero)
                {
                    SharedVkDevice = _graphicscontext.Handle;
                    SharedVkContext = _graphicscontext.ContextHandle;
                }
#endif
                // now start shader comp
                StartShaderCompilation(shaderTypes, shaderCount, _graphicscontext.Handle, _window, verbose);
            }
        }

        private void StartShaderCompilation(List<SlangShaderResources.IShader> _shaderTypes, int _shaderCount, IntPtr _devicePtr, Window _compilationWindow, bool verbose = false)
        {
#if WINDOWS
            // Create a new window for showing progress
            WindowConfig _w = new();
            _w.Width = 640; _w.Height = 480;
            _w.Style = WindowManagement.WindowStyle.PopupWindow;
            _w.ShowOnCreate = true;
            _w.Title = "Angene Shader Compilation";
            _w.renderMode = RenderType.GDI;
            Window _WindowInstance = new Window(_w);

            IScene scene = new ShaderCompilationScene(_shaderTypes, _shaderCount, _devicePtr, _compilationWindow, _WindowInstance.Handle, _WindowInstance, verbose);
#else
            WindowConfig _w = new();
            _w.Width = 10; _w.Height = 10;
            _w.ShowOnCreate = false;
            _w.Title = "Angene Shader Compilation";
            _w.renderMode = RenderType.Vulkan;
            Window _WindowInstance = new Window(_w);

            IScene scene = new LinuxShaderCompilationScene(_shaderTypes, _shaderCount, _devicePtr, _compilationWindow, true, _WindowInstance);
#endif
            _WindowInstance.SetScene(scene);
            scene.Initialize();
        }
    }

    internal class LinuxShaderCompilationScene : IScene
    {
        public object Instance { get; private set; }

        public List<Entity> Entities { get; private set; } = new List<Entity>();
        public string Name => "LinuxShaderCompilationScene";

        private readonly List<SlangShaderResources.IShader> _shaderTypes;
        private int _shaderCount;
        private bool _verbose;
        public double _timeElapsed;
        public int _shaderNum;
        public bool _started;
        public bool _done;
        private IntPtr _devicePtr;
        private Window _compilationWindow;
        private Window _thisWindow;

        public LinuxShaderCompilationScene(List<SlangShaderResources.IShader> shaderTypes, int shaderCount, IntPtr devicePtr, Window compilationWindow, bool verbose, Window thisWindow)
        {
            _shaderTypes = shaderTypes;
            _verbose = verbose;
            _shaderCount = shaderCount;
            _timeElapsed = 0;
            _shaderNum = 0;
            _started = false;
            _devicePtr = devicePtr;
            _compilationWindow = compilationWindow;
            _thisWindow = thisWindow;
        }

        public void Cleanup()
        {
            _compilationWindow.Close();
            _thisWindow.Close();
        }
        public void Initialize()
        {
            Instance = this;
            _started = true;
            _done = false;
            Engine.Instance.IsCompilingShaders = true;
        }
        public void OnMessage(nint msgPtr) { }
        public void Render()
        {
            if (_shaderNum < _shaderCount)
            {
                _timeElapsed = 0;
                SlangShaderResources.IShader current = _shaderTypes[_shaderNum];
                Logger.LogDebug($"Shader num {_shaderNum}/{_shaderCount - 1} (_shaderTypes Max: {_shaderTypes.Count})", LoggingTarget.Graphics);
                switch (current.Origin)
                {
                    case SlangShaderResources.ShaderOrigin.Vulkan:
                        if (current.VerboseLog)
                            Logger.LogDebug($"Compiling Vulkan shader '{current.Name}' to ID {current.id}..", LoggingTarget.Graphics);
                        CompileVulkanShader(current, _devicePtr, current.compileToFile);
                        break; 
                }

                _shaderNum++;
            }
            else
            {
                _done = true;
                Engine.Instance.IsCompilingShaders = false;
                Cleanup();
            }
        }

        private void CompileVulkanShader(SlangShaderResources.IShader shader, IntPtr devicePtr, bool CompileToFile = false)
        {
            string stage = shader.Type switch
            {
                SlangShaderResources.ShaderType.Vertex => "vertex",
                SlangShaderResources.ShaderType.Pixel => "fragment",
                SlangShaderResources.ShaderType.Fragment => "fragment",
                SlangShaderResources.ShaderType.Compute => "compute",
                _ => throw new AngeneException($"Unknown stage for shader '{shader.Name}'")
            };

            string cachePath = Path.Combine(
                Engine.Instance.settingsInstance.GetSetting<string>("Graphics.ShaderDirectory"),
                $"{shader.Name}-Angene-{shader.Type}-{shader.id}-{shader.Origin}.spv.cache");

            byte[] code = null;

            if (CompileToFile && File.Exists(cachePath))
            {
                if (!TryLoadVerifiedShaderFile(cachePath, out code))
                {
                    Logger.LogDebug($"Cached SPIR-V for '{shader.Name}' failed verification, recompiling.", LoggingTarget.Graphics);
                    code = NativeSlangMemoryCompiler.CompileShaderFromMemorySpirv(shader.Code, shader.EntryPoint, stage);
                    byte[] intBytes = BitConverter.GetBytes(code.Length);
                    byte[] fileData = new byte[intBytes.Length + 1 + code.Length + 1];
                    Buffer.BlockCopy(intBytes, 0, fileData, 0, intBytes.Length);
                    fileData[intBytes.Length] = 0xAF;
                    Buffer.BlockCopy(code, 0, fileData, intBytes.Length + 1, code.Length);
                    fileData[intBytes.Length + 1 + code.Length] = 0xAA;

                    try
                    {
                        string dir = Path.GetDirectoryName(cachePath);
                        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                            Directory.CreateDirectory(dir);

                        File.WriteAllBytes(cachePath, fileData);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogWarning($"Failed to write shader cache '{cachePath}': {ex.Message}", LoggingTarget.Graphics);
                    }
                }
            }
            else if (CompileToFile)
            {
                code = NativeSlangMemoryCompiler.CompileShaderFromMemorySpirv(shader.Code, shader.EntryPoint, stage);
                byte[] intBytes = BitConverter.GetBytes(code.Length);
                byte[] fileData = new byte[intBytes.Length + 1 + code.Length + 1];
                Buffer.BlockCopy(intBytes, 0, fileData, 0, intBytes.Length);
                fileData[intBytes.Length] = 0xAF;
                Buffer.BlockCopy(code, 0, fileData, intBytes.Length + 1, code.Length);
                fileData[intBytes.Length + 1 + code.Length] = 0xAA;

                try
                {
                    string dir = Path.GetDirectoryName(cachePath);
                    if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    File.WriteAllBytes(cachePath, fileData);
                }
                catch (Exception ex)
                {
                    Logger.LogWarning($"Failed to write shader cache '{cachePath}': {ex.Message}", LoggingTarget.Graphics);
                }
            }
            else
            {
                code = NativeSlangMemoryCompiler.CompileShaderFromMemorySpirv(shader.Code, shader.EntryPoint, stage);
            }

            unsafe
            {
                fixed (byte* pCode = code)
                {
                    var createInfo = new VkShaderModuleCreateInfo
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO,
                        codeSize = (nuint)code.Length,
                        pCode = (uint*)pCode
                    };

                    IntPtr module;
                    VkResult result = Vulkan.Interop.Methods.vkCreateShaderModule(devicePtr, &createInfo, null, &module);
                    if (result != VkResult.VK_SUCCESS)
                        throw new AngeneException($"Failed to create shader module for '{shader.Name}': {result}");

                    var wrapped = new VkShader(shader.Name, shader.Type, null, module, shader.id, code);
                    Engine.Instance.ShaderCache ??= new Dictionary<int, SlangShaderResources.IShader>();
                    Engine.Instance.ShaderCache[shader.id] = wrapped;
                }
            }
        }

        private static bool TryLoadVerifiedShaderFile(string path, out byte[] code)
        {
            code = null;
            try
            {
                byte[] fileData = File.ReadAllBytes(path);
                if (fileData.Length < 6) // 4 (length) + 1 (0xAF) + 1 (0xAA) minimum
                    return false;

                int length = BitConverter.ToInt32(fileData, 0);
                if (length < 0 || fileData.Length != 4 + 1 + length + 1)
                    return false; // size doesn't line up with the declared length -> corrupt/truncated

                if (fileData[4] != 0xAF)
                    return false; // start marker missing

                if (fileData[4 + 1 + length] != 0xAA)
                    return false; // end marker missing

                code = new byte[length];
                Buffer.BlockCopy(fileData, 5, code, 0, length);
                return true;
            }
            catch (IOException)
            {
                return false;
            }
            catch (Exception ex)
            {
                Logger.LogDebug($"Failed to verify shader file '{path}': {ex.Message}", LoggingTarget.Graphics);
                return false;
            }
        }


    }
    internal class ShaderCompilationScene : IScene
    {
        public object Instance { get; private set; }
        public List<Entity> Entities { get; private set; } = new List<Entity>();
        public string Name => "ShaderCompilationScene";

        private readonly List<SlangShaderResources.IShader> _shaderTypes;
        private int _shaderCount;
        private bool _verbose;
        public double _timeElapsed;
        public int _shaderNum;
        public bool _started;
        public bool _done;
        private IntPtr _devicePtr;
        private Window _compilationWindow;
        private IntPtr _hwnd;
        private Window _thisWindow;

        public ShaderCompilationScene(List<SlangShaderResources.IShader> shaderTypes, int shaderCount, IntPtr devicePtr, Window compilationWindow, object handle, Window thisWindow, bool verbose)
        { 
            _shaderTypes = shaderTypes;
            _verbose = verbose;
            _shaderCount = shaderCount;
            _timeElapsed = 0;
            _shaderNum = 0;
            _started = false;
            _devicePtr = devicePtr;
            _compilationWindow = compilationWindow;
            _hwnd = ((MicrosoftWindowHandle)handle).Hwnd;
            _thisWindow = thisWindow;
        }

        public void Initialize()
        {
            Instance = this;
            _started = true;
            _done = false;
            Engine.Instance.IsCompilingShaders = true;
        }
        public void OnMessage(nint msgPtr) { } // Not needed for this scene

        public void Render()
        {
            IntPtr dc = User32.GetDC(_hwnd);
            if (dc == IntPtr.Zero) return;

            try
            {
                int centerx = 320;
                int centery = 240;
                using var r = new GdiRenderer(dc);
                r.BeginFrame(640, 480);
                r.Clear(0, 0.51f, 0.58f, 0.72f);

                r.DrawText(centerx, centery - 100, "Please Wait..", 0x0);
                if (!_started && !_done)
                {
                    r.DrawText(centerx, centery - 70, "Waiting for Initialization..", 0x00FF0000);
                } else
                {
                    if (_shaderNum < _shaderCount)
                    {
                        _timeElapsed = 0;
                        r.DrawText(centerx, centery - 70, "Running...", 0x0F0);
                        SlangShaderResources.IShader current = _shaderTypes[_shaderNum];
                        Logger.LogDebug($"Shader num {_shaderNum}/{_shaderCount - 1} (_shaderTypes Max: {_shaderTypes.Count})", LoggingTarget.Graphics);
                        switch (current.Origin)
                        {
                            case SlangShaderResources.ShaderOrigin.Dx11:
                                if (current.VerboseLog)
                                    Logger.LogDebug($"Compiling Dx11 shader '{current.Name}' to ID {current.id}..", LoggingTarget.Graphics);
                                CompileDx11Shader(current, _devicePtr, current.compileToFile);
                                break;
                            case SlangShaderResources.ShaderOrigin.Vulkan:
                                if (current.VerboseLog)
                                    Logger.LogDebug($"Compiling Vulkan shader '{current.Name}' to ID {current.id}..", LoggingTarget.Graphics);
                                CompileVulkanShader(current, _devicePtr, current.compileToFile);
                                break; 
                        }
                        
                        _shaderNum++;
                    }
                    else
                    {
                        _done = true;
                        Engine.Instance.IsCompilingShaders = false;
                        Cleanup();
                    }
                }
                r.DrawText(centerx, centery, $"Compiled {_shaderNum}/{_shaderCount} Shaders..", 0x0);

                r.EndFrame();
            }
            finally
            {
                User32.ReleaseDC(_hwnd, dc);
            }
        }

        private static bool TryLoadVerifiedShaderFile(string path, out byte[] code)
        {
            code = null;
            try
            {
                byte[] fileData = File.ReadAllBytes(path);
                if (fileData.Length < 6) // 4 (length) + 1 (0xAF) + 1 (0xAA) minimum
                    return false;

                int length = BitConverter.ToInt32(fileData, 0);
                if (length < 0 || fileData.Length != 4 + 1 + length + 1)
                    return false; // size doesn't line up with the declared length -> corrupt/truncated

                if (fileData[4] != 0xAF)
                    return false; // start marker missing

                if (fileData[4 + 1 + length] != 0xAA)
                    return false; // end marker missing

                code = new byte[length];
                Buffer.BlockCopy(fileData, 5, code, 0, length);
                return true;
            }
            catch (IOException)
            {
                return false;
            }
            catch (Exception ex)
            {
                Logger.LogDebug($"Failed to verify shader file '{path}': {ex.Message}", LoggingTarget.Graphics);
                return false;
            }
        }

        private void CompileVulkanShader(SlangShaderResources.IShader shader, IntPtr devicePtr, bool CompileToFile = false)
        {
            string stage = shader.Type switch
            {
                SlangShaderResources.ShaderType.Vertex => "vertex",
                SlangShaderResources.ShaderType.Pixel => "fragment",
                SlangShaderResources.ShaderType.Fragment => "fragment",
                SlangShaderResources.ShaderType.Compute => "compute",
                _ => throw new AngeneException($"Unknown stage for shader '{shader.Name}'")
            };

            string cachePath = Path.Combine(
                Engine.Instance.settingsInstance.GetSetting<string>("Graphics.ShaderDirectory"),
                $"{shader.Name}-Angene-{shader.Type}-{shader.id}-{shader.Origin}.spv.cache");

            byte[] code = null;

            if (CompileToFile && File.Exists(cachePath))
            {
                if (!TryLoadVerifiedShaderFile(cachePath, out code))
                {
                    Logger.LogDebug($"Cached SPIR-V for '{shader.Name}' failed verification, recompiling.", LoggingTarget.Graphics);
                    code = NativeSlangMemoryCompiler.CompileShaderFromMemorySpirv(shader.Code, shader.EntryPoint, stage);
                    byte[] intBytes = BitConverter.GetBytes(code.Length);
                    byte[] fileData = new byte[intBytes.Length + 1 + code.Length + 1];
                    Buffer.BlockCopy(intBytes, 0, fileData, 0, intBytes.Length);
                    fileData[intBytes.Length] = 0xAF;
                    Buffer.BlockCopy(code, 0, fileData, intBytes.Length + 1, code.Length);
                    fileData[intBytes.Length + 1 + code.Length] = 0xAA;

                    try
                    {
                        string dir = Path.GetDirectoryName(cachePath);
                        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                            Directory.CreateDirectory(dir);

                        File.WriteAllBytes(cachePath, fileData);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogWarning($"Failed to write shader cache '{cachePath}': {ex.Message}", LoggingTarget.Graphics);
                    }
                }
            }
            else if (CompileToFile)
            {
                code = NativeSlangMemoryCompiler.CompileShaderFromMemorySpirv(shader.Code, shader.EntryPoint, stage);
                byte[] intBytes = BitConverter.GetBytes(code.Length);
                byte[] fileData = new byte[intBytes.Length + 1 + code.Length + 1];
                Buffer.BlockCopy(intBytes, 0, fileData, 0, intBytes.Length);
                fileData[intBytes.Length] = 0xAF;
                Buffer.BlockCopy(code, 0, fileData, intBytes.Length + 1, code.Length);
                fileData[intBytes.Length + 1 + code.Length] = 0xAA;

                try
                {
                    string dir = Path.GetDirectoryName(cachePath);
                    if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    File.WriteAllBytes(cachePath, fileData);
                }
                catch (Exception ex)
                {
                    Logger.LogWarning($"Failed to write shader cache '{cachePath}': {ex.Message}", LoggingTarget.Graphics);
                }
            }
            else
            {
                code = NativeSlangMemoryCompiler.CompileShaderFromMemorySpirv(shader.Code, shader.EntryPoint, stage);
            }

            unsafe
            {
                fixed (byte* pCode = code)
                {
                    var createInfo = new VkShaderModuleCreateInfo
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO,
                        codeSize = (nuint)code.Length,
                        pCode = (uint*)pCode
                    };

                    IntPtr module;
                    VkResult result = Vulkan.Interop.Methods.vkCreateShaderModule(devicePtr, &createInfo, null, &module);
                    if (result != VkResult.VK_SUCCESS)
                        throw new AngeneException($"Failed to create shader module for '{shader.Name}': {result}");

                    var wrapped = new VkShader(shader.Name, shader.Type, null, module, shader.id, code);
                    Engine.Instance.ShaderCache ??= new Dictionary<int, SlangShaderResources.IShader>();
                    Engine.Instance.ShaderCache[shader.id] = wrapped;
                }
            }
        }
        private void CompileDx11Shader(SlangShaderResources.IShader shader, IntPtr devicePtr, bool CompileToFile = false)
        {
            string stage = shader.Type switch
            {
                SlangShaderResources.ShaderType.Vertex => "vertex",
                SlangShaderResources.ShaderType.Pixel => "pixel",
                SlangShaderResources.ShaderType.Compute => "compute",
                _ => throw new AngeneException($"Unknown stage for shader '{shader.Name}'")
            };

            string cachePath = Path.Combine(
                Engine.Instance.settingsInstance.GetSetting<string>("Graphics.ShaderDirectory"),
                $"{shader.Name}-Angene-{shader.Type}-{shader.id}-{shader.Origin}.cso");

            byte[] code = null;

            if (CompileToFile && File.Exists(cachePath))
            {
                // Cached file exists — verify it before trusting it, instead of blindly loading it.
                if (!TryLoadVerifiedShaderFile(cachePath, out code))
                {
                    Logger.LogDebug($"Cached shader file for '{shader.Name}' failed verification, recompiling.", LoggingTarget.Graphics);
                    code = NativeSlangMemoryCompiler.CompileShaderFromMemoryToFile(shader.Code, shader.EntryPoint, stage, cachePath, NativeSlangMemoryCompiler.ToShaderType.D3D11);
                }
            }
            else if (CompileToFile)
            {
                // No cache yet — compile and write the verified file for next time.
                code = NativeSlangMemoryCompiler.CompileShaderFromMemoryToFile(shader.Code, shader.EntryPoint, stage, cachePath, NativeSlangMemoryCompiler.ToShaderType.D3D11);
            }
            else
            {
                // Not using file caching at all.
                code = NativeSlangMemoryCompiler.CompileShaderFromMemoryD3D11(shader.Code, shader.EntryPoint, stage);
            }

            unsafe
            {
                fixed (byte* p = code)
                {
                    IntPtr nativeShader;
                    int hr = shader.Type == SlangShaderResources.ShaderType.Vertex ? D3D11.CreateVertexShader(devicePtr, (IntPtr)p, (nuint)code.Length, out nativeShader) : D3D11.CreatePixelShader(devicePtr, (IntPtr)p, (nuint)code.Length, out nativeShader);

                    if (hr < 0)
                        throw new AngeneException($"Failed to compile shader '{shader.Name}', (HRESULT: {hr:X8})");

                    if (code == null)
                        throw new AngeneException($"Failed to compile shader '{shader.Name}', Bytecode result is null.");
                    else
                        Logger.LogDebug($"Bytecode length: {code.Length}", LoggingTarget.MainGame);
                    var wrapped = new Dx11Shader(shader.Name, shader.Type, null, null, IntPtr.Zero, nativeShader, shader.id, code);
                    Engine.Instance.ShaderCache ??= new Dictionary<int, SlangShaderResources.IShader>();
                    Engine.Instance.ShaderCache[shader.id] = (SlangShaderResources.IShader)wrapped;
                }
            }
        }

        public void Cleanup()
        {
            _thisWindow.Close();
            _compilationWindow.Close();
        }
    }

    public class Window
    {
        public object Handle { get; private set; }

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

#if WINDOWS
        // Windows-specific fields
        private string _instanceConnectionString;
        private static readonly User32.WndProcDelegate s_wndProc = DefaultWndProc;
#endif
#if LINUX
        public nuint wmDeleteAtom, wmPingAtom;
#endif
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
#if WINDOWS
            if (config.cTI)
            {
                _instanceConnectionString = config.cTS;
            }
            else
            {
                _instanceConnectionString = null;
            }
#endif

            Handle = CreateWindow(config, config.cTI, config.cTS, config.cTT);
            if (Handle.GetType() != typeof(String))
            {
                WindowMap[Handle] = this;
            }
            else
            {
                WindowMap[Handle] = this;
            }
            Engine.Instance.OpenWindows.Add(this);

            string initToken = Guid.NewGuid().ToString("N");
            Engine.Instance.settingsInstance.SetSetting("Main.OTT", initToken); // One Time Token
            var mgmtScene = new Angene.Management.ManagementScene(initToken);
            AddScene(mgmtScene);

            if (!config.cTI)
            {
#if WINDOWS
                if (config.renderMode == RenderType.D3D11 && Engine.Instance.SharedD3D11Device != IntPtr.Zero)
                    graphicsContext = GraphicsContextFactory.Create(Handle, config.Width, config.Height, (int)config.renderMode,
                        Engine.Instance.SharedD3D11Device, Engine.Instance.SharedD3D11Context);
                else
                    graphicsContext = GraphicsContextFactory.Create(Handle, config.Width, config.Height, (int)config.renderMode);
#else
                graphicsContext = GraphicsContextFactory.Create(Handle, config.Width, config.Height, (int)config.renderMode);
#endif
            }
#if WINDOWS
            else
            {
                graphicsContext = GraphicsContextFactory.CreateWS((string)Handle, config.Width, config.Height);
                var streamer = new Websocket.WebStreamer(this);
                _screenPlay = streamer;
                RegisterWebSocketInput();
            }
#endif
            Logger.LogDebug("Window created successfully", LoggingTarget.Engine);
        }

        private int CheckSceneIndexOf(IScene scene)
        {
            if (scene.Name == "ManagementScene")
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
                Logger.LogError("Attempted to set null scene", LoggingTarget.Engine);
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

            Logger.LogDebug($"Primary scene set to '{scene.GetType().Name}'", LoggingTarget.Engine);
        }

        /// <summary>
        /// Add an additional scene to the window.
        /// </summary>
        public void AddScene(IScene scene)
        {
            if (scene == null)
            {
                Logger.LogError("Attempted to add nil scene", LoggingTarget.Engine);
                return;
            }

            foreach (var e in Scenes)
            {
                if (e == scene)
                {
                    Logger.LogWarning("Attempted to add a scene that is already in the scene list", LoggingTarget.Engine);
                    return;
                }
            }

            if (scene is Management.ManagementScene && ManagementScene == null)
            {
                Logger.LogDebug("Recieved a new ManagementScene call. Verifying...", LoggingTarget.Engine);
                // Silently add without logging, but check signatures.
                List<Entity> e = scene.GetEntities(); // If this throws a new Entity of 'ManagementCheck$o7' (creating entity of this name would fail), then we have passed.
                if (e != null && e.Count == 1)
                {
                    if (e[0].name == Engine.Instance.settingsInstance.GetSetting("Main.OTT").ToString())
                    {
                        e[0].name = "Ent1"; // Rename to indicate success, set management scene, and fail on all other occurances of a Management Scene.
                        Engine.Instance.settingsInstance.SetSetting("Main.OTT", null); // Clear the one time token to prevent reuse
                        ManagementScene = scene;
                        scene.Initialize();
                        Logger.LogDebug("ManagementScene attached successfully.", LoggingTarget.Engine);
                    }
                }
                return;
            }

            Scenes.Add(scene);
            scene.Initialize();
            Logger.LogDebug($"Scene '{scene.GetType().Name}' added to window", LoggingTarget.Engine);
        }

        /// <summary>
        /// Remove a scene from the window.
        /// </summary>
        public void RemoveScene(IScene scene)
        {
            if (scene == null)
            {
                Logger.LogWarning("Attempted to remove null scene", LoggingTarget.Engine);
                return;
            }

            int index = CheckSceneIndexOf(scene);
            if (index == -1)
            {
                Logger.LogWarning("The scene to be removed was not found in the current scene list", LoggingTarget.Engine);
                return;
            } 
            else if (index == -2)
            {
                Logger.LogError($"The scene to be removed is a fundamental part of Angene and cannot be removed. (Attempted to remove '{scene.Name}'.)", LoggingTarget.Engine);
                return;
            }

            Scenes.RemoveAt(index);
            scene.Cleanup();

            if (PrimaryScene == scene)
            {
                PrimaryScene = Scenes.Count > 0 ? Scenes[0] : null;
            }

            Logger.LogDebug($"Scene '{scene.GetType().Name}' removed from window", LoggingTarget.Engine);
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
                Logger.LogDebug($"Engine mode changed to: {mode}", LoggingTarget.Engine);
            }
        }

        /// <summary>
        /// Get the current engine mode.
        /// </summary>
        public EngineMode GetEngineMode()
        {
            return _engineMode;
        }

#if WINDOWS
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
                        hwnd = ((MicrosoftWindowHandle)Handle).Hwnd is IntPtr h ? h : IntPtr.Zero,
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
                    Logger.LogDebug($"Failed to process input packet: {ex.Message}", LoggingTarget.Engine);
                }
            };
        }
#endif

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

        private object CreateWindow(WindowConfig config, bool cTI, string cTS, object type)
        {
            if (!Engine.Instance.supportedLibs.Contains("Graphics"))
                Logger.LogCritical("Graphics library was not found at init. Please check your installation.", LoggingTarget.Engine, new AngeneException("Graphics library was not found at init. Installation is corrupt or incomplete."), true);
#if WINDOWS
            if (!Engine.Instance.supportedLibs.Contains("Windows"))
                Logger.LogCritical("Windows library was not found at init. Please check your installation.", LoggingTarget.Engine, new AngeneException("Windows library was not found at init. Installation is corrupt or incomplete."), true);
            return CreateWindowWindows(config, cTI, cTS, type);
#else
            if (!Engine.Instance.InitializedXThreads)
                Engine.Instance.XInitThreads();
            if (!Engine.Instance.supportedLibs.Contains("X11"))
                Logger.LogCritical("X11 library was not found at init. Please check your installation.", LoggingTarget.Engine, new AngeneException("X11 library was not found at init. Installation is corrupt or incomplete."), true);
            return CreateWindowX11(config, cTI, cTS, type);
#endif
        }

#if WINDOWS
        // windows apis
        private static object CreateWindowWindows(WindowConfig config, bool cTI, string cTS, object type)
        {
            if (cTI && cTS != null && type != null)
            {
                // use strings to shut up the compiler
                if ((string)type == "ws" || (string)type == "websocket")
                {
                    Logger.LogWarning("\r\n __    __   ______   __     ________ \r\n|  \\  |  \\ /      \\ |  \\   |        \\\r\n| $$  | $$|  $$$$$$\\| $$    \\$$$$$$$$\r\n| $$__| $$| $$__| $$| $$      | $$   \r\n| $$    $$| $$    $$| $$      | $$   \r\n| $$$$$$$$| $$$$$$$$| $$      | $$   \r\n| $$  | $$| $$  | $$| $$_____ | $$   \r\n| $$  | $$| $$  | $$| $$     \\| $$   \r\n \\$$   \\$$ \\$$   \\$$ \\$$$$$$$$ \\$$   ", LoggingTarget.Engine);
                    Logger.LogWarning("You have opted to start a websocket for window streaming. This is highly discouraged but you shall continue. Work with caution fellow developer.", LoggingTarget.Engine);
                    Logger.LogWarning("If the game developer does NOT allow this, the process will be terminated, commencing check.", LoggingTarget.Engine);

                    // check settings
                    Settings settings = Engine.Instance.settingsInstance;
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
                Logger.LogDebug($"Window({hwnd}) shown", LoggingTarget.Engine);
                User32.UpdateWindow(hwnd);
                return new MicrosoftWindowHandle(hwnd);

            }
            return IntPtr.Zero;
        }

        private const int RENDER_TIMER_ID = 1;
        private static IntPtr DefaultWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            // Render throughout resize and moving
            if (msg == (uint)WM.ENTERSIZEMOVE)
            {
                User32.SetTimer(hWnd, RENDER_TIMER_ID, 16, IntPtr.Zero); // ~60 FPS while dragging/resizing
                return IntPtr.Zero;
            }

            if (msg == (uint)WM.EXITSIZEMOVE)
            {
                User32.KillTimer(hWnd, RENDER_TIMER_ID);
                return IntPtr.Zero;
            }

            if (msg == (uint)WM.TIMER && (int)wParam == RENDER_TIMER_ID)
            {
                if (WindowMap.TryGetValue(hWnd, out var movingWin))
                {
                    try
                    {
                        movingWin.RenderFrame();
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError($"Exception rendering during move/resize: {ex.Message}", LoggingTarget.Engine);
                    }
                }
                return IntPtr.Zero;
            }

            if (msg == (uint)WM.SIZE)
            {
                if (WindowMap.TryGetValue(hWnd, out var sizedWin))
                {
                    int newWidth = (int)(lParam.ToInt64() & 0xFFFF);
                    int newHeight = (int)((lParam.ToInt64() >> 16) & 0xFFFF);
                    if (newWidth > 0 && newHeight > 0)
                        sizedWin.Graphics?.Resize(newWidth, newHeight);
                }
            }

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
                        Logger.LogError($"Exception in scene OnMessage: {ex.Message}", LoggingTarget.Engine);
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
                if (WindowMap.TryGetValue(hWnd, out var destroyedWin))
                {
                    WindowMap.Remove(hWnd);
                    Engine.Instance.OpenWindows.Remove(destroyedWin);
                }

                return IntPtr.Zero;
            }

            return User32.DefWindowProcW(hWnd, msg, wParam, lParam);
        }
#endif

        public void RenderFrame()
        {
#if WINDOWS
            if (graphicsContext is IDX11GraphicsContext dx11)
            {
                dx11.BeginFrame(0xFF202020);
                try
                {
                    foreach (var scene in Scenes)
                    {
                        if (scene is IDX11Scene dx11Scene)
                            dx11Scene.Render(dx11);
                        else
                            scene.Render();
                    }
                }
                finally
                {
                    dx11.EndFrame();
                }

                return;
            }
#endif
            // Non-DX path: call each scene.Render()
            foreach (var scene in Scenes)
            {
                try
                {
                    scene.Render();
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Exception rendering scene '{scene?.Name}': {ex.Message}", LoggingTarget.Engine);
                }
            }

            // Try to present the final buffer for non-DX graphics contexts.
            // Present takes the window handle; some contexts may ignore the handle if not needed.
            try
            {
                if (graphicsContext != null)
                {
                    if (Handle is MicrosoftWindowHandle)
                        graphicsContext.Present(((MicrosoftWindowHandle)Handle).Hwnd);
                    else
                        graphicsContext.Present(IntPtr.Zero);
                }
            }
            catch (Exception ex)
            {
                Logger.LogDebug($"Present failed in RenderFrame: {ex.Message}", LoggingTarget.Engine);
            }
        }

#if LINUX
        // Linux specific api stuff
        private unsafe X11WindowHandle CreateWindowX11(WindowConfig config, bool cTI, string cTS, object type)
        {
            if (cTI && cTS != null && type != null)
            {
                Logger.LogError("Websocket streaming is not supported on Linux yet.", LoggingTarget.Engine);
                return new X11WindowHandle(null, IntPtr.Zero, null);
            }
            else
            {
                if (Engine.Instance.SharedX11Display == null)
                {
                    Engine.Instance.SharedX11Display = Methods.XOpenDisplay(null);
                    if (Engine.Instance.SharedX11Display == null)
                    {
                        Logger.LogCritical("Failed to open X11 display. Ensure that the DISPLAY environment variable is set correctly.", LoggingTarget.Engine, new AngeneException("Failed to open X11 display."), true);
                    }
                }
                nuint window = Methods.XCreateSimpleWindow(Engine.Instance.SharedX11Display, Methods.XDefaultRootWindow(Engine.Instance.SharedX11Display), config.X, config.Y, (uint)config.Width, (uint)config.Height, 0, 0x00000000, 0x00000000);
                sbyte* titlePtr = ToSBytePtr(config.Title);
                
                Methods.XStoreName(Engine.Instance.SharedX11Display, window, titlePtr);
                Methods.XSelectInput(Engine.Instance.SharedX11Display, window, (IntPtr)(XEventMask.KeyPressMask|XEventMask.KeyReleaseMask|XEventMask.ButtonPressMask|XEventMask.ButtonReleaseMask|XEventMask.PointerMotionMask|XEventMask.StructureNotifyMask));
                Methods.XMapWindow(Engine.Instance.SharedX11Display, window);

                // Say we can handle closing or some shit
                sbyte* deleteName = ToSBytePtr("WM_DELETE_WINDOW");
                sbyte* pingName = ToSBytePtr("_NET_WM_PING");
                wmDeleteAtom = Methods.XInternAtom(Engine.Instance.SharedX11Display, deleteName, 0);
                wmPingAtom  = Methods.XInternAtom(Engine.Instance.SharedX11Display, pingName, 0);
                
                nuint* protocols = stackalloc nuint[2];
                protocols[0] = wmDeleteAtom;
                protocols[1] = wmPingAtom;
                Marshal.FreeHGlobal((IntPtr)deleteName);
                Marshal.FreeHGlobal((IntPtr)pingName);

                Methods.XSetWMProtocols(Engine.Instance.SharedX11Display, window, protocols, 2);

                return new X11WindowHandle(Engine.Instance.SharedX11Display, (IntPtr)window, titlePtr);
            }
        }
        public unsafe static sbyte* ToSBytePtr(string myString)
        {
            // 1. Allocate space and copy the string data to unmanaged memory
            IntPtr unmanagedPtr = Marshal.StringToHGlobalAnsi(myString);
            sbyte* sbytePtr = (sbyte*)unmanagedPtr.ToPointer();

            // 2. Cast directly to an sbyte*
            return sbytePtr;
        }
#endif

        private bool _cleanedUp;

        public void Cleanup()
        {
            if (_cleanedUp) return;
            _cleanedUp = true;

            Logger.LogInfo("Cleaning up window resources", LoggingTarget.Engine);

            if (!is3D && graphicsContext != null)
                graphicsContext.Cleanup();

            foreach (IScene scene in Scenes)
                scene?.Cleanup();
        }
        /// <summary>
        /// Requests this window be closed. Frees this window's own scenes/graphics
        /// resources immediately.
        /// </summary>
        public void Close()
        {
            Cleanup();
            Engine.Instance.RequestClose(this);
        }

        internal unsafe void ReallyClose()
        {
            if (Handle is MicrosoftWindowHandle handle && handle.Hwnd != IntPtr.Zero)
            {
                WindowMap.Remove(handle);
                Engine.Instance.OpenWindows.Remove(this);
                User32.DestroyWindow(handle.Hwnd);
                if (Engine.Instance.OpenWindows.Count == 0)
                    Engine.Instance.ShouldShutdown = true;
            }
            else if (Handle is X11WindowHandle x11Handle && x11Handle.Display != null && x11Handle.Window != IntPtr.Zero)
            {
                WindowMap.Remove(x11Handle);
                Engine.Instance.OpenWindows.Remove(this);
                Cleanup();

                Methods.XLockDisplay(x11Handle.Display);
                try
                {
                    Methods.XDestroyWindow(x11Handle.Display, (nuint)x11Handle.Window);
                    Methods.XFlush(x11Handle.Display);
                }
                finally
                {
                    Methods.XUnlockDisplay(x11Handle.Display);
                }

                if (Engine.Instance.OpenWindows.Count == 0)
                    Engine.Instance.ShouldShutdown = true;
            }
            else if (Handle is string strHandle)
            {
                WindowMap.Remove(strHandle);
                Engine.Instance.OpenWindows.Remove(this);
            }
        }

        /// <summary>
        /// Process Window messages.
        /// Returns false when Quit/Destroy is received and cleans up.
        /// </summary>
        public unsafe bool ProcessMessages(object Handle, Action<object>[] injectedCalls = null)
        {
#if LINUX
            if (Handle is X11WindowHandle _handle)
            {
                while (Methods.XPending(_handle.Display) > 0)
                {
                    _XEvent xevent = default;
                    Methods.XNextEvent(_handle.Display, &xevent);

                    IntPtr eventWindowId = (IntPtr)xevent.xany.window;
                    Window target = WindowMap.Values
                        .FirstOrDefault(w => w.Handle is X11WindowHandle h && h.Window == eventWindowId);

                    if (target == null)
                        continue;

                    if (xevent.type == 33 /* ClientMessage */ &&
                        xevent.xclient.data.l[0] == (IntPtr)target.wmDeleteAtom)
                    {
                        target.Close();
                        continue;
                    }

                    if (injectedCalls != null)
                        foreach (var i in injectedCalls)
                            i(xevent.type);
                }

                Engine.Instance.FlushPendingCloses();
            }
#else
            if (Handle is MicrosoftWindowHandle)
            {
                while (User32.PeekMessageW(out var msg, IntPtr.Zero, 0, 0, Consts.PM_REMOVE))
                {
                    if (msg.message == (uint)WM.QUIT)
                    {
                        Close();
                        return false;
                    }
                    
                    if (injectedCalls != null)
                        foreach (Action<object> i in injectedCalls)
                            i(msg.message);

                    User32.TranslateMessage(ref msg);
                    User32.DispatchMessageW(ref msg);
                    Engine.Instance.FlushPendingCloses();
                }
            }
#endif
            return !Engine.Instance.ShouldShutdown;
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