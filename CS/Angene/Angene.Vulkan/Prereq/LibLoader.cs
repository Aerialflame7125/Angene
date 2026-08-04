using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal static class LibLoader
{
    [ModuleInitializer]
    internal static void Init() => EnsureRegistered();

    public const string VulkanLibName = "vulkan";
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
        if (name == "vma")
        {
            var (rid, fileName) = OperatingSystem.IsWindows()
                ? ("win-x64", "vma.dll")
                : ("linux-x64", "libvma.so");

            string resourceName = $"Angene.Vulkan.Native.{rid}.{fileName}";
            string extractPath = ExtractToCache(assembly, resourceName, fileName);
            return NativeLibrary.Load(extractPath);
        }

        // Not ours — hand off to the Vulkan resolver, then default probing
        return ResolveVulkanLib(name, assembly, searchPath);
    }

    private static IntPtr ResolveVulkanLib(string libraryName, System.Reflection.Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (libraryName == VulkanLibName)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Windows requires the -1 suffix
                return NativeLibrary.Load("vulkan-1.dll", assembly, searchPath);
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // Linux standard system library name
                return NativeLibrary.Load("libvulkan.so.1", assembly, searchPath);
            }
        }
        // Fallback to default loading behavior for other libraries
        return IntPtr.Zero; 
    }

    private static string ExtractToCache(Assembly assembly, string resourceName, string fileName)
    {
        string version = assembly.GetName().Version?.ToString() ?? "0.0.0";
        string dir = Path.Combine(Path.GetTempPath(), "Angene", "vma");
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