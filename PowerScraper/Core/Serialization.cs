using System.ComponentModel;
using PowerScraper.Core.Serializers;
using PowerScraper.Core.Utility;

namespace PowerScraper.Core;

public static class Serializer
{
    public static string SerializeScrapedOutput(SerializationFormat formatting,
        Dictionary<string, Dictionary<string, string>> scrapedContent)
    {
        var serializedOutput = formatting switch
        {
            SerializationFormat.Csv => new CsvSerializer().Serialize(scrapedContent),
            SerializationFormat.Ini => new IniSerializer().Serialize(scrapedContent),
            SerializationFormat.Xml => new XmlSerializer().Serialize(scrapedContent),
            SerializationFormat.Json => new JsonSerializer().Serialize(scrapedContent),
            SerializationFormat.Yaml => new YamlSerializer().Serialize(scrapedContent),
            SerializationFormat.Toml => new TomlSerializer().Serialize(scrapedContent),
            _ => throw new InvalidEnumArgumentException()
        };

        return serializedOutput;
    }
}