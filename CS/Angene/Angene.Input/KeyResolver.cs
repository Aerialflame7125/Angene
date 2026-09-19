using Angene.Linux.Wayland;
using Angene.Linux.X11;
using Angene.Windows;

namespace Angene.Input;

public class KeyResolver
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
        if (Enum.IsDefined(typeof(WinInputKeys.IKeyCodeASCIIWin), keyCode))
            return (WinInputKeys.IKeyCodeASCIIWin)keyCode;
        else if (Enum.IsDefined(typeof(WinInputKeys.IKeyCodeNumWin), keyCode))
            return (WinInputKeys.IKeyCodeNumWin)keyCode;
        else if (Enum.IsDefined(typeof(WinInputKeys.IKeyCodeFuncWin), keyCode))
            return (WinInputKeys.IKeyCodeFuncWin)keyCode;
        else if (Enum.IsDefined(typeof(WinInputKeys.IKeyCodeModWin), keyCode))
            return (WinInputKeys.IKeyCodeModWin)keyCode;
        else if (Enum.IsDefined(typeof(WinInputKeys.IKeyCodeSpecialWin), keyCode))
            return (WinInputKeys.IKeyCodeSpecialWin)keyCode;
        else if (Enum.IsDefined(typeof(WinInputKeys.IKeyCodeArrowWin), keyCode))
            return (WinInputKeys.IKeyCodeArrowWin)keyCode;
        else if (Enum.IsDefined(typeof(WinInputKeys.IKeyCodeNumPadWin), keyCode))
            return (WinInputKeys.IKeyCodeNumPadWin)keyCode;
        else if (Enum.IsDefined(typeof(WinInputKeys.IKeyCodeGamePadWin), keyCode))
            return (WinInputKeys.IKeyCodeGamePadWin)keyCode;
        else if (Enum.IsDefined(typeof(WinInputKeys.IKeyCodeMouseWin), keyCode))
            return (WinInputKeys.IKeyCodeMouseWin)keyCode;
        else if (Enum.IsDefined(typeof(WinInputKeys.IKeyCodeOEMWin), keyCode))
            return (WinInputKeys.IKeyCodeOEMWin)keyCode;
        else if (Enum.IsDefined(typeof(WinInputKeys.IKeyCodeBrowserWin), keyCode))
            return (WinInputKeys.IKeyCodeBrowserWin)keyCode;
        else if (Enum.IsDefined(typeof(WinInputKeys.IKeyCodeMediaWin), keyCode))
            return (WinInputKeys.IKeyCodeMediaWin)keyCode;

        
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeExtraLinux), keyCode))
            return (X11InputKeys.IKeyCodeExtraLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeModLinux), keyCode))
            return (X11InputKeys.IKeyCodeModLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeMultiKeyLinux), keyCode))
            return (X11InputKeys.IKeyCodeMultiKeyLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeCursorControlLinux), keyCode))
            return (X11InputKeys.IKeyCodeCursorControlLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeMiscLinux), keyCode))
            return (X11InputKeys.IKeyCodeMiscLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeNumPadLinux), keyCode))
            return (X11InputKeys.IKeyCodeNumPadLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeFuncLinux), keyCode))
            return (X11InputKeys.IKeyCodeFuncLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeXKBExtensionLinux), keyCode))
            return (X11InputKeys.IKeyCodeXKBExtensionLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCode3270Linux), keyCode))
            return (X11InputKeys.IKeyCode3270Linux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeJP), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeJP)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin1), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin1)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin2), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin2)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin3), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin3)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin4), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin4)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin8), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin8)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin9), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin9)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeJPKatakana), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeJPKatakana)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeAR), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeAR)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeRU), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeRU)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeGR), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeGR)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeAPL), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeAPL)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeHB), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeHB)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeTH), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeTH)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeKR), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeKR)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeHY), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeHY)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeGE), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeGE)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeAZ), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeAZ)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeVN), keyCode))
            return (X11InputKeys.IKeyCodeLangLinux.IKeyCodeVN)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeTechnicalLinux), keyCode))
            return (X11InputKeys.IKeyCodeTechnicalLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeSpecialLinux), keyCode))
            return (X11InputKeys.IKeyCodeSpecialLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodePublishingLinux), keyCode))
            return (X11InputKeys.IKeyCodePublishingLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeCurrencyLinux), keyCode))
            return (X11InputKeys.IKeyCodeCurrencyLinux)keyCode;
        
        
        else if (Enum.IsDefined(typeof(WaylandInputKeys.DeviceProps), keyCode))
            return (uint)(WaylandInputKeys.DeviceProps)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.EventTypes), keyCode))
            return (uint)(WaylandInputKeys.EventTypes)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.SynEvents), keyCode))
            return (uint)(WaylandInputKeys.SynEvents)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.KeysAndButtons), keyCode))
            return (uint)(WaylandInputKeys.KeysAndButtons)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.RelativeAxes), keyCode))
            return (uint)(WaylandInputKeys.RelativeAxes)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.AbsoluteAxes), keyCode))
            return (uint)(WaylandInputKeys.AbsoluteAxes)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.SwitchEvents), keyCode))
            return (uint)(WaylandInputKeys.SwitchEvents)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.MiscEvents), keyCode))
            return (uint)(WaylandInputKeys.MiscEvents)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.LEDEvents), keyCode))
            return (uint)(WaylandInputKeys.LEDEvents)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.Autorepeat), keyCode))
            return (uint)(WaylandInputKeys.Autorepeat)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.Sounds), keyCode))
            return (uint)(WaylandInputKeys.Sounds)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.ABS_SND_PROFILE), keyCode))
            return (uint)(WaylandInputKeys.ABS_SND_PROFILE)keyCode;
        else
            return 0;
    }
    
    public static uint TryLinuxKeysym(nuint keyCodeRaw)
    {
        uint keyCode = (uint)keyCodeRaw;

        if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeExtraLinux), keyCode))
            return (uint)(X11InputKeys.IKeyCodeExtraLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeModLinux), keyCode))
            return (uint)(X11InputKeys.IKeyCodeModLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeMultiKeyLinux), keyCode))
            return (uint)(X11InputKeys.IKeyCodeMultiKeyLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeCursorControlLinux), keyCode))
            return (uint)(X11InputKeys.IKeyCodeCursorControlLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeMiscLinux), keyCode))
            return (uint)(X11InputKeys.IKeyCodeMiscLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeNumPadLinux), keyCode))
            return (uint)(X11InputKeys.IKeyCodeNumPadLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeFuncLinux), keyCode))
            return (uint)(X11InputKeys.IKeyCodeFuncLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeXKBExtensionLinux), keyCode))
            return (uint)(X11InputKeys.IKeyCodeXKBExtensionLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCode3270Linux), keyCode))
            return (uint)(X11InputKeys.IKeyCode3270Linux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeJP), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeJP)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin1), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin1)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin2), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin2)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin3), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin3)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin4), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin4)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin8), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin8)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin9), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin9)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeJPKatakana), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeJPKatakana)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeAR), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeAR)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeRU), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeRU)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeGR), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeGR)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeAPL), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeAPL)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeHB), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeHB)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeTH), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeTH)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeKR), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeKR)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeHY), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeHY)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeGE), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeGE)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeAZ), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeAZ)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeLangLinux.IKeyCodeVN), keyCode))
            return (uint)(X11InputKeys.IKeyCodeLangLinux.IKeyCodeVN)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeTechnicalLinux), keyCode))
            return (uint)(X11InputKeys.IKeyCodeTechnicalLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeSpecialLinux), keyCode))
            return (uint)(X11InputKeys.IKeyCodeSpecialLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodePublishingLinux), keyCode))
            return (uint)(X11InputKeys.IKeyCodePublishingLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeCurrencyLinux), keyCode))
            return (uint)(X11InputKeys.IKeyCodeCurrencyLinux)keyCode;
        else if (Enum.IsDefined(typeof(X11InputKeys.IKeyCodeMouseLinux), keyCode))
            return (uint)(X11InputKeys.IKeyCodeMouseLinux)keyCode;
        
        else if (Enum.IsDefined(typeof(WaylandInputKeys.DeviceProps), keyCode))
            return (uint)(WaylandInputKeys.DeviceProps)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.EventTypes), keyCode))
            return (uint)(WaylandInputKeys.EventTypes)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.SynEvents), keyCode))
            return (uint)(WaylandInputKeys.SynEvents)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.KeysAndButtons), keyCode))
            return (uint)(WaylandInputKeys.KeysAndButtons)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.RelativeAxes), keyCode))
            return (uint)(WaylandInputKeys.RelativeAxes)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.AbsoluteAxes), keyCode))
            return (uint)(WaylandInputKeys.AbsoluteAxes)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.SwitchEvents), keyCode))
            return (uint)(WaylandInputKeys.SwitchEvents)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.MiscEvents), keyCode))
            return (uint)(WaylandInputKeys.MiscEvents)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.LEDEvents), keyCode))
            return (uint)(WaylandInputKeys.LEDEvents)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.Autorepeat), keyCode))
            return (uint)(WaylandInputKeys.Autorepeat)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.Sounds), keyCode))
            return (uint)(WaylandInputKeys.Sounds)keyCode;
        else if (Enum.IsDefined(typeof(WaylandInputKeys.ABS_SND_PROFILE), keyCode))
            return (uint)(WaylandInputKeys.ABS_SND_PROFILE)keyCode;
        else
            return 0;
    }
}