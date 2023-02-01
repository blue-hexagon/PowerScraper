using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Network.Interface
{
    public sealed  class InterfaceDescriptor :AbstractDescriptor
    {
        public InterfaceDescriptor (): base(
            name: "Network Interface Collector",
            description: "Collects information about the devices network adapters, assigned IP addresses, MAC addresses and more",
            cmdArg: "--interface",
            scraper: new InterfaceScraper()
            )
        {
            
        }
    }
}