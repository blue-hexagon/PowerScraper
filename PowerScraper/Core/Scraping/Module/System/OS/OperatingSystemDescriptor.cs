using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.System.OS
{
    public sealed class OperatingSystemDescriptor : AbstractDescriptor
    {
        public OperatingSystemDescriptor() : base(
            name: "OS Information Collector",
            description: "Collect operating system information",
            cmdArg: "--os",
            scraper: new OperatingSystemScraper()
        )
        {
        }
    }
}