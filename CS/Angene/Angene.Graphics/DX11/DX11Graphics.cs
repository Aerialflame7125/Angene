#if WINDOWS
using Angene.Common;
using Angene.Graphics.SlangShader;
using Angene.Windows;
using Angene.Windows.D3D11;
using Angene.Windows.Dxgi;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;
using static Angene.Windows.D3D11.D3D11;
using static Angene.Windows.D3D11.D3D11Interop;
using static Angene.Windows.Dxgi.DxgiEnums;

namespace Angene.Graphics.DX11
{
    public class DX11GraphicsContext : IDX11GraphicsContext, IGraphicsContext
    {
        private IntPtr _hwnd;
        private int _w, _h;

        // D3D11 COM objects
        private IntPtr _device;           // ID3D11Device
        private IntPtr _context;          // ID3D11DeviceContext
        private IntPtr _swapChain;        // IDXGISwapChain
        private IntPtr _renderTargetView; // ID3D11RenderTargetView
        private IntPtr _depthStencilView; // ID3D11DepthStencilView

        private IntPtr _existingDevice, _existingContext;
        private bool _sharingDevice = false;
        public IntPtr ContextHandle => _context;

        public IntPtr Handle => _device;

        public DX11GraphicsContext(IntPtr hwnd, int width, int height, IntPtr existingDevice, IntPtr existingContext)
        {
            this._hwnd = hwnd;
            this._w = width;
            this._h = height;
            _existingContext = (IntPtr)existingContext;
            _existingDevice = (IntPtr)existingDevice;

            IntPtr Hdc = User32.GetDC(hwnd);
            try
            {
                if (existingDevice != IntPtr.Zero && existingContext != IntPtr.Zero)
                {
                    _device = (IntPtr)existingDevice;
                    _context = (IntPtr)existingContext;
                    Marshal.AddRef(_device);
                    Marshal.AddRef(_context);
                    _sharingDevice = true;
                }
                else
                {
                    InitializeD3D11();
                }
                CreateSwapChain();
                CreateRenderTargetView();
                CreateDepthStencilView();
                OMSetRenderTargets(_context, 1, _renderTargetView, _depthStencilView);
                SetViewport();
            }
            catch (Exception ex)
            {
                Logger.LogCritical($"[D3D11] Initialization failed: {ex.Message}", LoggingTarget.Engine, ex);
                throw;
            }
        }

        private IntPtr _stagingTexture;

        private void CreateStagingTexture()
        {
            ReleaseComObject(ref _stagingTexture);

            var desc = new D3D11Interop.D3D11_TEXTURE2D_DESC
            {
                Width = (uint)_w,
                Height = (uint)_h,
                MipLevels = 1,
                ArraySize = 1,
                Format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM, // must match swap chain's back buffer format
                SampleDesc = new DXGI_SAMPLE_DESC { Count = 1, Quality = 0 },
                Usage = D3D11_USAGE.D3D11_USAGE_STAGING,
                BindFlags = 0,
                CPUAccessFlags = (uint)D3D11_CPU_ACCESS_FLAG.D3D11_CPU_ACCESS_READ,
                MiscFlags = 0
            };

            int hr = D3D11.CreateTexture2D(_device, ref desc, IntPtr.Zero, out _stagingTexture);
            if (hr < 0)
                Logger.LogWarning($"[D3D11] Failed to create staging texture for readback (HRESULT {hr:X8})", LoggingTarget.Graphics);
        }
        public void Resize(int width, int height)
        {
            if (_swapChain == IntPtr.Zero || width <= 0 || height <= 0)
                return;

            _w = width;
            _h = height;

            D3D11.OMSetRenderTargets(_context, 0, IntPtr.Zero, IntPtr.Zero);

            ReleaseComObject(ref _renderTargetView);
            ReleaseComObject(ref _depthStencilView);

            int hr = D3D11.ResizeSwapChainBuffers(
                _swapChain,
                2,
                (uint)_w,
                (uint)_h,
                DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM,
                0);

            if (hr < 0)
            {
                Logger.LogCritical($"[D3D11] ResizeBuffers failed with HRESULT 0x{hr:X8}", LoggingTarget.Graphics,
                    new Exceptions.GraphicsException("Failed to resize D3D11 swap chain buffers."), false);
                return;
            }

            CreateRenderTargetView();

            CreateDepthStencilView();

            OMSetRenderTargets(_context, 1, _renderTargetView, _depthStencilView);
            SetViewport();
            CreateStagingTexture();

            Logger.LogInfo($"[D3D11] Resized swap chain to {_w}x{_h}", LoggingTarget.Graphics);
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

            Logger.LogInfo($"[D3D11] Device creation finished, Featurelevel '{outLevel}'", LoggingTarget.Engine);
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
                    SwapEffect = DXGI_SWAP_EFFECT.DXGI_SWAP_EFFECT_FLIP_DISCARD,
                    OutputWindow = _hwnd,
                    Windowed = 1, // choice later,
                    Flags = 0
                };

