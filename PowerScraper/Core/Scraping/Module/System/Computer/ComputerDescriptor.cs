using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.System.Computer
{
    public sealed class ComputerDescriptor : AbstractDescriptor
    {
        public ComputerDescriptor() : base(
            name: "Computer Information Collector",
            description: "Collect device information specific to this computer",
            cmdArg: "--computer",
            scraper: new ComputerScraper()
        )
        {
        }
    }
}