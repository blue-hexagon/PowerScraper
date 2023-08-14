using PowerScraper.Core.Scraping.Module;
using PowerScraper.Core.Utility;
using PowerScraper.Core.Utility.OS;

namespace PowerScraper.Core.ExtractionTooling.Powershell;

public static class ScriptParser
{
    public static string GetPsCommand(PropertyGroup propertyTree, Platform platform)
    {
        var extractionImplementation = propertyTree.ExtractionImplementations.FirstOrDefault(implementation => implementation.Os == platform);

        if (extractionImplementation == null)
            throw new InvalidOperationException("No extraction implementation definition found for the specified platform.");

        var propertyItemsQueryFields = propertyTree.GetItemQueryNames(platform, ExtractionTool.PowerShell);
        var joinedFields = string.Join(", ", propertyItemsQueryFields);

        return GetPsCommandString(extractionImplementation.Command!, joinedFields);
    }

    private static string GetPsCommandString(string command, string joinedFields)
    {
        var psCommand = $"{command} | Select-Object {joinedFields}";
        Logger.ToConsole(LogLevel.Info, psCommand);
        return psCommand;
    }
}