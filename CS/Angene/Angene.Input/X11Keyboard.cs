using System;
using Angene.Essentials;
using Angene.X11.Interop;
using static Angene.X11.Interop.XLib;
using System.Collections.Generic;

namespace Angene.Input
{
    internal static unsafe class X11Keyboard
    {
        /// <summary>
        /// True if the given X11 keysym (e.g. from Keys.IKeyCodeLangX.IKeyCodeLatin1X or
        /// Keys.IKeyCodeCursorControlX) is currently held down.
        /// </summary>
        public static bool IsKeyDown(nuint keysym)
        {
            var display = Main.Engine.Instance.SharedX11Display;
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
        public static bool IsKeyDown()
        {
            var display = Main.Engine.Instance.SharedX11Display;
            if (display == null)
                return false;

            byte* keys = stackalloc byte[32];
            XLib.Methods.XQueryKeymap(display, (sbyte*)keys);

            // XQueryKeymap fills 32 bytes (256 bits). 
            // Reinterpret as 64-bit integers to check 8 bytes at a time for speed.
            ulong* ptr = (ulong*)keys;
            return (ptr[0] | ptr[1] | ptr[2] | ptr[3]) != 0;
        }

        public static List<nuint> GetPressedKeys()
        {
            var pressedKeys = new List<nuint>();

            var display = Main.Engine.Instance.SharedX11Display;
            if (display == null)
                return pressedKeys;

            byte* keys = stackalloc byte[32];
            XLib.Methods.XQueryKeymap(display, (sbyte*)keys);

            for (int keycode = 0; keycode < 256; keycode++)
            {
                int byteIndex = keycode >> 3;
                int bitIndex = keycode & 7;

                if ((keys[byteIndex] & (1 << bitIndex)) != 0)
                {
                    // Convert the physical X11 keycode back to a KeySym.
                    // Index 0 represents the un-shifted key state.
                    nuint keysym = XLib.Methods.XKeycodeToKeysym(display, (byte)keycode, 0);
                    if (keysym != 0)
                    {
                        pressedKeys.Add(keysym);
                    }
                }
            }

            return pressedKeys;
        }
    }
}
