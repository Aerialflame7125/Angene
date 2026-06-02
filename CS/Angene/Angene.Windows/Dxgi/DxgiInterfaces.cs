using System.Runtime.InteropServices;

namespace Angene.Windows.Dxgi // I noticed there was a major amount of AI generated code, so I made the entirety of DXGI myself.
{
    // I honestly don't know what i will and wont use, so why not implement all of them? ..Right?
    public class DxgiInterfaces
    {
        /* Notes:
         * # Imports interface
         * [ComImport]
         * [Guid("")]
         * [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
         * 
         * # Gets HRESULT uint/int return instead of "out" var
         * [PreserveSig]
        */


        // Adapters
        [ComImport]
        [Guid("bec2a66b-1718-4f6d-91aa-b554f21bcb6a")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIAdapter
        {
            [PreserveSig]
            uint CheckInterfaceSupport(ref Guid InterfaceName, [MarshalAs(UnmanagedType.IUnknown)] out long pUMDVersion); // If system supports device interface for a graphics component

            /// <summary>
            /// Enumerates video card outputs. "Output" is the index of the video card output, "ppOutput" is a returning output pointer of type IDXGIOutput.
            /// </summary>
            /// <param name="Output"></param>
            /// <param name="ppOutput"></param>
            /// <returns>HRESULT Uint</returns>
            [PreserveSig]
            uint EnumOutputs(uint Output, [MarshalAs(UnmanagedType.IUnknown)] out IDXGIOutput ppOutput); // Enumerate outputs (video cards)

            /// <summary>
            /// Returns a 1.0 DXGI description of an adapter. Only param is "pDesc" which is returning a type of "DXGI_ADAPTER_DESC" (a struct)
            /// </summary>
            /// <param name="pDesc"></param>
            /// <returns></returns>
            [PreserveSig]
            uint GetDesc([MarshalAs(UnmanagedType.IUnknown)] out DXGI_ADAPTER_DESC pDesc); // 1.0 description of card
        }

        [ComImport]
        [Guid("be9c48bb-3367-4c2f-a119-dc22c04bca2d")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIAdapter1 : IDXGIAdapter
        {
            [PreserveSig]
            uint GetDesc1([MarshalAs(UnmanagedType.IUnknown)] out DXGI_ADAPTER_DESC1 pDesc);
        }

        [ComImport]
        [Guid("812a9200-e209-4334-9517-8a9e8ded4721")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIAdapter2 : IDXGIAdapter1
        {
            [PreserveSig]
            uint GetDesc2(out DXGI_ADAPTER_DESC2 pDesc);
        }

        [ComImport]
        [Guid("6782722e-407a-4d2b-aaf8-5f2924c90581")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIAdapter3 : IDXGIAdapter2
        {
            [PreserveSig]
            uint QueryVideoMemoryInfo(uint NodeIndex, ref DXGI_MEMORY_SEGMENT_GROUP MemorySegmentGroup, out DXGI_QUERY_VIDEO_MEMORY_INFO pVideoMemoryInfo);
            [PreserveSig]
            uint RegisterHardwareContentProtectionTeardownStatusEvent(IntPtr hEvent, out uint pdwCookie);
            [PreserveSig]
            uint RegisterVideoMemoryBudgetChangeNotificationEvent(IntPtr hEvent, out uint pdwCookie);
            [PreserveSig]
            uint SetVideoMemoryReservation(uint NodeIndex, ref DXGI_MEMORY_SEGMENT_GROUP MemorySegmentGroup, ref UInt64 Reservation);
            [PreserveSig]
            void UnregisterHardwareContentProtectionTeardownStatus(uint dwCookie);
            [PreserveSig]
            void UnregisterVideoMemoryBudgetChangeNotification(uint dwCookie);
        }

        [ComImport]
        [Guid("0ffad788-42ab-47a8-819b-b2bda2b43eb2")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIAdapter4 : IDXGIAdapter3
        {
            [PreserveSig]
            uint GetDesc3(out DXGI_ADAPTER_DESC3 pDesc);
        }


        // Outputs
        [ComImport]
        [Guid("5d6de087-31c6-4e8d-ac4a-944614bf1c6f")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput
        {
            [PreserveSig]
            uint FindClosestMatchingMode(ref DXGI_MODE_DESC pModeToMatch, out DXGI_MODE_DESC pClosestMatch); // will fix later maybe
            
            [PreserveSig]
            uint GetDesc(out DXGI_OUTPUT_DESC pDesc);
            
            [PreserveSig]
            uint GetDisplayModeList(
                DXGI_FORMAT EnumFormat, 
                uint Flags, 
                uint pNumModes, // Listed as [in, out]
                out DXGI_MODE_DESC pDesc // Listed as optional
                );
            
            [PreserveSig]
            uint GetDisplaySurfaceData(IDXGISurface pDestination);
            
            [PreserveSig]
            uint GetFrameStatistics(DXGI_FRAME_STATISTICS pStats);
            
            [PreserveSig]
            uint GetGammaControl(out DXGI_GAMMA_CONTROL pArray);
            
            [PreserveSig]
            uint GetGammaControlCapabilities(out DXGI_GAMMA_CONTROL_CAPABILITIES pGammaCaps);
            
            [PreserveSig]
            void ReleaseOwnership(); // Release ownership of output
            
            [PreserveSig]
            uint SetDisplaySurface(IDXGISurface pScanoutSurface);
            
            [PreserveSig]
            uint SetGammaControl(DXGI_GAMMA_CONTROL pArray);
            
            [PreserveSig]
            uint TakeOwnership([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, bool Exclusive);
            
            [PreserveSig]
            uint WaitForVBlank(); // Halt until next vertical blank
        }

        [ComImport]
        [Guid("33fda638-53fc-4b9d-a2eb-3e6a6fa0ba90")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput1 : IDXGIOutput
        {
            [PreserveSig]
            uint DuplicateOutput([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, out IDXGIOutputDuplication ppOutputDuplication);

            [PreserveSig] // might throw an error for an "in" after "out" specified.
            uint FindClosestMatchingMode1(DXGI_MODE_DESC1 pModeToMatch, out DXGI_MODE_DESC1 pClosestMatch, [MarshalAs(UnmanagedType.IUnknown)] IntPtr pConcernedDevice);
            
            [PreserveSig]
            uint GetDisplayModeList1(DXGI_FORMAT EnumFormat, 
                uint Flags, 
                uint pNumModes, // Listed as "[in, out]"
                out DXGI_MODE_DESC1 pDesc // Listed as optional out
            );
            
            [PreserveSig]
            uint GetDisplaySurfaceData1(IDXGIResource pDestination);
        }

        [ComImport]
        [Guid("46c98038-9765-4993-95d6-ee753ecf8e82")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput2 : IDXGIOutput1
        {
            [PreserveSig]
            bool SupportsOverlays(); // Query adapter output for multipane overlay support. (https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgioutput2-supportsoverlays)
        }

        [ComImport]
        [Guid("e09b8df3-6899-40ba-bd8f-c151842d08a0")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput3 : IDXGIOutput2 
        {
            [PreserveSig]
            uint CheckOverlaySupport(DXGI_FORMAT EnumFormat, [MarshalAs(UnmanagedType.IUnknown)] IntPtr pConcernedDevice, out uint pFlags);
        }

        [ComImport]
        [Guid("8a22c7d9-212c-4550-85ac-cda442790273")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput4 : IDXGIOutput3
        {
            [PreserveSig]
            uint CheckOverlayColorSpaceSupport(DXGI_FORMAT Format, DXGI_COLOR_SPACE_TYPE ColorSpace, [MarshalAs(UnmanagedType.IUnknown)] pConcernedDevice, out uint pFlags);
        }

        [ComImport]
        [Guid("268a2745-ce50-48a2-bf4e-33f5421d34f6")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput5 : IDXGIOutput4
        {
            [PreserveSig]
            uint DuplicateOutput1([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, uint Flags, uint SupportedFormatsCount, int DXGI_FORMAT pSupportedFormats, out IDXGIOutputDuplication ppOutputDuplication);
        }

        [ComImport]
        [Guid("166be73f-5f8b-437c-842a-a651699729b1")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput6 : IDXGIOutput5
        {
            [PreserveSig]
            uint CheckHardwareCompositionSupport(out uint pFlags);

            [PreserveSig]
            uint GetDesc1(out DXGI_OUTPUT_DESC1 pDesc);
        }


        // Factories
        [ComImport]
        [Guid("7a65c7ed-301f-4aa0-b0be-c46584b5e1a7")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory : IDXGIObject // praying this works
        {
            [PreserveSig]
            uint EnumAdapters(uint Adapter, [MarshalAs(UnmanagedType.Interface)] out IDXGIAdapter ppAdapter);

            [PreserveSig]
            uint MakeWindowAssociation(IntPtr WindowHandle, uint Flags);

            [PreserveSig]
            uint GetWindowAssociation(out IntPtr pWindowHandle);

            [PreserveSig]
            uint CreateSwapChain(
                [MarshalAs(UnmanagedType.IUnknown)] object pDevice, // D3D device
                ref DXGI_SWAP_CHAIN_DESC pDesc,
                [MarshalAs(UnmanagedType.Interface)] out IDXGISwapChain ppSwapChain);

            [PreserveSig]
            uint CreateSoftwareAdapter(IntPtr Module, [MarshalAs(UnmanagedType.Interface)] out IDXGIAdapter ppAdapter);
        }

        [ComImport]
        [Guid("5b49cc29-3b1f-4003-823d-8b6e3633cad2")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory1 : IDXGIFactory
        {
            [PreserveSig]
            uint EnumAdapters1(uint Adapter, [MarshalAs(UnmanagedType.Interface)] out IDXGIAdapter1 ppAdapter);

            [PreserveSig]
            bool IsCurrent(); // False if becoming available or adapter is going away, True if no adapter changes.
            // Also returns false to inform application to re-enumerate adapters.
        }

        [ComImport]
        [Guid("5e8b292f-f21e-4955-8b0c-0aa132a49a63")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory2 : IDXGIFactory1
        {
            [PreserveSig]
            uint CreateSwapChainForComposition([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, ref DXGI_SWAP_CHAIN_DESC1 pDesc, IDXGIOutput pRestrictToOutput, [MarshalAs(UnmanagedType.IUnknown)] IDXGISwapChain1 ppSwapChain);
            [PreserveSig]
            uint CreateSwapChainForCoreWindow([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, [MarshalAs(UnmanagedType.IUnknown)] IntPtr pWindow, ref DXGI_SWAP_CHAIN_DESC1 pDesc, IDXGIOutput pRestrictToOutput, [MarshalAs(UnmanagedType.IUnknown)] out IDXGISwapChain1 ppSwapChain);
            [PreserveSig]
            uint CreateSwapChainForHwnd([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, IntPtr hWnd, ref DXGI_SWAP_CHAIN_DESC1 pDesc, DXGI_SWAP_CHAIN_FULLSCREEN_DESC pFullScreenDesc, IDXGIOutput pRestrictToOutput, [MarshalAs(UnmanagedType.IUnknown)] out IDXGISwapChain1 ppSwapChain);
            [PreserveSig]
            uint GetSharedResourceAdapterLuid(IntPtr hResource, [MarshalAs(UnmanagedType.IUnknown)] out LUID pLuid);
            [PreserveSig]
            bool IsWindowedStereoEnabled(); // Indication of whether or not to use stereo mode.
            // True inducates you can use stereo mode, otherwise false.
            [PreserveSig]
            uint RegisterOcclusionStatusEvent(IntPtr hEvent,  out uint pdwCookie);
            [PreserveSig]
            uint RegisterOcclusionStatusWindow(IntPtr HWND, uint wMsg, [MarshalAs(UnmanagedType.IUnknown)] out uint pdwCookie);
            [PreserveSig]
            uint RegisterStereoStatusEvent(IntPtr hEvent, [MarshalAs(UnmanagedType.IUnknown)] out uint pdwCookie);
            [PreserveSig]
            uint RegisterStereoStatusWindow(IntPtr HWND, uint wMsg, [MarshalAs(UnmanagedType.IUnknown)] out uint pdwCookie);
            [PreserveSig]
            uint UnregisterOcclusionStatus(UInt32 dwCookie); // Unregisters a window or event to stop from recieving notification when occlusion status changes
            [PreserveSig]
            uint UnregisterStereoStatus(UInt32 dwCookie); // Unregisters a window or event to stop from recieving notification when stereo status changes
        }

        [ComImport]
        [Guid("d9c92741-5cd7-4d08-a2ce-f15d2ae98f91")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory3 : IDXGIFactory2
        {
            [PreserveSig]
            uint GetCreationFlags(); // Returns flags used when DXGI object was created.
        }

        [ComImport]
        [Guid("dfbe594e-56f7-4a15-9cc9-032c769c3dc8")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory4 : IDXGIFactory3
        {
            [PreserveSig]
            uint EnumAdapterByLuid(LUID AdapterLuid, ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out IntPtr ppvAdapter);
            [PreserveSig]
            uint EnumWarpAdapter(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out IntPtr ppvAdapter);
        }

        [ComImport]
        [Guid("2a342ec6-e959-49dc-bd39-0c7233e84077")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory5 : IDXGIFactory4
        {
            [PreserveSig]
            uint CheckFeatureSupport(int Feature, out D3D12_FEATURE_DATA_D3D12_OPTIONS featureSupportData, int featureSupportDataSize);
        }

        [ComImport]
        [Guid("729c4365-cd85-4bb6-961c-cfc87d2cf06c")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory6 : IDXGIFactory5
        {
            [PreserveSig]
            uint EnumAdapterByGpuPreference(uint Adapter, DXGI_GPU_PREFERENCE GpuPreference, ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] IntPtr ppvAdapter);
        }


        // Swapchains
        [ComImport]
        [Guid("d0a8576d-8cfd-4cc1-8622-81f345c85ba6")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapchain
        {
            [PreserveSig]
            uint GetBuffer(uint Buffer, ref Guid riid, out IntPtr ppSurface);
            [PreserveSig]
            uint GetContainingOutput(out IDXGIOutput ppOutput);
            [PreserveSig]
            uint GetDesc(out DXGI_SWAP_CHAIN_DESC pDesc);
            [PreserveSig]
            uint GetFrameStatistics(out DXGI_FRAME_STATISTICS pStats);
            [PreserveSig]
            uint GetFullScreenState(out bool pFullscreen, out IDXGIOutput ppTarget);
            [PreserveSig]
            uint GetLastPresetCount(out uint pLastPresentCount);
            [PreserveSig]
            uint Present(uint SyncInterval, uint Flags);
            [PreserveSig]
            uint ResizeBuffers(uint BufferCount, uint Width, uint Height, ref DXGI_FORMAT NewFormat, uint SwapChainFlags);
            [PreserveSig]
            uint ResizeTarget(ref DXGI_MODE_DESC pNewTargetParameters);
            [PreserveSig]
            uint SetFullscreenState(bool Fullscreen, ref IDXGIOutput pTarget);
        }

        [ComImport]
        [Guid("d5cde982-d515-4560-a9c4-55f2128fc808")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapchain1 : IDXGISwapchain
        {
            [PreserveSig]
            uint GetBackgroundColor(out DXGI_RGBA pColor);
            [PreserveSig]
            uint GetCoreWindow(ref Guid refiid, out IntPtr ppUnk);
            [PreserveSig]
            uint GetDesc1(out DXGI_SWAP_CHAIN_DESC1 pDesc);
            [PreserveSig]
            uint GetFullscreenDesc(out DXGI_SWAP_CHAIN_FULLSCREEN_DESC pDesc);
            [PreserveSig]
            uint GetHwnd(out IntPtr pHwnd);
            [PreserveSig]
            uint GetRestrictToOutput(out IDXGIOutput ppRestrictToOutput);
            [PreserveSig]
            uint GetRotation(out DXGI_MODE_ROTATION pRotation);
            [PreserveSig]
            bool IsTemporaryMonoSupported();
            [PreserveSig]
            uint Present1(uint SyncInterval, uint PresentFlags, ref DXGI_PRESENT_PARAMETERS pPresentParameters);
            [PreserveSig]
            uint SetBackgroundColor(ref DXGI_RGBA pColor);
            [PreserveSig]
            uint SetRotation(ref DXGI_MODE_ROTATION Rotation);

        }

        [ComImport]
        [Guid("f29ac532-e98b-431c-9cf7-821c32b9615a")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapchain2 : IDXGISwapchain1
        {
            [PreserveSig]
            IntPtr GetFrameLatencyWaitableObject();
            [PreserveSig]
            uint GetMatrixTransform(ref DXGI_MATRIX_3X2_F pMatrix);
            [PreserveSig]
            uint GetMaximumFrameLatency(out uint pMaxLatency);
            [PreserveSig]
            uint GetSourceSize(out uint pWidth, out uint pHeight);
            [PreserveSig]
            uint SetMatrixTransform(ref DXGI_MATRIX_3X2_F pMatrix);
            [PreserveSig]
            uint SetMaximumFrameLatency(uint MaxLatency);
            [PreserveSig]
            uint SetSourceSize(uint Width, uint Height);
        }

        [ComImport]
        [Guid("f8823b48-5640-4242-bf56-fe6f1a7ad2de")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapchain3 : IDXGISwapchain2
        {
            [PreserveSig]
            uint CheckColorSpaceSupport(ref DXGI_COLOR_SPACE_TYPE ColorSpace, out uint pColorSpaceSupport);
            [PreserveSig]
            uint GetCurrentBackBufferIndex();
            [PreserveSig]
            uint ResizeBuffers1(uint BufferCount, uint Width, uint Height, ref DXGI_FORMAT Format, uint SwapChainFlags, uint pCreationNodeMask, [MarshalAs(UnmanagedType.IUnknown)] IntPtr ppPresentQueue);
            [PreserveSig]
            uint SetColorSpace1(ref DXGI_COLOR_SPACE_TYPE ColorSpace);
        }

        [ComImport]
        [Guid("f3b2a8bb-45cc-45bb-80e6-91af1f9bf8d1")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapchain4 : IDXGISwapchain3
        {
            [PreserveSig]
            uint SetHDRMetaData(ref DXGI_HDR_METADATA_TYPE Type, uint Size, IntPtr pMetaData);
        }


        // Devices
        [ComImport]
        [Guid("35ce0784-3c45-47ee-bcdc-f628061af33d")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDevice
        {
            [PreserveSig]
            uint CreateSurface(ref DXGI_SURFACE_DESC pDesc, uint NumSurfaces, ref DXGI_USAGE Usage, DXGI_SHARED_RESOURCE pSharedResource, out IDXGISurface ppSurface);
            [PreserveSig]
            uint GetAdapter(out IDXGIAdapter pAdapter);
            [PreserveSig]
            uint GetGPUThreadPriority(out int pPriority);
            [PreserveSig]
            uint QueryResourceResidency([MarshalAs(UnmanagedType.IUnknown)] IntPtr ppResources, out DXGI_RESIDENCY pResidencyStatus, uint NumResources);
            [PreserveSig]
            uint SetGPUThreadPriority(int Priority);
        }

        [ComImport]
        [Guid("7500097b-2950-43ee-a3e5-1e25b3669eb5")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDevice1
        {
            [PreserveSig]
            uint GetMaximumFrameLatency(out uint pMaxLatency);
            [PreserveSig]
            uint SetMaximumFrameLatency(uint MaxLatency);
        }

        [ComImport]
        [Guid("91a205ce-955a-4e33-9300-0ecc3348c633")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDevice2
        {
            [PreserveSig]
            uint EnqueueSetEvent(IntPtr hEvent);
            [PreserveSig]
            uint OfferResources(uint NumResources, ref IDXGIResource ppResources, ref DXGI_OFFER_RESOURCE_PRIORITY Priority);
            [PreserveSig]
            uint ReclaimResources(uint NumResources, ref IDXGIResource ppResources, out bool pDiscarded);
        }

        [ComImport]
        [Guid("f83266d4-2303-4af9-96ca-524fa5f3e107")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDevice3
        {
            [PreserveSig]
            void Trim();
        }

        [ComImport]
        [Guid("dce9af25-584c-47a1-8335-bd9a7a41863f")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDevice4
        {
            [PreserveSig]
            uint OfferResources1(uint NumResources, ref IDXGIResource ppResources, ref DXGI_OFFER_RESOURCE_PRIORITY Priority, uint Flags);
            [PreserveSig]
            uint ReclaimResources1(uint NumResources, ref IDXGIResource ppResources, ref DXGI_RECLAIM_RESOURCE_RESULTS pResults);
        }


        // Debug
        [ComImport]
        [Guid("e36a46af-90a5-49e5-95d8-1d0ac05692dd")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDebug
        {
            [PreserveSig]
            uint ReportLiveObjects(ref Guid apiid, ref DXGI_DEBUG_RLO_FLAGS flags);
        }

        [ComImport]
        [Guid("cacd16c9-7a4c-4d68-be3b-e64ea7e8c20f")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDebug1 : IDXGIDebug
        {
            [PreserveSig]
            void DisableLeakTrackingForThread();
            [PreserveSig]
            void EnableLeakTrackingForThread();
            [PreserveSig]
            bool IsLeakTrackingEnabledForThread();
        }


        // Resources
        [ComImport]
        [Guid("4e7c8f56-8d45-46fd-9758-a88433963abc")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIResource
        {
            [PreserveSig]
            uint GetEvictionPriority(out uint pEvictionPriority);
            [PreserveSig]
            uint GetSharedHandle(out IntPtr pSharedHandle);
            [PreserveSig]
            uint GetUsage(ref DXGI_USAGE pUsage);
            [PreserveSig]
            uint SetEvictionPriority(uint EvictionPriority);
        }

        [ComImport]
        [Guid("a0841905-11de-4441-85c7-a70ddfae9566")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIResource1 : IDXGIResource
        {
            [PreserveSig]
            uint CreateSharedHandle(ref SECURITY_ATTRIBUTES pAttributes, uint dwAccess, string lpName, out IntPtr pHandle);
            [PreserveSig]
            uint CreateSubresourceSurface(uint index, out IDXGISurface2 ppSurface);
        }


        // Surfaces
        [ComImport]
        [Guid("7d36ee18-654d-40b6-8428-68b2b38a4886")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISurface
        {
            [PreserveSig]
            uint GetDesc(out DXGI_SURFACE_DESC pDesc);
            [PreserveSig]
            uint Map(out DXGI_MAPPED_RECT pLockedRect, uint MapFlags);
            [PreserveSig]
            uint Unmap();
        }

        [ComImport]
        [Guid("cf99c92c-77b1-4843-b48b-ed3a43a23f87")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISurface1 : IDXGISurface
        {
            [PreserveSig]
            uint GetDC(bool Discard, out IntPtr phdc);
            [PreserveSig]
            uint ReleaseDC(ref tagRECT pDirtyRect);
        }

        [ComImport]
        [Guid("d7c3be4f-08e8-4e60-92a3-0dd24c4f1634")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISurface2 : IDXGISurface1
        {
            [PreserveSig]
            uint GetResource(ref Guid riid, out IntPtr ppParentResource, out uint pSubresourceIndex);
        }


        // Etc
        [ComImport]
        [Guid("aec22fb8-76f3-4639-9be0-28eb43a67a2e")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIObject
        {
            [PreserveSig]
            uint SetPrivateData(ref Guid Name, uint DataSize, IntPtr pData);

            [PreserveSig]
            uint SetPrivateDataInterface(ref Guid Name, [MarshalAs(UnmanagedType.IUnknown)] object pUnknown);

            [PreserveSig]
            uint GetPrivateData(ref Guid Name, ref uint pDataSize, IntPtr pData);

            [PreserveSig]
            uint GetParent(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppParent);
        }

        [ComImport]
        [Guid("5106d9ed-e79d-42bf-9981-29d0dce47442")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDecodeSwapChain
        {
            [PreserveSig]
            DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAGS GetColorSpace();
            [PreserveSig]
            uint GetDestSize(out uint pWidth, out uint pHeight);
            [PreserveSig]
            uint GetSourceRect(out tagRECT pRect);
            [PreserveSig]
            uint GetTargetRect(out tagRECT pRect);
            [PreserveSig]
            uint PresentBuffer(uint BufferToPresent, uint SyncInterval, uint Flags);
            [PreserveSig]
            uint SetColorSpace(ref DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAGS ColorSpace);
            [PreserveSig]
            uint SetDestSize(uint Width, uint Height);
            [PreserveSig]
            uint SetSourceRect(ref tagRECT pRect);
            [PreserveSig]
            uint SetTargetRect(ref tagRECT pRect);
        }

        [ComImport]
        [Guid("ac794add-0f6f-4634-814a-9870c855ac5d")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDeviceSubObject
        {
            [PreserveSig]
            uint GetDevice(ref Guid riid, out IntPtr ppDevice);
        }

        [ComImport]
        [Guid("ae5add06-5b2a-4bfc-8dd2-b572d1c5239e")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDisplayControl
        {
            [PreserveSig]
            bool IsStereoEnabled();
            [PreserveSig]
            void SetStereoEnabled(bool enabled);
        }

        [ComImport]
        [Guid("b9a5561d-62e0-4562-8a52-bedbff98a064")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactoryMedia
        {
            [PreserveSig]
            uint CreateDecodeSwapChainForCompositionSurfaceHandle([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, IntPtr hSurface, ref DXGI_DECODE_SWAP_CHAIN_DESC pDesc, ref IDXGIResource pYuvDecodeBuffers, ref IDXGIOutput pRestrictToOutput, out IDXGIDecodeSwapChain ppSwapChain);
            [PreserveSig]
            uint CreateSwapChainForCompositionSurfaceHandle([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, IntPtr hSurface, ref DXGI_SWAP_CHAIN_DESC1 pDesc, ref IDXGIOutput pRestrictToOutput, out IDXGISwapchain1 ppSwapChain);
        }

        [ComImport]
        [Guid("7556e4d2-ea03-4b9d-835b-a75b510fb76f")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIInfoQueue
        {
            [PreserveSig]
            uint AddApplicationMessage(ref DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, string pDescription);
            [PreserveSig]
            uint AddMessage(ref DXGI_DEBUG_ID Producer, DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category, DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, DXGI_INFO_QUEUE_MESSAGE_ID ID, string pDescription);
            [PreserveSig]
            uint AddRetrievalFilterEntries(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_FILTER pFilter);
            [PreserveSig]
            uint AddStorageFilterEntries(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_FILTER pFilter);
            [PreserveSig]
            void ClearRetrievalFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            void ClearStorageFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            void ClearStoredMessages(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            bool GetBreakOnCategory(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category);
            [PreserveSig]
            bool GetBreakOnID(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_MESSAGE_ID ID);
            [PreserveSig]
            bool GetBreakOnSeverity(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity);
            [PreserveSig]
            uint GetMessage(ref DXGI_DEBUG_ID Producer, ref UInt64 MessageIndex, out DXGI_INFO_QUEUE_MESSAGE pMessage, ref SIZE_T pMessageByteLength);
            [PreserveSig]
            UInt64 GetMessageCountLimit(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            bool GetMuteDebugOutput(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            UInt64 GetNumMessagesAllowedByStorageFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            UInt64 GetNumMessagesDeniedByStorageFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            UInt64 GetNumMessagesDiscardedByMessageCountLimit(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            UInt64 GetNumStoredMessages(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            uint GetNumStoredMessagesAllowedByRetrievalFilters(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            uint GetRetrievalFilter(ref DXGI_DEBUG_ID Producer, out DXGI_INFO_QUEUE_FILTER pFilter, ref SIZE_T pFilterByteLength);
            [PreserveSig]
            uint GetRetrievalFilterStackSize(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            uint GetStorageFilter(ref DXGI_DEBUG_ID Producer, out DXGI_INFO_QUEUE_FILTER pFilter, ref SIZE_T pFilterByteLength);
            [PreserveSig]
            uint GetStorageFilterStackSize(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            void PopRetrievalFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            void PopStorageFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            uint PushCopyOfRetrievalFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            uint PushCopyOfStorageFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            uint PushDenyAllRetrievalFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            uint PushDenyAllStorageFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            uint PushEmptyRetrievalFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            uint PushEmptyStorageFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            uint PushRetrievalFilter(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_FILTER pFilter);
            [PreserveSig]
            uint PushStorageFilter(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_FILTER pFilter);
            [PreserveSig]
            uint SetBreakOnCategory(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category, bool bEnable);
            [PreserveSig]
            uint SetBreakOnID(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_MESSAGE_ID ID, bool bEnable);
            [PreserveSig]
            uint SetBreakOnSeverity(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, bool bEnable);
            [PreserveSig]
            uint SetMessageCountLimit(ref DXGI_DEBUG_ID Producer, ref UInt64 MessageCountLimit);
            [PreserveSig]
            void SetMuteDebugOutput(ref DXGI_DEBUG_ID Producer, bool bMute);
        }

        [ComImport]
        [Guid("07c5bcb6-64ea-4f19-8b87-817c9fc85c84")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIKeyedMutex
        {
            [PreserveSig]
            uint AcquireSync(ref UInt64 Key, uint dwMilliseconds);
            [PreserveSig]
            uint ReleaseSync(ref UInt64 Key);
        }

        [ComImport]
        [Guid("6aedc9ab-ff7f-44d9-a1e6-29f37aba2cce")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutputDuplication
        {
            [PreserveSig]
            uint AcquireNextFrame(uint TimeoutInMilliseconds, out DXGI_OUTDUPL_FRAME_INFO pFrameInfo, out IDXGIResource ppDesktopResource);
            [PreserveSig]
            void GetDesc(out DXGI_OUTDUPL_DESC pDesc);
            [PreserveSig]
            uint GetFrameDirtyRects(uint DirtyRectsBufferSize, out tagRECT pDirtyRectsBuffer, out uint pDirtyRectsBufferSizeRequired);
            [PreserveSig]
            uint GetFrameMoveRects(uint MoveRectsBufferSize, out DXGI_OUTDUPL_MOVE_RECT pMoveRectBuffer, out uint pMoveRectsBufferSizeRequired);
            [PreserveSig]
            uint GetFramePointerShape(uint PointerShapeBufferSize, out IntPtr pPointerShapeBuffer, out uint pPointerShapeBufferSizeRequired, out DXGI_OUTDUPL_POINTER_SHAPE_INFO pPointerShapeInfo);
            [PreserveSig]
            uint MapDesktopSurface(out DXGI_MAPPED_RECT pLockedRect);
            [PreserveSig]
            uint ReleaseFrame();
            [PreserveSig]
            uint UnMapDesktopSurface();
        }

        [ComImport]
        [Guid("ef9bec92-ab99-4e0b-83f9-09e9d0784903")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapChainMedia
        {
            [PreserveSig]
            uint CheckPresentDurationSupport(uint DesiredPresentDuration, out uint pClosestSmallerPresentDuration, out uint pClosestLargetPresentDuration);
            [PreserveSig]
            uint GetFrameStatisticsMedia(out DXGI_FRAME_STATISTICS_MEDIA pStats);
            [PreserveSig]
            uint SetPresentDuration(uint Duration);
        }
    }
}
