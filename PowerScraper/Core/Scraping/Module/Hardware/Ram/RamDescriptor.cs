namespace PowerScraper.Core.Scraping.Module.Hardware.Ram
{
    public sealed class RamDescriptor : CollectorDescriptor
    {
        public RamDescriptor() : base(
            name: "RAM Collector",
            description: "Collects information about the devices RAM consumption and resources",
            categoryDescriptor: new HardwareDescriptor(),
            cmdArg: "--ram",
            parameter: "ram",
            collector: new RamCollector()
        )
        {
        }
    }
}