using Angene.Common;
using Angene.Essentials;
using Angene.Graphics;
using Angene.Graphics.DX11;
using Angene.Main;
using Angene.Windows.D3D11;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using static Angene.Windows.Dxgi.DxgiEnums;

namespace Game
{
    public class DX11TriangleTestScene : IScene
    {
        public object Instance { get; private set; }
        public List<Entity> Entities { get; private set; } = new List<Entity>();
        public string Name => "DX11TriangleTestScene";

        private readonly Window _window;
        private IDX11GraphicsContext _gfx;

        private IntPtr _vertexBuffer;
        private IntPtr _inputLayout;
        private Dx11Shader _vertexShader;
        private Dx11Shader _pixelShader;

        public DX11TriangleTestScene(Window window)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public void Initialize()
        {
            Instance = this;

            _gfx = _window.Graphics as IDX11GraphicsContext;
            if (_gfx == null)
            {
                Logger.LogCritical("[DX11TriangleTestScene] Window is not using the D3D11 backend — use WindowConfig.Rendering3D(...).", LoggingTarget.Graphics, new AngeneException("Window is not using the D3D11 rendering backend."));
                return;
            }

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

            string shaderDir = Path.Combine(AppContext.BaseDirectory, "Shaders");
            byte[] vsBytecode = File.ReadAllBytes(Path.Combine(shaderDir, "VertexShader.cso"));
            byte[] psBytecode = File.ReadAllBytes(Path.Combine(shaderDir, "PixelShader.cso"));

            IntPtr vsPtr = _gfx.CreateVertexShader(vsBytecode);
            IntPtr psPtr = _gfx.CreatePixelShader(psBytecode);

            _vertexShader = new Dx11Shader("TestVS", SlangShaderResources.ShaderType.Vertex, null, null, IntPtr.Zero, vsPtr);
            _pixelShader = new Dx11Shader("TestPS", SlangShaderResources.ShaderType.Pixel, null, null, IntPtr.Zero, psPtr);

            var elements = new[]
            {
                new InputElement { SemanticName = "POSITION", SemanticIndex = 0, Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT,    ByteOffset = 0  },
                new InputElement { SemanticName = "COLOR",    SemanticIndex = 0, Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT, ByteOffset = 12 },
            };
            _inputLayout = _gfx.CreateInputLayout(elements, vsBytecode);

            Logger.LogInfo("[DX11TriangleTestScene] Initialized.", LoggingTarget.Graphics);
        }

        public void OnMessage(IntPtr msgPtr) { }

        public void Render()
        {
            if (_gfx == null) return;

            _gfx.Clear(0xFF203040); // opaque dark navy

            _gfx.SetVertexBuffer(_vertexBuffer, strideBytes: 7 * sizeof(float));
            _gfx.SetInputLayout(_inputLayout);
            _gfx.SetShader(_vertexShader, _pixelShader);
            _gfx.Draw(3);

            _gfx.Present((IntPtr)_window.Hwnd);
        }

        public void Cleanup()
        {
            _vertexShader?.Dispose();
            _pixelShader?.Dispose();
            if (_vertexBuffer != IntPtr.Zero) Marshal.Release(_vertexBuffer);
            if (_inputLayout != IntPtr.Zero) Marshal.Release(_inputLayout);
        }
    }
}