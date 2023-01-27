namespace PowerScraper.Core.Scraping.Module.Process.Pid
{
    public sealed class PidDescriptor: CollectorDescriptor
    {
        public PidDescriptor() : base(
            name: "Process ID Collector",
            description: "Collects all process names and IDs",
            categoryDescriptor: new ProcessDescriptor(),
            cmdArg: "--pid",
            parameter: "pid",
            collector: new PidCollector()
            )
        {
            
        }
    }
}