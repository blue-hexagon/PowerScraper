namespace PowerScraper.Core.Utility.OS;

public static class ExitMessage
{
    public static void Write(string message, Exception? exceptionTrace = null)
    {
        if (exceptionTrace != null){
            Console.WriteLine(exceptionTrace);
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
        Environment.Exit(ExitStatus.Error);
    } 
}