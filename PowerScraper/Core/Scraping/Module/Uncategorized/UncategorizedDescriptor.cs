using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Uncategorized
{
    public class UncategorizedDescriptor : AbstractDescriptor
    {
        public UncategorizedDescriptor() : base(
            name: "Uncategorized",
            cmdArg: "--uncategorized",
            description: "All uncategorized modules",
            scraper: null
        )
        {
        }
    }
}