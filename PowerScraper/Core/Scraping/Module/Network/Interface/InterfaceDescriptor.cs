namespace PowerScraper.Core.Scraping.Module.Network.Interface
{
    public sealed  class InterfaceDescriptor :CollectorDescriptor
    {
        public InterfaceDescriptor (): base(
            name: "Network Interface Collector",
            description: "Collects information about the devices network adapters, assigned IP addresses, MAC addresses and more",
            categoryDescriptor: new NetworkDescriptor(),
            cmdArg: "--interface",
            parameter: "interface",
            collector: new InterfaceCollector()
            )
        {
            
        }
    }
}