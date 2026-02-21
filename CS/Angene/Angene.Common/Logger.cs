using Newtonsoft.Json;
using System;
using System.IO;
using Angene.Common.Settings;
using System.Linq.Expressions;

namespace Angene.Common
{
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
        Package
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
                    $"log_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt"
                );

                LogInstance = new StreamWriter(logFile)
                {
                    AutoFlush = true
                };

                LogInstance.WriteLine($"Log file created on {DateTime.Now}");
                LogInstance.WriteLine("Logger initialized!");
                string version = settings.GetSetting("Main.Version");
                LogInstance.WriteLine($"Engine Version: {version}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"[ERROR] Logger.(Static Constructor) ({DateTime.Now}): Failed to create log file. Exception: {ex.Message}");
            }
        }

        public static void Log(string message, LoggingTarget logFrom, LogLevel logLevel = LogLevel.Info, Exception exception = null, int sceneNumber = -1)
        {
            lock (logLock)
            {
                if (LogInstance == null)
                {
                    System.Console.WriteLine($"[ERROR] Logger.Log ({DateTime.Now}): LogInstance is null. Message: {message}");
                    return;
                }

                // Write to file — including exception if present
                Logger.LogInstance.WriteLine($"[{logLevel}] {logFrom} ({DateTime.Now}): {message}");
                if (exception != null)
                {
                    Logger.LogInstance.WriteLine($"  >> {exception.GetType().FullName}: {exception.Message}");
                    Logger.LogInstance.WriteLine($"  >> Stack Trace: {exception.StackTrace}");
                    if (exception.InnerException != null)
                        Logger.LogInstance.WriteLine($"  >> Inner: {exception.InnerException.GetType().FullName}: {exception.InnerException.Message}");
                }

                if (sceneNumber != -1)

                    Logger.LogInstance.WriteLine($"Log came from Scene Number: {sceneNumber}");

                if (logLevel == LogLevel.Debug && settings.GetSetting("Console.LogDebugToConsole") == "1")
                {
                    System.Console.ForegroundColor = ConsoleColor.Gray;
                    System.Console.WriteLine($"[{logLevel}] {logFrom} ({DateTime.Now}): {message}");
                }
                switch (logLevel)
                {
                    case LogLevel.Info:
                        System.Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine($"[{logLevel}] {logFrom} ({DateTime.Now}): {message}");
                        Instance.OnLog(message, logFrom, logLevel, DateTime.Now, null);
                        break;
                    case LogLevel.Warning:
                        System.Console.ForegroundColor = ConsoleColor.Yellow;
                        System.Console.WriteLine($"[{logLevel}] {logFrom} ({DateTime.Now}): {message}");
                        Instance.OnLog(message, logFrom, logLevel, DateTime.Now, null);
                        break;
                    case LogLevel.Error:
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine($"[{logLevel}] {logFrom} ({DateTime.Now}): {message}");
                        Instance.OnLog(message, logFrom, logLevel, DateTime.Now, null);
                        break;
                    case LogLevel.Critical:
                        System.Console.ForegroundColor = ConsoleColor.Magenta;
                        if (exception != null)
                            System.Console.WriteLine($"[CRITICAL] {logFrom} ({DateTime.Now}): {message} Exception: {exception.Message}\nStack Trace: {exception.StackTrace}");
                        else
                            System.Console.WriteLine($"[CRITICAL] {logFrom} ({DateTime.Now}): {message}");
                        Instance.OnLog(message, logFrom, logLevel, DateTime.Now, exception);
                        break;
                    case LogLevel.Important:
                        System.Console.ForegroundColor = ConsoleColor.Cyan;
                        System.Console.WriteLine($"[{logLevel}] {logFrom} ({DateTime.Now}): {message}");
                        Instance.OnLog(message, logFrom, logLevel, DateTime.Now, null);
                        break;
                }
                System.Console.ResetColor();

            }
        }

        public static void LogDebug(string message, LoggingTarget logFrom) { Log(message, logFrom, LogLevel.Debug); }
        public static void LogInfo(string message, LoggingTarget logFrom) { Log(message, logFrom, LogLevel.Info); }
        public static void LogWarning(string message, LoggingTarget logFrom) { Log(message, logFrom, LogLevel.Warning); }
        public static void LogError(string message, LoggingTarget logFrom) { Log(message, logFrom, LogLevel.Error); }
        public static void LogCritical(string message, LoggingTarget logFrom, Exception exception) { Log(message, logFrom, LogLevel.Critical, exception); }

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
