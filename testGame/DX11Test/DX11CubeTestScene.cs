using Angene.Common;
using Angene.Essentials;
using Angene.Graphics;
using Angene.Graphics.DX11;
using Angene.Main;
using Angene.Windows.D3D11;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;
using static Angene.Windows.Dxgi.DxgiEnums;

namespace Game
{
    public class DX11CubeTestScene : IScene
    {
        public object Instance { get; private set; }
        public List<Entity> Entities { get; private set; } = new List<Entity>();
        public string Name => "DX11CubeTestScene";

        private readonly Window _window;
        private IDX11GraphicsContext _gfx;

        private IntPtr _vertexBuffer;
        private IntPtr _indexBuffer;
        private IntPtr _inputLayout;
        private IntPtr _constantBuffer;
        private IntPtr _rasterizerState;
        private Dx11Shader _vertexShader;
        private Dx11Shader _pixelShader;

        private readonly DateTime _startTime = DateTime.Now;

        public DX11CubeTestScene(Window window)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public void Initialize()
        {
            Instance = this;

            _gfx = _window.Graphics as IDX11GraphicsContext;
            if (_gfx == null)
            {
                Logger.LogCritical("[DX11CubeTestScene] Window is not using the D3D11 backend.", LoggingTarget.Graphics, new AngeneException("Not a D3D11 window."));
                return;
            }

            // 24 verts (4 per face) so each face can have its own solid color.
            // Layout: position (3f) + color (4f) = 28 bytes/vertex — same stride as the triangle test.
            float[] vertices =
            {
                // +X face (red)
                 0.5f,-0.5f,-0.5f, 1,0,0,1,   0.5f, 0.5f,-0.5f, 1,0,0,1,   0.5f, 0.5f, 0.5f, 1,0,0,1,   0.5f,-0.5f, 0.5f, 1,0,0,1,
                // -X face (cyan)
                -0.5f,-0.5f, 0.5f, 0,1,1,1,  -0.5f, 0.5f, 0.5f, 0,1,1,1,  -0.5f, 0.5f,-0.5f, 0,1,1,1,  -0.5f,-0.5f,-0.5f, 0,1,1,1,
                // +Y face (green)
                -0.5f, 0.5f,-0.5f, 0,1,0,1,  -0.5f, 0.5f, 0.5f, 0,1,0,1,   0.5f, 0.5f, 0.5f, 0,1,0,1,   0.5f, 0.5f,-0.5f, 0,1,0,1,
                // -Y face (magenta)
                -0.5f,-0.5f, 0.5f, 1,0,1,1,  -0.5f,-0.5f,-0.5f, 1,0,1,1,   0.5f,-0.5f,-0.5f, 1,0,1,1,   0.5f,-0.5f, 0.5f, 1,0,1,1,
                // +Z face (blue)
                -0.5f,-0.5f, 0.5f, 0,0,1,1,   0.5f,-0.5f, 0.5f, 0,0,1,1,   0.5f, 0.5f, 0.5f, 0,0,1,1,  -0.5f, 0.5f, 0.5f, 0,0,1,1,
                // -Z face (yellow)
                 0.5f,-0.5f,-0.5f, 1,1,0,1,  -0.5f,-0.5f,-0.5f, 1,1,0,1,  -0.5f, 0.5f,-0.5f, 1,1,0,1,   0.5f, 0.5f,-0.5f, 1,1,0,1,
            };
            byte[] vertexBytes = new byte[vertices.Length * sizeof(float)];
            Buffer.BlockCopy(vertices, 0, vertexBytes, 0, vertexBytes.Length);
            _vertexBuffer = _gfx.CreateVertexBuffer(vertexBytes, strideBytes: 7 * sizeof(float));

            uint[] indices =
            {
                 0, 1, 2,  0, 2, 3,   // +X
                 4, 5, 6,  4, 6, 7,   // -X
                 8, 9,10,  8,10,11,   // +Y
                12,13,14, 12,14,15,   // -Y
                16,17,18, 16,18,19,   // +Z
                20,21,22, 20,22,23,   // -Z
            };
            _indexBuffer = _gfx.CreateIndexBuffer(indices);

            string shaderDir = Path.Combine(AppContext.BaseDirectory, "Shaders");
            byte[] vsBytecode = File.ReadAllBytes(Path.Combine(shaderDir, "VertexShader3D.cso"));
            byte[] psBytecode = File.ReadAllBytes(Path.Combine(shaderDir, "PixelShader.cso"));

            IntPtr vsPtr = _gfx.CreateVertexShader(vsBytecode);
            IntPtr psPtr = _gfx.CreatePixelShader(psBytecode);
            _vertexShader = new Dx11Shader("CubeVS", SlangShaderResources.ShaderType.Vertex, null, null, IntPtr.Zero, vsPtr);
            _pixelShader = new Dx11Shader("CubePS", SlangShaderResources.ShaderType.Pixel, null, null, IntPtr.Zero, psPtr);

            var elements = new[]
            {
                new InputElement { SemanticName = "POSITION", SemanticIndex = 0, Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT,    ByteOffset = 0  },
                new InputElement { SemanticName = "COLOR",    SemanticIndex = 0, Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT, ByteOffset = 12 },
            };
            _inputLayout = _gfx.CreateInputLayout(elements, vsBytecode);

            _constantBuffer = _gfx.CreateConstantBuffer((uint)Marshal.SizeOf<Matrix4x4>()); // 64 bytes
            _rasterizerState = _gfx.CreateRasterizerState(cullNone: true);

            Logger.LogInfo("[DX11CubeTestScene] Initialized.", LoggingTarget.Graphics);
        }

