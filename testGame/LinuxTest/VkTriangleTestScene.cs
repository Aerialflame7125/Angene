using Angene.Common;
using Angene.Graphics;
using static Angene.Vulkan.Interop.Structs;
using static Angene.Vulkan.Interop.Enumerators;
using System.IO;
using Angene.Essentials;
using System.Collections.Generic;
using Angene.Main;
using System;
using Angene.Graphics.SlangShader;

namespace Game.Scenes
{
    public unsafe class VkTriangleTestScene : IScene
    {
        public object Instance { get; private set; }
        public List<Entity> Entities { get; private set; } = new List<Entity>();
        public string Name => "VkTriangleTestScene";

        private readonly Window _window;
        private IVkGraphicsContext _gfx;

        private IntPtr _vertexBuffer;
        private IntPtr _vertexShaderModule;
        private IntPtr _fragmentShaderModule;
        private IntPtr _pipeline;

        private SlangShaderResources.IShader _vertexShader;
        private SlangShaderResources.IShader _fragShader;

        public VkTriangleTestScene(Window window)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public void Initialize()
        {
            Instance = this;

            _gfx = _window.Graphics as IVkGraphicsContext;
            if (_gfx == null)
            {
                Logger.LogCritical("[VkTriangleTestScene] Window is not using the Vulkan backend.", LoggingTarget.Graphics, new Exception("Window is not using the Vulkan rendering backend."));
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

            if (Engine.Instance.ShaderCache == null
                || !Engine.Instance.ShaderCache.TryGetValue(1, out _vertexShader)
                || !Engine.Instance.ShaderCache.TryGetValue(2, out _fragShader))
            {
                Logger.LogCritical("[ShaderCompileTestScene] VertexShader/FragmentShader were not found in Engine.Instance.ShaderCache. Precompilation did not run or failed silently.", LoggingTarget.Graphics, new AngeneException("Shader cache missing expected entries."));
                return;
            }

            _vertexShaderModule = _gfx.CreateShaderModule(_vertexShader.byteCode);
            _fragmentShaderModule = _gfx.CreateShaderModule(_fragShader.byteCode);

            var attributes = new VkVertexInputAttributeDescription[]
            {
                new VkVertexInputAttributeDescription
                {
                    location = 0, binding = 0,
                    format = VkFormat.VK_FORMAT_R32G32B32_SFLOAT,
                    offset = 0
                },
                new VkVertexInputAttributeDescription
                {
                    location = 1, binding = 0,
                    format = VkFormat.VK_FORMAT_R32G32B32A32_SFLOAT,
                    offset = 12
                },
            };

            _pipeline = _gfx.CreatePipeline(_vertexShaderModule, _fragmentShaderModule, attributes, strideBytes: 7 * sizeof(float));

            Logger.LogInfo("[VkTriangleTestScene] Initialized.", LoggingTarget.Graphics);
        }

        public void OnMessage(IntPtr msgPtr) { }

        public void Render()
        {
            if (_gfx == null) return;

            _gfx.BeginFrame(0xFF203040); // opaque dark navy

            _gfx.SetPipeline(_pipeline);
            _gfx.SetVertexBuffer(_vertexBuffer, strideBytes: 7 * sizeof(float));
            _gfx.Draw(3);

            _gfx.EndFrame();
        }

        public void Cleanup()
        {
            // pipeline/shader module/buffer teardown belongs here once
            // VkGraphicsContext exposes destroy methods for them individually,
            // or relies on Cleanup() sweeping the tracked dictionaries.
        }
    }
}