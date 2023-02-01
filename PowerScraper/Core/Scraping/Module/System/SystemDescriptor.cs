using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.System
{
    public class SystemDescriptor : AbstractDescriptor
    {
        public SystemDescriptor() : base(
            name: "System",
            cmdArg: "--system",
            description: "All system modules",
            scraper:null
        )
        {
        }
    }
}