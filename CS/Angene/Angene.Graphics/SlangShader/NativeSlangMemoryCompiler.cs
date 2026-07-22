using Angene.Common.Settings;
using Angene.Windows.Slang;
using Org.BouncyCastle.Asn1.X509;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;

namespace Angene.Graphics.SlangShader
{
    public class NativeSlangMemoryCompiler
    {
        private unsafe static IGlobalSession* _globalSession = default;
        private static bool _libraryLoaded = false;

        // COM Interface VTable delegates for ISlangUnknown -> IBlob
        // 0-2: IUnknown (QueryInterface, AddRef, Release)
        // 3: getBufferPointer
        // 4: getBufferSize
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate IntPtr GetBufferPointerDelegate(IntPtr thisPtr);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate UIntPtr GetBufferSizeDelegate(IntPtr thisPtr);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate uint ReleaseDelegate(IntPtr thisPtr);

        /// <summary>
        /// Gets diagnostic output from a Slang compilation request as a string.
        /// </summary>
        private unsafe static string GetSlangDiagnostics(ICompileRequest* request)
        {
            try
            {
                // First try getting diagnostic blob
                ISlangBlob* diagBlob = null;
                int hr = Methods.spGetDiagnosticOutputBlob(request, &diagBlob);

                if (hr == 0 && (IntPtr)diagBlob != IntPtr.Zero)
                {
                    IntPtr vtable = Marshal.ReadIntPtr((IntPtr)diagBlob);

                    IntPtr pGetBufferPointer = Marshal.ReadIntPtr(vtable, 3 * IntPtr.Size);
                    IntPtr pGetBufferSize = Marshal.ReadIntPtr(vtable, 4 * IntPtr.Size);
                    IntPtr pRelease = Marshal.ReadIntPtr(vtable, 2 * IntPtr.Size);

                    var getBufferPointer = Marshal.GetDelegateForFunctionPointer<GetBufferPointerDelegate>(pGetBufferPointer);
                    var getBufferSize = Marshal.GetDelegateForFunctionPointer<GetBufferSizeDelegate>(pGetBufferSize);
                    var releaseBlob = Marshal.GetDelegateForFunctionPointer<ReleaseDelegate>(pRelease);

                    IntPtr dataPtr = getBufferPointer((IntPtr)diagBlob);
                    int size = (int)getBufferSize((IntPtr)diagBlob).ToUInt32();

                    if (size > 0 && dataPtr != IntPtr.Zero)
                    {
                        byte[] diagBytes = new byte[size];
                        Marshal.Copy(dataPtr, diagBytes, 0, size);
                        releaseBlob((IntPtr)diagBlob);
                        return Encoding.UTF8.GetString(diagBytes).TrimEnd('\0');
                    }

                    releaseBlob((IntPtr)diagBlob);
                }

                // Fallback to old method
                sbyte* diagStr = Methods.spGetDiagnosticOutput(request);
                if (diagStr != null)
                {
                    return Marshal.PtrToStringAnsi((IntPtr)diagStr) ?? "Unknown diagnostic error";
                }

                return "No diagnostic information available";
            }
            catch (Exception ex)
            {
                return $"Error retrieving diagnostics: {ex.Message}";
            }
        }

        // Helper to convert string to null-terminated UTF-8 byte array
        public static byte[] ToNullTerminatedUtf8(string str)
        {
            if (str == null) return new byte[] { 0 };
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            Array.Resize(ref bytes, bytes.Length + 1);
            bytes[bytes.Length - 1] = 0;
            return bytes;
        }

        // accepts sbyte and converts to t or smth
        private unsafe delegate T NativeStringFunc<T>(sbyte* ptr);

        private unsafe static T WithNativeString<T>(string input, NativeStringFunc<T> action)
        {
            byte[] bytes = ToNullTerminatedUtf8(input);
            fixed (byte* pBytes = bytes)
            {
                return action((sbyte*)pBytes);
            }
        }

        /// <summary>
        /// Extracts bytecode from an ISlangBlob COM object.
        /// </summary>
        private unsafe static byte[] ExtractBytecodeFromBlob(ISlangBlob* blob)
        {
            if ((IntPtr)blob == IntPtr.Zero)
                throw new Exception("Blob is null");

            IntPtr vtable = Marshal.ReadIntPtr((IntPtr)blob);

            IntPtr pGetBufferPointer = Marshal.ReadIntPtr(vtable, 3 * IntPtr.Size);
            IntPtr pGetBufferSize = Marshal.ReadIntPtr(vtable, 4 * IntPtr.Size);
            IntPtr pRelease = Marshal.ReadIntPtr(vtable, 2 * IntPtr.Size);

            var getBufferPointer = Marshal.GetDelegateForFunctionPointer<GetBufferPointerDelegate>(pGetBufferPointer);
            var getBufferSize = Marshal.GetDelegateForFunctionPointer<GetBufferSizeDelegate>(pGetBufferSize);
            var releaseBlob = Marshal.GetDelegateForFunctionPointer<ReleaseDelegate>(pRelease);

            IntPtr dataPtr = getBufferPointer((IntPtr)blob);
            int size = (int)getBufferSize((IntPtr)blob).ToUInt32();

            byte[] bytecode = new byte[size];
            if (size > 0 && dataPtr != IntPtr.Zero)
            {
                Marshal.Copy(dataPtr, bytecode, 0, size);
            }

            releaseBlob((IntPtr)blob);
            return bytecode;
        }

