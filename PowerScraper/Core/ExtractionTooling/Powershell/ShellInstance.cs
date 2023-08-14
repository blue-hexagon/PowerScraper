using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.PowerShell.Commands;
using PowerScraper.Core.Scraping.DataStructure.Collection;
using PowerScraper.Core.Scraping.Module;
using PowerScraper.Core.Utility;
using Platform = PowerScraper.Core.Utility.OS.Platform;

namespace PowerScraper.Core.ExtractionTooling.Powershell;

public static class ShellInstance
{
    private static List<PowerShell>? PowerShells { get; set; }
    private static List<Runspace>? Runspaces { get; set; }
    private static int _currentPowerShellIndex;
    private static readonly string[] CmdletEntries = { "Select-Object" };
    private static readonly string[] PsModules = { "CimCmdlets" };

    public static void InitializeRunspace()
    {
        var iss = InitialSessionState.Create();

        foreach (var cmdletEntry in CmdletEntries)
            iss.Commands.Add(new SessionStateCmdletEntry(cmdletEntry, typeof(SelectObjectCommand), null));

        foreach (var psModule in PsModules)
            iss.ImportPSModule(psModule);

        iss.LanguageMode = PSLanguageMode.FullLanguage;
        Runspaces = new List<Runspace>();
        PowerShells = new List<PowerShell>();

        for (var i = 0; i < ThreadingOptions.GetCoreCount(); i++)
        {
            var rs = RunspaceFactory.CreateRunspace(iss);
            rs.Open();
            Runspaces.Add(rs);

            var ps = PowerShell.Create();
            ps.Runspace = rs;
            PowerShells.Add(ps);

            Logger.ToConsole(LogLevel.Debug, $"Created PowerShell with initialized runspace {i + 1}/{ThreadingOptions.GetCoreCount()}.");
        }
    }


    public static void RunPowershellExtraction(PropertyGroup propertyTree, CollectionTree collectionNodeInstance, Platform platform, string? mapName)
    {
        if (mapName != null)
            collectionNodeInstance = collectionNodeInstance.InsertModule(new CollectionTree(mapName));

        var psCommand = ScriptParser.GetPsCommand(propertyTree, platform);
        var psObjects = InvokePsScript(psCommand);

        var groups = propertyTree.PropertyGroups;
        var items = propertyTree.GetItems(platform, ExtractionTool.PowerShell);

        ObjectParser.ParsePsObjectsAndAddItemsToNode(psObjects, items, collectionNodeInstance);

        if (groups == null)
            return;

        foreach (var group in groups)
            RunPowershellExtraction(group, collectionNodeInstance, platform, group.MapName);
    }

    public static Collection<PSObject> InvokePsScript(string command)
    {
        var index = Interlocked.Increment(ref _currentPowerShellIndex) % PowerShells!.Count;
        var ps = PowerShells[index];

        ps.Commands.Clear();
        ps.AddScript(command);
        var psObjects = ps.Invoke();

        return psObjects;
    }

    public static void CloseRunspace()
    {
        foreach (var ps in PowerShells!)
        {
            ps.Dispose();
        }

        foreach (var rs in Runspaces!)
        {
            rs.Close();
            rs.Dispose();
        }
    }
}