using System.ComponentModel;
using PowerScraper.Core.Serializers;
using PowerScraper.Core.Utility;

namespace PowerScraper.Core;

public static class Serializer
{
    public static string SerializeScrapedOutput(OutputFormat formatting,
        Dictionary<string, Dictionary<string, string>> scrapedContent)
    {
        var serializedOutput = formatting switch
        {
            OutputFormat.Csv => new CsvSerializer().Serialize(scrapedContent),
            OutputFormat.Ini => new IniSerializer().Serialize(scrapedContent),
            OutputFormat.Xml => new XmlSerializer().Serialize(scrapedContent),
            OutputFormat.Json => new JsonSerializer().Serialize(scrapedContent),
            OutputFormat.Yaml => new YamlSerializer().Serialize(scrapedContent),
            OutputFormat.Toml => new TomlSerializer().Serialize(scrapedContent),
            _ => throw new InvalidEnumArgumentException()
        };

        return serializedOutput;
    }
}