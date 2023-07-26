using PowerScraper.Core.Utility.OS;

namespace PowerScraper.Core.Scraping.Module;

public class PropertyItemListAk : PropertyItem
{
    public readonly AutoKey AutoIncrementingKeyType;

    public PropertyItemListAk(Platform operatingSystem, string propertyDisplayName, string propertyQueryName, bool valueContainsBytes, bool cacheable, DataExtractionTool extractionTool, string? resourcePath, AutoKey autoIncrementingKeyType) : base(operatingSystem, propertyDisplayName, propertyQueryName, valueContainsBytes, cacheable, extractionTool, resourcePath)
    {
        AutoIncrementingKeyType = autoIncrementingKeyType;
    }
}
