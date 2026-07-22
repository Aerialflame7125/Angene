using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angene.Windows
{
    public class Consts
    {
        public const uint WS_POPUP = 0x80000000;
        public const uint WS_EX_LAYERED = 0x00080000;
        public const uint WS_EX_TRANSPARENT = 0x00000020;
        public const uint WS_EX_TOPMOST = 0x00000008;

        public const int LWA_COLORKEY = 0x1;
        public const int LWA_ALPHA = 0x2;

        public const int GWL_EXSTYLE = -20;

        // icon related constants
        public const uint IMAGE_ICON = 1;
        public const uint LR_DEFAULTSIZE = 0x00000040;
        public const uint LR_LOADFROMFILE = 0x00000010;
        public const uint WM_SETICON = 0x0080;
        public const int ICON_SMALL = 0;
        public const int ICON_BIG = 1;

        public const uint LR_DEFAULTCOLOR = 0x00000000;

        // gdi? need to look up meanings.
        public const uint GR_GDIOBJECTS = 0;
        public const int PM_REMOVE = 0x0001; //PeakMessage_Remove

        public const int CW_USEDEFAULT = unchecked((int)0x80000000); // Default value for x, y pos on CreateWindowExA
        public const int SW_SHOW = 5; // Focus window and make it visible
    }
}
