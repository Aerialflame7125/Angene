using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Angene.Windows.Slang
{
    public class NativeSlangMemoryCompiler
    {
        private static IntPtr _globalSession = IntPtr.Zero;
        private static bool _libraryLoaded = false;

        public static void Initialize()
        {
            if (_libraryLoaded) return;

            string arch = RuntimeInformation.ProcessArchitecture.ToString().ToLowerInvariant();
            string path = Path.Combine(AppContext.BaseDirectory, "runtimes", $"win-{arch}", "native");

            // Explicitly load the core slang library first so the runtime resolves dependencies
            NativeLibrary.Load("slang.dll");
            NativeLibrary.Load(Path.Combine(path, "slang-compiler.dll"));
            _libraryLoaded = true;
        }

        // Flat C Exports from slang.dll
        [DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr slang_createSession();

        [DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr spCreateCompileRequest(IntPtr session);

        [DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
        private static extern int spProcessCommandLineArguments(IntPtr request, string[] args, int argCount);

        [DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
        private static extern void spAddTranslationUnitSourceString(IntPtr request, int translationUnitIndex, string path, string source);

        [DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
        private static extern int spCompile(IntPtr request);

        [DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr spGetQueryResultBlob(IntPtr request);

        [DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
        private static extern void spDestroyCompileRequest(IntPtr request);

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

        public static byte[] CompileShaderFromMemory(string sourceCode, string entryPoint, string stage)
        {
            // Ensure native DLL binaries are present in process memory space
            Initialize();

            if (_globalSession == IntPtr.Zero)
                _globalSession = slang_createSession();

            IntPtr request = spCreateCompileRequest(_globalSession);
            if (request == IntPtr.Zero)
                throw new Exception("Failed to create Slang compilation request context.");

            try
            {
                string virtualPath = "memory_shader.slang";
                spAddTranslationUnitSourceString(request, 0, virtualPath, sourceCode);

                string[] args = new[]
                {
                    "-target", "dxbc",
                    "-profile", "sm_5_0",
                    "-entry", entryPoint,
                    "-stage", stage,
                    virtualPath
                };

                if (spProcessCommandLineArguments(request, args, args.Length) != 0)
                    throw new Exception("Slang failed parsing memory runtime arguments.");

                if (spCompile(request) != 0)
                    throw new Exception("Slang memory compilation failed.");

                IntPtr blob = spGetQueryResultBlob(request);
                if (blob == IntPtr.Zero)
                    throw new Exception("Slang compiler returned a null data blob.");

                // Read the VTable out of the COM interface instance pointer
                IntPtr vtable = Marshal.ReadIntPtr(blob);

                // Fetch our functional pointers from the VTable layout
                IntPtr pGetBufferPointer = Marshal.ReadIntPtr(vtable, 3 * IntPtr.Size);
                IntPtr pGetBufferSize = Marshal.ReadIntPtr(vtable, 4 * IntPtr.Size);
                IntPtr pRelease = Marshal.ReadIntPtr(vtable, 2 * IntPtr.Size);

                var getBufferPointer = Marshal.GetDelegateForFunctionPointer<GetBufferPointerDelegate>(pGetBufferPointer);
                var getBufferSize = Marshal.GetDelegateForFunctionPointer<GetBufferSizeDelegate>(pGetBufferSize);
                var releaseBlob = Marshal.GetDelegateForFunctionPointer<ReleaseDelegate>(pRelease);

                // Call the virtual interface functions securely
                IntPtr dataPtr = getBufferPointer(blob);
                int size = (int)getBufferSize(blob).ToUInt32();

                byte[] bytecode = new byte[size];
                if (size > 0 && dataPtr != IntPtr.Zero)
                {
                    Marshal.Copy(dataPtr, bytecode, 0, size);
                }

                // Crucial: Release the COM blob reference count so it doesn't stay locked in RAM permanently
                releaseBlob(blob);

                return bytecode;
            }
            finally
            {
                // Always scrub the active session request parameters from execution tracks
                spDestroyCompileRequest(request);
            }
        }
    }
}