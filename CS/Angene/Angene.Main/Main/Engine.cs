

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Angene.Common;
using Angene.Common.Settings;
using Angene.Essentials;
using Angene.Essentials.GraphicsContexts;
using Angene.Graphics;
using Angene.Graphics.SlangShader;
using Angene.Platform;
using static Angene.Vulkan.Interop.Enumerators;
using static Angene.Vulkan.Interop.Structs;
using static Angene.X11.Interop.XLib;

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
        public Dictionary<int, object> ShaderCache { get; internal set; }
        int shaderCount = 0;
        List<WindowConfig> WindowCreationQueue = new List<WindowConfig>([]);
        public bool IsCompilingShaders = false;
        public bool ShouldShutdown = false;

#if WINDOWS
        private LogConsoleWindow? _logConsole; // log window keepalive
#endif
        public IntPtr SharedD3D11Device { get; internal set; } = IntPtr.Zero;
        public IntPtr SharedD3D11Context { get; internal set; } = IntPtr.Zero;
        public unsafe _XDisplay* SharedX11Display { get; internal set; } = null;
        public bool InitializedXThreads { get; internal set; } = false;

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

#if LINUX
        public unsafe void XInitThreads()
        {
            if (SharedX11Display == null)
            {
                Logger.LogDebug("[Engine.cs | XInitThreads] Initializing X11 threads..", LoggingTarget.Engine);

                int result = Methods.XInitThreads();
                if (result == 0)
                    Logger.LogCritical("[Engine.cs | XInitThreads] Failed to initialize X11 threads. Please check your installation.", LoggingTarget.Engine, new AngeneException("Failed to initialize X11 threads. Installation is corrupt or incomplete."), true);

                InitializedXThreads = true;
                Logger.LogDebug("[Engine.cs | XInitThreads] Successfully initialized X11 threads.", LoggingTarget.Engine);
            }
        }
