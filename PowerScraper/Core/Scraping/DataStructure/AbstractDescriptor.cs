namespace PowerScraper.Core.Scraping.DataStructure;

public abstract class AbstractDescriptor
{
    public readonly string Name;
    public readonly string CmdArg;
    public readonly string Description;
    public readonly IScraper? Scraper; // Null if Descriptor is a category/module

    protected AbstractDescriptor(string name, string cmdArg, string description, IScraper? scraper)
    {
        Name = name;
        CmdArg = cmdArg;
        Description = description;
        Scraper = scraper;
    }

    public override string ToString()
    {
        return $"{Name} : {Description}";
    }
}