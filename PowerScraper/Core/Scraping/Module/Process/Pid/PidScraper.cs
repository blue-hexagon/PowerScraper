using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Process.Pid
{
    public sealed class PidScraper : AbstractScraper, IScraper
    {
        public List<Dictionary<string, string>> ScrapeWindows()
        {
            return new List<Dictionary<string, string>>();
        }

        public List<Dictionary<string, string>> ScrapeLinux()
        {
            throw new NotImplementedException();
        }

        public List<Dictionary<string, string>> ScrapeOsX()
        {
            throw new NotImplementedException();
        }

        public List<Dictionary<string, string>> ScrapeFreeBsd()
        {
            throw new NotImplementedException();
        }
    }
}