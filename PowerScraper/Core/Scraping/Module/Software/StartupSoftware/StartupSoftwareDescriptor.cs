namespace PowerScraper.Core.Scraping.Module.Software.StartupSoftware  {
    public sealed class StartupSoftDescriptor : CollectorDescriptor
    {
        public StartupSoftDescriptor() : base(
            name: "Startup Software Collector",
            description: "Scan the windows registry for software which is executed at startup",
            categoryDescriptor: new SoftwareDescriptor(),
            cmdArg: "--startup-software",
            parameter: "startup-software",
            collector: new StartupSoftwareCollector()
            )
        {
            
        }
    }
}