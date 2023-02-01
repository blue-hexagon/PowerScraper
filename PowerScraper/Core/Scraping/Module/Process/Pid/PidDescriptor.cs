using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Process.Pid
{
    public sealed class PidDescriptor: AbstractDescriptor
    {
        public PidDescriptor() : base(
            name: "Process ID Collector",
            description: "Collects all process names and IDs",
            cmdArg: "--pid",
            scraper: new PidScraper()
            )
        {
            
        }
    }
}