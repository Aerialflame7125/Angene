

using Angene.Graphics.DX11;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static Angene.Windows.D3D11.D3D11;
using static Angene.Windows.D3D11.D3D11Interop;

namespace Angene.Windows.D3D11
{
    public class D3D11Interop
    {
        public partial struct D3D11_BOX
        {
            public uint left;

            public uint top;

            public uint front;

            public uint right;

            public uint bottom;

            public uint back;
        }
        [Guid("DA6FEA51-564C-4487-9810-F0D0F9B4E3A5")]
        [NativeTypeName("struct ID3D11SamplerState : ID3D11DeviceChild")]
        public unsafe partial struct ID3D11SamplerState
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11SamplerState*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11SamplerState*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11SamplerState*, uint>)(lpVtbl[1]))((ID3D11SamplerState*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11SamplerState*, uint>)(lpVtbl[2]))((ID3D11SamplerState*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11SamplerState*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11SamplerState*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11SamplerState*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11SamplerState*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11SamplerState*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11SamplerState*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11SamplerState*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11SamplerState*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public void GetDesc(D3D11_SAMPLER_DESC* pDesc)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11SamplerState*, D3D11_SAMPLER_DESC*, void>)(lpVtbl[7]))((ID3D11SamplerState*)Unsafe.AsPointer(ref this), pDesc);
            }
        }
        [Guid("B0E06FE0-8192-4E1A-B1CA-36D7414710B2")]
        [NativeTypeName("struct ID3D11ShaderResourceView : ID3D11View")]
        public unsafe partial struct ID3D11ShaderResourceView
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ShaderResourceView*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11ShaderResourceView*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ShaderResourceView*, uint>)(lpVtbl[1]))((ID3D11ShaderResourceView*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ShaderResourceView*, uint>)(lpVtbl[2]))((ID3D11ShaderResourceView*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11ShaderResourceView*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11ShaderResourceView*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ShaderResourceView*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11ShaderResourceView*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ShaderResourceView*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11ShaderResourceView*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ShaderResourceView*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11ShaderResourceView*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public void GetResource(ID3D11Resource** ppResource)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11ShaderResourceView*, ID3D11Resource**, void>)(lpVtbl[7]))((ID3D11ShaderResourceView*)Unsafe.AsPointer(ref this), ppResource);
            }

            public void GetDesc(D3D11_SHADER_RESOURCE_VIEW_DESC* pDesc)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11ShaderResourceView*, D3D11_SHADER_RESOURCE_VIEW_DESC*, void>)(lpVtbl[8]))((ID3D11ShaderResourceView*)Unsafe.AsPointer(ref this), pDesc);
            }
        }
        [Guid("DC8E63F3-D12B-4952-B47B-5E45026A862D")]
        [NativeTypeName("struct ID3D11Resource : ID3D11DeviceChild")]
        public unsafe partial struct ID3D11Resource
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Resource*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11Resource*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Resource*, uint>)(lpVtbl[1]))((ID3D11Resource*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Resource*, uint>)(lpVtbl[2]))((ID3D11Resource*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Resource*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11Resource*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Resource*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11Resource*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Resource*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11Resource*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Resource*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11Resource*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public void GetType(D3D11_RESOURCE_DIMENSION* pResourceDimension)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Resource*, D3D11_RESOURCE_DIMENSION*, void>)(lpVtbl[7]))((ID3D11Resource*)Unsafe.AsPointer(ref this), pResourceDimension);
            }

            public void SetEvictionPriority(uint EvictionPriority)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Resource*, uint, void>)(lpVtbl[8]))((ID3D11Resource*)Unsafe.AsPointer(ref this), EvictionPriority);
            }

            public uint GetEvictionPriority()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Resource*, uint>)(lpVtbl[9]))((ID3D11Resource*)Unsafe.AsPointer(ref this));
            }
        }
        [Guid("48570B85-D1EE-4FCD-A250-EB350722B037")]
        [NativeTypeName("struct ID3D11Buffer : ID3D11Resource")]
        public unsafe partial struct ID3D11Buffer
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Buffer*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11Buffer*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Buffer*, uint>)(lpVtbl[1]))((ID3D11Buffer*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Buffer*, uint>)(lpVtbl[2]))((ID3D11Buffer*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Buffer*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11Buffer*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Buffer*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11Buffer*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Buffer*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11Buffer*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Buffer*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11Buffer*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public void GetType(D3D11_RESOURCE_DIMENSION* pResourceDimension)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Buffer*, D3D11_RESOURCE_DIMENSION*, void>)(lpVtbl[7]))((ID3D11Buffer*)Unsafe.AsPointer(ref this), pResourceDimension);
            }

            public void SetEvictionPriority(uint EvictionPriority)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Buffer*, uint, void>)(lpVtbl[8]))((ID3D11Buffer*)Unsafe.AsPointer(ref this), EvictionPriority);
            }

            public uint GetEvictionPriority()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Buffer*, uint>)(lpVtbl[9]))((ID3D11Buffer*)Unsafe.AsPointer(ref this));
            }

            public void GetDesc(D3D11_BUFFER_DESC* pDesc)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Buffer*, D3D11_BUFFER_DESC*, void>)(lpVtbl[10]))((ID3D11Buffer*)Unsafe.AsPointer(ref this), pDesc);
            }
        }
        [Guid("A6CD7FAA-B0B7-4A2F-9436-8662A65797CB")]
        [NativeTypeName("struct ID3D11ClassInstance : ID3D11DeviceChild")]
        public unsafe partial struct ID3D11ClassInstance
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ClassInstance*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11ClassInstance*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ClassInstance*, uint>)(lpVtbl[1]))((ID3D11ClassInstance*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ClassInstance*, uint>)(lpVtbl[2]))((ID3D11ClassInstance*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11ClassInstance*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11ClassInstance*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ClassInstance*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11ClassInstance*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ClassInstance*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11ClassInstance*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ClassInstance*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11ClassInstance*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public void GetClassLinkage(ID3D11ClassLinkage** ppLinkage)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11ClassInstance*, ID3D11ClassLinkage**, void>)(lpVtbl[7]))((ID3D11ClassInstance*)Unsafe.AsPointer(ref this), ppLinkage);
            }

            public void GetDesc(D3D11_CLASS_INSTANCE_DESC* pDesc)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11ClassInstance*, D3D11_CLASS_INSTANCE_DESC*, void>)(lpVtbl[8]))((ID3D11ClassInstance*)Unsafe.AsPointer(ref this), pDesc);
            }

            public void GetInstanceName([NativeTypeName("LPSTR")] sbyte* pInstanceName, [NativeTypeName("SIZE_T *")] nuint* pBufferLength)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11ClassInstance*, sbyte*, nuint*, void>)(lpVtbl[9]))((ID3D11ClassInstance*)Unsafe.AsPointer(ref this), pInstanceName, pBufferLength);
            }

            public void GetTypeName([NativeTypeName("LPSTR")] sbyte* pTypeName, [NativeTypeName("SIZE_T *")] nuint* pBufferLength)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11ClassInstance*, sbyte*, nuint*, void>)(lpVtbl[10]))((ID3D11ClassInstance*)Unsafe.AsPointer(ref this), pTypeName, pBufferLength);
            }
        }
        [Guid("4B35D0CD-1E15-4258-9C98-1B1333F6DD3B")]
        [NativeTypeName("struct ID3D11Asynchronous : ID3D11DeviceChild")]
        public unsafe partial struct ID3D11Asynchronous
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Asynchronous*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11Asynchronous*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Asynchronous*, uint>)(lpVtbl[1]))((ID3D11Asynchronous*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Asynchronous*, uint>)(lpVtbl[2]))((ID3D11Asynchronous*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Asynchronous*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11Asynchronous*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Asynchronous*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11Asynchronous*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Asynchronous*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11Asynchronous*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Asynchronous*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11Asynchronous*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public uint GetDataSize()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Asynchronous*, uint>)(lpVtbl[7]))((ID3D11Asynchronous*)Unsafe.AsPointer(ref this));
            }
        }
        [Guid("03823EFB-8D8F-4E1C-9AA2-F64BB2CBFDF1")]
        [NativeTypeName("struct ID3D11DepthStencilState : ID3D11DeviceChild")]
        public unsafe partial struct ID3D11DepthStencilState
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilState*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11DepthStencilState*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilState*, uint>)(lpVtbl[1]))((ID3D11DepthStencilState*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilState*, uint>)(lpVtbl[2]))((ID3D11DepthStencilState*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilState*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11DepthStencilState*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilState*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11DepthStencilState*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilState*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11DepthStencilState*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilState*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11DepthStencilState*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public void GetDesc(D3D11_DEPTH_STENCIL_DESC* pDesc)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilState*, D3D11_DEPTH_STENCIL_DESC*, void>)(lpVtbl[7]))((ID3D11DepthStencilState*)Unsafe.AsPointer(ref this), pDesc);
            }
        }
        [Guid("9FDAC92A-1876-48C3-AFAD-25B94F84A9B6")]
        [NativeTypeName("struct ID3D11DepthStencilView : ID3D11View")]
        public unsafe partial struct ID3D11DepthStencilView
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilView*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11DepthStencilView*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilView*, uint>)(lpVtbl[1]))((ID3D11DepthStencilView*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilView*, uint>)(lpVtbl[2]))((ID3D11DepthStencilView*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilView*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11DepthStencilView*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilView*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11DepthStencilView*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilView*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11DepthStencilView*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilView*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11DepthStencilView*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public void GetResource(ID3D11Resource** ppResource)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilView*, ID3D11Resource**, void>)(lpVtbl[7]))((ID3D11DepthStencilView*)Unsafe.AsPointer(ref this), ppResource);
            }

            public void GetDesc(D3D11_DEPTH_STENCIL_VIEW_DESC* pDesc)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11DepthStencilView*, D3D11_DEPTH_STENCIL_VIEW_DESC*, void>)(lpVtbl[8]))((ID3D11DepthStencilView*)Unsafe.AsPointer(ref this), pDesc);
            }
        }
        [Guid("4F5B196E-C2BD-495E-BD01-1FDED38E4969")]
        [NativeTypeName("struct ID3D11ComputeShader : ID3D11DeviceChild")]
        public unsafe partial struct ID3D11ComputeShader
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ComputeShader*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11ComputeShader*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ComputeShader*, uint>)(lpVtbl[1]))((ID3D11ComputeShader*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ComputeShader*, uint>)(lpVtbl[2]))((ID3D11ComputeShader*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11ComputeShader*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11ComputeShader*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ComputeShader*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11ComputeShader*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ComputeShader*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11ComputeShader*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ComputeShader*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11ComputeShader*)Unsafe.AsPointer(ref this), guid, pData);
            }
        }
        [Guid("A24BC4D1-769E-43F7-8013-98FF566C18E2")]
        [NativeTypeName("struct ID3D11CommandList : ID3D11DeviceChild")]
        public unsafe partial struct ID3D11CommandList
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11CommandList*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11CommandList*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11CommandList*, uint>)(lpVtbl[1]))((ID3D11CommandList*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11CommandList*, uint>)(lpVtbl[2]))((ID3D11CommandList*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11CommandList*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11CommandList*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11CommandList*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11CommandList*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11CommandList*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11CommandList*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11CommandList*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11CommandList*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public uint GetContextFlags()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11CommandList*, uint>)(lpVtbl[7]))((ID3D11CommandList*)Unsafe.AsPointer(ref this));
            }
        }
        [Guid("75B68FAA-347D-4159-8F45-A0640F01CD9A")]
        [NativeTypeName("struct ID3D11BlendState : ID3D11DeviceChild")]
        public unsafe partial struct ID3D11BlendState
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11BlendState*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11BlendState*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11BlendState*, uint>)(lpVtbl[1]))((ID3D11BlendState*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11BlendState*, uint>)(lpVtbl[2]))((ID3D11BlendState*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11BlendState*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11BlendState*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11BlendState*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11BlendState*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11BlendState*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11BlendState*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11BlendState*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11BlendState*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public void GetDesc(D3D11_BLEND_DESC* pDesc)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11BlendState*, D3D11_BLEND_DESC*, void>)(lpVtbl[7]))((ID3D11BlendState*)Unsafe.AsPointer(ref this), pDesc);
            }
        }
        [Guid("DDF57CBA-9543-46E4-A12B-F207A0FE7FED")]
        [NativeTypeName("struct ID3D11ClassLinkage : ID3D11DeviceChild")]
        public unsafe partial struct ID3D11ClassLinkage
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ClassLinkage*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11ClassLinkage*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ClassLinkage*, uint>)(lpVtbl[1]))((ID3D11ClassLinkage*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ClassLinkage*, uint>)(lpVtbl[2]))((ID3D11ClassLinkage*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11ClassLinkage*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11ClassLinkage*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ClassLinkage*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11ClassLinkage*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ClassLinkage*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11ClassLinkage*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ClassLinkage*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11ClassLinkage*)Unsafe.AsPointer(ref this), guid, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetClassInstance([NativeTypeName("LPCSTR")] sbyte* pClassInstanceName, uint InstanceIndex, ID3D11ClassInstance** ppInstance)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ClassLinkage*, sbyte*, uint, ID3D11ClassInstance**, int>)(lpVtbl[7]))((ID3D11ClassLinkage*)Unsafe.AsPointer(ref this), pClassInstanceName, InstanceIndex, ppInstance);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateClassInstance([NativeTypeName("LPCSTR")] sbyte* pClassTypeName, uint ConstantBufferOffset, uint ConstantVectorOffset, uint TextureOffset, uint SamplerOffset, ID3D11ClassInstance** ppInstance)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11ClassLinkage*, sbyte*, uint, uint, uint, uint, ID3D11ClassInstance**, int>)(lpVtbl[8]))((ID3D11ClassLinkage*)Unsafe.AsPointer(ref this), pClassTypeName, ConstantBufferOffset, ConstantVectorOffset, TextureOffset, SamplerOffset, ppInstance);
            }
        }
        [Guid("F582C508-0F36-490C-9977-31EECE268CFA")]
        [NativeTypeName("struct ID3D11DomainShader : ID3D11DeviceChild")]
        public unsafe partial struct ID3D11DomainShader
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DomainShader*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11DomainShader*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DomainShader*, uint>)(lpVtbl[1]))((ID3D11DomainShader*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DomainShader*, uint>)(lpVtbl[2]))((ID3D11DomainShader*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11DomainShader*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11DomainShader*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DomainShader*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11DomainShader*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DomainShader*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11DomainShader*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11DomainShader*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11DomainShader*)Unsafe.AsPointer(ref this), guid, pData);
            }
        }
        [Guid("38325B96-EFFB-4022-BA02-2E795B70275C")]
        [NativeTypeName("struct ID3D11GeometryShader : ID3D11DeviceChild")]
        public unsafe partial struct ID3D11GeometryShader
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11GeometryShader*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11GeometryShader*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11GeometryShader*, uint>)(lpVtbl[1]))((ID3D11GeometryShader*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11GeometryShader*, uint>)(lpVtbl[2]))((ID3D11GeometryShader*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11GeometryShader*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11GeometryShader*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11GeometryShader*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11GeometryShader*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11GeometryShader*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11GeometryShader*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11GeometryShader*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11GeometryShader*)Unsafe.AsPointer(ref this), guid, pData);
            }
        }
        [Guid("8E5C6061-628A-4C8E-8264-BBE45CB3D5DD")]
        [NativeTypeName("struct ID3D11HullShader : ID3D11DeviceChild")]
        public unsafe partial struct ID3D11HullShader
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11HullShader*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11HullShader*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11HullShader*, uint>)(lpVtbl[1]))((ID3D11HullShader*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11HullShader*, uint>)(lpVtbl[2]))((ID3D11HullShader*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11HullShader*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11HullShader*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11HullShader*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11HullShader*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11HullShader*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11HullShader*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11HullShader*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11HullShader*)Unsafe.AsPointer(ref this), guid, pData);
            }
        }
        [Guid("E4819DDC-4CF0-4025-BD26-5DE82A3E07B7")]
        [NativeTypeName("struct ID3D11InputLayout : ID3D11DeviceChild")]
        public unsafe partial struct ID3D11InputLayout
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11InputLayout*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11InputLayout*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11InputLayout*, uint>)(lpVtbl[1]))((ID3D11InputLayout*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11InputLayout*, uint>)(lpVtbl[2]))((ID3D11InputLayout*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11InputLayout*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11InputLayout*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11InputLayout*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11InputLayout*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11InputLayout*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11InputLayout*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11InputLayout*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11InputLayout*)Unsafe.AsPointer(ref this), guid, pData);
            }
        }
        [Guid("EA82E40D-51DC-4F33-93D4-DB7C9125AE8C")]
        [NativeTypeName("struct ID3D11PixelShader : ID3D11DeviceChild")]
        public unsafe partial struct ID3D11PixelShader
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11PixelShader*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11PixelShader*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11PixelShader*, uint>)(lpVtbl[1]))((ID3D11PixelShader*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11PixelShader*, uint>)(lpVtbl[2]))((ID3D11PixelShader*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11PixelShader*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11PixelShader*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11PixelShader*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11PixelShader*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11PixelShader*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11PixelShader*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11PixelShader*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11PixelShader*)Unsafe.AsPointer(ref this), guid, pData);
            }
        }
        [Guid("9EB576DD-9F77-4D86-81AA-8BAB5FE490E2")]
        [NativeTypeName("struct ID3D11Predicate : ID3D11Query")]
        public unsafe partial struct ID3D11Predicate
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Predicate*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11Predicate*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Predicate*, uint>)(lpVtbl[1]))((ID3D11Predicate*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Predicate*, uint>)(lpVtbl[2]))((ID3D11Predicate*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Predicate*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11Predicate*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Predicate*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11Predicate*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Predicate*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11Predicate*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Predicate*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11Predicate*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public uint GetDataSize()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Predicate*, uint>)(lpVtbl[7]))((ID3D11Predicate*)Unsafe.AsPointer(ref this));
            }

            public void GetDesc(D3D11_QUERY_DESC* pDesc)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Predicate*, D3D11_QUERY_DESC*, void>)(lpVtbl[8]))((ID3D11Predicate*)Unsafe.AsPointer(ref this), pDesc);
            }
        }
        [Guid("9BB4AB81-AB1A-4D8F-B506-FC04200B6EE7")]
        [NativeTypeName("struct ID3D11RasterizerState : ID3D11DeviceChild")]
        public unsafe partial struct ID3D11RasterizerState
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11RasterizerState*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11RasterizerState*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11RasterizerState*, uint>)(lpVtbl[1]))((ID3D11RasterizerState*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11RasterizerState*, uint>)(lpVtbl[2]))((ID3D11RasterizerState*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11RasterizerState*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11RasterizerState*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11RasterizerState*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11RasterizerState*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11RasterizerState*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11RasterizerState*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11RasterizerState*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11RasterizerState*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public void GetDesc(D3D11_RASTERIZER_DESC* pDesc)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11RasterizerState*, D3D11_RASTERIZER_DESC*, void>)(lpVtbl[7]))((ID3D11RasterizerState*)Unsafe.AsPointer(ref this), pDesc);
            }
        }
        [Guid("DFDBA067-0B8D-4865-875B-D7B4516CC164")]
        [NativeTypeName("struct ID3D11RenderTargetView : ID3D11View")]
        public unsafe partial struct ID3D11RenderTargetView
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11RenderTargetView*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11RenderTargetView*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11RenderTargetView*, uint>)(lpVtbl[1]))((ID3D11RenderTargetView*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11RenderTargetView*, uint>)(lpVtbl[2]))((ID3D11RenderTargetView*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11RenderTargetView*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11RenderTargetView*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11RenderTargetView*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11RenderTargetView*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11RenderTargetView*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11RenderTargetView*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11RenderTargetView*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11RenderTargetView*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public void GetResource(ID3D11Resource** ppResource)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11RenderTargetView*, ID3D11Resource**, void>)(lpVtbl[7]))((ID3D11RenderTargetView*)Unsafe.AsPointer(ref this), ppResource);
            }

            public void GetDesc(D3D11_RENDER_TARGET_VIEW_DESC* pDesc)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11RenderTargetView*, D3D11_RENDER_TARGET_VIEW_DESC*, void>)(lpVtbl[8]))((ID3D11RenderTargetView*)Unsafe.AsPointer(ref this), pDesc);
            }
        }
        [Guid("28ACF509-7F5C-48F6-8611-F316010A6380")]
        [NativeTypeName("struct ID3D11UnorderedAccessView : ID3D11View")]
        public unsafe partial struct ID3D11UnorderedAccessView
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11UnorderedAccessView*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11UnorderedAccessView*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11UnorderedAccessView*, uint>)(lpVtbl[1]))((ID3D11UnorderedAccessView*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11UnorderedAccessView*, uint>)(lpVtbl[2]))((ID3D11UnorderedAccessView*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11UnorderedAccessView*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11UnorderedAccessView*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11UnorderedAccessView*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11UnorderedAccessView*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11UnorderedAccessView*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11UnorderedAccessView*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11UnorderedAccessView*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11UnorderedAccessView*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public void GetResource(ID3D11Resource** ppResource)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11UnorderedAccessView*, ID3D11Resource**, void>)(lpVtbl[7]))((ID3D11UnorderedAccessView*)Unsafe.AsPointer(ref this), ppResource);
            }

            public void GetDesc(D3D11_UNORDERED_ACCESS_VIEW_DESC* pDesc)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11UnorderedAccessView*, D3D11_UNORDERED_ACCESS_VIEW_DESC*, void>)(lpVtbl[8]))((ID3D11UnorderedAccessView*)Unsafe.AsPointer(ref this), pDesc);
            }
        }
        [Guid("3B301D64-D678-4289-8897-22F8928B72F3")]
        [NativeTypeName("struct ID3D11VertexShader : ID3D11DeviceChild")]
        public unsafe partial struct ID3D11VertexShader
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11VertexShader*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11VertexShader*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11VertexShader*, uint>)(lpVtbl[1]))((ID3D11VertexShader*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11VertexShader*, uint>)(lpVtbl[2]))((ID3D11VertexShader*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11VertexShader*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11VertexShader*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11VertexShader*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11VertexShader*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11VertexShader*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11VertexShader*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11VertexShader*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11VertexShader*)Unsafe.AsPointer(ref this), guid, pData);
            }
        }
        [Guid("DB6F6DDB-AC77-4E88-8253-819DF9BBF140")]
        [NativeTypeName("struct ID3D11Device : IUnknown")]
        public unsafe partial struct ID3D11Device
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11Device*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, uint>)(lpVtbl[1]))((ID3D11Device*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, uint>)(lpVtbl[2]))((ID3D11Device*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateBuffer([NativeTypeName("const D3D11_BUFFER_DESC *")] D3D11_BUFFER_DESC* pDesc, [NativeTypeName("const D3D11_SUBRESOURCE_DATA *")] D3D11_SUBRESOURCE_DATA* pInitialData, ID3D11Buffer** ppBuffer)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, D3D11_BUFFER_DESC*, D3D11_SUBRESOURCE_DATA*, ID3D11Buffer**, int>)(lpVtbl[3]))((ID3D11Device*)Unsafe.AsPointer(ref this), pDesc, pInitialData, ppBuffer);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateTexture1D([NativeTypeName("const D3D11_TEXTURE1D_DESC *")] D3D11_TEXTURE1D_DESC* pDesc, [NativeTypeName("const D3D11_SUBRESOURCE_DATA *")] D3D11_SUBRESOURCE_DATA* pInitialData, ID3D11Texture1D** ppTexture1D)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, D3D11_TEXTURE1D_DESC*, D3D11_SUBRESOURCE_DATA*, ID3D11Texture1D**, int>)(lpVtbl[4]))((ID3D11Device*)Unsafe.AsPointer(ref this), pDesc, pInitialData, ppTexture1D);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateTexture2D([NativeTypeName("const D3D11_TEXTURE2D_DESC *")] D3D11_TEXTURE2D_DESC* pDesc, [NativeTypeName("const D3D11_SUBRESOURCE_DATA *")] D3D11_SUBRESOURCE_DATA* pInitialData, ID3D11Texture2D** ppTexture2D)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, D3D11_TEXTURE2D_DESC*, D3D11_SUBRESOURCE_DATA*, ID3D11Texture2D**, int>)(lpVtbl[5]))((ID3D11Device*)Unsafe.AsPointer(ref this), pDesc, pInitialData, ppTexture2D);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateTexture3D([NativeTypeName("const D3D11_TEXTURE3D_DESC *")] D3D11_TEXTURE3D_DESC* pDesc, [NativeTypeName("const D3D11_SUBRESOURCE_DATA *")] D3D11_SUBRESOURCE_DATA* pInitialData, ID3D11Texture3D** ppTexture3D)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, D3D11_TEXTURE3D_DESC*, D3D11_SUBRESOURCE_DATA*, ID3D11Texture3D**, int>)(lpVtbl[6]))((ID3D11Device*)Unsafe.AsPointer(ref this), pDesc, pInitialData, ppTexture3D);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateShaderResourceView(ID3D11Resource* pResource, [NativeTypeName("const D3D11_SHADER_RESOURCE_VIEW_DESC *")] D3D11_SHADER_RESOURCE_VIEW_DESC* pDesc, ID3D11ShaderResourceView** ppSRView)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, ID3D11Resource*, D3D11_SHADER_RESOURCE_VIEW_DESC*, ID3D11ShaderResourceView**, int>)(lpVtbl[7]))((ID3D11Device*)Unsafe.AsPointer(ref this), pResource, pDesc, ppSRView);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateUnorderedAccessView(ID3D11Resource* pResource, [NativeTypeName("const D3D11_UNORDERED_ACCESS_VIEW_DESC *")] D3D11_UNORDERED_ACCESS_VIEW_DESC* pDesc, ID3D11UnorderedAccessView** ppUAView)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, ID3D11Resource*, D3D11_UNORDERED_ACCESS_VIEW_DESC*, ID3D11UnorderedAccessView**, int>)(lpVtbl[8]))((ID3D11Device*)Unsafe.AsPointer(ref this), pResource, pDesc, ppUAView);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateRenderTargetView(ID3D11Resource* pResource, [NativeTypeName("const D3D11_RENDER_TARGET_VIEW_DESC *")] D3D11_RENDER_TARGET_VIEW_DESC* pDesc, ID3D11RenderTargetView** ppRTView)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, ID3D11Resource*, D3D11_RENDER_TARGET_VIEW_DESC*, ID3D11RenderTargetView**, int>)(lpVtbl[9]))((ID3D11Device*)Unsafe.AsPointer(ref this), pResource, pDesc, ppRTView);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateDepthStencilView(ID3D11Resource* pResource, [NativeTypeName("const D3D11_DEPTH_STENCIL_VIEW_DESC *")] D3D11_DEPTH_STENCIL_VIEW_DESC* pDesc, ID3D11DepthStencilView** ppDepthStencilView)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, ID3D11Resource*, D3D11_DEPTH_STENCIL_VIEW_DESC*, ID3D11DepthStencilView**, int>)(lpVtbl[10]))((ID3D11Device*)Unsafe.AsPointer(ref this), pResource, pDesc, ppDepthStencilView);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateInputLayout([NativeTypeName("const D3D11_INPUT_ELEMENT_DESC *")] D3D11_INPUT_ELEMENT_DESC* pInputElementDescs, uint NumElements, [NativeTypeName("const void *")] void* pShaderBytecodeWithInputSignature, [NativeTypeName("SIZE_T")] nuint BytecodeLength, ID3D11InputLayout** ppInputLayout)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, D3D11_INPUT_ELEMENT_DESC*, uint, void*, nuint, ID3D11InputLayout**, int>)(lpVtbl[11]))((ID3D11Device*)Unsafe.AsPointer(ref this), pInputElementDescs, NumElements, pShaderBytecodeWithInputSignature, BytecodeLength, ppInputLayout);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateVertexShader([NativeTypeName("const void *")] void* pShaderBytecode, [NativeTypeName("SIZE_T")] nuint BytecodeLength, ID3D11ClassLinkage* pClassLinkage, ID3D11VertexShader** ppVertexShader)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, void*, nuint, ID3D11ClassLinkage*, ID3D11VertexShader**, int>)(lpVtbl[12]))((ID3D11Device*)Unsafe.AsPointer(ref this), pShaderBytecode, BytecodeLength, pClassLinkage, ppVertexShader);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateGeometryShader([NativeTypeName("const void *")] void* pShaderBytecode, [NativeTypeName("SIZE_T")] nuint BytecodeLength, ID3D11ClassLinkage* pClassLinkage, ID3D11GeometryShader** ppGeometryShader)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, void*, nuint, ID3D11ClassLinkage*, ID3D11GeometryShader**, int>)(lpVtbl[13]))((ID3D11Device*)Unsafe.AsPointer(ref this), pShaderBytecode, BytecodeLength, pClassLinkage, ppGeometryShader);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateGeometryShaderWithStreamOutput([NativeTypeName("const void *")] void* pShaderBytecode, [NativeTypeName("SIZE_T")] nuint BytecodeLength, [NativeTypeName("const D3D11_SO_DECLARATION_ENTRY *")] D3D11_SO_DECLARATION_ENTRY* pSODeclaration, uint NumEntries, [NativeTypeName("const UINT *")] uint* pBufferStrides, uint NumStrides, uint RasterizedStream, ID3D11ClassLinkage* pClassLinkage, ID3D11GeometryShader** ppGeometryShader)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, void*, nuint, D3D11_SO_DECLARATION_ENTRY*, uint, uint*, uint, uint, ID3D11ClassLinkage*, ID3D11GeometryShader**, int>)(lpVtbl[14]))((ID3D11Device*)Unsafe.AsPointer(ref this), pShaderBytecode, BytecodeLength, pSODeclaration, NumEntries, pBufferStrides, NumStrides, RasterizedStream, pClassLinkage, ppGeometryShader);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreatePixelShader([NativeTypeName("const void *")] void* pShaderBytecode, [NativeTypeName("SIZE_T")] nuint BytecodeLength, ID3D11ClassLinkage* pClassLinkage, ID3D11PixelShader** ppPixelShader)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, void*, nuint, ID3D11ClassLinkage*, ID3D11PixelShader**, int>)(lpVtbl[15]))((ID3D11Device*)Unsafe.AsPointer(ref this), pShaderBytecode, BytecodeLength, pClassLinkage, ppPixelShader);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateHullShader([NativeTypeName("const void *")] void* pShaderBytecode, [NativeTypeName("SIZE_T")] nuint BytecodeLength, ID3D11ClassLinkage* pClassLinkage, ID3D11HullShader** ppHullShader)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, void*, nuint, ID3D11ClassLinkage*, ID3D11HullShader**, int>)(lpVtbl[16]))((ID3D11Device*)Unsafe.AsPointer(ref this), pShaderBytecode, BytecodeLength, pClassLinkage, ppHullShader);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateDomainShader([NativeTypeName("const void *")] void* pShaderBytecode, [NativeTypeName("SIZE_T")] nuint BytecodeLength, ID3D11ClassLinkage* pClassLinkage, ID3D11DomainShader** ppDomainShader)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, void*, nuint, ID3D11ClassLinkage*, ID3D11DomainShader**, int>)(lpVtbl[17]))((ID3D11Device*)Unsafe.AsPointer(ref this), pShaderBytecode, BytecodeLength, pClassLinkage, ppDomainShader);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateComputeShader([NativeTypeName("const void *")] void* pShaderBytecode, [NativeTypeName("SIZE_T")] nuint BytecodeLength, ID3D11ClassLinkage* pClassLinkage, ID3D11ComputeShader** ppComputeShader)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, void*, nuint, ID3D11ClassLinkage*, ID3D11ComputeShader**, int>)(lpVtbl[18]))((ID3D11Device*)Unsafe.AsPointer(ref this), pShaderBytecode, BytecodeLength, pClassLinkage, ppComputeShader);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateClassLinkage(ID3D11ClassLinkage** ppLinkage)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, ID3D11ClassLinkage**, int>)(lpVtbl[19]))((ID3D11Device*)Unsafe.AsPointer(ref this), ppLinkage);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateBlendState([NativeTypeName("const D3D11_BLEND_DESC *")] D3D11_BLEND_DESC* pBlendStateDesc, ID3D11BlendState** ppBlendState)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, D3D11_BLEND_DESC*, ID3D11BlendState**, int>)(lpVtbl[20]))((ID3D11Device*)Unsafe.AsPointer(ref this), pBlendStateDesc, ppBlendState);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateDepthStencilState([NativeTypeName("const D3D11_DEPTH_STENCIL_DESC *")] D3D11_DEPTH_STENCIL_DESC* pDepthStencilDesc, ID3D11DepthStencilState** ppDepthStencilState)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, D3D11_DEPTH_STENCIL_DESC*, ID3D11DepthStencilState**, int>)(lpVtbl[21]))((ID3D11Device*)Unsafe.AsPointer(ref this), pDepthStencilDesc, ppDepthStencilState);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateRasterizerState([NativeTypeName("const D3D11_RASTERIZER_DESC *")] D3D11_RASTERIZER_DESC* pRasterizerDesc, ID3D11RasterizerState** ppRasterizerState)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, D3D11_RASTERIZER_DESC*, ID3D11RasterizerState**, int>)(lpVtbl[22]))((ID3D11Device*)Unsafe.AsPointer(ref this), pRasterizerDesc, ppRasterizerState);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateSamplerState([NativeTypeName("const D3D11_SAMPLER_DESC *")] D3D11_SAMPLER_DESC* pSamplerDesc, ID3D11SamplerState** ppSamplerState)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, D3D11_SAMPLER_DESC*, ID3D11SamplerState**, int>)(lpVtbl[23]))((ID3D11Device*)Unsafe.AsPointer(ref this), pSamplerDesc, ppSamplerState);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateQuery([NativeTypeName("const D3D11_QUERY_DESC *")] D3D11_QUERY_DESC* pQueryDesc, ID3D11Query** ppQuery)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, D3D11_QUERY_DESC*, ID3D11Query**, int>)(lpVtbl[24]))((ID3D11Device*)Unsafe.AsPointer(ref this), pQueryDesc, ppQuery);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreatePredicate([NativeTypeName("const D3D11_QUERY_DESC *")] D3D11_QUERY_DESC* pPredicateDesc, ID3D11Predicate** ppPredicate)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, D3D11_QUERY_DESC*, ID3D11Predicate**, int>)(lpVtbl[25]))((ID3D11Device*)Unsafe.AsPointer(ref this), pPredicateDesc, ppPredicate);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateCounter([NativeTypeName("const D3D11_COUNTER_DESC *")] D3D11_COUNTER_DESC* pCounterDesc, ID3D11Counter** ppCounter)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, D3D11_COUNTER_DESC*, ID3D11Counter**, int>)(lpVtbl[26]))((ID3D11Device*)Unsafe.AsPointer(ref this), pCounterDesc, ppCounter);
            }

            [return: NativeTypeName("HRESULT")]
            public int CreateDeferredContext(uint ContextFlags, ID3D11DeviceContext** ppDeferredContext)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, uint, ID3D11DeviceContext**, int>)(lpVtbl[27]))((ID3D11Device*)Unsafe.AsPointer(ref this), ContextFlags, ppDeferredContext);
            }

            [return: NativeTypeName("HRESULT")]
            public int OpenSharedResource([NativeTypeName("HANDLE")] void* hResource, [NativeTypeName("const IID &")] Guid* ReturnedInterface, void** ppResource)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, void*, Guid*, void**, int>)(lpVtbl[28]))((ID3D11Device*)Unsafe.AsPointer(ref this), hResource, ReturnedInterface, ppResource);
            }

            [return: NativeTypeName("HRESULT")]
            public int CheckFormatSupport(DXGI_FORMAT Format, uint* pFormatSupport)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, DXGI_FORMAT, uint*, int>)(lpVtbl[29]))((ID3D11Device*)Unsafe.AsPointer(ref this), Format, pFormatSupport);
            }

            [return: NativeTypeName("HRESULT")]
            public int CheckMultisampleQualityLevels(DXGI_FORMAT Format, uint SampleCount, uint* pNumQualityLevels)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, DXGI_FORMAT, uint, uint*, int>)(lpVtbl[30]))((ID3D11Device*)Unsafe.AsPointer(ref this), Format, SampleCount, pNumQualityLevels);
            }

            public void CheckCounterInfo(D3D11_COUNTER_INFO* pCounterInfo)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Device*, D3D11_COUNTER_INFO*, void>)(lpVtbl[31]))((ID3D11Device*)Unsafe.AsPointer(ref this), pCounterInfo);
            }

            [return: NativeTypeName("HRESULT")]
            public int CheckCounter([NativeTypeName("const D3D11_COUNTER_DESC *")] D3D11_COUNTER_DESC* pDesc, D3D11_COUNTER_TYPE* pType, uint* pActiveCounters, [NativeTypeName("LPSTR")] sbyte* szName, uint* pNameLength, [NativeTypeName("LPSTR")] sbyte* szUnits, uint* pUnitsLength, [NativeTypeName("LPSTR")] sbyte* szDescription, uint* pDescriptionLength)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, D3D11_COUNTER_DESC*, D3D11_COUNTER_TYPE*, uint*, sbyte*, uint*, sbyte*, uint*, sbyte*, uint*, int>)(lpVtbl[32]))((ID3D11Device*)Unsafe.AsPointer(ref this), pDesc, pType, pActiveCounters, szName, pNameLength, szUnits, pUnitsLength, szDescription, pDescriptionLength);
            }

            [return: NativeTypeName("HRESULT")]
            public int CheckFeatureSupport(D3D11_FEATURE Feature, void* pFeatureSupportData, uint FeatureSupportDataSize)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, D3D11_FEATURE, void*, uint, int>)(lpVtbl[33]))((ID3D11Device*)Unsafe.AsPointer(ref this), Feature, pFeatureSupportData, FeatureSupportDataSize);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, Guid*, uint*, void*, int>)(lpVtbl[34]))((ID3D11Device*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, Guid*, uint, void*, int>)(lpVtbl[35]))((ID3D11Device*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, Guid*, IntPtr, int>)(lpVtbl[36]))((ID3D11Device*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public D3D_FEATURE_LEVEL GetFeatureLevel()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, D3D_FEATURE_LEVEL>)(lpVtbl[37]))((ID3D11Device*)Unsafe.AsPointer(ref this));
            }

            public uint GetCreationFlags()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, uint>)(lpVtbl[38]))((ID3D11Device*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("HRESULT")]
            public int GetDeviceRemovedReason()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, int>)(lpVtbl[39]))((ID3D11Device*)Unsafe.AsPointer(ref this));
            }

            public void GetImmediateContext(ID3D11DeviceContext** ppImmediateContext)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Device*, ID3D11DeviceContext**, void>)(lpVtbl[40]))((ID3D11Device*)Unsafe.AsPointer(ref this), ppImmediateContext);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetExceptionMode(uint RaiseFlags)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, uint, int>)(lpVtbl[41]))((ID3D11Device*)Unsafe.AsPointer(ref this), RaiseFlags);
            }

            public uint GetExceptionMode()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Device*, uint>)(lpVtbl[42]))((ID3D11Device*)Unsafe.AsPointer(ref this));
            }
        }
        public partial struct D3D11_BLEND_DESC
        {
            [NativeTypeName("WINBOOL")]
            public int AlphaToCoverageEnable;

            [NativeTypeName("WINBOOL")]
            public int IndependentBlendEnable;

            [NativeTypeName("D3D11_RENDER_TARGET_BLEND_DESC[8]")]
            public _RenderTarget_e__FixedBuffer RenderTarget;

            [InlineArray(8)]
            public partial struct _RenderTarget_e__FixedBuffer
            {
                public D3D11_RENDER_TARGET_BLEND_DESC e0;
            }
        }
        public partial struct D3D11_DEPTH_STENCILOP_DESC
        {
            public D3D11_STENCIL_OP StencilFailOp;

            public D3D11_STENCIL_OP StencilDepthFailOp;

            public D3D11_STENCIL_OP StencilPassOp;

            public D3D11_COMPARISON_FUNC StencilFunc;
        }
        public partial struct D3D11_COUNTER_DESC
        {
            public D3D11_COUNTER Counter;

            public uint MiscFlags;
        }
        public partial struct D3D11_COUNTER_INFO
        {
            public D3D11_COUNTER LastDeviceDependentCounter;

            public uint NumSimultaneousCounters;

            [NativeTypeName("UINT8")]
            public byte NumDetectableParallelUnits;
        }
        public partial struct D3D11_CLASS_INSTANCE_DESC
        {
            public uint InstanceId;

            public uint InstanceIndex;

            public uint TypeId;

            public uint ConstantBuffer;

            public uint BaseConstantBufferOffset;

            public uint BaseTexture;

            public uint BaseSampler;

            [NativeTypeName("WINBOOL")]
            public int Created;
        }
        public partial struct D3D11_BUFFER_DESC
        {
            public uint ByteWidth;

            public D3D11_USAGE Usage;

            public uint BindFlags;

            public uint CPUAccessFlags;

            public uint MiscFlags;

            public uint StructureByteStride;
        }
        public partial struct D3D11_DEPTH_STENCIL_VIEW_DESC
        {
            public DXGI_FORMAT Format;

            public D3D11_DSV_DIMENSION ViewDimension;

            public uint Flags;

            [NativeTypeName("__AnonymousRecord_d3d11_L1824_C20")]
            public _Anonymous_e__Union Anonymous;

            [UnscopedRef]
            public ref D3D11_TEX1D_DSV Texture1D
            {
                get
                {
                    return ref Anonymous.Texture1D;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX1D_ARRAY_DSV Texture1DArray
            {
                get
                {
                    return ref Anonymous.Texture1DArray;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX2D_DSV Texture2D
            {
                get
                {
                    return ref Anonymous.Texture2D;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX2D_ARRAY_DSV Texture2DArray
            {
                get
                {
                    return ref Anonymous.Texture2DArray;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX2DMS_DSV Texture2DMS
            {
                get
                {
                    return ref Anonymous.Texture2DMS;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX2DMS_ARRAY_DSV Texture2DMSArray
            {
                get
                {
                    return ref Anonymous.Texture2DMSArray;
                }
            }

            [StructLayout(LayoutKind.Explicit)]
            public partial struct _Anonymous_e__Union
            {
                [FieldOffset(0)]
                public D3D11_TEX1D_DSV Texture1D;

                [FieldOffset(0)]
                public D3D11_TEX1D_ARRAY_DSV Texture1DArray;

                [FieldOffset(0)]
                public D3D11_TEX2D_DSV Texture2D;

                [FieldOffset(0)]
                public D3D11_TEX2D_ARRAY_DSV Texture2DArray;

                [FieldOffset(0)]
                public D3D11_TEX2DMS_DSV Texture2DMS;

                [FieldOffset(0)]
                public D3D11_TEX2DMS_ARRAY_DSV Texture2DMSArray;
            }
        }
        public partial struct D3D11_RASTERIZER_DESC
        {
            public D3D11_FILL_MODE FillMode;

            public D3D11_CULL_MODE CullMode;

            [NativeTypeName("WINBOOL")]
            public int FrontCounterClockwise;

            public int DepthBias;

            public float DepthBiasClamp;

            public float SlopeScaledDepthBias;

            [NativeTypeName("WINBOOL")]
            public int DepthClipEnable;

            [NativeTypeName("WINBOOL")]
            public int ScissorEnable;

            [NativeTypeName("WINBOOL")]
            public int MultisampleEnable;

            [NativeTypeName("WINBOOL")]
            public int AntialiasedLineEnable;
        }
        public partial struct D3D11_QUERY_DESC
        {
            public D3D11_QUERY Query;

            public uint MiscFlags;
        }
        public unsafe partial struct D3D11_INPUT_ELEMENT_DESC
        {
            [NativeTypeName("LPCSTR")]
            public sbyte* SemanticName;

            public uint SemanticIndex;

            public DXGI_FORMAT Format;

            public uint InputSlot;

            public uint AlignedByteOffset;

            public D3D11_INPUT_CLASSIFICATION InputSlotClass;

            public uint InstanceDataStepRate;
        }
        public unsafe partial struct D3D11_MAPPED_SUBRESOURCE
        {
            public void* pData;

            public uint RowPitch;

            public uint DepthPitch;
        }
        public partial struct D3D11_RENDER_TARGET_BLEND_DESC
        {
            [NativeTypeName("WINBOOL")]
            public int BlendEnable;

            public D3D11_BLEND SrcBlend;

            public D3D11_BLEND DestBlend;

            public D3D11_BLEND_OP BlendOp;

            public D3D11_BLEND SrcBlendAlpha;

            public D3D11_BLEND DestBlendAlpha;

            public D3D11_BLEND_OP BlendOpAlpha;

            [NativeTypeName("UINT8")]
            public byte RenderTargetWriteMask;
        }
        public partial struct D3D11_RENDER_TARGET_VIEW_DESC
        {
            public DXGI_FORMAT Format;

            public D3D11_RTV_DIMENSION ViewDimension;

            [NativeTypeName("__AnonymousRecord_d3d11_L1902_C20")]
            public _Anonymous_e__Union Anonymous;

            [UnscopedRef]
            public ref D3D11_BUFFER_RTV Buffer
            {
                get
                {
                    return ref Anonymous.Buffer;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX1D_RTV Texture1D
            {
                get
                {
                    return ref Anonymous.Texture1D;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX1D_ARRAY_RTV Texture1DArray
            {
                get
                {
                    return ref Anonymous.Texture1DArray;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX2D_RTV Texture2D
            {
                get
                {
                    return ref Anonymous.Texture2D;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX2D_ARRAY_RTV Texture2DArray
            {
                get
                {
                    return ref Anonymous.Texture2DArray;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX2DMS_RTV Texture2DMS
            {
                get
                {
                    return ref Anonymous.Texture2DMS;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX2DMS_ARRAY_RTV Texture2DMSArray
            {
                get
                {
                    return ref Anonymous.Texture2DMSArray;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX3D_RTV Texture3D
            {
                get
                {
                    return ref Anonymous.Texture3D;
                }
            }

            [StructLayout(LayoutKind.Explicit)]
            public partial struct _Anonymous_e__Union
            {
                [FieldOffset(0)]
                public D3D11_BUFFER_RTV Buffer;

                [FieldOffset(0)]
                public D3D11_TEX1D_RTV Texture1D;

                [FieldOffset(0)]
                public D3D11_TEX1D_ARRAY_RTV Texture1DArray;

                [FieldOffset(0)]
                public D3D11_TEX2D_RTV Texture2D;

                [FieldOffset(0)]
                public D3D11_TEX2D_ARRAY_RTV Texture2DArray;

                [FieldOffset(0)]
                public D3D11_TEX2DMS_RTV Texture2DMS;

                [FieldOffset(0)]
                public D3D11_TEX2DMS_ARRAY_RTV Texture2DMSArray;

                [FieldOffset(0)]
                public D3D11_TEX3D_RTV Texture3D;
            }
        }
        public partial struct D3D11_SAMPLER_DESC
        {
            public D3D11_FILTER Filter;

            public D3D11_TEXTURE_ADDRESS_MODE AddressU;

            public D3D11_TEXTURE_ADDRESS_MODE AddressV;

            public D3D11_TEXTURE_ADDRESS_MODE AddressW;

            public float MipLODBias;

            public uint MaxAnisotropy;

            public D3D11_COMPARISON_FUNC ComparisonFunc;

            [NativeTypeName("FLOAT[4]")]
            public _BorderColor_e__FixedBuffer BorderColor;

            public float MinLOD;

            public float MaxLOD;

            [InlineArray(4)]
            public partial struct _BorderColor_e__FixedBuffer
            {
                public float e0;
            }
        }
        public partial struct D3D11_SHADER_RESOURCE_VIEW_DESC
        {
            public DXGI_FORMAT Format;

            [NativeTypeName("D3D11_SRV_DIMENSION")]
            public D3D_SRV_DIMENSION ViewDimension;

            [NativeTypeName("__AnonymousRecord_d3d11_L2034_C20")]
            public _Anonymous_e__Union Anonymous;

            [UnscopedRef]
            public ref D3D11_BUFFER_SRV Buffer
            {
                get
                {
                    return ref Anonymous.Buffer;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX1D_SRV Texture1D
            {
                get
                {
                    return ref Anonymous.Texture1D;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX1D_ARRAY_SRV Texture1DArray
            {
                get
                {
                    return ref Anonymous.Texture1DArray;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX2D_SRV Texture2D
            {
                get
                {
                    return ref Anonymous.Texture2D;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX2D_ARRAY_SRV Texture2DArray
            {
                get
                {
                    return ref Anonymous.Texture2DArray;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX2DMS_SRV Texture2DMS
            {
                get
                {
                    return ref Anonymous.Texture2DMS;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX2DMS_ARRAY_SRV Texture2DMSArray
            {
                get
                {
                    return ref Anonymous.Texture2DMSArray;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX3D_SRV Texture3D
            {
                get
                {
                    return ref Anonymous.Texture3D;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEXCUBE_SRV TextureCube
            {
                get
                {
                    return ref Anonymous.TextureCube;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEXCUBE_ARRAY_SRV TextureCubeArray
            {
                get
                {
                    return ref Anonymous.TextureCubeArray;
                }
            }

            [UnscopedRef]
            public ref D3D11_BUFFEREX_SRV BufferEx
            {
                get
                {
                    return ref Anonymous.BufferEx;
                }
            }

            [StructLayout(LayoutKind.Explicit)]
            public partial struct _Anonymous_e__Union
            {
                [FieldOffset(0)]
                public D3D11_BUFFER_SRV Buffer;

                [FieldOffset(0)]
                public D3D11_TEX1D_SRV Texture1D;

                [FieldOffset(0)]
                public D3D11_TEX1D_ARRAY_SRV Texture1DArray;

                [FieldOffset(0)]
                public D3D11_TEX2D_SRV Texture2D;

                [FieldOffset(0)]
                public D3D11_TEX2D_ARRAY_SRV Texture2DArray;

                [FieldOffset(0)]
                public D3D11_TEX2DMS_SRV Texture2DMS;

                [FieldOffset(0)]
                public D3D11_TEX2DMS_ARRAY_SRV Texture2DMSArray;

                [FieldOffset(0)]
                public D3D11_TEX3D_SRV Texture3D;

                [FieldOffset(0)]
                public D3D11_TEXCUBE_SRV TextureCube;

                [FieldOffset(0)]
                public D3D11_TEXCUBE_ARRAY_SRV TextureCubeArray;

                [FieldOffset(0)]
                public D3D11_BUFFEREX_SRV BufferEx;
            }
        }
        public partial struct D3D11_BUFFEREX_SRV
        {
            public uint FirstElement;

            public uint NumElements;

            public uint Flags;
        }
        public partial struct D3D11_BUFFER_RTV
        {
            [NativeTypeName("__AnonymousRecord_d3d11_L1016_C20")]
            public _Anonymous1_e__Union Anonymous1;

            [NativeTypeName("__AnonymousRecord_d3d11_L1020_C20")]
            public _Anonymous2_e__Union Anonymous2;

            [UnscopedRef]
            public ref uint FirstElement
            {
                get
                {
                    return ref Anonymous1.FirstElement;
                }
            }

            [UnscopedRef]
            public ref uint ElementOffset
            {
                get
                {
                    return ref Anonymous1.ElementOffset;
                }
            }

            [UnscopedRef]
            public ref uint NumElements
            {
                get
                {
                    return ref Anonymous2.NumElements;
                }
            }

            [UnscopedRef]
            public ref uint ElementWidth
            {
                get
                {
                    return ref Anonymous2.ElementWidth;
                }
            }

            [StructLayout(LayoutKind.Explicit)]
            public partial struct _Anonymous1_e__Union
            {
                [FieldOffset(0)]
                public uint FirstElement;

                [FieldOffset(0)]
                public uint ElementOffset;
            }

            [StructLayout(LayoutKind.Explicit)]
            public partial struct _Anonymous2_e__Union
            {
                [FieldOffset(0)]
                public uint NumElements;

                [FieldOffset(0)]
                public uint ElementWidth;
            }
        }
        public partial struct D3D11_BUFFER_SRV
        {
            [NativeTypeName("__AnonymousRecord_d3d11_L1026_C20")]
            public _Anonymous1_e__Union Anonymous1;

            [NativeTypeName("__AnonymousRecord_d3d11_L1030_C20")]
            public _Anonymous2_e__Union Anonymous2;

            [UnscopedRef]
            public ref uint FirstElement
            {
                get
                {
                    return ref Anonymous1.FirstElement;
                }
            }

            [UnscopedRef]
            public ref uint ElementOffset
            {
                get
                {
                    return ref Anonymous1.ElementOffset;
                }
            }

            [UnscopedRef]
            public ref uint NumElements
            {
                get
                {
                    return ref Anonymous2.NumElements;
                }
            }

            [UnscopedRef]
            public ref uint ElementWidth
            {
                get
                {
                    return ref Anonymous2.ElementWidth;
                }
            }

            [StructLayout(LayoutKind.Explicit)]
            public partial struct _Anonymous1_e__Union
            {
                [FieldOffset(0)]
                public uint FirstElement;

                [FieldOffset(0)]
                public uint ElementOffset;
            }

            [StructLayout(LayoutKind.Explicit)]
            public partial struct _Anonymous2_e__Union
            {
                [FieldOffset(0)]
                public uint NumElements;

                [FieldOffset(0)]
                public uint ElementWidth;
            }
        }
        public partial struct D3D11_BUFFER_UAV
        {
            public uint FirstElement;

            public uint NumElements;

            public uint Flags;
        }
        public unsafe partial struct D3D11_SUBRESOURCE_DATA
        {
            [NativeTypeName("const void *")]
            public void* pSysMem;

            public uint SysMemPitch;

            public uint SysMemSlicePitch;
        }
        public unsafe partial struct D3D11_SO_DECLARATION_ENTRY
        {
            public uint Stream;

            [NativeTypeName("LPCSTR")]
            public sbyte* SemanticName;

            public uint SemanticIndex;

            public byte StartComponent;

            public byte ComponentCount;

            public byte OutputSlot;
        }
        public partial struct D3D11_TEX1D_ARRAY_DSV
        {
            public uint MipSlice;

            public uint FirstArraySlice;

            public uint ArraySize;
        }
        public partial struct D3D11_TEX1D_ARRAY_RTV
        {
            public uint MipSlice;

            public uint FirstArraySlice;

            public uint ArraySize;
        }
        public partial struct D3D11_TEX1D_ARRAY_SRV
        {
            public uint MostDetailedMip;

            public uint MipLevels;

            public uint FirstArraySlice;

            public uint ArraySize;
        }
        public partial struct D3D11_TEX1D_ARRAY_UAV
        {
            public uint MipSlice;

            public uint FirstArraySlice;

            public uint ArraySize;
        }
        public partial struct D3D11_TEX1D_DSV
        {
            public uint MipSlice;
        }        
        public partial struct D3D11_TEX1D_RTV
        {
            public uint MipSlice;
        }
        public partial struct D3D11_TEX1D_SRV
        {
            public uint MostDetailedMip;

            public uint MipLevels;
        }
        public partial struct D3D11_TEX1D_UAV
        {
            public uint MipSlice;
        }
        public partial struct D3D11_TEX2D_ARRAY_DSV
        {
            public uint MipSlice;

            public uint FirstArraySlice;

            public uint ArraySize;
        }
        public partial struct D3D11_TEX2D_ARRAY_RTV
        {
            public uint MipSlice;

            public uint FirstArraySlice;

            public uint ArraySize;
        }
        public partial struct D3D11_TEX2D_ARRAY_SRV
        {
            public uint MostDetailedMip;

            public uint MipLevels;

            public uint FirstArraySlice;

            public uint ArraySize;
        }
        public partial struct D3D11_TEX2D_ARRAY_UAV
        {
            public uint MipSlice;

            public uint FirstArraySlice;

            public uint ArraySize;
        }
        public partial struct D3D11_TEX2D_DSV
        {
            public uint MipSlice;
        }
        public partial struct D3D11_TEX2D_RTV
        {
            public uint MipSlice;
        }
        public partial struct D3D11_TEX2D_SRV
        {
            public uint MostDetailedMip;

            public uint MipLevels;
        }
        public partial struct D3D11_TEX2D_UAV
        {
            public uint MipSlice;
        }
        public partial struct D3D11_TEX2DMS_ARRAY_DSV
        {
            public uint FirstArraySlice;

            public uint ArraySize;
        }
        public partial struct D3D11_TEX2DMS_ARRAY_RTV
        {
            public uint FirstArraySlice;

            public uint ArraySize;
        }
        public partial struct D3D11_TEX2DMS_ARRAY_SRV
        {
            public uint FirstArraySlice;

            public uint ArraySize;
        }
        public partial struct D3D11_TEX2DMS_DSV
        {
            public uint UnusedField_NothingToDefine;
        }
        public partial struct D3D11_TEX2DMS_RTV
        {
            public uint UnusedField_NothingToDefine;
        }
        public partial struct D3D11_TEX2DMS_SRV
        {
            public uint UnusedField_NothingToDefine;
        }
        public partial struct D3D11_TEX3D_RTV
        {
            public uint MipSlice;

            public uint FirstWSlice;

            public uint WSize;
        }
        public partial struct D3D11_TEX3D_SRV
        {
            public uint MostDetailedMip;

            public uint MipLevels;
        }
        public partial struct D3D11_TEX3D_UAV
        {
            public uint MipSlice;

            public uint FirstWSlice;

            public uint WSize;
        }
        public partial struct D3D11_TEXCUBE_ARRAY_SRV
        {
            public uint MostDetailedMip;

            public uint MipLevels;

            public uint First2DArrayFace;

            public uint NumCubes;
        }
        public partial struct D3D11_TEXCUBE_SRV
        {
            public uint MostDetailedMip;

            public uint MipLevels;
        }
        public partial struct D3D11_TEXTURE1D_DESC
        {
            public uint Width;

            public uint MipLevels;

            public uint ArraySize;

            public DXGI_FORMAT Format;

            public D3D11_USAGE Usage;

            public uint BindFlags;

            public uint CPUAccessFlags;

            public uint MiscFlags;
        }
        public partial struct D3D11_TEXTURE2D_DESC
        {
            public uint Width;

            public uint Height;

            public uint MipLevels;

            public uint ArraySize;

            public DXGI_FORMAT Format;

            public DXGI_SAMPLE_DESC SampleDesc;

            public D3D11_USAGE Usage;

            public uint BindFlags;

            public uint CPUAccessFlags;

            public uint MiscFlags;
        }
        public partial struct D3D11_TEXTURE3D_DESC
        {
            public uint Width;

            public uint Height;

            public uint Depth;

            public uint MipLevels;

            public DXGI_FORMAT Format;

            public D3D11_USAGE Usage;

            public uint BindFlags;

            public uint CPUAccessFlags;

            public uint MiscFlags;
        }
        public partial struct D3D11_UNORDERED_ACCESS_VIEW_DESC
        {
            public DXGI_FORMAT Format;

            public D3D11_UAV_DIMENSION ViewDimension;

            [NativeTypeName("__AnonymousRecord_d3d11_L1661_C20")]
            public _Anonymous_e__Union Anonymous;

            [UnscopedRef]
            public ref D3D11_BUFFER_UAV Buffer
            {
                get
                {
                    return ref Anonymous.Buffer;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX1D_UAV Texture1D
            {
                get
                {
                    return ref Anonymous.Texture1D;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX1D_ARRAY_UAV Texture1DArray
            {
                get
                {
                    return ref Anonymous.Texture1DArray;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX2D_UAV Texture2D
            {
                get
                {
                    return ref Anonymous.Texture2D;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX2D_ARRAY_UAV Texture2DArray
            {
                get
                {
                    return ref Anonymous.Texture2DArray;
                }
            }

            [UnscopedRef]
            public ref D3D11_TEX3D_UAV Texture3D
            {
                get
                {
                    return ref Anonymous.Texture3D;
                }
            }

            [StructLayout(LayoutKind.Explicit)]
            public partial struct _Anonymous_e__Union
            {
                [FieldOffset(0)]
                public D3D11_BUFFER_UAV Buffer;

                [FieldOffset(0)]
                public D3D11_TEX1D_UAV Texture1D;

                [FieldOffset(0)]
                public D3D11_TEX1D_ARRAY_UAV Texture1DArray;

                [FieldOffset(0)]
                public D3D11_TEX2D_UAV Texture2D;

                [FieldOffset(0)]
                public D3D11_TEX2D_ARRAY_UAV Texture2DArray;

                [FieldOffset(0)]
                public D3D11_TEX3D_UAV Texture3D;
            }
        }
        [Guid("F8FB5C27-C6B3-4F75-A4C8-439AF2EF564C")]
        [NativeTypeName("struct ID3D11Texture1D : ID3D11Resource")]
        public unsafe partial struct ID3D11Texture1D
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture1D*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11Texture1D*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture1D*, uint>)(lpVtbl[1]))((ID3D11Texture1D*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture1D*, uint>)(lpVtbl[2]))((ID3D11Texture1D*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Texture1D*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11Texture1D*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture1D*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11Texture1D*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture1D*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11Texture1D*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture1D*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11Texture1D*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public void GetType(D3D11_RESOURCE_DIMENSION* pResourceDimension)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Texture1D*, D3D11_RESOURCE_DIMENSION*, void>)(lpVtbl[7]))((ID3D11Texture1D*)Unsafe.AsPointer(ref this), pResourceDimension);
            }

            public void SetEvictionPriority(uint EvictionPriority)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Texture1D*, uint, void>)(lpVtbl[8]))((ID3D11Texture1D*)Unsafe.AsPointer(ref this), EvictionPriority);
            }

            public uint GetEvictionPriority()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture1D*, uint>)(lpVtbl[9]))((ID3D11Texture1D*)Unsafe.AsPointer(ref this));
            }

            public void GetDesc(D3D11_TEXTURE1D_DESC* pDesc)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Texture1D*, D3D11_TEXTURE1D_DESC*, void>)(lpVtbl[10]))((ID3D11Texture1D*)Unsafe.AsPointer(ref this), pDesc);
            }
        }
        [Guid("6F15AAF2-D208-4E89-9AB4-489535D34F9C")]
        [NativeTypeName("struct ID3D11Texture2D : ID3D11Resource")]
        public unsafe partial struct ID3D11Texture2D
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture2D*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11Texture2D*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture2D*, uint>)(lpVtbl[1]))((ID3D11Texture2D*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture2D*, uint>)(lpVtbl[2]))((ID3D11Texture2D*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Texture2D*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11Texture2D*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture2D*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11Texture2D*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture2D*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11Texture2D*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture2D*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11Texture2D*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public void GetType(D3D11_RESOURCE_DIMENSION* pResourceDimension)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Texture2D*, D3D11_RESOURCE_DIMENSION*, void>)(lpVtbl[7]))((ID3D11Texture2D*)Unsafe.AsPointer(ref this), pResourceDimension);
            }

            public void SetEvictionPriority(uint EvictionPriority)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Texture2D*, uint, void>)(lpVtbl[8]))((ID3D11Texture2D*)Unsafe.AsPointer(ref this), EvictionPriority);
            }

            public uint GetEvictionPriority()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture2D*, uint>)(lpVtbl[9]))((ID3D11Texture2D*)Unsafe.AsPointer(ref this));
            }

            public void GetDesc(D3D11_TEXTURE2D_DESC* pDesc)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Texture2D*, D3D11_TEXTURE2D_DESC*, void>)(lpVtbl[10]))((ID3D11Texture2D*)Unsafe.AsPointer(ref this), pDesc);
            }
        }
        [Guid("037E866E-F56D-4357-A8AF-9DABBE6E250E")]
        [NativeTypeName("struct ID3D11Texture3D : ID3D11Resource")]
        public unsafe partial struct ID3D11Texture3D
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture3D*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11Texture3D*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture3D*, uint>)(lpVtbl[1]))((ID3D11Texture3D*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture3D*, uint>)(lpVtbl[2]))((ID3D11Texture3D*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Texture3D*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11Texture3D*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture3D*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11Texture3D*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture3D*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11Texture3D*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture3D*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11Texture3D*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public void GetType(D3D11_RESOURCE_DIMENSION* pResourceDimension)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Texture3D*, D3D11_RESOURCE_DIMENSION*, void>)(lpVtbl[7]))((ID3D11Texture3D*)Unsafe.AsPointer(ref this), pResourceDimension);
            }

            public void SetEvictionPriority(uint EvictionPriority)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Texture3D*, uint, void>)(lpVtbl[8]))((ID3D11Texture3D*)Unsafe.AsPointer(ref this), EvictionPriority);
            }

            public uint GetEvictionPriority()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Texture3D*, uint>)(lpVtbl[9]))((ID3D11Texture3D*)Unsafe.AsPointer(ref this));
            }

            public void GetDesc(D3D11_TEXTURE3D_DESC* pDesc)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Texture3D*, D3D11_TEXTURE3D_DESC*, void>)(lpVtbl[10]))((ID3D11Texture3D*)Unsafe.AsPointer(ref this), pDesc);
            }
        }
        [Guid("D6C00747-87B7-425E-B84D-44D108560AFD")]
        [NativeTypeName("struct ID3D11Query : ID3D11Asynchronous")]
        public unsafe partial struct ID3D11Query
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Query*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11Query*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Query*, uint>)(lpVtbl[1]))((ID3D11Query*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Query*, uint>)(lpVtbl[2]))((ID3D11Query*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Query*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11Query*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Query*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11Query*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Query*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11Query*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Query*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11Query*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public uint GetDataSize()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Query*, uint>)(lpVtbl[7]))((ID3D11Query*)Unsafe.AsPointer(ref this));
            }

            public void GetDesc(D3D11_QUERY_DESC* pDesc)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Query*, D3D11_QUERY_DESC*, void>)(lpVtbl[8]))((ID3D11Query*)Unsafe.AsPointer(ref this), pDesc);
            }
        }
        [Guid("6E8C49FB-A371-4770-B440-29086022B741")]
        [NativeTypeName("struct ID3D11Counter : ID3D11Asynchronous")]
        public unsafe partial struct ID3D11Counter
        {
            public void** lpVtbl;

            [return: NativeTypeName("HRESULT")]
            public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Counter*, Guid*, void**, int>)(lpVtbl[0]))((ID3D11Counter*)Unsafe.AsPointer(ref this), riid, ppvObject);
            }

            [return: NativeTypeName("ULONG")]
            public uint AddRef()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Counter*, uint>)(lpVtbl[1]))((ID3D11Counter*)Unsafe.AsPointer(ref this));
            }

            [return: NativeTypeName("ULONG")]
            public uint Release()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Counter*, uint>)(lpVtbl[2]))((ID3D11Counter*)Unsafe.AsPointer(ref this));
            }

            public void GetDevice(ID3D11Device** ppDevice)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Counter*, ID3D11Device**, void>)(lpVtbl[3]))((ID3D11Counter*)Unsafe.AsPointer(ref this), ppDevice);
            }

            [return: NativeTypeName("HRESULT")]
            public int GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Counter*, Guid*, uint*, void*, int>)(lpVtbl[4]))((ID3D11Counter*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Counter*, Guid*, uint, void*, int>)(lpVtbl[5]))((ID3D11Counter*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
            }

            [return: NativeTypeName("HRESULT")]
            public int SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IntPtr pData)
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Counter*, Guid*, IntPtr, int>)(lpVtbl[6]))((ID3D11Counter*)Unsafe.AsPointer(ref this), guid, pData);
            }

            public uint GetDataSize()
            {
                return ((delegate* unmanaged[Stdcall]<ID3D11Counter*, uint>)(lpVtbl[7]))((ID3D11Counter*)Unsafe.AsPointer(ref this));
            }

            public void GetDesc(D3D11_COUNTER_DESC* pDesc)
            {
                ((delegate* unmanaged[Stdcall]<ID3D11Counter*, D3D11_COUNTER_DESC*, void>)(lpVtbl[8]))((ID3D11Counter*)Unsafe.AsPointer(ref this), pDesc);
            }
        }
        public partial struct D3D11_DEPTH_STENCIL_DESC
        {
            bool DepthEnable;
            D3D11_DEPTH_WRITE_MASK DepthWriteMask;
            D3D11_COMPARISON_FUNC DepthFunc;
            bool StencilEnable;
            uint StencilReadMask;
            uint StencilWriteMask;
            D3D11_DEPTH_STENCILOP_DESC FrontFace;
            D3D11_DEPTH_STENCILOP_DESC BackFace;
        }
        
        // Enums
        public enum D3D_SRV_DIMENSION
        {
            Unknown = 0,
            Buffer = 1,
            Texture1D = 2,
            Texture1DArray = 3,
            Texture2D = 4,
            Texture2DArray = 5,
            Texture2DMS = 6,
            Texture2DMSArray = 7,
            Texture3D = 8,
            TextureCube = 9,
            TextureCubeArray = 10,
            BufferEx = 11
        }
        public enum D3D11_PRIMITIVE_TOPOLOGY
        {
            D3D_PRIMITIVE_TOPOLOGY_UNDEFINED = 0,
            D3D_PRIMITIVE_TOPOLOGY_POINTLIST = 1,
            D3D_PRIMITIVE_TOPOLOGY_LINELIST = 2,
            D3D_PRIMITIVE_TOPOLOGY_LINESTRIP = 3,
            D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST = 4,
            D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP = 5,
            D3D_PRIMITIVE_TOPOLOGY_TRIANGLEFAN,
            D3D_PRIMITIVE_TOPOLOGY_LINELIST_ADJ = 10,
            D3D_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ = 11,
            D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ = 12,
            D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ = 13,
            D3D_PRIMITIVE_TOPOLOGY_1_CONTROL_POINT_PATCHLIST = 33,
            D3D_PRIMITIVE_TOPOLOGY_2_CONTROL_POINT_PATCHLIST = 34,
            D3D_PRIMITIVE_TOPOLOGY_3_CONTROL_POINT_PATCHLIST = 35,
            D3D_PRIMITIVE_TOPOLOGY_4_CONTROL_POINT_PATCHLIST = 36,
            D3D_PRIMITIVE_TOPOLOGY_5_CONTROL_POINT_PATCHLIST = 37,
            D3D_PRIMITIVE_TOPOLOGY_6_CONTROL_POINT_PATCHLIST = 38,
            D3D_PRIMITIVE_TOPOLOGY_7_CONTROL_POINT_PATCHLIST = 39,
            D3D_PRIMITIVE_TOPOLOGY_8_CONTROL_POINT_PATCHLIST = 40,
            D3D_PRIMITIVE_TOPOLOGY_9_CONTROL_POINT_PATCHLIST = 41,
            D3D_PRIMITIVE_TOPOLOGY_10_CONTROL_POINT_PATCHLIST = 42,
            D3D_PRIMITIVE_TOPOLOGY_11_CONTROL_POINT_PATCHLIST = 43,
            D3D_PRIMITIVE_TOPOLOGY_12_CONTROL_POINT_PATCHLIST = 44,
            D3D_PRIMITIVE_TOPOLOGY_13_CONTROL_POINT_PATCHLIST = 45,
            D3D_PRIMITIVE_TOPOLOGY_14_CONTROL_POINT_PATCHLIST = 46,
            D3D_PRIMITIVE_TOPOLOGY_15_CONTROL_POINT_PATCHLIST = 47,
            D3D_PRIMITIVE_TOPOLOGY_16_CONTROL_POINT_PATCHLIST = 48,
            D3D_PRIMITIVE_TOPOLOGY_17_CONTROL_POINT_PATCHLIST = 49,
            D3D_PRIMITIVE_TOPOLOGY_18_CONTROL_POINT_PATCHLIST = 50,
            D3D_PRIMITIVE_TOPOLOGY_19_CONTROL_POINT_PATCHLIST = 51,
            D3D_PRIMITIVE_TOPOLOGY_20_CONTROL_POINT_PATCHLIST = 52,
            D3D_PRIMITIVE_TOPOLOGY_21_CONTROL_POINT_PATCHLIST = 53,
            D3D_PRIMITIVE_TOPOLOGY_22_CONTROL_POINT_PATCHLIST = 54,
            D3D_PRIMITIVE_TOPOLOGY_23_CONTROL_POINT_PATCHLIST = 55,
            D3D_PRIMITIVE_TOPOLOGY_24_CONTROL_POINT_PATCHLIST = 56,
            D3D_PRIMITIVE_TOPOLOGY_25_CONTROL_POINT_PATCHLIST = 57,
            D3D_PRIMITIVE_TOPOLOGY_26_CONTROL_POINT_PATCHLIST = 58,
            D3D_PRIMITIVE_TOPOLOGY_27_CONTROL_POINT_PATCHLIST = 59,
            D3D_PRIMITIVE_TOPOLOGY_28_CONTROL_POINT_PATCHLIST = 60,
            D3D_PRIMITIVE_TOPOLOGY_29_CONTROL_POINT_PATCHLIST = 61,
            D3D_PRIMITIVE_TOPOLOGY_30_CONTROL_POINT_PATCHLIST = 62,
            D3D_PRIMITIVE_TOPOLOGY_31_CONTROL_POINT_PATCHLIST = 63,
            D3D_PRIMITIVE_TOPOLOGY_32_CONTROL_POINT_PATCHLIST = 64,
            D3D10_PRIMITIVE_TOPOLOGY_UNDEFINED,
            D3D10_PRIMITIVE_TOPOLOGY_POINTLIST,
            D3D10_PRIMITIVE_TOPOLOGY_LINELIST,
            D3D10_PRIMITIVE_TOPOLOGY_LINESTRIP,
            D3D10_PRIMITIVE_TOPOLOGY_TRIANGLELIST,
            D3D10_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP,
            D3D10_PRIMITIVE_TOPOLOGY_LINELIST_ADJ,
            D3D10_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ,
            D3D10_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ,
            D3D10_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ,
            D3D11_PRIMITIVE_TOPOLOGY_UNDEFINED,
            D3D11_PRIMITIVE_TOPOLOGY_POINTLIST,
            D3D11_PRIMITIVE_TOPOLOGY_LINELIST,
            D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP,
            D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST,
            D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP,
            D3D11_PRIMITIVE_TOPOLOGY_LINELIST_ADJ,
            D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ,
            D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ,
            D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ,
            D3D11_PRIMITIVE_TOPOLOGY_1_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_2_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_3_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_4_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_5_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_6_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_7_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_8_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_9_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_10_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_11_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_12_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_13_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_14_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_15_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_16_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_17_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_18_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_19_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_20_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_21_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_22_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_23_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_24_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_25_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_26_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_27_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_28_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_29_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_30_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_31_CONTROL_POINT_PATCHLIST,
            D3D11_PRIMITIVE_TOPOLOGY_32_CONTROL_POINT_PATCHLIST
        };
        public enum D3D11_TEXTURE_ADDRESS_MODE
        {
            D3D11_TEXTURE_ADDRESS_WRAP = 1,
            D3D11_TEXTURE_ADDRESS_MIRROR = 2,
            D3D11_TEXTURE_ADDRESS_CLAMP = 3,
            D3D11_TEXTURE_ADDRESS_BORDER = 4,
            D3D11_TEXTURE_ADDRESS_MIRROR_ONCE = 5,
        }
        public enum D3D11_UAV_DIMENSION
        {
            D3D11_UAV_DIMENSION_UNKNOWN = 0,
            D3D11_UAV_DIMENSION_BUFFER = 1,
            D3D11_UAV_DIMENSION_TEXTURE1D = 2,
            D3D11_UAV_DIMENSION_TEXTURE1DARRAY = 3,
            D3D11_UAV_DIMENSION_TEXTURE2D = 4,
            D3D11_UAV_DIMENSION_TEXTURE2DARRAY = 5,
            D3D11_UAV_DIMENSION_TEXTURE3D = 8,
        }
        public enum D3D11_RTV_DIMENSION
        {
            D3D11_RTV_DIMENSION_UNKNOWN = 0,
            D3D11_RTV_DIMENSION_BUFFER = 1,
            D3D11_RTV_DIMENSION_TEXTURE1D = 2,
            D3D11_RTV_DIMENSION_TEXTURE1DARRAY = 3,
            D3D11_RTV_DIMENSION_TEXTURE2D = 4,
            D3D11_RTV_DIMENSION_TEXTURE2DARRAY = 5,
            D3D11_RTV_DIMENSION_TEXTURE2DMS = 6,
            D3D11_RTV_DIMENSION_TEXTURE2DMSARRAY = 7,
            D3D11_RTV_DIMENSION_TEXTURE3D = 8,
        }
        public enum D3D11_STENCIL_OP
        {
            D3D11_STENCIL_OP_KEEP = 1,
            D3D11_STENCIL_OP_ZERO = 2,
            D3D11_STENCIL_OP_REPLACE = 3,
            D3D11_STENCIL_OP_INCR_SAT = 4,
            D3D11_STENCIL_OP_DECR_SAT = 5,
            D3D11_STENCIL_OP_INVERT = 6,
            D3D11_STENCIL_OP_INCR = 7,
            D3D11_STENCIL_OP_DECR = 8,
        }
        public enum D3D11_RESOURCE_DIMENSION
        {
            D3D11_RESOURCE_DIMENSION_UNKNOWN = 0,
            D3D11_RESOURCE_DIMENSION_BUFFER = 1,
            D3D11_RESOURCE_DIMENSION_TEXTURE1D = 2,
            D3D11_RESOURCE_DIMENSION_TEXTURE2D = 3,
            D3D11_RESOURCE_DIMENSION_TEXTURE3D = 4,
        }
        public enum D3D11_FILTER
        {
            D3D11_FILTER_MIN_MAG_MIP_POINT = 0x0,
            D3D11_FILTER_MIN_MAG_POINT_MIP_LINEAR = 0x1,
            D3D11_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x4,
            D3D11_FILTER_MIN_POINT_MAG_MIP_LINEAR = 0x5,
            D3D11_FILTER_MIN_LINEAR_MAG_MIP_POINT = 0x10,
            D3D11_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x11,
            D3D11_FILTER_MIN_MAG_LINEAR_MIP_POINT = 0x14,
            D3D11_FILTER_MIN_MAG_MIP_LINEAR = 0x15,
            D3D11_FILTER_ANISOTROPIC = 0x55,
            D3D11_FILTER_COMPARISON_MIN_MAG_MIP_POINT = 0x80,
            D3D11_FILTER_COMPARISON_MIN_MAG_POINT_MIP_LINEAR = 0x81,
            D3D11_FILTER_COMPARISON_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x84,
            D3D11_FILTER_COMPARISON_MIN_POINT_MAG_MIP_LINEAR = 0x85,
            D3D11_FILTER_COMPARISON_MIN_LINEAR_MAG_MIP_POINT = 0x90,
            D3D11_FILTER_COMPARISON_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x91,
            D3D11_FILTER_COMPARISON_MIN_MAG_LINEAR_MIP_POINT = 0x94,
            D3D11_FILTER_COMPARISON_MIN_MAG_MIP_LINEAR = 0x95,
            D3D11_FILTER_COMPARISON_ANISOTROPIC = 0xd5,
            D3D11_FILTER_MINIMUM_MIN_MAG_MIP_POINT = 0x100,
            D3D11_FILTER_MINIMUM_MIN_MAG_POINT_MIP_LINEAR = 0x101,
            D3D11_FILTER_MINIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x104,
            D3D11_FILTER_MINIMUM_MIN_POINT_MAG_MIP_LINEAR = 0x105,
            D3D11_FILTER_MINIMUM_MIN_LINEAR_MAG_MIP_POINT = 0x110,
            D3D11_FILTER_MINIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x111,
            D3D11_FILTER_MINIMUM_MIN_MAG_LINEAR_MIP_POINT = 0x114,
            D3D11_FILTER_MINIMUM_MIN_MAG_MIP_LINEAR = 0x115,
            D3D11_FILTER_MINIMUM_ANISOTROPIC = 0x155,
            D3D11_FILTER_MAXIMUM_MIN_MAG_MIP_POINT = 0x180,
            D3D11_FILTER_MAXIMUM_MIN_MAG_POINT_MIP_LINEAR = 0x181,
            D3D11_FILTER_MAXIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x184,
            D3D11_FILTER_MAXIMUM_MIN_POINT_MAG_MIP_LINEAR = 0x185,
            D3D11_FILTER_MAXIMUM_MIN_LINEAR_MAG_MIP_POINT = 0x190,
            D3D11_FILTER_MAXIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x191,
            D3D11_FILTER_MAXIMUM_MIN_MAG_LINEAR_MIP_POINT = 0x194,
            D3D11_FILTER_MAXIMUM_MIN_MAG_MIP_LINEAR = 0x195,
            D3D11_FILTER_MAXIMUM_ANISOTROPIC = 0x1d5,
        }
        public enum D3D11_BLEND
        {
            D3D11_BLEND_ZERO = 1,
            D3D11_BLEND_ONE = 2,
            D3D11_BLEND_SRC_COLOR = 3,
            D3D11_BLEND_INV_SRC_COLOR = 4,
            D3D11_BLEND_SRC_ALPHA = 5,
            D3D11_BLEND_INV_SRC_ALPHA = 6,
            D3D11_BLEND_DEST_ALPHA = 7,
            D3D11_BLEND_INV_DEST_ALPHA = 8,
            D3D11_BLEND_DEST_COLOR = 9,
            D3D11_BLEND_INV_DEST_COLOR = 10,
            D3D11_BLEND_SRC_ALPHA_SAT = 11,
            D3D11_BLEND_BLEND_FACTOR = 14,
            D3D11_BLEND_INV_BLEND_FACTOR = 15,
            D3D11_BLEND_SRC1_COLOR = 16,
            D3D11_BLEND_INV_SRC1_COLOR = 17,
            D3D11_BLEND_SRC1_ALPHA = 18,
            D3D11_BLEND_INV_SRC1_ALPHA = 19,
        }
        public enum D3D11_BLEND_OP
        {
            D3D11_BLEND_OP_ADD = 1,
            D3D11_BLEND_OP_SUBTRACT = 2,
            D3D11_BLEND_OP_REV_SUBTRACT = 3,
            D3D11_BLEND_OP_MIN = 4,
            D3D11_BLEND_OP_MAX = 5,
        }
        public enum D3D11_INPUT_CLASSIFICATION
        {
            D3D11_INPUT_PER_VERTEX_DATA = 0,
            D3D11_INPUT_PER_INSTANCE_DATA = 1,
        }
        public enum D3D11_MAP
        {
            D3D11_MAP_READ = 1,
            D3D11_MAP_WRITE = 2,
            D3D11_MAP_READ_WRITE = 3,
            D3D11_MAP_WRITE_DISCARD = 4,
            D3D11_MAP_WRITE_NO_OVERWRITE = 5,
        }
        public enum D3D11_DEPTH_WRITE_MASK
        {
            D3D11_DEPTH_WRITE_MASK_ZERO = 0,
            D3D11_DEPTH_WRITE_MASK_ALL = 1,
        }
        public enum D3D11_DSV_DIMENSION
        {
            D3D11_DSV_DIMENSION_UNKNOWN = 0,
            D3D11_DSV_DIMENSION_TEXTURE1D = 1,
            D3D11_DSV_DIMENSION_TEXTURE1DARRAY = 2,
            D3D11_DSV_DIMENSION_TEXTURE2D = 3,
            D3D11_DSV_DIMENSION_TEXTURE2DARRAY = 4,
            D3D11_DSV_DIMENSION_TEXTURE2DMS = 5,
            D3D11_DSV_DIMENSION_TEXTURE2DMSARRAY = 6,
        }
        public enum D3D11_FEATURE
        {
            D3D11_FEATURE_THREADING = 0,
            D3D11_FEATURE_DOUBLES = 1,
            D3D11_FEATURE_FORMAT_SUPPORT = 2,
            D3D11_FEATURE_FORMAT_SUPPORT2 = 3,
            D3D11_FEATURE_D3D10_X_HARDWARE_OPTIONS = 4,
            D3D11_FEATURE_D3D11_OPTIONS = 5,
            D3D11_FEATURE_ARCHITECTURE_INFO = 6,
            D3D11_FEATURE_D3D9_OPTIONS = 7,
            D3D11_FEATURE_SHADER_MIN_PRECISION_SUPPORT = 8,
            D3D11_FEATURE_D3D9_SHADOW_SUPPORT = 9,
            D3D11_FEATURE_D3D11_OPTIONS1 = 10,
            D3D11_FEATURE_D3D9_SIMPLE_INSTANCING_SUPPORT = 11,
            D3D11_FEATURE_MARKER_SUPPORT = 12,
            D3D11_FEATURE_D3D9_OPTIONS1 = 13,
            D3D11_FEATURE_D3D11_OPTIONS2 = 14,
            D3D11_FEATURE_D3D11_OPTIONS3 = 15,
            D3D11_FEATURE_GPU_VIRTUAL_ADDRESS_SUPPORT = 16,
            D3D11_FEATURE_D3D11_OPTIONS4 = 17,
            D3D11_FEATURE_SHADER_CACHE = 18,
            D3D11_FEATURE_D3D11_OPTIONS5 = 19,
        }
        public enum D3D11_COMPARISON_FUNC
        {
            D3D11_COMPARISON_NEVER = 1,
            D3D11_COMPARISON_LESS = 2,
            D3D11_COMPARISON_EQUAL = 3,
            D3D11_COMPARISON_LESS_EQUAL = 4,
            D3D11_COMPARISON_GREATER = 5,
            D3D11_COMPARISON_NOT_EQUAL = 6,
            D3D11_COMPARISON_GREATER_EQUAL = 7,
            D3D11_COMPARISON_ALWAYS = 8,
        }
        public enum D3D11_COUNTER
        {
            D3D11_COUNTER_DEVICE_DEPENDENT_0 = 0x40000000,
        }
        public enum D3D11_COUNTER_TYPE
        {
            D3D11_COUNTER_TYPE_FLOAT32 = 0,
            D3D11_COUNTER_TYPE_UINT16 = 1,
            D3D11_COUNTER_TYPE_UINT32 = 2,
            D3D11_COUNTER_TYPE_UINT64 = 3,
        }
        public enum D3D11_FILL_MODE
        {
            D3D11_FILL_WIREFRAME = 2,
            D3D11_FILL_SOLID = 3,
        }
        public enum D3D11_CULL_MODE
        {
            D3D11_CULL_NONE = 1,
            D3D11_CULL_FRONT = 2,
            D3D11_CULL_BACK = 3,
        }
        public enum D3D11_QUERY
        {
            D3D11_QUERY_EVENT = 0,
            D3D11_QUERY_OCCLUSION = 1,
            D3D11_QUERY_TIMESTAMP = 2,
            D3D11_QUERY_TIMESTAMP_DISJOINT = 3,
            D3D11_QUERY_PIPELINE_STATISTICS = 4,
            D3D11_QUERY_OCCLUSION_PREDICATE = 5,
            D3D11_QUERY_SO_STATISTICS = 6,
            D3D11_QUERY_SO_OVERFLOW_PREDICATE = 7,
            D3D11_QUERY_SO_STATISTICS_STREAM0 = 8,
            D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM0 = 9,
            D3D11_QUERY_SO_STATISTICS_STREAM1 = 10,
            D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM1 = 11,
            D3D11_QUERY_SO_STATISTICS_STREAM2 = 12,
            D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM2 = 13,
            D3D11_QUERY_SO_STATISTICS_STREAM3 = 14,
            D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM3 = 15,
        }
        public enum D3D11_DEVICE_CONTEXT_TYPE
        {
            D3D11_DEVICE_CONTEXT_IMMEDIATE = 0,
            D3D11_DEVICE_CONTEXT_DEFERRED = 1,
        }
    }
}