                hresult = D3D11.CreateSwapChain(fact, _device, ref swapDesc, out _swapChain);

                if (hresult < 0)
                {
                    Logger.LogCritical($"[D3D11] Failed to create SwapChain: 0x{hresult:X8}", LoggingTarget.Graphics, new Exceptions.FailedToCreateGraphicsBackendException("Failed to create D3D11 SwapChain"), true);
                    return;
                }

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
            D3D11_TEXTURE2D_DESC depthDesc = new D3D11_TEXTURE2D_DESC
            {
                Width = (uint)_w,
                Height = (uint)_h,
                MipLevels = 1,
                ArraySize = 1,
                Format = DXGI_FORMAT.DXGI_FORMAT_D24_UNORM_S8_UINT,
                SampleDesc = new DXGI_SAMPLE_DESC { Count = 1, Quality = 0 },
                Usage = D3D11_USAGE.D3D11_USAGE_DEFAULT,
                BindFlags = (uint)D3D11_BIND_FLAG.D3D11_BIND_DEPTH_STENCIL,
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
            CreateStagingTexture();
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
            if (_stagingTexture == IntPtr.Zero || _swapChain == IntPtr.Zero)
                return new byte[0];

            IntPtr backBuffer = IntPtr.Zero;
            int hr = D3D11.GetSwapChainBackBuffer(_swapChain, 0, out backBuffer);
            if (hr < 0 || backBuffer == IntPtr.Zero)
            {
                Logger.LogWarning("[D3D11] GetRawPixels: failed to acquire back buffer", LoggingTarget.Graphics);
                return new byte[0];
            }

            try
            {
                D3D11.CopyResource(_context, _stagingTexture, backBuffer);

                hr = D3D11.Map(_context, _stagingTexture, 0, D3D11.D3D11_MAP.D3D11_MAP_READ, 0, out D3D11_MAPPED_SUBRESOURCE mapped);
                if (hr < 0)
                {
                    Logger.LogWarning($"[D3D11] GetRawPixels: Map failed (HRESULT {hr:X8})", LoggingTarget.Graphics);
                    return new byte[0];
                }

                try
                {
                    int rowBytes = _w * 4; // BGRA32
                    byte[] pixels = new byte[rowBytes * _h];

                    // RowPitch can be larger than rowBytes due to GPU alignment padding — copy row by row.
                    for (int y = 0; y < _h; y++)
                    {
                        IntPtr srcRow = IntPtr.Add(mapped.pData, y * (int)mapped.RowPitch);
                        Marshal.Copy(srcRow, pixels, y * rowBytes, rowBytes);
                    }

                    return pixels;
                }
                finally
                {
                    D3D11.Unmap(_context, _stagingTexture, 0);
                }
            }
            finally
            {
                Marshal.Release(backBuffer);
            }
        }
        public void Cleanup()
        {
            ReleaseComObject(ref _renderTargetView);
            ReleaseComObject(ref _depthStencilView);
            ReleaseComObject(ref _swapChain);
            ReleaseComObject(ref _context);
            ReleaseComObject(ref _device);
            ReleaseComObject(ref _stagingTexture);

            Logger.LogInfo("[D3D11] Cleaned up device context.", LoggingTarget.Engine);
        }
        public void Dispose()
        {
            Cleanup();
        }
        public IntPtr CreateVertexBuffer(byte[] data, uint strideBytes)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                var desc = new D3D11.D3D11_BUFFER_DESC
                {
                    ByteWidth = (uint)data.Length,
                    Usage = D3D11_USAGE.D3D11_USAGE_DEFAULT,
                    BindFlags = (uint)D3D11_BIND_FLAG.D3D11_BIND_VERTEX_BUFFER,
                    CPUAccessFlags = 0,
                    MiscFlags = 0,
                    StructureByteStride = 0
                };
                var initData = new D3D11.D3D11_SUBRESOURCE_DATA { pSysMem = handle.AddrOfPinnedObject() };

