// AngeneHostLinCore.cpp
// Linux native host that loads and runs a managed .NET assembly via CoreCLR/hostfxr.
// Mirrors the Windows WinMain hostfxr-based host so both platforms use the same
// [UnmanagedCallersOnly] managed entry point.

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdarg.h>
#include <unistd.h>
#include <limits.h>
#include <libgen.h>
#include <dlfcn.h>
#include <dirent.h>
#include <sys/stat.h>

#include <string>
#include <vector>
#include <algorithm>

#include "hostfxr.h"
#include "coreclr_delegates.h"

// -----------------------------------------------------------------------
// Logging
// -----------------------------------------------------------------------
bool g_consoleAvailable = true;

void LogMessage(const char* format, ...)
{
    char buffer[1024];
    va_list args;
    va_start(args, format);
    vsnprintf(buffer, sizeof(buffer), format, args);
    va_end(args);

    if (g_consoleAvailable) printf("%s", buffer);
}

void LogError(const char* format, ...)
{
    char buffer[1024];
    va_list args;
    va_start(args, format);
    vsnprintf(buffer, sizeof(buffer), format, args);
    va_end(args);

    if (g_consoleAvailable) fprintf(stderr, "ERROR: %s", buffer);
}

std::string GetExecutableDirectory()
{
    char path[PATH_MAX];
    ssize_t len = readlink("/proc/self/exe", path, sizeof(path) - 1);
    if (len != -1)
    {
        path[len] = '\0';
        char temp[PATH_MAX];
        strncpy(temp, path, PATH_MAX - 1);
        temp[PATH_MAX - 1] = '\0';
        char* dir = dirname(temp);
        std::string resolved = std::string(dir) + "/";
        return resolved;
    }
    return "./";
}

bool FileExists(const std::string& path)
{
    return (access(path.c_str(), F_OK) == 0);
}

// -----------------------------------------------------------------------
// hostfxr discovery (manual, no libnethost dependency)
// -----------------------------------------------------------------------

// Compare two version strings like "8.0.11" numerically, component by component.
static bool VersionLess(const std::string& a, const std::string& b)
{
    auto split = [](const std::string& v) {
        std::vector<int> parts;
        size_t start = 0;
        while (start <= v.size())
        {
            size_t dot = v.find('.', start);
            std::string token = (dot == std::string::npos) ? v.substr(start) : v.substr(start, dot - start);
            // Strip any non-numeric suffix (e.g. "8.0.0-preview")
            int value = 0;
            sscanf(token.c_str(), "%d", &value);
            parts.push_back(value);
            if (dot == std::string::npos) break;
            start = dot + 1;
        }
        return parts;
    };

    std::vector<int> va = split(a), vb = split(b);
    size_t n = std::max(va.size(), vb.size());
    for (size_t i = 0; i < n; ++i)
    {
        int x = (i < va.size()) ? va[i] : 0;
        int y = (i < vb.size()) ? vb[i] : 0;
        if (x != y) return x < y;
    }
    return false;
}

// Find the highest-versioned subdirectory of fxrRoot (e.g. host/fxr/) and
// return the full path to libhostfxr.so inside it.
static bool FindHighestFxrVersion(const std::string& fxrRoot, std::string& outLibPath, std::string& outVersion)
{
    DIR* dir = opendir(fxrRoot.c_str());
    if (!dir) return false;

    std::string best;
    struct dirent* entry;
    while ((entry = readdir(dir)) != nullptr)
    {
        std::string name = entry->d_name;
        if (name == "." || name == "..") continue;

        struct stat st;
        std::string fullPath = fxrRoot + "/" + name;
        if (stat(fullPath.c_str(), &st) != 0 || !S_ISDIR(st.st_mode)) continue;

        std::string candidateLib = fullPath + "/libhostfxr.so";
        if (!FileExists(candidateLib)) continue;

        if (best.empty() || VersionLess(best, name)) best = name;
    }
    closedir(dir);

    if (best.empty()) return false;

    outVersion = best;
    outLibPath = fxrRoot + "/" + best + "/libhostfxr.so";
    return true;
}

