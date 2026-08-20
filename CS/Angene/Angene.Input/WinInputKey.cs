using Org.BouncyCastle.Crypto.Engines;
using System;

namespace Angene.Input
{
    public partial class Key
    {
        public static object TryInt(int n)
        {
            uint a = (uint)n;
            return TryByte(a);
        }

        public static object TryNInt(nint n)
        {
            uint a = (uint)n;
            return TryByte(a);
        }

        public static object TryByte(uint keyCode)
        {
            if (Enum.IsDefined(typeof(Keys.IKeyCodeASCIIWin), keyCode))
                return (Keys.IKeyCodeASCIIWin)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeNumWin), keyCode))
                return (Keys.IKeyCodeNumWin)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeFuncWin), keyCode))
                return (Keys.IKeyCodeFuncWin)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeModWin), keyCode))
                return (Keys.IKeyCodeModWin)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeSpecialWin), keyCode))
                return (Keys.IKeyCodeSpecialWin)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeArrowWin), keyCode))
                return (Keys.IKeyCodeArrowWin)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeNumPadWin), keyCode))
                return (Keys.IKeyCodeNumPadWin)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeGamePadWin), keyCode))
                return (Keys.IKeyCodeGamePadWin)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeMouseWin), keyCode))
                return (Keys.IKeyCodeMouseWin)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeOEMWin), keyCode))
                return (Keys.IKeyCodeOEMWin)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeBrowserWin), keyCode))
                return (Keys.IKeyCodeBrowserWin)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeMediaWin), keyCode))
                return (Keys.IKeyCodeMediaWin)keyCode;

            else if (Enum.IsDefined(typeof(Keys.IKeyCodeExtraX), keyCode))
                return (Keys.IKeyCodeExtraX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeModX), keyCode))
                return (Keys.IKeyCodeModX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeMultiKeyX), keyCode))
                return (Keys.IKeyCodeMultiKeyX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeCursorControlX), keyCode))
                return (Keys.IKeyCodeCursorControlX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeMiscX), keyCode))
                return (Keys.IKeyCodeMiscX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeNumPadX), keyCode))
                return (Keys.IKeyCodeNumPadX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeFuncX), keyCode))
                return (Keys.IKeyCodeFuncX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeXKBExtensionX), keyCode))
                return (Keys.IKeyCodeXKBExtensionX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCode3270X), keyCode))
                return (Keys.IKeyCode3270X)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeJPX), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeJPX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeLatin1X), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeLatin1X)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeLatin2X), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeLatin2X)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeLatin3X), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeLatin3X)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeLatin4X), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeLatin4X)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeLatin8X), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeLatin8X)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeLatin9X), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeLatin9X)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeJPKatakanaX), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeJPKatakanaX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeARX), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeARX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeRUX), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeRUX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeGRX), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeGRX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeAPLX), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeAPLX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeHBX), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeHBX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeTHX), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeTHX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeKRX), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeKRX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeHYX), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeHYX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeGEX), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeGEX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeAZX), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeAZX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangX.IKeyCodeVNX), keyCode))
                return (Keys.IKeyCodeLangX.IKeyCodeVNX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeTechnicalX), keyCode))
                return (Keys.IKeyCodeTechnicalX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeSpecialX), keyCode))
                return (Keys.IKeyCodeSpecialX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodePublishingX), keyCode))
                return (Keys.IKeyCodePublishingX)keyCode;
            else if (Enum.IsDefined(typeof(Keys.IKeyCodeCurrencyX), keyCode))
                return (Keys.IKeyCodeCurrencyX)keyCode;

            else
                return 0;
        }
    }
    public partial struct Keys
    {
        public enum IKeyCodeASCIIWin : uint
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
        public enum IKeyCodeNumWin : uint
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
        public enum IKeyCodeFuncWin : uint
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
        public enum IKeyCodeModWin : uint
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
        public enum IKeyCodeSpecialWin : uint
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
        public enum IKeyCodeArrowWin : uint
        {
            Left = 0x25,
            Up = 0x26,
            Right = 0x27,
            Down = 0x28,
        }
        public enum IKeyCodeNumPadWin : uint
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
        public enum IKeyCodeGamePadWin : uint
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
        public enum IKeyCodeMouseWin : uint
        {
            LMouse = 0x01,
            RMouse = 0x02,
            XButton1 = 0x05,
            XButton2 = 0x06,
        }
        public enum IKeyCodeOEMWin : uint // Keys labeled as OEM
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
        public enum IKeyCodeBrowserWin : uint
        {
            BrowserBack = 0xA6,
            BrowserForward = 0xA7,
            BrowserRefresh = 0xA8,
            BrowserStop = 0xA9,
            BrowserSearch = 0xAA,
            BrowserFavorites = 0xAB,
            BrowserHome = 0xAC,
        }
        public enum IKeyCodeMediaWin : uint
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