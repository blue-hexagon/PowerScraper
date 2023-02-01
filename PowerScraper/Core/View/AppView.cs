using PowerScraper.Core.Scraping;
using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Utility;

namespace PowerScraper.Core.View
{
    public static class AppView
    {
        public static void Display(SerializationFormat formatting, List<AbstractDescriptor> collectorDescriptors)
        {
            var scrapedContent = ScrapingBuilder.PerformScraping(collectorDescriptors);
            var serializedOutput = Serializer.SerializeScrapedOutput(formatting, scrapedContent);
            Console.WriteLine(serializedOutput);
            TransientShell.CloseRunspace();
        }
    }
}