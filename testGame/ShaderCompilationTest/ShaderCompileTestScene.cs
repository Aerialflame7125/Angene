using Angene.Common;
using Angene.Essentials;
using Angene.Graphics;
using Angene.Graphics.SlangShader;
using Angene.Main;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Angene.Windows.Dxgi.DxgiEnums;
using static Angene.Graphics.Defs;
using Angene.Essentials.GraphicsContexts;

namespace Game
{
    // Proves the [Precompile] -> Slang -> Engine.Instance.ShaderCache pipeline actually
    // produces usable D3D11 shaders, by drawing a triangle with the shaders that came out
    // of the cache rather than loading pre-baked .cso files (compare with
    // DX11Test/DX11TestScene.cs, which uses the old .cso-loading path).
    public class ShaderCompileTestScene : IDX11Scene
    {
        public object Instance { get; private set; }
        public List<Entity> Entities { get; private set; } = new List<Entity>();
        public string Name => "ShaderCompileTestScene";

        public Entity MainCamera => null;

        private readonly Window _window;
        private IDX11GraphicsContext _gfx;

        private IntPtr _vertexBuffer;
        private IntPtr _inputLayout;
        private object vertexShader;
        private object pixelShader;
        private SlangShaderResources.IShader _vertexShader => (SlangShaderResources.IShader)vertexShader;
        private SlangShaderResources.IShader _pixelShader => (SlangShaderResources.IShader)pixelShader;

        private Vertex[] vertices = new Vertex[] { };
        private uint vertexStride;
        private int vertexCount;
        private int totalByteSize;

        public ShaderCompileTestScene(Window window)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public void Initialize()
        {
            Instance = this;

            _gfx = _window.Graphics as IDX11GraphicsContext;
            if (_gfx is null)
            {
                Logger.LogCritical("[ShaderCompileTestScene] Window is not using the D3D11 backend — use WindowConfig.Rendering3D(...).", LoggingTarget.Graphics, new AngeneException("Window is not using the D3D11 rendering backend."));
                return;
            }

            if (Engine.Instance.ShaderCache == null
                || !Engine.Instance.ShaderCache.TryGetValue(1, out vertexShader)
                || !Engine.Instance.ShaderCache.TryGetValue(2, out pixelShader))
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
            };

            vertexStride = (uint)Marshal.SizeOf<Vertex>(); // 28 bytes
            vertexCount = vertices.Length;            // 3 vertices
            totalByteSize = (int)(vertexStride * vertexCount);

            // Convert to byte array seamlessly
            byte[] vertexBytes = MemoryMarshal.AsBytes(vertices.AsSpan()).ToArray();
            totalByteSize = vertexBytes.Length;

            // Pass variables instead of hardcoded numbers
            _vertexBuffer = _gfx.CreateVertexBuffer(vertexBytes, vertexStride);

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

        public void Render() { } // temporary compatibility member
        public void Render(IDX11GraphicsContext _gfx)
        {
            _gfx.Render(_vertexShader, _pixelShader,
                   _inputLayout, _vertexBuffer,
                   vertexStride, (uint)vertexCount);
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
