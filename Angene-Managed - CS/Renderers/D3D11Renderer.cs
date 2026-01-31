using System;
using Angene.Globals;
using Angene.Renderers.D3D11Types;

namespace Angene.Renderers
{
    public sealed class D3D11Renderer : IRenderer
    {
        private readonly D3D11Device _device;
        private readonly D3D11SwapChain _swapChain;

        // Proper constructor; readonly fields assigned here.
        public D3D11Renderer(IntPtr hwnd, int width, int height)
        {
            _device = new D3D11Device();
            _swapChain = new D3D11SwapChain(_device, hwnd, width, height);
        }

        public void BeginFrame(int width, int height)
        {
            if (width != _swapChain.Width || height != _swapChain.Height)
                _swapChain.Resize(width, height);
        }

        public void Clear(float r, float g, float b, float a)
        {
            _device.Context.ClearRenderTargetView(
                _swapChain.RenderTargetView,
                new[] { r, g, b, a }
            );
        }

        // These 2D helpers required by the IRenderer interface.
        // No-op implementations for a 3D renderer.
        public void DrawRect(float x, float y, float w, float h, uint color) { /* no-op for D3D renderer */ }
        public void DrawText(float x, float y, string text, uint color) { /* no-op for D3D renderer */ }

        public void EndFrame()
        {
            // Guard against null swapchain; the null-forgiving operator avoids "possibly null" warning
            _swapChain.SwapChain!.Present(1, 0);
        }

        public void Dispose()
        {
            // cleanup if needed (device / swapchain expose their own cleanup if necessary)
        }
    }
}
