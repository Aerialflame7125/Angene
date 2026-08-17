using System;
using Angene.Essentials;
using Angene.Main;
using Angene.X11.Interop;
using static Angene.X11.Interop.XLib;

namespace Game
{
    /// <summary>
    /// Polling-based keyboard state for X11/Linux, using XQueryKeymap + XKeysymToKeycode.
    ///
    /// WHY POLLING INSTEAD OF THE ENGINE'S KeyDetection:
    /// Angene.Input.KeyDetection relies on KeyDetectionScript.OnMessage(IntPtr msgPtr),
    /// which marshals msgPtr as a Win32 WindowManagement.MSG and switches on WM.KEYDOWN /
    /// WM.KEYUP -- there is no X11 code path there at all. Worse, on Linux,
    /// Engine.ProcessMessages() never calls scene.OnMessage()/any script's OnMessage() for
    /// individual X11 events in the first place: it drains the queue with XNextEvent, only
    /// special-cases the WM_DELETE_WINDOW ClientMessage, and otherwise just invokes
    /// injectedCalls with the bare xevent.type int (no keycode, no key data). So even a
    /// correctly-X11-aware OnMessage handler would never be called with real key events on
    /// this backend today.
    ///
    /// XQueryKeymap sidesteps all of that: it asks the X server for the current state of
    /// every key on the keyboard directly, independent of the (non-functional for this
    /// purpose) event dispatch pipeline.
    /// </summary>
    public static unsafe class X11Keyboard
    {
        /// <summary>
        /// True if the given X11 keysym (e.g. from Keys.IKeyCodeLangX.IKeyCodeLatin1X or
        /// Keys.IKeyCodeCursorControlX) is currently held down.
        /// </summary>
        public static bool IsKeyDown(nuint keysym)
        {
            var display = Engine.Instance.SharedX11Display;
            if (display == null)
                return false;

            byte keycode = XLib.Methods.XKeysymToKeycode(display, keysym);
            if (keycode == 0)
                return false;

            byte* keys = stackalloc byte[32];
            XLib.Methods.XQueryKeymap(display, (sbyte*)keys);

            int byteIndex = keycode >> 3;
            int bitIndex = keycode & 7;
            return (keys[byteIndex] & (1 << bitIndex)) != 0;
        }
    }
}
