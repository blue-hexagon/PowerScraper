using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.All
{
    public class AllDescriptor : AbstractDescriptor
    {
        public AllDescriptor() : base(
            name: "Everything",
            cmdArg: "--all",
            description: "All modules (everything)",
            scraper: null
        )
        {
        }
    }
}