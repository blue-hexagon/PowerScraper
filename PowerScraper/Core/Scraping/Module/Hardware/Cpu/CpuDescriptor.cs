namespace PowerScraper.Core.Scraping.Module.Hardware.Cpu
{
    public sealed class CpuDescriptor : CollectorDescriptor
    {

        public CpuDescriptor() : base(
            name: "CPU Collector",
            description: "Gathers information about the CPU such as the number of cores and their utilization",
            categoryDescriptor: new HardwareDescriptor(),
            cmdArg: "--cpu",
            parameter: "cpu",
            collector: new CpuCollector()
        )
        {
        }
    }
}