#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdarg.h>
#include <vector>
#include <string>

#ifdef _WIN32
    #include <windows.h>
    #define PATH_SEPARATOR "\\"
    #define MAX_PATH_LEN MAX_PATH
#else
    #include <unistd.h>
    #include <limits.h>
    #include <libgen.h>
    #define PATH_SEPARATOR "/"
    #define MAX_PATH_LEN PATH_MAX
    #ifndef FALSE
        #define FALSE 0
    #endif
    #ifndef TRUE
        #define TRUE 1
    #endif
#endif

#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/debug-helpers.h>
#include <mono/metadata/mono-config.h>

// Global logging
FILE* g_logFile = nullptr;
bool g_consoleAvailable = true;

void LogMessage(const char* format, ...)
{
    char buffer[1024];
    va_list args;
    va_start(args, format);
    vsnprintf(buffer, sizeof(buffer), format, args);
    va_end(args);

    if (g_consoleAvailable)
    {
        printf("%s", buffer);
    }

    if (g_logFile)
    {
        fprintf(g_logFile, "%s", buffer);
        fflush(g_logFile);
    }
}

void LogError(const char* format, ...)
{
    char buffer[1024];
    va_list args;
    va_start(args, format);
    vsnprintf(buffer, sizeof(buffer), format, args);
    va_end(args);

    if (g_consoleAvailable)
    {
        fprintf(stderr, "ERROR: %s", buffer);
    }

    if (g_logFile)
    {
        fprintf(g_logFile, "ERROR: %s", buffer);
        fflush(g_logFile);
    }
}

// Get executable directory in a cross-platform way
std::string GetExecutableDirectory()
{
    char path[MAX_PATH_LEN];
    char resolved[MAX_PATH_LEN];
    
#ifdef _WIN32
    GetModuleFileNameA(NULL, path, MAX_PATH_LEN);
    // Find last backslash
    char* lastSlash = strrchr(path, '\\');
    if (lastSlash)
    {
        *(lastSlash + 1) = '\0';
    }
    return std::string(path);
#elif defined(__APPLE__)
    uint32_t size = sizeof(path);
    if (_NSGetExecutablePath(path, &size) == 0)
    {
        // Resolve to absolute path
        if (realpath(path, resolved) != NULL)
        {
            // Make a copy for dirname since it modifies the string
            char temp[MAX_PATH_LEN];
            strncpy(temp, resolved, MAX_PATH_LEN - 1);
            temp[MAX_PATH_LEN - 1] = '\0';
            
            char* dir = dirname(temp);
            snprintf(resolved, MAX_PATH_LEN, "%s/", dir);
            return std::string(resolved);
        }
    }
    return "./";
#else // Linux
    ssize_t len = readlink("/proc/self/exe", path, sizeof(path) - 1);
    if (len != -1)
    {
        path[len] = '\0';
        
        // dirname() modifies its argument, so make a copy
        char temp[MAX_PATH_LEN];
        strncpy(temp, path, MAX_PATH_LEN - 1);
        temp[MAX_PATH_LEN - 1] = '\0';
        
        char* dir = dirname(temp);
        snprintf(resolved, MAX_PATH_LEN, "%s/", dir);
        return std::string(resolved);
    }
    return "./";
#endif
}

// Check if file exists
bool FileExists(const std::string& path)
{
#ifdef _WIN32
    DWORD attrs = GetFileAttributesA(path.c_str());
    return (attrs != INVALID_FILE_ATTRIBUTES);
#else
    return (access(path.c_str(), F_OK) == 0);
#endif
}

