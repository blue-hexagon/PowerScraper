using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.PowerShell.Commands;
using PowerScraper.Core.Scraping.DataStructure.Collection;
using PowerScraper.Core.Scraping.Module;
using PowerScraper.Core.Utility;
using Platform = PowerScraper.Core.Utility.OS.Platform;

namespace PowerScraper.Core;

public static class TransientShell
{
    private static PowerShell? _ps;
    private static Runspace? _rs;

    public static void InitializeRunspace()
    {
        var iss = InitialSessionState.Create();
        iss.Commands.Add(new SessionStateCmdletEntry("Select-Object", typeof(SelectObjectCommand), null));
        iss.ImportPSModule("CimCmdlets");
        iss.LanguageMode = PSLanguageMode.FullLanguage;
        _rs = RunspaceFactory.CreateRunspace(iss);
        _rs.Open();

        _ps = PowerShell.Create();

        _ps.Runspace = _rs;
    }

    public static void CloseRunspace()
    {
        _rs!.Close();
        _ps!.Dispose();
    }

    public static Collection<PSObject> InvokeRawScript(string command)
    {
        _ps!.AddScript(command);
        var content = _ps.Invoke();
        return content;
    }

    public static void RunPowershellExtraction(
        PropertyGroup propertyTree,
        CollectionTree collectionNodeInstance,
        Platform platform,
        string? mapName)
    {
        if (mapName != null)
            collectionNodeInstance = collectionNodeInstance.InsertModule(new CollectionTree(mapName));

        var psCommand = GetPsCommand(propertyTree, platform);
        var psObjects = InvokeRawScript(psCommand);

        var groups = propertyTree.PropertyGroups;
        var groupItems = propertyTree.GetItems(platform, ExtractionTool.PowerShell);

        ParsePsObjectsAndAddItemsToNode(psObjects, groupItems, collectionNodeInstance);

        if (groups == null) return;
        foreach (var group in groups)
        {
            RunPowershellExtraction(group, collectionNodeInstance, platform, group.MapName);
        }
    }

    private static string GetPsCommand(PropertyGroup propertyTree, Platform platform)
    {
        var extractionImplementation = propertyTree.ExtractionImplementations
            .First(implementation => implementation.Os == platform);

        var propertyItemsQueryFields = propertyTree.GetItemQueryNames(platform, ExtractionTool.PowerShell);
        var joinedFields = string.Join(", ", propertyItemsQueryFields);

        var psCommand = @$"{extractionImplementation.Command} | Select-Object {joinedFields}";
        Logger.ToConsole(LogLevel.Info, psCommand);
        return psCommand;
    }

    // TODO: Refactor naming
    private static void ParsePsObjectsAndAddItemsToNode(
        Collection<PSObject> psObjects,
        List<PropertyItem> propertyObjects,
        CollectionTree collectionNodeInstance)
    {
        foreach (var member in psObjects)
        {
            if (member.Properties.Count() != propertyObjects.Count)
                throw new Exception("The number of properties in the PSObject should be equal to the number of propertyObjects");

            var zipGroup = member.Properties
                .Zip(propertyObjects, (psProp, propObj) => new { Ps = psProp, Obj = propObj });

            foreach (var item in zipGroup)
            {
                string value;
                if (item.Ps.Value == null)
                    continue;
                if (item.Obj.ValueContainsBytes)
                {
                    try
                    {
                        value = UnitConversion.ConvertBytesToGreatestUnit(Convert.ToInt64(item.Ps.Value));
                        collectionNodeInstance.AddItem(item.Obj.PropertyDisplayName, value);
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("A scraper-file (*Scraper.cs) has a wrong boolean value for the field " +
                                          "ValueContainsBytes on a PropertyObject which caused the program to try to " +
                                          "convert a string to an Int64.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(e);
                        Environment.Exit(ExitStatus.Error);
                    }
                }
                else
                {
                    value = item.Ps.Value.ToString()!;
                    collectionNodeInstance.AddItem(item.Obj.PropertyDisplayName, value);
                }
            }
        }
    }
}