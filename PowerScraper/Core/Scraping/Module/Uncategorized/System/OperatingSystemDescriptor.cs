namespace PowerScraper.Core.Scraping.Module.Uncategorized.System
{
    public sealed class OperatingSystemDescriptor : CollectorDescriptor
    {
        public OperatingSystemDescriptor() : base(
            name: "OS Information Collector",
            description: "Collect operating system information",
            categoryDescriptor: new UncategorizedDescriptor(),
            cmdArg: "--os",
            parameter: "os",
            collector: new OperatingSystemCollector()
        )
        {
        }
    }
}