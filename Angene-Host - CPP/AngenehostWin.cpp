#include <windows.h>
#include <metahost.h>
#include <stdio.h>
#include <string>
#include <vector>

#pragma comment(lib, "mscoree.lib")
#pragma comment(lib, "shell32.lib")  // For CommandLineToArgvW

// Import mscorlib for basic .NET functionality
#import "mscorlib.tlb" raw_interfaces_only \
    high_property_prefixes("_get","_put","_putref") \
    rename("ReportEvent", "InteropServices_ReportEvent")

using namespace mscorlib;

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

// Error handling macro
#define CHECK_HR(hr, msg) if (FAILED(hr)) { \
    LogError(L"%s (HRESULT: 0x%08X)\n", msg, hr); \
    return hr; \
}

// Try to load assembly with multiple possible names
struct AssemblyInfo {
    std::wstring path;
    std::wstring className;
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
        info.path = dirPath + name;
        info.exists = (GetFileAttributesW(info.path.c_str()) != INVALID_FILE_ATTRIBUTES);

        // Derive class name from assembly name (remove .dll)
        std::wstring baseName = name.substr(0, name.find_last_of(L'.'));
        info.className = baseName + L".Program";

        assemblies.push_back(info);
    }

    return assemblies;
}

// Main entry point - use WinMain for windowless app
// Correct WinMain signature (no extra parameters!)
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
    HRESULT hr;
    DWORD dwRetVal = 0;  // DECLARE dwRetVal here!

    // Initialize logging system
    InitializeLogging();

    LogMessage(L"========================================\n");
    LogMessage(L"  Angene Native Host Launcher\n");
    LogMessage(L"  SOTD: Cheese Quesadillas\n");
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
        for (int i = 1; i < argc; i++)  // Start at 1 to skip program name
        {
            LogMessage(L"  [%d] %s\n", i, argv[i]);
        }
        LogMessage(L"\n");
    }

    // Step 1: Get the ICLRMetaHost interface
    ICLRMetaHost* pMetaHost = nullptr;
    hr = CLRCreateInstance(CLSID_CLRMetaHost, IID_ICLRMetaHost, (LPVOID*)&pMetaHost);
    CHECK_HR(hr, L"Failed to create CLRMetaHost");

    LogMessage(L"[OK] CLR MetaHost created\n");

    // Step 2: Get the ICLRRuntimeInfo for .NET Framework 4.x
    ICLRRuntimeInfo* pRuntimeInfo = nullptr;
    hr = pMetaHost->GetRuntime(L"v4.0.30319", IID_ICLRRuntimeInfo, (LPVOID*)&pRuntimeInfo);
    CHECK_HR(hr, L"Failed to get runtime info");

    LogMessage(L"[OK] Runtime info obtained (.NET Framework 4.x)\n");

    // Check if runtime is loadable
    BOOL loadable = FALSE;
    hr = pRuntimeInfo->IsLoadable(&loadable);
    CHECK_HR(hr, L"Failed to check if runtime is loadable");

    if (!loadable)
    {
        LogError(L".NET Framework 4.x runtime is not loadable\n");
        LogError(L"Please install .NET Framework 4.8 or later\n");
        if (argv) LocalFree(argv);
        CleanupLogging();
        return E_FAIL;
    }

    LogMessage(L"[OK] Runtime is loadable\n");

    // Step 3: Get the ICLRRuntimeHost interface
    ICLRRuntimeHost* pClrRuntimeHost = nullptr;
    hr = pRuntimeInfo->GetInterface(CLSID_CLRRuntimeHost, IID_ICLRRuntimeHost, (LPVOID*)&pClrRuntimeHost);
    CHECK_HR(hr, L"Failed to get CLR runtime host");

    LogMessage(L"[OK] CLR Runtime Host interface obtained\n");

    // Step 4: Start the CLR
    hr = pClrRuntimeHost->Start();
    CHECK_HR(hr, L"Failed to start CLR");

    LogMessage(L"[OK] CLR started successfully\n\n");

    // Step 5: Build path to managed assembly
    wchar_t assemblyPath[MAX_PATH];
    GetModuleFileNameW(NULL, assemblyPath, MAX_PATH);

    // Get directory of the executable
    std::wstring pathStr(assemblyPath);
    size_t lastSlash = pathStr.find_last_of(L"\\/");
    std::wstring dirPath = pathStr.substr(0, lastSlash + 1);

    LogMessage(L"Executable directory: %s\n\n", dirPath.c_str());

    // Scan for possible assemblies
    auto assemblies = FindPossibleAssemblies(dirPath);

    LogMessage(L"Scanning for game assemblies:\n");
    AssemblyInfo* targetAssembly = nullptr;
    for (auto& assembly : assemblies)
    {
        if (assembly.exists)
        {
            LogMessage(L"  [FOUND] %s\n", assembly.path.c_str());
            if (!targetAssembly)
                targetAssembly = &assembly;
        }
        else
        {
            LogMessage(L"  [MISS]  %s\n", assembly.path.c_str());
        }
    }

    if (!targetAssembly)
    {
        LogMessage(L"\n========================================\n");
        LogError(L"No game assembly found!\n");
        LogMessage(L"========================================\n");
        LogMessage(L"Expected one of:\n");
        for (const auto& assembly : assemblies)
        {
            LogMessage(L"  - %s\n", assembly.path.c_str());
        }
        if (argv) LocalFree(argv);
        CleanupLogging();
        return E_FAIL;
    }

    LogMessage(L"\nLoading managed assembly:\n");
    LogMessage(L"  Path: %s\n", targetAssembly->path.c_str());
    LogMessage(L"  Class: %s\n", targetAssembly->className.c_str());
    LogMessage(L"  Method: Main\n\n");

    // Build arguments string for managed code
    std::wstring joinedArgs;
    if (argv != nullptr && argc > 1)
    {
        for (int i = 1; i < argc; i++)  // Start at 1 to skip program name
        {
            joinedArgs += argv[i];
            if (i < argc - 1)
                joinedArgs += L" ";  // Space between arguments
        }

        LogMessage(L"Arguments to pass: \"%s\"\n\n", joinedArgs.c_str());
    }
    else
    {
        LogMessage(L"No arguments to pass\n\n");
    }

    // Step 6: Execute the managed entry point
    hr = pClrRuntimeHost->ExecuteInDefaultAppDomain(
        targetAssembly->path.c_str(),       // Path to DLL
        targetAssembly->className.c_str(),  // Fully qualified class name
        L"Main",                            // Static method name
        joinedArgs.c_str(),                 // Arguments as single string
        &dwRetVal                           // Return value
    );

    // Free command-line argument memory
    if (argv) LocalFree(argv);

    if (FAILED(hr))
    {
        LogMessage(L"\n");
        LogMessage(L"========================================\n");
        LogError(L"Failed to execute managed entry point\n");
        LogMessage(L"========================================\n");
        LogError(L"HRESULT: 0x%08X\n\n", hr);

        // Detailed error explanations
        switch (hr)
        {
        case 0x80131522:
            LogError(L"Error Code: COR_E_METHODACCESS (0x80131522)\n");
            LogMessage(L"This means the method signature is incorrect!\n\n");
            LogMessage(L"Required signature:\n");
            LogMessage(L"  public static int Main(string args)\n\n");
            LogMessage(L"Common mistakes:\n");
            LogMessage(L"  - Using 'string[] args' instead of 'string args'\n");
            LogMessage(L"  - Method is not public\n");
            LogMessage(L"  - Method is not static\n");
            LogMessage(L"  - Return type is not int\n");
            break;

        case 0x80131040:
            LogError(L"Error Code: COR_E_FILENOTFOUND (0x80131040)\n");
            LogMessage(L"Assembly or one of its dependencies not found\n");
            break;

        case 0x80131513:
            LogError(L"Error Code: COR_E_TYPELOAD (0x80131513)\n");
            LogMessage(L"Type not found or not accessible\n");
            LogMessage(L"Check that the class is public and in the correct namespace\n");
            break;

        case 0x80004005:
            LogError(L"Error Code: E_FAIL (0x80004005)\n");
            LogMessage(L"General failure - check dependencies\n");
            break;
        }

        LogMessage(L"\nTroubleshooting checklist:\n");
        LogMessage(L"  - Assembly exists: %s\n", targetAssembly->path.c_str());
        LogMessage(L"  - Class is public: %s\n", targetAssembly->className.c_str());
        LogMessage(L"  - Method signature: 'public static int Main(string args)'\n");
        LogMessage(L"  - All dependencies present (check DLLs in same folder)\n");
        LogMessage(L"  - .NET Framework 4.8 installed\n");
    }
    else
    {
        LogMessage(L"\n========================================\n");
        LogMessage(L"Game execution completed\n");
        LogMessage(L"========================================\n");
        LogMessage(L"Return code: %d\n", dwRetVal);
        if (dwRetVal == 0)
            LogMessage(L"Status: SUCCESS\n");
        else
            LogMessage(L"Status: ERROR (non-zero exit code)\n");
    }

    // Step 7: Cleanup and shutdown
    LogMessage(L"\nShutting down CLR...\n");

    if (pClrRuntimeHost)
    {
        pClrRuntimeHost->Stop();
        pClrRuntimeHost->Release();
    }

    if (pRuntimeInfo)
        pRuntimeInfo->Release();

    if (pMetaHost)
        pMetaHost->Release();

    LogMessage(L"[OK] Host terminated cleanly\n");

    CleanupLogging();

    return (int)dwRetVal;
}