// Search common dotnet install locations (DOTNET_ROOT env var first, then
// well-known Linux paths) for host/fxr/<version>/libhostfxr.so.
static bool LocateHostfxr(std::string& outLibPath, std::string& outVersion, std::string& outDotnetRoot)
{
    std::vector<std::string> candidateRoots;

    const char* envRoot = getenv("DOTNET_ROOT");
    if (envRoot && *envRoot) candidateRoots.push_back(envRoot);

    candidateRoots.push_back("/usr/lib/dotnet");
    candidateRoots.push_back("/usr/share/dotnet");
    candidateRoots.push_back("/usr/lib64/dotnet");
    candidateRoots.push_back("/opt/dotnet");

    const char* home = getenv("HOME");
    if (home && *home) candidateRoots.push_back(std::string(home) + "/.dotnet");

    for (const auto& root : candidateRoots)
    {
        std::string fxrRoot = root + "/host/fxr";
        std::string libPath, version;
        if (FindHighestFxrVersion(fxrRoot, libPath, version))
        {
            outLibPath = libPath;
            outVersion = version;
            outDotnetRoot = root;
            return true;
        }
    }
    return false;
}

// -----------------------------------------------------------------------
// hostfxr function pointers
// -----------------------------------------------------------------------

hostfxr_initialize_for_runtime_config_fn init_for_config_fptr = nullptr;
hostfxr_get_runtime_delegate_fn get_delegate_fptr = nullptr;
hostfxr_close_fn close_fptr = nullptr;

static void* g_hostfxrHandle = nullptr;

bool LoadHostfxr(const std::string& libPath)
{
    g_hostfxrHandle = dlopen(libPath.c_str(), RTLD_NOW | RTLD_GLOBAL);
    if (!g_hostfxrHandle)
    {
        LogError("dlopen failed for %s: %s\n", libPath.c_str(), dlerror());
        return false;
    }

    init_for_config_fptr = (hostfxr_initialize_for_runtime_config_fn)dlsym(g_hostfxrHandle, "hostfxr_initialize_for_runtime_config");
    get_delegate_fptr = (hostfxr_get_runtime_delegate_fn)dlsym(g_hostfxrHandle, "hostfxr_get_runtime_delegate");
    close_fptr = (hostfxr_close_fn)dlsym(g_hostfxrHandle, "hostfxr_close");

    return init_for_config_fptr && get_delegate_fptr && close_fptr;
}

// -----------------------------------------------------------------------
// Assembly discovery
// -----------------------------------------------------------------------

struct AssemblyInfo
{
    std::string dllPath;
    std::string typeName;   // "Namespace.Class, AssemblyName"
    bool exists;
};

std::vector<AssemblyInfo> FindPossibleAssemblies(const std::string& dirPath)
{
    std::vector<AssemblyInfo> assemblies;
    std::vector<std::string> names = { "Game.dll" };

    for (const auto& name : names)
    {
        AssemblyInfo info;
        info.dllPath = dirPath + name;
        info.exists = FileExists(info.dllPath);

        std::string baseName = name.substr(0, name.find_last_of('.'));
        info.typeName = baseName + ".Program, " + baseName;

        assemblies.push_back(info);
    }
    return assemblies;
}

// -----------------------------------------------------------------------
// Load and run managed code via an embedded runtimeconfig.json
// -----------------------------------------------------------------------

