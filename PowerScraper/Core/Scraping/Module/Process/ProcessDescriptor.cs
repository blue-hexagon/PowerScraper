using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Process
{
    public class ProcessDescriptor : AbstractDescriptor
    {
        public ProcessDescriptor() : base(
            name: "Process",
            cmdArg: "--process",
            description: "All process modules",
            scraper:null
        )
        {
        }
    }
}