#include <windows.h>
#include <stdio.h>
#include <string>
#include <vector>
#include "nethost.h"
#include "coreclr_delegates.h"
#include "hostfxr.h"

#pragma comment(lib, "shell32.lib")  // For CommandLineToArgvW

// Global flag to control logging behavior
bool g_consoleAvailable = false;
FILE* g_logFile = nullptr;

// Logging functions that work with or without console
void LogMessage(const wchar_t* format, ...)
{
    wchar_t buffer[1024];
    va_list args;
    va_start(args, format);
    vswprintf_s(buffer, 1024, format, args);
    va_end(args);

    if (g_consoleAvailable)
    {
        wprintf(L"%s", buffer);
    }

    if (g_logFile)
    {
        fwprintf(g_logFile, L"%s", buffer);
        fflush(g_logFile);
    }
}

void LogError(const wchar_t* format, ...)
{
    wchar_t buffer[1024];
    va_list args;
    va_start(args, format);
    vswprintf_s(buffer, 1024, format, args);
    va_end(args);

    if (g_consoleAvailable)
    {
        wprintf(L"ERROR: %s", buffer);
    }

    if (g_logFile)
    {
        fwprintf(g_logFile, L"ERROR: %s", buffer);
        fflush(g_logFile);
    }
}

// Check if we have a console available
bool CheckConsoleAvailable()
{
    HWND consoleWnd = GetConsoleWindow();
    if (consoleWnd == NULL)
        return false;

    HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
    if (hStdOut == NULL || hStdOut == INVALID_HANDLE_VALUE)
        return false;

    return true;
}

// Initialize logging
void InitializeLogging()
{
    g_consoleAvailable = CheckConsoleAvailable();

    wchar_t logPath[MAX_PATH];
    GetModuleFileNameW(NULL, logPath, MAX_PATH);

    std::wstring pathStr(logPath);
    size_t lastSlash = pathStr.find_last_of(L"\\/");
    std::wstring dirPath = pathStr.substr(0, lastSlash + 1);
    std::wstring logFile = dirPath + L"angene_host.log";

    _wfopen_s(&g_logFile, logFile.c_str(), L"w");

    if (g_logFile)
    {
        LogMessage(L"Log file created: %s\n", logFile.c_str());
    }
}

void CleanupLogging()
{
    if (g_logFile)
    {
        fclose(g_logFile);
        g_logFile = nullptr;
    }
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
        LogError(L"Failed to find hostfxr library (error code: %d)\n", rc);
        LogMessage(L"Please ensure .NET 8+ Runtime is installed\n");
        LogMessage(L"Download from: https://dotnet.microsoft.com/download/dotnet\n");
        return false;
    }

    LogMessage(L"hostfxr path: %s\n", buffer);

    // Load hostfxr
    HMODULE lib = LoadLibraryW(buffer);
    if (!lib)
    {
        LogError(L"Failed to load hostfxr library\n");
        return false;
    }

    LogMessage(L"[OK] hostfxr library loaded\n");

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
        LogError(L"Failed to get required hostfxr function pointers\n");
        return false;
    }

    LogMessage(L"[OK] hostfxr function pointers obtained\n");
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
    LogMessage(L"\n========================================\n");
    LogMessage(L"Using embedded configuration method\n");
    LogMessage(L"(Temporary config with version rollforward)\n");
    LogMessage(L"========================================\n\n");

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
        LogMessage(L"Created temporary config: %s\n", tempConfigPath.c_str());
        LogMessage(L"Target .NET version: %s (with Major rollforward)\n", dotnetVersion.c_str());
    }
    else
    {
        LogError(L"Failed to create temporary config file\n");
        return -1;
    }

    // Initialize using the temporary config
    hostfxr_initialize_parameters params{};
    params.size = sizeof(hostfxr_initialize_parameters);
    params.host_path = assemblyPath.c_str();

    hostfxr_handle cxt = nullptr;
    int rc = init_for_config_fptr(
        tempConfigPath.c_str(),
        &params,
        &cxt);

    // Delete the temporary config immediately after use
    DeleteFileW(tempConfigPath.c_str());
    LogMessage(L"Deleted temporary config file\n");

    if (rc != 0 || cxt == nullptr)
    {
        LogError(L"Failed to initialize .NET runtime (error code: 0x%08X)\n", rc);
        LogMessage(L"\nTroubleshooting:\n");
        LogMessage(L"  - Ensure .NET %s+ Runtime is installed\n", majorVer.c_str());
        LogMessage(L"  - Check that all assembly dependencies are present\n");
        LogMessage(L"  - Run 'dotnet --list-runtimes' to see installed versions\n");
        if (cxt) close_fptr(cxt);
        return -1;
    }

    LogMessage(L"[OK] .NET runtime initialized successfully\n\n");

    // Get the load assembly function pointer
    load_assembly_and_get_function_pointer_fn load_assembly_and_get_function_pointer = nullptr;
    rc = get_delegate_fptr(
        cxt,
        hdt_load_assembly_and_get_function_pointer,
        (void**)&load_assembly_and_get_function_pointer);

    if (rc != 0 || load_assembly_and_get_function_pointer == nullptr)
    {
        LogError(L"Failed to get load_assembly delegate (error code: 0x%08X)\n", rc);
        close_fptr(cxt);
        return -1;
    }

    LogMessage(L"[OK] Load assembly delegate obtained\n\n");

    // Define the function pointer type
    typedef int (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(const wchar_t** argv, int argc);
    custom_entry_point_fn mainFunc = nullptr;

    // Load the assembly and get the function pointer
    rc = load_assembly_and_get_function_pointer(
        assemblyPath.c_str(),
        typeName.c_str(),
        L"Main",
        UNMANAGEDCALLERSONLY_METHOD,
        nullptr,
        (void**)&mainFunc);

    if (rc != 0 || mainFunc == nullptr)
    {
        LogError(L"Failed to load assembly and get Main function pointer (error code: 0x%08X)\n", rc);
        LogMessage(L"\nPossible causes:\n");
        LogMessage(L"  - Assembly: %s\n", assemblyPath.c_str());
        LogMessage(L"  - Type: %s\n", typeName.c_str());
        LogMessage(L"  - Method signature must be: [UnmanagedCallersOnly] public static int Main(IntPtr args, int argc)\n");
        close_fptr(cxt);
        return -1;
    }

    LogMessage(L"[OK] Main function pointer obtained\n");
    LogMessage(L"Executing managed code...\n\n");

    // Call the managed function
    const wchar_t** argvPtr = const_cast<const wchar_t**>(argv);
    int result = mainFunc(argvPtr, argc);

    LogMessage(L"\n[OK] Managed code execution completed\n");
    LogMessage(L"Return code: %d\n", result);

    // Cleanup
    close_fptr(cxt);
    return result;
}

