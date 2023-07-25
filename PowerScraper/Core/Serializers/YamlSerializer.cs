using PowerScraper.Core.Scraping.DataStructure.Collection;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace PowerScraper.Core.Serializers
{
    public class YamlSerializer : ISerializer
    {
        public string Serialize(CollectionTree scrapedContent)
        {
            var serializer = new SerializerBuilder()
                .DisableAliases()
                .WithNamingConvention(PascalCaseNamingConvention.Instance)
                .Build();
            return serializer.Serialize(scrapedContent);
        }
    }
}