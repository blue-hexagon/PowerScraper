namespace PowerScraper.Core.Scraping;

public abstract class AbstractDescriptor
{
    public readonly string Name;
    public readonly string CmdArg;
    public readonly string Parameter;
    public readonly string Description;

    protected AbstractDescriptor(string name, string cmdArg, string parameter, string description)
    {
        Name = name;
        CmdArg = cmdArg;
        Parameter = parameter;
        Description = description;
    }
}