// Main entry point
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
    // Initialize logging system
    InitializeLogging();

    LogMessage(L"========================================\n");
    LogMessage(L"  Angene Native Host Launcher\n");
    LogMessage(L"  No Persistent Config Files\n");
    LogMessage(L"========================================\n\n");

    if (g_consoleAvailable)
    {
        LogMessage(L"Running mode: Console attached\n");
    }
    else
    {
        LogMessage(L"Running mode: Background (no console)\n");
        LogMessage(L"Output is being logged to angene_host.log\n");
    }
    LogMessage(L"\n");

    // Parse command-line arguments (Windows style)
    int argc = 0;
    LPWSTR* argv = CommandLineToArgvW(GetCommandLineW(), &argc);

    if (argv != nullptr && argc > 1)
    {
        LogMessage(L"Command-line arguments received:\n");
        for (int i = 0; i < argc; i++)
        {
            LogMessage(L"  [%d] %s\n", i, argv[i]);
        }
        LogMessage(L"\n");
    }

    // Load hostfxr
    if (!LoadHostfxr())
    {
        if (argv) LocalFree(argv);
        CleanupLogging();
        return -1;
    }

    // Get executable directory
    wchar_t exePath[MAX_PATH];
    GetModuleFileNameW(NULL, exePath, MAX_PATH);

    std::wstring pathStr(exePath);
    size_t lastSlash = pathStr.find_last_of(L"\\/");
    std::wstring dirPath = pathStr.substr(0, lastSlash + 1);

    LogMessage(L"\nExecutable directory: %s\n\n", dirPath.c_str());

    // Detect .NET version from hostfxr
    char_t hostfxrPath[MAX_PATH];
    size_t buffer_size = sizeof(hostfxrPath) / sizeof(char_t);
    get_hostfxr_path(hostfxrPath, &buffer_size, nullptr);
    std::wstring detectedVersion = DetectDotNetVersion(hostfxrPath);
    LogMessage(L"Detected .NET version: %s\n", detectedVersion.c_str());
    LogMessage(L"(Will use rollforward to accept newer versions)\n\n");

    // Scan for possible assemblies
    auto assemblies = FindPossibleAssemblies(dirPath);

    LogMessage(L"Scanning for game assemblies:\n");
    AssemblyInfo* targetAssembly = nullptr;
    for (auto& assembly : assemblies)
    {
        LogMessage(L"  DLL: %s %s\n", assembly.dllPath.c_str(),
            assembly.dllExists ? L"[FOUND]" : L"[MISS]");

        if (assembly.dllExists)
        {
            if (!targetAssembly)
                targetAssembly = &assembly;
        }
        LogMessage(L"\n");
    }

    if (!targetAssembly)
    {
        LogMessage(L"========================================\n");
        LogError(L"No game assembly found!\n");
        LogMessage(L"========================================\n");
        LogMessage(L"Required files:\n");
        for (const auto& assembly : assemblies)
        {
            LogMessage(L"  - %s\n", assembly.dllPath.c_str());
        }
        if (argv) LocalFree(argv);
        CleanupLogging();
        return -1;
    }

    LogMessage(L"Loading managed assembly:\n");
    LogMessage(L"  DLL:    %s\n", targetAssembly->dllPath.c_str());
    LogMessage(L"  Class:  %s\n", targetAssembly->className.c_str());
    LogMessage(L"  Method: Main\n");

    // Execute using embedded config method (most compatible)
    int result = LoadAndRunManagedCode_Embedded(
        targetAssembly->dllPath,
        targetAssembly->className,
        argc,
        argv,
        detectedVersion);

    // Free command-line argument memory
    if (argv) LocalFree(argv);

    LogMessage(L"\n========================================\n");
    if (result == 0)
    {
        LogMessage(L"Game execution completed successfully\n");
    }
    else
    {
        LogMessage(L"Game execution completed with errors\n");
    }
    LogMessage(L"========================================\n");
    LogMessage(L"Final return code: %d\n\n", result);

    CleanupLogging();
    return result;
}