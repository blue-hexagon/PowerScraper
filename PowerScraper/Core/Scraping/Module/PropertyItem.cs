using PowerScraper.Core.Utility.OS;
namespace PowerScraper.Core.Scraping.Module;

public class PropertyItem
{
    public readonly Platform OperatingSystem;
    public readonly string PropertyDisplayName;
    public readonly string PropertyQueryName;
    public readonly bool ValueContainsBytes;
    public readonly bool Cacheable;
    public readonly ExtractionTool ExtractionTool;
    public readonly string? ResourcePath;

    public PropertyItem(Platform operatingSystem, string propertyDisplayName, string propertyQueryName,
        bool valueContainsBytes, bool cacheable, ExtractionTool extractionTool, string? resourcePath)
    {
        OperatingSystem = operatingSystem;
        PropertyDisplayName = propertyDisplayName;
        PropertyQueryName = propertyQueryName;
        ValueContainsBytes = valueContainsBytes;
        Cacheable = cacheable;
        ExtractionTool = extractionTool;
        ResourcePath = resourcePath;
    }
}