int LoadAndRunManagedCode(const std::string& assemblyPath, const std::string& typeName,
                           int argc, char* argv[], const std::string& dotnetVersion)
{
    std::string dirPath = assemblyPath.substr(0, assemblyPath.find_last_of("/") + 1);
    std::string tempConfigPath = dirPath + "_angene_temp.config.json";

    std::string majorVer = dotnetVersion.substr(0, dotnetVersion.find('.'));

    std::string configJson = "{\n";
    configJson += "  \"runtimeOptions\": {\n";
    configJson += "    \"tfm\": \"net" + majorVer + ".0\",\n";
    configJson += "    \"rollForward\": \"Major\",\n";
    configJson += "    \"framework\": {\n";
    configJson += "      \"name\": \"Microsoft.NETCore.App\",\n";
    configJson += "      \"version\": \"" + dotnetVersion + "\"\n";
    configJson += "    }\n";
    configJson += "  }\n";
    configJson += "}";

    FILE* tempFile = fopen(tempConfigPath.c_str(), "w");
    if (!tempFile)
    {
        LogError("Failed to write temporary runtime config: %s\n", tempConfigPath.c_str());
        return -1;
    }
    fputs(configJson.c_str(), tempFile);
    fclose(tempFile);

    hostfxr_initialize_parameters params{};
    params.size = sizeof(hostfxr_initialize_parameters);
    params.host_path = assemblyPath.c_str();
    params.dotnet_root = nullptr;

    hostfxr_handle cxt = nullptr;
    int rc = init_for_config_fptr(tempConfigPath.c_str(), &params, &cxt);

    remove(tempConfigPath.c_str());

    if (rc != 0 || cxt == nullptr)
    {
        LogError("hostfxr_initialize_for_runtime_config failed, rc=0x%x\n", rc);
        if (cxt) close_fptr(cxt);
        return -1;
    }

    load_assembly_and_get_function_pointer_fn load_assembly_and_get_function_pointer = nullptr;
    rc = get_delegate_fptr(cxt, hdt_load_assembly_and_get_function_pointer,
                            (void**)&load_assembly_and_get_function_pointer);

    if (rc != 0 || load_assembly_and_get_function_pointer == nullptr)
    {
        LogError("Failed to get load_assembly_and_get_function_pointer delegate, rc=0x%x\n", rc);
        close_fptr(cxt);
        return -1;
    }

    typedef int (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(const char** argv, int argc);
    custom_entry_point_fn mainFunc = nullptr;

    rc = load_assembly_and_get_function_pointer(
        assemblyPath.c_str(),
        typeName.c_str(),
        "Main",
        UNMANAGEDCALLERSONLY_METHOD,
        nullptr,
        (void**)&mainFunc);

    if (rc != 0 || mainFunc == nullptr)
    {
        LogError("Failed to load assembly / get function pointer for %s, rc=0x%x\n", typeName.c_str(), rc);
        close_fptr(cxt);
        return -1;
    }

    // Mirror the Windows layout: pass remaining argv (skip argv[0]).
    const char** argvPtr = const_cast<const char**>(argv + (argc > 0 ? 1 : 0));
    int argCount = (argc > 0) ? (argc - 1) : 0;

    int result = mainFunc(argvPtr, argCount);

    close_fptr(cxt);
    return result;
}

// -----------------------------------------------------------------------
// main
// -----------------------------------------------------------------------

int main(int argc, char* argv[])
{
    std::string exeDir = GetExecutableDirectory();
    LogMessage("Runtime: CoreCLR / hostfxr\n\n");

    if (argc > 1)
    {
        LogMessage("Command-line arguments received:\n");
        for (int i = 1; i < argc; i++) LogMessage("  [%d] %s\n", i, argv[i]);
        LogMessage("\n");
    }

    std::string hostfxrPath, hostfxrVersion, dotnetRoot;
    if (!LocateHostfxr(hostfxrPath, hostfxrVersion, dotnetRoot))
    {
        LogError("Could not locate libhostfxr.so.\n");
        return 1;
    }
    LogMessage("[OK] Found hostfxr %s at %s\n\n", hostfxrVersion.c_str(), hostfxrPath.c_str());

    if (!LoadHostfxr(hostfxrPath))
    {
        LogError("Failed to load hostfxr exports\n");
        return 1;
    }

    auto assemblies = FindPossibleAssemblies(exeDir);
    AssemblyInfo* targetAssembly = nullptr;
    for (auto& assembly : assemblies)
    {
        if (assembly.exists)
        {
            if (!targetAssembly) targetAssembly = &assembly;
        }
    }

    if (!targetAssembly)
    {
        LogError("No game assembly found!\n");
        return 1;
    }
    int returnCode = LoadAndRunManagedCode(targetAssembly->dllPath, targetAssembly->typeName,
                                            argc, argv, hostfxrVersion);

    LogMessage("Exit Code: %d\n", returnCode);
    return returnCode;
}
