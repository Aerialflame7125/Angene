using Angene.Common;
using Angene.Graphics.DX11;
using Angene.Graphics.SlangShader;
using Angene.Windows;
using Angene.Windows.D3D11;
using Angene.X11.Interop;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using static Angene.Vulkan.Interop.Enumerators;
using static Angene.Vulkan.Interop.Structs;
using static Angene.Windows.Dxgi.DxgiEnums;

namespace Angene.Graphics
{
    public unsafe class X11WindowHandle
    {
        public XLib._XDisplay* Display { get; }
        public IntPtr Window { get; }
        public sbyte* TitlePtr { get; }

        public X11WindowHandle(XLib._XDisplay* display, IntPtr window, sbyte* titlePtr)
        {
            Display = display;
            Window = window;
            TitlePtr = titlePtr;
        }
    }

    public class MicrosoftWindowHandle
    {
        public IntPtr Hwnd { get; }

        public MicrosoftWindowHandle(IntPtr hwnd)
        {
            Hwnd = hwnd;
        }
    }

    // Abstract interface for platform-specific graphics
    public interface IGraphicsContext
    {
        IntPtr Handle { get; }
        void Clear(uint color);
        void Present(IntPtr windowHandle);
        void Cleanup();
        void Resize(int width, int height);
        byte[] GetRawPixels();
    }

    public struct InputElement
    {
        public string SemanticName;
        public uint SemanticIndex;
        public DXGI_FORMAT Format;
        public uint ByteOffset;
    }
#if WINDOWS
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

    // Windows GDI implementation
    public class GdiGraphicsContext : IGraphicsContext, IDisposable
    {
        private IntPtr windowHandle;
        private IntPtr memDc;
        private IntPtr bitmap;
        private IntPtr oldBitmap;
        private int width;
        private int height;

        public IntPtr Handle => memDc;
        
        public GdiGraphicsContext(IntPtr hwnd, int w, int h)
        {
            windowHandle = hwnd;
            width = w;
            height = h;
            
            IntPtr hdc = User32.GetDC(hwnd);
            memDc = Gdi32.CreateCompatibleDC(hdc);
            bitmap = Gdi32.CreateCompatibleBitmap(hdc, w, h);
            oldBitmap = Gdi32.SelectObject(memDc, bitmap);
            User32.ReleaseDC(hwnd, hdc);
        }
        
        public void Resize(int w, int h) { }

        public void Clear(uint color)
        {
            IntPtr brush = Gdi32.CreateSolidBrush(color);
            IntPtr oldBrush = Gdi32.SelectObject(memDc, brush);
            Gdi32.Rectangle(memDc, 0, 0, width, height);
            Gdi32.SelectObject(memDc, oldBrush);
            Gdi32.DeleteObject(brush);
        }
        
        public void DrawRectangle(int x, int y, int w, int h, uint color)
        {
            IntPtr brush = Gdi32.CreateSolidBrush(color);
            IntPtr oldBrush = Gdi32.SelectObject(memDc, brush);
            Gdi32.Rectangle(memDc, x, y, x + w, y + h);
            Gdi32.SelectObject(memDc, oldBrush);
            Gdi32.DeleteObject(brush);
        }
        
        public void DrawText(string text, int x, int y, uint color)
        {
            Gdi32.SetBkMode(memDc, 1); // TRANSPARENT
            Gdi32.SetTextColor(memDc, color);
            Gdi32.TextOutW(memDc, x, y, text, text.Length);
        }
        
        public void Present(IntPtr hwnd)
        {
            IntPtr hdc = User32.GetDC(hwnd);
            Gdi32.BitBlt(hdc, 0, 0, width, height, memDc, 0, 0, Gdi32.SRCCOPY);
            User32.ReleaseDC(hwnd, hdc);
        }

        public void Cleanup()
        {
            Dispose();
        }

        public byte[] GetRawPixels() { return null; }

        public void Dispose()
        {
            if (oldBitmap != IntPtr.Zero)
                Gdi32.SelectObject(memDc, oldBitmap);
            if (bitmap != IntPtr.Zero)
                Gdi32.DeleteObject(bitmap);
            if (memDc != IntPtr.Zero)
                Gdi32.DeleteDC(memDc);
        }
    }
    public class WSGraphicsContext : IGraphicsContext
    {
        private string windowHandle;
        private IntPtr memDc;
        private IntPtr bitmap;
        private IntPtr oldBitmap;
        private int width;
        private int height;

        public IntPtr Handle => memDc;

        public WSGraphicsContext(string hwnd, int w, int h)
        {
            windowHandle = hwnd; // This is just for your internal mapping
            width = w;
            height = h;

            // Get the Desktop DC as a reference (IntPtr.Zero is the screen)
            IntPtr hdc = User32.GetDC(IntPtr.Zero);

            // Create a Memory DC that isn't tied to any window
            memDc = Gdi32.CreateCompatibleDC(hdc);

            // Create a bitmap in RAM that matches the screen's color depth
            bitmap = Gdi32.CreateCompatibleBitmap(hdc, w, h);

            // Select the bitmap into our DC so GDI functions draw onto the bitmap
            oldBitmap = Gdi32.SelectObject(memDc, bitmap);

            // We're done with the screen DC reference
            User32.ReleaseDC(IntPtr.Zero, hdc);
        }

