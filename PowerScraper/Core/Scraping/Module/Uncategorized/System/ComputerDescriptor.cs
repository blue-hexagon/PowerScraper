namespace PowerScraper.Core.Scraping.Module.Uncategorized.System
{
    public sealed class ComputerDescriptor : CollectorDescriptor
    {
        public ComputerDescriptor() : base(
            name: "Computer Information Collector",
            description: "Collect device information specific to this computer",
            categoryDescriptor: new UncategorizedDescriptor(),
            cmdArg: "--computer",
            parameter: "computer",
            collector: new ComputerCollector()
        )
        {
        }
    }
}