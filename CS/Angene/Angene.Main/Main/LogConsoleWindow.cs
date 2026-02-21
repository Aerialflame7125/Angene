#if WINDOWS
using System;
using System.Runtime.InteropServices;

namespace Angene.Main
{
    public class LogConsoleWindow
    {
        private IntPtr _hwnd;
        private IntPtr _editHwnd;

        private static readonly Win32.WndProcDelegate s_wndProc = WndProc;
        private static bool s_classRegistered = false;

        // Edit control styles not in your WS class yet — keeping as locals for clarity
        private const uint ES_MULTILINE = 0x0004;
        private const uint ES_AUTOVSCROLL = 0x0040;
        private const uint ES_READONLY = 0x0800;
        private const uint WS_VSCROLL = 0x00200000;
        private const uint WS_CAPTION = 0x00C00000;
        private const uint WS_MINIMIZEBOX = 0x00020000;
        private const uint WS_MAXIMIZEBOX = 0x00010000;
        private const uint EM_SETLIMITTEXT = 0x00C5;
        private const uint WM_CTLCOLOREDIT = 0x0133;

        private const uint WM_SETFONT = 0x0030;
        private const uint WM_SIZE = (uint)WM.SIZE;

        [DllImport("gdi32.dll")]
        private static extern uint SetTextColor(IntPtr hdc, uint crColor);

        [DllImport("gdi32.dll")]
        private static extern uint SetBkColor(IntPtr hdc, uint crColor);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateSolidBrush(uint crColor); // already present

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr CreateFont(
            int nHeight, int nWidth, int nEscapement, int nOrientation,
            int fnWeight, uint fdwItalic, uint fdwUnderline, uint fdwStrikeOut,
            uint fdwCharSet, uint fdwOutputPrecision, uint fdwClipPrecision,
            uint fdwQuality, uint fdwPitchAndFamily, string lpszFace);

        [DllImport("user32.dll")]
        private static extern IntPtr LoadCursor(IntPtr hInstance, IntPtr lpCursorName);

