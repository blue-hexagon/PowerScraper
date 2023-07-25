using PowerScraper.Core.Scraping.DataStructure.Collection;

namespace PowerScraper.Core.Serializers
{
    public interface ISerializer
    {
        string Serialize(CollectionTree scrapedContent);
    }
}