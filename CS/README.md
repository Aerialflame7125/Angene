![Angene Logo](https://github.com/Aerialflame7125/Angene/blob/main/AngeneLogoBig.png?raw=true)

# Angene

(pronounced 'engine')
Last updated 2026/07/22

The C# library/variant of Angene. If you want to skip the entire tree for the engine, skip to the [examples.](https://github.com/Aerialflame7125/Angene/blob/main/CS/README.md#Examples)

## Angene.Main

<details><summary><b>Angene.Crypto</b></summary>

* **class AesGcm**
  * `void Decrypt()`
  * `void Encrypt()`
  * `void Dispose()`

</details>

<details><summary><b>Angene.Examples</b></summary>

* **class Example1_BasicCube**
  * `void Initialize()`
  * `void Update()`
  * `void Render()`
  * `void Cleanup()`
* **class Example2_CustomShapes**
  * `void Initialize()`
  * `void Update()`
  * `void Render()`
  * `void Cleanup()`
* **class Example3_ShapesAndCamera**
  * `void Initialize()`
  * `void Update()`
  * `void Render()`
  * `void Cleanup()`
* **class Example4_ComplexScene**
  * `void Initialize()`
  * `void Update()`
  * `void Render()`
  * `void Cleanup()`

</details>

<details><summary><b>Angene.External</b></summary>

* **class DiscordPresenceState**
  * `string? State { get; set; }`
  * `string? Details { get; set; }`
  * `string? LargeImageKey { get; set; }`
  * `string? LargeImageText { get; set; }`
  * `string? SmallImageKey { get; set; }`
  * `string? SmallImageText { get; set; }`
  * `Button[]? Buttons { get; set; }`
  * `void SetPresence()`
  * `void Clear()`
  * `void Dispose()`
* **class DiscordRichPresence**

</details>

<details><summary><b>Angene.Main</b></summary>

* **class Console**
  * `void WriteLine()`
  * `void ReadLine()`
  * `void Write()`
* **class Engine**
  * `bool IsCompilingShaders`
  * `IntPtr SharedD3D11Device { get; set; }`
  * `IntPtr SharedD3D11Context { get; set; }`
  * `Engine Instance { get; set; }`
  * `void FlushPendingCloses()`
  * `void Init()`
  * `object Instance { get; set; }`
  * `List<Entity> Entities { get; set; }`
  * `string Name { get; set; }`
  * `double _timeElapsed`
  * `int _shaderNum`
  * `bool _started`
  * `bool _done`
  * `void Initialize()`
  * `void OnMessage()`
  * `void Render()`
  * `void Cleanup()`
* **class Framebuffer**
  * `int Width { get; set; }`
  * `int Height { get; set; }`
  * `IntPtr BufferPtr { get; set; }`
  * `void Clear()`
  * `void Dispose()`
  * `List<WebSocket> ActiveClients`
* **class LogConsoleWindow**
  * `void AppendLine()`
* **class ManifestEntry**
  * `string Path { get; set; }`
  * `long Offset { get; set; }`
  * `long Length { get; set; }`
  * `bool Compressed { get; set; }`
  * `bool Encrypted { get; set; }`
  * `string Nonce { get; set; }`
  * `string Tag { get; set; }`
* **class Package**
  * `IReadOnlyList<ManifestEntry> Entries { get; set; }`
  * `Package Open()`
  * `void ExtractTo()`
  * `Stream OpenStream()`
  * `void Dispose()`
  * `ManifestEntry[] Files { get; set; }`
  * `DateTime Created { get; set; }`
* **class WebStreamer**
  * `void Start()`
  * `void LateUpdate()`
* **class Window**
  * `object Hwnd { get; set; }`
  * `List<IScene> Scenes { get; set; }`
  * `IScene? PrimaryScene { get; set; }`
  * `IScene ManagementScene { get; set; }`
  * `int Width { get; set; }`
  * `int Height { get; set; }`
  * `IScreenPlay? _screenPlay`
  * `void SetScene()`
  * `void AddScene()`
  * `void RemoveScene()`
  * `void SetEngineMode()`
  * `EngineMode GetEngineMode()`
  * `bool ProcessMessages()`
  * `void Cleanup()`
  * `void Close()`
* **struct PlatformMessage**
  * `IntPtr hwnd`
  * `uint message`
  * `IntPtr wParam`
  * `IntPtr lParam`
  * `IGraphicsContext? Graphics { get; set; }`

</details>

<details><summary><b>Angene.Platform</b></summary>

* **class PlatformDetection**
  * `bool IsWindows { get; set; }`
  * `bool IsLinux { get; set; }`
  * `bool IsMacOS { get; set; }`
* **class WindowConfig**
  * `string Title { get; set; }`
  * `int Width { get; set; }`
  * `int Height { get; set; }`
  * `int X { get; set; }`
  * `int Y { get; set; }`
  * `bool cTI { get; set; }`
  * `string cTS { get; set; }`
  * `string cTT { get; set; }`
  * `RenderType renderMode`
  * `bool ShowOnCreate { get; set; }`
  * `WindowConfig Standard()`
  * `WindowConfig TransparentOverlay()`
  * `WindowConfig Borderless()`
  * `WindowConfig Rendering3D()`

</details>

<details><summary><b>Angene.Protection</b></summary>

* **class Integrity**
  * `byte[] ComputeCurrentAssemblyHash()`
  * `void AssertAssemblyHash()`

</details>

## Angene.Audio
* **class AudioFile**
  * `LoadType _loadType`
* **class AudioManager**
  * `bool IsPlaying { get; set; }`
  * `bool IsPaused { get; set; }`
  * `float Volume { get; set; }`
  * `bool Looping { get; set; }`
  * `void Play()`
  * `void Stop()`
  * `void Pause()`
  * `void Resume()`
  * `void SetVolume()`
  * `void SetLooping()`
  * `void Dispose()`
* **enum LoadType**
  * `byte[] GetAudioBytes()`
  * `Stream GetAudioStream()`
  * `void Dispose()`
* **interface IAudioPlayer**

</details>

<details><summary><b>Angene.Audio.Common</b></summary>

* **class AudioFactory**
  * `IAudioPlayer Create()`

</details>

<details><summary><b>Angene.Audio.Windows</b></summary>

* **struct WAVEHDR**
  * `IntPtr lpData`
  * `uint dwBufferLength`
  * `uint dwBytesRecorded`
  * `IntPtr dwUser`
  * `uint dwFlags`
  * `uint dwLoops`
  * `IntPtr lpNext`
  * `IntPtr reserved`
* **struct WaveFormatEx**
  * `ushort wFormatTag`
  * `ushort nChannels`
  * `uint nSamplesPerSec`
  * `uint nAvgBytesPerSec`
  * `ushort nBlockAlign`
  * `ushort wBitsPerSample`
  * `ushort cbSize`

</details>

## Angene.Common
<details><summary><b>Angene.Common</b></summary>

* **class AngeneException**
* **class Attributes**
* **class Logger**
  * `Logger Instance`
  * `StreamWriter? LogInstance`
  * `bool _verbose`
  * `void Init()`
  * `void LogDebug()`
  * `void LogInfo()`
  * `void LogWarning()`
  * `void LogError()`
  * `void LogImportant()`
  * `void LogCritical()`
  * `void Shutdown()`
* **class PrecompileAttribute**
* **class TShader**
* **class TShaderMetadata**
  * `int Id`
  * `string ShaderName`
  * `TShaderType ShaderType`
  * `string Source`
  * `float ShaderRate`
  * `float Shade`
  * `bool CacheOnDevice`
* **class Types**
* **enum LoggingTarget**
* **enum TShaderType**

</details>

<details><summary><b>Angene.Common.Settings</b></summary>

* **class Settings**
  * `void LoadDefaults()`
  * `void Register()`
  * `object? GetSetting()`
  * `bool SetSetting()`
  * `string saveKeys()`

</details>

<details><summary><b>Angene.Globals</b></summary>

* **interface IRenderer**
* **interface IRenderer3D**

</details>

## Angene.Essentials
<details><summary><b>Angene.Essentials</b></summary>

* **class Entity**
  * `int Id { get; set; }`
  * `float x`
  * `float y`
  * `float z`
  * `string name`
  * `List<Entity> childEntities { get; set; }`
  * `void AddScript()`
  * `void RemoveScript()`
  * `IReadOnlyList<object> GetScripts()`
  * `void SetEnabled()`
  * `bool IsEnabled()`
  * `void AddChild()`
  * `void RemoveChild()`
  * `bool IsParent()`
  * `Entity? GetParent()`
  * `void Remove()`
  * `void Destroy()`
  * `bool Equals()`
  * `int GetHashCode()`
  * `bool operator`
* **class Lifecycle**
  * `object Instance`
  * `Action? Awake`
  * `Action? OnEnable`
  * `Action? Start`
  * `Action<double>? Update`
  * `Action<double>? LateUpdate`
  * `Action? OnDraw`
  * `Action? OnDisable`
  * `Action? OnDestroy`
  * `Action<IntPtr>? OnMessage`
  * `Action? Render`
  * `Action? Cleanup`
  * `bool AwakeCalled`
  * `bool Enabled`
  * `bool StartCalled`
  * `bool Destroyed`
* **class ScriptBinding**
  * `List<Action> destroyEngineList`
  * `void Tick()`
  * `void Draw()`
  * `void HandleEntityCreated()`
  * `void DestroyEntity()`
  * `void SetEntityEnabled()`
  * `void RegisterScript()`
  * `void ShutdownEngine()`
* **enum EngineMode**
* **interface IScene**
  * `List<Entity> GetEntities()`
  * `void AddEntity()`
  * `void RemoveEntity()`
* **interface IScreenPlay**
* **struct LifecycleInfo**
  * `bool HasUpdate`
  * `bool HasLateUpdate`
  * `bool HasOnDraw`
  * `bool HasStart`

</details>

## Angene.Graphics
<details><summary><b>Angene.Graphics</b></summary>

* **class Defs**
* **class FailedToCreateGraphicsBackendException**
* **class GdiGraphicsContext**
  * `IntPtr Handle { get; set; }`
  * `void Resize()`
  * `void Clear()`
  * `void DrawRectangle()`
  * `void DrawText()`
  * `void Present()`
  * `void Cleanup()`
  * `byte[] GetRawPixels()`
  * `void Dispose()`
* **class GdiRenderer**
  * `void BeginFrame()`
  * `void Clear()`
  * `void DrawRect()`
  * `void DrawText()`
  * `void EndFrame()`
  * `void Dispose()`
* **class GraphicsContextFactory**
  * `IGraphicsContext Create()`
  * `IGraphicsContext CreateWS()`
* **class GraphicsException**
* **class WSGraphicsContext**
  * `IntPtr Handle { get; set; }`
  * `void Resize()`
  * `void Clear()`
  * `void DrawRectangle()`
  * `void DrawText()`
  * `void Cleanup()`
  * `byte[] GetRawPixels()`
  * `void Present()`
* **enum RenderType**
* **interface IDX11GraphicsContext**
* **interface IGraphicsContext**
* **struct Color**
* **struct Edge**
  * `float XAtY0`
  * `float Slope`
* **struct InputElement**
  * `string SemanticName`
  * `uint SemanticIndex`
  * `DXGI_FORMAT Format`
  * `uint ByteOffset`

</details>

<details><summary><b>Angene.Graphics.DX11</b></summary>

* **class DX11GraphicsContext**
  * `IntPtr ContextHandle { get; set; }`
  * `nint Handle { get; set; }`
  * `void Resize()`
  * `void Clear()`
  * `void Present()`
  * `byte[] GetRawPixels()`
  * `void Cleanup()`
  * `void Dispose()`
  * `IntPtr CreateVertexBuffer()`
  * `IntPtr CreateVertexShader()`
  * `IntPtr CreatePixelShader()`
  * `IntPtr CreateInputLayout()`
  * `void SetVertexBuffer()`
  * `void DrawIndexed()`
  * `IntPtr CreateIndexBuffer()`
  * `void SetIndexBuffer()`
  * `void SetInputLayout()`
  * `void SetShader()`
  * `void Draw()`
  * `IntPtr CreateConstantBuffer()`
  * `void UpdateConstantBuffer()`
  * `void SetVertexShaderConstantBuffer()`
  * `IntPtr CreateRasterizerState()`
  * `void SetRasterizerState()`

</details>

<details><summary><b>Angene.Graphics.OpenGL</b></summary>

* **class Camera3D**
  * `float X { get; set; }`
  * `float Y { get; set; }`
  * `float Z { get; set; }`
  * `float Pitch { get; set; }`
  * `float Yaw { get; set; }`
  * `float Roll { get; set; }`
  * `void Apply()`
  * `void MoveForward()`
  * `void Strafe()`
  * `void MoveVertical()`
* **class OpenGlRenderer**
  * `bool IsInitialized { get; set; }`
  * `int Width { get; set; }`
  * `int Height { get; set; }`
  * `void Resize()`
  * `void BeginFrame()`
  * `void EndFrame()`
  * `void SetClearColor()`
  * `void Translate()`
  * `void Rotate()`
  * `void PushMatrix()`
  * `void PopMatrix()`
  * `void DrawCube()`
  * `void BeginDraw()`
  * `void EndDraw()`
  * `void SetColor()`
  * `void AddVertex()`
  * `void Dispose()`
* **class Shapes3D**
  * `void DrawWireCube()`
  * `void DrawSphere()`
  * `void DrawPlane()`
  * `void DrawPyramid()`
  * `void DrawAxes()`
  * `void DrawGrid()`
* **enum PrimitiveType**

</details>

<details><summary><b>Angene.Graphics.SlangShader</b></summary>

* **class BaseShader**
  * `string Name { get; set; }`
  * `bool IsDisposed { get; set; }`
  * `ShaderType Type { get; set; }`
  * `ShaderOrigin Origin { get; set; }`
  * `string OutputDebugInfo()`
  * `void Bind()`
  * `void Dispose()`
* **class Dx11Shader**
  * `int id { get; set; }`
  * `bool compileToFile { get; set; }`
  * `IntPtr NativeShader { get; set; }`
  * `ShaderOrigin Origin { get; set; }`
  * `string Code { get; set; }`
  * `string Extension { get; set; }`
  * `string EntryPoint { get; set; }`
  * `byte[] byteCode { get; set; }`
  * `void Bind()`
* **class NativeSlangMemoryCompiler**
  * `byte[] ToNullTerminatedUtf8()`
  * `byte[] CompileShaderFromMemoryToFile()`
* **class SlangShaderResources**
* **enum ShaderOrigin**
* **enum ShaderType**
* **interface IShader**

</details>

## Angene.Input
<details><summary><b>Angene.Input</b></summary>

* **class KeyDetection**
  * `List<Entity> Instances`
  * `void Register()`
  * `bool IsKeyDown()`
  * `void Deregister()`
  * `HashSet<object> GetDownKeys { get; set; }`
* **class MouseDetection**
  * `List<Entity> Instances`
  * `void Register()`
  * `bool IsButtonDown()`
  * `void Deregister()`
  * `bool IsInWindow()`

</details>

<details><summary><b>Angene.Input.WinInput</b></summary>

* **class Key**
  * `object TryInt()`
  * `object TryNInt()`
  * `object TryByte()`
* **enum IKeyCodeASCII**
* **enum IKeyCodeArrow**
* **enum IKeyCodeBrowser**
* **enum IKeyCodeFunc**
* **enum IKeyCodeGamePad**
* **enum IKeyCodeMedia**
* **enum IKeyCodeMod**
* **enum IKeyCodeMouse**
* **enum IKeyCodeNum**
* **enum IKeyCodeNumPad**
* **enum IKeyCodeOEM**
* **enum IKeyCodeSpecial**
* **struct Keys**

</details>

## Angene.Management
<details><summary><b>Angene.Management</b></summary>

* **class ManagementScene**
  * `object Instance { get; set; }`
  * `string Name { get; set; }`
  * `List<Entity> Entities { get; set; }`
  * `Entity AddEntity()`
  * `Entity RemoveScript()`
  * `Entity GetDefaultEntity()`
  * `void Cleanup()`
  * `List<Entity> GetEntities()`
  * `void Initialize()`
  * `void OnMessage()`
  * `void Render()`

</details>

## Angene.Math
<details><summary><b>Angene.Math</b></summary>

* **class Rand**
  * `void SetSeed()`
  * `float Value { get; set; }`
  * `float Range()`
  * `int Range()`
  * `bool Chance()`

</details>

<details><summary><b>Angene.Math.Defs</b></summary>

* **interface IComputeBackend**
* **interface IComputeJob<TInput**

</details>

<details><summary><b>Angene.Math.GPU</b></summary>

* **class Math**
  * `int GpuThreshold { get; set; }`
  * `Vec2[] Add()`
  * `Vec2[] Scale()`
  * `Vec2[] Normalize()`
  * `float[] Dot()`
  * `float[] Length()`
  * `Vec2[] Lerp()`
  * `Vec3[] Add()`
  * `Vec3[] Cross()`
  * `Vec3[] Normalize()`
  * `Vec2[] Transform()`
  * `Matrix3x3[] Multiply()`
  * `float[] Clamp()`
  * `float[] Lerp()`
  * `float[] Remap()`
  * `float[] Sqrt()`
  * `float[] Abs()`
  * `float Sum()`
  * `float Min()`
  * `float Max()`
  * `Vec2 Sum()`
  * `Vec2 Average()`
  * `void Dispose()`

</details>

<details><summary><b>Angene.Math.GraphicsMath</b></summary>

* **class GraphicsMath**
  * `IEnumerable<Point> GetPointsOnLine()`

</details>

<details><summary><b>Angene.Math.Interpolation</b></summary>

* **class Ease**
  * `float InQuad()`
  * `float OutQuad()`
  * `float InOutQuad()`
  * `float InCubic()`
  * `float OutCubic()`
  * `float InOutCubic()`
  * `float InBack()`
  * `float InBounce()`
  * `float InElastic()`
  * `float OutBack()`
  * `float OutBounce()`
  * `float OutElastic()`
* **class Mathf**
  * `float PI`
  * `float Deg2Rad`
  * `float Rad2Deg`
  * `float Clamp()`
  * `float Clamp01()`
  * `float Remap()`
  * `float Lerp()`
  * `float LerpUnclamped()`
  * `float InverseLerp()`
  * `float SmoothStep()`
  * `float SmootherStep()`
  * `float MoveTowards()`
  * `float SmoothDamp()`
  * `float DeltaAngle()`
  * `float LerpAngle()`

</details>

<details><summary><b>Angene.Math.Vectors</b></summary>

* **struct Matrix3x3**
  * `Matrix3x3 Identity { get; set; }`
  * `Matrix3x3 Translation()`
  * `Matrix3x3 Rotation()`
  * `Matrix3x3 Scale()`
* **struct Point**
* **struct Rect**
  * `float X`
  * `float Left { get; set; }`
  * `float Right { get; set; }`
  * `float Top { get; set; }`
  * `float Bottom { get; set; }`
  * `Vec2 Center { get; set; }`
  * `bool Contains()`
  * `bool Intersects()`
  * `Rect Expand()`
* **struct Vec2**
  * `float X`
  * `Vec2 Zero { get; set; }`
  * `Vec2 One { get; set; }`
  * `Vec2 Up { get; set; }`
  * `Vec2 Down { get; set; }`
  * `Vec2 Left { get; set; }`
  * `Vec2 Right { get; set; }`
  * `float Length { get; set; }`
  * `float LengthSquared { get; set; }`
  * `Vec2 Normalized { get; set; }`
  * `float Dot()`
  * `float Distance()`
  * `Vec2 Lerp()`
  * `Vec2 Reflect()`
* **struct Vec3**
  * `float X`
  * `float Length { get; set; }`
  * `Vec3 Normalized { get; set; }`
  * `float Dot()`
  * `Vec3 Cross()`
  * `Vec3 Lerp()`

</details>

## Angene.Windows
<details><summary><b>Angene.Windows</b></summary>

* **class Consts**
  * `uint WS_POPUP`
  * `uint WS_EX_LAYERED`
  * `uint WS_EX_TRANSPARENT`
  * `uint WS_EX_TOPMOST`
  * `int LWA_COLORKEY`
  * `int LWA_ALPHA`
  * `int GWL_EXSTYLE`
  * `uint IMAGE_ICON`
  * `uint LR_DEFAULTSIZE`
  * `uint LR_LOADFROMFILE`
  * `uint WM_SETICON`
  * `int ICON_SMALL`
  * `int ICON_BIG`
  * `uint LR_DEFAULTCOLOR`
  * `uint GR_GDIOBJECTS`
  * `int PM_REMOVE`
  * `int CW_USEDEFAULT`
  * `int SW_SHOW`
* **class Kernel32**
* **class SWP**
  * `uint NOSIZE`
  * `uint NOMOVE`
  * `uint NOZORDER`
  * `uint NOACTIVATE`
  * `uint SHOWWINDOW`
* **class User32**
* **class WS**
  * `uint OVERLAPPED`
  * `uint POPUP`
  * `uint CHILD`
  * `uint VISIBLE`
  * `uint DISABLED`
  * `uint CLIPSIBLINGS`
  * `uint CLIPCHILDREN`
  * `uint SYSMENU`
  * `uint THICKFRAME`
* **class WS_EX**
  * `uint TOPMOST`
  * `uint TOOLWINDOW`
  * `uint APPWINDOW`
  * `uint LAYERED`
  * `uint NOACTIVATE`
* **class WindowManagement**
* **enum EM**
* **enum WM**
* **enum WindowStyle**
* **enum WindowStyleEx**
* **struct MSG**
  * `IntPtr hwnd`
  * `uint message`
  * `IntPtr wParam`
  * `IntPtr lParam`
  * `uint time`
  * `int pt_x`
  * `int pt_y`
* **struct PAINTSTRUCT**
  * `IntPtr hdc`
  * `bool fErase`
  * `RECT rcPaint`
  * `bool fRestore`
  * `bool fIncUpdate`
  * `byte[] rgbReserved`
* **struct RECT**
  * `int left`
  * `int top`
  * `int right`
  * `int bottom`
* **struct SIZE**
  * `int cx`
  * `int cy`
* **struct TRACKMOUSEEVENT**
  * `uint cbSize`
  * `uint dwFlags`
  * `IntPtr hwndTrack`
  * `uint dwHoverTime`
* **struct WNDCLASSEX**
  * `uint cbSize`
  * `uint style`
  * `int cbClsExtra`
  * `int cbWndExtra`
  * `IntPtr hInstance`
  * `IntPtr hIcon`
  * `IntPtr hCursor`
  * `IntPtr hbrBackground`
  * `string lpszMenuName`
  * `string lpszClassName`
  * `IntPtr hIconSm`
* **struct WindowTransparency**
  * `bool Enabled`
  * `byte Alpha`
  * `bool ClickThrough`
  * `WindowTransparency None { get; set; }`
  * `WindowTransparency Opaque { get; set; }`
  * `WindowTransparency SemiTransparent { get; set; }`
  * `WindowTransparency FullyTransparent { get; set; }`

</details>

<details><summary><b>Angene.Windows.D3D11</b></summary>

* **class D3D11**
* **class D3D11Interop**
* **enum D3D11_BIND_FLAG**
* **enum D3D11_BLEND**
* **enum D3D11_BLEND_OP**
* **enum D3D11_COMPARISON_FUNC**
* **enum D3D11_COUNTER**
* **enum D3D11_COUNTER_TYPE**
* **enum D3D11_CPU_ACCESS_FLAG**
* **enum D3D11_CULL_MODE**
* **enum D3D11_DEPTH_WRITE_MASK**
* **enum D3D11_DEVICE_CONTEXT_TYPE**
* **enum D3D11_DSV_DIMENSION**
* **enum D3D11_FEATURE**
* **enum D3D11_FILL_MODE**
* **enum D3D11_FILTER**
* **enum D3D11_INPUT_CLASSIFICATION**
* **enum D3D11_MAP**
* **enum D3D11_PRIMITIVE_TOPOLOGY**
* **enum D3D11_QUERY**
* **enum D3D11_RESOURCE_DIMENSION**
* **enum D3D11_RTV_DIMENSION**
* **enum D3D11_STENCIL_OP**
* **enum D3D11_TEXTURE_ADDRESS_MODE**
* **enum D3D11_UAV_DIMENSION**
* **enum D3D11_USAGE**
* **enum D3D_DRIVER_TYPE**
* **enum D3D_FEATURE_LEVEL**
* **enum D3D_SRV_DIMENSION**
* **interface ID3D11DeviceChild**
* **interface ID3D11DeviceContext**
  * `void VSSetConstantBuffers()`
  * `void PSGetShaderResources()`
  * `void PSSetShader()`
  * `void PSSetSamplers()`
  * `void VSSetShader()`
  * `void DrawIndexed()`
  * `void Draw()`
  * `void Map()`
  * `void Unmap()`
  * `void PSSetConstantBuffers()`
  * `void IASetInputLayout()`
  * `void IASetVertexBuffers()`
  * `void IASetIndexBuffer()`
  * `void DrawIndexedInstanced()`
  * `void DrawInstanced()`
  * `void GSSetConstantBuffers()`
  * `void GSSetShader()`
  * `void IASetPrimitiveTopology()`
  * `void VSSetShaderResources()`
  * `void VSSetSamplers()`
  * `void Begin()`
  * `void End()`
  * `int GetData()`
  * `void SetPredication()`
  * `void GSSetShaderResources()`
  * `void GSSetSamplers()`
  * `void OMSetRenderTargets()`
  * `void OMSetRenderTargetsAndUnorderedAccessViews()`
  * `void OMSetBlendState()`
  * `void OMGetDepthStencilState()`
  * `void SOSetTargets()`
  * `void DrawAuto()`
  * `void DrawIndexedInstancedIndirect()`
  * `void DrawInstancedIndirect()`
  * `void Dispatch()`
  * `void DispatchIndirect()`
  * `void RSSetState()`
  * `void RSSetViewports()`
  * `void RSSetScissorRects()`
  * `void CopySubresourceRegion()`
  * `void CopyResource()`
  * `void UpdateSubresource()`
  * `void CopyStructureCount()`
  * `void ClearRenderTargetView()`
  * `void ClearUnorderedAccessViewUint()`
  * `void ClearUnorderedAccessViewFloat()`
  * `void ClearDepthStencilView()`
  * `void GenerateMips()`
  * `void SetResourceMinLOD()`
  * `float GetResourceMinLOD()`
  * `void ResolveSubresource()`
  * `void ExecuteCommandList()`
  * `void HSSetShaderResources()`
  * `void HSSetShader()`
  * `void HSSetSamplers()`
  * `void HSSetConstantBuffers()`
  * `void DSSetShaderResources()`
  * `void DSSetShader()`
  * `void DSSetSamplers()`
  * `void DSSetConstantBuffers()`
  * `void CSSetShaderResources()`
  * `void CSSetUnorderedAccessViews()`
  * `void CSSetShader()`
  * `void CSSetSamplers()`
  * `void CSSetConstantBuffers()`
  * `void VSGetConstantBuffers()`
  * `void PSSetShaderResources()`
  * `void PSGetShader()`
  * `void PSGetSamplers()`
  * `void VSGetShader()`
  * `void PSGetConstantBuffers()`
  * `void IAGetInputLayout()`
  * `void IAGetVertexBuffers()`
  * `void IAGetIndexBuffer()`
  * `void GSGetConstantBuffers()`
  * `void GSGetShader()`
  * `void IAGetPrimitiveTopology()`
  * `void VSGetShaderResources()`
  * `void VSGetSamplers()`
  * `void GetPredication()`
  * `void GSGetShaderResources()`
  * `void GSGetSamplers()`
  * `void OMGetRenderTargets()`
  * `void OMGetRenderTargetsAndUnorderedAccessViews()`
  * `void OMGetBlendState()`
  * `void OMSetDepthStencilState()`
  * `void SOGetTargets()`
  * `void RSGetState()`
  * `void RSGetViewports()`
  * `void RSGetScissorRects()`
  * `void HSGetShaderResources()`
  * `void HSGetShader()`
  * `void HSGetSamplers()`
  * `void HSGetConstantBuffers()`
  * `void DSGetShaderResources()`
  * `void DSGetShader()`
  * `void DSGetSamplers()`
  * `void DSGetConstantBuffers()`
  * `void CSGetShaderResources()`
  * `void CSGetUnorderedAccessViews()`
  * `void CSGetShader()`
  * `void CSGetConstantBuffers()`
  * `void CSGetSamplers()`
  * `void ClearState()`
  * `void Flush()`
  * `uint GetContextFlags()`
  * `int FinishCommandList()`
  * `void GetDevice()`
  * `void GetPrivateData()`
  * `void SetPrivateData()`
  * `void SetPrivateDataInterface()`
* **struct D3D11_BLEND_DESC**
  * `int AlphaToCoverageEnable`
  * `int IndependentBlendEnable`
  * `_RenderTarget_e__FixedBuffer RenderTarget`
* **struct D3D11_BOX**
  * `uint left`
  * `uint top`
  * `uint front`
  * `uint right`
  * `uint bottom`
  * `uint back`
  * `int QueryInterface()`
  * `uint AddRef()`
  * `uint Release()`
  * `void GetDevice()`
  * `int GetPrivateData()`
  * `int SetPrivateData()`
  * `int SetPrivateDataInterface()`
  * `void GetDesc()`
  * `void GetResource()`
  * `void GetType()`
  * `void SetEvictionPriority()`
  * `uint GetEvictionPriority()`
  * `void GetClassLinkage()`
  * `void GetInstanceName()`
  * `void GetTypeName()`
  * `uint GetDataSize()`
  * `uint GetContextFlags()`
  * `int GetClassInstance()`
  * `int CreateClassInstance()`
  * `int CreateBuffer()`
  * `int CreateTexture1D()`
  * `int CreateTexture2D()`
  * `int CreateTexture3D()`
  * `int CreateShaderResourceView()`
  * `int CreateUnorderedAccessView()`
  * `int CreateRenderTargetView()`
  * `int CreateDepthStencilView()`
  * `int CreateInputLayout()`
  * `int CreateVertexShader()`
  * `int CreateGeometryShader()`
  * `int CreateGeometryShaderWithStreamOutput()`
  * `int CreatePixelShader()`
  * `int CreateHullShader()`
  * `int CreateDomainShader()`
  * `int CreateComputeShader()`
  * `int CreateClassLinkage()`
  * `int CreateBlendState()`
  * `int CreateDepthStencilState()`
  * `int CreateRasterizerState()`
  * `int CreateSamplerState()`
  * `int CreateQuery()`
  * `int CreatePredicate()`
  * `int CreateCounter()`
  * `int CreateDeferredContext()`
  * `int OpenSharedResource()`
  * `int CheckFormatSupport()`
  * `int CheckMultisampleQualityLevels()`
  * `void CheckCounterInfo()`
  * `int CheckCounter()`
  * `int CheckFeatureSupport()`
  * `D3D_FEATURE_LEVEL GetFeatureLevel()`
  * `uint GetCreationFlags()`
  * `int GetDeviceRemovedReason()`
  * `void GetImmediateContext()`
  * `int SetExceptionMode()`
  * `uint GetExceptionMode()`
* **struct D3D11_BUFFEREX_SRV**
  * `uint FirstElement`
  * `uint NumElements`
  * `uint Flags`
* **struct D3D11_BUFFER_DESC**
  * `uint ByteWidth`
  * `D3D11_USAGE Usage`
  * `uint BindFlags`
  * `uint CPUAccessFlags`
  * `uint MiscFlags`
  * `uint StructureByteStride`
* **struct D3D11_BUFFER_RTV**
  * `_Anonymous1_e__Union Anonymous1`
  * `_Anonymous2_e__Union Anonymous2`
* **struct D3D11_BUFFER_SRV**
  * `_Anonymous1_e__Union Anonymous1`
  * `_Anonymous2_e__Union Anonymous2`
* **struct D3D11_BUFFER_UAV**
  * `uint FirstElement`
  * `uint NumElements`
  * `uint Flags`
  * `uint SysMemPitch`
  * `uint SysMemSlicePitch`
  * `uint Stream`
  * `uint SemanticIndex`
  * `byte StartComponent`
  * `byte ComponentCount`
  * `byte OutputSlot`
* **struct D3D11_CLASS_INSTANCE_DESC**
  * `uint InstanceId`
  * `uint InstanceIndex`
  * `uint TypeId`
  * `uint ConstantBuffer`
  * `uint BaseConstantBufferOffset`
  * `uint BaseTexture`
  * `uint BaseSampler`
  * `int Created`
* **struct D3D11_COUNTER_DESC**
  * `D3D11_COUNTER Counter`
  * `uint MiscFlags`
* **struct D3D11_COUNTER_INFO**
  * `D3D11_COUNTER LastDeviceDependentCounter`
  * `uint NumSimultaneousCounters`
  * `byte NumDetectableParallelUnits`
* **struct D3D11_DEPTH_STENCILOP_DESC**
  * `D3D11_STENCIL_OP StencilFailOp`
  * `D3D11_STENCIL_OP StencilDepthFailOp`
  * `D3D11_STENCIL_OP StencilPassOp`
  * `D3D11_COMPARISON_FUNC StencilFunc`
* **struct D3D11_DEPTH_STENCIL_DESC**
* **struct D3D11_DEPTH_STENCIL_VIEW_DESC**
  * `DXGI_FORMAT Format`
  * `D3D11_DSV_DIMENSION ViewDimension`
  * `uint Flags`
  * `_Anonymous_e__Union Anonymous`
* **struct D3D11_INPUT_ELEMENT_DESC**
  * `IntPtr SemanticName`
  * `uint SemanticIndex`
  * `DXGI_FORMAT Format`
  * `uint InputSlot`
  * `uint AlignedByteOffset`
  * `uint InputSlotClass`
  * `uint InstanceDataStepRate`
* **struct D3D11_QUERY_DESC**
  * `D3D11_QUERY Query`
  * `uint MiscFlags`
  * `uint SemanticIndex`
  * `DXGI_FORMAT Format`
  * `uint InputSlot`
  * `uint AlignedByteOffset`
  * `D3D11_INPUT_CLASSIFICATION InputSlotClass`
  * `uint InstanceDataStepRate`
  * `IntPtr pData`
  * `uint RowPitch`
  * `uint DepthPitch`
* **struct D3D11_RASTERIZER_DESC**
  * `uint FillMode`
  * `uint CullMode`
  * `int FrontCounterClockwise`
  * `int DepthBias`
  * `float DepthBiasClamp`
  * `float SlopeScaledDepthBias`
  * `int DepthClipEnable`
  * `int ScissorEnable`
  * `int MultisampleEnable`
  * `int AntialiasedLineEnable`
  * `D3D11_FILL_MODE FillMode`
  * `D3D11_CULL_MODE CullMode`
* **struct D3D11_RENDER_TARGET_BLEND_DESC**
  * `int BlendEnable`
  * `D3D11_BLEND SrcBlend`
  * `D3D11_BLEND DestBlend`
  * `D3D11_BLEND_OP BlendOp`
  * `D3D11_BLEND SrcBlendAlpha`
  * `D3D11_BLEND DestBlendAlpha`
  * `D3D11_BLEND_OP BlendOpAlpha`
  * `byte RenderTargetWriteMask`
* **struct D3D11_RENDER_TARGET_VIEW_DESC**
  * `DXGI_FORMAT Format`
  * `D3D11_RTV_DIMENSION ViewDimension`
  * `_Anonymous_e__Union Anonymous`
* **struct D3D11_SAMPLER_DESC**
  * `D3D11_FILTER Filter`
  * `D3D11_TEXTURE_ADDRESS_MODE AddressU`
  * `D3D11_TEXTURE_ADDRESS_MODE AddressV`
  * `D3D11_TEXTURE_ADDRESS_MODE AddressW`
  * `float MipLODBias`
  * `uint MaxAnisotropy`
  * `D3D11_COMPARISON_FUNC ComparisonFunc`
  * `_BorderColor_e__FixedBuffer BorderColor`
  * `float MinLOD`
  * `float MaxLOD`
* **struct D3D11_SHADER_RESOURCE_VIEW_DESC**
  * `DXGI_FORMAT Format`
  * `D3D_SRV_DIMENSION ViewDimension`
  * `_Anonymous_e__Union Anonymous`
* **struct D3D11_SUBRESOURCE_DATA**
  * `IntPtr pSysMem`
  * `uint SysMemPitch`
  * `uint SysMemSlicePitch`
* **struct D3D11_TEX1D_ARRAY_DSV**
  * `uint MipSlice`
  * `uint FirstArraySlice`
  * `uint ArraySize`
* **struct D3D11_TEX1D_ARRAY_RTV**
  * `uint MipSlice`
  * `uint FirstArraySlice`
  * `uint ArraySize`
* **struct D3D11_TEX1D_ARRAY_SRV**
  * `uint MostDetailedMip`
  * `uint MipLevels`
  * `uint FirstArraySlice`
  * `uint ArraySize`
* **struct D3D11_TEX1D_ARRAY_UAV**
  * `uint MipSlice`
  * `uint FirstArraySlice`
  * `uint ArraySize`
* **struct D3D11_TEX1D_DSV**
  * `uint MipSlice`
* **struct D3D11_TEX1D_RTV**
  * `uint MipSlice`
* **struct D3D11_TEX1D_SRV**
  * `uint MostDetailedMip`
  * `uint MipLevels`
* **struct D3D11_TEX1D_UAV**
  * `uint MipSlice`
* **struct D3D11_TEX2DMS_ARRAY_DSV**
  * `uint FirstArraySlice`
  * `uint ArraySize`
* **struct D3D11_TEX2DMS_ARRAY_RTV**
  * `uint FirstArraySlice`
  * `uint ArraySize`
* **struct D3D11_TEX2DMS_ARRAY_SRV**
  * `uint FirstArraySlice`
  * `uint ArraySize`
* **struct D3D11_TEX2DMS_DSV**
  * `uint UnusedField_NothingToDefine`
* **struct D3D11_TEX2DMS_RTV**
  * `uint UnusedField_NothingToDefine`
* **struct D3D11_TEX2DMS_SRV**
  * `uint UnusedField_NothingToDefine`
* **struct D3D11_TEX2D_ARRAY_DSV**
  * `uint MipSlice`
  * `uint FirstArraySlice`
  * `uint ArraySize`
* **struct D3D11_TEX2D_ARRAY_RTV**
  * `uint MipSlice`
  * `uint FirstArraySlice`
  * `uint ArraySize`
* **struct D3D11_TEX2D_ARRAY_SRV**
  * `uint MostDetailedMip`
  * `uint MipLevels`
  * `uint FirstArraySlice`
  * `uint ArraySize`
* **struct D3D11_TEX2D_ARRAY_UAV**
  * `uint MipSlice`
  * `uint FirstArraySlice`
  * `uint ArraySize`
* **struct D3D11_TEX2D_DSV**
  * `uint MipSlice`
* **struct D3D11_TEX2D_RTV**
  * `uint MipSlice`
* **struct D3D11_TEX2D_SRV**
  * `uint MostDetailedMip`
  * `uint MipLevels`
* **struct D3D11_TEX2D_UAV**
  * `uint MipSlice`
* **struct D3D11_TEX3D_RTV**
  * `uint MipSlice`
  * `uint FirstWSlice`
  * `uint WSize`
* **struct D3D11_TEX3D_SRV**
  * `uint MostDetailedMip`
  * `uint MipLevels`
* **struct D3D11_TEX3D_UAV**
  * `uint MipSlice`
  * `uint FirstWSlice`
  * `uint WSize`
* **struct D3D11_TEXCUBE_ARRAY_SRV**
  * `uint MostDetailedMip`
  * `uint MipLevels`
  * `uint First2DArrayFace`
  * `uint NumCubes`
* **struct D3D11_TEXCUBE_SRV**
  * `uint MostDetailedMip`
  * `uint MipLevels`
* **struct D3D11_TEXTURE1D_DESC**
  * `uint Width`
  * `uint MipLevels`
  * `uint ArraySize`
  * `DXGI_FORMAT Format`
  * `D3D11_USAGE Usage`
  * `uint BindFlags`
  * `uint CPUAccessFlags`
  * `uint MiscFlags`
* **struct D3D11_TEXTURE2D_DESC**
  * `uint Width`
  * `uint Height`
  * `uint MipLevels`
  * `uint ArraySize`
  * `DXGI_FORMAT Format`
  * `DXGI_SAMPLE_DESC SampleDesc`
  * `D3D11_USAGE Usage`
  * `uint BindFlags`
  * `uint CPUAccessFlags`
  * `uint MiscFlags`
* **struct D3D11_TEXTURE3D_DESC**
  * `uint Width`
  * `uint Height`
  * `uint Depth`
  * `uint MipLevels`
  * `DXGI_FORMAT Format`
  * `D3D11_USAGE Usage`
  * `uint BindFlags`
  * `uint CPUAccessFlags`
  * `uint MiscFlags`
* **struct D3D11_UNORDERED_ACCESS_VIEW_DESC**
  * `DXGI_FORMAT Format`
  * `D3D11_UAV_DIMENSION ViewDimension`
  * `_Anonymous_e__Union Anonymous`
* **struct D3D11_VIEWPORT**
  * `float TopLeftX`
  * `float TopLeftY`
  * `float Width`
  * `float Height`
  * `float MinDepth`
  * `float MaxDepth`
  * `int CreateRasterizerState()`
  * `void RSSetState()`
  * `void VSSetConstantBuffers()`
  * `void IASetVertexBuffers()`
  * `void IASetIndexBuffer()`
  * `void IASetInputLayout()`
  * `void IASetPrimitiveTopology()`
  * `void VSSetShader()`
  * `void PSSetShader()`
  * `void Draw()`
  * `void DrawIndexed()`
  * `int CreateInputLayout()`
  * `int CreateBuffer()`
  * `int CreateVertexShader()`
  * `int CreatePixelShader()`
  * `int Map()`
  * `void Unmap()`
  * `void CopyResource()`
  * `int ResizeSwapChainBuffers()`
  * `void OMSetRenderTargets()`
  * `int CreateDXGIFactory()`
  * `int CreateSwapChain()`
  * `int CreateRenderTargetView()`
  * `int CreateTexture2D()`
  * `int CreateDepthStencilView()`
  * `int GetSwapChainBackBuffer()`
  * `void SetViewports()`
  * `void ClearRenderTargetView()`
  * `void ClearDepthStencilView()`
  * `int PresentSwapChain()`
* **struct DXGI_MODE_DESC**
  * `uint Width`
  * `uint Height`
  * `uint RefreshRate_Numerator`
  * `uint RefreshRate_Denominator`
  * `DXGI_FORMAT Format`
  * `uint ScanlineOrdering`
  * `uint Scaling`
* **struct DXGI_SAMPLE_DESC**
  * `uint Count`
  * `uint Quality`
* **struct DXGI_SWAP_CHAIN_DESC**
  * `DXGI_MODE_DESC BufferDesc`
  * `DXGI_SAMPLE_DESC SampleDesc`
  * `DXGI_USAGE BufferUsage`
  * `uint BufferCount`
  * `IntPtr OutputWindow`
  * `int Windowed`
  * `DXGI_SWAP_EFFECT SwapEffect`
  * `uint Flags`
* **struct _Anonymous1_e__Union**
  * `uint FirstElement`
  * `uint ElementOffset`
* **struct _Anonymous2_e__Union**
  * `uint NumElements`
  * `uint ElementWidth`
* **struct _Anonymous_e__Union**
  * `D3D11_TEX1D_DSV Texture1D`
  * `D3D11_TEX1D_ARRAY_DSV Texture1DArray`
  * `D3D11_TEX2D_DSV Texture2D`
  * `D3D11_TEX2D_ARRAY_DSV Texture2DArray`
  * `D3D11_TEX2DMS_DSV Texture2DMS`
  * `D3D11_TEX2DMS_ARRAY_DSV Texture2DMSArray`
  * `D3D11_BUFFER_RTV Buffer`
  * `D3D11_TEX1D_RTV Texture1D`
  * `D3D11_TEX1D_ARRAY_RTV Texture1DArray`
  * `D3D11_TEX2D_RTV Texture2D`
  * `D3D11_TEX2D_ARRAY_RTV Texture2DArray`
  * `D3D11_TEX2DMS_RTV Texture2DMS`
  * `D3D11_TEX2DMS_ARRAY_RTV Texture2DMSArray`
  * `D3D11_TEX3D_RTV Texture3D`
  * `D3D11_BUFFER_SRV Buffer`
  * `D3D11_TEX1D_SRV Texture1D`
  * `D3D11_TEX1D_ARRAY_SRV Texture1DArray`
  * `D3D11_TEX2D_SRV Texture2D`
  * `D3D11_TEX2D_ARRAY_SRV Texture2DArray`
  * `D3D11_TEX2DMS_SRV Texture2DMS`
  * `D3D11_TEX2DMS_ARRAY_SRV Texture2DMSArray`
  * `D3D11_TEX3D_SRV Texture3D`
  * `D3D11_TEXCUBE_SRV TextureCube`
  * `D3D11_TEXCUBE_ARRAY_SRV TextureCubeArray`
  * `D3D11_BUFFEREX_SRV BufferEx`
  * `D3D11_BUFFER_UAV Buffer`
  * `D3D11_TEX1D_UAV Texture1D`
  * `D3D11_TEX1D_ARRAY_UAV Texture1DArray`
  * `D3D11_TEX2D_UAV Texture2D`
  * `D3D11_TEX2D_ARRAY_UAV Texture2DArray`
  * `D3D11_TEX3D_UAV Texture3D`
  * `int QueryInterface()`
  * `uint AddRef()`
  * `uint Release()`
  * `void GetDevice()`
  * `int GetPrivateData()`
  * `int SetPrivateData()`
  * `int SetPrivateDataInterface()`
  * `void GetType()`
  * `void SetEvictionPriority()`
  * `uint GetEvictionPriority()`
  * `void GetDesc()`
  * `uint GetDataSize()`
* **struct _BorderColor_e__FixedBuffer**
  * `float e0`
* **struct _RenderTarget_e__FixedBuffer**
  * `D3D11_RENDER_TARGET_BLEND_DESC e0`

</details>

<details><summary><b>Angene.Windows.Dxgi</b></summary>

* **class DxgiConstants**
  * `uint S_OK`
  * `Guid DXGI_DEBUG_ALL`
  * `Guid DXGI_DEBUG_DX`
  * `Guid DXGI_DEBUG_DXGI`
  * `Guid DXGI_DEBUG_APP`
  * `uint D3D11_CLEAR_DEPTH`
* **class DxgiEnums**
* **class DxgiInterfaces**
* **class DxgiStructs**
* **enum D3D12_CONSERVATIVE_RASTERIZATION_TIER**
* **enum D3D12_CROSS_NODE_SHARING_TIER**
* **enum D3D12_RESOURCE_BINDING_TIER**
* **enum D3D12_RESOURCE_HEAP_TIER**
* **enum D3D12_SHADER_MIN_PRECISION_SUPPORT**
* **enum D3D12_TILED_RESOURCES_TIER**
* **enum DXGI_ADAPTER_FLAG**
* **enum DXGI_ADAPTER_FLAG3**
* **enum DXGI_ALPHA_MODE**
* **enum DXGI_COLOR_SPACE_TYPE**
* **enum DXGI_COMPUTE_PREEMPTION_GRANULARITY**
* **enum DXGI_DEBUG_RLO_FLAGS**
* **enum DXGI_FEATURE**
* **enum DXGI_FORMAT**
* **enum DXGI_FRAME_PRESENTATION_MODE**
* **enum DXGI_GPU_PREFERENCE**
* **enum DXGI_GRAPHICS_PREEMPTION_GRANULARITY**
* **enum DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAGS**
* **enum DXGI_HDR_METADATA_TYPE**
* **enum DXGI_INFO_QUEUE_MESSAGE_CATEGORY**
* **enum DXGI_INFO_QUEUE_MESSAGE_SEVERITY**
* **enum DXGI_MEMORY_SEGMENT_GROUP**
* **enum DXGI_MODE_ROTATION**
* **enum DXGI_MODE_SCALING**
* **enum DXGI_MODE_SCANLINE_ORDER**
* **enum DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAGS**
* **enum DXGI_OUTDUPL_POINTER_SHAPE_TYPE**
* **enum DXGI_OVERLAY_COLOR_SPACE_SUPPORT_FLAG**
* **enum DXGI_OVERLAY_SUPPORT_FLAG**
* **enum DXGI_RESIDENCY**
* **enum DXGI_SCALING**
* **enum DXGI_SWAP_CHAIN_COLOR_SPACE_SUPPORT_FLAG**
* **enum DXGI_SWAP_CHAIN_FLAG**
* **enum DXGI_SWAP_EFFECT**
* **enum DXGI_USAGE**
* **enum _DXGI_OFFER_RESOURCE_FLAGS**
* **enum _DXGI_OFFER_RESOURCE_PRIORITY**
* **enum _DXGI_RECLAIM_RESOURCE_RESULTS**
* **interface IDXGIAdapter**
* **interface IDXGIAdapter1**
* **interface IDXGIAdapter2**
* **interface IDXGIAdapter3**
* **interface IDXGIAdapter4**
* **interface IDXGIDebug**
* **interface IDXGIDebug1**
* **interface IDXGIDecodeSwapChain**
* **interface IDXGIDevice**
* **interface IDXGIDevice1**
* **interface IDXGIDevice2**
* **interface IDXGIDevice3**
* **interface IDXGIDevice4**
* **interface IDXGIDeviceSubObject**
* **interface IDXGIDisplayControl**
* **interface IDXGIFactory**
* **interface IDXGIFactory1**
* **interface IDXGIFactory2**
* **interface IDXGIFactory3**
* **interface IDXGIFactory4**
* **interface IDXGIFactory5**
* **interface IDXGIFactory6**
* **interface IDXGIFactory7**
* **interface IDXGIFactoryMedia**
* **interface IDXGIInfoQueue**
* **interface IDXGIKeyedMutex**
* **interface IDXGIObject**
* **interface IDXGIOutput**
* **interface IDXGIOutput1**
* **interface IDXGIOutput2**
* **interface IDXGIOutput3**
* **interface IDXGIOutput4**
* **interface IDXGIOutput5**
* **interface IDXGIOutput6**
* **interface IDXGIOutputDuplication**
* **interface IDXGIResource**
* **interface IDXGIResource1**
* **interface IDXGISurface**
* **interface IDXGISurface1**
* **interface IDXGISurface2**
* **interface IDXGISwapChain**
* **interface IDXGISwapChain1**
* **interface IDXGISwapChain2**
* **interface IDXGISwapChain3**
* **interface IDXGISwapChain4**
* **interface IDXGISwapChainMedia**
* **struct D3D12_FEATURE_DATA_D3D12_OPTIONS**
  * `bool DoublePrecisionFloatShaderOps`
  * `bool OutputMergerLogicOp`
  * `D3D12_SHADER_MIN_PRECISION_SUPPORT MinPrecisionSupport`
  * `D3D12_TILED_RESOURCES_TIER TiledResourcesTier`
  * `D3D12_RESOURCE_BINDING_TIER ResourceBindingTier`
  * `bool PSSpecifiedStencilRefSupported`
  * `bool TypedUAVLoadAdditionalFormats`
  * `bool ROVsSupported`
  * `D3D12_CONSERVATIVE_RASTERIZATION_TIER ConservativeRasterizationTier`
  * `uint MaxGPUVirtualAddressBitsPerResource`
  * `bool StandardSwizzle64KBSupported`
  * `D3D12_CROSS_NODE_SHARING_TIER CrossNodeSharingTier`
  * `bool CrossAdapterRowMajorTextureSupported`
  * `bool VPAndRTArrayIndexFromAnyShaderFeedingRasterizerSupportedWithoutGSEmulation`
  * `D3D12_RESOURCE_HEAP_TIER ResourceHeapTier`
* **struct D3DCOLORVALUE**
  * `float r`
  * `float g`
  * `float b`
  * `float a`
* **struct DXGI_ADAPTER_DESC**
  * `string Description`
  * `uint VendorId`
  * `uint DeviceId`
  * `uint SubSysId`
  * `uint Revision`
  * `nuint DedicatedVideoMemory`
  * `nuint DedicatedSystemMemory`
  * `nuint SharedSystemMemory`
  * `LUID AdapterLuid`
* **struct DXGI_ADAPTER_DESC1**
  * `string Description`
  * `uint VendorId`
  * `uint DeviceId`
  * `uint SubSysId`
  * `uint Revision`
  * `nuint DedicatedVideoMemory`
  * `nuint DedicatedSystemMemory`
  * `nuint SharedSystemMemory`
  * `LUID AdapterLuid`
  * `uint Flags`
* **struct DXGI_ADAPTER_DESC2**
  * `string Description`
  * `uint VendorId`
  * `uint DeviceId`
  * `uint SubSysId`
  * `uint Revision`
  * `nuint DedicatedVideoMemory`
  * `nuint DedicatedSystemMemory`
  * `nuint SharedSystemMemory`
  * `LUID AdapterLuid`
  * `uint Flags`
  * `DXGI_GRAPHICS_PREEMPTION_GRANULARITY GraphicsPreemptionGramularity`
  * `DXGI_COMPUTE_PREEMPTION_GRANULARITY ComputePreemptionGramularity`
* **struct DXGI_ADAPTER_DESC3**
  * `string Description`
  * `uint VendorId`
  * `uint DeviceId`
  * `uint SubSysId`
  * `uint Revision`
  * `nuint DedicatedVideoMemory`
  * `nuint DedicatedSystemMemory`
  * `nuint SharedSystemMemory`
  * `LUID AdapterLuid`
  * `DXGI_ADAPTER_FLAG3 Flags`
  * `DXGI_GRAPHICS_PREEMPTION_GRANULARITY GraphicsPreemptionGramularity`
  * `DXGI_COMPUTE_PREEMPTION_GRANULARITY ComputePreemptionGramularity`
* **struct DXGI_DECODE_SWAP_CHAIN_DESC**
  * `uint Flags`
* **struct DXGI_DISPLAY_COLOR_SPACE**
* **struct DXGI_FRAME_STATISTICS**
  * `uint PresentCount`
  * `uint PresentRefreshCount`
  * `uint SyncRefreshCount`
  * `LARGE_INTEGER SyncQPCTime`
  * `LARGE_INTEGER SyncGPUTime`
* **struct DXGI_FRAME_STATISTICS_MEDIA**
  * `uint PresentCount`
  * `uint PresentRefreshCount`
  * `uint SyncRefreshCount`
  * `LARGE_INTEGER SyncQPCTime`
  * `LARGE_INTEGER SyncGPUTime`
  * `DXGI_FRAME_PRESENTATION_MODE CompositionMode`
  * `uint ApprovedPresentDuration`
* **struct DXGI_GAMMA_CONTROL**
  * `DXGI_RGB Scale`
  * `DXGI_RGB Offset`
* **struct DXGI_GAMMA_CONTROL_CAPABILITIES**
  * `bool ScaleAndOffsetSupported`
  * `float MaxConvertedValue`
  * `float MinConvertedValue`
  * `uint NumGammaControlPoints`
* **struct DXGI_HDE_METADATA_HDR10**
  * `uint MaxMasteringLuminance`
  * `uint MinMasteringLuminance`
  * `UInt16 MaxContentLightLevel`
  * `UInt16 MaxFrameAverageLightLevel`
* **struct DXGI_INFO_QUEUE_FILTER**
  * `DXGI_INFO_QUEUE_FILTER_DESC AllowList`
  * `DXGI_INFO_QUEUE_FILTER_DESC DenyList`
* **struct DXGI_INFO_QUEUE_FILTER_DESC**
  * `uint NumCategories`
  * `IntPtr pCategoryList`
  * `uint NumSeverities`
  * `IntPtr pSeverityList`
  * `uint NumIDs`
  * `IntPtr pIDList`
* **struct DXGI_INFO_QUEUE_MESSAGE**
  * `DXGI_DEBUG_ID Producer`
  * `DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category`
  * `DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity`
  * `uint ID`
  * `IntPtr pDescription`
  * `nuint DescriptionByteLength`
* **struct DXGI_JPEG_AC_HUFFMAN_TABLE**
* **struct DXGI_JPEG_DC_HUFFMAN_TABLE**
* **struct DXGI_JPEG_QUANTIZATION_TABLE**
* **struct DXGI_MAPPED_RECT**
  * `int Pitch`
  * `IntPtr pBits`
* **struct DXGI_MATRIX_3X2_F**
  * `float _11`
  * `float _12`
  * `float _21`
  * `float _22`
  * `float _31`
  * `float _32`
* **struct DXGI_MODE_DESC**
  * `uint Width`
  * `uint Height`
  * `DXGI_RATIONAL RefreshRate`
  * `DXGI_FORMAT Format`
  * `DXGI_MODE_SCANLINE_ORDER ScanlineOrdering`
  * `DXGI_MODE_SCALING Scaling`
* **struct DXGI_MODE_DESC1**
  * `uint Width`
  * `uint Height`
  * `DXGI_RATIONAL RefreshRate`
  * `DXGI_FORMAT Format`
  * `DXGI_MODE_SCANLINE_ORDER ScanlineOrdering`
  * `DXGI_MODE_SCALING Scaling`
  * `bool Stereo`
* **struct DXGI_OUTDUPL_DESC**
  * `DXGI_MODE_DESC ModeDesc`
  * `DXGI_MODE_ROTATION Rotation`
  * `bool DesktopImageInSystemMemory`
* **struct DXGI_OUTDUPL_FRAME_INFO**
  * `LARGE_INTEGER LastPresentTime`
  * `LARGE_INTEGER LastMouseUpdateTime`
  * `uint AccumulatedFrames`
  * `bool RectsCoalesced`
  * `bool ProtectedContentMaskedOut`
  * `DXGI_OUTDUPL_POINTER_POSITION PointerPosition`
  * `uint TotalMetadataBufferSize`
  * `uint PointerShapeBufferSize`
* **struct DXGI_OUTDUPL_MOVE_RECT**
  * `POINT SourcePoint`
  * `RECT DestinationRect`
* **struct DXGI_OUTDUPL_POINTER_POSITION**
  * `POINT Position`
  * `bool Visible`
* **struct DXGI_OUTDUPL_POINTER_SHAPE_INFO**
  * `uint Type`
  * `uint Width`
  * `uint Height`
  * `uint Pitch`
  * `POINT HotSpot`
* **struct DXGI_OUTPUT_DESC**
  * `RECT DesktopCoordinates`
  * `bool AttachedToDesktop`
  * `DXGI_MODE_ROTATION Rotation`
  * `IntPtr Monitor`
* **struct DXGI_OUTPUT_DESC1**
  * `RECT DesktopCoordinates`
  * `bool AttachedToDesktop`
  * `DXGI_MODE_ROTATION Rotation`
  * `IntPtr Monitor`
  * `uint BitsPerColor`
  * `DXGI_COLOR_SPACE_TYPE ColorSpace`
  * `float MinLuminance`
  * `float MaxLuminance`
  * `float MaxFullFrameLuminance`
* **struct DXGI_PRESENT_PARAMETERS**
  * `uint DirtyRectsCount`
  * `RECT pDirtyRects`
  * `RECT pScrollRect`
  * `POINT pScrollOffset`
* **struct DXGI_QUERY_VIDEO_MEMORY_INFO**
  * `UInt64 Budget`
  * `UInt64 CurrentUsage`
  * `UInt64 AvailableForReservation`
  * `UInt64 CurrentReservation`
* **struct DXGI_RATIONAL**
  * `uint Numerator`
  * `uint Denominator`
* **struct DXGI_RGB**
  * `float Red`
  * `float Green`
  * `float Blue`
* **struct DXGI_RGBA**
  * `float r`
  * `float g`
  * `float b`
  * `float a`
* **struct DXGI_SAMPLE_DESC**
  * `uint Count`
  * `uint Quality`
* **struct DXGI_SHARED_RESOURCE**
  * `IntPtr Handle`
* **struct DXGI_SURFACE_DESC**
  * `uint Width`
  * `uint Height`
  * `DXGI_FORMAT Format`
  * `DXGI_SAMPLE_DESC SampleDesc`
* **struct DXGI_SWAP_CHAIN_DESC**
  * `DXGI_MODE_DESC BufferDesc`
  * `DXGI_SAMPLE_DESC SampleDesc`
  * `DXGI_USAGE BufferUsage`
  * `uint BufferCount`
  * `IntPtr OutputWindow`
  * `bool Windowed`
  * `DXGI_SWAP_EFFECT SwapEffect`
  * `uint Flags`
* **struct DXGI_SWAP_CHAIN_DESC1**
  * `uint Width`
  * `uint Height`
  * `DXGI_FORMAT Format`
  * `bool Stereo`
  * `DXGI_SAMPLE_DESC SampleDesc`
  * `DXGI_USAGE BufferUsage`
  * `uint BufferCount`
  * `DXGI_SCALING Scaling`
  * `DXGI_SWAP_EFFECT SwapEffect`
  * `DXGI_ALPHA_MODE AlphaMode`
  * `DXGI_SWAP_CHAIN_FLAG Flags`
* **struct DXGI_SWAP_CHAIN_FULLSCREEN_DESC**
  * `DXGI_RATIONAL RefreshRate`
  * `DXGI_MODE_SCANLINE_ORDER ScanlineOrdering`
  * `DXGI_MODE_SCALING Scaling`
  * `bool Windowed`
* **struct LARGE_INTEGER**
* **struct LUID**
  * `uint LowPart`
  * `int HighPart`
* **struct POINT**
  * `int X`
  * `int Y`
* **struct _SECURITY_ATTRIBUTES**
  * `uint nLength`
  * `IntPtr lpSecurityDescriptor`
  * `bool bInheritHandle`

</details>

<details><summary><b>Angene.Windows.Graphics</b></summary>

* **class DxgiFunctions**

</details>

<details><summary><b>Angene.Windows.Slang</b></summary>

* **enum BindingType**
  * `nuint getSize()`
  * `nuint getStride()`
  * `int getAlignment()`
  * `uint getFieldCount()`
  * `long findFieldIndexByName()`
  * `bool isArray()`
  * `nuint getElementCount()`
  * `nuint getTotalArrayElementCount()`
  * `nuint getElementStride()`
  * `ParameterCategory getParameterCategory()`
  * `uint getCategoryCount()`
  * `ParameterCategory getCategoryByIndex()`
  * `uint getRowCount()`
  * `uint getColumnCount()`
  * `SlangResourceShape getResourceShape()`
  * `SlangResourceAccess getResourceAccess()`
  * `SlangMatrixLayoutMode getMatrixLayoutMode()`
  * `int getGenericParamIndex()`
  * `long getBindingRangeCount()`
  * `BindingType getBindingRangeType()`
  * `bool isBindingRangeSpecializable()`
  * `long getBindingRangeBindingCount()`
  * `long getFieldBindingRangeOffset()`
  * `long getExplicitCounterBindingRangeOffset()`
  * `SlangImageFormat getBindingRangeImageFormat()`
  * `long getBindingRangeDescriptorSetIndex()`
  * `long getBindingRangeFirstDescriptorRangeIndex()`
  * `long getBindingRangeDescriptorRangeCount()`
  * `long getDescriptorSetCount()`
  * `long getDescriptorSetSpaceOffset()`
  * `long getDescriptorSetDescriptorRangeCount()`
  * `long getDescriptorSetDescriptorRangeIndexOffset()`
  * `long getDescriptorSetDescriptorRangeDescriptorCount()`
  * `BindingType getDescriptorSetDescriptorRangeType()`
  * `ParameterCategory getDescriptorSetDescriptorRangeCategory()`
  * `long getSubObjectRangeCount()`
  * `long getSubObjectRangeBindingRangeIndex()`
  * `long getSubObjectRangeSpaceOffset()`
* **enum BuiltinModuleName**
  * `SlangUUID getTypeGuid()`
  * `int QueryInterface()`
  * `uint AddRef()`
  * `uint Release()`
  * `int queryInterface()`
  * `uint addRef()`
  * `uint release()`
  * `int createSession()`
  * `SlangProfileID findProfile()`
  * `void setDownstreamCompilerPath()`
  * `void setDownstreamCompilerPrelude()`
  * `void getDownstreamCompilerPrelude()`
  * `int setDefaultDownstreamCompiler()`
  * `SlangPassThrough getDefaultDownstreamCompiler()`
  * `void setLanguagePrelude()`
  * `void getLanguagePrelude()`
  * `int createCompileRequest()`
  * `void addBuiltins()`
  * `void setSharedLibraryLoader()`
  * `int checkCompileTargetSupport()`
  * `int checkPassThroughSupport()`
  * `int compileCoreModule()`
  * `int loadCoreModule()`
  * `int saveCoreModule()`
  * `SlangCapabilityID findCapability()`
  * `void setDownstreamCompilerForTransition()`
  * `SlangPassThrough getDownstreamCompilerForTransition()`
  * `void getCompilerElapsedTime()`
  * `int setSPIRVCoreGrammar()`
  * `int parseCommandLineArguments()`
  * `int getSessionDescDigest()`
  * `int compileBuiltinModule()`
  * `int loadBuiltinModule()`
  * `int saveBuiltinModule()`
  * `nuint structureSize`
  * `SlangCompileTarget format`
  * `SlangProfileID profile`
  * `uint flags`
  * `SlangFloatingPointMode floatingPointMode`
  * `SlangLineDirectiveMode lineDirectiveMode`
  * `byte forceGLSLScalarBufferLayout`
  * `uint compilerOptionEntryCount`
  * `long targetCount`
  * `SlangMatrixLayoutMode defaultMatrixLayoutMode`
  * `long searchPathCount`
  * `long preprocessorMacroCount`
  * `byte enableEffectAnnotations`
  * `byte allowGLSLSyntax`
  * `byte skipSPIRVValidation`
* **enum CompilerOptionName**
* **enum CompilerOptionValueKind**
  * `CompilerOptionValueKind kind`
  * `int intValue0`
  * `int intValue1`
* **enum ContainerType**
  * `long line`
  * `long column`
  * `SlangUUID getTypeGuid()`
  * `int QueryInterface()`
  * `uint AddRef()`
  * `uint Release()`
  * `int queryInterface()`
  * `uint addRef()`
  * `uint release()`
  * `int createCompositeComponentType()`
  * `int getTypeRTTIMangledName()`
  * `int getTypeConformanceWitnessMangledName()`
  * `int getTypeConformanceWitnessSequentialID()`
  * `int createCompileRequest()`
  * `int createTypeConformanceComponentType()`
  * `long getLoadedModuleCount()`
  * `bool isBinaryModuleUpToDate()`
  * `int getDynamicObjectRTTIBytes()`
  * `int loadModuleInfoFromIRBlob()`
  * `int getDeclSourceLocation()`
  * `int isParameterLocationUsed()`
  * `bool usesBindlessResourceHeap()`
* **enum CoverageBranchArmKind**
  * `nuint structSize`
  * `uint line`
  * `uint counterIndex`
  * `CoverageEntryKind kind`
  * `CoverageCounterMode counterMode`
  * `uint startColumn`
  * `uint endLine`
  * `uint endColumn`
  * `uint branchSiteID`
  * `uint branchArmID`
  * `CoverageBranchArmKind branchArmKind`
* **enum CoverageCounterMode**
* **enum CoverageEntryKind**
* **enum Enum**
* **enum ID**
  * `uint getUserAttributeCount()`
  * `bool hasDefaultValue()`
  * `int getDefaultValueInt()`
  * `int getDefaultValueFloat()`
  * `ParameterCategory getCategory()`
  * `uint getCategoryCount()`
  * `ParameterCategory getCategoryByIndex()`
  * `nuint getOffset()`
  * `uint getBindingIndex()`
  * `uint getBindingSpace()`
  * `nuint getBindingSpace()`
  * `SlangImageFormat getImageFormat()`
  * `nuint getSemanticIndex()`
  * `SlangStage getStage()`
  * `uint getParameterCount()`
  * `bool isOverloaded()`
  * `uint getOverloadCount()`
  * `uint getTypeParameterCount()`
  * `uint getValueParameterCount()`
  * `uint getTypeParameterConstraintCount()`
  * `SlangDeclKind getInnerKind()`
  * `long getConcreteIntVal()`
  * `void getComputeThreadGroupSize()`
  * `void getComputeWaveSize()`
  * `bool usesAnySampleRateInput()`
  * `bool hasDefaultConstantBuffer()`
  * `uint getIndex()`
  * `uint getConstraintCount()`
* **enum Kind**
  * `uint count`
  * `uint index`
  * `void Increment()`
  * `bool NotEquals()`
* **enum LayoutRules**
  * `uint getParameterCount()`
  * `uint getTypeParameterCount()`
  * `ulong getEntryPointCount()`
  * `ulong getGlobalConstantBufferBinding()`
  * `nuint getGlobalConstantBufferSize()`
  * `bool isSubType()`
  * `ulong getHashedStringCount()`
  * `int toJson()`
  * `long getBindlessSpaceIndex()`
  * `uint getChildrenCount()`
* **enum OSPathKind**
* **enum OperandDataType**
  * `uint _bitfield`
  * `uint offset`
  * `OperandDataType getType()`
  * `uint opcodeExtension`
  * `uint operandCount`
* **enum ParameterCategory**
* **enum PathKind**
  * `SlangUUID getTypeGuid()`
  * `int QueryInterface()`
  * `uint AddRef()`
  * `uint Release()`
  * `int queryInterface()`
  * `uint addRef()`
  * `uint release()`
  * `int loadFile()`
  * `int getFileUniqueIdentity()`
  * `int calcCombinedPath()`
  * `int getPathType()`
  * `int getPath()`
  * `void clearCache()`
  * `int enumeratePathContents()`
  * `OSPathKind getOSPathKind()`
  * `int saveFile()`
  * `int saveFileBlob()`
  * `int remove()`
  * `int createDirectory()`
* **enum ScalarType**
* **enum SlangArchiveType**
* **enum SlangBindableResourceType**
* **enum SlangBindingType**
* **enum SlangCapabilityID**
* **enum SlangCompileTarget**
* **enum SlangContainerFormat**
* **enum SlangCooperativeMatrixUse**
* **enum SlangCooperativeVectorMatrixLayout**
* **enum SlangDebugInfoFormat**
* **enum SlangDebugInfoLevel**
* **enum SlangDeclKind**
* **enum SlangDiagnosticColor**
* **enum SlangEmitCPUMethod**
* **enum SlangEmitSpirvMethod**
* **enum SlangFloatingPointMode**
* **enum SlangFpDenormalMode**
* **enum SlangImageFormat**
  * `SlangUUID getTypeGuid()`
  * `int QueryInterface()`
  * `uint AddRef()`
  * `uint Release()`
  * `int queryInterface()`
  * `uint addRef()`
  * `uint release()`
  * `void setFileSystem()`
  * `void setCompileFlags()`
  * `uint getCompileFlags()`
  * `void setDumpIntermediates()`
  * `void setDumpIntermediatePrefix()`
  * `void setLineDirectiveMode()`
  * `void setCodeGenTarget()`
  * `int addCodeGenTarget()`
  * `void setTargetProfile()`
  * `void setTargetFlags()`
  * `void setTargetFloatingPointMode()`
  * `void setTargetMatrixLayoutMode()`
  * `void setMatrixLayoutMode()`
  * `void setDebugInfoLevel()`
  * `void setOptimizationLevel()`
  * `void setOutputContainerFormat()`
  * `void setPassThrough()`
  * `void setDiagnosticCallback()`
  * `void setWriter()`
  * `void addSearchPath()`
  * `void addPreprocessorDefine()`
  * `int processCommandLineArguments()`
  * `int addTranslationUnit()`
  * `void setDefaultModuleName()`
  * `void addTranslationUnitPreprocessorDefine()`
  * `void addTranslationUnitSourceFile()`
  * `void addTranslationUnitSourceString()`
  * `int addLibraryReference()`
  * `void addTranslationUnitSourceStringSpan()`
  * `void addTranslationUnitSourceBlob()`
  * `int addEntryPoint()`
  * `int addEntryPointEx()`
  * `int setGlobalGenericArgs()`
  * `int setTypeNameForGlobalExistentialTypeParam()`
  * `int setTypeNameForEntryPointExistentialTypeParam()`
  * `void setAllowGLSLInput()`
  * `int compile()`
  * `int getDiagnosticOutputBlob()`
  * `int getDependencyFileCount()`
  * `int getTranslationUnitCount()`
  * `int getEntryPointCodeBlob()`
  * `int getEntryPointHostCallable()`
  * `int getTargetCodeBlob()`
  * `int getTargetHostCallable()`
  * `int getContainerCode()`
  * `int loadRepro()`
  * `int saveRepro()`
  * `int enableReproCapture()`
  * `int getProgram()`
  * `int getEntryPoint()`
  * `int getModule()`
  * `int getSession()`
  * `void setCommandLineCompilerMode()`
  * `int addTargetCapability()`
  * `int getProgramWithEntryPoints()`
  * `int isParameterLocationUsed()`
  * `void setTargetLineDirectiveMode()`
  * `void setTargetForceGLSLScalarBufferLayout()`
  * `void overrideDiagnosticSeverity()`
  * `int getDiagnosticFlags()`
  * `void setDiagnosticFlags()`
  * `void setDebugInfoFormat()`
  * `void setEnableEffectAnnotations()`
  * `void setReportDownstreamTime()`
  * `void setReportPerfBenchmark()`
  * `void setSkipSPIRVValidation()`
  * `void setTargetUseMinimumSlangOptimization()`
  * `void setIgnoreCapabilityCheck()`
  * `int getCompileTimeProfile()`
  * `void setTargetGenerateWholeProgram()`
  * `void setTargetForceDXLayout()`
  * `void setTargetEmbedDownstreamIR()`
  * `void setTargetForceCLayout()`
* **enum SlangLanguageVersion**
* **enum SlangLayoutRules**
* **enum SlangLineDirectiveMode**
* **enum SlangMatrixLayoutMode**
* **enum SlangModifierID**
* **enum SlangOptimizationLevel**
* **enum SlangParameterCategory**
* **enum SlangPassThrough**
* **enum SlangPathType**
* **enum SlangProfileID**
* **enum SlangReflectionGenericArgType**
* **enum SlangResourceAccess**
* **enum SlangResourceShape**
* **enum SlangScalarType**
* **enum SlangScope**
* **enum SlangSeverity**
* **enum SlangSourceLanguage**
* **enum SlangStage**
* **enum SlangTypeKind**
* **enum SlangWriterChannel**
* **enum SlangWriterMode**
  * `SlangUUID getTypeGuid()`
  * `int QueryInterface()`
  * `uint AddRef()`
  * `uint Release()`
  * `int queryInterface()`
  * `uint addRef()`
  * `uint release()`
  * `int endAppendBuffer()`
  * `int write()`
  * `void flush()`
  * `bool isConsole()`
  * `int setMode()`
  * `nuint getEntryCount()`
  * `int getEntryTimeMS()`
  * `uint getEntryInvocationTimes()`
* **enum SyntheticResourceAccess**
  * `nuint structSize`
  * `uint id`
  * `BindingType bindingType`
  * `uint arraySize`
  * `SyntheticResourceScope scope`
  * `SyntheticResourceAccess access`
  * `int entryPointIndex`
  * `int space`
  * `int binding`
  * `int uniformOffset`
  * `int uniformStride`
  * `SlangUUID getTypeGuid()`
  * `int QueryInterface()`
  * `uint AddRef()`
  * `uint Release()`
  * `int queryInterface()`
  * `uint addRef()`
  * `uint release()`
  * `uint getResourceCount()`
  * `int getResourceInfo()`
  * `int findResourceIndexByID()`
* **enum SyntheticResourceScope**
* **struct BufferReflection**
  * `long intVal`
  * `byte boolVal`
  * `uint getArgumentCount()`
  * `int getArgumentValueInt()`
  * `int getArgumentValueFloat()`
  * `uint getFieldCount()`
  * `bool isArray()`
  * `nuint getElementCount()`
  * `nuint getTotalArrayElementCount()`
  * `uint getRowCount()`
  * `uint getColumnCount()`
  * `SlangResourceShape getResourceShape()`
  * `SlangResourceAccess getResourceAccess()`
  * `int getFullName()`
  * `uint getUserAttributeCount()`
* **struct ByteCodeFuncInfo**
  * `uint parameterCount`
  * `uint returnValueSize`
* **struct ByteCodeRunnerDesc**
  * `nuint structSize`
  * `SlangUUID getTypeGuid()`
  * `int QueryInterface()`
  * `uint AddRef()`
  * `uint Release()`
  * `int queryInterface()`
  * `uint addRef()`
  * `uint release()`
  * `int loadModule()`
  * `int selectFunctionByIndex()`
  * `int findFunctionByName()`
  * `int getFunctionInfo()`
  * `int execute()`
  * `void getErrorString()`
  * `void setExtInstHandlerUserData()`
  * `int registerExtCall()`
  * `int setPrintCallback()`
  * `int SLANG_DIAGNOSTIC_FLAG_VERBOSE_PATHS`
  * `int SLANG_DIAGNOSTIC_FLAG_TREAT_WARNINGS_AS_ERRORS`
  * `int SLANG_COMPILE_FLAG_NO_MANGLING`
  * `int SLANG_COMPILE_FLAG_NO_CODEGEN`
  * `int SLANG_COMPILE_FLAG_OBFUSCATE`
  * `int SLANG_COMPILE_FLAG_NO_CHECKING`
  * `int SLANG_COMPILE_FLAG_SPLIT_MIXED_TYPES`
  * `int SLANG_TARGET_FLAG_PARAMETER_BLOCKS_USE_REGISTER_SPACES`
  * `int SLANG_TARGET_FLAG_GENERATE_WHOLE_PROGRAM`
  * `int SLANG_TARGET_FLAG_DUMP_IR`
  * `int SLANG_TARGET_FLAG_GENERATE_SPIRV_DIRECTLY`
  * `uint kDefaultTargetFlags`
  * `int? spProcessCommandLineArguments()`
  * `void spAddTranslationUnitSourceString()`
  * `int kSessionFlags_None`
  * `uint kInvalidCoverageCounterIndex`
  * `void shutdown()`
  * `bool Equals()`
  * `bool NotEquals()`
* **struct CompileCoreModuleFlag**
* **struct CompilerOptionEntry**
  * `CompilerOptionName name`
  * `CompilerOptionValue value`
* **struct CooperativeMatrixCombination**
  * `uint m`
  * `uint n`
  * `uint k`
  * `SlangScalarType componentTypeA`
  * `SlangScalarType componentTypeB`
  * `SlangScalarType componentTypeC`
  * `SlangScalarType componentTypeResult`
  * `byte saturate`
  * `SlangScope scope`
* **struct CooperativeMatrixType**
  * `SlangScalarType componentType`
  * `SlangScope scope`
  * `uint rowCount`
  * `uint columnCount`
  * `SlangCooperativeMatrixUse use`
* **struct CooperativeVectorCombination**
  * `SlangScalarType inputType`
  * `SlangScalarType inputInterpretation`
  * `uint inputPackingFactor`
  * `SlangScalarType matrixInterpretation`
  * `SlangScalarType biasInterpretation`
  * `SlangScalarType resultType`
  * `byte transpose`
  * `SlangUUID getTypeGuid()`
  * `int QueryInterface()`
  * `uint AddRef()`
  * `uint Release()`
  * `int queryInterface()`
  * `uint addRef()`
  * `uint release()`
  * `ulong getCooperativeMatrixTypeCount()`
  * `int getCooperativeMatrixTypeByIndex()`
  * `ulong getCooperativeMatrixCombinationCount()`
  * `int getCooperativeMatrixCombinationByIndex()`
  * `ulong getCooperativeVectorTypeCount()`
  * `int getCooperativeVectorTypeByIndex()`
  * `ulong getCooperativeVectorCombinationCount()`
  * `int getCooperativeVectorCombinationByIndex()`
  * `uint getItemCount()`
  * `int getItemData()`
  * `int getMetadata()`
  * `long getSpecializationParamCount()`
  * `int getEntryPointCode()`
  * `int getResultAsFileSystem()`
  * `void getEntryPointHash()`
  * `int specialize()`
  * `int link()`
  * `int getEntryPointHostCallable()`
  * `int renameEntryPoint()`
  * `int linkWithOptions()`
  * `int getTargetCode()`
  * `int getTargetMetadata()`
  * `int getEntryPointMetadata()`
  * `int getTargetCompileResult()`
  * `int getEntryPointCompileResult()`
  * `int getTargetHostCallable()`
  * `int findEntryPointByName()`
  * `int getDefinedEntryPointCount()`
  * `int getDefinedEntryPoint()`
  * `int serialize()`
  * `int writeToFile()`
  * `int findAndCheckEntryPoint()`
  * `int getDependencyFileCount()`
  * `int disassemble()`
  * `int precompileForTarget()`
  * `int getPrecompiledTargetCode()`
  * `long getModuleDependencyCount()`
  * `int getModuleDependency()`
  * `_Anonymous_e__Union Anonymous`
  * `SpecializationArg fromType()`
  * `SpecializationArg fromExpr()`
* **struct CooperativeVectorTypeUsageInfo**
  * `SlangScalarType componentType`
  * `uint maxSize`
  * `byte usedForTrainingOp`
* **struct CoverageBufferInfo**
  * `nuint structSize`
  * `int space`
  * `int binding`
  * `uint elementByteWidth`
  * `SlangUUID getTypeGuid()`
  * `int QueryInterface()`
  * `uint AddRef()`
  * `uint Release()`
  * `int queryInterface()`
  * `uint addRef()`
  * `uint release()`
  * `uint getCounterCount()`
  * `int getEntryInfo()`
  * `int getBufferInfo()`
  * `uint getEntryCount()`
* **struct Modifier**
* **struct SlangEntryPoint**
* **struct SlangEntryPointLayout**
* **struct SlangGlobalSessionDesc**
  * `uint structureSize`
  * `uint apiVersion`
  * `uint minLanguageVersion`
  * `byte enableGLSL`
  * `_reserved_e__FixedBuffer reserved`
* **struct SlangProgramLayout**
* **struct SlangReflectionDecl**
* **struct SlangReflectionFunction**
* **struct SlangReflectionGeneric**
  * `long intVal`
  * `byte boolVal`
* **struct SlangReflectionModifier**
* **struct SlangReflectionType**
* **struct SlangReflectionTypeLayout**
* **struct SlangReflectionTypeParameter**
* **struct SlangReflectionUserAttribute**
* **struct SlangReflectionVariable**
* **struct SlangReflectionVariableLayout**
* **struct SlangUUID**
  * `uint data1`
  * `ushort data2`
  * `ushort data3`
  * `_data4_e__FixedBuffer data4`
* **struct _chars_e__FixedBuffer**
  * `sbyte e0`
  * `Span<sbyte> AsSpan()`
  * `SlangUUID getTypeGuid()`
  * `int QueryInterface()`
  * `uint AddRef()`
  * `uint Release()`
  * `int queryInterface()`
  * `uint addRef()`
  * `uint release()`
  * `int loadFile()`
  * `int loadSharedLibrary()`
* **struct _data4_e__FixedBuffer**
  * `byte e0`
  * `SlangUUID getTypeGuid()`
  * `int QueryInterface()`
  * `uint AddRef()`
  * `uint Release()`
  * `int queryInterface()`
  * `uint addRef()`
  * `uint release()`
  * `nuint getBufferSize()`
  * `_chars_e__FixedBuffer chars`
* **struct _reserved_e__FixedBuffer**
  * `uint e0`

</details>

## Angene.XR (Not done at time of writing: 2026/07/22)
<details><summary><b>Angene.External.OpenXR</b></summary>

* **enum VkDeviceQueueCreateFlags**
  * `XrStructureType type`
  * `ulong systemId`
  * `uint width`
  * `uint height`
  * `int minFilter`
  * `int magFilter`
  * `int mipmapMode`
  * `int wrapModeS`
  * `int wrapModeT`
  * `int swizzleRed`
  * `int swizzleGreen`
  * `int swizzleBlue`
  * `int swizzleAlpha`
  * `float maxAnisotropy`
  * `XrColor4f borderColor`
  * `uint additionalCreateFlags`
  * `uint additionalUsageFlags`
  * `ulong XR_SPACE_VELOCITY_LINEAR_VALID_BIT`
  * `ulong XR_SPACE_VELOCITY_ANGULAR_VALID_BIT`
  * `ulong XR_SPACE_LOCATION_ORIENTATION_VALID_BIT`
  * `ulong XR_SPACE_LOCATION_POSITION_VALID_BIT`
  * `ulong XR_SPACE_LOCATION_ORIENTATION_TRACKED_BIT`
  * `ulong XR_SPACE_LOCATION_POSITION_TRACKED_BIT`
  * `ulong XR_SWAPCHAIN_CREATE_PROTECTED_CONTENT_BIT`
  * `ulong XR_SWAPCHAIN_CREATE_STATIC_IMAGE_BIT`
  * `ulong XR_SWAPCHAIN_USAGE_COLOR_ATTACHMENT_BIT`
  * `ulong XR_SWAPCHAIN_USAGE_DEPTH_STENCIL_ATTACHMENT_BIT`
  * `ulong XR_SWAPCHAIN_USAGE_UNORDERED_ACCESS_BIT`
  * `ulong XR_SWAPCHAIN_USAGE_TRANSFER_SRC_BIT`
  * `ulong XR_SWAPCHAIN_USAGE_TRANSFER_DST_BIT`
  * `ulong XR_SWAPCHAIN_USAGE_SAMPLED_BIT`
  * `ulong XR_SWAPCHAIN_USAGE_MUTABLE_FORMAT_BIT`
  * `ulong XR_SWAPCHAIN_USAGE_INPUT_ATTACHMENT_BIT_MND`
  * `ulong XR_SWAPCHAIN_USAGE_INPUT_ATTACHMENT_BIT_KHR`
  * `ulong XR_COMPOSITION_LAYER_CORRECT_CHROMATIC_ABERRATION_BIT`
  * `ulong XR_COMPOSITION_LAYER_BLEND_TEXTURE_SOURCE_ALPHA_BIT`
  * `ulong XR_COMPOSITION_LAYER_UNPREMULTIPLIED_ALPHA_BIT`
  * `ulong XR_COMPOSITION_LAYER_INVERTED_ALPHA_BIT_EXT`
  * `ulong XR_VIEW_STATE_ORIENTATION_VALID_BIT`
  * `ulong XR_VIEW_STATE_POSITION_VALID_BIT`
  * `ulong XR_VIEW_STATE_ORIENTATION_TRACKED_BIT`
  * `ulong XR_VIEW_STATE_POSITION_TRACKED_BIT`
  * `ulong XR_INPUT_SOURCE_LOCALIZED_NAME_USER_PATH_BIT`
  * `ulong XR_INPUT_SOURCE_LOCALIZED_NAME_INTERACTION_PROFILE_BIT`
  * `ulong XR_INPUT_SOURCE_LOCALIZED_NAME_COMPONENT_BIT`
  * `ulong XR_DEBUG_UTILS_MESSAGE_SEVERITY_VERBOSE_BIT_EXT`
  * `ulong XR_DEBUG_UTILS_MESSAGE_SEVERITY_INFO_BIT_EXT`
  * `ulong XR_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT`
  * `ulong XR_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT`
  * `ulong XR_DEBUG_UTILS_MESSAGE_TYPE_GENERAL_BIT_EXT`
  * `ulong XR_DEBUG_UTILS_MESSAGE_TYPE_VALIDATION_BIT_EXT`
  * `ulong XR_DEBUG_UTILS_MESSAGE_TYPE_PERFORMANCE_BIT_EXT`
  * `ulong XR_DEBUG_UTILS_MESSAGE_TYPE_CONFORMANCE_BIT_EXT`
  * `ulong XR_OVERLAY_MAIN_SESSION_ENABLED_COMPOSITION_LAYER_INFO_DEPTH_BIT_EXTX`
  * `ulong XR_COMPOSITION_LAYER_IMAGE_LAYOUT_VERTICAL_FLIP_BIT_FB`
  * `ulong XR_COMPOSITION_LAYER_SECURE_CONTENT_EXCLUDE_LAYER_BIT_FB`
  * `ulong XR_COMPOSITION_LAYER_SECURE_CONTENT_REPLACE_LAYER_BIT_FB`
  * `ulong XR_HAND_TRACKING_AIM_COMPUTED_BIT_FB`
  * `ulong XR_HAND_TRACKING_AIM_VALID_BIT_FB`
  * `ulong XR_HAND_TRACKING_AIM_INDEX_PINCHING_BIT_FB`
  * `ulong XR_HAND_TRACKING_AIM_MIDDLE_PINCHING_BIT_FB`
  * `ulong XR_HAND_TRACKING_AIM_RING_PINCHING_BIT_FB`
  * `ulong XR_HAND_TRACKING_AIM_LITTLE_PINCHING_BIT_FB`
  * `ulong XR_HAND_TRACKING_AIM_SYSTEM_GESTURE_BIT_FB`
  * `ulong XR_HAND_TRACKING_AIM_DOMINANT_HAND_BIT_FB`
  * `ulong XR_HAND_TRACKING_AIM_MENU_PRESSED_BIT_FB`
  * `ulong XR_SWAPCHAIN_CREATE_FOVEATION_SCALED_BIN_BIT_FB`
  * `ulong XR_SWAPCHAIN_CREATE_FOVEATION_FRAGMENT_DENSITY_MAP_BIT_FB`
  * `ulong XR_KEYBOARD_TRACKING_EXISTS_BIT_FB`
  * `ulong XR_KEYBOARD_TRACKING_LOCAL_BIT_FB`
  * `ulong XR_KEYBOARD_TRACKING_REMOTE_BIT_FB`
  * `ulong XR_KEYBOARD_TRACKING_CONNECTED_BIT_FB`
  * `ulong XR_KEYBOARD_TRACKING_QUERY_LOCAL_BIT_FB`
  * `ulong XR_KEYBOARD_TRACKING_QUERY_REMOTE_BIT_FB`
  * `ulong XR_TRIANGLE_MESH_MUTABLE_BIT_FB`
  * `ulong XR_PASSTHROUGH_CAPABILITY_BIT_FB`
  * `ulong XR_PASSTHROUGH_CAPABILITY_COLOR_BIT_FB`
  * `ulong XR_PASSTHROUGH_CAPABILITY_LAYER_DEPTH_BIT_FB`
  * `ulong XR_PASSTHROUGH_IS_RUNNING_AT_CREATION_BIT_FB`
  * `ulong XR_PASSTHROUGH_LAYER_DEPTH_BIT_FB`
  * `ulong XR_PASSTHROUGH_STATE_CHANGED_REINIT_REQUIRED_BIT_FB`
  * `ulong XR_PASSTHROUGH_STATE_CHANGED_NON_RECOVERABLE_ERROR_BIT_FB`
  * `ulong XR_PASSTHROUGH_STATE_CHANGED_RECOVERABLE_ERROR_BIT_FB`
  * `ulong XR_PASSTHROUGH_STATE_CHANGED_RESTORED_ERROR_BIT_FB`
  * `ulong XR_RENDER_MODEL_SUPPORTS_GLTF_2_0_SUBSET_1_BIT_FB`
  * `ulong XR_RENDER_MODEL_SUPPORTS_GLTF_2_0_SUBSET_2_BIT_FB`
  * `ulong XR_FRAME_END_INFO_PROTECTED_BIT_ML`
  * `ulong XR_FRAME_END_INFO_VIGNETTE_BIT_ML`
  * `ulong XR_GLOBAL_DIMMER_FRAME_END_INFO_ENABLED_BIT_ML`
  * `ulong XR_LOCALIZATION_MAP_ERROR_UNKNOWN_BIT_ML`
  * `ulong XR_LOCALIZATION_MAP_ERROR_OUT_OF_MAPPED_AREA_BIT_ML`
  * `ulong XR_LOCALIZATION_MAP_ERROR_LOW_FEATURE_COUNT_BIT_ML`
  * `ulong XR_LOCALIZATION_MAP_ERROR_EXCESSIVE_MOTION_BIT_ML`
  * `ulong XR_LOCALIZATION_MAP_ERROR_LOW_LIGHT_BIT_ML`
  * `ulong XR_LOCALIZATION_MAP_ERROR_HEADPOSE_BIT_ML`
  * `ulong XR_COMPOSITION_LAYER_SPACE_WARP_INFO_FRAME_SKIP_BIT_FB`
  * `ulong XR_SEMANTIC_LABELS_SUPPORT_MULTIPLE_SEMANTIC_LABELS_BIT_FB`
  * `ulong XR_SEMANTIC_LABELS_SUPPORT_ACCEPT_DESK_TO_TABLE_MIGRATION_BIT_FB`
  * `ulong XR_SEMANTIC_LABELS_SUPPORT_ACCEPT_INVISIBLE_WALL_FACE_BIT_FB`
  * `ulong XR_DIGITAL_LENS_CONTROL_PROCESSING_DISABLE_BIT_ALMALENCE`
  * `ulong XR_FOVEATION_EYE_TRACKED_STATE_VALID_BIT_META`
  * `ulong XR_COMPOSITION_LAYER_SETTINGS_NORMAL_SUPER_SAMPLING_BIT_FB`
  * `ulong XR_COMPOSITION_LAYER_SETTINGS_QUALITY_SUPER_SAMPLING_BIT_FB`
  * `ulong XR_COMPOSITION_LAYER_SETTINGS_NORMAL_SHARPENING_BIT_FB`
  * `ulong XR_COMPOSITION_LAYER_SETTINGS_QUALITY_SHARPENING_BIT_FB`
  * `ulong XR_COMPOSITION_LAYER_SETTINGS_AUTO_LAYER_FILTER_BIT_META`
  * `ulong XR_FRAME_SYNTHESIS_INFO_USE_2D_MOTION_VECTOR_BIT_EXT`
  * `ulong XR_FRAME_SYNTHESIS_INFO_REQUEST_RELAXED_FRAME_INTERVAL_BIT_EXT`
  * `ulong XR_PASSTHROUGH_PREFERENCE_DEFAULT_TO_ACTIVE_BIT_META`
  * `ulong XR_VIRTUAL_KEYBOARD_INPUT_STATE_PRESSED_BIT_META`
  * `ulong XR_EXTERNAL_CAMERA_STATUS_CONNECTED_BIT_OCULUS`
  * `ulong XR_EXTERNAL_CAMERA_STATUS_CALIBRATING_BIT_OCULUS`
  * `ulong XR_EXTERNAL_CAMERA_STATUS_CALIBRATION_FAILED_BIT_OCULUS`
  * `ulong XR_EXTERNAL_CAMERA_STATUS_CALIBRATED_BIT_OCULUS`
  * `ulong XR_EXTERNAL_CAMERA_STATUS_CAPTURING_BIT_OCULUS`
  * `ulong XR_PERFORMANCE_METRICS_COUNTER_ANY_VALUE_VALID_BIT_META`
  * `ulong XR_PERFORMANCE_METRICS_COUNTER_UINT_VALUE_VALID_BIT_META`
  * `ulong XR_PERFORMANCE_METRICS_COUNTER_FLOAT_VALUE_VALID_BIT_META`
  * `ulong XR_FOVEATION_DYNAMIC_LEVEL_ENABLED_BIT_HTC`
  * `ulong XR_FOVEATION_DYNAMIC_CLEAR_FOV_ENABLED_BIT_HTC`
  * `ulong XR_FOVEATION_DYNAMIC_FOCAL_CENTER_OFFSET_ENABLED_BIT_HTC`
  * `ulong XR_SPATIAL_MESH_CONFIG_SEMANTIC_BIT_BD`
  * `ulong XR_SPATIAL_MESH_CONFIG_ALIGN_SEMANTIC_WITH_VERTEX_BIT_BD`
  * `ulong XR_SPACE_ACCELERATION_LINEAR_VALID_BIT_BD`
  * `ulong XR_SPACE_ACCELERATION_ANGULAR_VALID_BIT_BD`
  * `ulong XR_SOUND_OBSTACLE_ENABLED_BIT_BD`
  * `ulong XR_SOUND_OBSTACLE_POSE_BIT_BD`
  * `ulong XR_SOUND_OBSTACLE_MESH_BIT_BD`
  * `ulong XR_SOUND_OBSTACLE_MATERIALS_BIT_BD`
  * `ulong XR_SOUND_OBJECT_ENABLED_BIT_BD`
  * `ulong XR_SOUND_OBJECT_POSE_BIT_BD`
  * `ulong XR_SOUND_OBJECT_DIRECTIVITY_BIT_BD`
  * `ulong XR_SOUND_OBJECT_SHAPE_BIT_BD`
  * `ulong XR_SOUND_OBJECT_MAIN_VOLUME_BIT_BD`
  * `ulong XR_SOUND_OBJECT_REFLECTION_GAIN_BIT_BD`
  * `ulong XR_SOUND_OBJECT_ENABLE_DOPPLER_BIT_BD`
  * `ulong XR_SOUND_OBJECT_DIRECT_SOUND_ATTENUATION_BIT_BD`
  * `ulong XR_SOUND_OBJECT_INDIRECT_SOUND_ATTENUATION_BIT_BD`
  * `ulong XR_SOUND_FIELD_ENABLED_BIT_BD`
  * `ulong XR_SOUND_FIELD_ORIENTATION_BIT_BD`
  * `ulong XR_SOUND_FIELD_MAIN_VOLUME_BIT_BD`
  * `ulong XR_SOUND_FIELD_LFE_GAIN_BIT_BD`
  * `ulong XR_PLANE_DETECTION_CAPABILITY_PLANE_DETECTION_BIT_EXT`
  * `ulong XR_PLANE_DETECTION_CAPABILITY_PLANE_HOLES_BIT_EXT`
  * `ulong XR_PLANE_DETECTION_CAPABILITY_SEMANTIC_CEILING_BIT_EXT`
  * `ulong XR_PLANE_DETECTION_CAPABILITY_SEMANTIC_FLOOR_BIT_EXT`
  * `ulong XR_PLANE_DETECTION_CAPABILITY_SEMANTIC_WALL_BIT_EXT`
  * `ulong XR_PLANE_DETECTION_CAPABILITY_SEMANTIC_PLATFORM_BIT_EXT`
  * `ulong XR_PLANE_DETECTION_CAPABILITY_ORIENTATION_BIT_EXT`
  * `ulong XR_PLANE_DETECTOR_ENABLE_CONTOUR_BIT_EXT`
  * `ulong XR_PERFORMANCE_METRICS_COUNTER_ANY_VALUE_VALID_BIT_ANDROID`
  * `ulong XR_PERFORMANCE_METRICS_COUNTER_UINT_VALUE_VALID_BIT_ANDROID`
  * `ulong XR_PERFORMANCE_METRICS_COUNTER_FLOAT_VALUE_VALID_BIT_ANDROID`
  * `ulong XR_WORLD_MESH_DETECTOR_POINT_CLOUD_BIT_ML`
  * `ulong XR_WORLD_MESH_DETECTOR_COMPUTE_NORMALS_BIT_ML`
  * `ulong XR_WORLD_MESH_DETECTOR_COMPUTE_CONFIDENCE_BIT_ML`
  * `ulong XR_WORLD_MESH_DETECTOR_PLANARIZE_BIT_ML`
  * `ulong XR_WORLD_MESH_DETECTOR_REMOVE_MESH_SKIRT_BIT_ML`
  * `ulong XR_WORLD_MESH_DETECTOR_INDEX_ORDER_CW_BIT_ML`
  * `ulong XR_FACIAL_EXPRESSION_BLEND_SHAPE_PROPERTIES_VALID_BIT_ML`
  * `ulong XR_FACIAL_EXPRESSION_BLEND_SHAPE_PROPERTIES_TRACKED_BIT_ML`
  * `ulong XR_GEOSPATIAL_POSE_ORIENTATION_VALID_BIT_ANDROID`
  * `ulong XR_GEOSPATIAL_POSE_POSITION_VALID_BIT_ANDROID`
  * `ulong XR_BATTERY_STATE_DISPLAY_STATE_VALID_BIT_EXT`
  * `ulong XR_BATTERY_STATE_DISPLAY_STATE_CHARGING_BIT_EXT`
  * `ulong XR_BATTERY_STATE_DISPLAY_STATE_PLUGGED_IN_BIT_EXT`
  * `ulong XR_BATTERY_STATE_DISPLAY_STATE_NO_BATTERY_BIT_EXT`
  * `int OPENXR_H_`
  * `int XR_VERSION_1_0`
  * `ulong XR_CURRENT_API_VERSION`
  * `ulong XR_API_VERSION_1_0`
  * `int XR_MIN_COMPOSITION_LAYERS_SUPPORTED`
  * `int XR_NULL_SYSTEM_ID`
  * `int XR_NULL_PATH`
  * `int XR_NO_DURATION`
  * `long XR_INFINITE_DURATION`
  * `int XR_MIN_HAPTIC_DURATION`
  * `int XR_FREQUENCY_UNSPECIFIED`
  * `ulong XR_MAX_EVENT_DATA_SIZE`
  * `int XR_EXTENSION_ENUM_BASE`
  * `int XR_EXTENSION_ENUM_STRIDE`
  * `int XR_TRUE`
  * `int XR_FALSE`
  * `int XR_MAX_EXTENSION_NAME_SIZE`
  * `int XR_MAX_API_LAYER_NAME_SIZE`
  * `int XR_MAX_API_LAYER_DESCRIPTION_SIZE`
  * `int XR_MAX_SYSTEM_NAME_SIZE`
  * `int XR_MAX_APPLICATION_NAME_SIZE`
  * `int XR_MAX_ENGINE_NAME_SIZE`
  * `int XR_MAX_RUNTIME_NAME_SIZE`
  * `int XR_MAX_PATH_LENGTH`
  * `int XR_MAX_STRUCTURE_NAME_SIZE`
  * `int XR_MAX_RESULT_STRING_SIZE`
  * `int XR_MAX_ACTION_SET_NAME_SIZE`
  * `int XR_MAX_LOCALIZED_ACTION_SET_NAME_SIZE`
  * `int XR_MAX_ACTION_NAME_SIZE`
  * `int XR_MAX_LOCALIZED_ACTION_NAME_SIZE`
  * `int XR_VERSION_1_1`
  * `ulong XR_API_VERSION_1_1`
  * `int XR_UUID_SIZE`
  * `int XR_KHR_composition_layer_cube`
  * `int XR_KHR_composition_layer_cube_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_COMPOSITION_LAYER_CUBE_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_composition_layer_depth`
  * `int XR_KHR_composition_layer_depth_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_COMPOSITION_LAYER_DEPTH_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_composition_layer_cylinder`
  * `int XR_KHR_composition_layer_cylinder_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_COMPOSITION_LAYER_CYLINDER_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_composition_layer_equirect`
  * `int XR_KHR_composition_layer_equirect_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_COMPOSITION_LAYER_EQUIRECT_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_visibility_mask`
  * `int XR_KHR_visibility_mask_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_VISIBILITY_MASK_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_composition_layer_color_scale_bias`
  * `int XR_KHR_composition_layer_color_scale_bias_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_COMPOSITION_LAYER_COLOR_SCALE_BIAS_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_loader_init`
  * `int XR_KHR_loader_init_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_LOADER_INIT_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_composition_layer_equirect2`
  * `int XR_KHR_composition_layer_equirect2_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_COMPOSITION_LAYER_EQUIRECT2_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_binding_modification`
  * `int XR_KHR_binding_modification_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_BINDING_MODIFICATION_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_extended_struct_name_lengths`
  * `int XR_KHR_extended_struct_name_lengths_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_EXTENDED_STRUCT_NAME_LENGTHS_EXTENSION_NAME { get; set; }`
  * `int XR_MAX_STRUCTURE_NAME_SIZE_EXTENDED_KHR`
  * `int XR_KHR_swapchain_usage_input_attachment_bit`
  * `int XR_KHR_swapchain_usage_input_attachment_bit_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_SWAPCHAIN_USAGE_INPUT_ATTACHMENT_BIT_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_locate_spaces`
  * `int XR_KHR_locate_spaces_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_LOCATE_SPACES_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_maintenance1`
  * `int XR_KHR_maintenance1_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_MAINTENANCE1_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_generic_controller`
  * `int XR_KHR_generic_controller_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_GENERIC_CONTROLLER_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_performance_settings`
  * `int XR_EXT_performance_settings_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_PERFORMANCE_SETTINGS_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_thermal_query`
  * `int XR_EXT_thermal_query_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_THERMAL_QUERY_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_debug_utils`
  * `int XR_EXT_debug_utils_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_DEBUG_UTILS_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_eye_gaze_interaction`
  * `int XR_EXT_eye_gaze_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_EYE_GAZE_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_EXTX_overlay`
  * `int XR_EXTX_overlay_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXTX_OVERLAY_EXTENSION_NAME { get; set; }`
  * `int XR_VARJO_quad_views`
  * `int XR_VARJO_quad_views_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_VARJO_QUAD_VIEWS_EXTENSION_NAME { get; set; }`
  * `int XR_MSFT_unbounded_reference_space`
  * `int XR_MSFT_unbounded_reference_space_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MSFT_UNBOUNDED_REFERENCE_SPACE_EXTENSION_NAME { get; set; }`
  * `int XR_MSFT_spatial_anchor`
  * `int XR_MSFT_spatial_anchor_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MSFT_SPATIAL_ANCHOR_EXTENSION_NAME { get; set; }`
  * `int XR_FB_composition_layer_image_layout`
  * `int XR_FB_composition_layer_image_layout_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_COMPOSITION_LAYER_IMAGE_LAYOUT_EXTENSION_NAME { get; set; }`
  * `int XR_FB_composition_layer_alpha_blend`
  * `int XR_FB_composition_layer_alpha_blend_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_COMPOSITION_LAYER_ALPHA_BLEND_EXTENSION_NAME { get; set; }`
  * `int XR_MND_headless`
  * `int XR_MND_headless_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MND_HEADLESS_EXTENSION_NAME { get; set; }`
  * `int XR_OCULUS_android_session_state_enable`
  * `int XR_OCULUS_android_session_state_enable_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_OCULUS_ANDROID_SESSION_STATE_ENABLE_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_view_configuration_depth_range`
  * `int XR_EXT_view_configuration_depth_range_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_VIEW_CONFIGURATION_DEPTH_RANGE_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_conformance_automation`
  * `int XR_EXT_conformance_automation_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_CONFORMANCE_AUTOMATION_EXTENSION_NAME { get; set; }`
  * `int XR_MSFT_spatial_graph_bridge`
  * `int XR_GUID_SIZE_MSFT`
  * `int XR_MSFT_spatial_graph_bridge_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MSFT_SPATIAL_GRAPH_BRIDGE_EXTENSION_NAME { get; set; }`
  * `int XR_MSFT_hand_interaction`
  * `int XR_MSFT_hand_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MSFT_HAND_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_hand_tracking`
  * `int XR_HAND_JOINT_COUNT_EXT`
  * `int XR_EXT_hand_tracking_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_HAND_TRACKING_EXTENSION_NAME { get; set; }`
  * `int XR_MSFT_hand_tracking_mesh`
  * `int XR_MSFT_hand_tracking_mesh_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MSFT_HAND_TRACKING_MESH_EXTENSION_NAME { get; set; }`
  * `int XR_MSFT_secondary_view_configuration`
  * `int XR_MSFT_secondary_view_configuration_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MSFT_SECONDARY_VIEW_CONFIGURATION_EXTENSION_NAME { get; set; }`
  * `int XR_MSFT_first_person_observer`
  * `int XR_MSFT_first_person_observer_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MSFT_FIRST_PERSON_OBSERVER_EXTENSION_NAME { get; set; }`
  * `int XR_MSFT_controller_model`
  * `int XR_NULL_CONTROLLER_MODEL_KEY_MSFT`
  * `int XR_MAX_CONTROLLER_MODEL_NODE_NAME_SIZE_MSFT`
  * `int XR_MSFT_controller_model_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MSFT_CONTROLLER_MODEL_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_win32_appcontainer_compatible`
  * `int XR_EXT_win32_appcontainer_compatible_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_WIN32_APPCONTAINER_COMPATIBLE_EXTENSION_NAME { get; set; }`
  * `int XR_EPIC_view_configuration_fov`
  * `int XR_EPIC_view_configuration_fov_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EPIC_VIEW_CONFIGURATION_FOV_EXTENSION_NAME { get; set; }`
  * `int XR_MSFT_composition_layer_reprojection`
  * `int XR_MSFT_composition_layer_reprojection_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MSFT_COMPOSITION_LAYER_REPROJECTION_EXTENSION_NAME { get; set; }`
  * `int XR_HUAWEI_controller_interaction`
  * `int XR_HUAWEI_controller_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_HUAWEI_CONTROLLER_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_FB_swapchain_update_state`
  * `int XR_FB_swapchain_update_state_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_SWAPCHAIN_UPDATE_STATE_EXTENSION_NAME { get; set; }`
  * `int XR_FB_composition_layer_secure_content`
  * `int XR_FB_composition_layer_secure_content_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_COMPOSITION_LAYER_SECURE_CONTENT_EXTENSION_NAME { get; set; }`
  * `int XR_FB_body_tracking`
  * `int XR_FB_body_tracking_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_BODY_TRACKING_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_dpad_binding`
  * `int XR_EXT_dpad_binding_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_DPAD_BINDING_EXTENSION_NAME { get; set; }`
  * `int XR_VALVE_analog_threshold`
  * `int XR_VALVE_analog_threshold_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_VALVE_ANALOG_THRESHOLD_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_hand_joints_motion_range`
  * `int XR_EXT_hand_joints_motion_range_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_HAND_JOINTS_MOTION_RANGE_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_samsung_odyssey_controller`
  * `int XR_EXT_samsung_odyssey_controller_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_SAMSUNG_ODYSSEY_CONTROLLER_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_hp_mixed_reality_controller`
  * `int XR_EXT_hp_mixed_reality_controller_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_HP_MIXED_REALITY_CONTROLLER_EXTENSION_NAME { get; set; }`
  * `int XR_MND_swapchain_usage_input_attachment_bit`
  * `int XR_MND_swapchain_usage_input_attachment_bit_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MND_SWAPCHAIN_USAGE_INPUT_ATTACHMENT_BIT_EXTENSION_NAME { get; set; }`
  * `int XR_MSFT_scene_understanding`
  * `int XR_MSFT_scene_understanding_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MSFT_SCENE_UNDERSTANDING_EXTENSION_NAME { get; set; }`
  * `int XR_MSFT_scene_understanding_serialization`
  * `int XR_MSFT_scene_understanding_serialization_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MSFT_SCENE_UNDERSTANDING_SERIALIZATION_EXTENSION_NAME { get; set; }`
  * `int XR_FB_display_refresh_rate`
  * `int XR_FB_display_refresh_rate_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_DISPLAY_REFRESH_RATE_EXTENSION_NAME { get; set; }`
  * `int XR_HTC_vive_cosmos_controller_interaction`
  * `int XR_HTC_vive_cosmos_controller_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_HTC_VIVE_COSMOS_CONTROLLER_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_HTCX_vive_tracker_interaction`
  * `int XR_HTCX_vive_tracker_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_HTCX_VIVE_TRACKER_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_HTC_facial_tracking`
  * `int XR_FACIAL_EXPRESSION_EYE_COUNT_HTC`
  * `int XR_FACIAL_EXPRESSION_LIP_COUNT_HTC`
  * `int XR_HTC_facial_tracking_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_HTC_FACIAL_TRACKING_EXTENSION_NAME { get; set; }`
  * `int XR_HTC_vive_focus3_controller_interaction`
  * `int XR_HTC_vive_focus3_controller_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_HTC_VIVE_FOCUS3_CONTROLLER_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_HTC_hand_interaction`
  * `int XR_HTC_hand_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_HTC_HAND_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_HTC_vive_wrist_tracker_interaction`
  * `int XR_HTC_vive_wrist_tracker_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_HTC_VIVE_WRIST_TRACKER_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_FB_color_space`
  * `int XR_FB_color_space_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_COLOR_SPACE_EXTENSION_NAME { get; set; }`
  * `int XR_FB_hand_tracking_mesh`
  * `int XR_FB_hand_tracking_mesh_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_HAND_TRACKING_MESH_EXTENSION_NAME { get; set; }`
  * `int XR_FB_hand_tracking_aim`
  * `int XR_FB_hand_tracking_aim_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_HAND_TRACKING_AIM_EXTENSION_NAME { get; set; }`
  * `int XR_FB_hand_tracking_capsules`
  * `int XR_HAND_TRACKING_CAPSULE_POINT_COUNT_FB`
  * `int XR_HAND_TRACKING_CAPSULE_COUNT_FB`
  * `int XR_FB_hand_tracking_capsules_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_HAND_TRACKING_CAPSULES_EXTENSION_NAME { get; set; }`
  * `int XR_FB_HAND_TRACKING_CAPSULE_POINT_COUNT`
  * `int XR_FB_HAND_TRACKING_CAPSULE_COUNT`
  * `int XR_FB_spatial_entity`
  * `int XR_FB_spatial_entity_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_SPATIAL_ENTITY_EXTENSION_NAME { get; set; }`
  * `int XR_FB_foveation`
  * `int XR_FB_foveation_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_FOVEATION_EXTENSION_NAME { get; set; }`
  * `int XR_FB_foveation_configuration`
  * `int XR_FB_foveation_configuration_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_FOVEATION_CONFIGURATION_EXTENSION_NAME { get; set; }`
  * `int XR_FB_keyboard_tracking`
  * `int XR_MAX_KEYBOARD_TRACKING_NAME_SIZE_FB`
  * `int XR_FB_keyboard_tracking_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_KEYBOARD_TRACKING_EXTENSION_NAME { get; set; }`
  * `int XR_FB_triangle_mesh`
  * `int XR_FB_triangle_mesh_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_TRIANGLE_MESH_EXTENSION_NAME { get; set; }`
  * `int XR_FB_passthrough`
  * `int XR_PASSTHROUGH_COLOR_MAP_MONO_SIZE_FB`
  * `int XR_FB_passthrough_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_PASSTHROUGH_EXTENSION_NAME { get; set; }`
  * `int XR_FB_render_model`
  * `int XR_NULL_RENDER_MODEL_KEY_FB`
  * `int XR_MAX_RENDER_MODEL_NAME_SIZE_FB`
  * `int XR_FB_render_model_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_RENDER_MODEL_EXTENSION_NAME { get; set; }`
  * `int XR_VARJO_foveated_rendering`
  * `int XR_VARJO_foveated_rendering_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_VARJO_FOVEATED_RENDERING_EXTENSION_NAME { get; set; }`
  * `int XR_VARJO_composition_layer_depth_test`
  * `int XR_VARJO_composition_layer_depth_test_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_VARJO_COMPOSITION_LAYER_DEPTH_TEST_EXTENSION_NAME { get; set; }`
  * `int XR_VARJO_environment_depth_estimation`
  * `int XR_VARJO_environment_depth_estimation_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_VARJO_ENVIRONMENT_DEPTH_ESTIMATION_EXTENSION_NAME { get; set; }`
  * `int XR_VARJO_marker_tracking`
  * `int XR_VARJO_marker_tracking_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_VARJO_MARKER_TRACKING_EXTENSION_NAME { get; set; }`
  * `int XR_VARJO_view_offset`
  * `int XR_VARJO_view_offset_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_VARJO_VIEW_OFFSET_EXTENSION_NAME { get; set; }`
  * `int XR_VARJO_xr4_controller_interaction`
  * `int XR_VARJO_xr4_controller_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_VARJO_XR4_CONTROLLER_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_ML_ml2_controller_interaction`
  * `int XR_ML_ml2_controller_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ML_ML2_CONTROLLER_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_ML_frame_end_info`
  * `int XR_ML_frame_end_info_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ML_FRAME_END_INFO_EXTENSION_NAME { get; set; }`
  * `int XR_ML_global_dimmer`
  * `int XR_ML_global_dimmer_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ML_GLOBAL_DIMMER_EXTENSION_NAME { get; set; }`
  * `int XR_ML_marker_understanding`
  * `int XR_ML_marker_understanding_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ML_MARKER_UNDERSTANDING_EXTENSION_NAME { get; set; }`
  * `int XR_ML_localization_map`
  * `int XR_MAX_LOCALIZATION_MAP_NAME_LENGTH_ML`
  * `int XR_ML_localization_map_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ML_LOCALIZATION_MAP_EXTENSION_NAME { get; set; }`
  * `int XR_ML_spatial_anchors`
  * `int XR_ML_spatial_anchors_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ML_SPATIAL_ANCHORS_EXTENSION_NAME { get; set; }`
  * `int XR_ML_spatial_anchors_storage`
  * `int XR_ML_spatial_anchors_storage_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ML_SPATIAL_ANCHORS_STORAGE_EXTENSION_NAME { get; set; }`
  * `int XR_MSFT_spatial_anchor_persistence`
  * `int XR_MAX_SPATIAL_ANCHOR_NAME_SIZE_MSFT`
  * `int XR_MSFT_spatial_anchor_persistence_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MSFT_SPATIAL_ANCHOR_PERSISTENCE_EXTENSION_NAME { get; set; }`
  * `int XR_MSFT_scene_marker`
  * `int XR_MSFT_scene_marker_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MSFT_SCENE_MARKER_EXTENSION_NAME { get; set; }`
  * `int XR_ULTRALEAP_hand_tracking_forearm`
  * `int XR_HAND_FOREARM_JOINT_COUNT_ULTRALEAP`
  * `int XR_ULTRALEAP_hand_tracking_forearm_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ULTRALEAP_HAND_TRACKING_FOREARM_EXTENSION_NAME { get; set; }`
  * `int XR_FB_spatial_entity_query`
  * `int XR_FB_spatial_entity_query_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_SPATIAL_ENTITY_QUERY_EXTENSION_NAME { get; set; }`
  * `int XR_FB_spatial_entity_storage`
  * `int XR_FB_spatial_entity_storage_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_SPATIAL_ENTITY_STORAGE_EXTENSION_NAME { get; set; }`
  * `int XR_FB_touch_controller_pro`
  * `int XR_FB_touch_controller_pro_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_TOUCH_CONTROLLER_PRO_EXTENSION_NAME { get; set; }`
  * `int XR_FB_spatial_entity_sharing`
  * `int XR_FB_spatial_entity_sharing_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_SPATIAL_ENTITY_SHARING_EXTENSION_NAME { get; set; }`
  * `int XR_FB_space_warp`
  * `int XR_FB_space_warp_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_SPACE_WARP_EXTENSION_NAME { get; set; }`
  * `int XR_FB_haptic_amplitude_envelope`
  * `uint XR_MAX_HAPTIC_AMPLITUDE_ENVELOPE_SAMPLES_FB`
  * `int XR_FB_haptic_amplitude_envelope_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_HAPTIC_AMPLITUDE_ENVELOPE_EXTENSION_NAME { get; set; }`
  * `int XR_FB_scene`
  * `int XR_FB_scene_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_SCENE_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_palm_pose`
  * `int XR_EXT_palm_pose_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_PALM_POSE_EXTENSION_NAME { get; set; }`
  * `int XR_ALMALENCE_digital_lens_control`
  * `int XR_ALMALENCE_digital_lens_control_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ALMALENCE_DIGITAL_LENS_CONTROL_EXTENSION_NAME { get; set; }`
  * `int XR_FB_scene_capture`
  * `int XR_FB_scene_capture_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_SCENE_CAPTURE_EXTENSION_NAME { get; set; }`
  * `int XR_FB_spatial_entity_container`
  * `int XR_FB_spatial_entity_container_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_SPATIAL_ENTITY_CONTAINER_EXTENSION_NAME { get; set; }`
  * `int XR_META_foveation_eye_tracked`
  * `int XR_FOVEATION_CENTER_SIZE_META`
  * `int XR_META_foveation_eye_tracked_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_FOVEATION_EYE_TRACKED_EXTENSION_NAME { get; set; }`
  * `int XR_FB_face_tracking`
  * `XrFaceExpressionSetFB XR_FACE_EXPRESSSION_SET_DEFAULT_FB`
  * `int XR_FB_face_tracking_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_FACE_TRACKING_EXTENSION_NAME { get; set; }`
  * `int XR_FB_eye_tracking_social`
  * `int XR_FB_eye_tracking_social_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_EYE_TRACKING_SOCIAL_EXTENSION_NAME { get; set; }`
  * `int XR_FB_passthrough_keyboard_hands`
  * `int XR_FB_passthrough_keyboard_hands_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_PASSTHROUGH_KEYBOARD_HANDS_EXTENSION_NAME { get; set; }`
  * `int XR_FB_composition_layer_settings`
  * `int XR_FB_composition_layer_settings_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_COMPOSITION_LAYER_SETTINGS_EXTENSION_NAME { get; set; }`
  * `int XR_FB_touch_controller_proximity`
  * `int XR_FB_touch_controller_proximity_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_TOUCH_CONTROLLER_PROXIMITY_EXTENSION_NAME { get; set; }`
  * `int XR_FB_haptic_pcm`
  * `int XR_MAX_HAPTIC_PCM_BUFFER_SIZE_FB`
  * `int XR_FB_haptic_pcm_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_HAPTIC_PCM_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_frame_synthesis`
  * `int XR_EXT_frame_synthesis_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_FRAME_SYNTHESIS_EXTENSION_NAME { get; set; }`
  * `int XR_FB_composition_layer_depth_test`
  * `int XR_FB_composition_layer_depth_test_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_COMPOSITION_LAYER_DEPTH_TEST_EXTENSION_NAME { get; set; }`
  * `int XR_META_local_dimming`
  * `int XR_META_local_dimming_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_LOCAL_DIMMING_EXTENSION_NAME { get; set; }`
  * `int XR_META_passthrough_preferences`
  * `int XR_META_passthrough_preferences_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_PASSTHROUGH_PREFERENCES_EXTENSION_NAME { get; set; }`
  * `int XR_META_virtual_keyboard`
  * `int XR_MAX_VIRTUAL_KEYBOARD_COMMIT_TEXT_SIZE_META`
  * `int XR_META_virtual_keyboard_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_VIRTUAL_KEYBOARD_EXTENSION_NAME { get; set; }`
  * `int XR_OCULUS_external_camera`
  * `int XR_MAX_EXTERNAL_CAMERA_NAME_SIZE_OCULUS`
  * `int XR_OCULUS_external_camera_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_OCULUS_EXTERNAL_CAMERA_EXTENSION_NAME { get; set; }`
  * `int XR_META_performance_metrics`
  * `int XR_META_performance_metrics_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_PERFORMANCE_METRICS_EXTENSION_NAME { get; set; }`
  * `int XR_FB_spatial_entity_storage_batch`
  * `int XR_FB_spatial_entity_storage_batch_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_SPATIAL_ENTITY_STORAGE_BATCH_EXTENSION_NAME { get; set; }`
  * `int XR_META_detached_controllers`
  * `int XR_META_detached_controllers_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_DETACHED_CONTROLLERS_EXTENSION_NAME { get; set; }`
  * `int XR_FB_spatial_entity_user`
  * `int XR_FB_spatial_entity_user_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_SPATIAL_ENTITY_USER_EXTENSION_NAME { get; set; }`
  * `int XR_META_headset_id`
  * `int XR_META_headset_id_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_HEADSET_ID_EXTENSION_NAME { get; set; }`
  * `int XR_META_spatial_entity_discovery`
  * `int XR_META_spatial_entity_discovery_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_SPATIAL_ENTITY_DISCOVERY_EXTENSION_NAME { get; set; }`
  * `int XR_META_hand_tracking_microgestures`
  * `int XR_META_hand_tracking_microgestures_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_HAND_TRACKING_MICROGESTURES_EXTENSION_NAME { get; set; }`
  * `int XR_META_recommended_layer_resolution`
  * `int XR_META_recommended_layer_resolution_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_RECOMMENDED_LAYER_RESOLUTION_EXTENSION_NAME { get; set; }`
  * `int XR_META_spatial_entity_persistence`
  * `int XR_META_spatial_entity_persistence_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_SPATIAL_ENTITY_PERSISTENCE_EXTENSION_NAME { get; set; }`
  * `int XR_META_passthrough_color_lut`
  * `int XR_META_passthrough_color_lut_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_PASSTHROUGH_COLOR_LUT_EXTENSION_NAME { get; set; }`
  * `int XR_META_spatial_entity_mesh`
  * `int XR_META_spatial_entity_mesh_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_SPATIAL_ENTITY_MESH_EXTENSION_NAME { get; set; }`
  * `int XR_META_automatic_layer_filter`
  * `int XR_META_automatic_layer_filter_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_AUTOMATIC_LAYER_FILTER_EXTENSION_NAME { get; set; }`
  * `int XR_META_body_tracking_full_body`
  * `int XR_META_body_tracking_full_body_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_BODY_TRACKING_FULL_BODY_EXTENSION_NAME { get; set; }`
  * `int XR_META_touch_controller_plus`
  * `int XR_META_touch_controller_plus_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_TOUCH_CONTROLLER_PLUS_EXTENSION_NAME { get; set; }`
  * `int XR_META_passthrough_layer_resumed_event`
  * `int XR_META_passthrough_layer_resumed_event_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_PASSTHROUGH_LAYER_RESUMED_EVENT_EXTENSION_NAME { get; set; }`
  * `int XR_META_body_tracking_calibration`
  * `int XR_META_body_tracking_calibration_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_BODY_TRACKING_CALIBRATION_EXTENSION_NAME { get; set; }`
  * `int XR_META_body_tracking_fidelity`
  * `int XR_META_body_tracking_fidelity_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_BODY_TRACKING_FIDELITY_EXTENSION_NAME { get; set; }`
  * `int XR_FB_face_tracking2`
  * `int XR_FB_face_tracking2_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_FACE_TRACKING2_EXTENSION_NAME { get; set; }`
  * `int XR_META_spatial_entity_sharing`
  * `int XR_META_spatial_entity_sharing_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_SPATIAL_ENTITY_SHARING_EXTENSION_NAME { get; set; }`
  * `int XR_MAX_SPACES_PER_SHARE_REQUEST_META`
  * `int XR_META_environment_depth`
  * `int XR_META_environment_depth_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_ENVIRONMENT_DEPTH_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_uuid`
  * `int XR_EXT_uuid_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_UUID_EXTENSION_NAME { get; set; }`
  * `int XR_UUID_SIZE_EXT`
  * `int XR_EXT_render_model`
  * `int XR_MAX_RENDER_MODEL_ASSET_NODE_NAME_SIZE_EXT`
  * `int XR_EXT_render_model_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_RENDER_MODEL_EXTENSION_NAME { get; set; }`
  * `int XR_NULL_RENDER_MODEL_ID_EXT`
  * `int XR_EXT_interaction_render_model`
  * `int XR_EXT_interaction_render_model_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_INTERACTION_RENDER_MODEL_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_hand_interaction`
  * `int XR_EXT_hand_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_HAND_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_QCOM_tracking_optimization_settings`
  * `int XR_QCOM_tracking_optimization_settings_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_QCOM_TRACKING_OPTIMIZATION_SETTINGS_EXTENSION_NAME { get; set; }`
  * `int XR_QCOM_hand_tracking_gesture`
  * `int XR_QCOM_hand_tracking_gesture_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_QCOM_HAND_TRACKING_GESTURE_EXTENSION_NAME { get; set; }`
  * `int XR_HTC_passthrough`
  * `int XR_HTC_passthrough_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_HTC_PASSTHROUGH_EXTENSION_NAME { get; set; }`
  * `int XR_HTC_foveation`
  * `int XR_HTC_foveation_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_HTC_FOVEATION_EXTENSION_NAME { get; set; }`
  * `int XR_HTC_anchor`
  * `int XR_MAX_SPATIAL_ANCHOR_NAME_SIZE_HTC`
  * `int XR_HTC_anchor_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_HTC_ANCHOR_EXTENSION_NAME { get; set; }`
  * `int XR_HTC_body_tracking`
  * `int XR_BODY_JOINT_COUNT_HTC`
  * `int XR_HTC_body_tracking_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_HTC_BODY_TRACKING_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_active_action_set_priority`
  * `int XR_EXT_active_action_set_priority_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_ACTIVE_ACTION_SET_PRIORITY_EXTENSION_NAME { get; set; }`
  * `int XR_MNDX_force_feedback_curl`
  * `int XR_MNDX_force_feedback_curl_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MNDX_FORCE_FEEDBACK_CURL_EXTENSION_NAME { get; set; }`
  * `int XR_BD_controller_interaction`
  * `int XR_BD_controller_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_BD_CONTROLLER_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_BD_body_tracking`
  * `int XR_BODY_JOINT_COUNT_BD`
  * `int XR_BODY_JOINT_WITHOUT_ARM_COUNT_BD`
  * `int XR_BD_body_tracking_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_BD_BODY_TRACKING_EXTENSION_NAME { get; set; }`
  * `int XR_BD_facial_simulation`
  * `int XR_FACE_EXPRESSION_COUNT_BD`
  * `int XR_LIP_EXPRESSION_COUNT_BD`
  * `int XR_BD_facial_simulation_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_BD_FACIAL_SIMULATION_EXTENSION_NAME { get; set; }`
  * `int XR_BD_spatial_sensing`
  * `int XR_BD_spatial_sensing_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_BD_SPATIAL_SENSING_EXTENSION_NAME { get; set; }`
  * `int XR_BD_spatial_anchor`
  * `int XR_BD_spatial_anchor_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_BD_SPATIAL_ANCHOR_EXTENSION_NAME { get; set; }`
  * `int XR_BD_spatial_anchor_sharing`
  * `int XR_BD_spatial_anchor_sharing_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_BD_SPATIAL_ANCHOR_SHARING_EXTENSION_NAME { get; set; }`
  * `int XR_BD_spatial_scene`
  * `int XR_BD_spatial_scene_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_BD_SPATIAL_SCENE_EXTENSION_NAME { get; set; }`
  * `int XR_BD_spatial_mesh`
  * `int XR_BD_spatial_mesh_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_BD_SPATIAL_MESH_EXTENSION_NAME { get; set; }`
  * `int XR_BD_future_progress`
  * `int XR_BD_future_progress_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_BD_FUTURE_PROGRESS_EXTENSION_NAME { get; set; }`
  * `int XR_BD_body_tracking_auxiliary_metrics`
  * `int XR_BD_body_tracking_auxiliary_metrics_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_BD_BODY_TRACKING_AUXILIARY_METRICS_EXTENSION_NAME { get; set; }`
  * `int XR_BD_spatial_plane`
  * `int XR_BD_spatial_plane_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_BD_SPATIAL_PLANE_EXTENSION_NAME { get; set; }`
  * `int XR_BD_ultra_controller_interaction`
  * `int XR_BD_ultra_controller_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_BD_ULTRA_CONTROLLER_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_BD_spatial_audio_rendering`
  * `int XR_BD_spatial_audio_rendering_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_BD_SPATIAL_AUDIO_RENDERING_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_local_floor`
  * `int XR_EXT_local_floor_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_LOCAL_FLOOR_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_hand_tracking_data_source`
  * `int XR_EXT_hand_tracking_data_source_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_HAND_TRACKING_DATA_SOURCE_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_plane_detection`
  * `int XR_EXT_plane_detection_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_PLANE_DETECTION_EXTENSION_NAME { get; set; }`
  * `int XR_OPPO_controller_interaction`
  * `int XR_OPPO_controller_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_OPPO_CONTROLLER_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_trackables`
  * `int XR_NULL_TRACKABLE_ANDROID`
  * `int XR_ANDROID_trackables_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_TRACKABLES_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_eye_tracking`
  * `int XR_EYE_MAX_ANDROID`
  * `int XR_ANDROID_eye_tracking_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_EYE_TRACKING_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_device_anchor_persistence`
  * `int XR_ANDROID_device_anchor_persistence_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_DEVICE_ANCHOR_PERSISTENCE_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_face_tracking`
  * `int XR_ANDROID_face_tracking_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_FACE_TRACKING_EXTENSION_NAME { get; set; }`
  * `int XR_FACE_PARAMETER_COUNT_ANDROID`
  * `int XR_FACE_REGION_CONFIDENCE_COUNT_ANDROID`
  * `int XR_ANDROID_passthrough_camera_state`
  * `int XR_ANDROID_passthrough_camera_state_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_PASSTHROUGH_CAMERA_STATE_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_recommended_resolution`
  * `int XR_ANDROID_recommended_resolution_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_RECOMMENDED_RESOLUTION_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_composition_layer_passthrough_mesh`
  * `int XR_ANDROID_composition_layer_passthrough_mesh_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_COMPOSITION_LAYER_PASSTHROUGH_MESH_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_raycast`
  * `int XR_ANDROID_raycast_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_RAYCAST_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_performance_metrics`
  * `int XR_ANDROID_performance_metrics_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_PERFORMANCE_METRICS_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_trackables_object`
  * `int XR_ANDROID_trackables_object_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_TRACKABLES_OBJECT_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_unbounded_reference_space`
  * `int XR_ANDROID_unbounded_reference_space_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_UNBOUNDED_REFERENCE_SPACE_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_future`
  * `int XR_EXT_future_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_FUTURE_EXTENSION_NAME { get; set; }`
  * `int XR_NULL_FUTURE_EXT`
  * `int XR_EXT_user_presence`
  * `int XR_EXT_user_presence_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_USER_PRESENCE_EXTENSION_NAME { get; set; }`
  * `int XR_ML_user_calibration`
  * `int XR_ML_user_calibration_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ML_USER_CALIBRATION_EXTENSION_NAME { get; set; }`
  * `int XR_ML_system_notifications`
  * `int XR_ML_system_notifications_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ML_SYSTEM_NOTIFICATIONS_EXTENSION_NAME { get; set; }`
  * `int XR_ML_world_mesh_detection`
  * `int XR_ML_world_mesh_detection_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ML_WORLD_MESH_DETECTION_EXTENSION_NAME { get; set; }`
  * `int XR_ML_facial_expression`
  * `int XR_ML_facial_expression_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ML_FACIAL_EXPRESSION_EXTENSION_NAME { get; set; }`
  * `int XR_ML_view_configuration_depth_range_change`
  * `int XR_ML_view_configuration_depth_range_change_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ML_VIEW_CONFIGURATION_DEPTH_RANGE_CHANGE_EXTENSION_NAME { get; set; }`
  * `int XR_YVR_controller_interaction`
  * `int XR_YVR_controller_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_YVR_CONTROLLER_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_META_boundary_visibility`
  * `int XR_META_boundary_visibility_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_BOUNDARY_VISIBILITY_EXTENSION_NAME { get; set; }`
  * `int XR_META_simultaneous_hands_and_controllers`
  * `int XR_META_simultaneous_hands_and_controllers_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_SIMULTANEOUS_HANDS_AND_CONTROLLERS_EXTENSION_NAME { get; set; }`
  * `int XR_META_face_tracking_visemes`
  * `int XR_FACE_TRACKING_VISEME_COUNT_META`
  * `int XR_META_face_tracking_visemes_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_FACE_TRACKING_VISEMES_EXTENSION_NAME { get; set; }`
  * `int XR_META_spatial_entity_semantic_label`
  * `int XR_META_spatial_entity_semantic_label_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_SPATIAL_ENTITY_SEMANTIC_LABEL_EXTENSION_NAME { get; set; }`
  * `int XR_META_spatial_entity_room_mesh`
  * `int XR_META_spatial_entity_room_mesh_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_SPATIAL_ENTITY_ROOM_MESH_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_composition_layer_inverted_alpha`
  * `int XR_EXT_composition_layer_inverted_alpha_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_COMPOSITION_LAYER_INVERTED_ALPHA_EXTENSION_NAME { get; set; }`
  * `int XR_META_colocation_discovery`
  * `int XR_MAX_COLOCATION_DISCOVERY_BUFFER_SIZE_META`
  * `int XR_META_colocation_discovery_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_COLOCATION_DISCOVERY_EXTENSION_NAME { get; set; }`
  * `int XR_META_spatial_entity_group_sharing`
  * `int XR_META_spatial_entity_group_sharing_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_SPATIAL_ENTITY_GROUP_SHARING_EXTENSION_NAME { get; set; }`
  * `int XR_META_environment_raycast`
  * `int XR_META_environment_raycast_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_ENVIRONMENT_RAYCAST_EXTENSION_NAME { get; set; }`
  * `int XR_META_tile_properties_hint`
  * `int XR_META_tile_properties_hint_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_TILE_PROPERTIES_HINT_EXTENSION_NAME { get; set; }`
  * `int XR_META_hand_tracking_unextrapolated_poses`
  * `int XR_META_hand_tracking_unextrapolated_poses_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_HAND_TRACKING_UNEXTRAPOLATED_POSES_EXTENSION_NAME { get; set; }`
  * `int XR_META_hand_tracking_frequency_hint`
  * `int XR_META_hand_tracking_frequency_hint_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_HAND_TRACKING_FREQUENCY_HINT_EXTENSION_NAME { get; set; }`
  * `int XR_META_hand_tracking_wide_motion_mode2`
  * `int XR_META_hand_tracking_wide_motion_mode2_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_HAND_TRACKING_WIDE_MOTION_MODE2_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_light_estimation`
  * `int XR_ANDROID_light_estimation_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_LIGHT_ESTIMATION_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_mouse_interaction`
  * `int XR_ANDROID_mouse_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_MOUSE_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_trackables_marker`
  * `int XR_ANDROID_trackables_marker_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_TRACKABLES_MARKER_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_trackables_qr_code`
  * `int XR_ANDROID_trackables_qr_code_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_TRACKABLES_QR_CODE_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_trackables_image`
  * `int XR_ANDROID_trackables_image_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_TRACKABLES_IMAGE_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_scene_meshing`
  * `int XR_ANDROID_scene_meshing_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_SCENE_MESHING_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_spatial_entity`
  * `int XR_NULL_SPATIAL_ENTITY_ID_EXT`
  * `int XR_NULL_SPATIAL_BUFFER_ID_EXT`
  * `int XR_EXT_spatial_entity_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_SPATIAL_ENTITY_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_spatial_plane_tracking`
  * `int XR_EXT_spatial_plane_tracking_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_SPATIAL_PLANE_TRACKING_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_stationary_reference_space`
  * `int XR_EXT_stationary_reference_space_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_STATIONARY_REFERENCE_SPACE_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_spatial_marker_tracking`
  * `int XR_EXT_spatial_marker_tracking_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_SPATIAL_MARKER_TRACKING_EXTENSION_NAME { get; set; }`
  * `int XR_LOGITECH_mx_ink_stylus_interaction`
  * `int XR_LOGITECH_mx_ink_stylus_interaction_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_LOGITECH_MX_INK_STYLUS_INTERACTION_EXTENSION_NAME { get; set; }`
  * `int XR_BD_dynamic_object_tracking`
  * `int XR_BD_dynamic_object_tracking_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_BD_DYNAMIC_OBJECT_TRACKING_EXTENSION_NAME { get; set; }`
  * `int XR_BD_dynamic_object_keyboard`
  * `int XR_BD_dynamic_object_keyboard_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_BD_DYNAMIC_OBJECT_KEYBOARD_EXTENSION_NAME { get; set; }`
  * `int XR_BD_dynamic_object_mouse`
  * `int XR_BD_dynamic_object_mouse_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_BD_DYNAMIC_OBJECT_MOUSE_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_spatial_discovery_bounds`
  * `int XR_ANDROID_spatial_discovery_bounds_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_SPATIAL_DISCOVERY_BOUNDS_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_spatial_anchor`
  * `int XR_EXT_spatial_anchor_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_SPATIAL_ANCHOR_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_spatial_persistence`
  * `int XR_EXT_spatial_persistence_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_SPATIAL_PERSISTENCE_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_haptic_parametric`
  * `int XR_HAPTIC_PARAMETRIC_MAX_POINTS_TRANSIENTS_EXT`
  * `int XR_HAPTIC_PARAMETRIC_VIBRATION_EXTEND_DURATION_EXT`
  * `int XR_HAPTIC_PARAMETRIC_FREQUENCY_MIN_HZ_EXT`
  * `int XR_HAPTIC_PARAMETRIC_FREQUENCY_MAX_HZ_EXT`
  * `int XR_EXT_haptic_parametric_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_HAPTIC_PARAMETRIC_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_spatial_persistence_operations`
  * `int XR_EXT_spatial_persistence_operations_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_SPATIAL_PERSISTENCE_OPERATIONS_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_spatial_object_tracking`
  * `int XR_ANDROID_spatial_object_tracking_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_SPATIAL_OBJECT_TRACKING_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_spatial_discovery_raycast`
  * `int XR_ANDROID_spatial_discovery_raycast_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_SPATIAL_DISCOVERY_RAYCAST_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_google_cloud_auth`
  * `int XR_ANDROID_google_cloud_auth_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_GOOGLE_CLOUD_AUTH_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_geospatial`
  * `int XR_ANDROID_geospatial_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_GEOSPATIAL_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_spatial_entity_bound_anchor`
  * `int XR_ANDROID_spatial_entity_bound_anchor_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_SPATIAL_ENTITY_BOUND_ANCHOR_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_spatial_component_subsumed_by`
  * `int XR_ANDROID_spatial_component_subsumed_by_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_SPATIAL_COMPONENT_SUBSUMED_BY_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_spatial_anchor_space`
  * `int XR_ANDROID_spatial_anchor_space_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_SPATIAL_ANCHOR_SPACE_EXTENSION_NAME { get; set; }`
  * `int XR_ANDROID_geospatial_anchor`
  * `int XR_ANDROID_geospatial_anchor_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_ANDROID_GEOSPATIAL_ANCHOR_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_interaction_profile_battery_state_display`
  * `int XR_EXT_interaction_profile_battery_state_display_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_INTERACTION_PROFILE_BATTERY_STATE_DISPLAY_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_loader_init_properties`
  * `int XR_EXT_loader_init_properties_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_LOADER_INIT_PROPERTIES_EXTENSION_NAME { get; set; }`
  * `int XR_EXT_view_configuration_views_change`
  * `int XR_EXT_view_configuration_views_change_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_EXT_VIEW_CONFIGURATION_VIEWS_CHANGE_EXTENSION_NAME { get; set; }`
  * `int OPENXR_PLATFORM_H_`
  * `int XR_KHR_vulkan_swapchain_format_list`
  * `int XR_KHR_vulkan_swapchain_format_list_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_VULKAN_SWAPCHAIN_FORMAT_LIST_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_opengl_enable`
  * `int XR_KHR_opengl_enable_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_OPENGL_ENABLE_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_vulkan_enable`
  * `int XR_KHR_vulkan_enable_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_VULKAN_ENABLE_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_D3D11_enable`
  * `int XR_KHR_D3D11_enable_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_D3D11_ENABLE_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_D3D12_enable`
  * `int XR_KHR_D3D12_enable_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_D3D12_ENABLE_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_win32_convert_performance_counter_time`
  * `int XR_KHR_win32_convert_performance_counter_time_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_WIN32_CONVERT_PERFORMANCE_COUNTER_TIME_EXTENSION_NAME { get; set; }`
  * `int XR_KHR_vulkan_enable2`
  * `int XR_KHR_vulkan_enable2_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_KHR_VULKAN_ENABLE2_EXTENSION_NAME { get; set; }`
  * `int XR_MSFT_perception_anchor_interop`
  * `int XR_MSFT_perception_anchor_interop_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MSFT_PERCEPTION_ANCHOR_INTEROP_EXTENSION_NAME { get; set; }`
  * `int XR_MSFT_holographic_window_attachment`
  * `int XR_MSFT_holographic_window_attachment_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_MSFT_HOLOGRAPHIC_WINDOW_ATTACHMENT_EXTENSION_NAME { get; set; }`
  * `int XR_OCULUS_audio_device_guid`
  * `int XR_OCULUS_audio_device_guid_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_OCULUS_AUDIO_DEVICE_GUID_EXTENSION_NAME { get; set; }`
  * `int XR_MAX_AUDIO_DEVICE_STR_SIZE_OCULUS`
  * `int XR_FB_foveation_vulkan`
  * `int XR_FB_foveation_vulkan_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_FOVEATION_VULKAN_EXTENSION_NAME { get; set; }`
  * `int XR_FB_swapchain_update_state_vulkan`
  * `int XR_FB_swapchain_update_state_vulkan_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_FB_SWAPCHAIN_UPDATE_STATE_VULKAN_EXTENSION_NAME { get; set; }`
  * `int XR_META_vulkan_swapchain_create_info`
  * `int XR_META_vulkan_swapchain_create_info_SPEC_VERSION`
  * `ReadOnlySpan<byte> XR_META_VULKAN_SWAPCHAIN_CREATE_INFO_EXTENSION_NAME { get; set; }`
* **enum VkStructureType**
* **enum XrActionType**
* **enum XrAnchorPersistStateANDROID**
  * `XrStructureType type`
  * `XrUuid anchorId`
  * `uint supportsAnchorPersistence`
* **enum XrAudioBufferChannelLayoutBD**
* **enum XrAudioSampleRateBD**
* **enum XrBlendFactorFB**
  * `XrStructureType type`
  * `XrBlendFactorFB srcFactorColor`
  * `XrBlendFactorFB dstFactorColor`
  * `XrBlendFactorFB srcFactorAlpha`
  * `XrBlendFactorFB dstFactorAlpha`
  * `float recommendedNearZ`
  * `float minNearZ`
  * `float recommendedFarZ`
  * `float maxFarZ`
* **enum XrBodyJointBD**
* **enum XrBodyJointConfidenceHTC**
  * `XrStructureType type`
  * `uint supportsBodyTracking`
  * `XrBodyJointSetHTC bodyJointSet`
  * `long time`
* **enum XrBodyJointFB**
* **enum XrBodyJointHTC**
* **enum XrBodyJointSetBD**
  * `XrStructureType type`
  * `uint supportsBodyTracking`
  * `XrBodyJointSetBD jointSet`
  * `long time`
* **enum XrBodyJointSetFB**
* **enum XrBodyJointSetHTC**
* **enum XrBodyTrackingCalibrationStateMETA**
  * `XrStructureType type`
  * `XrBodyTrackingCalibrationStateMETA status`
  * `float bodyHeight`
  * `uint supportsHeightOverride`
* **enum XrBodyTrackingFidelityMETA**
  * `XrStructureType type`
  * `uint supportsBodyTrackingFidelity`
  * `XrBodyTrackingFidelityMETA fidelity`
* **enum XrBodyTrackingMessageBD**
  * `XrStructureType type`
  * `uint postureCount`
* **enum XrBodyTrackingPostureBD**
* **enum XrBodyTrackingStatusBD**
* **enum XrBoundaryVisibilityMETA**
  * `XrStructureType type`
  * `uint supportsBoundaryVisibility`
  * `XrBoundaryVisibilityMETA boundaryVisibility`
  * `uint supportsSimultaneousHandsAndControllers`
* **enum XrColorSpaceFB**
  * `XrStructureType type`
  * `XrColorSpaceFB colorSpace`
* **enum XrCompareOpFB**
  * `XrStructureType type`
  * `uint depthMask`
  * `XrCompareOpFB compareOp`
* **enum XrDynamicObjectTypeBD**
  * `XrStructureType type`
  * `uint supportsDynamicObjectTracking`
  * `uint trackingTypeCount`
  * `XrDynamicObjectTypeBD objectType`
  * `XrDynamicObjectDataBD data`
  * `uint typeCount`
  * `uint supportsDynamicObjectKeyboard`
  * `uint supportsDynamicObjectMouse`
  * `long time`
  * `XrSpheref sphere`
  * `XrBoxf box`
  * `XrFrustumf frustum`
  * `XrSpatialCapabilityEXT capability`
  * `uint enabledComponentCount`
  * `uint locationCount`
  * `XrPosef pose`
* **enum XrEnvironmentBlendMode**
* **enum XrEnvironmentRaycastFilterTypeMETA**
* **enum XrEnvironmentRaycastHitStatusMETA**
  * `XrStructureType type`
  * `uint supportsEnvironmentRaycast`
  * `XrResult futureResult`
  * `long time`
  * `XrVector3f origin`
  * `XrVector3f direction`
  * `uint filterCount`
  * `XrEnvironmentRaycastHitStatusMETA status`
  * `XrPosef pose`
  * `float maxDistance`
* **enum XrExternalCameraAttachedToDeviceOCULUS**
* **enum XrEyeCalibrationStatusML**
  * `XrStructureType type`
  * `XrHeadsetFitStatusML status`
  * `long time`
  * `XrEyeCalibrationStatusML status`
  * `uint enabled`
  * `uint suppressNotifications`
* **enum XrEyeExpressionHTC**
* **enum XrEyeIndexANDROID**
* **enum XrEyePositionFB**
* **enum XrEyeStateANDROID**
* **enum XrEyeTrackingModeANDROID**
  * `XrStructureType type`
  * `uint supportsEyeTracking`
* **enum XrEyeVisibility**
* **enum XrFaceConfidence2FB**
  * `XrStructureType type`
  * `uint supportsVisualFaceTracking`
  * `uint supportsAudioFaceTracking`
  * `XrFaceExpressionSet2FB faceExpressionSet`
  * `uint requestedDataSourceCount`
  * `long time`
  * `uint weightCount`
  * `uint confidenceCount`
  * `uint isValid`
  * `uint isEyeFollowingBlendshapesValid`
  * `XrFaceTrackingDataSource2FB dataSource`
  * `uint supportsSpatialEntitySharing`
  * `uint spaceCount`
  * `ulong requestId`
  * `XrResult result`
  * `ulong createFlags`
  * `uint width`
  * `uint height`
  * `long displayTime`
  * `XrFovf fov`
  * `XrPosef pose`
  * `uint swapchainIndex`
  * `float nearZ`
  * `float farZ`
  * `_views_e__FixedBuffer views`
* **enum XrFaceConfidenceFB**
  * `XrStructureType type`
  * `uint supportsFaceTracking`
  * `XrFaceExpressionSetFB faceExpressionSet`
  * `long time`
* **enum XrFaceConfidenceRegionsANDROID**
  * `XrStructureType type`
  * `long time`
  * `uint parametersCapacityInput`
  * `uint parametersCountOutput`
  * `XrFaceTrackingStateANDROID faceTrackingState`
  * `long sampleTime`
  * `uint isValid`
  * `uint regionConfidencesCapacityInput`
  * `uint regionConfidencesCountOutput`
  * `uint supportsFaceTracking`
* **enum XrFaceExpression2FB**
* **enum XrFaceExpressionBD**
* **enum XrFaceExpressionFB**
* **enum XrFaceExpressionSet2FB**
* **enum XrFaceExpressionSetFB**
* **enum XrFaceParameterIndicesANDROID**
* **enum XrFaceTrackingDataSource2FB**
* **enum XrFaceTrackingStateANDROID**
* **enum XrFaceTrackingVisemeMETA**
  * `XrStructureType type`
  * `uint isValid`
  * `_visemes_e__FixedBuffer visemes`
* **enum XrFacialBlendShapeML**
  * `XrStructureType type`
  * `uint supportsFacialExpression`
  * `uint requestedCount`
  * `XrFacialBlendShapeML requestedFacialBlendShape`
  * `float weight`
  * `ulong flags`
  * `long time`
* **enum XrFacialSimulationModeBD**
* **enum XrFacialTrackingTypeHTC**
  * `XrStructureType type`
  * `uint supportEyeFacialTracking`
  * `uint supportLipFacialTracking`
  * `uint isActive`
  * `long sampleTime`
  * `uint expressionCount`
  * `XrFacialTrackingTypeHTC facialTrackingType`
* **enum XrForceFeedbackCurlLocationMNDX**
  * `XrStructureType type`
  * `uint supportsForceFeedbackCurl`
* **enum XrFormFactor**
* **enum XrFoveationDynamicFB**
  * `XrStructureType type`
  * `XrFoveationLevelFB level`
  * `float verticalOffset`
  * `XrFoveationDynamicFB dynamic`
  * `uint supportsKeyboardTracking`
* **enum XrFoveationLevelFB**
* **enum XrFoveationLevelHTC**
  * `XrStructureType type`
  * `XrFoveationModeHTC mode`
  * `uint subImageCount`
* **enum XrFoveationModeHTC**
* **enum XrFullBodyJointMETA**
  * `XrStructureType type`
  * `uint supportsFullBodyTracking`
  * `IntPtr layer`
* **enum XrFutureStateEXT**
  * `XrStructureType type`
  * `XrResult futureResult`
  * `XrFutureStateEXT state`
  * `uint isUserPresent`
  * `uint supportsUserPresence`
* **enum XrGeospatialTrackerStateANDROID**
* **enum XrGoogleCloudAuthErrorANDROID**
  * `XrStructureType type`
  * `XrGoogleCloudAuthErrorANDROID error`
* **enum XrHandEXT**
* **enum XrHandForearmJointULTRALEAP**
* **enum XrHandGestureTypeQCOM**
* **enum XrHandJointEXT**
* **enum XrHandJointSetEXT**
  * `XrStructureType type`
  * `uint supportsHandTracking`
  * `XrHandEXT hand`
  * `XrHandJointSetEXT handJointSet`
  * `long time`
* **enum XrHandJointsMotionRangeEXT**
  * `XrStructureType type`
  * `XrHandJointsMotionRangeEXT handJointsMotionRange`
* **enum XrHandPoseTypeMSFT**
  * `XrStructureType type`
  * `uint supportsHandTrackingMesh`
  * `uint maxHandMeshIndexCount`
  * `uint maxHandMeshVertexCount`
  * `XrHandPoseTypeMSFT handPoseType`
  * `XrPosef poseInHandMeshSpace`
  * `long time`
  * `uint indexBufferKey`
  * `uint indexCapacityInput`
  * `uint indexCountOutput`
* **enum XrHandTrackingDataSourceEXT**
  * `XrStructureType type`
  * `uint requestedDataSourceCount`
  * `uint isActive`
  * `XrHandTrackingDataSourceEXT dataSource`
* **enum XrHandTrackingFrequencyHintMETA**
* **enum XrHapticParametricStreamFrameTypeEXT**
  * `XrStructureType type`
  * `long idealFrameSubmissionRate`
  * `long minimumFirstFrameDuration`
  * `float minFrequencyHz`
  * `float maxFrequencyHz`
* **enum XrHeadsetFitStatusML**
* **enum XrLightEstimateStateANDROID**
* **enum XrLipExpressionBD**
  * `XrStructureType type`
  * `uint supportsFaceTracking`
  * `XrFacialSimulationModeBD mode`
  * `long time`
  * `uint faceExpressionWeightCount`
  * `uint isUpperFaceDataValid`
  * `uint isLowerFaceDataValid`
  * `uint lipsyncExpressionWeightCount`
* **enum XrLipExpressionHTC**
* **enum XrLocalDimmingModeMETA**
  * `XrStructureType type`
  * `XrLocalDimmingModeMETA localDimmingMode`
  * `ulong flags`
* **enum XrLocalizationMapConfidenceML**
  * `XrStructureType type`
  * `_name_e__FixedBuffer name`
  * `XrUuid mapUuid`
  * `XrLocalizationMapTypeML mapType`
* **enum XrLocalizationMapStateML**
* **enum XrLocalizationMapTypeML**
* **enum XrMarkerAprilTagDictML**
* **enum XrMarkerArucoDictML**
* **enum XrMarkerDetectorCameraML**
* **enum XrMarkerDetectorCornerRefineMethodML**
* **enum XrMarkerDetectorFpsML**
* **enum XrMarkerDetectorFullAnalysisIntervalML**
* **enum XrMarkerDetectorProfileML**
* **enum XrMarkerDetectorResolutionML**
* **enum XrMarkerDetectorStatusML**
  * `XrStructureType type`
  * `uint supportsMarkerUnderstanding`
  * `XrMarkerDetectorProfileML profile`
  * `XrMarkerTypeML markerType`
  * `XrMarkerArucoDictML arucoDict`
  * `float markerLength`
  * `XrMarkerAprilTagDictML aprilTagDict`
  * `XrMarkerDetectorFpsML fpsHint`
  * `XrMarkerDetectorResolutionML resolutionHint`
  * `XrMarkerDetectorCameraML cameraHint`
  * `XrMarkerDetectorCornerRefineMethodML cornerRefineMethod`
  * `uint useEdgeRefinement`
  * `XrMarkerDetectorFullAnalysisIntervalML fullAnalysisIntervalHint`
  * `XrMarkerDetectorStatusML state`
  * `IntPtr markerDetector`
  * `ulong marker`
  * `XrPosef poseInMarkerSpace`
* **enum XrMarkerTypeML**
* **enum XrMeshComputeLodMSFT**
* **enum XrObjectLabelANDROID**
  * `XrStructureType type`
  * `XrTrackingStateANDROID trackingState`
  * `XrPosef centerPose`
  * `XrExtent3Df extents`
  * `XrObjectLabelANDROID objectLabel`
  * `long lastUpdatedTime`
  * `uint labelCount`
* **enum XrObjectType**
  * `XrStructureType type`
  * `_layerName_e__FixedBuffer layerName`
  * `ulong specVersion`
  * `uint layerVersion`
  * `_description_e__FixedBuffer description`
* **enum XrPassthroughCameraStateANDROID**
  * `XrStructureType type`
  * `uint supportsPassthroughCameraState`
* **enum XrPassthroughColorLutChannelsMETA**
  * `uint bufferSize`
  * `XrStructureType type`
  * `XrPassthroughColorLutChannelsMETA channels`
  * `uint resolution`
  * `XrPassthroughColorLutDataMETA data`
  * `ulong colorLut`
  * `float weight`
  * `ulong sourceColorLut`
  * `ulong targetColorLut`
  * `uint maxColorLutResolution`
  * `uint vertexCapacityInput`
  * `uint vertexCountOutput`
  * `uint indexCapacityInput`
  * `uint indexCountOutput`
* **enum XrPassthroughFormHTC**
  * `XrStructureType type`
  * `XrPassthroughFormHTC form`
  * `float alpha`
  * `uint vertexCount`
  * `uint indexCount`
  * `long time`
  * `XrPosef pose`
  * `XrVector3f scale`
  * `ulong layerFlags`
  * `IntPtr passthrough`
  * `XrPassthroughColorHTC color`
* **enum XrPassthroughLayerPurposeFB**
  * `XrStructureType type`
  * `uint supportsPassthrough`
  * `ulong capabilities`
  * `ulong flags`
  * `IntPtr passthrough`
  * `XrPassthroughLayerPurposeFB purpose`
  * `IntPtr layerHandle`
  * `IntPtr layer`
  * `IntPtr mesh`
  * `XrPosef pose`
  * `XrVector3f scale`
  * `long time`
  * `float textureOpacityFactor`
  * `XrColor4f edgeColor`
  * `_textureColorMap_e__FixedBuffer textureColorMap`
* **enum XrPerfSettingsDomainEXT**
* **enum XrPerfSettingsLevelEXT**
* **enum XrPerfSettingsNotificationLevelEXT**
  * `XrStructureType type`
  * `XrPerfSettingsDomainEXT domain`
  * `XrPerfSettingsSubDomainEXT subDomain`
  * `XrPerfSettingsNotificationLevelEXT fromLevel`
  * `XrPerfSettingsNotificationLevelEXT toLevel`
  * `XrObjectType objectType`
  * `ulong objectHandle`
  * `uint objectCount`
  * `uint sessionLabelCount`
  * `ulong messageSeverities`
  * `ulong messageTypes`
  * `uint supportsEyeGazeInteraction`
  * `long time`
  * `ulong createFlags`
  * `uint sessionLayersPlacement`
  * `uint visible`
  * `ulong flags`
  * `XrPosef pose`
  * `IntPtr anchor`
  * `XrPosef poseInAnchorSpace`
* **enum XrPerfSettingsSubDomainEXT**
* **enum XrPerformanceMetricsCounterUnitANDROID**
  * `XrStructureType type`
  * `uint enabled`
  * `ulong counterFlags`
  * `XrPerformanceMetricsCounterUnitANDROID counterUnit`
  * `uint uintValue`
  * `float floatValue`
* **enum XrPerformanceMetricsCounterUnitMETA**
  * `XrStructureType type`
  * `uint enabled`
  * `ulong counterFlags`
  * `XrPerformanceMetricsCounterUnitMETA counterUnit`
  * `uint uintValue`
  * `float floatValue`
  * `uint spaceCount`
  * `XrSpaceStorageLocationFB location`
  * `ulong requestId`
  * `XrResult result`
  * `ulong userId`
  * `XrUuid id`
  * `uint supportsSpaceDiscovery`
  * `uint filterCount`
  * `uint uuidCount`
  * `XrSpaceComponentTypeFB componentType`
  * `XrUuid uuid`
  * `uint resultCapacityInput`
  * `uint resultCountOutput`
  * `XrExtent2Di recommendedImageDimensions`
  * `uint isValid`
  * `long predictedDisplayTime`
  * `uint supportsSpacePersistence`
* **enum XrPersistenceLocationBD**
  * `XrStructureType type`
  * `uint supportsSpatialAnchor`
  * `XrPosef pose`
  * `long time`
  * `XrResult futureResult`
  * `XrUuid uuid`
  * `XrPersistenceLocationBD location`
  * `uint supportsSpatialAnchorSharing`
  * `uint supportsSpatialScene`
* **enum XrPlaneDetectionStateEXT**
  * `XrStructureType type`
  * `ulong supportedFeatures`
  * `ulong flags`
  * `long time`
  * `uint orientationCount`
  * `uint semanticTypeCount`
  * `uint maxPlanes`
  * `float minArea`
  * `XrPosef boundingBoxPose`
  * `XrExtent3Df boundingBoxExtent`
  * `ulong planeId`
  * `ulong locationFlags`
  * `XrPosef pose`
  * `XrExtent2Df extents`
  * `XrPlaneDetectorOrientationEXT orientation`
  * `XrPlaneDetectorSemanticTypeEXT semanticType`
  * `uint polygonBufferCount`
  * `uint planeLocationCapacityInput`
  * `uint planeLocationCountOutput`
  * `uint vertexCapacityInput`
  * `uint vertexCountOutput`
* **enum XrPlaneDetectorOrientationEXT**
* **enum XrPlaneDetectorSemanticTypeEXT**
* **enum XrPlaneLabelANDROID**
  * `XrStructureType type`
  * `XrTrackableTypeANDROID trackableType`
  * `ulong trackable`
  * `long time`
  * `XrTrackingStateANDROID trackingState`
  * `XrPosef centerPose`
  * `XrExtent2Df extents`
  * `XrPlaneTypeANDROID planeType`
  * `XrPlaneLabelANDROID planeLabel`
  * `ulong subsumedByPlane`
  * `long lastUpdatedTime`
  * `uint vertexCapacityInput`
  * `XrPosef pose`
  * `uint supportsAnchor`
  * `uint maxAnchors`
* **enum XrPlaneOrientationBD**
  * `XrStructureType type`
  * `uint supportsSpatialPlane`
  * `XrPlaneOrientationBD orientation`
  * `uint orientationCount`
* **enum XrPlaneTypeANDROID**
* **enum XrQrCodeTrackingModeANDROID**
  * `XrStructureType type`
  * `uint supportsQrCodeTracking`
  * `uint supportsQrCodeSizeEstimation`
  * `ushort maxQrCodeCount`
  * `XrQrCodeTrackingModeANDROID trackingMode`
  * `float qrCodeEdgeSize`
  * `XrTrackingStateANDROID trackingState`
  * `long lastUpdatedTime`
  * `XrPosef centerPose`
  * `XrExtent2Df extents`
  * `uint bufferCapacityInput`
  * `uint bufferCountOutput`
* **enum XrReferenceSpaceType**
* **enum XrReprojectionModeMSFT**
  * `XrStructureType type`
  * `XrReprojectionModeMSFT reprojectionMode`
  * `XrVector3f position`
  * `XrVector3f normal`
  * `XrVector3f velocity`
  * `ulong flags`
* **enum XrResult**
* **enum XrSceneComponentTypeMSFT**
* **enum XrSceneComputeConsistencyMSFT**
* **enum XrSceneComputeFeatureMSFT**
* **enum XrSceneComputeStateMSFT**
* **enum XrSceneMarkerQRCodeSymbolTypeMSFT**
* **enum XrSceneMarkerTypeMSFT**
* **enum XrSceneMeshSemanticLabelANDROID**
  * `XrStructureType type`
  * `uint supportsSceneMeshing`
  * `XrSceneMeshSemanticLabelSetANDROID semanticLabelSet`
  * `uint enableNormals`
  * `long time`
  * `XrBoxf boundingBox`
  * `IntPtr snapshot`
  * `XrSceneMeshTrackingStateANDROID trackingState`
  * `XrUuid submeshId`
  * `long lastUpdatedTime`
  * `XrPosef submeshPoseInBaseSpace`
  * `XrExtent3Df bounds`
  * `uint vertexCapacityInput`
  * `uint vertexCountOutput`
  * `uint indexCapacityInput`
  * `uint indexCountOutput`
* **enum XrSceneMeshSemanticLabelSetANDROID**
* **enum XrSceneMeshTrackingStateANDROID**
* **enum XrSceneObjectTypeMSFT**
* **enum XrScenePlaneAlignmentTypeMSFT**
* **enum XrSemanticLabelBD**
* **enum XrSemanticLabelMETA**
* **enum XrSenseDataProviderStateBD**
  * `XrStructureType type`
  * `uint supportsSpatialSensing`
  * `ulong entityId`
  * `XrSpatialEntityComponentTypeBD componentType`
  * `XrSpaceLocation location`
  * `uint labelCapacityInput`
  * `uint labelCountOutput`
  * `XrRect2Df boundingBox2D`
  * `uint vertexCapacityInput`
  * `uint vertexCountOutput`
  * `XrBoxf boundingBox3D`
  * `uint indexCapacityInput`
  * `uint indexCountOutput`
  * `XrSpheref sphere`
  * `XrSenseDataProviderTypeBD providerType`
  * `XrSenseDataProviderStateBD newState`
  * `XrResult futureResult`
  * `IntPtr snapshot`
  * `long lastUpdateTime`
  * `XrUuid uuid`
  * `uint stateCapacityInput`
  * `uint stateCountOutput`
  * `uint uuidCount`
  * `uint labelCount`
  * `XrPosef poseInAnchorSpace`
* **enum XrSenseDataProviderTypeBD**
* **enum XrSessionState**
* **enum XrSoundFieldChannelMaskAmbixBD**
* **enum XrSoundFieldChannelMaskFumaBD**
* **enum XrSoundFieldChannelMaskSurroundBD**
* **enum XrSoundObjectDistanceAttenuationTypeBD**
* **enum XrSoundObstacleMaterialTypeBD**
  * `XrStructureType type`
  * `uint framesPerBuffer`
  * `XrAudioSampleRateBD sampleRate`
  * `XrAudioBufferChannelLayoutBD channelLayout`
  * `uint bufferChannels`
  * `uint bufferLength`
  * `float alpha`
  * `float order`
  * `float radius`
* **enum XrSpaceComponentTypeFB**
  * `XrStructureType type`
  * `uint supportsSpatialEntity`
  * `XrPosef poseInSpace`
  * `long time`
  * `XrSpaceComponentTypeFB componentType`
  * `uint enabled`
  * `long timeout`
  * `uint changePending`
  * `ulong requestId`
  * `XrResult result`
  * `XrUuid uuid`
  * `ulong flags`
* **enum XrSpacePersistenceModeFB**
  * `XrStructureType type`
  * `XrSpaceStorageLocationFB location`
  * `XrSpacePersistenceModeFB persistenceMode`
  * `ulong requestId`
  * `XrResult result`
  * `XrUuid uuid`
  * `uint spaceCount`
  * `uint userCount`
* **enum XrSpaceQueryActionFB**
* **enum XrSpaceStorageLocationFB**
  * `XrStructureType type`
  * `XrSpaceQueryActionFB queryAction`
  * `uint maxResultCount`
  * `long timeout`
  * `XrSpaceStorageLocationFB location`
  * `uint uuidCount`
  * `XrSpaceComponentTypeFB componentType`
  * `XrUuid uuid`
  * `uint resultCapacityInput`
  * `uint resultCountOutput`
  * `ulong requestId`
  * `XrResult result`
* **enum XrSpatialAnchorConfidenceML**
  * `XrStructureType type`
  * `XrPosef poseInBaseSpace`
  * `long time`
  * `XrResult futureResult`
  * `uint spaceCount`
  * `XrSpatialAnchorConfidenceML confidence`
  * `XrVector3f center`
  * `float radius`
  * `uint uuidCapacityInput`
  * `uint uuidCountOutput`
  * `IntPtr storage`
  * `uint uuidCount`
  * `uint anchorCount`
  * `ulong expiration`
* **enum XrSpatialBufferTypeEXT**
  * `XrStructureType type`
  * `uint componentTypeCapacityInput`
  * `uint componentTypeCountOutput`
  * `XrSpatialCapabilityEXT capability`
  * `uint enabledComponentCount`
  * `uint capabilityConfigCount`
  * `XrResult futureResult`
  * `IntPtr spatialContext`
  * `uint componentTypeCount`
  * `long time`
  * `IntPtr snapshot`
  * `uint entityIdCapacityInput`
  * `uint entityIdCountOutput`
  * `uint entityStateCapacityInput`
  * `uint entityStateCountOutput`
* **enum XrSpatialCapabilityEXT**
* **enum XrSpatialCapabilityFeatureEXT**
* **enum XrSpatialComponentTypeEXT**
* **enum XrSpatialEntityComponentTypeBD**
* **enum XrSpatialEntityTrackingStateEXT**
* **enum XrSpatialGraphNodeTypeMSFT**
  * `XrStructureType type`
  * `XrSpatialGraphNodeTypeMSFT nodeType`
  * `_nodeId_e__FixedBuffer nodeId`
  * `XrPosef pose`
* **enum XrSpatialMarkerAprilTagDictEXT**
  * `XrStructureType type`
  * `XrSpatialCapabilityEXT capability`
  * `uint enabledComponentCount`
  * `XrSpatialMarkerArucoDictEXT arUcoDict`
  * `XrSpatialMarkerAprilTagDictEXT aprilDict`
  * `float markerSideLength`
  * `uint optimizeForStaticMarker`
* **enum XrSpatialMarkerArucoDictEXT**
* **enum XrSpatialMeshLodBD**
  * `XrStructureType type`
  * `uint supportsSpatialMesh`
  * `ulong configFlags`
  * `XrSpatialMeshLodBD lod`
  * `uint isSupported`
  * `uint progressPercentage`
* **enum XrSpatialObjectSemanticLabelANDROID**
  * `XrStructureType type`
  * `XrSpatialCapabilityEXT capability`
  * `uint enabledComponentCount`
  * `uint activeSemanticLabelCount`
  * `uint semanticLabelCount`
* **enum XrSpatialPersistenceContextResultEXT**
* **enum XrSpatialPersistenceScopeEXT**
* **enum XrSpatialPersistenceStateEXT**
  * `XrStructureType type`
  * `XrSpatialPersistenceScopeEXT scope`
  * `XrResult futureResult`
  * `XrSpatialPersistenceContextResultEXT createResult`
  * `uint persistenceContextCount`
  * `IntPtr Handle { get; set; }`
  * `bool IsNull { get; set; }`
  * `XrSpatialPersistenceContextEXT Null { get; set; }`
  * `bool Equals()`
  * `int GetHashCode()`
  * `bool operator`
  * `string ToString()`
  * `uint persistedUuidCount`
* **enum XrSpatialPlaneAlignmentEXT**
* **enum XrSpatialPlaneSemanticLabelEXT**
  * `XrStructureType type`
  * `XrSpatialCapabilityEXT capability`
  * `uint enabledComponentCount`
  * `uint planeAlignmentCount`
  * `uint meshCount`
* **enum XrSphericalHarmonicsKindANDROID**
  * `XrStructureType type`
  * `uint supportsLightEstimation`
  * `long time`
  * `XrLightEstimateStateANDROID state`
  * `long lastUpdatedTime`
  * `XrVector3f intensity`
  * `XrVector3f direction`
  * `XrVector3f colorCorrection`
  * `XrSphericalHarmonicsKindANDROID kind`
  * `_coefficients_e__FixedBuffer coefficients`
* **enum XrStructureType**
* **enum XrSurfaceAnchorTypeANDROID**
  * `XrStructureType type`
  * `uint maxSurfaceAnchorCount`
  * `uint shouldTrackPlanes`
  * `XrGeospatialPoseANDROID geospatialPose`
  * `XrSurfaceAnchorTypeANDROID surfaceAnchorType`
  * `XrQuaternionf eastUpSouthOrientation`
  * `double latitude`
  * `double longitude`
  * `double altitudeRelativeToSurface`
  * `XrResult futureResult`
  * `ulong anchorEntityId`
  * `ulong stateFlags`
  * `float batteryLevel`
  * `uint propertyValueCount`
  * `ulong systemId`
  * `XrViewConfigurationType viewConfigurationType`
  * `uint viewFormatCount`
  * `uint image`
  * `ulong minApiVersionSupported`
  * `ulong maxApiVersionSupported`
  * `uint queueFamilyIndex`
  * `uint queueIndex`
  * `LUID adapterLuid`
  * `int minFeatureLevel`
  * `ulong createFlags`
* **enum XrTrackableImageFormatANDROID**
  * `XrStructureType type`
  * `uint supportsImageTracking`
  * `uint supportsPhysicalSizeEstimation`
  * `uint maxTrackedImageCount`
  * `uint maxLoadedImageCount`
  * `XrTrackableImageTrackingModeANDROID trackingMode`
  * `float physicalWidth`
  * `uint imageWidth`
  * `uint imageHeight`
  * `XrTrackableImageFormatANDROID format`
  * `uint bufferSize`
  * `uint entryCount`
  * `XrResult futureResult`
* **enum XrTrackableImageTrackingModeANDROID**
* **enum XrTrackableMarkerDictionaryANDROID**
  * `XrStructureType type`
  * `uint supportsMarkerTracking`
  * `uint supportsMarkerSizeEstimation`
  * `ushort maxMarkerCount`
* **enum XrTrackableMarkerTrackingModeANDROID**
* **enum XrTrackableTypeANDROID**
* **enum XrTrackingOptimizationSettingsDomainQCOM**
* **enum XrTrackingOptimizationSettingsHintQCOM**
* **enum XrTrackingStateANDROID**
* **enum XrVPSAvailabilityANDROID**
* **enum XrViewConfigurationType**
* **enum XrVirtualKeyboardInputSourceMETA**
  * `XrStructureType type`
  * `uint supportsVirtualKeyboard`
  * `XrVirtualKeyboardLocationTypeMETA locationType`
  * `XrPosef poseInSpace`
  * `float scale`
  * `uint visible`
  * `int animationIndex`
  * `float fraction`
  * `uint stateCapacityInput`
  * `uint stateCountOutput`
  * `uint textureWidth`
  * `uint textureHeight`
  * `uint bufferCapacityInput`
  * `uint bufferCountOutput`
  * `XrVirtualKeyboardInputSourceMETA inputSource`
  * `XrPosef inputPoseInSpace`
  * `ulong inputState`
  * `_text_e__FixedBuffer text`
* **enum XrVirtualKeyboardLocationTypeMETA**
* **enum XrVisibilityMaskTypeKHR**
  * `XrStructureType type`
  * `uint vertexCapacityInput`
  * `uint vertexCountOutput`
  * `uint indexCapacityInput`
  * `uint indexCountOutput`
  * `XrViewConfigurationType viewConfigurationType`
  * `uint viewIndex`
  * `XrColor4f colorScale`
  * `XrColor4f colorBias`
  * `ulong layerFlags`
  * `XrEyeVisibility eyeVisibility`
  * `XrSwapchainSubImage subImage`
  * `XrPosef pose`
  * `float radius`
  * `float centralHorizontalAngle`
  * `float upperVerticalAngle`
  * `float lowerVerticalAngle`
  * `uint bindingModificationCount`
* **enum XrWindingOrderANDROID**
  * `XrStructureType type`
  * `uint vertexCapacity`
  * `uint indexCapacity`
  * `XrWindingOrderANDROID windingOrder`
  * `uint vertexCount`
  * `uint indexCount`
  * `ulong layerFlags`
  * `XrPosef pose`
  * `XrVector3f scale`
  * `float opacity`
  * `IntPtr layer`
  * `uint supportsPassthroughLayer`
  * `uint maxMeshIndexCount`
  * `uint maxMeshVertexCount`
  * `uint maxResults`
  * `uint trackerCount`
  * `XrVector3f origin`
  * `XrVector3f trajectory`
  * `long time`
* **enum XrWindingOrderFB**
  * `XrStructureType type`
  * `ulong flags`
  * `XrWindingOrderFB windingOrder`
  * `uint vertexCount`
  * `uint triangleCount`
* **enum XrWorldMeshBlockResultML**
  * `XrStructureType type`
  * `XrUuid uuid`
  * `XrPosef meshBoundingBoxCenter`
  * `XrExtent3Df meshBoundingBoxExtents`
  * `long lastUpdateTime`
  * `XrWorldMeshBlockStatusML status`
  * `long time`
  * `XrPosef boundingBoxCenter`
  * `XrExtent3Df boundingBoxExtents`
  * `XrResult futureResult`
  * `long timestamp`
  * `uint meshBlockStateCapacityInput`
  * `uint meshBlockStateCountOutput`
  * `uint maxBlockCount`
  * `uint size`
  * `uint bufferSize`
  * `XrWorldMeshDetectorLodML lod`
  * `ulong flags`
  * `float fillHoleLength`
  * `float disconnectedComponentArea`
  * `uint blockCount`
  * `XrWorldMeshBlockResultML blockResult`
  * `uint indexCount`
  * `uint vertexCount`
  * `uint normalCount`
  * `uint confidenceCount`
  * `long meshSpaceLocateTime`
* **enum XrWorldMeshBlockStatusML**
* **enum XrWorldMeshDetectorLodML**
* **struct D3D11_BOX**
  * `int left`
  * `int top`
  * `int front`
  * `int right`
  * `int bottom`
  * `int back`
* **struct VkInstanceCreateInfo**
  * `VkStructureType sType`
  * `IntPtr pNext`
  * `uint flags`
  * `IntPtr pApplicationInfo`
  * `uint enabledLayerCount`
  * `IntPtr ppEnabledLayerNames`
  * `uint enabledExtensionCount`
  * `IntPtr ppEnabledExtensionNames`
  * `XrStructureType type`
  * `ulong systemId`
  * `ulong createFlags`
  * `uint queueCreateInfoCount`
  * `VkBool32 robustBufferAccess`
  * `VkBool32 fullDrawIndexUint32`
  * `VkBool32 imageCubeArray`
  * `VkBool32 independentBlend`
  * `VkBool32 geometryShader`
  * `VkBool32 tessellationShader`
  * `VkBool32 sampleRateShading`
  * `VkBool32 dualSrcBlend`
  * `VkBool32 logicOp`
  * `VkBool32 multiDrawIndirect`
  * `VkBool32 drawIndirectFirstInstance`
  * `VkBool32 depthClamp`
  * `VkBool32 depthBiasClamp`
  * `VkBool32 fillModeNonSolid`
  * `VkBool32 depthBounds`
  * `VkBool32 wideLines`
  * `VkBool32 largePoints`
  * `VkBool32 alphaToOne`
  * `VkBool32 multiViewport`
  * `VkBool32 samplerAnisotropy`
  * `VkBool32 textureCompressionETC2`
  * `VkBool32 textureCompressionASTC_LDR`
  * `VkBool32 textureCompressionBC`
  * `VkBool32 occlusionQueryPrecise`
  * `VkBool32 pipelineStatisticsQuery`
  * `VkBool32 vertexPipelineStoresAndAtomics`
  * `VkBool32 fragmentStoresAndAtomics`
  * `VkBool32 shaderTessellationAndGeometryPointSize`
  * `VkBool32 shaderImageGatherExtended`
  * `VkBool32 shaderStorageImageExtendedFormats`
  * `VkBool32 shaderStorageImageMultisample`
  * `VkBool32 shaderStorageImageReadWithoutFormat`
  * `VkBool32 shaderStorageImageWriteWithoutFormat`
  * `VkBool32 shaderUniformBufferArrayDynamicIndexing`
  * `VkBool32 shaderSampledImageArrayDynamicIndexing`
  * `VkBool32 shaderStorageBufferArrayDynamicIndexing`
  * `VkBool32 shaderStorageImageArrayDynamicIndexing`
  * `VkBool32 shaderClipDistance`
  * `VkBool32 shaderCullDistance`
  * `VkBool32 shaderFloat64`
  * `VkBool32 shaderInt64`
  * `VkBool32 shaderInt16`
  * `VkBool32 shaderResourceResidency`
  * `VkBool32 shaderResourceMinLod`
  * `VkBool32 sparseBinding`
  * `VkBool32 sparseResidencyBuffer`
  * `VkBool32 sparseResidencyImage2D`
  * `VkBool32 sparseResidencyImage3D`
  * `VkBool32 sparseResidency2Samples`
  * `VkBool32 sparseResidency4Samples`
  * `VkBool32 sparseResidency8Samples`
  * `VkBool32 sparseResidency16Samples`
  * `VkBool32 sparseResidencyAliased`
  * `VkBool32 variableMultisampleRate`
  * `VkBool32 inheritedQueries`
  * `VkDeviceQueueCreateFlags flags`
  * `uint queueFamilyIndex`
  * `uint queueCount`
* **struct XrActionSet_T**
  * `IntPtr Handle`
* **struct XrAction_T**
  * `IntPtr Handle`
  * `XrAction_T Null`
  * `bool operator`
  * `bool Equals()`
  * `int GetHashCode()`
* **struct XrAnchorBD_T**
  * `IntPtr Handle`
  * `ulong Handle`
  * `bool IsNull { get; set; }`
* **struct XrApplicationInfo**
  * `_applicationName_e__FixedBuffer applicationName`
  * `uint applicationVersion`
  * `_engineName_e__FixedBuffer engineName`
  * `uint engineVersion`
  * `ulong apiVersion`
* **struct XrAttenuationCurvePointBD**
  * `float distance`
  * `float gain`
  * `XrStructureType type`
  * `uint curvePointCount`
  * `XrSoundObjectDistanceAttenuationTypeBD distanceAttenuationType`
  * `float minAttenuationRange`
  * `float maxAttenuationRange`
  * `float referenceDistance`
  * `float rolloffFactor`
  * `uint enabled`
  * `XrPosef pose`
  * `float mainVolume`
  * `float reflectionGain`
  * `uint enableDoppler`
  * `XrQuaternionf orientation`
  * `float lfeGain`
  * `XrSoundFieldChannelMaskSurroundBD channelMask`
  * `XrSoundFieldChannelMaskAmbixBD channelMask`
  * `XrSoundFieldChannelMaskFumaBD channelMask`
  * `uint vertexCount`
  * `uint indexCount`
  * `uint materialCount`
  * `ulong Value { get; set; }`
  * `bool IsNull { get; set; }`
  * `XrSoundObstacleMaterialBD_T Null { get; set; }`
  * `bool Equals()`
  * `int GetHashCode()`
  * `string ToString()`
  * `bool operator`
  * `XrSoundObstacleMaterialTypeBD materialType`
  * `uint bandCount`
* **struct XrBodyJointAccelerationBD**
  * `ulong accelerationFlags`
  * `XrVector3f linearAcceleration`
  * `XrVector3f angularAcceleration`
  * `XrStructureType type`
  * `uint accelerationCount`
  * `XrBodyTrackingStatusBD status`
  * `XrBodyTrackingMessageBD message`
* **struct XrBodyJointLocationBD**
  * `ulong locationFlags`
  * `XrPosef pose`
  * `XrStructureType type`
  * `uint allJointPosesTracked`
  * `uint jointLocationCount`
* **struct XrBodyJointLocationFB**
  * `ulong locationFlags`
  * `XrPosef pose`
  * `XrStructureType type`
  * `uint supportsBodyTracking`
  * `XrBodyJointSetFB bodyJointSet`
* **struct XrBodyJointLocationHTC**
  * `ulong locationFlags`
  * `XrPosef pose`
  * `XrStructureType type`
  * `ulong combinedLocationFlags`
  * `XrBodyJointConfidenceHTC confidenceLevel`
  * `uint jointLocationCount`
  * `uint skeletonGenerationId`
* **struct XrBodyJointVelocityBD**
  * `ulong velocityFlags`
  * `XrVector3f linearVelocity`
  * `XrVector3f angularVelocity`
  * `XrStructureType type`
  * `uint velocityCount`
* **struct XrBodySkeletonJointFB**
  * `int joint`
  * `int parentJoint`
  * `XrPosef pose`
  * `XrStructureType type`
  * `uint jointCount`
  * `long time`
  * `uint isActive`
  * `float confidence`
  * `uint skeletonChangedCount`
  * `ulong binding`
  * `float forceThreshold`
  * `float forceThresholdReleased`
  * `float centerRegion`
  * `float wedgeAngle`
  * `uint isSticky`
  * `float onThreshold`
  * `float offThreshold`
* **struct XrBodySkeletonJointHTC**
  * `XrPosef pose`
  * `XrStructureType type`
  * `uint jointCount`
  * `uint priorityOverride`
  * `uint actionSetPriorityCount`
* **struct XrBoxf**
  * `XrPosef center`
  * `XrExtent3Df extents`
* **struct XrColor3f**
  * `float r`
  * `float g`
  * `float b`
* **struct XrColor4f**
  * `float r`
  * `float g`
  * `float b`
  * `float a`
* **struct XrExtent2Df**
  * `float width`
  * `float height`
  * `XrStructureType type`
  * `ulong subactionPath`
  * `XrPosef poseInActionSpace`
  * `ulong locationFlags`
  * `XrPosef pose`
  * `XrViewConfigurationType viewConfigurationType`
  * `uint fovMutable`
  * `uint recommendedImageRectWidth`
  * `uint maxImageRectWidth`
  * `uint recommendedImageRectHeight`
  * `uint maxImageRectHeight`
  * `uint recommendedSwapchainSampleCount`
  * `uint maxSwapchainSampleCount`
  * `ulong createFlags`
  * `ulong usageFlags`
  * `long format`
  * `uint sampleCount`
  * `uint width`
  * `uint height`
  * `uint faceCount`
  * `uint arraySize`
  * `uint mipCount`
  * `long timeout`
  * `XrViewConfigurationType primaryViewConfigurationType`
  * `long predictedDisplayTime`
  * `long predictedDisplayPeriod`
  * `uint shouldRender`
  * `ulong layerFlags`
  * `long displayTime`
  * `XrEnvironmentBlendMode environmentBlendMode`
  * `uint layerCount`
  * `ulong viewStateFlags`
* **struct XrExtent2Di**
  * `int width`
  * `int height`
* **struct XrExtent3Df**
  * `float width`
  * `float height`
  * `float depth`
* **struct XrExtent3DiMETA**
  * `int width`
  * `int height`
  * `int depth`
  * `XrStructureType type`
  * `XrExtent3DiMETA tileDimensions`
  * `XrExtent2Di apronDimensions`
  * `XrOffset2Di origin`
  * `uint propertiesCount`
  * `long captureTime`
* **struct XrExternalCameraExtrinsicsOCULUS**
  * `long lastChangeTime`
  * `ulong cameraStatusFlags`
  * `XrExternalCameraAttachedToDeviceOCULUS attachedToDevice`
  * `XrPosef relativePose`
  * `XrStructureType type`
  * `_name_e__FixedBuffer name`
  * `XrExternalCameraIntrinsicsOCULUS intrinsics`
  * `XrExternalCameraExtrinsicsOCULUS extrinsics`
* **struct XrExternalCameraIntrinsicsOCULUS**
  * `long lastChangeTime`
  * `XrFovf fov`
  * `float virtualNearPlaneDistance`
  * `float virtualFarPlaneDistance`
  * `XrExtent2Di imageSensorPixelResolution`
* **struct XrEyeANDROID**
  * `XrEyeStateANDROID eyeState`
  * `XrPosef eyePose`
  * `XrStructureType type`
  * `_eyes_e__FixedBuffer eyes`
  * `XrEyeTrackingModeANDROID mode`
* **struct XrEyeGazeFB**
  * `uint isValid`
  * `XrPosef gazePose`
  * `float gazeConfidence`
  * `XrStructureType type`
  * `long time`
  * `uint supportsEyeTracking`
  * `_gaze_e__FixedBuffer gaze`
* **struct XrFaceExpressionStatusFB**
  * `uint isValid`
  * `uint isEyeFollowingBlendshapesValid`
  * `XrStructureType type`
  * `uint weightCount`
  * `uint confidenceCount`
  * `XrFaceExpressionStatusFB status`
  * `long time`
* **struct XrForceFeedbackCurlApplyLocationMNDX**
  * `XrForceFeedbackCurlLocationMNDX location`
  * `float value`
  * `XrStructureType type`
  * `uint locationCount`
* **struct XrFoveationConfigurationHTC**
  * `XrFoveationLevelHTC level`
  * `float clearFovDegree`
  * `XrVector2f focalCenterOffset`
  * `XrStructureType type`
  * `ulong dynamicFlags`
  * `uint configCount`
  * `uint supportsAnchor`
* **struct XrFoveationProfileFB_T**
  * `IntPtr Handle`
* **struct XrFovf**
  * `float angleLeft`
  * `float angleRight`
  * `float angleUp`
  * `float angleDown`
  * `XrStructureType type`
  * `XrPosef pose`
  * `XrFovf fov`
  * `_actionSetName_e__FixedBuffer actionSetName`
  * `_localizedActionSetName_e__FixedBuffer localizedActionSetName`
  * `uint priority`
* **struct XrFrustumf**
  * `XrPosef pose`
  * `XrFovf fov`
  * `float nearZ`
  * `float farZ`
* **struct XrGeospatialPoseANDROID**
  * `XrQuaternionf eastUpSouthOrientation`
  * `double latitude`
  * `double longitude`
  * `double altitude`
  * `XrStructureType type`
  * `uint supportsGeospatial`
  * `XrGeospatialTrackerStateANDROID state`
  * `XrResult initializationResult`
  * `long time`
* **struct XrGeospatialTrackerANDROID_T**
  * `IntPtr Handle`
  * `XrStructureType type`
  * `long time`
  * `XrPosef pose`
  * `ulong poseFlags`
  * `XrGeospatialPoseANDROID geospatialPose`
  * `double horizontalAccuracy`
  * `double verticalAccuracy`
  * `double orientationYawAccuracy`
  * `XrResult futureResult`
  * `XrVPSAvailabilityANDROID availability`
  * `ulong parentId`
  * `uint subsumedUniqueIdCount`
  * `ulong anchorEntityId`
* **struct XrHandCapsuleFB**
  * `_points_e__FixedBuffer points`
  * `float radius`
  * `XrHandJointEXT joint`
* **struct XrHandGestureQCOM**
  * `XrHandGestureTypeQCOM gesture`
  * `float gestureRatio`
  * `float flipRatio`
* **struct XrHandJointLocationEXT**
  * `ulong locationFlags`
  * `XrPosef pose`
  * `float radius`
* **struct XrHandJointVelocityEXT**
  * `ulong velocityFlags`
  * `XrVector3f linearVelocity`
  * `XrVector3f angularVelocity`
  * `XrStructureType type`
  * `uint isActive`
  * `uint jointCount`
* **struct XrHandMeshVertexMSFT**
  * `XrVector3f position`
  * `XrVector3f normal`
  * `long vertexUpdateTime`
  * `uint vertexCapacityInput`
  * `uint vertexCountOutput`
  * `XrStructureType type`
  * `uint isActive`
  * `uint indexBufferChanged`
  * `uint vertexBufferChanged`
  * `XrHandMeshIndexBufferMSFT indexBuffer`
  * `XrHandMeshVertexBufferMSFT vertexBuffer`
  * `XrHandPoseTypeMSFT handPoseType`
  * `uint viewConfigurationCount`
  * `XrViewConfigurationType viewConfigurationType`
  * `uint active`
  * `XrEnvironmentBlendMode environmentBlendMode`
  * `uint layerCount`
  * `ulong modelKey`
  * `_parentNodeName_e__FixedBuffer parentNodeName`
  * `_nodeName_e__FixedBuffer nodeName`
* **struct XrHapticParametricPointEXT**
  * `long time`
  * `float value`
* **struct XrHapticParametricTransientEXT**
  * `long time`
  * `float amplitude`
  * `float frequency`
  * `XrStructureType type`
  * `uint amplitudePointCount`
  * `uint frequencyPointCount`
  * `uint transientCount`
  * `float minFrequencyHz`
  * `float maxFrequencyHz`
  * `XrHapticParametricStreamFrameTypeEXT streamFrameType`
  * `uint supportsParametricHaptics`
  * `IntPtr spatialContext`
  * `ulong spatialEntityId`
  * `XrResult futureResult`
  * `XrSpatialPersistenceContextResultEXT persistResult`
  * `XrUuid persistUuid`
  * `XrSpatialPersistenceContextResultEXT unpersistResult`
* **struct XrKeyboardTrackingDescriptionFB**
  * `ulong trackedKeyboardId`
  * `XrVector3f size`
  * `ulong flags`
  * `_name_e__FixedBuffer name`
* **struct XrOffset2Df**
  * `float x`
  * `float y`
* **struct XrOffset2Di**
  * `int x`
  * `int y`
* **struct XrOffset3DfFB**
  * `float x`
  * `float y`
  * `float z`
* **struct XrPosef**
  * `XrQuaternionf orientation`
  * `XrVector3f position`
  * `XrStructureType type`
  * `XrReferenceSpaceType referenceSpaceType`
  * `XrPosef poseInReferenceSpace`
* **struct XrQuaternionf**
  * `float x`
  * `float y`
  * `float z`
  * `float w`
* **struct XrRaycastHitResultANDROID**
  * `XrTrackableTypeANDROID type`
  * `ulong trackable`
  * `XrPosef pose`
  * `XrStructureType type`
  * `uint resultsCapacityInput`
  * `uint resultsCountOutput`
* **struct XrRect2Df**
  * `XrOffset2Df offset`
  * `XrExtent2Df extent`
* **struct XrRect2Di**
  * `XrOffset2Di offset`
  * `XrExtent2Di extent`
  * `IntPtr swapchain`
  * `XrRect2Di imageRect`
  * `uint imageArrayIndex`
  * `XrStructureType type`
  * `XrPosef pose`
  * `XrFovf fov`
  * `XrSwapchainSubImage subImage`
  * `ulong layerFlags`
  * `uint viewCount`
  * `XrEyeVisibility eyeVisibility`
  * `XrExtent2Df size`
  * `uint lostEventCount`
  * `long lossTime`
  * `XrSessionState state`
  * `long time`
  * `XrReferenceSpaceType referenceSpaceType`
  * `long changeTime`
  * `uint poseValid`
  * `XrPosef poseInPreviousSpace`
  * `long duration`
  * `float frequency`
  * `float amplitude`
* **struct XrRect3DfFB**
  * `XrOffset3DfFB offset`
  * `XrExtent3Df extent`
  * `XrStructureType type`
  * `uint bufferCapacityInput`
  * `uint bufferCountOutput`
  * `XrUuid floorUuid`
  * `XrUuid ceilingUuid`
  * `uint wallUuidCapacityInput`
  * `uint wallUuidCountOutput`
  * `uint vertexCapacityInput`
  * `uint vertexCountOutput`
  * `ulong flags`
  * `ulong requestId`
  * `XrResult result`
  * `uint requestByteCount`
  * `uint uuidCapacityInput`
  * `uint uuidCountOutput`
  * `_foveationCenter_e__FixedBuffer foveationCenter`
* **struct XrRenderModelAssetNodePropertiesEXT**
  * `_uniqueName_e__FixedBuffer uniqueName`
* **struct XrRenderModelNodeStateEXT**
  * `XrPosef nodePose`
  * `uint isVisible`
  * `XrStructureType type`
  * `uint nodeStateCount`
  * `XrUuid cacheId`
  * `uint bufferCapacityInput`
  * `uint bufferCountOutput`
* **struct XrRoomMeshFaceMETA**
  * `XrUuid uuid`
  * `XrUuid parentUuid`
  * `XrSemanticLabelMETA semanticLabel`
  * `XrStructureType type`
  * `uint indexCapacityInput`
  * `uint indexCountOutput`
  * `uint recognizedSemanticLabelCount`
  * `uint vertexCapacityInput`
  * `uint vertexCountOutput`
  * `uint faceCapacityInput`
  * `uint faceCountOutput`
  * `uint bufferSize`
  * `ulong advertisementRequestId`
  * `XrResult result`
  * `XrUuid advertisementUuid`
  * `ulong requestId`
  * `ulong discoveryRequestId`
  * `_buffer_e__FixedBuffer buffer`
* **struct XrSceneComponentLocationMSFT**
  * `ulong flags`
  * `XrPosef pose`
  * `XrStructureType type`
  * `uint locationCount`
  * `long time`
  * `uint componentIdCount`
* **struct XrSceneComponentMSFT**
  * `XrSceneComponentTypeMSFT componentType`
  * `XrUuidMSFT id`
  * `XrUuidMSFT parentId`
  * `long updateTime`
  * `XrStructureType type`
  * `uint componentCapacityInput`
  * `uint componentCountOutput`
* **struct XrSceneFrustumBoundMSFT**
  * `XrPosef pose`
  * `XrFovf fov`
  * `float farDistance`
  * `long time`
  * `uint sphereCount`
  * `uint boxCount`
  * `uint frustumCount`
  * `XrStructureType type`
  * `uint requestedFeatureCount`
  * `XrSceneComputeConsistencyMSFT consistency`
  * `XrSceneBoundsMSFT bounds`
  * `XrMeshComputeLodMSFT lod`
* **struct XrSceneMarkerMSFT**
  * `XrSceneMarkerTypeMSFT markerType`
  * `long lastSeenTime`
  * `XrOffset2Df center`
  * `XrExtent2Df size`
  * `XrStructureType type`
  * `uint sceneMarkerCapacityInput`
  * `uint markerTypeCount`
* **struct XrSceneMarkerQRCodeMSFT**
  * `XrSceneMarkerQRCodeSymbolTypeMSFT symbolType`
  * `byte version`
  * `XrStructureType type`
  * `uint qrCodeCapacityInput`
* **struct XrSceneMeshMSFT**
  * `ulong meshBufferId`
  * `uint supportsIndicesUint16`
  * `XrStructureType type`
  * `uint sceneMeshCount`
  * `uint vertexCapacityInput`
  * `uint vertexCountOutput`
  * `uint indexCapacityInput`
  * `uint indexCountOutput`
  * `XrUuidMSFT sceneFragmentId`
  * `uint bufferSize`
  * `uint fragmentCount`
  * `float fromDisplayRefreshRate`
  * `float toDisplayRefreshRate`
  * `ulong persistentPath`
  * `ulong rolePath`
* **struct XrSceneObjectMSFT**
  * `XrSceneObjectTypeMSFT objectType`
  * `XrStructureType type`
  * `uint sceneObjectCount`
  * `XrUuidMSFT parentId`
  * `uint objectTypeCount`
* **struct XrSceneOrientedBoxBoundMSFT**
  * `XrPosef pose`
  * `XrVector3f extents`
* **struct XrScenePlaneMSFT**
  * `XrScenePlaneAlignmentTypeMSFT alignment`
  * `XrExtent2Df size`
  * `ulong meshBufferId`
  * `uint supportsIndicesUint16`
  * `XrStructureType type`
  * `uint scenePlaneCount`
  * `uint alignmentCount`
* **struct XrSceneSphereBoundMSFT**
  * `XrVector3f center`
  * `float radius`
* **struct XrSenseDataProviderBD_T**
  * `XrSenseDataProviderBD Null`
  * `bool Equals()`
  * `int GetHashCode()`
  * `bool operator`
  * `string ToString()`
* **struct XrSession_T**
  * `IntPtr Handle`
* **struct XrSpaceLocationData**
  * `ulong locationFlags`
  * `XrPosef pose`
  * `XrStructureType type`
  * `uint locationCount`
* **struct XrSpaceUserFB_T**
  * `ulong NativeHandle { get; set; }`
  * `bool IsNull { get; set; }`
  * `XrSpaceUserFB_T Null { get; set; }`
  * `bool Equals()`
  * `int GetHashCode()`
  * `bool operator`
  * `XrStructureType type`
  * `ulong requestId`
  * `XrResult result`
  * `ulong layerFlags`
  * `XrSwapchainSubImage motionVectorSubImage`
  * `XrPosef appSpaceDeltaPose`
  * `XrSwapchainSubImage depthSubImage`
  * `float minDepth`
  * `float maxDepth`
  * `float nearZ`
  * `float farZ`
  * `uint recommendedMotionVectorImageRectWidth`
  * `uint recommendedMotionVectorImageRectHeight`
  * `long duration`
  * `uint amplitudeCount`
* **struct XrSpaceVelocityData**
  * `ulong velocityFlags`
  * `XrVector3f linearVelocity`
  * `XrVector3f angularVelocity`
  * `XrStructureType type`
  * `uint velocityCount`
  * `ulong layerFlags`
  * `XrEyeVisibility eyeVisibility`
  * `IntPtr swapchain`
  * `uint imageArrayIndex`
  * `XrQuaternionf orientation`
  * `XrSwapchainSubImage subImage`
  * `float minDepth`
  * `float maxDepth`
  * `float nearZ`
  * `float farZ`
  * `XrPosef pose`
  * `float radius`
  * `float centralAngle`
  * `float aspectRatio`
  * `XrVector2f scale`
  * `XrVector2f bias`
* **struct XrSpace_T**
  * `IntPtr Handle`
  * `bool IsNull { get; set; }`
* **struct XrSpatialAnchorCompletionResultML**
  * `XrUuid uuid`
  * `XrResult result`
  * `XrStructureType type`
  * `uint resultCount`
* **struct XrSpatialAnchorNameHTC**
  * `_name_e__FixedBuffer name`
* **struct XrSpatialAnchorPersistenceNameMSFT**
  * `_name_e__FixedBuffer name`
* **struct XrSpatialBounded2DDataEXT**
  * `XrPosef center`
  * `XrExtent2Df extents`
  * `XrStructureType type`
  * `uint boundCount`
  * `uint parentCount`
* **struct XrSpatialBufferEXT**
  * `ulong bufferId`
  * `XrSpatialBufferTypeEXT bufferType`
  * `XrStructureType type`
* **struct XrSpatialEntityEXT_T**
  * `IntPtr Handle`
  * `bool IsNull { get; set; }`
  * `XrSpatialEntityEXT_T Null { get; set; }`
  * `XrStructureType type`
  * `IntPtr spatialContext`
  * `XrSpatialEntityTrackingStateEXT trackingState`
* **struct XrSpatialMarkerDataEXT**
  * `XrSpatialCapabilityEXT capability`
  * `uint markerId`
  * `XrSpatialBufferEXT data`
  * `XrStructureType type`
  * `uint markerCount`
* **struct XrSpatialMeshDataEXT**
  * `XrPosef origin`
  * `XrSpatialBufferEXT vertexBuffer`
  * `XrSpatialBufferEXT indexBuffer`
  * `XrStructureType type`
  * `uint meshCount`
  * `ulong entityId`
  * `uint entityCount`
  * `uint componentTypeCount`
  * `long time`
* **struct XrSpatialPersistenceDataEXT**
  * `XrUuid persistUuid`
  * `XrSpatialPersistenceStateEXT persistState`
  * `XrStructureType type`
  * `uint persistDataCount`
* **struct XrSpatialPolygon2DDataEXT**
  * `XrPosef origin`
  * `XrSpatialBufferEXT vertexBuffer`
  * `XrStructureType type`
  * `uint polygonCount`
  * `uint semanticLabelCount`
  * `XrUuid generationId`
* **struct XrSpatialRaycastResultDataANDROID**
  * `XrPosef hitPose`
  * `float distanceSquared`
  * `XrStructureType type`
  * `XrSpatialCapabilityEXT capability`
  * `uint enabledComponentCount`
  * `long time`
  * `XrVector3f origin`
  * `XrVector3f direction`
  * `float maxDistance`
  * `uint raycastResultCount`
  * `uint componentTypeCount`
* **struct XrSpheref**
  * `XrPosef center`
  * `float radius`
* **struct XrSystemGraphicsProperties**
  * `uint maxSwapchainImageHeight`
  * `uint maxSwapchainImageWidth`
  * `uint maxLayerCount`
* **struct XrSystemTrackingProperties**
  * `uint orientationTracking`
  * `uint positionTracking`
  * `XrStructureType type`
  * `ulong systemId`
  * `uint vendorId`
  * `_systemName_e__FixedBuffer systemName`
  * `XrSystemGraphicsProperties graphicsProperties`
  * `XrSystemTrackingProperties trackingProperties`
* **struct XrTrackableImageDatabaseANDROID_T**
  * `ulong Handle`
  * `XrTrackableImageDatabaseANDROID_T Null`
  * `bool IsNull { get; set; }`
  * `XrStructureType type`
  * `uint databaseCount`
  * `XrTrackingStateANDROID trackingState`
  * `long lastUpdatedTime`
  * `uint databaseEntryIndex`
  * `XrPosef centerPose`
  * `XrExtent2Df extents`
  * `long time`
* **struct XrTrackableMarkerDatabaseEntryANDROID**
  * `int id`
  * `float edgeSize`
  * `XrTrackableMarkerDictionaryANDROID dictionary`
  * `uint entryCount`
  * `XrStructureType type`
  * `XrTrackableMarkerTrackingModeANDROID trackingMode`
  * `uint databaseCount`
  * `XrTrackingStateANDROID trackingState`
  * `long lastUpdatedTime`
  * `int markerId`
  * `XrPosef centerPose`
  * `XrExtent2Df extents`
* **struct XrTrackableTrackerANDROID_T**
  * `IntPtr Handle`
* **struct XrUuid**
  * `_data_e__FixedBuffer data`
* **struct XrUuidMSFT**
  * `_bytes_e__FixedBuffer bytes`
* **struct XrVector2f**
  * `float x`
  * `float y`
  * `XrStructureType type`
  * `XrVector2f currentState`
  * `uint changedSinceLastSync`
  * `long lastChangeTime`
  * `uint isActive`
  * `ulong subactionPath`
  * `uint countActiveActionSets`
  * `ulong sourcePath`
  * `ulong whichComponents`
* **struct XrVector3f**
  * `float x`
  * `float y`
  * `float z`
  * `XrStructureType type`
  * `ulong velocityFlags`
  * `XrVector3f linearVelocity`
  * `XrVector3f angularVelocity`
* **struct XrVector4f**
  * `float x`
  * `float y`
  * `float z`
  * `float w`
* **struct XrVector4sFB**
  * `short x`
  * `short y`
  * `short z`
  * `short w`
  * `XrStructureType type`
  * `uint jointCapacityInput`
  * `uint jointCountOutput`
  * `uint vertexCapacityInput`
  * `uint vertexCountOutput`
  * `uint indexCapacityInput`
  * `uint indexCountOutput`
  * `float sensorOutput`
  * `float currentOutput`
  * `uint overrideHandScale`
  * `float overrideValueInput`
  * `ulong status`
  * `XrPosef aimPose`
  * `float pinchStrengthIndex`
  * `float pinchStrengthMiddle`
  * `float pinchStrengthRing`
  * `float pinchStrengthLittle`
* **struct _actionName_e__FixedBuffer**
  * `sbyte e0`
* **struct _actionSetName_e__FixedBuffer**
  * `sbyte e0`
* **struct _applicationName_e__FixedBuffer**
  * `sbyte e0`
* **struct _buffer_e__FixedBuffer**
  * `byte e0`
  * `XrStructureType type`
  * `ulong discoveryRequestId`
  * `XrResult result`
  * `ulong requestId`
  * `uint supportsColocationDiscovery`
  * `uint supportsSpatialEntityGroupSharing`
  * `uint groupCount`
  * `XrUuid groupUuid`
* **struct _bytes_e__FixedBuffer**
  * `byte e0`
  * `XrStructureType type`
* **struct _capsules_e__FixedBuffer**
  * `XrHandCapsuleFB e0`
* **struct _coefficients_e__FixedBuffer**
  * `float e0_0`
* **struct _data_e__FixedBuffer**
  * `byte e0`
  * `XrStructureType type`
  * `long time`
  * `uint spaceCount`
* **struct _description_e__FixedBuffer**
  * `sbyte e0`
  * `XrStructureType type`
  * `_extensionName_e__FixedBuffer extensionName`
  * `uint extensionVersion`
* **struct _engineName_e__FixedBuffer**
  * `sbyte e0`
  * `XrStructureType type`
  * `ulong createFlags`
  * `XrApplicationInfo applicationInfo`
  * `uint enabledApiLayerCount`
  * `uint enabledExtensionCount`
  * `ulong runtimeVersion`
  * `_runtimeName_e__FixedBuffer runtimeName`
* **struct _extensionName_e__FixedBuffer**
  * `sbyte e0`
* **struct _eyes_e__FixedBuffer**
  * `XrEyeANDROID e0`
  * `XrStructureType type`
  * `long time`
* **struct _foveationCenter_e__FixedBuffer**
  * `XrVector2f e0`
  * `XrStructureType type`
  * `uint supportsFoveationEyeTracked`
* **struct _gaze_e__FixedBuffer**
  * `XrEyeGazeFB e0`
  * `XrStructureType type`
  * `float leftHandIntensity`
  * `float rightHandIntensity`
  * `ulong layerFlags`
  * `uint bufferSize`
  * `float sampleRate`
  * `uint append`
  * `XrSwapchainSubImage motionVectorSubImage`
  * `XrVector4f motionVectorScale`
  * `XrVector4f motionVectorOffset`
  * `XrPosef appSpaceDeltaPose`
  * `XrSwapchainSubImage depthSubImage`
  * `float minDepth`
  * `float maxDepth`
  * `float nearZ`
  * `float farZ`
  * `uint recommendedMotionVectorImageRectWidth`
  * `uint recommendedMotionVectorImageRectHeight`
* **struct _layerName_e__FixedBuffer**
  * `sbyte e0`
* **struct _localizedActionName_e__FixedBuffer**
  * `sbyte e0`
  * `ulong binding`
  * `XrStructureType type`
  * `ulong interactionProfile`
  * `uint countSuggestedBindings`
  * `uint countActionSets`
  * `ulong subactionPath`
  * `uint currentState`
  * `uint changedSinceLastSync`
  * `long lastChangeTime`
  * `uint isActive`
  * `float currentState`
* **struct _localizedActionSetName_e__FixedBuffer**
  * `sbyte e0`
  * `XrStructureType type`
  * `_actionName_e__FixedBuffer actionName`
  * `XrActionType actionType`
  * `uint countSubactionPaths`
  * `_localizedActionName_e__FixedBuffer localizedActionName`
* **struct _modelName_e__FixedBuffer**
  * `sbyte e0`
  * `XrStructureType type`
  * `uint bufferCapacityInput`
  * `uint bufferCountOutput`
  * `ulong modelKey`
  * `uint supportsRenderModelLoading`
  * `ulong flags`
  * `uint foveatedRenderingActive`
  * `uint supportsFoveatedRendering`
  * `float depthTestRangeNearZ`
  * `float depthTestRangeFarZ`
  * `uint supportsMarkerTracking`
  * `ulong markerId`
  * `uint isActive`
  * `uint isPredicted`
  * `long time`
  * `XrPosef poseInMarkerSpace`
  * `float focusDistance`
  * `float dimmerValue`
* **struct _name_e__FixedBuffer**
  * `sbyte e0`
  * `XrStructureType type`
  * `ulong trackedKeyboardId`
  * `ulong flags`
  * `XrLocalizationMapStateML state`
  * `XrLocalizationMapML map`
  * `XrLocalizationMapConfidenceML confidence`
  * `ulong errorFlags`
  * `XrUuid mapUuid`
  * `uint size`
  * `uint enabled`
  * `XrSpatialAnchorPersistenceNameMSFT spatialAnchorPersistenceName`
  * `IntPtr spatialAnchor`
  * `IntPtr spatialAnchorStore`
  * `XrPosef poseInSpace`
  * `XrSpatialAnchorNameHTC name`
* **struct _nodeId_e__FixedBuffer**
  * `byte e0`
  * `XrStructureType type`
  * `XrPosef poseInSpace`
  * `long time`
  * `_nodeId_e__FixedBuffer nodeId`
  * `XrPosef poseInNodeSpace`
* **struct _nodeName_e__FixedBuffer**
  * `sbyte e0`
  * `XrStructureType type`
  * `uint nodeCapacityInput`
  * `uint nodeCountOutput`
  * `XrPosef nodePose`
  * `XrFovf recommendedFov`
  * `XrFovf maxMutableFov`
* **struct _parentNodeName_e__FixedBuffer**
  * `sbyte e0`
* **struct _points_e__FixedBuffer**
  * `XrVector3f e0`
  * `XrStructureType type`
  * `_capsules_e__FixedBuffer capsules`
* **struct _runtimeName_e__FixedBuffer**
  * `sbyte e0`
  * `XrStructureType type`
  * `_varying_e__FixedBuffer varying`
* **struct _systemName_e__FixedBuffer**
  * `sbyte e0`
  * `XrStructureType type`
  * `ulong createFlags`
  * `ulong systemId`
* **struct _text_e__FixedBuffer**
  * `sbyte e0`
  * `XrStructureType type`
* **struct _textureColorMap_e__FixedBuffer**
  * `XrColor4f e0`
  * `XrStructureType type`
  * `_textureColorMap_e__FixedBuffer textureColorMap`
  * `byte e0`
  * `float brightness`
  * `float contrast`
  * `float saturation`
  * `ulong flags`
  * `ulong path`
  * `uint vendorId`
  * `_modelName_e__FixedBuffer modelName`
  * `ulong modelKey`
  * `uint modelVersion`
* **struct _uniqueName_e__FixedBuffer**
  * `sbyte e0`
  * `XrStructureType type`
  * `uint nodePropertyCount`
  * `uint topLevelUserPathCount`
* **struct _varying_e__FixedBuffer**
  * `byte e0`
  * `XrStructureType type`
  * `XrFormFactor formFactor`
* **struct _views_e__FixedBuffer**
  * `XrEnvironmentDepthImageViewMETA e0`
  * `XrStructureType type`
  * `long captureTime`
  * `uint enabled`
  * `uint supportsEnvironmentDepth`
  * `uint supportsHandRemoval`
  * `ulong renderModelId`
  * `uint gltfExtensionCount`
  * `XrUuid cacheId`
  * `uint animatableNodeCount`
  * `IntPtr renderModel`
  * `long displayTime`
* **struct _visemes_e__FixedBuffer**
  * `float e0`
  * `XrStructureType type`
  * `uint supportsVisemes`

</details>


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
At least its better than placing it in 'LocalLow{Dev}{Game}Player.log' where NO ORDINARY USER WILL BE ABLE TO FIND IT.

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
    catch (Exception ex)
    {
        Logger.Log($"nFATAL EXCEPTION in Main:", LoggingTarget.MainConstructor, logLevel: LogLevel.Critical, exception: ex);
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

    * Not going to rant about microsoft implementations, just that me personally, I have no idea (as of now) how graphics rendering works in the terms of creation, nor does the documentation really help me in the case of using C#.
    * Although I do state all of the above, GDI is the only one that does not adhere to this. The implementation carries from Python, and is human written (for the most part, conversion was AI.)

    ### Angene.Windows

* Kernel32
* Gdi32
* Win32
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

