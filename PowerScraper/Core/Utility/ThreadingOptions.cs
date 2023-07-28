namespace PowerScraper.Core.Utility;

public class ThreadingOptions
{
    private static readonly int MaxCores = Environment.ProcessorCount;
    private static int _coresAllocated;


    public static void SetCores(CoreUtilisation coreUtilisation)
    {
        switch (coreUtilisation)
        {
            case CoreUtilisation.Min:
                _coresAllocated = 1;
                break;
            case CoreUtilisation.Medium:
                _coresAllocated = MaxCores / 2;
                break;
            case CoreUtilisation.Max:
                _coresAllocated = MaxCores;
                break;
            default:
                throw new ArgumentException();
        }

        Logger.ToConsole(LogLevel.Debug, $"Core utilization set to: {GetCoreCount()}/{MaxCores} cores.");
    }

    public static int GetCoreCount()
    {
        return _coresAllocated;
    }
}

public enum CoreUtilisation
{
    Min,
    Medium,
    Max
}