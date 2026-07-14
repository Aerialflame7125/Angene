using Angene.Common;
using Angene.Windows;
using Angene.Windows.D3D11;
using Angene.Windows.Dxgi;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;
using static Angene.Windows.D3D11.D3D11;

namespace Angene.Graphics.DX11
{
    public class DX11GraphicsContext : IGraphicsContext
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
        public DX11GraphicsContext(IntPtr hwnd, int width, int height)
        {
            this._hwnd = hwnd;
            this._w = width;
            this._h = height;

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
                Logger.LogCritical($"[D3D11] DXGI Factory creation FAILED with HResult '{hresult:X8}'", LoggingTarget.Graphics, new Exceptions.FailedToCreateGraphicsBackendException("Failed to create DXGI Factory."), false);
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
            if (_swapChain == IntPtr.Zero)
                throw new Exceptions.GraphicsException("Swapchain is not initialized. Please initialize before calling 'CreateRenderTargetView'.");

            // back buffer from swapchain
            IntPtr backBuffer = IntPtr.Zero;
            int hr = GetSwapChainBackBuffer(_swapChain, 0, out backBuffer);

            if (hr < 0)
                throw new Exceptions.GraphicsException($"Failed to acquire back buffer from swapchain. (HRESULT {hr:X8})");
            else if (backBuffer == IntPtr.Zero)
                throw new Exceptions.GraphicsException("Failed to acquire back buffer from swapchain. (backBuffer is Zero.)");

            try
            {
                // RTV from back buffer texture
                hr = D3D11.CreateRenderTargetView(_device, backBuffer, IntPtr.Zero /* null descriptor */, out _renderTargetView);

                if (hr < 0)
                    throw new Exceptions.GraphicsException($"Failed to create render target view. (HRESULT {hr:X8})");

                Logger.LogDebug("[D3D11] Render target view created.", LoggingTarget.Graphics);
            }
            finally
            {
                Marshal.Release(backBuffer);
            }
        }
        private void CreateDepthStencilView()
        {
            D3D11.D3D11_TEXTURE2D_DESC depthDesc = new D3D11_TEXTURE2D_DESC
            {
                Width = (uint)_w,
                Height = (uint)_h,
                MipLevels = 1,
                ArraySize = 1,
                Format = DXGI_FORMAT.DXGI_FORMAT_D24_UNORM_S8_UINT,
                SampleDesc = new DXGI_SAMPLE_DESC { Count = 1, Quality = 0 },
                Usage = D3D11_USAGE.D3D11_USAGE_DEFAULT,
                BindFlags = D3D11_BIND_FLAG.D3D11_BIND_DEPTH_STENCIL,
                CPUAccessFlags = 0,
                MiscFlags = 0
            };

            IntPtr depthTexture = IntPtr.Zero;
            int hr = D3D11.CreateTexture2D(_device, ref depthDesc, IntPtr.Zero, out depthTexture);

            if (hr < 0)
            {
                Logger.LogWarning("[D3D11] Failed to create depth stencil texture (continuing without it)", LoggingTarget.Graphics);
                return;
            }

            try
            {
                hr = D3D11.CreateDepthStencilView(_device, depthTexture, IntPtr.Zero, out _depthStencilView);

                if (hr >= 0)
                    Logger.LogDebug("[D3D11] Depth stencil view created", LoggingTarget.Graphics);
                else
                    Logger.LogWarning($"[D3D11] Failed to create depth stencil view. ({hr:X8})", LoggingTarget.Graphics);
            }
            finally
            {
                Marshal.Release(depthTexture);
            }
        }
        private void SetViewport()
        {
            if (_context == IntPtr.Zero)
                return;

            D3D11_VIEWPORT viewport = new D3D11_VIEWPORT
            {
                TopLeftX = 0,
                TopLeftY = 0,
                Width = _w,
                Height = _h,
                MinDepth = 0.0f,
                MaxDepth = 1.0f
            };

            SetViewports(_context, 1, ref viewport);
        }

        public void Clear(uint color)
        {
            if (_context == IntPtr.Zero || _renderTargetView == IntPtr.Zero)
                return;

            float r = ((color >> 16) & 0xFF) / 255.0f;
            float g = ((color >> 8) & 0xFF) / 255.0f;
            float b = (color & 0xFF) / 255.0f;
            float a = ((color >> 24) & 0xFF) / 255.0f;

            ClearRenderTargetView(_context, _renderTargetView, r, g, b, a);

            if (_depthStencilView != IntPtr.Zero)
            {
                ClearDepthStencilView(_context, _depthStencilView, DxgiConstants.D3D11_CLEAR_DEPTH, 1.0f, 0);
            }
        }

        private static void ReleaseComObject(ref IntPtr obj)
        {
            if (obj != IntPtr.Zero)
            {
                try
                {
                    Marshal.Release(obj);
                }
                catch (Exception ex)
                {
                    Logger.LogDebug("Caught error when releasing COM object from DX11. '{ex}'", LoggingTarget.Graphics);
                }
                finally
                {
                    obj = IntPtr.Zero;
                }
            }
        }

        public void Present(nint windowHandle)
        {
            if (_swapChain == IntPtr.Zero)
                return;

            int hr = PresentSwapChain(_swapChain, 1, 0);
            if (hr < 0)
            {
                Logger.LogWarning($"[D3D11] Present failed with HRESULT 0x{hr:X8}", LoggingTarget.Graphics);
            }
        }

        public byte[] GetRawPixels()
        {
            // texture readback from render target needed here
            return new byte[0];
        }

        public void Cleanup()
        {
            ReleaseComObject(ref _renderTargetView);
            ReleaseComObject(ref _depthStencilView);
            ReleaseComObject(ref _swapChain);
            ReleaseComObject(ref _context);
            ReleaseComObject(ref _device);

            Logger.LogInfo("[D3D11] Cleaned up device context.", LoggingTarget.Engine);
        }

        public void Dispose()
        {
            Cleanup();
        }
    }
}