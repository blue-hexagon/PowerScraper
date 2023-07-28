using PowerScraper.Core.Utility.OS;

namespace PowerScraper.Core.Scraping.Module;

public enum ExtractionTool
{
    PowerShell,
    Bash,
    Subprocess,
}

public class ExtractionImplementation
{
    public string? Command { get; }
    public Platform Os { get; }
    public ExtractionTool Tool { get; }

    public ExtractionImplementation(string? command, Platform os, ExtractionTool tool)
    {
        Command = command;
        Os = os;
        Tool = tool;
    }
}