using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Software
{
    public class SoftwareDescriptor : AbstractDescriptor
    {
        public SoftwareDescriptor() : base(
            name: "Software",
            cmdArg: "--software",
            description: "All software modules",
            scraper:null
            )
        {
            
        }
    }
}