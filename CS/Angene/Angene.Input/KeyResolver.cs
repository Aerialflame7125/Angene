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

        
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeExtraLinux), keyCode))
            return (Keys.IKeyCodeExtraLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeModLinux), keyCode))
            return (Keys.IKeyCodeModLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeMultiKeyLinux), keyCode))
            return (Keys.IKeyCodeMultiKeyLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeCursorControlLinux), keyCode))
            return (Keys.IKeyCodeCursorControlLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeMiscLinux), keyCode))
            return (Keys.IKeyCodeMiscLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeNumPadLinux), keyCode))
            return (Keys.IKeyCodeNumPadLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeFuncLinux), keyCode))
            return (Keys.IKeyCodeFuncLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeXKBExtensionLinux), keyCode))
            return (Keys.IKeyCodeXKBExtensionLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCode3270Linux), keyCode))
            return (Keys.IKeyCode3270Linux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeJP), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeJP)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeLatin1), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeLatin1)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeLatin2), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeLatin2)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeLatin3), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeLatin3)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeLatin4), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeLatin4)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeLatin8), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeLatin8)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeLatin9), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeLatin9)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeJPKatakana), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeJPKatakana)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeAR), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeAR)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeRU), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeRU)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeGR), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeGR)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeAPL), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeAPL)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeHB), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeHB)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeTH), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeTH)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeKR), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeKR)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeHY), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeHY)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeGE), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeGE)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeAZ), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeAZ)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeVN), keyCode))
            return (Keys.IKeyCodeLangLinux.IKeyCodeVN)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeTechnicalLinux), keyCode))
            return (Keys.IKeyCodeTechnicalLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeSpecialLinux), keyCode))
            return (Keys.IKeyCodeSpecialLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodePublishingLinux), keyCode))
            return (Keys.IKeyCodePublishingLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeCurrencyLinux), keyCode))
            return (Keys.IKeyCodeCurrencyLinux)keyCode;

        else
            return 0;
    }
    
    public static uint TryLinuxKeysym(nuint keyCodeRaw)
    {
        uint keyCode = (uint)keyCodeRaw;

        if (Enum.IsDefined(typeof(Keys.IKeyCodeExtraLinux), keyCode))
            return (uint)(Keys.IKeyCodeExtraLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeModLinux), keyCode))
            return (uint)(Keys.IKeyCodeModLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeMultiKeyLinux), keyCode))
            return (uint)(Keys.IKeyCodeMultiKeyLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeCursorControlLinux), keyCode))
            return (uint)(Keys.IKeyCodeCursorControlLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeMiscLinux), keyCode))
            return (uint)(Keys.IKeyCodeMiscLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeNumPadLinux), keyCode))
            return (uint)(Keys.IKeyCodeNumPadLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeFuncLinux), keyCode))
            return (uint)(Keys.IKeyCodeFuncLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeXKBExtensionLinux), keyCode))
            return (uint)(Keys.IKeyCodeXKBExtensionLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCode3270Linux), keyCode))
            return (uint)(Keys.IKeyCode3270Linux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeJP), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeJP)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeLatin1), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeLatin1)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeLatin2), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeLatin2)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeLatin3), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeLatin3)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeLatin4), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeLatin4)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeLatin8), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeLatin8)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeLatin9), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeLatin9)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeJPKatakana), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeJPKatakana)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeAR), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeAR)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeRU), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeRU)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeGR), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeGR)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeAPL), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeAPL)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeHB), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeHB)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeTH), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeTH)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeKR), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeKR)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeHY), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeHY)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeGE), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeGE)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeAZ), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeAZ)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeLangLinux.IKeyCodeVN), keyCode))
            return (uint)(Keys.IKeyCodeLangLinux.IKeyCodeVN)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeTechnicalLinux), keyCode))
            return (uint)(Keys.IKeyCodeTechnicalLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeSpecialLinux), keyCode))
            return (uint)(Keys.IKeyCodeSpecialLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodePublishingLinux), keyCode))
            return (uint)(Keys.IKeyCodePublishingLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeCurrencyLinux), keyCode))
            return (uint)(Keys.IKeyCodeCurrencyLinux)keyCode;
        else if (Enum.IsDefined(typeof(Keys.IKeyCodeMouseLinux), keyCode))
            return (uint)(Keys.IKeyCodeMouseLinux)keyCode;
        else
            return 0;
    }
}