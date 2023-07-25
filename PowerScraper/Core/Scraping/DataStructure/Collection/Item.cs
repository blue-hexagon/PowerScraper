using YamlDotNet.Serialization;

namespace PowerScraper.Core.Scraping.DataStructure.Collection;

public class Item
{
    [YamlMember(Alias = "key", Order = 1)]
    public string Key { get; set; }

    [YamlMember(Alias = "value", Order = 2)]
    public string Value { get; set; }

    public Item(string key, string value)
    {
        Key = key;
        Value = value;
    }
}