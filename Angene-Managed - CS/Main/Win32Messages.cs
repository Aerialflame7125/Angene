namespace Angene.Main
{
    // window messages (wm)
    public enum WM : uint
    {
        NULL            = 0x0000,
        CREATE          = 0x0001,
        DESTROY         = 0x0002,
        MOVE            = 0x0003,
        SIZE            = 0x0005,
        SETFOCUS        = 0x0007,
        KILLFOCUS       = 0x0008,
        PAINT           = 0x000F,
        CLOSE           = 0x0010,
        QUIT            = 0x0012,
        ERASEBKGND      = 0x0014,

        KEYDOWN         = 0x0100,
        KEYUP           = 0x0101,
        CHAR            = 0x0102,

        MOUSEMOVE       = 0x0200,
        LBUTTONDOWN     = 0x0201,
        LBUTTONUP       = 0x0202,
        RBUTTONDOWN     = 0x0204,
        RBUTTONUP       = 0x0205,
        MOUSEWHEEL      = 0x020A,

        ENTERSIZEMOVE   = 0x0231,
        EXITSIZEMOVE    = 0x0232,
    }

    // edit messages (em)
    public enum EM : uint
    {
        GETSEL          = 0x00B0,
        SETSEL          = 0x00B1,
        GETRECT         = 0x00B2,
        SETRECT         = 0x00B3,
        REPLACESEL      = 0x00C2,
        GETLINE         = 0x00C4,
    }

    // window styles (ws)
    public static class WS
    {
        public const uint OVERLAPPED       = 0x00000000;
        public const uint POPUP            = 0x80000000;
        public const uint CHILD            = 0x40000000;
        public const uint VISIBLE          = 0x10000000;
        public const uint DISABLED         = 0x08000000;
        public const uint CLIPSIBLINGS     = 0x04000000;
        public const uint CLIPCHILDREN     = 0x02000000;
        public const uint SYSMENU          = 0x00080000;
        public const uint THICKFRAME       = 0x00040000;
    }

    // extended window styles (ws_ex)
    public static class WS_EX
    {
        public const uint TOPMOST           = 0x00000008;
        public const uint TOOLWINDOW        = 0x00000080;
        public const uint APPWINDOW         = 0x00040000;
        public const uint LAYERED           = 0x00080000;
        public const uint NOACTIVATE        = 0x08000000;
    }

    // setwindowprocess (swp)
    public static class SWP
    {
        public const uint NOSIZE        = 0x0001;
        public const uint NOMOVE        = 0x0002;
        public const uint NOZORDER      = 0x0004;
        public const uint NOACTIVATE    = 0x0010;
        public const uint SHOWWINDOW    = 0x0040;
    }
}
