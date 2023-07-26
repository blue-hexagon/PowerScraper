namespace PowerScraper.Core.Scraping.Module;

public class PropertyMap
{
    public readonly string PropertyDisplayName;
    private readonly List<PropertyItem> _propertyItems;

    public PropertyMap(string propertyDisplayName, List<PropertyItem> propertyItems)
    {
        PropertyDisplayName = propertyDisplayName;
        _propertyItems = propertyItems;
    }
}