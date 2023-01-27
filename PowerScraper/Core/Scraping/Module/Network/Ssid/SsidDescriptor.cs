namespace PowerScraper.Core.Scraping.Module.Network.Ssid
{
    public sealed class SsidDescriptor :CollectorDescriptor
    {
        public SsidDescriptor() : base(
            name: "SSID Collector",
            description: "Collects saved SSID and their associated passwords if such exists",
            categoryDescriptor: new NetworkDescriptor(),
            cmdArg: "--ssid",
            parameter: "ssid",
            collector: new SsidCollector()
            )
        {
            
        }
        
    }
}