void InitializeLogging(const std::string& exeDir)
{
    std::string logPath = exeDir + "angene_host.log";
    g_logFile = fopen(logPath.c_str(), "w");
    
    if (g_logFile)
    {
        LogMessage("Log file created: %s\n", logPath.c_str());
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

struct AssemblyInfo
{
    std::string path;
    std::string namespaceName;
    std::string className;
    bool exists;
};

std::vector<AssemblyInfo> FindPossibleAssemblies(const std::string& dirPath)
{
    std::vector<AssemblyInfo> assemblies;
    
    // Try different possible assembly names
    std::vector<std::string> names = {
        "Game.dll"
    };
    
    for (const auto& name : names)
    {
        AssemblyInfo info;
        info.path = dirPath + name;
        info.exists = FileExists(info.path);
        
        // Derive namespace and class name from assembly name
        std::string baseName = name.substr(0, name.find_last_of('.'));
        info.namespaceName = baseName;
        info.className = "Program";
        
        assemblies.push_back(info);
    }
    
    return assemblies;
}

int main(int argc, char* argv[])
{
    // Get executable directory
    std::string exeDir = GetExecutableDirectory();
    
    // Initialize logging
    InitializeLogging(exeDir);
    
    LogMessage("========================================\n");
    LogMessage("  Angene Native Host Launcher\n");
    LogMessage("  SOTD: Cheese Quesadillas\n");
    LogMessage("========================================\n\n");
    
#ifdef _WIN32
    LogMessage("Platform: Windows\n");
#elif defined(__APPLE__)
    LogMessage("Platform: macOS\n");
#else
    LogMessage("Platform: Linux\n");
#endif
    
    LogMessage("Runtime: Mono\n\n");
    
    if (argc > 1)
    {
        LogMessage("Command-line arguments received:\n");
        for (int i = 1; i < argc; i++)
        {
            LogMessage("  [%d] %s\n", i, argv[i]);
        }
        LogMessage("\n");
    }
    
    // Step 1: Initialize Mono
    LogMessage("Initializing Mono runtime...\n");
    
    // Set up config paths (optional but recommended)
    mono_config_parse(NULL);
    
    // Create a domain
    MonoDomain* domain = mono_jit_init("AngeneHost");
    if (!domain)
    {
        LogError("Failed to initialize Mono JIT\n");
        CleanupLogging();
        return 1;
    }
    
    LogMessage("[OK] Mono runtime initialized\n\n");
    
    // Step 2: Find and load assembly
    LogMessage("Executable directory: %s\n\n", exeDir.c_str());
    
    auto assemblies = FindPossibleAssemblies(exeDir);
    
    LogMessage("Scanning for game assemblies:\n");
    AssemblyInfo* targetAssembly = nullptr;
    for (auto& assembly : assemblies)
    {
        if (assembly.exists)
        {
            LogMessage("  [FOUND] %s\n", assembly.path.c_str());
            if (!targetAssembly)
                targetAssembly = &assembly;
        }
        else
        {
            LogMessage("  [MISS]  %s\n", assembly.path.c_str());
        }
    }
    
    if (!targetAssembly)
    {
        LogMessage("\n========================================\n");
        LogError("No game assembly found!\n");
        LogMessage("========================================\n");
        LogMessage("Expected one of:\n");
        for (const auto& assembly : assemblies)
        {
            LogMessage("  - %s\n", assembly.path.c_str());
        }
        mono_jit_cleanup(domain);
        CleanupLogging();
        return 1;
    }
    
    LogMessage("\nLoading managed assembly:\n");
    LogMessage("  Path: %s\n", targetAssembly->path.c_str());
    LogMessage("  Namespace: %s\n", targetAssembly->namespaceName.c_str());
    LogMessage("  Class: %s\n", targetAssembly->className.c_str());
    LogMessage("  Method: Main\n\n");
    
    // Step 3: Load the assembly
    MonoAssembly* assembly = mono_domain_assembly_open(domain, targetAssembly->path.c_str());
    if (!assembly)
    {
        LogError("Failed to load assembly: %s\n", targetAssembly->path.c_str());
        mono_jit_cleanup(domain);
        CleanupLogging();
        return 1;
    }
    
    LogMessage("[OK] Assembly loaded\n");
    
    MonoImage* image = mono_assembly_get_image(assembly);
    if (!image)
    {
        LogError("Failed to get assembly image\n");
        mono_jit_cleanup(domain);
        CleanupLogging();
        return 1;
    }
    
    LogMessage("[OK] Assembly image obtained\n");
    
    // Step 4: Find the class
    MonoClass* klass = mono_class_from_name(image, targetAssembly->namespaceName.c_str(), 
                                             targetAssembly->className.c_str());
    if (!klass)
    {
        LogError("Failed to find class: %s.%s\n", 
                targetAssembly->namespaceName.c_str(), 
                targetAssembly->className.c_str());
        mono_jit_cleanup(domain);
        CleanupLogging();
        return 1;
    }
    
    LogMessage("[OK] Class found\n");
    
    // Step 5: Find the Main method
    // Try different signatures
    MonoMethod* method = nullptr;
    
    // Try: public static int Main(string args)
    MonoMethodDesc* desc = mono_method_desc_new("::Main(string)", FALSE);
    method = mono_method_desc_search_in_class(desc, klass);
    mono_method_desc_free(desc);
    
    if (!method)
    {
        // Try: public static int Main(string[])
        desc = mono_method_desc_new("::Main(string[])", FALSE);
        method = mono_method_desc_search_in_class(desc, klass);
        mono_method_desc_free(desc);
    }
    
    if (!method)
    {
        // Try: public static void Main(string[])
        desc = mono_method_desc_new("::Main(string[])", FALSE);
        method = mono_method_desc_search_in_class(desc, klass);
        mono_method_desc_free(desc);
    }
    
    if (!method)
    {
        LogError("Failed to find Main method\n");
        LogMessage("Tried signatures:\n");
        LogMessage("  - public static int Main(string args)\n");
        LogMessage("  - public static int Main(string[] args)\n");
        LogMessage("  - public static void Main(string[] args)\n");
        mono_jit_cleanup(domain);
        CleanupLogging();
        return 1;
    }
    
    LogMessage("[OK] Main method found\n\n");
    
    // Step 6: Prepare arguments
    MonoArray* args_array = nullptr;
    void* method_args[1];
    
    if (argc > 1)
    {
        // Create string array for arguments
        args_array = mono_array_new(domain, mono_get_string_class(), argc - 1);
        
        for (int i = 1; i < argc; i++)
        {
            MonoString* arg_str = mono_string_new(domain, argv[i]);
            mono_array_set(args_array, MonoString*, i - 1, arg_str);
        }
        
        method_args[0] = args_array;
        LogMessage("Passing %d argument(s) to managed code\n\n", argc - 1);
    }
    else
    {
        // Create empty array
        args_array = mono_array_new(domain, mono_get_string_class(), 0);
        method_args[0] = args_array;
        LogMessage("No arguments to pass\n\n");
    }
    
    // Step 7: Execute the method
    LogMessage("Executing managed entry point...\n\n");
    
    MonoObject* exception = nullptr;
    MonoObject* result = mono_runtime_invoke(method, nullptr, method_args, &exception);
    
    int returnCode = 0;
    
    if (exception)
    {
        LogMessage("\n========================================\n");
        LogError("Exception occurred during execution\n");
        LogMessage("========================================\n");
        
        // Get exception message
        MonoClass* exc_class = mono_object_get_class(exception);
        MonoProperty* prop = mono_class_get_property_from_name(exc_class, "Message");
        if (prop)
        {
            MonoMethod* getter = mono_property_get_get_method(prop);
            MonoString* msg = (MonoString*)mono_runtime_invoke(getter, exception, nullptr, nullptr);
            char* msg_utf8 = mono_string_to_utf8(msg);
            LogError("Message: %s\n", msg_utf8);
            mono_free(msg_utf8);
        }
        
        returnCode = 1;
    }
    else
    {
        LogMessage("\n========================================\n");
        LogMessage("Game execution completed\n");
        LogMessage("========================================\n");
        
        if (result)
        {
            // Try to unbox as int
            returnCode = *(int*)mono_object_unbox(result);
            LogMessage("Return code: %d\n", returnCode);
        }
        else
        {
            LogMessage("Return code: 0 (void method)\n");
        }
        
        if (returnCode == 0)
            LogMessage("Status: SUCCESS\n");
        else
            LogMessage("Status: ERROR (non-zero exit code)\n");
    }
    
    // Step 8: Cleanup
    LogMessage("\nShutting down Mono runtime...\n");
    mono_jit_cleanup(domain);
    LogMessage("[OK] Host terminated cleanly\n");
    
    CleanupLogging();
    
    return returnCode;
}