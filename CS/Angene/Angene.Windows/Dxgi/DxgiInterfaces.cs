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
        public interface IDXGIAdapter1
        {
            [PreserveSig]
            uint GetDesc1([MarshalAs(UnmanagedType.IUnknown)] out DXGI_ADAPTER_DESC1 pDesc);
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
    }
}
