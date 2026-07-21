using Angene.Windows.Slang;
using System.Runtime.InteropServices;
using System.Text;

namespace Angene.Windows.Slang
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

        private unsafe static sbyte* FromStringToSbyte(string input)
        {
            IntPtr Ptr0 = Marshal.StringToHGlobalAnsi(input);
            try
            {
                return (sbyte*)Ptr0.ToPointer();
            }
            finally
            {
                Marshal.FreeHGlobal(Ptr0);
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

        public unsafe static byte[] CompileShaderFromMemory(string sourceCode, string entryPoint, string stage)
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
                // Add a translation unit with the source code
                const int translationUnitIndex = 0;
                string virtualPath = "memory_shader.slang";

                // translation unit in this day and age??
                int addUnitResult = Methods.spAddTranslationUnit(request, SlangSourceLanguage.SLANG_SOURCE_LANGUAGE_SLANG, FromStringToSbyte("shader"));
                if (addUnitResult != 0)
                    throw new Exception($"Failed to add translation unit. Code = {addUnitResult}");

                // source to translation unit
                Methods.spAddTranslationUnitSourceString(request, translationUnitIndex, virtualPath, sourceCode);

                // String to SlangStage
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

                // entry point
                int addEntryResult = Methods.spAddEntryPoint(request, translationUnitIndex, FromStringToSbyte(entryPoint), slangStage);
                if (addEntryResult != 0)
                    throw new Exception($"Failed to add entry point '{entryPoint}'. Code = {addEntryResult}");

                // comp target
                Methods.spSetCodeGenTarget(request, SlangCompileTarget.SLANG_DXBC);

                // Profile
                const int targetIndex = 0;
                SlangProfileID profile = Methods.spFindProfile(_globalSession, FromStringToSbyte("sm_5_0"));

                if (profile == 0)
                {
                    profile = Methods.spFindProfile(_globalSession, FromStringToSbyte("ps_5_0"));
                    if (profile == 0)
                        profile = Methods.spFindProfile(_globalSession, FromStringToSbyte("vs_5_0"));

                    if (profile == 0)
                        profile = Methods.spFindProfile(_globalSession, FromStringToSbyte("5_0"));

                    if (profile == 0)
                        profile = Methods.spFindProfile(_globalSession, FromStringToSbyte("hlsl_5_0"));
                }

                if (profile != 0)
                {
                    Methods.spSetTargetProfile(request, targetIndex, profile);
                }

                // Compile
                int hr = Methods.spCompile(request);
                if (hr != 0)
                {
                    string diagnostics = GetSlangDiagnostics(request);
                    throw new Exception($"Slang memory compilation failed. HRESULT = 0x{hr:X8}\n\nDiagnostics:\n{diagnostics}");
                }

                // Get the compiled bytecode blob
                ISlangBlob* codeBlob = null;
                int getBlobResult = Methods.spGetEntryPointCodeBlob(request, 0, targetIndex, &codeBlob);
                if (getBlobResult != 0)
                {
                    // alternative
                    getBlobResult = Methods.spGetTargetCodeBlob(request, targetIndex, &codeBlob);
                    if (getBlobResult != 0)
                        throw new Exception($"Failed to get compiled code blob. Code = {getBlobResult}");
                }

                return ExtractBytecodeFromBlob(codeBlob);
            }
            finally
            {
                // request request go away come again another day
                Methods.spDestroyCompileRequest(request);
            }
        }
    }
}