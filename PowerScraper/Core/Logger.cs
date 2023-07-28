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
                switch (logLevel)
                {
                    case LogLevel.Debug:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case LogLevel.Info:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case LogLevel.Warning:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case LogLevel.Error:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case LogLevel.Critical:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                }

                Console.WriteLine($"[{new DateTimeOffset(DateTime.UtcNow).ToLocalTime()} - {logLevel.ToString()}]: " + message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }}