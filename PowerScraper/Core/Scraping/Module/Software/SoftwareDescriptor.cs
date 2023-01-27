namespace PowerScraper.Core.Scraping.Module.Software
{
    public class SoftwareDescriptor : CategoryDescriptor
    {
        public SoftwareDescriptor() : base(
            name: "Software",
            cmdArg: "--software",
            parameter: "software",
            description: "All software modules"
            )
        {
            
        }
    }
}