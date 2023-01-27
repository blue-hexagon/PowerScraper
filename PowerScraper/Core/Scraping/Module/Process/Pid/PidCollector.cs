namespace PowerScraper.Core.Scraping.Module.Process.Pid
{
    public sealed class PidCollector : AbstractCollector, ICollector
    {
        public Dictionary<string, string> PerformScraping()
        {
            Output.Add("Hello", "World");
            return Output;
        }
    }
}