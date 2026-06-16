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


        //
        // Adapters
        //
        [ComImport]
        [Guid("2411e7e1-12ac-4ccf-bd14-9798e8534dc0")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIAdapter : IDXGIObject
        {
            /// <summary>
            /// Enumerates video card outputs. "Output" is the index of the video card output, "ppOutput" is a returning output pointer of type IDXGIOutput.
            /// </summary>
            /// <param name="Output"></param>
            /// <param name="ppOutput"></param>
            /// <returns>HRESULT Uint</returns>
            [PreserveSig]
            int EnumOutputs(uint Output, [MarshalAs(UnmanagedType.IUnknown)] out IDXGIOutput ppOutput); // Enumerate outputs (video cards)

            /// <summary>
            /// Returns a 1.0 DXGI description of an adapter. Only param is "pDesc" which is returning a type of "DXGI_ADAPTER_DESC" (a struct)
            /// </summary>
            /// <param name="pDesc"></param>
            /// <returns></returns>
            [PreserveSig]
            int GetDesc(out DXGI_ADAPTER_DESC pDesc); // 1.0 description of card

            [PreserveSig]
            int CheckInterfaceSupport(ref Guid InterfaceName, out LARGE_INTEGER pUMDVersion); // If system supports device interface for a graphics component
        }

        [ComImport]
        [Guid("29038f61-3839-4626-91fd-086879011a05")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIAdapter1 : IDXGIAdapter
        {
            [PreserveSig]
            int GetDesc1(out DXGI_ADAPTER_DESC1 pDesc);
        }

        [ComImport]
        [Guid("0aa22c78-c28b-4988-934f-98774bd000a1")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIAdapter2 : IDXGIAdapter1
        {
            [PreserveSig]
            int GetDesc2(out DXGI_ADAPTER_DESC2 pDesc);
        }

        [ComImport]
        [Guid("645967bd-4efb-4d44-aab1-27963914944d")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIAdapter3 : IDXGIAdapter2
        {
            [PreserveSig]
            int RegisterHardwareContentProtectionTeardownStatusEvent(IntPtr hEvent, out uint pdwCookie);
            [PreserveSig]
            void UnregisterHardwareContentProtectionTeardownStatus(uint dwCookie);
            [PreserveSig]
            int QueryVideoMemoryInfo(uint NodeIndex, DXGI_MEMORY_SEGMENT_GROUP MemorySegmentGroup, out DXGI_QUERY_VIDEO_MEMORY_INFO pVideoMemoryInfo);
            [PreserveSig]
            int SetVideoMemoryReservation(uint NodeIndex, DXGI_MEMORY_SEGMENT_GROUP MemorySegmentGroup, UInt64 Reservation);
            [PreserveSig]
            int RegisterVideoMemoryBudgetChangeNotificationEvent(IntPtr hEvent, out uint pdwCookie);
            [PreserveSig]
            void UnregisterVideoMemoryBudgetChangeNotification(uint dwCookie);
        }

        [ComImport]
        [Guid("3c8d99d1-4fbf-4181-a82c-af66bf7bd24e")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIAdapter4 : IDXGIAdapter3
        {
            [PreserveSig]
            int GetDesc3(out DXGI_ADAPTER_DESC3 pDesc);
        }


        //
        // Outputs
        //
        [ComImport]
        [Guid("ae02eedb-c735-4690-8d52-5a8dc20213aa")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput : IDXGIObject
        {
            [PreserveSig]
            int GetDesc(out DXGI_OUTPUT_DESC pDesc);
            [PreserveSig]
            int GetDisplayModeList(
                DXGI_FORMAT EnumFormat,
                uint Flags,
                ref uint pNumModes, // Listed as [in, out]
                out DXGI_MODE_DESC pDesc // Listed as optional
            );
            [PreserveSig]
            int FindClosestMatchingMode(ref DXGI_MODE_DESC pModeToMatch, out DXGI_MODE_DESC pClosestMatch, [MarshalAs(UnmanagedType.IUnknown)] object pConcernedDevice);
            [PreserveSig]
            int WaitForVBlank(); // Halt until next vertical blank
            [PreserveSig]
            int TakeOwnership(IntPtr pDevice, bool Exclusive);
            [PreserveSig]
            void ReleaseOwnership(); // Release ownership of output
            [PreserveSig]
            int GetGammaControlCapabilities(out DXGI_GAMMA_CONTROL_CAPABILITIES pGammaCaps);
            [PreserveSig]
            int SetGammaControl(ref DXGI_GAMMA_CONTROL pArray);
            [PreserveSig]
            int GetGammaControl(out DXGI_GAMMA_CONTROL pArray);
            [PreserveSig]
            int SetDisplaySurface(IDXGISurface pScanoutSurface);
            [PreserveSig]
            int GetDisplaySurfaceData(IDXGISurface pDestination);
            [PreserveSig]
            int GetFrameStatistics(out DXGI_FRAME_STATISTICS pStats);
        }

        [ComImport]
        [Guid("00cddea8-939b-4b83-a340-a6851981dc85")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput1 : IDXGIOutput
        {
            [PreserveSig]
            int GetDisplayModeList1(DXGI_FORMAT EnumFormat, 
                uint Flags, 
                ref uint pNumModes, // Listed as "[in, out]"
                out DXGI_MODE_DESC1 pDesc // Listed as optional out
            );
            [PreserveSig] // might throw an error for an "in" after "out" specified.
            int FindClosestMatchingMode1(ref DXGI_MODE_DESC1 pModeToMatch, out DXGI_MODE_DESC1 pClosestMatch, IntPtr pConcernedDevice);
            [PreserveSig]
            int GetDisplaySurfaceData1(IDXGIResource pDestination);
            [PreserveSig]
            int DuplicateOutput(IntPtr pDevice, out IDXGIOutputDuplication ppOutputDuplication);

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
            int CheckOverlaySupport(DXGI_FORMAT EnumFormat, IntPtr pConcernedDevice, out uint pFlags);
        }

        [ComImport]
        [Guid("dc7dca35-2196-414d-9f53-617884032a60")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput4 : IDXGIOutput3
        {
            [PreserveSig]
            int CheckOverlayColorSpaceSupport(DXGI_FORMAT Format, DXGI_COLOR_SPACE_TYPE ColorSpace, IntPtr pConcernedDevice, out uint pFlags);
        }

        [ComImport]
        [Guid("80a13635-ab52-4555-8ef2-ab14a27f8c2f")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput5 : IDXGIOutput4
        {
            [PreserveSig]
            int DuplicateOutput1(IntPtr pDevice, uint Flags, uint SupportedFormatsCount, IntPtr pSupportedFormats, out IDXGIOutputDuplication ppOutputDuplication);
        }

        [ComImport]
        [Guid("f4a85484-055f-4efd-b92c-3d3173573f47")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutput6 : IDXGIOutput5
        {
            [PreserveSig]
            int GetDesc1(out DXGI_OUTPUT_DESC1 pDesc);
            [PreserveSig]
            int CheckHardwareCompositionSupport(out uint pFlags);
        }


        //
        // Factories
        //
        [ComImport]
        [Guid("7b7166ec-21c7-44ae-b21a-c94ed2391e3e")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory : IDXGIObject
        {
            [PreserveSig]
            int EnumAdapters(uint Adapter, [MarshalAs(UnmanagedType.Interface)] out IDXGIAdapter ppAdapter);
            [PreserveSig]
            int MakeWindowAssociation(IntPtr WindowHandle, uint Flags);
            [PreserveSig]
            int GetWindowAssociation(out IntPtr pWindowHandle);
            [PreserveSig]
            int CreateSwapChain(
                [MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, // D3D device
                ref DXGI_SWAP_CHAIN_DESC pDesc,
                [MarshalAs(UnmanagedType.Interface)] out IDXGISwapChain ppSwapChain);
            [PreserveSig]
            int CreateSoftwareAdapter(IntPtr Module, [MarshalAs(UnmanagedType.Interface)] out IDXGIAdapter ppAdapter);
        }

        [ComImport]
        [Guid("770aae78-f26f-4dba-a829-253c83d1b387")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory1 : IDXGIFactory
        {
            [PreserveSig]
            int EnumAdapters1(uint Adapter, [MarshalAs(UnmanagedType.Interface)] out IDXGIAdapter1 ppAdapter);

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
            int CreateSwapChainForHwnd([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, IntPtr hWnd, ref DXGI_SWAP_CHAIN_DESC1 pDesc, IntPtr pFullScreenDesc, IDXGIOutput pRestrictToOutput, [MarshalAs(UnmanagedType.IUnknown)] out IDXGISwapChain1 ppSwapChain);
            [PreserveSig]
            int CreateSwapChainForCoreWindow([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, [MarshalAs(UnmanagedType.IUnknown)] IntPtr pWindow, ref DXGI_SWAP_CHAIN_DESC1 pDesc, IDXGIOutput pRestrictToOutput, [MarshalAs(UnmanagedType.IUnknown)] out IDXGISwapChain1 ppSwapChain);
            [PreserveSig]
            int GetSharedResourceAdapterLuid(IntPtr hResource, out LUID pLuid);
            [PreserveSig]
            int RegisterStereoStatusWindow(IntPtr HWND, uint wMsg, out uint pdwCookie);
            [PreserveSig]
            int RegisterStereoStatusEvent(IntPtr hEvent, out uint pdwCookie);
            [PreserveSig]
            void UnregisterStereoStatus(UInt32 dwCookie); // Unregisters a window or event to stop from recieving notification when stereo status changes
            [PreserveSig]
            int RegisterOcclusionStatusWindow(IntPtr HWND, uint wMsg, out uint pdwCookie);
            [PreserveSig]
            int RegisterOcclusionStatusEvent(IntPtr hEvent, out uint pdwCookie);
            [PreserveSig]
            void UnregisterOcclusionStatus(UInt32 dwCookie); // Unregisters a window or event to stop from recieving notification when occlusion status changes
            [PreserveSig]
            int CreateSwapChainForComposition([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, ref DXGI_SWAP_CHAIN_DESC1 pDesc, IDXGIOutput pRestrictToOutput, out IDXGISwapChain1 ppSwapChain);
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
            int EnumAdapterByLuid(LUID AdapterLuid, ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out IntPtr ppvAdapter);
            [PreserveSig]
            int EnumWarpAdapter(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out IntPtr ppvAdapter);
        }

        [ComImport]
        [Guid("7632e1f5-ee65-4dca-87fd-84cd75f8838d")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory5 : IDXGIFactory4
        {
            [PreserveSig]
            int CheckFeatureSupport(DXGI_FEATURE Feature, out IntPtr featureSupportData, int featureSupportDataSize);
        }

        [ComImport]
        [Guid("c1b6694f-ff09-44a9-b0eb-c7aa351a0d6e")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory6 : IDXGIFactory5
        {
            [PreserveSig]
            int EnumAdapterByGpuPreference(uint Adapter, DXGI_GPU_PREFERENCE GpuPreference, ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out IntPtr ppvAdapter);
        }

        [ComImport]
        [Guid("a4a6616e-2844-42f5-b77a-a690e54ca62a")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIFactory7 : IDXGIFactory6
        {
            [PreserveSig]
            int RegisterAdaptersChangedEvent(IntPtr hEvent, out uint pdwCookie);
            [PreserveSig]
            int UnregisterAdaptersChangedEvent(uint dwCookie);
        }


        //
        // Swapchains
        //
        [ComImport]
        [Guid("310d36a0-d2e7-4c0a-aa04-6a9d23b8886a")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapChain : IDXGIDeviceSubObject
        {
            [PreserveSig]
            int Present(uint SyncInterval, uint Flags);
            [PreserveSig]
            int GetBuffer(uint Buffer, ref Guid riid, out IntPtr ppSurface);
            [PreserveSig]
            int SetFullscreenState([MarshalAs(UnmanagedType.Bool)] bool Fullscreen, ref IDXGIOutput pTarget);
            [PreserveSig]
            int GetFullScreenState([MarshalAs(UnmanagedType.Bool)] out bool pFullscreen, out IDXGIOutput ppTarget);
            [PreserveSig]
            int GetDesc(out DXGI_SWAP_CHAIN_DESC pDesc);
            [PreserveSig]
            int ResizeBuffers(uint BufferCount, uint Width, uint Height, DXGI_FORMAT NewFormat, uint SwapChainFlags);
            [PreserveSig]
            int ResizeTarget(ref DXGI_MODE_DESC pNewTargetParameters);
            [PreserveSig]
            int GetContainingOutput(out IDXGIOutput ppOutput);
            [PreserveSig]
            int GetFrameStatistics(out DXGI_FRAME_STATISTICS pStats);
            [PreserveSig]
            int GetLastPresentCount(out uint pLastPresentCount);
        }

        [ComImport]
        [Guid("790a45f7-0d42-4876-983a-0a55cfe6f4aa")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapChain1 : IDXGISwapChain
        {
            [PreserveSig]
            int GetDesc1(out DXGI_SWAP_CHAIN_DESC1 pDesc);
            [PreserveSig]
            int GetFullscreenDesc(out DXGI_SWAP_CHAIN_FULLSCREEN_DESC pDesc);
            [PreserveSig]
            int GetHwnd(out IntPtr pHwnd);
            [PreserveSig]
            int GetCoreWindow(ref Guid refiid, out IntPtr ppUnk);
            [PreserveSig]
            int Present1(uint SyncInterval, uint PresentFlags, ref DXGI_PRESENT_PARAMETERS pPresentParameters);
            [PreserveSig]
            [return: MarshalAs(UnmanagedType.Bool)]
            bool IsTemporaryMonoSupported();
            [PreserveSig]
            int GetRestrictToOutput(out IDXGIOutput ppRestrictToOutput);
            [PreserveSig]
            int SetBackgroundColor(ref DXGI_RGBA pColor);
            [PreserveSig]
            int GetBackgroundColor(out DXGI_RGBA pColor);
            [PreserveSig]
            int SetRotation(DXGI_MODE_ROTATION Rotation);
            [PreserveSig]
            int GetRotation(out DXGI_MODE_ROTATION pRotation);
        }

        [ComImport]
        [Guid("a8be2ac5-d107-4555-8763-c088edfd0354")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapChain2 : IDXGISwapChain1
        {
            [PreserveSig]
            int SetSourceSize(uint Width, uint Height);
            [PreserveSig]
            int GetSourceSize(out uint pWidth, out uint pHeight);
            [PreserveSig]
            int SetMaximumFrameLatency(uint MaxLatency);
            [PreserveSig]
            int GetMaximumFrameLatency(out uint pMaxLatency);
            [PreserveSig]
            IntPtr GetFrameLatencyWaitableObject();
            [PreserveSig]
            int SetMatrixTransform(ref DXGI_MATRIX_3X2_F pMatrix);
            [PreserveSig]
            int GetMatrixTransform(out DXGI_MATRIX_3X2_F pMatrix);
        }

        [ComImport]
        [Guid("94d99bdb-f1f8-4ab0-b236-7da0170edab1")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapChain3 : IDXGISwapChain2
        {
            [PreserveSig]
            uint GetCurrentBackBufferIndex();
            [PreserveSig]
            int CheckColorSpaceSupport(DXGI_COLOR_SPACE_TYPE ColorSpace, out uint pColorSpaceSupport);
            [PreserveSig]
            int SetColorSpace1(DXGI_COLOR_SPACE_TYPE ColorSpace);
            [PreserveSig]
            int ResizeBuffers1(uint BufferCount, uint Width, uint Height, ref DXGI_FORMAT Format, uint SwapChainFlags, [In] uint[] pCreationNodeMask, [In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] ppPresentQueue);
        }

        [ComImport]
        [Guid("3d585d5a-bd4a-489e-b1f4-3dbcb6452ffb")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapChain4 : IDXGISwapChain3
        {
            [PreserveSig]
            int SetHDRMetaData(DXGI_HDR_METADATA_TYPE Type, uint Size, IntPtr pMetaData);
        }


        //
        // Devices
        //
        [ComImport]
        [Guid("54ec77fa-1377-44e6-8c32-88fd5f44c84c")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDevice : IDXGIObject
        {
            [PreserveSig]
            int GetAdapter(out IDXGIAdapter pAdapter);
            [PreserveSig]
            int CreateSurface(ref DXGI_SURFACE_DESC pDesc, uint NumSurfaces, ref DXGI_USAGE Usage, ref DXGI_SHARED_RESOURCE pSharedResource, out IntPtr ppSurface);
            [PreserveSig]
            int QueryResourceResidency([MarshalAs(UnmanagedType.IUnknown)] IntPtr ppResources, out DXGI_RESIDENCY pResidencyStatus, uint NumResources);
            [PreserveSig]
            int SetGPUThreadPriority(int Priority);
            [PreserveSig]
            int GetGPUThreadPriority(out int pPriority);
        }

        [ComImport]
        [Guid("77db970f-6276-48ba-ba28-070143b4392c")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDevice1 : IDXGIDevice
        {
            [PreserveSig]
            int SetMaximumFrameLatency(uint MaxLatency);
            [PreserveSig]
            int GetMaximumFrameLatency(out uint pMaxLatency);
        }

        [ComImport]
        [Guid("05008617-fbfd-4051-a790-144884b4f6a9")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDevice2 : IDXGIDevice1
        {
            [PreserveSig]
            int OfferResources(uint NumResources, ref IDXGIResource ppResources, ref _DXGI_OFFER_RESOURCE_PRIORITY Priority);
            [PreserveSig]
            int ReclaimResources(uint NumResources, ref IDXGIResource ppResources, out bool pDiscarded);
            [PreserveSig]
            int EnqueueSetEvent(IntPtr hEvent);
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
            int OfferResources1(uint NumResources, ref IDXGIResource ppResources, ref _DXGI_OFFER_RESOURCE_PRIORITY Priority, uint Flags);
            [PreserveSig]
            int ReclaimResources1(uint NumResources, ref IDXGIResource ppResources, ref _DXGI_RECLAIM_RESOURCE_RESULTS pResults);
        }

        //
        // Debug
        //
        [ComImport]
        [Guid("119e7452-de9e-40fe-8806-88f90c12b441")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDebug
        {
            [PreserveSig]
            int ReportLiveObjects(ref Guid apiid, DXGI_DEBUG_RLO_FLAGS flags);
        }

        [ComImport]
        [Guid("c5a05f0c-16f2-4adf-9f4d-a8c4d58ac550")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDebug1 : IDXGIDebug
        {
            [PreserveSig]
            void EnableLeakTrackingForThread();
            [PreserveSig]
            void DisableLeakTrackingForThread();
            [PreserveSig]
            [return: MarshalAs(UnmanagedType.Bool)]
            bool IsLeakTrackingEnabledForThread();
        }

        //
        // Resources
        //
        [ComImport]
        [Guid("035f3ab4-482e-4e50-b41f-8a7f8bd8960b")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIResource : IDXGIDeviceSubObject
        {
            [PreserveSig]
            int GetSharedHandle(out IntPtr pSharedHandle);
            [PreserveSig]
            int GetUsage(ref DXGI_USAGE pUsage);
            [PreserveSig]
            int SetEvictionPriority(uint EvictionPriority);
            [PreserveSig]
            int GetEvictionPriority(out uint pEvictionPriority);
        }

        [ComImport]
        [Guid("30961379-4609-4a41-998e-54fe567ee0c1")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIResource1 : IDXGIResource
        {
            [PreserveSig]
            int CreateSubresourceSurface(uint index, out IDXGISurface2 ppSurface);
            [PreserveSig]
            int CreateSharedHandle(ref _SECURITY_ATTRIBUTES pAttributes, uint dwAccess, string lpName, out IntPtr pHandle);
        }


        //
        // Surfaces
        //
        [ComImport]
        [Guid("cafcb56c-6ac3-4889-bf47-9e23bbd260ec")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISurface : IDXGIDeviceSubObject
        {
            [PreserveSig]
            int GetDesc(out DXGI_SURFACE_DESC pDesc);
            [PreserveSig]
            int Map(out DXGI_MAPPED_RECT pLockedRect, uint MapFlags);
            [PreserveSig]
            int Unmap();
        }

        [ComImport]
        [Guid("4ae63092-6327-4c1b-80ae-bfe12ea32b86")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISurface1 : IDXGISurface
        {
            [PreserveSig]
            int GetDC(bool Discard, out IntPtr phdc);
            [PreserveSig]
            int ReleaseDC(ref RECT pDirtyRect);
        }

        [ComImport]
        [Guid("aba496dd-b617-4cb8-a866-bc44d7eb1fa2")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISurface2 : IDXGISurface1
        {
            [PreserveSig]
            int GetResource(ref Guid riid, out IntPtr ppParentResource, out uint pSubresourceIndex);
        }


        //
        // Etc
        //
        [ComImport]
        [Guid("aec22fb8-76f3-4639-9be0-28eb43a67a2e")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIObject
        {
            [PreserveSig]
            int SetPrivateData(ref Guid Name, uint DataSize, IntPtr pData);

            [PreserveSig]
            int SetPrivateDataInterface(ref Guid Name, [MarshalAs(UnmanagedType.IUnknown)] object pUnknown);

            [PreserveSig]
            int GetPrivateData(ref Guid Name, ref uint pDataSize, IntPtr pData);

            [PreserveSig]
            int GetParent(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppParent);
        }

        [ComImport]
        [Guid("2633066b-4514-4c7a-8fd8-12ea98059d18")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDecodeSwapChain
        {
            [PreserveSig]
            int PresentBuffer(uint BufferToPresent, uint SyncInterval, uint Flags);
            [PreserveSig]
            int SetSourceRect(ref RECT pRect);
            [PreserveSig]
            int SetTargetRect(ref RECT pRect);
            [PreserveSig]
            int SetDestSize(uint Width, uint Height);
            [PreserveSig]
            int GetSourceRect(out RECT pRect);
            [PreserveSig]
            int GetTargetRect(out RECT pRect);
            [PreserveSig]
            int GetDestSize(out uint pWidth, out uint pHeight);
            [PreserveSig]
            int SetColorSpace(DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAGS ColorSpace);
            [PreserveSig]
            DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAGS GetColorSpace();

        }

        [ComImport]
        [Guid("3d3e0379-f9de-4d58-bb6c-18d62992f1a6")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIDeviceSubObject : IDXGIObject
        {
            [PreserveSig]
            int GetDevice(ref Guid riid, out IntPtr ppDevice);
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
            int CreateSwapChainForCompositionSurfaceHandle([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, IntPtr hSurface, ref DXGI_SWAP_CHAIN_DESC1 pDesc, IDXGIOutput pRestrictToOutput, out IDXGISwapChain1 ppSwapChain);
            [PreserveSig]
            int CreateDecodeSwapChainForCompositionSurfaceHandle([MarshalAs(UnmanagedType.IUnknown)] IntPtr pDevice, IntPtr hSurface, ref DXGI_DECODE_SWAP_CHAIN_DESC pDesc, ref IDXGIResource pYuvDecodeBuffers, IDXGIOutput pRestrictToOutput, out IDXGIDecodeSwapChain ppSwapChain);
        }

        [ComImport]
        [Guid("d67441c7-672a-476f-9e82-cd55b44949ce")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIInfoQueue
        {
            [PreserveSig]
            int SetMessageCountLimit(DXGI_DEBUG_ID Producer, ref UInt64 MessageCountLimit);
            [PreserveSig]
            void ClearStoredMessages(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            int GetMessage(ref DXGI_DEBUG_ID Producer, ref UInt64 MessageIndex, out DXGI_INFO_QUEUE_MESSAGE pMessage, ref nuint pMessageByteLength);
            [PreserveSig]
            UInt64 GetNumStoredMessagesAllowedByRetrievalFilters(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            UInt64 GetNumStoredMessages(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            UInt64 GetNumMessagesDiscardedByMessageCountLimit(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            UInt64 GetMessageCountLimit(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            UInt64 GetNumMessagesAllowedByStorageFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            UInt64 GetNumMessagesDeniedByStorageFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            int AddStorageFilterEntries(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_FILTER pFilter);
            [PreserveSig]
            int GetStorageFilter(ref DXGI_DEBUG_ID Producer, out DXGI_INFO_QUEUE_FILTER pFilter, nuint pFilterByteLength);
            [PreserveSig]
            void ClearStorageFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            int PushEmptyStorageFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            int PushDenyAllStorageFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            int PushCopyOfStorageFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            int PushStorageFilter(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_FILTER pFilter);
            [PreserveSig]
            void PopStorageFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            uint GetStorageFilterStackSize(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            int AddRetrievalFilterEntries(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_FILTER pFilter);
            [PreserveSig]
            int GetRetrievalFilter(ref DXGI_DEBUG_ID Producer, out DXGI_INFO_QUEUE_FILTER pFilter, nuint pFilterByteLength);
            [PreserveSig]
            void ClearRetrievalFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            int PushEmptyRetrievalFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            int PushDenyAllRetrievalFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            int PushCopyOfRetrievalFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            int PushRetrievalFilter(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_FILTER pFilter);
            [PreserveSig]
            void PopRetrievalFilter(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            uint GetRetrievalFilterStackSize(ref DXGI_DEBUG_ID Producer);
            [PreserveSig]
            int AddMessage(ref DXGI_DEBUG_ID Producer, DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category, DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, uint ID, string pDescription);
            [PreserveSig]
            int AddApplicationMessage(ref DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, string pDescription);
            [PreserveSig]
            int SetBreakOnCategory(ref DXGI_DEBUG_ID Producer, DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category, bool bEnable);
            [PreserveSig]
            int SetBreakOnSeverity(ref DXGI_DEBUG_ID Producer, DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, bool bEnable);
            [PreserveSig]
            int SetBreakOnID(ref DXGI_DEBUG_ID Producer, uint ID, bool bEnable);
            [PreserveSig]
            [return: MarshalAs(UnmanagedType.Bool)]
            bool GetBreakOnCategory(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category);
            [PreserveSig]
            [return: MarshalAs(UnmanagedType.Bool)]
            bool GetBreakOnSeverity(ref DXGI_DEBUG_ID Producer, ref DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity);
            [PreserveSig]
            [return: MarshalAs(UnmanagedType.Bool)]
            bool GetBreakOnID(ref DXGI_DEBUG_ID Producer, uint ID);
            [PreserveSig]
            void SetMuteDebugOutput(ref DXGI_DEBUG_ID Producer, bool bMute);
            [PreserveSig]
            [return: MarshalAs(UnmanagedType.Bool)]
            bool GetMuteDebugOutput(ref DXGI_DEBUG_ID Producer);
        }

        [ComImport]
        [Guid("9d8e1289-d7b3-465f-8126-250e349af85d")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIKeyedMutex : IDXGIObject
        {
            [PreserveSig]
            int AcquireSync(UInt64 Key, uint dwMilliseconds);
            [PreserveSig]
            int ReleaseSync(UInt64 Key);
        }

        [ComImport]
        [Guid("191cfac3-a341-470d-b26e-a864f428319c")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGIOutputDuplication
        {
            [PreserveSig]
            void GetDesc(out DXGI_OUTDUPL_DESC pDesc);
            [PreserveSig]
            int AcquireNextFrame(uint TimeoutInMilliseconds, out DXGI_OUTDUPL_FRAME_INFO pFrameInfo, out IDXGIResource ppDesktopResource);
            [PreserveSig]
            int GetFrameDirtyRects(uint DirtyRectsBufferSize, out RECT pDirtyRectsBuffer, out uint pDirtyRectsBufferSizeRequired);
            [PreserveSig]
            int GetFrameMoveRects(uint MoveRectsBufferSize, out DXGI_OUTDUPL_MOVE_RECT pMoveRectBuffer, out uint pMoveRectsBufferSizeRequired);
            [PreserveSig]
            int GetFramePointerShape(uint PointerShapeBufferSize, out IntPtr pPointerShapeBuffer, out uint pPointerShapeBufferSizeRequired, out DXGI_OUTDUPL_POINTER_SHAPE_INFO pPointerShapeInfo);
            [PreserveSig]
            int MapDesktopSurface(out DXGI_MAPPED_RECT pLockedRect);
            [PreserveSig]
            int UnMapDesktopSurface();
            [PreserveSig]
            int ReleaseFrame();
        }

        [ComImport]
        [Guid("dd95b0ed-466f-461c-91d5-7b32f25f1716")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDXGISwapChainMedia
        {
            [PreserveSig]
            int GetFrameStatisticsMedia(out DXGI_FRAME_STATISTICS_MEDIA pStats);
            [PreserveSig]
            int SetPresentDuration(uint Duration);
            [PreserveSig]
            int CheckPresentDurationSupport(uint DesiredPresentDuration, out uint pClosestSmallerPresentDuration, out uint pClosestLargetPresentDuration);
        }
    }
}
