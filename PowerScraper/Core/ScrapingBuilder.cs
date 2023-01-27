using System.Collections.Generic;
using PowerScraper.Core.Scraping.Module;

namespace PowerScraper.Core;

public static class ScrapingBuilder
{
    /** This class handles piecing the scraped content together */
    public static Dictionary<string, Dictionary<string, string>> PerformScraping(
        List<CollectorDescriptor> collectorDescriptors)
    {
        var scrapedContent = new Dictionary<string, Dictionary<string, string>>();
        foreach (var descriptor in collectorDescriptors)
        {
            var result = descriptor.Scraper.PerformScraping();
            scrapedContent.Add(descriptor.Name, result);
        }

        return scrapedContent;
    }
}