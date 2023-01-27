namespace PowerScraper.Core.Scraping.Module.Software.InstalledSoftware {
    public sealed class InstalledSoftwareDescriptor : CollectorDescriptor
    {
        public InstalledSoftwareDescriptor() : base(
            name: "Installed Software Collector",
            description: "Scan the windows registry for installed software",
            categoryDescriptor: new SoftwareDescriptor(),
            cmdArg: "--installed-software",
            parameter: "installed-software",
            collector: new InstalledSoftwareCollector()
            
            )
        {
            
        }
    }
}