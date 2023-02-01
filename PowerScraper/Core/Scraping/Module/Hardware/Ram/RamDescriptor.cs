using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Hardware.Ram
{
    public sealed class RamDescriptor : AbstractDescriptor
    {
        public RamDescriptor() : base(
            name: "RAM Collector",
            description: "Collects information about the devices RAM consumption and resources",
            cmdArg: "--ram",
            scraper: new RamScraper()
        )
        {
        }
    }
}