using Newtonsoft.Json;
using PowerScraper.Core.Scraping.DataStructure.Collection;

namespace PowerScraper.Core.Serializers
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize(CollectionTree scrapedContent)
        {
            return JsonConvert.SerializeObject(scrapedContent, Formatting.Indented);
        }
    }
}