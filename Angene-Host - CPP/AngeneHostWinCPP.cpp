#include <windows.h>
#include <stdio.h>
#include <stdarg.h>
#include <iostream>
#include <string>
#include <vector>
#include "nethost.h"
#include "coreclr_delegates.h"
#include "hostfxr.h"

#pragma comment(lib, "shell32.lib")  // For CommandLineToArgvW

bool g_consoleAvailable = false;

// A WinMain-subsystem app has no console of its own, even when launched from
// cmd/PowerShell. AttachConsole(ATTACH_PARENT_PROCESS) hooks us into the
// console of whatever process started us (if any), and we then have to
// re-point the CRT's stdout/stderr/stdin at that console explicitly.
// If there's no parent console (e.g. launched by double-clicking the exe),
// this fails and we just stay silent rather than popping up a new window.
bool AttachToConsole()
{
    if (!AttachConsole(ATTACH_PARENT_PROCESS))
        return false;

    FILE* fp = nullptr;
    freopen_s(&fp, "CONOUT$", "w", stdout);
    freopen_s(&fp, "CONOUT$", "w", stderr);
    freopen_s(&fp, "CONIN$", "r", stdin);

    // freopen only rebinds the CRT's FILE* streams. Managed code (the .NET
    // Console class) reads the process's Win32-level standard handles via
    // GetStdHandle instead, so without this, System.Console.WriteLine calls
    // in the hosted assembly are silently swallowed even though our own
    // printf-based logging works fine.
    HANDLE hConOut = CreateFileW(L"CONOUT$", GENERIC_READ | GENERIC_WRITE,
                                  FILE_SHARE_READ | FILE_SHARE_WRITE, nullptr,
                                  OPEN_EXISTING, 0, nullptr);
    HANDLE hConIn = CreateFileW(L"CONIN$", GENERIC_READ | GENERIC_WRITE,
                                 FILE_SHARE_READ | FILE_SHARE_WRITE, nullptr,
                                 OPEN_EXISTING, 0, nullptr);

    if (hConOut != INVALID_HANDLE_VALUE)
    {
        SetStdHandle(STD_OUTPUT_HANDLE, hConOut);
        SetStdHandle(STD_ERROR_HANDLE, hConOut);
    }
    if (hConIn != INVALID_HANDLE_VALUE)
    {
        SetStdHandle(STD_INPUT_HANDLE, hConIn);
    }

    // Re-sync C++ iostreams with the new C stdio handles, in case any code
    // elsewhere uses std::cout/std::cerr.
    std::ios::sync_with_stdio(true);

    return true;
}

// -----------------------------------------------------------------------
// Logging (mirrors the Linux host so behavior/output is consistent)
// -----------------------------------------------------------------------

void LogMessage(const char* format, ...)
{
    if (!g_consoleAvailable) return;

    char buffer[1024];
    va_list args;
    va_start(args, format);
    vsnprintf(buffer, sizeof(buffer), format, args);
    va_end(args);

    printf("%s", buffer);
    fflush(stdout);
}

void LogError(const char* format, ...)
{
    if (!g_consoleAvailable) return;

    char buffer[1024];
    va_list args;
    va_start(args, format);
    vsnprintf(buffer, sizeof(buffer), format, args);
    va_end(args);

    fprintf(stderr, "ERROR: %s", buffer);
    fflush(stderr);
}

// hostfxr function pointers
hostfxr_initialize_for_dotnet_command_line_fn init_for_cmd_line_fptr = nullptr;
hostfxr_initialize_for_runtime_config_fn init_for_config_fptr = nullptr;
hostfxr_get_runtime_delegate_fn get_delegate_fptr = nullptr;
hostfxr_run_app_fn run_app_fptr = nullptr;
hostfxr_close_fn close_fptr = nullptr;
hostfxr_set_runtime_property_value_fn set_property_fptr = nullptr;
hostfxr_get_runtime_properties_fn get_properties_fptr = nullptr;

