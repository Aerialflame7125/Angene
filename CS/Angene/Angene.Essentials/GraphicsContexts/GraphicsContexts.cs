using static Angene.Vulkan.Interop.Enumerators;
using static Angene.Vulkan.Interop.Structs;
using static Angene.Windows.Dxgi.DxgiEnums;

namespace Angene.Essentials.GraphicsContexts;

    // Abstract interface for platform-specific graphics
    public struct InputElement
    {
        public string SemanticName;
        public uint SemanticIndex;
        public DXGI_FORMAT Format;
        public uint ByteOffset;
    }

    public interface IGraphicsContext
    {
        IntPtr Handle { get; }
        void Clear(uint color);
        void Present(IntPtr windowHandle);
        void Cleanup();
        bool isDisposed();
        void Resize(int width, int height);
        byte[] GetRawPixels();
    }

    public interface IDX11GraphicsContext : IGraphicsContext
    {
        IntPtr ContextHandle { get; }
        IntPtr CreateVertexBuffer(byte[] data, uint strideBytes);
        IntPtr CreateIndexBuffer(uint[] indices);
        IntPtr CreateVertexShader(byte[] bytecode);
        IntPtr CreatePixelShader(byte[] bytecode);
        IntPtr CreateInputLayout(InputElement[] elements, byte[] vsBytecode);

        void SetVertexBuffer(IntPtr buffer, uint strideBytes, uint offset = 0);
        void SetIndexBuffer(IntPtr buffer, uint offset = 0);
        void SetInputLayout(IntPtr inputLayout);
        void SetShader(SlangShaderResources.IShader vs, SlangShaderResources.IShader ps);
        void Draw(uint vertexCount, uint startVertex = 0);
        void DrawIndexed(uint indexCount, uint startIndex = 0, int baseVertex = 0);
        IntPtr CreateConstantBuffer(uint byteWidth);
        void UpdateConstantBuffer(IntPtr buffer, byte[] data);
        void SetVertexShaderConstantBuffer(IntPtr buffer, uint slot = 0);
        IntPtr CreateRasterizerState(bool cullNone);
        void SetRasterizerState(IntPtr state);
        void BeginFrame(uint clearColor);
        void Render(
            SlangShaderResources.IShader vertexShader,
            SlangShaderResources.IShader pixelShader,
            IntPtr inputLayout,
            IntPtr vertexBuffer,
            uint vertexStride,
            uint vertexCount);
        void EndFrame();
    }

    public interface IVkGraphicsContext : IGraphicsContext
    {
        // Context
        IntPtr VkInstance { get; } // keep as IntPtr
        IntPtr VkPhysicalDevice { get; } // keep as IntPtr
        IntPtr VkDevice { get; } // keep as IntPtr
        IntPtr VkQueue { get; }

        // Window/Presentation
        IntPtr VkSurfaceKHR { get; } // keep as IntPtr
        IntPtr VkSwapchainKHR { get; } // keep as IntPtr
        VkFormat VkFormat { get; }
        VkExtent2D VkExtent2D { get; }
        int SwapchainImageCount { get; }
        int CurrentImageIndex { get; }

        // Execution/Rendering
        IntPtr VkCommandPool { get; }
        IntPtr VkCommandBuffer { get; } // keep as IntPtr
        IntPtr VkRenderPass { get; }
        IntPtr VkFramebuffer { get; }
        IntPtr VkPipeline { get; }
        IntPtr VkSemaphoreImageAvailable { get; }
        IntPtr VkSemaphoreRenderFinished { get; }
        IntPtr VkFenceInFlight { get; }

        // IGraphicsContext
        IntPtr Handle => (IntPtr)VkDevice;
        IntPtr ContextHandle => (IntPtr)VkInstance;

        // Resource creation
        IntPtr CreateVertexBuffer(byte[] data, uint strideBytes);
        IntPtr CreateIndexBuffer(uint[] indices);
        IntPtr CreatePipeline(IntPtr vertexShaderModule, IntPtr fragmentShaderModule,
                      VkVertexInputAttributeDescription[] attributes, uint strideBytes);

        // Per-draw state
        void SetVertexBuffer(IntPtr buffer, uint strideBytes, uint offset = 0);
        void SetIndexBuffer(IntPtr buffer, uint offset = 0);
        void SetPipeline(IntPtr pipeline);
        void Draw(uint vertexCount, uint startVertex = 0);
        void DrawIndexed(uint indexCount, uint startIndex = 0, int baseVertex = 0);

        // Frame lifecycle
        void BeginFrame(uint clearColor);
        void EndFrame();
    }
    
