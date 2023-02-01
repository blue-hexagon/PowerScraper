using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Hardware.Cpu
{
    public sealed class CpuDescriptor : AbstractDescriptor
    {

        public CpuDescriptor() : base(
            name: "CPU Collector",
            description: "Gathers information about the CPU such as the number of cores and their utilization",
            cmdArg: "--cpu",
            scraper: new CpuScraper()
        )
        {
        }
    }
}