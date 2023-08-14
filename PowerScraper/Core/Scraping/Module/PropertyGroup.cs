using PowerScraper.Core.Utility.OS;

namespace PowerScraper.Core.Scraping.Module;

public class PropertyGroup
{
    public string? MapName { get; }
    public ExtractionImplementation[] ExtractionImplementations { get; }

    public readonly List<PropertyItem>? PropertyItems;
    public readonly PropertyItemSequence? PropertyItemSequence;
    public readonly List<PropertyGroup>? PropertyGroups;

    public PropertyGroup(string? mapName, ExtractionImplementation[] extractionImplementations,
        List<PropertyItem>? propertyItems,
        PropertyItemSequence? propertyItemSequence,
        List<PropertyGroup>? propertyGroups)
    {
        MapName = mapName;
        ExtractionImplementations = extractionImplementations;

        PropertyItems = propertyItems;
        PropertyItemSequence = propertyItemSequence;
        PropertyGroups = propertyGroups;
    }

    //TODO: Refactor and fix naming
    public List<string> GetItemQueryNames(Platform platform, ExtractionTool extractionTool)
    {
        // Get all (groupnode) items query fields
        return PropertyItems!
            .Where(propertyItem =>
                propertyItem.OperatingSystem == platform && propertyItem.ExtractionTool == extractionTool)
            .Select(propertyItem => propertyItem.PropertyQueryName)
            .ToList();
    }

    //TODO: Refactor and fix naming
    public List<PropertyItem> GetItems(Platform platform, ExtractionTool extractionTool)
    {
        // Get all (groupnode) items
        return PropertyItems!
            .Where(propertyItem =>
                propertyItem.OperatingSystem == platform && propertyItem.ExtractionTool == extractionTool)
            .Select(propertyItem => propertyItem)
            .ToList();
    }
}