        public static byte[] CompileShaderFromMemoryToFile(string sourceCode, string entryPoint, string stage, string outputPath)
        {
            // Initialize
            byte[] code = CompileShaderFromMemory(sourceCode, entryPoint, stage);
            byte[] intBytes = BitConverter.GetBytes(code.Length);
            byte[] fileData = new byte[intBytes.Length + 1 + code.Length + 1];

            // copy data
            Buffer.BlockCopy(intBytes, 0, fileData, 0, intBytes.Length);
            fileData[intBytes.Length] = (byte)0xAF;
            Buffer.BlockCopy(code, 0, fileData, intBytes.Length + 1, code.Length);
            fileData[intBytes.Length + 1 + code.Length] = (byte)0xAA;

            // write and return
            File.WriteAllBytes(outputPath, fileData);
            return code;
        }

        public unsafe static byte[] CompileShaderFromMemory(string sourceCode, string entryPoint, string stage, int trynum = 0)
        {
            sourceCode = sourceCode.Trim();
            entryPoint = entryPoint.Trim();
            stage = stage.Trim();

            if ((IntPtr)_globalSession == IntPtr.Zero)
                _globalSession = Methods.spCreateSession();

            ICompileRequest* request = Methods.spCreateCompileRequest(_globalSession);
            if ((IntPtr)request == IntPtr.Zero)
                throw new Exception("Failed to create Slang compilation request context.");

            try
            {
                const int translationUnitIndex = 0;
                string virtualPath = "memory_shader.slang";

                // 1. Add translation unit safely
                int addUnitResult = WithNativeString("shader", pName =>
                    Methods.spAddTranslationUnit(request, SlangSourceLanguage.SLANG_SOURCE_LANGUAGE_SLANG, pName));

                if (addUnitResult != 0)
                    throw new Exception($"Failed to add translation unit. Code = {addUnitResult}");

                Methods.spAddTranslationUnitSourceString(request, translationUnitIndex, virtualPath, sourceCode);

                SlangStage slangStage = stage.ToLower() switch
                {
                    "vertex" => SlangStage.SLANG_STAGE_VERTEX,
                    "pixel" or "fragment" => SlangStage.SLANG_STAGE_FRAGMENT,
                    "compute" => SlangStage.SLANG_STAGE_COMPUTE,
                    "geometry" => SlangStage.SLANG_STAGE_GEOMETRY,
                    "hull" or "tessellation control" => SlangStage.SLANG_STAGE_HULL,
                    "domain" or "tessellation evaluation" => SlangStage.SLANG_STAGE_DOMAIN,
                    _ => throw new ArgumentException($"Unknown shader stage: {stage}")
                };

                // 2. Add entry point safely
                int addEntryResult = WithNativeString(entryPoint, pEntryPoint =>
                    Methods.spAddEntryPoint(request, translationUnitIndex, pEntryPoint, slangStage));

                if (addEntryResult != 0)
                    throw new Exception($"Failed to add entry point '{entryPoint}'. Code = {addEntryResult}");

                Methods.spSetCodeGenTarget(request, SlangCompileTarget.SLANG_DXBC);

                // 3. Find profile safely
                const int targetIndex = 0;

                // Select specific profile based on stage for DirectX 11
                string profileTarget = stage.ToLower() switch
                {
                    "vertex" => "vs_5_0",
                    "pixel" or "fragment" => "ps_5_0",
                    "compute" => "cs_5_0",
                    "geometry" => "gs_5_0",
                    "hull" or "tessellation control" => "hs_5_0",
                    "domain" or "tessellation evaluation" => "ds_5_0",
                    _ => "sm_5_0"
                };

                SlangProfileID profile = WithNativeString(profileTarget, pProfile => Methods.spFindProfile(_globalSession, pProfile));

                if (profile == 0)
                {
                    profile = WithNativeString("sm_5_0", pProfile => Methods.spFindProfile(_globalSession, pProfile));
                }

                if (profile != 0)
                {
                    Methods.spSetTargetProfile(request, targetIndex, profile);
                }

                int hr = Methods.spCompile(request);
                if (hr != 0)
                {
                    if (hr == unchecked((int)0x80004005) && trynum < 3)
                    {
                        return CompileShaderFromMemory(sourceCode, entryPoint, stage, trynum + 1);
                    }
                    else
                    {
                        string diagnostics = GetSlangDiagnostics(request);
                        throw new Exception($"Slang memory compilation failed. HRESULT = 0x{hr:X8}\n\nDiagnostics:\n{diagnostics}");
                    }
                }

                ISlangBlob* codeBlob = null;
                int getBlobResult = Methods.spGetEntryPointCodeBlob(request, 0, targetIndex, &codeBlob);
                if (getBlobResult != 0)
                {
                    getBlobResult = Methods.spGetTargetCodeBlob(request, targetIndex, &codeBlob);
                    if (getBlobResult != 0)
                        throw new Exception($"Failed to get compiled code blob. Code = {getBlobResult}");
                }

                return ExtractBytecodeFromBlob(codeBlob);
            }
            finally
            {
                Methods.spDestroyCompileRequest(request);
            }
        }
    }
}