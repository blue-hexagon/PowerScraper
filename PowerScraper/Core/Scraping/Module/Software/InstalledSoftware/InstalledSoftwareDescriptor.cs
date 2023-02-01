using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Software.InstalledSoftware {
    public sealed class InstalledSoftwareDescriptor : AbstractDescriptor
    {
        public InstalledSoftwareDescriptor() : base(
            name: "Installed Software Collector",
            description: "Scan the windows registry for installed software",
            cmdArg: "--installed-software",
            scraper: new InstalledSoftwareScraper()
            
            )
        {
            
        }
    }
}