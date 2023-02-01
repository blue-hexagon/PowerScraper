using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Software.StartupSoftware  {
    public sealed class StartupSoftDescriptor : AbstractDescriptor
    {
        public StartupSoftDescriptor() : base(
            name: "Startup Software Collector",
            description: "Scan the windows registry for software which is executed at startup",
            cmdArg: "--startup-software",
            scraper: new StartupSoftwareScraper()
            )
        {
            
        }
    }
}