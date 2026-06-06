using Angene.Common;
using Angene.Windows;
using Angene.Windows.Dxgi;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using static Angene.Windows.D3D11;

namespace Angene.Graphics.DX11
{
    public class DX11Graphics : IGraphicsContext
    {
        private IntPtr _hwnd;
        private int _w, _h;

        // D3D11 COM objects
        private IntPtr _device;           // ID3D11Device
        private IntPtr _context;          // ID3D11DeviceContext
        private IntPtr _swapChain;        // IDXGISwapChain
        private IntPtr _renderTargetView; // ID3D11RenderTargetView
        private IntPtr _depthStencilView; // ID3D11DepthStencilView

        public nint Handle => throw new NotImplementedException();
        public DX11Graphics(int x, int y, int w, int h, IntPtr hwnd)
        {
            this.hwnd = hwnd;
            this.w = w;
            this.h = h;

            IntPtr Hdc = User32.GetDC(hwnd);
            try
            {
                InitializeD3D11();
                CreateSwapChain();
                CreateRenderTargetView();
                CreateDepthStencilView();
                SetViewport();
            }
            catch (Exception ex)
            {
                Logger.LogCritical($"[D3D11] Initialization failed: {ex.Message}", LoggingTarget.Engine, ex);
                throw;
            }
        }
        
        private void InitializeD3D11() // Initializer
        {
            D3D11.D3D_FEATURE_LEVEL[] LevelsToTry = new[] // different d3d levels to try in order of preference
            {
                D3D11.D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_0,
                D3D11.D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_10_1,
                D3D11.D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_10_0
            };

            uint deviceFlags = 0;

            int func = D3D11.D3D11CreateDevice(
                IntPtr.Zero, // pAdapter (default)
                D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_HARDWARE, // DriverType
                IntPtr.Zero, // Software
                deviceFlags, // Flags
                LevelsToTry, // pFeatureLevels
                (uint)LevelsToTry.Length, // FeatureLevels
                7, // SDKVersion
                out _device, // ppDevice
                out D3D_FEATURE_LEVEL outLevel, // pFeatureLevel
                out _context // ppImmediateContext
            );

            if (func < 0)
                Logger.LogCritical($"[D3D11] Device creation FAILED with HResult '{func:X8}'", LoggingTarget.Graphics, new Exceptions.FailedToCreateGraphicsBackendException("Failed to create D3D11 Device."), false);

            Logger.LogInfo($"[D3D11] Device creation finished, Featurelevel 0x{func:X8}", LoggingTarget.Engine);
        }
        private void CreateSwapChain()
        {
            // dxgi factory
            IntPtr fact = IntPtr.Zero; 
            int hresult = D3D11.CreateDXGIFactory(out fact);

            if (hresult < 0)
                Logger.LogCritical("[D3D11] DXGI Factory creation FAILED with HResult '{func:X8}'", LoggingTarget.Graphics, new Exceptions.FailedToCreateGraphicsBackendException("Failed to create DXGI Factory."), false);
            try
            {
                // swap chain description
                DXGI_SWAP_CHAIN_DESC swapDesc = new DXGI_SWAP_CHAIN_DESC
                {
                    BufferDesc = new DXGI_MODE_DESC
                    {
                        Width = (uint)_w,
                        Height = (uint)_h,
                        RefreshRate_Numerator = 60, // For now
                        RefreshRate_Denominator = 1,
                        Format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM
                    },
                    SampleDesc = new DXGI_SAMPLE_DESC
                    {
                        Count = 1,
                        Quality = 0
                    },
                    BufferUsage = DXGI_USAGE.DXGI_USAGE_RENDER_TARGET_OUTPUT,
                    BufferCount = 2,
                    OutputWindow = _hwnd,
                    Windowed = 1, // choice later,
                    SwapEffect = DXGI_SWAP_EFFECT.DXGI_SWAP_EFFECT_DISCARD,
                    Flags = 0
                };

                hresult = D3D11.CreateSwapChain(fact, _device, ref swapDesc, out _swapChain);

                if (hresult < 0)
                    Logger.LogCritical($"[D3D11] Failed to create SwapChain: 0x{hresult:X8}", LoggingTarget.Graphics, new Exceptions.FailedToCreateGraphicsBackendException("Failed to create D3D11 SwapChain"), false);

                Logger.LogInfo("[D3D11] Created new SwapChain", LoggingTarget.Graphics);
            }
            finally
            {
                Marshal.Release(fact);
            }
        }
        private void CreateRenderTargetView()
        {

        }
        private void CreateDepthStencilView()
        {

        }
        private void SetViewport()
        {

        }

        public void Cleanup()
        {
            throw new NotImplementedException();
        }

        public void Clear(uint color)
        {
            throw new NotImplementedException();
        }

        public byte[] GetRawPixels()
        {
            throw new NotImplementedException();
        }

        public void Present(nint windowHandle)
        {
            throw new NotImplementedException();
        }
    }
}