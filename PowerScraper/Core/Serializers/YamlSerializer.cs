using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace PowerScraper.Core.Serializers
{
    public class YamlSerializer : ISerializer
    {
        public string Serialize(Dictionary<string, Dictionary<string, string>> scrapedContent)
        {
            var serializer = new SerializerBuilder()
                .DisableAliases()
                .WithNamingConvention(PascalCaseNamingConvention.Instance)
                .Build();
            return serializer.Serialize(scrapedContent);
        }
    }
}