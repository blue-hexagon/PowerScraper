using PowerScraper.Core.Utility.OS;
using PlatformNotSupportedException = System.PlatformNotSupportedException;

namespace PowerScraper.Core.Scraping.Module
{
    public interface ICollector
    {
        Dictionary<string, string> ScrapeWindows();
        Dictionary<string, string> ScrapeLinux();
        Dictionary<string, string> ScrapeOsX();
        Dictionary<string, string> ScrapeFreeBsd();
    }
    

}