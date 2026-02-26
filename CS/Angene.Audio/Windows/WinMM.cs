using System.Runtime.InteropServices;
using System.Text;

namespace Angene.Audio.Windows
{
    public class WinMM
    {
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern int mciSendString(string cmd, StringBuilder ret, int retLen, IntPtr hwnd);
    }
}
