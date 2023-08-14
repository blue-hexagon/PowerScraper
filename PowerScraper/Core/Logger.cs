namespace PowerScraper.Core;

public enum LogLevel
{
    Debug,
    Info,
    Warning,
    Error,
    Critical
}

public static class Logger
{
    public static LogLevel LoggingLevel { get; set; }

    private static object _consoleLock = new object();

    public static void ToConsole(LogLevel logLevel, string message)
    {
        if (logLevel >= LoggingLevel)
        {
            lock (_consoleLock)
            {
                Console.ForegroundColor = logLevel switch
                {
                    LogLevel.Debug => ConsoleColor.Gray,
                    LogLevel.Info => ConsoleColor.Green,
                    LogLevel.Warning => ConsoleColor.Yellow,
                    LogLevel.Error => ConsoleColor.Red,
                    LogLevel.Critical => ConsoleColor.DarkRed,
                    _ => Console.ForegroundColor
                };

                Console.WriteLine($"[{new DateTimeOffset(DateTime.UtcNow).ToLocalTime()} - {logLevel.ToString()}]: " + message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }}