namespace PowerScraper.Core.Utility.OS;

public class PlatformNotSupportedException : Exception
{
    public PlatformNotSupportedException()
    {
    }

    public PlatformNotSupportedException(string message)
        : base(message)
    {
    }

    public PlatformNotSupportedException(string message, Exception inner)
        : base(message, inner)
    {
    }
}