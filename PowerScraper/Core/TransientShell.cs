using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.Management.Infrastructure;
using Microsoft.PowerShell.Commands;

namespace PowerScraper.Core;

public static class TransientShell
{
    private static PowerShell _ps;
    private static Dictionary<string, string> Output { get; set; } = new();
    private static Runspace _rs;

    public static void InitializeRunspace()
    {
        var iss = InitialSessionState.Create();
        iss.Commands.Add(new SessionStateCmdletEntry("Get-Command", typeof(GetCommandCommand), null));
        iss.Commands.Add(new SessionStateCmdletEntry("Import-Module", typeof(ImportModuleCommand), null));
        iss.Commands.Add(new SessionStateCmdletEntry("Get-WmiObject", typeof(CimClass), null));
        iss.Commands.Add(new SessionStateCmdletEntry("Select-Object", typeof(SelectObjectCommand), null));
        iss.LanguageMode = PSLanguageMode.ConstrainedLanguage;
        /* Set execution policy if needed */
        // var execPolProp = iss.GetType().GetProperty(@"ExecutionPolicy");
        // if (execPolProp != null && execPolProp.CanWrite){
        // execPolProp.SetValue(iss, ExecutionPolicy.RemoteSigned, null);
        // }
        _rs = RunspaceFactory.CreateRunspace(iss);
        _rs.Open();
        _ps = PowerShell.Create();
        _ps.Runspace = _rs;
    }

    public static Collection<PSObject> InvokeRawScript(string command)
    {
        _ps.AddScript(command);
        return _ps.Invoke();
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
                Output.Add(entry.Name, entry.Value.ToString());
            }
        }

        return Output;
    }

    public static void CloseRunspace()
    {
        _rs.Close();
        _ps.Dispose();
    }
}