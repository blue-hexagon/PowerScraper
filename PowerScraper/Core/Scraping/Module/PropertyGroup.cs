using PowerScraper.Core.Utility.OS;

namespace PowerScraper.Core.Scraping.Module;

public class PropertyGroup
{
    private readonly List<PropertyItem> _propertyObjects;
    public string Command { get; }
    public string[] Args { get; }

    public PropertyGroup(string command, string[] args, PropertyItem[] propertyObjects)
    {
        _propertyObjects = propertyObjects.ToList();
        Command = command;
        Args = args;
    }

    public List<string> GetPropertyQueryNamesFromGroup(Platform platform, DataExtractionTool extractionTool)
    {
        return _propertyObjects
            .Where(propertyObject => propertyObject.OperatingSystem == platform &&
                                     propertyObject.ExtractionTool == extractionTool)
            .Select(propertyObject => propertyObject.PropertyQueryName).ToList();
    }

    public List<PropertyItem> GetPropertiesFromGroup(Platform platform, DataExtractionTool extractionTool)
    {
        return _propertyObjects.Where(propertyObject =>
                propertyObject.OperatingSystem == platform && propertyObject.ExtractionTool == extractionTool)
            .Select(p => p)
            .ToList();
    }
}