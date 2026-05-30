using Newtonsoft.Json;
using System;
using System.IO;
using Angene.Common.Settings;
using System.Linq.Expressions;
using System.ComponentModel;

namespace Angene.Common
{
    public class AngeneException : Exception
    {
        public AngeneException(string message) : base(message) { }
        public AngeneException(string message, Exception inner) : base(message, inner) { }
    }
    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error,
        Critical,
        Important
    }

    public enum LoggingTarget
    {
        Network,
        Engine,
        MainConstructor,
        Method,
        Class,
        Definition,
        Call,
        MainGame,
        MasterScene,
        SlaveScene,
        Package,
        Graphics
    }

    public class Logger
    {
        public static readonly Logger Instance = new Logger();
        public static StreamWriter? LogInstance;
        private static readonly Settings.Settings settings = new Settings.Settings();
        private static readonly object logLock = new();
        public bool _verbose = false;

        public Action<object, object, object, object, object> OnLog { get; set; } = (_, _, _, _, _) => { };

        public void Init(bool verbose = false)
        {
            _verbose = verbose;
            // Create a new log file in Log\
            // Initialize LogInstance to write to that file
            try
            {
                string filePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Log"
                );

                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                string logFile = Path.Combine(
                    filePath,
                    $"log_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.log"
                );

                LogInstance = new StreamWriter(logFile)
                {
                    AutoFlush = true
                };

                LogInstance.WriteLine($"Log file created on {DateTime.Now}");
                LogInstance.WriteLine("Logger initialized!");
                string? version = settings.GetSetting("Main.Version") as string;
                LogInstance.WriteLine($"Engine Version: {version}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"[ERROR] Logger.(Static Constructor) ({DateTime.Now}): Failed to create log file. Exception: {ex.Message}");
            }
        }

        public static void Log(string message, LoggingTarget logFrom, LogLevel logLevel = LogLevel.Info, Exception? exception = null, bool enginePanic = false, int sceneNumber = -1)
        {
            lock (logLock)
            {
                
                if (LogInstance == null)
                {
                    System.Console.WriteLine($"[ERROR] Logger.Log ({DateTime.Now}): LogInstance is null. Message: {message}");
                    return;
                }

                // Write to file — including exception if present
                LogInstance.WriteLine($"[{logLevel}] {logFrom} ({DateTime.Now}): {message}");
                if (exception != null)
                {
                    LogInstance.WriteLine($"  >> {exception.GetType().FullName}: {exception.Message}");
                    LogInstance.WriteLine($"  >> Stack Trace: {exception.StackTrace}");
                    if (exception.InnerException != null)
                        LogInstance.WriteLine($"  >> Inner: {exception.InnerException.GetType().FullName}: {exception.InnerException.Message}");
                }

                if (sceneNumber != -1)
                    LogInstance.WriteLine($"Log came from Scene Number: {sceneNumber}");

                if (logLevel == LogLevel.Debug && settings.GetSetting("Console.LogDebugToConsole") as string == "1")
                {
                    System.Console.WriteLine($"[{logLevel}] {logFrom} ({DateTime.Now}): {message}");
                }

                // Message dispatcher
                switch (logLevel)
                {
                    case LogLevel.Info:
                        Instance.OnLog(message, logFrom, logLevel, DateTime.Now, null);
                        break;
                    case LogLevel.Warning:
                        Instance.OnLog(message, logFrom, logLevel, DateTime.Now, null);
                        break;
                    case LogLevel.Error:
                        Instance.OnLog(message, logFrom, logLevel, DateTime.Now, null);
                        break;
                    case LogLevel.Critical:
                        Instance.OnLog(message, logFrom, logLevel, DateTime.Now, exception);
                        if (enginePanic)
                            Instance.OnLog("[OnQuit] ExitOnException", logFrom, LogLevel.Important, DateTime.Now, null);
                        break;
                    case LogLevel.Important:
                        Instance.OnLog(message, logFrom, logLevel, DateTime.Now, null);
                        break;
                }

            }
        }

        public static void LogDebug(string message, LoggingTarget logFrom) { Log(message, logFrom, LogLevel.Debug); }
        public static void LogInfo(string message, LoggingTarget logFrom) { Log(message, logFrom, LogLevel.Info); }
        public static void LogWarning(string message, LoggingTarget logFrom) { Log(message, logFrom, LogLevel.Warning); }
        public static void LogError(string message, LoggingTarget logFrom) { Log(message, logFrom, LogLevel.Error); }
        public static void LogCritical(string message, LoggingTarget logFrom, Exception exception, bool enginePanic = false) { Log(message, logFrom, LogLevel.Critical, exception, enginePanic); }

        public static void Shutdown()
        {
            lock (logLock)
            {
                LogInstance?.Flush();
                LogInstance?.Dispose();
            }
        }
    }
}