        public void OnMessage(IntPtr msgPtr) { }

        public void Render()
        {
            if (_gfx == null) return;

            float t = (float)(DateTime.Now - _startTime).TotalSeconds;
            Matrix4x4 world = Matrix4x4.CreateRotationY(t) * Matrix4x4.CreateRotationX(t * 0.5f);
            Matrix4x4 view = Matrix4x4.CreateLookAt(new Vector3(0, 0, -3f), Vector3.Zero, Vector3.UnitY);
            float aspect = _window.Height > 0 ? (float)_window.Width / _window.Height : 1f;
            Matrix4x4 proj = Matrix4x4.CreatePerspectiveFieldOfView(MathF.PI / 4f, aspect, 0.1f, 100f);
            Matrix4x4 wvp = world * view * proj;

            byte[] cbData = new byte[64];
            var h = GCHandle.Alloc(wvp, GCHandleType.Pinned);
            Marshal.Copy(h.AddrOfPinnedObject(), cbData, 0, 64);
            h.Free();
            _gfx.UpdateConstantBuffer(_constantBuffer, cbData);

            _gfx.Clear(0xFF101020);

            _gfx.SetRasterizerState(_rasterizerState);
            _gfx.SetVertexBuffer(_vertexBuffer, strideBytes: 7 * sizeof(float));
            _gfx.SetIndexBuffer(_indexBuffer);
            _gfx.SetInputLayout(_inputLayout);
            _gfx.SetShader(_vertexShader, _pixelShader);
            _gfx.SetVertexShaderConstantBuffer(_constantBuffer);
            _gfx.DrawIndexed(36);

            _gfx.Present((IntPtr)_window.Hwnd);
        }

        public void Cleanup()
        {
            _vertexShader?.Dispose();
            _pixelShader?.Dispose();
            if (_vertexBuffer != IntPtr.Zero) Marshal.Release(_vertexBuffer);
            if (_indexBuffer != IntPtr.Zero) Marshal.Release(_indexBuffer);
            if (_inputLayout != IntPtr.Zero) Marshal.Release(_inputLayout);
            if (_constantBuffer != IntPtr.Zero) Marshal.Release(_constantBuffer);
            if (_rasterizerState != IntPtr.Zero) Marshal.Release(_rasterizerState);
        }
    }
}