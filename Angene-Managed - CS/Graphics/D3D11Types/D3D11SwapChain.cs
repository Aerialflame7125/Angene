using System;

namespace Angene.Graphics.D3D11Types
{
    internal sealed class D3D11SwapChain
    {
        // make swap chain nullable so it can be released/cleared
        public IDXGISwapChain? SwapChain { get; private set; }

        // RenderTargetView must be a field if you pass it by ref
        public IntPtr RenderTargetView;

        private readonly D3D11Device _device;
        private readonly IntPtr _hwnd;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public D3D11SwapChain(D3D11Device device, IntPtr hwnd, int width, int height)
        {
            _device = device;
            _hwnd = hwnd;
            Width = width;
            Height = height;

            CreateSwapChain();
            CreateRenderTarget();
        }

        private void CreateSwapChain()
        {
            var desc = new DXGI_SWAP_CHAIN_DESC
            {
                BufferCount = 1,
                BufferUsage = (uint)DXGI_USAGE.RENDER_TARGET_OUTPUT,
                OutputWindow = _hwnd,
                Windowed = true,
                SwapEffect = DXGI_SWAP_EFFECT.DISCARD,
                BufferDesc = new DXGI_MODE_DESC
                {
                    Width = (uint)Width,
                    Height = (uint)Height,
                    Format = DXGI_FORMAT.R8G8B8A8_UNORM,
                    RefreshRateNumerator = 60,
                    RefreshRateDenominator = 1,
                    ScanlineOrdering = 0,
                    Scaling = 0
                },
                SampleDesc = new DXGI_SAMPLE_DESC { Count = 1, Quality = 0 }
            };

            var guid = typeof(IDXGIFactory).GUID;
            D3D11Interop.CreateDXGIFactory(ref guid, out var factory);
            factory.CreateSwapChain(_device.Device, ref desc, out var sc);

            SwapChain = sc;
        }

        private void CreateRenderTarget()
        {
            Guid texGuid = new("6f15aaf2-d208-4e89-9ab4-489535d34f9c"); // ID3D11Texture2D
            SwapChain!.GetBuffer(0, ref texGuid, out var backBuffer);

            _device.Device.CreateRenderTargetView(backBuffer, IntPtr.Zero, out var rtv);
            RenderTargetView = rtv;

            // pass ref to the field (allowed)
            _device.Context.OMSetRenderTargets(1, ref RenderTargetView, IntPtr.Zero);
        }

        public void Resize(int width, int height)
        {
            Width = width;
            Height = height;

            // reset field
            RenderTargetView = IntPtr.Zero;

            // present and release previous swapchain (null-safe)
            SwapChain?.Present(0, 0);
            SwapChain = null;

            CreateSwapChain();
            CreateRenderTarget();
        }
    }
}
