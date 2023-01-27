namespace PowerScraper.Core.Scraping.Module.Hardware.Ram
{
    public sealed class RamCollector : AbstractCollector, ICollector
    {
        public Dictionary<string, string> PerformScraping()
        {
            Output.Add("Hello", "World");
            return Output;
        }
    }
}