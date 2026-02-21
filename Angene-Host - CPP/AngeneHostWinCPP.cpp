#include <windows.h>
#include <stdio.h>
#include <string>
#include <vector>
#include "nethost.h"
#include "coreclr_delegates.h"
#include "hostfxr.h"

#pragma comment(lib, "shell32.lib")  // For CommandLineToArgvW

bool g_consoleAvailable = false;

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
        return false;
    }

    HMODULE lib = LoadLibraryW(buffer);
    if (!lib)
    {
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

    if (rc != 0 || cxt == nullptr)
    {
        if (cxt) close_fptr(cxt);
        return -1;
    }

    // Get the load assembly function pointer
    load_assembly_and_get_function_pointer_fn load_assembly_and_get_function_pointer = nullptr;
    rc = get_delegate_fptr(
        cxt,
        hdt_load_assembly_and_get_function_pointer,
        (void**)&load_assembly_and_get_function_pointer);

    if (rc != 0 || load_assembly_and_get_function_pointer == nullptr)
    {
        close_fptr(cxt);
        return -1;
    }

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
        close_fptr(cxt);
        return -1;
    }

    // Call the managed function
    const wchar_t** argvPtr = const_cast<const wchar_t**>(argv);
    int result = mainFunc(argvPtr, argc);

    // Cleanup
    close_fptr(cxt);
    return result;
}

// Main entry point
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
    // Parse command-line arguments (Windows style)
    int argc = 0;
    LPWSTR* argv = CommandLineToArgvW(GetCommandLineW(), &argc);

    // Load hostfxr
    if (!LoadHostfxr())
    {
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
        return -1;
    }

    // Execute using embedded config method (most compatible)
    int result = LoadAndRunManagedCode_Embedded(
        targetAssembly->dllPath,
        targetAssembly->className,
        argc,
        argv,
        detectedVersion);

    // Free command-line argument memory
    if (argv) LocalFree(argv);

    return result;
}