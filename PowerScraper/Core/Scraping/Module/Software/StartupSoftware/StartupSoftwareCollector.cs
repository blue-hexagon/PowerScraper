using System.Collections.Generic;

namespace PowerScraper.Core.Scraping.Module.Software.StartupSoftware
{
    public sealed class StartupSoftwareCollector : AbstractCollector, ICollector
    {
        public Dictionary<string, string> PerformScraping()
        {
            Output.Add("Hello", "World");
            return Output;
        }
    }
}