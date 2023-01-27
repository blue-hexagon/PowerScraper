namespace PowerScraper.Core.Scraping.Module
{
    public interface ICollector
    {
        Dictionary<string, string> PerformScraping();
    }
}