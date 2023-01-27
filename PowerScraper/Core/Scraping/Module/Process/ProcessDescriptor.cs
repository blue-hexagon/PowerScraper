namespace PowerScraper.Core.Scraping.Module.Process
{
    public class ProcessDescriptor : CategoryDescriptor
    {
        public ProcessDescriptor() : base(
            name: "Process",
            cmdArg: "--process",
            parameter: "process",
            description: "All process modules"
        )
        {
        }
    }
}