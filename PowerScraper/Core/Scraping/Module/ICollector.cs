using System.Collections.Generic;

namespace PowerScraper.Core.Scraping.Module
{
    public interface ICollector
    {
        Dictionary<string, string> PerformScraping();
    }
}