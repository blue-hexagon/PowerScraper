using Newtonsoft.Json;

namespace PowerScraper.Core.Serializers
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize(Dictionary<string, Dictionary<string, string>> scrapedContent)
        {
            return JsonConvert.SerializeObject(scrapedContent,Formatting.Indented);
        }
    }
}