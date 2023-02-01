using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Network
{
    public class NetworkDescriptor : AbstractDescriptor
    {
        public NetworkDescriptor() : base(
            name: "Network",
            cmdArg: "--network",
            description: "All network modules",
            scraper:null
        )
        {
        }
    }
}