        [DllImport("user32.dll")]
        private static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);

        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int w, int h, bool repaint);

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        private const uint GW_CHILD = 5;
        private const int IDC_IBEAM = 32513;
        private const int IDI_APPLICATION = 32512;
        private static IntPtr s_bgBrush = IntPtr.Zero;

        public LogConsoleWindow()
        {
            if (!s_classRegistered)
            {
                var wc = new Win32.WNDCLASSEX
                {
                    cbSize = (uint)Marshal.SizeOf<Win32.WNDCLASSEX>(),
                    style = 0x0003, // CS_HREDRAW | CS_VREDRAW
                    lpfnWndProc = s_wndProc,
                    cbClsExtra = 0,
                    cbWndExtra = 0,
                    hInstance = Kernel32.GetModuleHandle(null),
                    hIcon = LoadIcon(IntPtr.Zero, new IntPtr(IDI_APPLICATION)),
                    hCursor = LoadCursor(IntPtr.Zero, new IntPtr(IDC_IBEAM)),
                    hbrBackground = CreateSolidBrush(0x00000000), // black
                    lpszMenuName = null,
                    lpszClassName = "AngeneLogConsole",
                    hIconSm = LoadIcon(IntPtr.Zero, new IntPtr(IDI_APPLICATION))
                };

                if (Win32.RegisterClassExW(ref wc) == 0)
                    throw new AngeneException("Failed to register LogConsoleWindow class.");
                s_bgBrush = CreateSolidBrush(0x00000000);
                s_classRegistered = true;
            }

            uint windowStyle = WS.OVERLAPPED | WS_CAPTION | WS.SYSMENU
                             | WS.THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX
                             | WS.CLIPSIBLINGS | WS.CLIPCHILDREN;

            _hwnd = Win32.CreateWindowExW(
                (uint)Win32.WindowStyleEx.AppWindow,
                "AngeneLogConsole",
                "Angene — Log Console",
                windowStyle,
                50, 50, 900, 500,
                IntPtr.Zero, IntPtr.Zero,
                Kernel32.GetModuleHandle(null),
                IntPtr.Zero
            );

            if (_hwnd == IntPtr.Zero)
                throw new AngeneException("Failed to create LogConsoleWindow.");

            uint editStyle = WS.CHILD | WS.VISIBLE | WS_VSCROLL
                           | ES_MULTILINE | ES_AUTOVSCROLL | ES_READONLY;

            _editHwnd = Win32.CreateWindowExW(
                0,
                "EDIT",
                "",
                editStyle,
                0, 0, 900, 500,
                _hwnd, IntPtr.Zero,
                Kernel32.GetModuleHandle(null),
                IntPtr.Zero
            );

            if (_editHwnd == IntPtr.Zero)
                throw new AngeneException("Failed to create log EDIT control.");

            IntPtr hFont = CreateFont(
                14, 0, 0, 0, 400, 0, 0, 0,
                1,  // ANSI_CHARSET
                0, 0, 0, 1,
                "Consolas"
            );
            Win32.SendMessage(_editHwnd, EM_SETLIMITTEXT, new IntPtr(int.MaxValue), IntPtr.Zero);

            Win32.ShowWindow(_hwnd, Win32.SW_SHOW);
            Win32.UpdateWindow(_hwnd);
        }

        private const uint EM_GETLINECOUNT = 0x00BA;
        private const uint EM_LINEINDEX = 0x00BB;
        private const int MAX_LINES = 500; // adjust as needed

        public void AppendLine(string text)
        {
            // Remove first line if over the limit
            int lineCount = (int)Win32.SendMessage(_editHwnd, EM_GETLINECOUNT, IntPtr.Zero, IntPtr.Zero).ToInt64();
            if (lineCount >= MAX_LINES)
            {
                // Get char index of start of line 0 and line 1
                int line0Start = (int)Win32.SendMessage(_editHwnd, EM_LINEINDEX, new IntPtr(0), IntPtr.Zero).ToInt64();
                int line1Start = (int)Win32.SendMessage(_editHwnd, EM_LINEINDEX, new IntPtr(1), IntPtr.Zero).ToInt64();

                // Select from start of line 0 to start of line 1 (includes the \r\n)
                Win32.SendMessage(_editHwnd, (uint)EM.SETSEL, new IntPtr(line0Start), new IntPtr(line1Start));

                // Delete the selection by replacing with empty string
                IntPtr empty = Marshal.StringToHGlobalUni("");
                try
                {
                    Win32.SendMessage(_editHwnd, (uint)EM.REPLACESEL, IntPtr.Zero, empty);
                }
                finally
                {
                    Marshal.FreeHGlobal(empty);
                }
            }

            // Append new line at end
            int len = GetWindowTextLength(_editHwnd);
            Win32.SendMessage(_editHwnd, (uint)EM.SETSEL, new IntPtr(len), new IntPtr(len));

            IntPtr strPtr = Marshal.StringToHGlobalUni(text + "\r\n");
            try
            {
                Win32.SendMessage(_editHwnd, (uint)EM.REPLACESEL, IntPtr.Zero, strPtr);
            }
            finally
            {
                Marshal.FreeHGlobal(strPtr);
            }
        }

        private static IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            if (msg == WM_CTLCOLOREDIT)
            {
                IntPtr hdc = wParam;
                SetTextColor(hdc, 0x00FFFFFF); // white text (BGR)
                SetBkColor(hdc, 0x00000000);   // black background
                return s_bgBrush;
            }

            if (msg == WM_SIZE)
            {
                int width = (int)(lParam.ToInt64() & 0xFFFF);
                int height = (int)((lParam.ToInt64() >> 16) & 0xFFFF);

                IntPtr hEdit = GetWindow(hWnd, GW_CHILD);
                if (hEdit != IntPtr.Zero)
                    MoveWindow(hEdit, 0, 0, width, height, true);

                return IntPtr.Zero;
            }

            if (msg == (uint)WM.CLOSE)
            {
                Win32.DestroyWindow(hWnd);
                return IntPtr.Zero;
            }

            if (msg == (uint)WM.DESTROY)
            {
                Win32.PostQuitMessage(0);
                return IntPtr.Zero;
            }

            return Win32.DefWindowProcW(hWnd, msg, wParam, lParam);
        }
    }
}
#endif