using System.Collections.Generic;

namespace PowerScraper.Core.Scraping.Module.Network.Ssid
{
    public sealed class SsidCollector : AbstractCollector, ICollector
    {
        public Dictionary<string, string> PerformScraping()
        {
            Output.Add("Hello", "World");
            return Output;
        }
    }
}