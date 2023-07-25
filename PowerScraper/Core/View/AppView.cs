using PowerScraper.Core.Scraping;
using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Utility;

namespace PowerScraper.Core.View
{
    public static class AppView
    {
        public static string Serialize(SerializationFormat formatting, List<AbstractDescriptor> collectorDescriptors)
        {
            var scrapedContent = ScrapingBuilder.PerformScraping(collectorDescriptors);
            var serializedOutput = Serializer.SerializeScrapedOutput(formatting, scrapedContent);
            TransientShell.CloseRunspace();
            return serializedOutput;
        }

        public static void Display(string serializedOutput)
        {
            Console.WriteLine(serializedOutput);
        }
    }
}