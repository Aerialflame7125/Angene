using System.Runtime.InteropServices;
using static Angene.Windows.D3D11.D3D11Interop;
using static Angene.Windows.Dxgi.DxgiEnums;
using static Angene.Windows.WindowManagement;

namespace Angene.Windows.D3D11
{
    public interface ID3D11DeviceContext
    {
        [PreserveSig]
        public void VSSetConstantBuffers(uint StartSlot, uint NumBuffers, ref ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        public void PSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        public void PSSetShader(ref ID3D11PixelShader pPixelShader, ref ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        public void PSSetSamplers(uint StartSlot, uint NumSamplers, ref ID3D11SamplerState ppSamplers);
        [PreserveSig]
        public void VSSetShader(ref ID3D11VertexShader pVertexShader, ref ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        public void DrawIndexed(uint IndexCount, uint StartIndexLocation, int BaseVertexLocation);
        [PreserveSig]
        public void Draw(uint VertexCount, uint StartVertexLocation);
        [PreserveSig]
        public void Map(ref ID3D11Resource pResource, uint Subresource, ref D3D11_MAP MapType, uint MapFlags, out D3D11_MAPPED_SUBRESOURCE pMappedResource);
        [PreserveSig]
        public void Unmap(ref ID3D11Resource pResource, uint Subresource);
        [PreserveSig]
        public void PSSetConstantBuffers(uint StartSlot, uint NumBuffers, ref ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        public void IASetInputLayout(ref ID3D11InputLayout pInputLayout);
        [PreserveSig]
        public void IASetVertexBuffers(uint StartSlot, uint NumBuffers, ref ID3D11Buffer ppVertexBuffers, uint pStrides, uint pOffsets);
        [PreserveSig]
        public void IASetIndexBuffer(ref ID3D11Buffer pIndexBuffer, ref DXGI_FORMAT Format, uint Offset);
        [PreserveSig]
        public void DrawIndexedInstanced(uint IndexCountPerInstance, uint InstanceCount, uint StartIndexLocation, uint BaseVertexLocation, uint StartInstanceLocation);
        [PreserveSig]
        public void DrawInstanced(uint VertexCountPerInstance, uint InstanceCount, uint StartVertexLocation, uint StartInstanceLocation);
        [PreserveSig]
        public void GSSetConstantBuffers(uint StartSlot, uint NumBuffers, ref ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        public void GSSetShader(ref ID3D11GeometryShader pShader, ref ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        public void IASetPrimitiveTopology(ref D3D11_PRIMITIVE_TOPOLOGY Topology);
        [PreserveSig]
        public void VSSetShaderResources(uint StartSlot, uint NumViews, ref ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        public void VSSetSamplers(uint StartSlot, uint NumSamplers, ref ID3D11SamplerState ppSamplers);
        [PreserveSig]
        public void Begin(ref ID3D11Asynchronous pAsync);
        [PreserveSig]
        public void End(ref ID3D11Asynchronous pAsync);
        [PreserveSig]
        public int GetData(ref ID3D11Asynchronous pAsync, out IntPtr pData, uint DataSize, uint GetDataFlags);
        [PreserveSig]
        public void SetPredication(ref ID3D11Predicate pPredicate, bool PredicateValue);
        [PreserveSig]
        public void GSSetShaderResources(uint StartSlot, uint NumViews, ref ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        public void GSSetSamplers(uint StartSlot, uint NumSamplers, ref ID3D11SamplerState ppSamplers);
        [PreserveSig]
        public void OMSetRenderTargets(IntPtr pContext, uint NumViews, ref IntPtr pRenderTargetView, IntPtr pDepthStencilView);
        [PreserveSig]
        public void OMSetRenderTargetsAndUnorderedAccessViews(uint NumRTVs, ref ID3D11RenderTargetView ppRenderTargetViews, ref ID3D11DepthStencilView pDepthStencilView, uint UAVStartSlot, uint NumUAVs, ref ID3D11UnorderedAccessView ppUnorderedAccessViews, uint pUAVInitialCounts);
        [PreserveSig]
        public void OMSetBlendState(ref ID3D11BlendState pBlendState, float[] BlendFactor, uint SampleMask);
        [PreserveSig]
        public void OMGetDepthStencilState(out ID3D11DepthStencilState ppDepthStencilState, out uint pStencilRef);
        [PreserveSig]
        public void SOSetTargets(uint NumBuffers, ref ID3D11Buffer[] ppSOTargets, uint[] pOffsets);
        [PreserveSig]
        public void DrawAuto();
        [PreserveSig]
        public void DrawIndexedInstancedIndirect(ref ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);
        [PreserveSig]
        public void DrawInstancedIndirect(ref ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);
        [PreserveSig]
        public void Dispatch(uint ThreadGroupCountX, uint ThreadGroupCountY, uint ThreadGroupCountZ);
        [PreserveSig]
        public void DispatchIndirect(ref ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);
        [PreserveSig]
        public void RSSetState(ref ID3D11RasterizerState pRasterizerState);
        [PreserveSig]
        public void RSSetViewports(uint NumViewports, ref D3D11.D3D11_VIEWPORT[] pViewports);
        [PreserveSig]
        public void RSSetScissorRects(uint NumRects, RECT[] pRects);
        [PreserveSig]
        public void CopySubresourceRegion(ref ID3D11Resource pDstResource, uint DstSubresource, uint DstX, uint DstY, uint DstZ, ref ID3D11Resource pSrcResource, uint SrcSubresource, ref D3D11_BOX pSrcBox);
        [PreserveSig]
        public void CopyResource(ref ID3D11Resource pDstResource, ref ID3D11Resource pSrcResource);
        [PreserveSig]
        public void UpdateSubresource(ID3D11Resource pDstResource, uint DstSubresource, ref D3D11_BOX pDstBox, [MarshalAs(UnmanagedType.IUnknown)] IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch);
        [PreserveSig]
        public void CopyStructureCount(ref ID3D11Buffer pDstBuffer, uint DstAlignedByteOffset, ref ID3D11UnorderedAccessView pSrcView);
        [PreserveSig]
        public void ClearRenderTargetView(ref ID3D11RenderTargetView pRenderTargetView, float[] ColorRGBA);
        [PreserveSig]
        public void ClearUnorderedAccessViewUint(ref ID3D11UnorderedAccessView pUnorderedAccessView, uint[] values);
        [PreserveSig]
        public void ClearUnorderedAccessViewFloat(ref ID3D11UnorderedAccessView pUnorderedAccessView, float[] Values);
        [PreserveSig]
        public void ClearDepthStencilView(ref ID3D11DepthStencilView pDepthStencilView, uint ClearFlags, float Depth, uint Stencil);
        [PreserveSig]
        public void GenerateMips(ID3D11ShaderResourceView pShaderResourceView);
        [PreserveSig]
        public void SetResourceMinLOD(ref ID3D11Resource pResource, float MinLOD);
        [PreserveSig]
        public float GetResourceMinLOD(ID3D11Resource pResource);
        [PreserveSig]
        public void ResolveSubresource(ref ID3D11Resource pDstResource, uint DstSubResource, ref ID3D11Resource pSrcResource, uint SrcSubresource, ref DXGI_FORMAT Format);
        [PreserveSig]
        public void ExecuteCommandList(ref ID3D11CommandList pCommandList, bool RestoreContextState);
        [PreserveSig]
        public void HSSetShaderResources(uint StartSlot, uint NumViews, ref ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        public void HSSetShader(ref ID3D11HullShader pHullShader, ref ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        public void HSSetSamplers(uint StartSlot, uint NumSamplers, ref ID3D11SamplerState ppSamplers);
        [PreserveSig]
        public void HSSetConstantBuffers(uint StartSlot, uint NumBuffers, ref ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        public void DSSetShaderResources(uint StartSlot, uint NumViews, ref ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        public void DSSetShader(ref ID3D11DomainShader pDomainShader, ref ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        public void DSSetSamplers(uint StartSlot, uint NumSamplers, ref ID3D11SamplerState ppSamplers);
        [PreserveSig]
        public void DSSetConstantBuffers(uint StartSlot, uint NumBuffers, ref ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        public void CSSetShaderResources(uint StartSlot, uint NumViews, ref ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        public void CSSetUnorderedAccessViews(uint StartSlot, uint NumUAVs, ref ID3D11UnorderedAccessView ppUnorderedAccessViews, uint pUAVInitialCounts);
        [PreserveSig]
        public void CSSetShader(ref ID3D11ComputeShader pComputeShader, ref ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        public void CSSetSamplers(uint StartSlot, uint NumSamplers, ID3D11SamplerState ppSamplers);
        [PreserveSig]
        public void CSSetConstantBuffers(uint StartSlot, uint NumBuffers, ref ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        public void VSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        public void PSSetShaderResources(uint StartSlot, uint NumViews, ref ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        public void PSGetShader(out ID3D11PixelShader ppPixelShader, out ID3D11ClassInstance ppClassInstances, out uint pNumClassInstances);
        [PreserveSig]
        public void PSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        public void VSGetShader(out ID3D11VertexShader ppVertexShader, out ID3D11ClassInstance ppClassInstances, out uint pNumClassInstances);
        [PreserveSig]
        public void PSGetConstantBuffers(uint StartSlot, uint NumBuffers, ref ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        public void IAGetInputLayout(out ID3D11InputLayout ppInputLayout);
        [PreserveSig]
        public void IAGetVertexBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppVertexBuffers, out uint[] pStrides, out uint[] pOffsets);
        [PreserveSig]
        public void IAGetIndexBuffer(out ID3D11Buffer pIndexBuffer, out DXGI_FORMAT Format, out uint Offset);
        [PreserveSig]
        public void GSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        public void GSGetShader(out ID3D11GeometryShader ppGeometryShader, out ID3D11ClassInstance ppClassInstances, out uint pNumClassInstances);
        [PreserveSig]
        public void IAGetPrimitiveTopology(out D3D11_PRIMITIVE_TOPOLOGY pTopology);
        [PreserveSig]
        public void VSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        public void VSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        public void GetPredication(out ID3D11Predicate ppPredicate, bool pPredicateValue);
        [PreserveSig]
        public void GSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        public void GSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        public void OMGetRenderTargets(uint NumViews, out ID3D11RenderTargetView ppRenderTargetViews, out ID3D11DepthStencilView ppDepthStencilView);
        [PreserveSig]
        public void OMGetRenderTargetsAndUnorderedAccessViews(uint NumRTVs, out ID3D11RenderTargetView ppRenderTargetViews, out ID3D11DepthStencilView ppDepthStencilView, uint UAVStartSlot, uint NumUAVs, out ID3D11UnorderedAccessView ppUnorderedAccessViews);
        [PreserveSig]
        public void OMGetBlendState(out ID3D11BlendState ppBlendState, out float[] BlendFactor, out uint pSampleMask);
        [PreserveSig]
        public void OMSetDepthStencilState(ref ID3D11DepthStencilState pDepthStencilState, uint StencilRef);
        [PreserveSig]
        public void SOGetTargets(uint NumBuffers, out ID3D11Buffer ppSOTargets);
        [PreserveSig]
        public void RSGetState(out ID3D11RasterizerState ppRasterizerState);
        [PreserveSig]
        public void RSGetViewports(out uint pNumViewports, out D3D11.D3D11_VIEWPORT[] pViewports);
        [PreserveSig]
        public void RSGetScissorRects(out uint pNumRects, out RECT[] pRects);
        [PreserveSig]
        public void HSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        public void HSGetShader(out ID3D11HullShader ppHullShader, out ID3D11ClassInstance ppClassInstances, out uint pNumClassInstances);
        [PreserveSig]
        public void HSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        public void HSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        public void DSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        public void DSGetShader(out ID3D11DomainShader ppDomainShader, out ID3D11ClassInstance ppClassInstances, out uint pNumClassInstances);
        [PreserveSig]
        public void DSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        public void DSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        public void CSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        public void CSGetUnorderedAccessViews(uint StartSlot, uint NumUAVs, out ID3D11UnorderedAccessView ID3D11UnorderedAccessViews);
        [PreserveSig]
        public void CSGetShader(out ID3D11ComputeShader ppComputeShader, out ID3D11ClassInstance ppClassInstances, out uint pNumClassInstances);
        [PreserveSig]
        public void CSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        public void CSGetSamplers(uint StartSlot, uint NumBuffers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        public void ClearState();
        [PreserveSig]
        public void Flush();
        [PreserveSig]
        D3D11_DEVICE_CONTEXT_TYPE GetType();
        [PreserveSig]
        public uint GetContextFlags();
        [PreserveSig]
        public int FinishCommandList(bool RestoreDeferredContextState, out ID3D11CommandList ppCommandList);
        /*** DEVICECHILD ***/
        [PreserveSig]
        public void GetDevice(out IntPtr ppDevice);
        [PreserveSig]
        public void GetPrivateData(ref Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        public void SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        public void SetPrivateDataInterface(ref Guid guid, [MarshalAs(UnmanagedType.IUnknown)] object pData);
    }
}
