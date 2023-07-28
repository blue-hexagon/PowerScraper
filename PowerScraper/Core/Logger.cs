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
    public static string GetTimestamp(DateTime value)
    {
        return value.ToString("yyyyMMddHHmmssffff");
    }
    public static LogLevel LoggingLevel { get; set; }

    public static void ToConsole(LogLevel logLevel, string message)
    {
        
        if (logLevel >= LoggingLevel)
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
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}