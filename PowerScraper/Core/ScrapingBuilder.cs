using PowerScraper.Core.Scraping.Module;
using PowerScraper.Core.Utility.OS;
using PlatformNotSupportedException = System.PlatformNotSupportedException;

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
            var result = PlatformReader.PlatformInUse switch
            {
                Platform.Windows => descriptor.Scraper.ScrapeWindows(),
                Platform.Linux => descriptor.Scraper.ScrapeLinux(),
                Platform.OsX => descriptor.Scraper.ScrapeOsX(),
                Platform.FreeBsd => descriptor.Scraper.ScrapeFreeBsd(),
                _ => throw new PlatformNotSupportedException()
            };
            scrapedContent.Add(descriptor.Name, result);
        }

        return scrapedContent;
    }
}