using Org.BouncyCastle.Crypto.Engines;
using System;

namespace Angene.Input.WinInput
{
    public class Key
    {
        public static object TryInt(int n)
        {
            byte a = (byte)n;
            return TryByte(a);
        }

        public static object TryNInt(nint n)
        {
            byte a = (byte)n;
            return TryByte(a);
        }

        public static object TryByte(byte keyCode)
        {
            if (Enum.IsDefined(typeof(Keys.IKeyCodeASCII), keyCode))
            {
                return (Keys.IKeyCodeASCII)keyCode;
            }
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeNum), keyCode))
            {
                return (Keys.IKeyCodeNum)keyCode;
            }
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeFunc), keyCode))
            {
                return (Keys.IKeyCodeFunc)keyCode;
            }
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeMod), keyCode))
            {
                return (Keys.IKeyCodeMod)keyCode;
            }
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeSpecial), keyCode))
            {
                return (Keys.IKeyCodeSpecial)keyCode;
            }
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeArrow), keyCode))
            {
                return (Keys.IKeyCodeArrow)keyCode;
            }
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeNumPad), keyCode))
            {
                return (Keys.IKeyCodeNumPad)keyCode;
            }
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeGamePad), keyCode))
            {
                return (Keys.IKeyCodeGamePad)keyCode;
            }
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeMouse), keyCode))
            {
                return (Keys.IKeyCodeMouse)keyCode;
            }
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeOEM), keyCode))
            {
                return (Keys.IKeyCodeOEM)keyCode;
            }
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeBrowser), keyCode))
            {
                return (Keys.IKeyCodeBrowser)keyCode;
            }
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeMedia), keyCode))
            {
                return (Keys.IKeyCodeMedia)keyCode;
            }
            else
            {
                return 0;
            }
        }
    }
    public struct Keys
    {
        public enum IKeyCodeASCII : byte
        {
            a = 0x41,
            b = 0x42,
            c = 0x43,
            d = 0x44,
            e = 0x45,
            f = 0x46,
            g = 0x47,
            h = 0x48,
            i = 0x49,
            j = 0x4A,
            k = 0x4B,
            l = 0x4C,
            m = 0x4D,
            n = 0x4E,
            o = 0x4F,
            p = 0x50,
            q = 0x51,
            r = 0x52,
            s = 0x53,
            t = 0x54,
            u = 0x55,
            v = 0x56,
            w = 0x57,
            x = 0x58,
            y = 0x59,
            z = 0x5A,
        }
        public enum IKeyCodeNum : byte
        {
            d0 = 0x30,
            d1 = 0x31,
            d2 = 0x32,
            d3 = 0x33,
            d4 = 0x34,
            d5 = 0x35,
            d6 = 0x36,
            d7 = 0x37,
            d8 = 0x38,
            d9 = 0x39,
        }
        public enum IKeyCodeFunc : byte
        {
            f1 = 0x70,
            f2 = 0x71,
            f3 = 0x72,
            f4 = 0x73,
            f5 = 0x74,
            f6 = 0x75,
            f7 = 0x76,
            f8 = 0x77,
            f9 = 0x78,
            f10 = 0x79,
            f11 = 0x7A,
            f12 = 0x7B,
            f13 = 0x7C,
            f14 = 0x7D,
            f15 = 0x7E,
            f16 = 0x7F,
            f17 = 0x80,
            f18 = 0x81,
            f19 = 0x82,
            f20 = 0x83,
            f21 = 0x84,
            f22 = 0x85,
            f23 = 0x86,
            f24 = 0x87,
        }
        public enum IKeyCodeMod : byte
        {
            Shift = 0x10,
            LShift = 0xA0,
            RShift = 0xA1,
            Ctrl = 0x11,
            LCtrl = 0xA2,
            RCtrl = 0xA3,
            Alt = 0x12,
            LAlt = 0xA4,
            RAlt = 0xA5,
            End = 0x23,
            Escape = 0x1B,
            LWin = 0x5B,
            RWin = 0x5C,
            Space = 0x20,
        }
        public enum IKeyCodeSpecial : byte
        {
            None = 0,
            Cancel = 0x03,
            Apps = 0x5D,
            Help = 0x2F,
            Home = 0x24,
            Zoom = 0xFB,
            CrSel = 0xF3,
            ExSel = 0xF4,
            PA1 = 0xFD,
            IMEConvert = 0x1C,
            IMENonconvert = 0x1D,
            IMEAccept = 0x1E,
            IMEModeChange = 0x1F,
            ProcessKey = 0xE5,
            Packet = 0xE7,
            Attn = 0xF6,
            EraseEof = 0xF5,
        }
        public enum IKeyCodeArrow : byte
        {
            Left = 0x25,
            Up = 0x26,
            Right = 0x27,
            Down = 0x28,
        }
        public enum IKeyCodeNumPad : byte
        {
            NumLock = 0x90,
            Divide = 0x6F,
            Multiply = 0x6A,
            Subtract = 0x6D,
            Add = 0x6B,
            Decimal = 0x6E,
            np0 = 0x60,
            np1 = 0x61,
            np2 = 0x62,
            np3 = 0x63,
            np4 = 0x64,
            np5 = 0x65,
            np6 = 0x66,
            np7 = 0x67,
            np8 = 0x68,
            np9 = 0x69,
        }
        public enum IKeyCodeGamePad : byte
        {
            a = 0xC3,
            b = 0xC4,
            x = 0xC5,
            y = 0xC6,
            leftShoulder = 0xC7,
            rightShoulder = 0xC8,
            leftThumb = 0xC9,
            rightThumb = 0xCA,
            dpadUp = 0xCB,
            dpadDown = 0xCC,
            dpadLeft = 0xCD,
            dpadRight = 0xCE,
            menu = 0xCF,
            view = 0xD0,
            lThumbUp = 0xD1,
            lThumbDown = 0xD2,
            lThumbRight = 0xD3,
            lThumbLeft = 0xD4,
            rThumbUp = 0xD5,
            rThumbDown = 0xD6,
            rThumbRight = 0xD7,
            rThumbLeft = 0xD8,
        }
        public enum IKeyCodeMouse : byte
        {
            LMouse = 0x01,
            RMouse = 0x02,
            XButton1 = 0x05,
            XButton2 = 0x06,
        }
        public enum IKeyCodeOEM : byte // Keys labeled as OEM
        {
            OEM1 = 0xBA,
            OEM2 = 0xBF,
            OEM3 = 0xC0,
            OEM4 = 0xDB,
            OEM5 = 0xDC,
            OEM6 = 0xDD,
            OEM7 = 0xDE,
            OEM8 = 0xDF,
            OEM102 = 0xE2,
            OEMPlus = 0xBB,
            OEMComma = 0xBC,
            OEMMinus = 0xBD,
            OEMPeriod = 0xBE,
            OEMClear = 0xFE,
        }
        public enum IKeyCodeBrowser : byte
        {
            BrowserBack = 0xA6,
            BrowserForward = 0xA7,
            BrowserRefresh = 0xA8,
            BrowserStop = 0xA9,
            BrowserSearch = 0xAA,
            BrowserFavorites = 0xAB,
            BrowserHome = 0xAC,
        }
        public enum IKeyCodeMedia : byte
        {
            Play = 0xFA,
            VolumeMute = 0xAD,
            VolumeDown = 0xAE,
            VolumeUp = 0xAF,
            MediaNextTrack = 0xB0,
            MediaPrevTrack = 0xB1,
            MediaStop = 0xB2,
            MediaPlayPause = 0xB3,
        }
    }
}