        public void Resize(int w, int h) { }

        public void Clear(uint color)
        {
            IntPtr brush = Gdi32.CreateSolidBrush(color);
            IntPtr oldBrush = Gdi32.SelectObject(memDc, brush);
            Gdi32.Rectangle(memDc, 0, 0, width, height);
            Gdi32.SelectObject(memDc, oldBrush);
            Gdi32.DeleteObject(brush);
        }

        public void DrawRectangle(int x, int y, int w, int h, uint color)
        {
            IntPtr brush = Gdi32.CreateSolidBrush(color);
            IntPtr oldBrush = Gdi32.SelectObject(memDc, brush);
            Gdi32.Rectangle(memDc, x, y, x + w, y + h);
            Gdi32.SelectObject(memDc, oldBrush);
            Gdi32.DeleteObject(brush);
        }

        public void DrawText(string text, int x, int y, uint color)
        {
            Gdi32.SetBkMode(memDc, 1); // TRANSPARENT
            Gdi32.SetTextColor(memDc, color);
            Gdi32.TextOutW(memDc, x, y, text, text.Length);
        }

        public void Cleanup()
        {
            if (oldBitmap != IntPtr.Zero)
                Gdi32.SelectObject(memDc, oldBitmap);
            if (bitmap != IntPtr.Zero)
                Gdi32.DeleteObject(bitmap);
            if (memDc != IntPtr.Zero)
                Gdi32.DeleteDC(memDc);
        }
        public byte[] GetRawPixels()
        {
            int size = width * height * 4;
            byte[] pixels = new byte[size];

            Gdi32.BITMAPINFO bmi = new Gdi32.BITMAPINFO();
            bmi.bmiHeader.biSize = (uint)Marshal.SizeOf(typeof(Gdi32.BITMAPINFOHEADER));
            bmi.bmiHeader.biWidth = width;
            bmi.bmiHeader.biHeight = -height; // Negative for top-down bitmap
            bmi.bmiHeader.biPlanes = 1;
            bmi.bmiHeader.biBitCount = 32;
            bmi.bmiHeader.biCompression = 0; // BI_RGB

            // Pull the bits from the bitmap into our array
            Gdi32.GetDIBits(memDc, bitmap, 0, (uint)height, pixels, ref bmi, 0);

            return pixels;
        }

        public void Present(nint windowHandle)
        {
            throw new NotImplementedException();
        }
    }

#endif

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
        IntPtr CreateShaderModule(byte[] spirvBytecode);
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
    
    // Factory for creating platform-specific graphics contexts
    public static class GraphicsContextFactory
    {
        public static unsafe IGraphicsContext Create(object windowHandle, int width, int height, int renderMode, IntPtr existingDevice = default, IntPtr existingContext = default, VkPipelineShaderStageCreateInfo[] shaderStages = null)
        {
            if (renderMode == 0)
#if WINDOWS
                return new GdiGraphicsContext(((MicrosoftWindowHandle)windowHandle).Hwnd, width, height);
#else
                throw new Exceptions.FailedToCreateGraphicsBackendException("GDI is only supported on Windows.");
#endif
            if (renderMode == 2)
#if WINDOWS
                return new DX11GraphicsContext(((MicrosoftWindowHandle)windowHandle).Hwnd, width, height, existingDevice, existingContext);
#else
                throw new Exceptions.FailedToCreateGraphicsBackendException("DirectX11 is only supported on Windows.");
#endif
            if (renderMode == 1)
                throw new Exceptions.FailedToCreateGraphicsBackendException("There currently is not an IGraphicsContext definition for OpenGL.");
            if (renderMode == 3)
            {
                return new VkGraphicsContext(((X11WindowHandle)windowHandle).Window, ((X11WindowHandle)windowHandle).Display, width, height, existingDevice, existingContext, shaderStages);
            }

            Common.Logger.LogCritical(
                "[GraphicsContextFactory] Failed to create IGraphicsContext, 'Graphics.RenderMode' is not a possible value.",
                Common.LoggingTarget.Graphics,
                new Exceptions.FailedToCreateGraphicsBackendException("[GraphicsContextFactory] Failed to create IGraphicsContext, 'Graphics.RenderMode' is not a possible value."),
                true
            );
            return null;
        }
        
        public static IGraphicsContext CreateWS(string windowHandle, int width, int height)
        {
#if WINDOWS
            return new WSGraphicsContext(windowHandle, width, height);
#else
            throw new Exceptions.FailedToCreateGraphicsBackendException("WebSocket graphics context is only supported on Windows.");
#endif
        }
    }
}