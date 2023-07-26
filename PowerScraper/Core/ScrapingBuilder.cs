using PowerScraper.Core.Scraping;
using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Scraping.DataStructure.Collection;
using PowerScraper.Core.Utility;
using PowerScraper.Core.Utility.OS;

namespace PowerScraper.Core;

public static class ScrapingBuilder
{
    public static CollectionTree PerformScraping(List<AbstractDescriptor> collectorDescriptors)
    {
        var scrapedContent = new CollectionTree(VersionStatus.ApplicationTag);
        foreach (var descriptor in collectorDescriptors)
        {
            var result = PlatformReader.PlatformInUse switch
            {
                Platform.Windows => descriptor.Scraper!.ScrapeWindows(new CollectionTree()),
                Platform.Linux => descriptor.Scraper!.ScrapeLinux(new CollectionTree()),
                Platform.OsX => descriptor.Scraper!.ScrapeOsX(new CollectionTree()),
                Platform.FreeBsd => descriptor.Scraper!.ScrapeFreeBsd(new CollectionTree()),
                _ => throw new PlatformNotSupportedException()
            };
            scrapedContent.InsertModule(result);
        }

        return scrapedContent;
    }
}