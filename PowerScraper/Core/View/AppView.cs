using PowerScraper.Core.Scraping.Module;
using PowerScraper.Core.Utility;

namespace PowerScraper.Core.View
{
    public static class AppView
    {
        public static void Display(SerializationFormat formatting, List<CollectorDescriptor> collectorDescriptors)
        {
            var scrapedContent = ScrapingBuilder.PerformScraping(collectorDescriptors);
            var serializedOutput = Serializer.SerializeScrapedOutput(formatting, scrapedContent);
            Console.WriteLine(serializedOutput);
            TransientShell.CloseRunspace();
        }
    }
}