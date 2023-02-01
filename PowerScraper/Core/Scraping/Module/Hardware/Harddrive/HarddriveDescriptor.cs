using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Hardware.Harddrive
{
    public sealed class HarddriveDescriptor : AbstractDescriptor
    {
        public HarddriveDescriptor() : base(
            name: "Harddrive Collector",
            description: "Collects information about disks and partitions as well as their usage",
            cmdArg: "--harddrive",
            scraper: new HarddriveScraper()
        )
        {
        }
        
    }
}