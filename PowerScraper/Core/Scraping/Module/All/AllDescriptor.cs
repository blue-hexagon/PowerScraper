namespace PowerScraper.Core.Scraping.Module.All
{
    public class AllDescriptor : CategoryDescriptor
    {
        public AllDescriptor() : base(
            name: "Everything",
            cmdArg: "--all",
            parameter: "all",
            description: "All modules (everything)"
        )
        {
        }
    }
}