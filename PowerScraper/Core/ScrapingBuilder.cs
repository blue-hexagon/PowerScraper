using PowerScraper.Core.Scraping;
using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Utility.OS;

namespace PowerScraper.Core;

public static class ScrapingBuilder
{
    /** This class handles piecing the scraped content together */
    public static Dictionary<string, Dictionary<string, string>> PerformScraping(
        List<AbstractDescriptor> collectorDescriptors)
    {
        var scrapedContent = new CollectionNode();
        foreach (var descriptor in collectorDescriptors)
        {
            var result = PlatformReader.PlatformInUse switch
            {
                Platform.Windows => descriptor.Scraper!.ScrapeWindows(),
                Platform.Linux => descriptor.Scraper!.ScrapeLinux(),
                Platform.OsX => descriptor.Scraper!.ScrapeOsX(),
                Platform.FreeBsd => descriptor.Scraper!.ScrapeFreeBsd(),
                _ => throw new PlatformNotSupportedException()
            };
            scrapedContent.Add(descriptor.Name, result);
        }

        return scrapedContent;
    }
}