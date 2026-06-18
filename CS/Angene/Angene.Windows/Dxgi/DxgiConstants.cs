using System.Runtime.InteropServices;

namespace Angene.Windows.Dxgi
{
    public class DxgiConstants
    {
        public const uint S_OK = 0; // Returned if OK.
        public static readonly Guid DXGI_DEBUG_ALL = new Guid("e48ae283-da80-490b-87e6-43e9a9cfda08");
        public static readonly Guid DXGI_DEBUG_DX = new Guid("35cdd7fc-13b2-421d-a5d7-7e4451287d64");
        public static readonly Guid DXGI_DEBUG_DXGI = new Guid("25cddaa4-b1c6-47e1-ac3e-98875b5a2e2a");
        public static readonly Guid DXGI_DEBUG_APP = new Guid("06cd6e01-4219-4ebd-8709-27ed23360c62");
        public const uint D3D11_CLEAR_DEPTH = 0x00000001;
    }
}
