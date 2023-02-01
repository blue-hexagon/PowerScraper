using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Network.Ssid
{
    public sealed class SsidDescriptor :AbstractDescriptor
    {
        public SsidDescriptor() : base(
            name: "SSID Collector",
            description: "Collects saved SSID and their associated passwords if such exists",
            cmdArg: "--ssid",
            scraper: new SsidScraper()
            )
        {
            
        }
        
    }
}