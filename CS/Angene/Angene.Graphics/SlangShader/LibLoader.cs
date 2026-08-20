using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Angene.Graphics.SlangShader;
internal static class LibLoader
{
    [ModuleInitializer]
    internal static void Init() => EnsureRegistered();

    private static int _registered;
    private static readonly object _lock = new();

    internal static void EnsureRegistered()
    {
        if (Interlocked.CompareExchange(ref _registered, 1, 0) != 0)
            return; // someone else already registered (or is mid-registration)

        NativeLibrary.SetDllImportResolver(typeof(LibLoader).Assembly, Resolve);
    }

    private static IntPtr Resolve(string name, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (name == "slang")
        {
            var (rid, fileName) = OperatingSystem.IsWindows()
                ? ("win-x64", "slang.dll")
                : ("linux-x64", "libslang.so");

            string resourceName = $"Angene.Graphics.Native.{rid}.{fileName}";
            string extractPath = ExtractToCache(assembly, resourceName, fileName);
            if (OperatingSystem.IsWindows())
                ExtractToCache(assembly, "Angene.Graphics.Native.win-x64.slang-compiler.dll", "slang-compiler.dll");
            return NativeLibrary.Load(extractPath);
        }

        return IntPtr.Zero;
    }

    private static string ExtractToCache(Assembly assembly, string resourceName, string fileName)
    {
        string version = assembly.GetName().Version?.ToString() ?? "0.0.0";
        string dir = Path.Combine(Path.GetTempPath(), "Angene", "slang");
        Directory.CreateDirectory(dir);
        string path = Path.Combine(dir, fileName);

        if (!File.Exists(path))
        {
            using Stream? resStream = assembly.GetManifestResourceStream(resourceName)
                ?? throw new InvalidOperationException($"Missing embedded native resource '{resourceName}'.");

            string tmp = path + ".tmp-" + Guid.NewGuid().ToString("N");
            using (FileStream fs = File.Create(tmp))
                resStream.CopyTo(fs);

            try { File.Move(tmp, path); }
            catch (IOException) { File.Delete(tmp); }
        }

        if (!OperatingSystem.IsWindows())
            MakeExecutable(path);

        return path;
    }

    [DllImport("libc", SetLastError = true)]
    private static extern int chmod(string pathname, int mode);

    private static void MakeExecutable(string path)
    {
        const int rwxrxrx = 0x1ED; // 0755
        chmod(path, rwxrxrx);
    }
}