namespace PowerScraper.Tonsil.Error;

public class LexingException : Exception
{
    public LexingException()
    {
    }

    public LexingException(string message) : base(message)
    {
    }

    public LexingException(string message, Exception innerException) : base(message, innerException)
    {
    }
}