#endif
        
        internal unsafe static void destroyInstances()
        {
#if WINDOWS
            if (Instance.SharedD3D11Device != IntPtr.Zero) { Marshal.Release(Instance.SharedD3D11Device); Instance.SharedD3D11Device = IntPtr.Zero; }
            if (Instance.SharedD3D11Context != IntPtr.Zero) { Marshal.Release(Instance.SharedD3D11Context); Instance.SharedD3D11Context = IntPtr.Zero; }
            Instance._logConsole = null;
#endif
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
                bool usesVulkan = false;
                bool usesD3D11 = false;
                foreach (SlangShaderResources.IShader shader in shaderTypes)
                {
                    if (shader.Origin == SlangShaderResources.ShaderOrigin.Dx11)
                        usesD3D11 = true;
                    else if (shader.Origin == SlangShaderResources.ShaderOrigin.Vulkan)
                        usesVulkan = true;
                }
                Window _D3dwindow = null;
                IDX11GraphicsContext _D3Dgraphicscontext = null;
                Window _Vkwindow = null;
                VkGraphicsContext _Vkgraphicscontext = null;
                
#if WINDOWS
                if (usesD3D11)
                {
                    // alright im going to fucking hate this
                    // To generate d3d shaders, low and behold, you *have* to initialize it.
                    // So lets initialize it here then dispose of it after it is done.
                    WindowConfig _D3DW = new();
                    _D3DW.Width = 100; _D3DW.Height = 100;
                    _D3DW.X = -10000; _D3DW.Y = -10000;
                    _D3DW.Style = WindowManagement.WindowStyle.PopupWindow;
                    _D3DW.ShowOnCreate = true;
                    _D3DW.Title = "D3D11 Dummy Window | Ignore.";
                    _D3DW.renderMode = RenderType.D3D11;
                    _D3dwindow = new(_D3DW);
                    _D3Dgraphicscontext = _D3dwindow.Graphics as IDX11GraphicsContext;
                    if (_D3Dgraphicscontext == null)
                        Logger.LogCritical("[Engine.cs | StartShaderCompilation] Dummy D3D11 window is not using the correct backend. Failing.", LoggingTarget.MainConstructor, new AngeneException("Incorrect backend on D3D11 Window."), true);

                    if (SharedD3D11Device == IntPtr.Zero)
                    {
                        SharedD3D11Device = _D3Dgraphicscontext.Handle;
                        SharedD3D11Context = _D3Dgraphicscontext.ContextHandle;
                        Marshal.AddRef(SharedD3D11Device);
                        Marshal.AddRef(SharedD3D11Context);
                    }
                }
#endif
                if (usesVulkan)
                {

#if WINDOWS
                    Logger.LogCritical("Using Vulkan on Windows is not supported. Please use D3D11.", LoggingTarget.Engine, new AngeneException("Using Vulkan on Windows is not supported. Please use D3D11."), true);
#endif
#if LINUX

                    WindowConfig _VkW = new(); // Im literally copying the above for Vk
                    _VkW.Width = 100; _VkW.Height = 100;
                    _VkW.X = -10000; _VkW.Y = -10000;
                    _VkW.ShowOnCreate = true;
                    _VkW.Title = "Vulkan Dummy Window | Ignore.";
                    _VkW.renderMode = RenderType.Vulkan;
                    _Vkwindow = new (_VkW);
                    _Vkgraphicscontext = _Vkwindow.Graphics as VkGraphicsContext; // Vulkan n stuff
                    if (_Vkgraphicscontext == null)
                        Logger.LogCritical("[Engine.cs | StartShaderCompilation] Dummy Vulkan window is not using the correct backend. Failing.", LoggingTarget.MainConstructor, new AngeneException("Incorrect backend on Vulkan Window."), true);
#endif
                }

                // now start shader comp
                if (usesD3D11 && usesVulkan)
                {
#if WINDOWS
                    StartShaderCompilation(shaderTypes, shaderCount, _D3Dgraphicscontext.Handle, _D3dwindow, _Vkgraphicscontext.Handle, _Vkwindow, verbose);
#endif
                }
                else if (usesD3D11 && !usesVulkan)
                {
#if WINDOWS
                    StartShaderCompilation(shaderTypes, shaderCount, _D3Dgraphicscontext.Handle, _D3dwindow, null, null, verbose);
#endif
                }
                else if (!usesD3D11 && usesVulkan)
                {
                    StartShaderCompilation(shaderTypes, shaderCount, null, null, _Vkgraphicscontext.Handle, _Vkwindow, verbose);
                }
            }
        }

        private void StartShaderCompilation(List<SlangShaderResources.IShader> _shaderTypes, int _shaderCount, IntPtr? _D3DDevicePtr, Window? _D3DCompilationWindow, IntPtr? _VkDevicePtr, Window? _VkCompilationWindow, bool verbose = false)
        {
#if WINDOWS
            if (_D3DDevicePtr != null && _D3DCompilationWindow != null)
            {
                // Create a new window for showing progress
                WindowConfig _wD3D = new();
                _wD3D.Width = 640; _wD3D.Height = 480;
                _wD3D.Style = WindowManagement.WindowStyle.PopupWindow;
                _wD3D.ShowOnCreate = true;
                _wD3D.Title = "Angene Shader Compilation";
                _wD3D.renderMode = RenderType.GDI;
                Window _WindowInstanceD3D = new Window(_wD3D);

                IScene D3DScene = new Dx11ShaderCompilationScene(_shaderTypes, _shaderCount, (IntPtr)_D3DDevicePtr, _D3DCompilationWindow, _WindowInstanceD3D.Handle, _WindowInstanceD3D, verbose);
                _WindowInstanceD3D.SetScene(D3DScene);
                D3DScene.Initialize();
            }
#endif

            if (_VkDevicePtr != null && _VkCompilationWindow != null)
            {
                WindowConfig _wVk = new();
                _wVk.Width = 10; _wVk.Height = 10;
                _wVk.X = -10000; _wVk.Y = -10000;
                _wVk.ShowOnCreate = false;
                _wVk.Title = "Angene Shader Compilation";
                _wVk.renderMode = RenderType.Vulkan;
                Window _WindowInstanceVk = new Window(_wVk);

                IScene Vkscene = new VulkanShaderCompilationScene(_shaderTypes, _shaderCount, (IntPtr)_VkDevicePtr, _VkCompilationWindow, verbose, _WindowInstanceVk);
                _WindowInstanceVk.SetScene(Vkscene);
                Vkscene.Initialize();
            }
        }
    }

    internal class VulkanShaderCompilationScene : IScene
    {
        public object Instance { get; private set; }

        public List<Entity> Entities { get; private set; } = new List<Entity>();
        public Entity MainCamera { get; } = null;
        public string Name => "VulkanShaderCompilationScene";

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

        public VulkanShaderCompilationScene(List<SlangShaderResources.IShader> shaderTypes, int shaderCount, IntPtr devicePtr, Window compilationWindow, bool verbose, Window thisWindow)
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

                    var wrapped = new VkShader(shader.Name, shader.Type, null, shader.id, module, code);
                    Engine.Instance.ShaderCache ??= new Dictionary<int, object>();
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

#if WINDOWS
    internal class Dx11ShaderCompilationScene : IScene
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

        public Dx11ShaderCompilationScene(List<SlangShaderResources.IShader> shaderTypes, int shaderCount, IntPtr devicePtr, Window compilationWindow, object handle, Window thisWindow, bool verbose)
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
                    Engine.Instance.ShaderCache ??= new Dictionary<int, object>();
                    Engine.Instance.ShaderCache[shader.id] = wrapped;
                }
            }
        }

        public void Cleanup()
        {
            _thisWindow.Close();
            _compilationWindow.Close();
        }
    }
#endif
}