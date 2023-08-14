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
        var tasks = new List<Task<CollectionTree>>();

        foreach (var descriptor in collectorDescriptors)
        {
            Logger.ToConsole(LogLevel.Debug, $"Scraping: {descriptor.Name}");

            var task = PlatformReader.PlatformInUse switch
            {
                Platform.Windows => Task.Run(() => descriptor.Scraper!.ScrapeWindows(new CollectionTree())),
                Platform.Linux => Task.Run(() => descriptor.Scraper!.ScrapeLinux(new CollectionTree())),
                Platform.OsX => Task.Run(() => descriptor.Scraper!.ScrapeOsX(new CollectionTree())),
                Platform.FreeBsd => Task.Run(() => descriptor.Scraper!.ScrapeFreeBsd(new CollectionTree())),
                _ => throw new PlatformNotSupportedException()
            };
            tasks.Add(task);
        }

        Task.WaitAll(tasks.ToArray());

        foreach (var task in tasks)
        {
            scrapedContent.InsertModule(task.Result);
        }

        return scrapedContent;
    }
}