namespace PowerScraper.Core.Scraping.Module.Hardware.Harddrive
{
    public sealed class HarddriveDescriptor : CollectorDescriptor
    {
        public HarddriveDescriptor() : base(
            name: "Harddrive Collector",
            description: "Collects information about disks and partitions as well as their usage",
            categoryDescriptor: new HardwareDescriptor(),
            cmdArg: "--harddrive",
            parameter: "harddrive",
            collector: new HarddriveCollector()
        )
        {
        }
        
    }
}