namespace PowerScraper.Core.Scraping.DataStructure
{
    public interface IScraper
    {
        List<Dictionary<string, string>> ScrapeWindows();
        List<Dictionary<string, string>> ScrapeLinux();
        List<Dictionary<string, string>> ScrapeOsX();
        List<Dictionary<string, string>> ScrapeFreeBsd();
    }
    

}