using System.Collections.Generic;

namespace PowerScraper.Core.Scraping.Module
{
    public abstract class AbstractCollector
    {
        protected Dictionary<string, string> Output { get; set; } = new();
    }

  
}