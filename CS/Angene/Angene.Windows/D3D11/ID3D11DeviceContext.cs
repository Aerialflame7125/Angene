using System.Runtime.InteropServices;
using static Angene.Windows.Dxgi.DxgiEnums;
using static Angene.Windows.WindowManagement;

namespace Angene.Windows.D3D11
{
    public interface ID3D11DeviceContext
    {
        [PreserveSig]
        void VSSetConstantBuffers(uint StartSlot, uint NumBuffers, ref ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void PSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void PSSetShader(ref ID3D11PixelShader pPixelShader, ref ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        void PSSetSamplers(uint StartSlot, uint NumSamplers, ref ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void VSSetShader(ref ID3D11VertexShader pVertexShader, ref ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        void DrawIndexed(uint IndexCount, uint StartIndexLocation, int BaseVertexLocation);
        [PreserveSig]
        void Draw(uint VertexCount, uint StartVertexLocation);
        [PreserveSig]
        void Map(ref ID3D11Resource pResource, uint Subresource, ref D3D11_MAP MapType, uint MapFlags, out D3D11_MAPPED_SUBRESOURCE pMappedResource);
        [PreserveSig]
        void Unmap(ref ID3D11Resource pResource, uint Subresource);
        [PreserveSig]
        void PSSetConstantBuffers(uint StartSlot, uint NumBuffers, ref ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void IASetInputLayout(ref ID3D11InputLayout pInputLayout);
        [PreserveSig]
        void IASetVertexBuffers(uint StartSlot, uint NumBuffers, ref ID3D11Buffer ppVertexBuffers, uint pStrides, uint pOffsets);
        [PreserveSig]
        void IASetIndexBuffer(ref ID3D11Buffer pIndexBuffer, ref DXGI_FORMAT Format, uint Offset);
        [PreserveSig]
        void DrawIndexedInstanced(uint IndexCountPerInstance, uint InstanceCount, uint StartIndexLocation, uint BaseVertexLocation, uint StartInstanceLocation);
        [PreserveSig]
        void DrawInstanced(uint VertexCountPerInstance, uint InstanceCount, uint StartVertexLocation, uint StartInstanceLocation);
        [PreserveSig]
        void GSSetConstantBuffers(uint StartSlot, uint NumBuffers, ref ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void GSSetShader(ref ID3D11GeometryShader pShader, ref ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        void IASetPrimitiveTopology(ref D3D11_PRIMITIVE_TOPOLOGY Topology);
        [PreserveSig]
        void VSSetShaderResources(uint StartSlot, uint NumViews, ref ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void VSSetSamplers(uint StartSlot, uint NumSamplers, ref ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void Begin(ref ID3D11Asynchronous pAsync);
        [PreserveSig]
        void End(ref ID3D11Asynchronous pAsync);
        [PreserveSig]
        int GetData(ref ID3D11Asynchronous pAsync, out IntPtr pData, uint DataSize, uint GetDataFlags);
        [PreserveSig]
        void SetPredication(ref ID3D11Predicate pPredicate, bool PredicateValue);
        [PreserveSig]
        void GSSetShaderResources(uint StartSlot, uint NumViews, ref ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void GSSetSamplers(uint StartSlot, uint NumSamplers, ref ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void OMSetRenderTargets(uint NumViews, ref ID3D11RenderTargetView ppRenderTargetViews, ref ID3D11DepthStencilView pDepthStencilView);
        [PreserveSig]
        void OMSetRenderTargetsAndUnorderedAccessViews(uint NumRTVs, ref ID3D11RenderTargetView ppRenderTargetViews, ref ID3D11DepthStencilView pDepthStencilView, uint UAVStartSlot, uint NumUAVs, ref ID3D11UnorderedAccessView ppUnorderedAccessViews, uint pUAVInitialCounts);
        [PreserveSig]
        void OMSetBlendState(ref ID3D11BlendState pBlendState, float[] BlendFactor, uint SampleMask);
        [PreserveSig]
        void OMGetDepthStencilState(out ID3D11DepthStencilState ppDepthStencilState, out uint pStencilRef);
        [PreserveSig]
        void SOSetTargets(uint NumBuffers, ref ID3D11Buffer[] ppSOTargets, uint[] pOffsets);
        [PreserveSig]
        void DrawAuto();
        [PreserveSig]
        void DrawIndexedInstancedIndirect(ref ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);
        [PreserveSig]
        void DrawInstancedIndirect(ref ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);
        [PreserveSig]
        void Dispatch(uint ThreadGroupCountX, uint ThreadGroupCountY, uint ThreadGroupCountZ);
        [PreserveSig]
        void DispatchIndirect(ref ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);
        [PreserveSig]
        void RSSetState(ref ID3D11RasterizerState pRasterizerState);
        [PreserveSig]
        void RSSetViewports(uint NumViewports, ref D3D11.D3D11_VIEWPORT[] pViewports);
        [PreserveSig]
        void RSSetScissorRects(uint NumRects, RECT[] pRects);
        [PreserveSig]
        void CopySubresourceRegion(ref ID3D11Resource pDstResource, uint DstSubresource, uint DstX, uint DstY, uint DstZ, ref ID3D11Resource pSrcResource, uint SrcSubresource, ref D3D11_BOX pSrcBox);
        [PreserveSig]
        void CopyResource(ref ID3D11Resource pDstResource, ref ID3D11Resource pSrcResource);
        [PreserveSig]
        void UpdateSubresource(ID3D11Resource pDstResource, uint DstSubresource, ref D3D11_BOX pDstBox, [MarshalAs(UnmanagedType.IUnknown)] IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch);
        [PreserveSig]
        void CopyStructureCount(ref ID3D11Buffer pDstBuffer, uint DstAlignedByteOffset, ref ID3D11UnorderedAccessView pSrcView);
        [PreserveSig]
        void ClearRenderTargetView(ref ID3D11RenderTargetView pRenderTargetView, float[] ColorRGBA);
        [PreserveSig]
        void ClearUnorderedAccessViewUint(ref ID3D11UnorderedAccessView pUnorderedAccessView, uint[] values);
        [PreserveSig]
        void ClearUnorderedAccessViewFloat(ref ID3D11UnorderedAccessView pUnorderedAccessView, float[] Values);
        [PreserveSig]
        void ClearDepthStencilView(ref ID3D11DepthStencilView pDepthStencilView, uint ClearFlags, float Depth, uint Stencil);
        [PreserveSig]
        void GenerateMips(ID3D11ShaderResourceView pShaderResourceView);
        [PreserveSig]
        void SetResourceMinLOD(ref ID3D11Resource pResource, float MinLOD);
        [PreserveSig]
        float GetResourceMinLOD(ID3D11Resource pResource);
        [PreserveSig]
        void ResolveSubresource(ref ID3D11Resource pDstResource, uint DstSubResource, ref ID3D11Resource pSrcResource, uint SrcSubresource, ref DXGI_FORMAT Format);
        [PreserveSig]
        void ExecuteCommandList(ref ID3D11CommandList pCommandList, bool RestoreContextState);
        [PreserveSig]
        void HSSetShaderResources(uint StartSlot, uint NumViews, ref ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void HSSetShader(ref ID3D11HullShader pHullShader, ref ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        void HSSetSamplers(uint StartSlot, uint NumSamplers, ref ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void HSSetConstantBuffers(uint StartSlot, uint NumBuffers, ref ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void DSSetShaderResources(uint StartSlot, uint NumViews, ref ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void DSSetShader(ref ID3D11DomainShader pDomainShader, ref ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        void DSSetSamplers(uint StartSlot, uint NumSamplers, ref ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void DSSetConstantBuffers(uint StartSlot, uint NumBuffers, ref ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void CSSetShaderResources(uint StartSlot, uint NumViews, ref ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void CSSetUnorderedAccessViews(uint StartSlot, uint NumUAVs, ref ID3D11UnorderedAccessView ppUnorderedAccessViews, uint pUAVInitialCounts);
        [PreserveSig]
        void CSSetShader(ref ID3D11ComputeShader pComputeShader, ref ID3D11ClassInstance ppClassInstances, uint NumClassInstances);
        [PreserveSig]
        void CSSetSamplers(uint StartSlot, uint NumSamplers, ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void CSSetConstantBuffers(uint StartSlot, uint NumBuffers, ref ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void VSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void PSSetShaderResources(uint StartSlot, uint NumViews, ref ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void PSGetShader(out ID3D11PixelShader ppPixelShader, out ID3D11ClassInstance ppClassInstances, out uint pNumClassInstances);
        [PreserveSig]
        void PSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void VSGetShader(out ID3D11VertexShader ppVertexShader, out ID3D11ClassInstance ppClassInstances, out uint pNumClassInstances);
        [PreserveSig]
        void PSGetConstantBuffers(uint StartSlot, uint NumBuffers, ref ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void IAGetInputLayout(out ID3D11InputLayout ppInputLayout);
        [PreserveSig]
        void IAGetVertexBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppVertexBuffers, out uint[] pStrides, out uint[] pOffsets);
        [PreserveSig]
        void IAGetIndexBuffer(out ID3D11Buffer pIndexBuffer, out DXGI_FORMAT Format, out uint Offset);
        [PreserveSig]
        void GSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void GSGetShader(out ID3D11GeometryShader ppGeometryShader, out ID3D11ClassInstance ppClassInstances, out uint pNumClassInstances);
        [PreserveSig]
        void IAGetPrimitiveTopology(out D3D11_PRIMITIVE_TOPOLOGY pTopology);
        [PreserveSig]
        void VSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void VSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void GetPredication(out ID3D11Predicate ppPredicate, bool pPredicateValue);
        [PreserveSig]
        void GSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void GSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void OMGetRenderTargets(uint NumViews, out ID3D11RenderTargetView ppRenderTargetViews, out ID3D11DepthStencilView ppDepthStencilView);
        [PreserveSig]
        void OMGetRenderTargetsAndUnorderedAccessViews(uint NumRTVs, out ID3D11RenderTargetView ppRenderTargetViews, out ID3D11DepthStencilView ppDepthStencilView, uint UAVStartSlot, uint NumUAVs, out ID3D11UnorderedAccessView ppUnorderedAccessViews);
        [PreserveSig]
        void OMGetBlendState(out ID3D11BlendState ppBlendState, out float[] BlendFactor, out uint pSampleMask);
        [PreserveSig]
        void OMSetDepthStencilState(ref ID3D11DepthStencilState pDepthStencilState, uint StencilRef);
        [PreserveSig]
        void SOGetTargets(uint NumBuffers, out ID3D11Buffer ppSOTargets);
        [PreserveSig]
        void RSGetState(out ID3D11RasterizerState ppRasterizerState);
        [PreserveSig]
        void RSGetViewports(out uint pNumViewports, out D3D11.D3D11_VIEWPORT[] pViewports);
        [PreserveSig]
        void RSGetScissorRects(out uint pNumRects, out RECT[] pRects);
        [PreserveSig]
        void HSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void HSGetShader(out ID3D11HullShader ppHullShader, out ID3D11ClassInstance ppClassInstances, out uint pNumClassInstances);
        [PreserveSig]
        void HSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void HSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void DSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void DSGetShader(out ID3D11DomainShader ppDomainShader, out ID3D11ClassInstance ppClassInstances, out uint pNumClassInstances);
        [PreserveSig]
        void DSGetSamplers(uint StartSlot, uint NumSamplers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void DSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void CSGetShaderResources(uint StartSlot, uint NumViews, out ID3D11ShaderResourceView ppShaderResourceViews);
        [PreserveSig]
        void CSGetUnorderedAccessViews(uint StartSlot, uint NumUAVs, out ID3D11UnorderedAccessView ID3D11UnorderedAccessViews);
        [PreserveSig]
        void CSGetShader(out ID3D11ComputeShader ppComputeShader, out ID3D11ClassInstance ppClassInstances, out uint pNumClassInstances);
        [PreserveSig]
        void CSGetConstantBuffers(uint StartSlot, uint NumBuffers, out ID3D11Buffer ppConstantBuffers);
        [PreserveSig]
        void CSGetSamplers(uint StartSlot, uint NumBuffers, out ID3D11SamplerState ppSamplers);
        [PreserveSig]
        void ClearState();
        [PreserveSig]
        void Flush();
        [PreserveSig]
        D3D11_DEVICE_CONTEXT_TYPE GetType();
        [PreserveSig]
        uint GetContextFlags();
        [PreserveSig]
        int FinishCommandList(bool RestoreDeferredContextState, out ID3D11CommandList ppCommandList);
        /*** DEVICECHILD ***/
        [PreserveSig]
        void GetDevice(out IntPtr ppDevice);
        [PreserveSig]
        void GetPrivateData(ref Guid guid, ref uint pDataSize, IntPtr pData);
        [PreserveSig]
        void SetPrivateData(ref Guid guid, uint DataSize, IntPtr pData);
        [PreserveSig]
        void SetPrivateDataInterface(ref Guid guid, [MarshalAs(UnmanagedType.IUnknown)] object pData);
    }
}
