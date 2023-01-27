using System;
using System.Collections.Generic;
using PowerScraper.Core.Scraping.Module;
using PowerScraper.Core.Utility;

namespace PowerScraper.Core.View
{
    public static class AppView
    {
        public static void Display(OutputFormat formatting, List<CollectorDescriptor> collectorDescriptors)
        {
            var scrapedContent = ScrapingBuilder.PerformScraping(collectorDescriptors);
            var serializedOutput = Serializer.SerializeScrapedOutput(formatting, scrapedContent);
            Console.WriteLine(serializedOutput);
            TransientShell.CloseRunspace();
        }
    }
}