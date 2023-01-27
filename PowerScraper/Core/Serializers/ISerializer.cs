using System.Collections.Generic;

namespace PowerScraper.Core.Serializers
{
    public interface ISerializer
    {
        string Serialize(Dictionary<string, Dictionary<string, string>> scrapedContent);
    }
}