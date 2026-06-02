using System.Runtime.InteropServices;
using static Angene.Windows.Dxgi.DxgiEnums;
using static Angene.Windows.Dxgi.DxgiStructs;
using static Angene.Windows.WindowManagement;
using DXGI_DEBUG_ID = System.Guid;

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
        [Guid("2411e7e1-12ac-4ccf-bd14-9798e8534dc0")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIAdapter
        {
            [PreserveSig] uint SetPrivateData(ref Guid Name, uint DataSize, IntPtr pData);
            [PreserveSig] uint SetPrivateDataInterface(ref Guid Name, [MarshalAs(UnmanagedType.IUnknown)] object pUnknown);
            [PreserveSig] uint GetPrivateData(ref Guid Name, ref uint pDataSize, IntPtr pData);
            [PreserveSig] uint GetParent(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppParent);

            [PreserveSig]
            uint CheckInterfaceSupport(ref Guid InterfaceName, out LARGE_INTEGER pUMDVersion); // If system supports device interface for a graphics component

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
            uint GetDesc(out DXGI_ADAPTER_DESC pDesc); // 1.0 description of card
        }

        [ComImport]
        [Guid("29038f61-3839-4626-91fd-086879011a05")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIAdapter1 : IDXGIAdapter
        {
            [PreserveSig]
            uint GetDesc1(out DXGI_ADAPTER_DESC1 pDesc);
        }

        [ComImport]
        [Guid("0aa22c78-c28b-4988-934f-98774bd000a1")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIAdapter2 : IDXGIAdapter1
        {
            [PreserveSig]
            uint GetDesc2(out DXGI_ADAPTER_DESC2 pDesc);
        }

        [ComImport]
        [Guid("645967bd-4efb-4d44-aab1-27963914944d")]
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
        [Guid("3c8d99d1-4fbf-4181-a82c-af66bf7bd24e")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIAdapter4 : IDXGIAdapter3
        {
            [PreserveSig]
            uint GetDesc3(out DXGI_ADAPTER_DESC3 pDesc);
        }


        // Outputs
        [ComImport]
        [Guid("ae02eedb-c735-4690-8d52-5a8dc20213aa")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput
        {
            // object
            [PreserveSig] uint SetPrivateData(ref Guid Name, uint DataSize, IntPtr pData);

            [PreserveSig] uint SetPrivateDataInterface(ref Guid Name, [MarshalAs(UnmanagedType.IUnknown)] object pUnknown);

            [PreserveSig] uint GetPrivateData(ref Guid Name, ref uint pDataSize, IntPtr pData);

            [PreserveSig] uint GetParent(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppParent);

            // devicesubobject
            [PreserveSig] uint GetDevice(ref Guid riid, out IntPtr ppDevice);

            // output
            [PreserveSig]
            uint FindClosestMatchingMode(ref DXGI_MODE_DESC pModeToMatch, out DXGI_MODE_DESC pClosestMatch, [MarshalAs(UnmanagedType.IUnknown)] IntPtr pConcernedDevice); // will fix later maybe
            
            [PreserveSig]
            uint GetDisplayModeList(
                DXGI_FORMAT EnumFormat, 
                uint Flags, 
                ref uint pNumModes, // Listed as [in, out]
                out DXGI_MODE_DESC pDesc // Listed as optional
                );
            
            [PreserveSig]
            uint GetDisplaySurfaceData(IDXGISurface pDestination);
            
            [PreserveSig]
            uint GetFrameStatistics(out DXGI_FRAME_STATISTICS pStats);
            
            [PreserveSig]
            uint GetGammaControl(out DXGI_GAMMA_CONTROL pArray);
            
            [PreserveSig]
            uint GetGammaControlCapabilities(out DXGI_GAMMA_CONTROL_CAPABILITIES pGammaCaps);

            [PreserveSig]
            uint GetDesc(out DXGI_OUTPUT_DESC pDesc);

            [PreserveSig]
            void ReleaseOwnership(); // Release ownership of output
            
            [PreserveSig]
            uint SetDisplaySurface(IDXGISurface pScanoutSurface);
            
            [PreserveSig]
            uint SetGammaControl(ref DXGI_GAMMA_CONTROL pArray);
            
            [PreserveSig]
            uint TakeOwnership([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, bool Exclusive);
            
            [PreserveSig]
            uint WaitForVBlank(); // Halt until next vertical blank
        }

        [ComImport]
        [Guid("00cddea8-939b-4b83-a340-a6851981dc85")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput1 : IDXGIOutput
        {
            [PreserveSig]
            uint DuplicateOutput([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, out IDXGIOutputDuplication ppOutputDuplication);

            [PreserveSig] // might throw an error for an "in" after "out" specified.
            uint FindClosestMatchingMode1(ref DXGI_MODE_DESC1 pModeToMatch, out DXGI_MODE_DESC1 pClosestMatch, [MarshalAs(UnmanagedType.IUnknown)] IntPtr pConcernedDevice);
            
            [PreserveSig]
            uint GetDisplayModeList1(DXGI_FORMAT EnumFormat, 
                uint Flags, 
                ref uint pNumModes, // Listed as "[in, out]"
                out DXGI_MODE_DESC1 pDesc // Listed as optional out
            );
            
            [PreserveSig]
            uint GetDisplaySurfaceData1(IDXGIResource pDestination);
        }

        [ComImport]
        [Guid("595e39d1-2724-4663-99b1-da969de28364")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput2 : IDXGIOutput1
        {
            [PreserveSig]
            [return: MarshalAs(UnmanagedType.Bool)]
            bool SupportsOverlays(); // Query adapter output for multipane overlay support. (https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgioutput2-supportsoverlays)
        }

        [ComImport]
        [Guid("8a6bb301-7e63-4713-b4a1-a78a41d252a4")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput3 : IDXGIOutput2 
        {
            [PreserveSig]
            uint CheckOverlaySupport(DXGI_FORMAT EnumFormat, [MarshalAs(UnmanagedType.IUnknown)] IntPtr pConcernedDevice, out uint pFlags);
        }

        [ComImport]
        [Guid("dc7dca35-2196-414d-9f53-617884032a60")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput4 : IDXGIOutput3
        {
            [PreserveSig]
            uint CheckOverlayColorSpaceSupport(DXGI_FORMAT Format, DXGI_COLOR_SPACE_TYPE ColorSpace, [MarshalAs(UnmanagedType.IUnknown)] IntPtr pConcernedDevice, out uint pFlags);
        }

        [ComImport]
        [Guid("80a13635-ab52-4555-8ef2-ab14a27f8c2f")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput5 : IDXGIOutput4
        {
            [PreserveSig]
            uint DuplicateOutput1([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, uint Flags, uint SupportedFormatsCount, IntPtr pSupportedFormats, out IDXGIOutputDuplication ppOutputDuplication);
        }

        [ComImport]
        [Guid("f4a85484-055f-4efd-b92c-3d3173573f47")]
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
        [Guid("7b7166ec-21c7-44ae-b21a-c94ed2391e3e")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory
        {
            // object
            [PreserveSig] uint SetPrivateData(ref Guid Name, uint DataSize, IntPtr pData);
            [PreserveSig] uint SetPrivateDataInterface(ref Guid Name, [MarshalAs(UnmanagedType.IUnknown)] object pUnknown);
            [PreserveSig] uint GetPrivateData(ref Guid Name, ref uint pDataSize, IntPtr pData);
            [PreserveSig] uint GetParent(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppParent);

            // factory
            [PreserveSig]
            uint EnumAdapters(uint Adapter, [MarshalAs(UnmanagedType.Interface)] out IDXGIAdapter ppAdapter);

            [PreserveSig]
            uint MakeWindowAssociation(IntPtr WindowHandle, uint Flags);

            [PreserveSig]
            uint GetWindowAssociation(out IntPtr pWindowHandle);

            [PreserveSig]
            uint CreateSwapChain(
                [MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, // D3D device
                ref DXGI_SWAP_CHAIN_DESC pDesc,
                [MarshalAs(UnmanagedType.Interface)] out IDXGISwapChain ppSwapChain);

            [PreserveSig]
            uint CreateSoftwareAdapter(IntPtr Module, [MarshalAs(UnmanagedType.Interface)] out IDXGIAdapter ppAdapter);
        }

        [ComImport]
        [Guid("770aae78-f26f-4dba-a829-253c83d1b387")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory1 : IDXGIFactory
        {
            [PreserveSig]
            uint EnumAdapters1(uint Adapter, [MarshalAs(UnmanagedType.Interface)] out IDXGIAdapter1 ppAdapter);

            [PreserveSig]
            [return: MarshalAs(UnmanagedType.Bool)]
            bool IsCurrent(); // False if becoming available or adapter is going away, True if no adapter changes.
            // Also returns false to inform application to re-enumerate adapters.
        }

        [ComImport]
        [Guid("50c83a1c-e072-4c48-87b0-3630d36a6a8c")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory2 : IDXGIFactory1
        {
            [PreserveSig]
            [return: MarshalAs(UnmanagedType.Bool)]
            bool IsWindowedStereoEnabled(); // Indication of whether or not to use stereo mode.
                                            // True inducates you can use stereo mode, otherwise false.
            [PreserveSig]
            uint CreateSwapChainForHwnd([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, IntPtr hWnd, ref DXGI_SWAP_CHAIN_DESC1 pDesc, IntPtr pFullScreenDesc, IDXGIOutput pRestrictToOutput, [MarshalAs(UnmanagedType.IUnknown)] out IDXGISwapChain1 ppSwapChain);
            [PreserveSig]
            uint CreateSwapChainForCoreWindow([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, [MarshalAs(UnmanagedType.IUnknown)] IntPtr pWindow, ref DXGI_SWAP_CHAIN_DESC1 pDesc, IDXGIOutput pRestrictToOutput, [MarshalAs(UnmanagedType.IUnknown)] out IDXGISwapChain1 ppSwapChain);
            [PreserveSig]
            uint CreateSwapChainForComposition([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, ref DXGI_SWAP_CHAIN_DESC1 pDesc, IDXGIOutput pRestrictToOutput, out IDXGISwapChain1 ppSwapChain);
            [PreserveSig]
            uint GetSharedResourceAdapterLuid(IntPtr hResource, out LUID pLuid);
            [PreserveSig]
            uint RegisterOcclusionStatusEvent(IntPtr hEvent,  out uint pdwCookie);
            [PreserveSig]
            uint RegisterOcclusionStatusWindow(IntPtr HWND, uint wMsg, [MarshalAs(UnmanagedType.IUnknown)] out uint pdwCookie);
            [PreserveSig]
            uint RegisterStereoStatusEvent(IntPtr hEvent, [MarshalAs(UnmanagedType.IUnknown)] out uint pdwCookie);
            [PreserveSig]
            void UnregisterStereoStatus(UInt32 dwCookie); // Unregisters a window or event to stop from recieving notification when stereo status changes
            [PreserveSig]
            uint RegisterStereoStatusWindow(IntPtr HWND, uint wMsg, [MarshalAs(UnmanagedType.IUnknown)] out uint pdwCookie);
            [PreserveSig]
            void UnregisterOcclusionStatus(UInt32 dwCookie); // Unregisters a window or event to stop from recieving notification when occlusion status changes
        }

        [ComImport]
        [Guid("25483823-cd46-4c7d-86f4-f4d2f80800d2")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory3 : IDXGIFactory2
        {
            [PreserveSig]
            uint GetCreationFlags(); // Returns flags used when DXGI object was created.
        }

        [ComImport]
        [Guid("1bc6ea02-ef36-464f-bf0c-21c385616cdb")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory4 : IDXGIFactory3
        {
            [PreserveSig]
            uint EnumAdapterByLuid(LUID AdapterLuid, ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out IntPtr ppvAdapter);
            [PreserveSig]
            uint EnumWarpAdapter(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out IntPtr ppvAdapter);
        }

        [ComImport]
        [Guid("7632e1f5-ee65-4dca-87fd-84cd75f8838d")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory5 : IDXGIFactory4
        {
            [PreserveSig]
            uint CheckFeatureSupport(int Feature, out D3D12_FEATURE_DATA_D3D12_OPTIONS featureSupportData, int featureSupportDataSize);
        }

        [ComImport]
        [Guid("c1b6694f-ff09-44a9-b0eb-c7aa351a0d6e")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory6 : IDXGIFactory5
        {
            [PreserveSig]
            uint EnumAdapterByGpuPreference(uint Adapter, DXGI_GPU_PREFERENCE GpuPreference, ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out IntPtr ppvAdapter);
        }

        [ComImport]
        [Guid("a4a6616e-2844-42f5-b77a-a690e54ca62a")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory7 : IDXGIFactory6
        {
            [PreserveSig]
            uint RegisterAdaptersChangedEvent(IntPtr hEvent, out uint pdwCookie);
            [PreserveSig]
            uint UnregisterAdaptersChangedEvent(uint dwCookie);
        }


        // Swapchains
        [ComImport]
        [Guid("310d36a0-d2e7-4c0a-aa04-6a9d23b8886a")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapChain
        {
            // object
            [PreserveSig] uint SetPrivateData(ref Guid Name, uint DataSize, IntPtr pData);
            [PreserveSig] uint SetPrivateDataInterface(ref Guid Name, [MarshalAs(UnmanagedType.IUnknown)] object pUnknown);
            [PreserveSig] uint GetPrivateData(ref Guid Name, ref uint pDataSize, IntPtr pData);
            [PreserveSig] uint GetParent(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppParent);

            // devicesubobject
            [PreserveSig] uint GetDevice(ref Guid riid, out IntPtr ppDevice);

            // swapchain
            [PreserveSig]
            uint GetBuffer(uint Buffer, ref Guid riid, out IntPtr ppSurface);
            [PreserveSig]
            uint GetContainingOutput(out IDXGIOutput ppOutput);
            [PreserveSig]
            uint GetDesc(out DXGI_SWAP_CHAIN_DESC pDesc);
            [PreserveSig]
            uint GetFrameStatistics(out DXGI_FRAME_STATISTICS pStats);
            [PreserveSig]
            uint GetFullScreenState([MarshalAs(UnmanagedType.Bool)] out bool pFullscreen, out IDXGIOutput ppTarget);
            [PreserveSig]
            uint GetLastPresentCount(out uint pLastPresentCount);
            [PreserveSig]
            uint Present(uint SyncInterval, uint Flags);
            [PreserveSig]
            uint ResizeBuffers(uint BufferCount, uint Width, uint Height, ref DXGI_FORMAT NewFormat, uint SwapChainFlags);
            [PreserveSig]
            uint ResizeTarget(ref DXGI_MODE_DESC pNewTargetParameters);
            [PreserveSig]
            uint SetFullscreenState([MarshalAs(UnmanagedType.Bool)] bool Fullscreen, ref IDXGIOutput pTarget);
        }

        [ComImport]
        [Guid("790a45f7-0d42-4876-983a-0a55cfe6f4aa")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapChain1 : IDXGISwapChain
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
            [return: MarshalAs(UnmanagedType.Bool)]
            bool IsTemporaryMonoSupported();
            [PreserveSig]
            uint Present1(uint SyncInterval, uint PresentFlags, ref DXGI_PRESENT_PARAMETERS pPresentParameters);
            [PreserveSig]
            uint SetBackgroundColor(ref DXGI_RGBA pColor);
            [PreserveSig]
            uint SetRotation(ref DXGI_MODE_ROTATION Rotation);

        }

        [ComImport]
        [Guid("a8be2ac5-d107-4555-8763-c088edfd0354")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapChain2 : IDXGISwapChain1
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
        [Guid("94d99bdb-f1f8-4ab0-b236-7da0170edab1")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapChain3 : IDXGISwapChain2
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
        [Guid("3d585d5a-bd4a-489e-b1f4-3dbcb6452ffb")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapChain4 : IDXGISwapChain3
        {
            [PreserveSig]
            uint SetHDRMetaData(ref DXGI_HDR_METADATA_TYPE Type, uint Size, IntPtr pMetaData);
        }


        // Devices
        [ComImport]
        [Guid("54ec77fa-1377-44e6-8c32-88fd5f44c84c")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDevice
        {
            // object
            [PreserveSig] uint SetPrivateData(ref Guid Name, uint DataSize, IntPtr pData);
            [PreserveSig] uint SetPrivateDataInterface(ref Guid Name, [MarshalAs(UnmanagedType.IUnknown)] object pUnknown);
            [PreserveSig] uint GetPrivateData(ref Guid Name, ref uint pDataSize, IntPtr pData);
            [PreserveSig] uint GetParent(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppParent);

            // device
            [PreserveSig]
            uint CreateSurface(ref DXGI_SURFACE_DESC pDesc, uint NumSurfaces, ref DXGI_USAGE Usage, ref DXGI_SHARED_RESOURCE pSharedResource, out IntPtr ppSurface);
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
        [Guid("77db970f-6276-48ba-ba28-070143b4392c")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDevice1 : IDXGIDevice
        {
            [PreserveSig]
            uint GetMaximumFrameLatency(out uint pMaxLatency);
            [PreserveSig]
            uint SetMaximumFrameLatency(uint MaxLatency);
        }

        [ComImport]
        [Guid("05008617-fbfd-4051-a790-144884b4f6a9")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDevice2 : IDXGIDevice1
        {
            [PreserveSig]
            uint EnqueueSetEvent(IntPtr hEvent);
            [PreserveSig]
            uint OfferResources(uint NumResources, ref IDXGIResource ppResources, ref _DXGI_OFFER_RESOURCE_PRIORITY Priority);
            [PreserveSig]
            uint ReclaimResources(uint NumResources, ref IDXGIResource ppResources, out bool pDiscarded);
        }

        [ComImport]
        [Guid("6007896c-3244-4afd-bf18-a6d3beda5023")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDevice3 : IDXGIDevice2
        {
            [PreserveSig]
            void Trim();
        }

        [ComImport]
        [Guid("95b4f00e-6e0b-407a-b85b-bc617397f504")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDevice4 : IDXGIDevice3
        {
            [PreserveSig]
            uint OfferResources1(uint NumResources, ref IDXGIResource ppResources, ref _DXGI_OFFER_RESOURCE_PRIORITY Priority, uint Flags);
            [PreserveSig]
            uint ReclaimResources1(uint NumResources, ref IDXGIResource ppResources, ref _DXGI_RECLAIM_RESOURCE_RESULTS pResults);
        }


        // Debug
        [ComImport]
        [Guid("119e7452-de9e-40fe-8806-88f90c12b441")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDebug
        {
            [PreserveSig]
            uint ReportLiveObjects(ref Guid apiid, ref DXGI_DEBUG_RLO_FLAGS flags);
        }

        [ComImport]
        [Guid("c5a05f0c-16f2-4adf-9f4d-a8c4d58ac550")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDebug1 : IDXGIDebug
        {
            [PreserveSig]
            void DisableLeakTrackingForThread();
            [PreserveSig]
            void EnableLeakTrackingForThread();
            [PreserveSig]
            [return: MarshalAs(UnmanagedType.Bool)]
            bool IsLeakTrackingEnabledForThread();
        }


        // Resources
        [ComImport]
        [Guid("035f3ab4-482e-4e50-b41f-8a7f8bd8960b")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIResource
        {
            // object
            [PreserveSig] uint SetPrivateData(ref Guid Name, uint DataSize, IntPtr pData);
            [PreserveSig] uint SetPrivateDataInterface(ref Guid Name, [MarshalAs(UnmanagedType.IUnknown)] object pUnknown);
            [PreserveSig] uint GetPrivateData(ref Guid Name, ref uint pDataSize, IntPtr pData);
            [PreserveSig] uint GetParent(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppParent);

            // devicesubobject
            [PreserveSig] uint GetDevice(ref Guid riid, out IntPtr ppDevice);

            // resource
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
        [Guid("30961379-4609-4a41-998e-54fe567ee0c1")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIResource1 : IDXGIResource
        {
            [PreserveSig]
            uint CreateSharedHandle(ref _SECURITY_ATTRIBUTES pAttributes, uint dwAccess, string lpName, out IntPtr pHandle);
            [PreserveSig]
            uint CreateSubresourceSurface(uint index, out IDXGISurface2 ppSurface);
        }


        // Surfaces
        [ComImport]
        [Guid("cafcb56c-6ac3-4889-bf47-9e23bbd260ec")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISurface
        {
            // object
            [PreserveSig] uint SetPrivateData(ref Guid Name, uint DataSize, IntPtr pData);
            [PreserveSig] uint SetPrivateDataInterface(ref Guid Name, [MarshalAs(UnmanagedType.IUnknown)] object pUnknown);
            [PreserveSig] uint GetPrivateData(ref Guid Name, ref uint pDataSize, IntPtr pData);
            [PreserveSig] uint GetParent(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppParent);

            // devicesubobject
            [PreserveSig] uint GetDevice(ref Guid riid, out IntPtr ppDevice);

            // surface
            [PreserveSig]
            uint GetDesc(out DXGI_SURFACE_DESC pDesc);
            [PreserveSig]
            uint Map(out DXGI_MAPPED_RECT pLockedRect, uint MapFlags);
            [PreserveSig]
            uint Unmap();
        }

        [ComImport]
        [Guid("4ae63092-6327-4c1b-80ae-bfe12ea32b86")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISurface1 : IDXGISurface
        {
            [PreserveSig]
            uint GetDC(bool Discard, out IntPtr phdc);
            [PreserveSig]
            uint ReleaseDC(ref RECT pDirtyRect);
        }

        [ComImport]
        [Guid("aba496dd-b617-4cb8-a866-bc44d7eb1fa2")]
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
            [PreserveSig] uint SetPrivateData(ref Guid Name, uint DataSize, IntPtr pData);

            [PreserveSig] uint SetPrivateDataInterface(ref Guid Name, [MarshalAs(UnmanagedType.IUnknown)] object pUnknown);

            [PreserveSig] uint GetPrivateData(ref Guid Name, ref uint pDataSize, IntPtr pData);

            [PreserveSig] uint GetParent(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppParent);
        }

        [ComImport]
        [Guid("2633066b-4514-4c7a-8fd8-12ea98059d18")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDecodeSwapChain
        {
            [PreserveSig]
            DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAGS GetColorSpace();
            [PreserveSig]
            uint GetDestSize(out uint pWidth, out uint pHeight);
            [PreserveSig]
            uint GetSourceRect(out RECT pRect);
            [PreserveSig]
            uint GetTargetRect(out RECT pRect);
            [PreserveSig]
            uint PresentBuffer(uint BufferToPresent, uint SyncInterval, uint Flags);
            [PreserveSig]
            uint SetColorSpace(ref DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAGS ColorSpace);
            [PreserveSig]
            uint SetDestSize(uint Width, uint Height);
            [PreserveSig]
            uint SetSourceRect(ref RECT pRect);
            [PreserveSig]
            uint SetTargetRect(ref RECT pRect);
        }

        [ComImport]
        [Guid("3d3e0379-f9de-4d58-bb6c-18d62992f1a6")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDeviceSubObject
        {
            [PreserveSig] uint GetDevice(ref Guid riid, out IntPtr ppDevice);
        }

        [ComImport]
        [Guid("ea9dbf1a-c88e-448b-b7c1-22cd9757c8bc")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDisplayControl
        {
            [PreserveSig]
            [return: MarshalAs(UnmanagedType.Bool)]
            bool IsStereoEnabled();
            [PreserveSig]
            void SetStereoEnabled(bool enabled);
        }

        [ComImport]
        [Guid("41e7d1f2-a591-4f7b-a2e5-fa9c843e1c12")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactoryMedia
        {
            [PreserveSig]
            uint CreateDecodeSwapChainForCompositionSurfaceHandle([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, IntPtr hSurface, ref DXGI_DECODE_SWAP_CHAIN_DESC pDesc, ref IDXGIResource pYuvDecodeBuffers, ref IDXGIOutput pRestrictToOutput, out IDXGIDecodeSwapChain ppSwapChain);
            [PreserveSig]
            uint CreateSwapChainForCompositionSurfaceHandle([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, IntPtr hSurface, ref DXGI_SWAP_CHAIN_DESC1 pDesc, ref IDXGIOutput pRestrictToOutput, out IDXGISwapChain1 ppSwapChain);
        }

        [ComImport]
        [Guid("d67441c7-672a-476f-9e82-cd55b44949ce")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIInfoQueue
        {
            [PreserveSig]
            uint AddApplicationMessage(ref DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, string pDescription);
            [PreserveSig]
            uint AddMessage(ref DXGI_DEBUG_ID Producer, DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category, DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, uint ID, string pDescription);
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
            [return: MarshalAs(UnmanagedType.Bool)]
            bool GetBreakOnCategory(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category);
            [PreserveSig]
            [return: MarshalAs(UnmanagedType.Bool)]
            bool GetBreakOnID(ref DXGI_DEBUG_ID Producer, uint ID);
            [PreserveSig]
            [return: MarshalAs(UnmanagedType.Bool)]
            bool GetBreakOnSeverity(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity);
            [PreserveSig]
            uint GetMessage(ref DXGI_DEBUG_ID Producer, ref UInt64 MessageIndex, out DXGI_INFO_QUEUE_MESSAGE pMessage, nuint pMessageByteLength);
            [PreserveSig]
            UInt64 GetMessageCountLimit(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            [return: MarshalAs(UnmanagedType.Bool)]
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
            uint GetRetrievalFilter(ref DXGI_DEBUG_ID Producer, out DXGI_INFO_QUEUE_FILTER pFilter, nuint pFilterByteLength);
            [PreserveSig]
            uint GetRetrievalFilterStackSize(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            uint GetStorageFilter(ref DXGI_DEBUG_ID Producer, out DXGI_INFO_QUEUE_FILTER pFilter, nuint pFilterByteLength);
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
            uint SetBreakOnID(ref DXGI_DEBUG_ID Producer, uint ID, bool bEnable);
            [PreserveSig]
            uint SetBreakOnSeverity(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, bool bEnable);
            [PreserveSig]
            uint SetMessageCountLimit(ref DXGI_DEBUG_ID Producer, ref UInt64 MessageCountLimit);
            [PreserveSig]
            void SetMuteDebugOutput(ref DXGI_DEBUG_ID Producer, bool bMute);
        }

        [ComImport]
        [Guid("9d8e1289-d7b3-465f-8126-250e349af85d")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIKeyedMutex
        {
            // object
            [PreserveSig] uint SetPrivateData(ref Guid Name, uint DataSize, IntPtr pData);
            [PreserveSig] uint SetPrivateDataInterface(ref Guid Name, [MarshalAs(UnmanagedType.IUnknown)] object pUnknown);
            [PreserveSig] uint GetPrivateData(ref Guid Name, ref uint pDataSize, IntPtr pData);
            [PreserveSig] uint GetParent(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppParent);

            // devicesubobject
            [PreserveSig] uint GetDevice(ref Guid riid, out IntPtr ppDevice);

            // keyedmutex
            [PreserveSig]
            uint AcquireSync(ref UInt64 Key, uint dwMilliseconds);
            [PreserveSig]
            uint ReleaseSync(ref UInt64 Key);
        }

        [ComImport]
        [Guid("191cfac3-a341-470d-b26e-a864f428319c")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutputDuplication
        {
            [PreserveSig]
            uint AcquireNextFrame(uint TimeoutInMilliseconds, out DXGI_OUTDUPL_FRAME_INFO pFrameInfo, out IDXGIResource ppDesktopResource);
            [PreserveSig]
            void GetDesc(out DXGI_OUTDUPL_DESC pDesc);
            [PreserveSig]
            uint GetFrameDirtyRects(uint DirtyRectsBufferSize, out RECT pDirtyRectsBuffer, out uint pDirtyRectsBufferSizeRequired);
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
        [Guid("dd95b0ed-466f-461c-91d5-7b32f25f1716")]
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