                int hr = D3D11.CreateBuffer(_device, ref desc, ref initData, out IntPtr buffer);
                if (hr < 0)
                    Logger.LogWarning($"[D3D11] CreateVertexBuffer failed (HRESULT {hr:X8})", LoggingTarget.Graphics);
                return buffer;
            }
            finally
            {
                handle.Free();
            }
        }
        public IntPtr CreateVertexShader(byte[] bytecode)
        {
            var handle = GCHandle.Alloc(bytecode, GCHandleType.Pinned);
            try
            {
                int hr = D3D11.CreateVertexShader(_device, handle.AddrOfPinnedObject(), (nuint)bytecode.Length, out IntPtr shader);
                if (hr < 0)
                    Logger.LogWarning($"[D3D11] CreateVertexShader failed (HRESULT {hr:X8})", LoggingTarget.Graphics);
                return shader;
            }
            finally { handle.Free(); }
        }
        public IntPtr CreatePixelShader(byte[] bytecode)
        {
            var handle = GCHandle.Alloc(bytecode, GCHandleType.Pinned);
            try
            {
                int hr = D3D11.CreatePixelShader(_device, handle.AddrOfPinnedObject(), (nuint)bytecode.Length, out IntPtr shader);
                if (hr < 0)
                    Logger.LogWarning($"[D3D11] CreatePixelShader failed (HRESULT {hr:X8})", LoggingTarget.Graphics);
                return shader;
            }
            finally { handle.Free(); }
        }
        public IntPtr CreateInputLayout(InputElement[] elements, byte[] vsBytecode)
        {
            int structSize = Marshal.SizeOf<D3D11.D3D11_INPUT_ELEMENT_DESC>();
            IntPtr descArray = Marshal.AllocHGlobal(structSize * elements.Length);
            var nameHandles = new List<IntPtr>();
            var vsHandle = GCHandle.Alloc(vsBytecode, GCHandleType.Pinned);

            try
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    IntPtr namePtr = Marshal.StringToHGlobalAnsi(elements[i].SemanticName);
                    nameHandles.Add(namePtr);

                    var desc = new D3D11.D3D11_INPUT_ELEMENT_DESC
                    {
                        SemanticName = namePtr,
                        SemanticIndex = elements[i].SemanticIndex,
                        Format = elements[i].Format,
                        InputSlot = 0,
                        AlignedByteOffset = elements[i].ByteOffset,
                        InputSlotClass = 0, // D3D11_INPUT_PER_VERTEX_DATA
                        InstanceDataStepRate = 0
                    };
                    Marshal.StructureToPtr(desc, IntPtr.Add(descArray, i * structSize), false);
                }

                int hr = D3D11.CreateInputLayout(_device, descArray, (uint)elements.Length,
                    vsHandle.AddrOfPinnedObject(), (nuint)vsBytecode.Length, out IntPtr layout);

                if (hr < 0)
                    Logger.LogWarning($"[D3D11] CreateInputLayout failed (HRESULT {hr:X8})", LoggingTarget.Graphics);

                return layout;
            }
            finally
            {
                vsHandle.Free();
                foreach (var h in nameHandles) Marshal.FreeHGlobal(h);
                Marshal.FreeHGlobal(descArray);
            }
        }
        
        public void SetVertexBuffer(IntPtr buffer, uint strideBytes, uint offset = 0)
            => D3D11.IASetVertexBuffers(_context, 0, buffer, strideBytes, offset);

        public void DrawIndexed(uint indexCount, uint startIndex = 0, int baseVertex = 0)
            => D3D11.DrawIndexed(_context, indexCount, startIndex, baseVertex);
        public IntPtr CreateIndexBuffer(uint[] indices)
        {
            var bytes = new byte[indices.Length * sizeof(uint)];
            Buffer.BlockCopy(indices, 0, bytes, 0, bytes.Length);
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                var desc = new D3D11.D3D11_BUFFER_DESC
                {
                    ByteWidth = (uint)bytes.Length,
                    Usage = D3D11_USAGE.D3D11_USAGE_DEFAULT,
                    BindFlags = (uint)D3D11_BIND_FLAG.D3D11_BIND_INDEX_BUFFER,
                    CPUAccessFlags = 0,
                    MiscFlags = 0,
                    StructureByteStride = 0
                };
                var initData = new D3D11.D3D11_SUBRESOURCE_DATA { pSysMem = handle.AddrOfPinnedObject() };

                int hr = D3D11.CreateBuffer(_device, ref desc, ref initData, out IntPtr buffer);
                if (hr < 0)
                    Logger.LogWarning($"[D3D11] CreateIndexBuffer failed (HRESULT {hr:X8})", LoggingTarget.Graphics);
                return buffer;
            }
            finally
            {
                handle.Free();
            }
        }

        public void SetIndexBuffer(IntPtr buffer, uint offset = 0)
            => D3D11.IASetIndexBuffer(_context, buffer, DXGI_FORMAT.DXGI_FORMAT_R32_UINT, offset);

        public void SetInputLayout(IntPtr inputLayout)
        {
            D3D11.IASetInputLayout(_context, inputLayout);
            D3D11.IASetPrimitiveTopology(_context, 4); // D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST
        }

        private IntPtr _currentVertexShader;
        private IntPtr _currentPixelShader;

        public void SetShader(SlangShaderResources.IShader vs, SlangShaderResources.IShader ps)
        {
            // Requires Dx11Shader to expose its native shader pointer — see note below.
            if (vs is Dx11Shader dxVs)
            {
                _currentVertexShader = dxVs.NativeShader;
                D3D11.VSSetShader(_context, _currentVertexShader);
            }
            if (ps is Dx11Shader dxPs)
            {
                _currentPixelShader = dxPs.NativeShader;
                D3D11.PSSetShader(_context, _currentPixelShader);
            }
        }

        public void Draw(uint vertexCount, uint startVertex = 0)
            => D3D11.Draw(_context, vertexCount, startVertex);

        public IntPtr CreateConstantBuffer(uint byteWidth)
        {
            // Constant buffers must be 16-byte aligned.
            uint alignedSize = (byteWidth + 15) & ~15u;
            byte[] zero = new byte[alignedSize]; // CreateBuffer always wants non-null initial data in our wrapper
            var handle = GCHandle.Alloc(zero, GCHandleType.Pinned);
            try
            {
                var desc = new D3D11.D3D11_BUFFER_DESC
                {
                    ByteWidth = alignedSize,
                    Usage = D3D11_USAGE.D3D11_USAGE_DYNAMIC,
                    BindFlags = (uint)D3D11_BIND_FLAG.D3D11_BIND_CONSTANT_BUFFER,
                    CPUAccessFlags = (uint)D3D11_CPU_ACCESS_FLAG.D3D11_CPU_ACCESS_WRITE,
                    MiscFlags = 0,
                    StructureByteStride = 0
                };
                var initData = new D3D11.D3D11_SUBRESOURCE_DATA { pSysMem = handle.AddrOfPinnedObject() };

                int hr = D3D11.CreateBuffer(_device, ref desc, ref initData, out IntPtr buffer);
                if (hr < 0)
                    Logger.LogWarning($"[D3D11] CreateConstantBuffer failed (HRESULT {hr:X8})", LoggingTarget.Graphics);
                return buffer;
            }
            finally { handle.Free(); }
        }

        public void UpdateConstantBuffer(IntPtr buffer, byte[] data)
        {
            int hr = D3D11.Map(_context, buffer, 0, D3D11.D3D11_MAP.D3D11_MAP_WRITE_DISCARD, 0, out D3D11_MAPPED_SUBRESOURCE mapped);
            if (hr < 0)
            {
                Logger.LogWarning($"[D3D11] UpdateConstantBuffer: Map failed (HRESULT {hr:X8})", LoggingTarget.Graphics);
                return;
            }
            Marshal.Copy(data, 0, mapped.pData, data.Length);
            D3D11.Unmap(_context, buffer, 0);
        }

        public void SetVertexShaderConstantBuffer(IntPtr buffer, uint slot = 0)
            => D3D11.VSSetConstantBuffers(_context, slot, buffer);

        public IntPtr CreateRasterizerState(bool cullNone)
        {
            var desc = new D3D11.D3D11_RASTERIZER_DESC
            {
                FillMode = 3, // D3D11_FILL_SOLID
                CullMode = cullNone ? 1u : 3u, // NONE : BACK
                FrontCounterClockwise = 0,
                DepthClipEnable = 1,
            };
            int hr = D3D11.CreateRasterizerState(_device, ref desc, out IntPtr state);
            if (hr < 0)
                Logger.LogWarning($"[D3D11] CreateRasterizerState failed (HRESULT {hr:X8})", LoggingTarget.Graphics);
            return state;
        }

        public void SetRasterizerState(IntPtr state) => D3D11.RSSetState(_context, state);

        public void BeginFrame(uint clearColor)
        {
            if (_context == IntPtr.Zero || _renderTargetView == IntPtr.Zero)
                return;

            OMSetRenderTargets(_context, 1, _renderTargetView, _depthStencilView);

            var viewport = new D3D11_VIEWPORT
            {
                TopLeftX = 0,
                TopLeftY = 0,
                Width = _w,
                Height = _h,
                MinDepth = 0.0f,
                MaxDepth = 1.0f
            };

            SetViewports(_context, 1, ref viewport);
            Clear(clearColor);
        }

        public void Render(
            SlangShaderResources.IShader vertexShader,
            SlangShaderResources.IShader pixelShader,
            IntPtr inputLayout,
            IntPtr vertexBuffer,
            uint vertexStride,
            uint vertexCount)
        {
            ArgumentNullException.ThrowIfNull(vertexShader);
            ArgumentNullException.ThrowIfNull(pixelShader);

            SetVertexBuffer(vertexBuffer, vertexStride);
            SetInputLayout(inputLayout);
            SetShader(vertexShader, pixelShader);
            Draw(vertexCount);
        }

        public void EndFrame() => Present(_hwnd);
    }
}
#endif