using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angene.Graphics.Dxgi
{
    public class GraphicsContext : IGraphicsContext
    {
        private ID3D11Device _device;
        private ID3D11DeviceContext _deviceContext;
        private IDXGISwapChain _swapchain;
        private ID3D11RenderTargetView _rtv;
        private ID3D11DepthStencilView _dsv;

        public IntPtr Handle { get; } // Can return device pointer or hwnd

        public void Clear(uint color)
        {

        }
        
        public void Present(IntPtr windowHandle)
        {

        }
        
        public void Cleanup()
        {

        }
        
        public byte[] GetRawPixels()
        {

        }
    }
}
