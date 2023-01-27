using System.Collections.Generic;

namespace PowerScraper.Core.Scraping.Module.Software.InstalledSoftware
{
    public sealed class InstalledSoftwareCollector : AbstractCollector, ICollector
    {
        public Dictionary<string, string> PerformScraping()
        {
            Output.Add("Hello", "World");
            return Output;
        }
    }
}