// Load hostfxr and get exports
bool LoadHostfxr()
{
    // Get the path to hostfxr
    char_t buffer[MAX_PATH];
    size_t buffer_size = sizeof(buffer) / sizeof(char_t);
    int rc = get_hostfxr_path(buffer, &buffer_size, nullptr);

    if (rc != 0)
    {
        LogError("get_hostfxr_path failed, rc=0x%x\n", rc);
        return false;
    }

    LogMessage("[OK] Found hostfxr at %ls\n\n", buffer);

    HMODULE lib = LoadLibraryW(buffer);
    if (!lib)
    {
        LogError("LoadLibraryW failed for %ls (GetLastError=%lu)\n", buffer, GetLastError());
        return false;
    }

    // Get function pointers
    init_for_cmd_line_fptr = (hostfxr_initialize_for_dotnet_command_line_fn)GetProcAddress(lib, "hostfxr_initialize_for_dotnet_command_line");
    init_for_config_fptr = (hostfxr_initialize_for_runtime_config_fn)GetProcAddress(lib, "hostfxr_initialize_for_runtime_config");
    get_delegate_fptr = (hostfxr_get_runtime_delegate_fn)GetProcAddress(lib, "hostfxr_get_runtime_delegate");
    run_app_fptr = (hostfxr_run_app_fn)GetProcAddress(lib, "hostfxr_run_app");
    close_fptr = (hostfxr_close_fn)GetProcAddress(lib, "hostfxr_close");
    set_property_fptr = (hostfxr_set_runtime_property_value_fn)GetProcAddress(lib, "hostfxr_set_runtime_property_value");
    get_properties_fptr = (hostfxr_get_runtime_properties_fn)GetProcAddress(lib, "hostfxr_get_runtime_properties");

    if (!init_for_cmd_line_fptr || !init_for_config_fptr || !get_delegate_fptr || !close_fptr)
    {
        LogError("Failed to resolve one or more required hostfxr exports\n");
        return false;
    }
    return true;
}

// Try to load assembly with multiple possible names
struct AssemblyInfo {
    std::wstring dllPath;
    std::wstring className;
    std::wstring path;
    bool dllExists;
    bool exists;
};

std::vector<AssemblyInfo> FindPossibleAssemblies(const std::wstring& dirPath)
{
    std::vector<AssemblyInfo> assemblies;

    // Try different possible assembly names
    std::vector<std::wstring> names = {
        L"Game.dll"
    };

    for (const auto& name : names)
    {
        AssemblyInfo info;
        info.dllPath = dirPath + name;
        info.dllExists = (GetFileAttributesW(info.dllPath.c_str()) != INVALID_FILE_ATTRIBUTES);

        info.path = info.dllPath;
        info.exists = info.dllExists;

        // Derive class name from assembly name (remove .dll)
        std::wstring baseName = name.substr(0, name.find_last_of(L'.'));
        info.className = baseName + L".Program, " + baseName;

        assemblies.push_back(info);
    }

    return assemblies;
}

// Detect installed .NET version from hostfxr path
std::wstring DetectDotNetVersion(const std::wstring& hostfxrPath)
{
    // hostfxr path looks like: C:\Program Files\dotnet\host\fxr\10.0.2\hostfxr.dll
    // Extract the version number (10.0.2 in this example)

    size_t fxrPos = hostfxrPath.find(L"\\fxr\\");
    if (fxrPos == std::wstring::npos)
        return L"8.0.0"; // Default fallback

    size_t versionStart = fxrPos + 5; // Skip "\fxr\"
    size_t versionEnd = hostfxrPath.find(L'\\', versionStart);

    if (versionEnd == std::wstring::npos)
        return L"8.0.0";

    std::wstring version = hostfxrPath.substr(versionStart, versionEnd - versionStart);

    // Extract major version
    size_t dotPos = version.find(L'.');
    if (dotPos != std::wstring::npos)
    {
        std::wstring majorVersion = version.substr(0, dotPos);
        return majorVersion + L".0.0";
    }

    return L"8.0.0";
}

