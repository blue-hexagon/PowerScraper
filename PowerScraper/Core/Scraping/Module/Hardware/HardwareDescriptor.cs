using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Hardware
{
    public class HardwareDescriptor : AbstractDescriptor
    {
        public HardwareDescriptor() : base(
            name: "Hardware",
            cmdArg: "--hardware",
            description: "All hardware modules",
            scraper:null
            )
        {
        }
    }
}