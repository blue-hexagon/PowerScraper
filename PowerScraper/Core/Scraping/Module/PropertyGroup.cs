using PowerScraper.Core.Utility.OS;

namespace PowerScraper.Core.Scraping.Module;

public class PropertyGroup
{
    public string? MapName { get; }
    public ExtractionImplementation[] ExtractionImplementations { get; }

    public readonly List<PropertyItem>? PropertyItems;
    public readonly List<PropertyGroup>? PropertyGroups;

    public PropertyGroup(string? mapName, ExtractionImplementation[] extractionImplementations,
        PropertyItem[]? propertyItems,
        PropertyGroup[]? propertyGroups)
    {
        MapName = mapName;
        ExtractionImplementations = extractionImplementations;

        if (propertyItems != null)
            PropertyItems = propertyItems.ToList();
        if (propertyGroups != null)
            PropertyGroups = propertyGroups.ToList();
    }

    //TODO: Refactor and fix naming
    public List<string> GetPropertyQueryNamesFromGroup(Platform platform, ExtractionTool extractionTool)
    {
        // Get all (groupnode) items query fields
        return PropertyItems!
            .Where(propertyItem =>
                propertyItem.OperatingSystem == platform && propertyItem.ExtractionTool == extractionTool)
            .Select(propertyItem => propertyItem.PropertyQueryName)
            .ToList();
    }

    //TODO: Refactor and fix naming
    public List<PropertyItem> GetPropertiesFromGroup(Platform platform, ExtractionTool extractionTool)
    {
        // Get all (groupnode) items
        return PropertyItems!
            .Where(propertyItem =>
                propertyItem.OperatingSystem == platform && propertyItem.ExtractionTool == extractionTool)
            .Select(propertyItem => propertyItem)
            .ToList();
    }
}