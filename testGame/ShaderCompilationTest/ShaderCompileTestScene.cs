using Angene.Common;
using Angene.Essentials;
using Angene.Graphics;
using Angene.Graphics.DX11;
using Angene.Main;
using Angene.Windows.D3D11;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Angene.Windows.Dxgi.DxgiEnums;

namespace Game
{
    // Proves the [Precompile] -> Slang -> Engine.Instance.ShaderCache pipeline actually
    // produces usable D3D11 shaders, by drawing a triangle with the shaders that came out
    // of the cache rather than loading pre-baked .cso files (compare with
    // DX11Test/DX11TestScene.cs, which uses the old .cso-loading path).
    public class ShaderCompileTestScene : IScene
    {
        public object Instance { get; private set; }
        public List<Entity> Entities { get; private set; } = new List<Entity>();
        public string Name => "ShaderCompileTestScene";

        private readonly Window _window;
        private IDX11GraphicsContext _gfx;

        private IntPtr _vertexBuffer;
        private IntPtr _inputLayout;
        private SlangShaderResources.IShader _vertexShader;
        private SlangShaderResources.IShader _pixelShader;

        public ShaderCompileTestScene(Window window)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public void Initialize()
        {
            Instance = this;

            _gfx = _window.Graphics as IDX11GraphicsContext;
            if (_gfx == null)
            {
                Logger.LogCritical("[ShaderCompileTestScene] Window is not using the D3D11 backend — use WindowConfig.Rendering3D(...).", LoggingTarget.Graphics, new AngeneException("Window is not using the D3D11 rendering backend."));
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

            // Interleaved position (float3) + color (float4) = 7 floats / 28 bytes per vertex
            float[] vertices =
            {
                 0.0f,  0.5f, 0.0f,   1f, 0f, 0f, 1f,
                 0.5f, -0.5f, 0.0f,   0f, 1f, 0f, 1f,
                -0.5f, -0.5f, 0.0f,   0f, 0f, 1f, 1f,
            };
            byte[] vertexBytes = new byte[vertices.Length * sizeof(float)];
            Buffer.BlockCopy(vertices, 0, vertexBytes, 0, vertexBytes.Length);

            _vertexBuffer = _gfx.CreateVertexBuffer(vertexBytes, strideBytes: 7 * sizeof(float));

            var elements = new[]
            {
                new InputElement { SemanticName = "POSITION", SemanticIndex = 0, Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT,    ByteOffset = 0  },
                new InputElement { SemanticName = "COLOR",    SemanticIndex = 0, Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT, ByteOffset = 12 },
            };
            
            if (_vertexShader.byteCode == null)
                Logger.LogCritical("Vertex shader bytecode is null. Compilation did not succeed.", LoggingTarget.MainGame, new AngeneException("Bytecode is null."), true);

            _inputLayout = _gfx.CreateInputLayout(elements, _vertexShader.byteCode);

            Logger.LogInfo("[ShaderCompileTestScene] Initialized.", LoggingTarget.Graphics);
        }

        public void OnMessage(IntPtr msgPtr) { }

        public void Render()
        {
            if (_gfx == null || _vertexShader == null || _pixelShader == null) return;

            _gfx.Clear(0xFF203040); // opaque dark navy

            _gfx.SetVertexBuffer(_vertexBuffer, strideBytes: 7 * sizeof(float));
            _gfx.SetInputLayout(_inputLayout);
            _gfx.SetShader(_vertexShader, _pixelShader);
            _gfx.Draw(3);

            _gfx.Present((IntPtr)_window.Hwnd);
        }

        public void Cleanup()
        {
            // Don't dispose _vertexShader/_pixelShader here — they're owned by
            // Engine.Instance.ShaderCache, not this scene.
            if (_vertexBuffer != IntPtr.Zero) Marshal.Release(_vertexBuffer);
            if (_inputLayout != IntPtr.Zero) Marshal.Release(_inputLayout);
        }
    }
}
