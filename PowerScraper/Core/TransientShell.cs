using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.Management.Infrastructure;
using Microsoft.PowerShell.Commands;
using Microsoft.PowerShell.Cim;


namespace PowerScraper.Core;

public static class TransientShell
{
    private static PowerShell? _ps;
    private static Dictionary<string, string> Output { get; set; } = new();
    private static Runspace? _rs;
    private const bool UseIssRunspace = true;

    public static void InitializeRunspace()
    {
        if (UseIssRunspace)
        {
            var iss = InitialSessionState.Create();
            iss.Commands.Add(new SessionStateCmdletEntry("Select-Object", typeof(SelectObjectCommand), null));
            iss.ImportPSModule("CimCmdlets");
            iss.LanguageMode = PSLanguageMode.FullLanguage;
            _rs = RunspaceFactory.CreateRunspace(iss);
            _rs.Open();
        }

        _ps = PowerShell.Create();

        if (UseIssRunspace)
            _ps.Runspace = _rs;
    }

    public static Collection<PSObject> InvokeRawScript(string command)
    {
        _ps!.AddScript(command);
        var content = _ps.Invoke();
        return content;
    }

    public static Dictionary<string, string> ParsePsObjects(Collection<PSObject> psObjects)
    {
        Output = new Dictionary<string, string>();
        foreach (var member in psObjects)
        {
            foreach (var entry in member.Properties)
            {
                if (entry.Value == null)
                    continue;
                Output.Add(entry.Name, entry.Value.ToString()!);
            }
        }

        return Output;
    }

    public static void CloseRunspace()
    {
        if (!UseIssRunspace)
            return;
        _rs!.Close();
        _ps!.Dispose();
    }
}