// OPTION 1: Load using temporary embedded config (MOST COMPATIBLE)
int LoadAndRunManagedCode_Embedded(const std::wstring& assemblyPath,
    const std::wstring& typeName, int argc, wchar_t** argv, const std::wstring& dotnetVersion)
{

    // Create a minimal runtime config with rollforward enabled
    std::wstring dirPath = assemblyPath.substr(0, assemblyPath.find_last_of(L"\\/") + 1);
    std::wstring tempConfigPath = dirPath + L"_angene_temp.config.json";

    // Get major version for tfm
    std::wstring majorVer = dotnetVersion.substr(0, dotnetVersion.find(L'.'));

    // Build config with rollforward to allow newer versions
    std::wstring configJson = L"{\n";
    configJson += L"  \"runtimeOptions\": {\n";
    configJson += L"    \"tfm\": \"net" + majorVer + L".0\",\n";
    configJson += L"    \"rollForward\": \"Major\",\n";
    configJson += L"    \"framework\": {\n";
    configJson += L"      \"name\": \"Microsoft.NETCore.App\",\n";
    configJson += L"      \"version\": \"" + dotnetVersion + L"\"\n";
    configJson += L"    }\n";
    configJson += L"  }\n";
    configJson += L"}";

    // Convert to narrow string for writing
    int size = WideCharToMultiByte(CP_UTF8, 0, configJson.c_str(), -1, nullptr, 0, nullptr, nullptr);
    std::string narrowConfig(size, 0);
    WideCharToMultiByte(CP_UTF8, 0, configJson.c_str(), -1, &narrowConfig[0], size, nullptr, nullptr);

    // Write temporary config file
    FILE* tempFile = nullptr;
    _wfopen_s(&tempFile, tempConfigPath.c_str(), L"w");
    if (tempFile)
    {
        fputs(narrowConfig.c_str(), tempFile);
        fclose(tempFile);
    }
    else
    {
        LogError("Failed to write temporary runtime config: %ls\n", tempConfigPath.c_str());
        return -1;
    }

    // Initialize using the temporary config
    hostfxr_initialize_parameters params{};
    params.size = sizeof(hostfxr_initialize_parameters);
    params.host_path = assemblyPath.c_str();

    LogMessage("[TRACE] Calling hostfxr_initialize_for_runtime_config...\n");
    hostfxr_handle cxt = nullptr;
    int rc = init_for_config_fptr(
        tempConfigPath.c_str(),
        &params,
        &cxt);

    // Delete the temporary config immediately after use
    DeleteFileW(tempConfigPath.c_str());

    if (rc != 0 || cxt == nullptr)
    {
        LogError("hostfxr_initialize_for_runtime_config failed, rc=0x%x\n", rc);
        if (cxt) close_fptr(cxt);
        return -1;
    }
    LogMessage("[TRACE] hostfxr_initialize_for_runtime_config OK (rc=0x%x)\n", rc);

    // Get the load assembly function pointer
    LogMessage("[TRACE] Calling hostfxr_get_runtime_delegate...\n");
    load_assembly_and_get_function_pointer_fn load_assembly_and_get_function_pointer = nullptr;
    rc = get_delegate_fptr(
        cxt,
        hdt_load_assembly_and_get_function_pointer,
        (void**)&load_assembly_and_get_function_pointer);

    if (rc != 0 || load_assembly_and_get_function_pointer == nullptr)
    {
        LogError("Failed to get load_assembly_and_get_function_pointer delegate, rc=0x%x\n", rc);
        close_fptr(cxt);
        return -1;
    }
    LogMessage("[TRACE] hostfxr_get_runtime_delegate OK\n");

    // Define the function pointer type
    typedef int (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(const wchar_t** argv, int argc);
    custom_entry_point_fn mainFunc = nullptr;

    // Load the assembly and get the function pointer
    LogMessage("[TRACE] Loading assembly and resolving %ls.Main...\n", typeName.c_str());
    rc = load_assembly_and_get_function_pointer(
        assemblyPath.c_str(),
        typeName.c_str(),
        L"Main",
        UNMANAGEDCALLERSONLY_METHOD,
        nullptr,
        (void**)&mainFunc);

    if (rc != 0 || mainFunc == nullptr)
    {
        LogError("Failed to load assembly / get function pointer for %ls, rc=0x%x\n", typeName.c_str(), rc);
        close_fptr(cxt);
        return -1;
    }
    LogMessage("[TRACE] Assembly loaded, Main resolved at %p\n", (void*)mainFunc);

    // Call the managed function
    LogMessage("[TRACE] Invoking managed Main() now...\n");
    const wchar_t** argvPtr = const_cast<const wchar_t**>(argv);
    int result = mainFunc(argvPtr, argc);
    LogMessage("[TRACE] Managed Main() returned %d\n", result);

    // Cleanup
    close_fptr(cxt);
    return result;
}

// Main entry point
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
    // Attach to the parent console (e.g. cmd/PowerShell) if one launched us, so
    // logging behaves the same as the Linux host. Silently does nothing if the
    // exe was double-clicked / has no parent console.
    g_consoleAvailable = AttachToConsole();

    LogMessage("Runtime: CoreCLR / hostfxr\n\n");

    // Parse command-line arguments (Windows style)
    int argc = 0;
    LPWSTR* argv = CommandLineToArgvW(GetCommandLineW(), &argc);

    if (argc > 1)
    {
        LogMessage("Command-line arguments received:\n");
        for (int i = 1; i < argc; i++) LogMessage("  [%d] %ls\n", i, argv[i]);
        LogMessage("\n");
    }

    // Load hostfxr
    if (!LoadHostfxr())
    {
        LogError("Failed to load hostfxr exports\n");
        if (argv) LocalFree(argv);
        return -1;
    }

    // Get executable directory
    wchar_t exePath[MAX_PATH];
    GetModuleFileNameW(NULL, exePath, MAX_PATH);

    std::wstring pathStr(exePath);
    size_t lastSlash = pathStr.find_last_of(L"\\/");
    std::wstring dirPath = pathStr.substr(0, lastSlash + 1);

    // Detect .NET version from hostfxr
    char_t hostfxrPath[MAX_PATH];
    size_t buffer_size = sizeof(hostfxrPath) / sizeof(char_t);
    get_hostfxr_path(hostfxrPath, &buffer_size, nullptr);
    std::wstring detectedVersion = DetectDotNetVersion(hostfxrPath);

    LogMessage("[OK] Detected .NET runtime version %ls\n\n", detectedVersion.c_str());

    // Scan for possible assemblies
    auto assemblies = FindPossibleAssemblies(dirPath);

    AssemblyInfo* targetAssembly = nullptr;
    for (auto& assembly : assemblies)
    {
        if (assembly.dllExists)
        {
            if (!targetAssembly)
                targetAssembly = &assembly;
        }
    }

    if (!targetAssembly)
    {
        LogError("No game assembly found!\n");
        if (argv) LocalFree(argv);
        return -1;
    }

    LogMessage("[OK] Using assembly %ls (type %ls)\n\n", targetAssembly->dllPath.c_str(), targetAssembly->className.c_str());

    // Execute using embedded config method (most compatible)
    int result = LoadAndRunManagedCode_Embedded(
        targetAssembly->dllPath,
        targetAssembly->className,
        argc,
        argv,
        detectedVersion);

    LogMessage("Exit Code: %d\n", result);

    // Free command-line argument memory
    if (argv) LocalFree(argv);

    return result;
}