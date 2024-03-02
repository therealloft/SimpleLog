using System.Diagnostics;
using System.Reflection;

namespace SimpleLog
{
    public static class Log
    {
        public static Level ConsoleLoggingLevel = Level.Error;
        public static Level FileLoggingLevel = Level.Information;
        public static string FilePrefix = string.Empty;
        public static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "logs");
        public static int MaxFileSize = 2000000;
        public static void Debug(string message) => InternalLog(Level.Debug, message);
        public static void Information(string message) => InternalLog(Level.Information, message);
        public static void Warning(string message) => InternalLog(Level.Warning, message);
        public static void Error(string message) => InternalLog(Level.Error, message);
        public static void Fatal(string message) => InternalLog(Level.Fatal, message);
        private static void InternalLog(Level level, string message) {
            if (level < FileLoggingLevel) return;            

            StackTrace stackTrace = new StackTrace(true);
            StackFrame? frame = stackTrace.GetFrame(2);

            MethodBase? method = frame?.GetMethod();
            Type? type = method?.DeclaringType;
            
            string? className = type != null ? type?.FullName : "Unknown Class";
            string? methodName = method?.Name;

            string fullMessage = $"{DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss.fff")} - [ {level} ] ({className}.{methodName}): {message}";

            WriteToFile(fullMessage);

            if (level >= ConsoleLoggingLevel) Console.WriteLine(fullMessage);
        }
        private static void WriteToFile(string message) {
            Directory.CreateDirectory(FilePath);
            int fileIndex = 0;
            string fileName = $"{FilePrefix}_{fileIndex}.log";
            string fullPath = Path.Combine(FilePath, fileName);
            while (File.Exists(fullPath) && new FileInfo(fullPath).Length > MaxFileSize)
            {
                fileIndex++;
                fileName = $"{FilePrefix}_{fileIndex}.log";
                fullPath = Path.Combine(FilePath, fileName);
            }
            File.AppendAllText(fullPath, message);
        }
    }
    public enum Level
    {
        Debug,
        Information,
        Warning,
        Error,
        Fatal,
    }
}