using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.PowerShell.Commands;

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

    public static Collection<PSObject> InvokeRawScript(string command)
    {
        _ps!.AddScript(command);
        var content = _ps.Invoke();
        return content;
    }

    // public static Dictionary<string, string> ParsePsObjects(Collection<PSObject> psObjects)
    // {
    //     var output = new Dictionary<string, string>();
    //     foreach (var member in psObjects)
    //     {
    //         foreach (var entry in member.Properties)
    //         {
    //             if (entry.Value == null)
    //                 continue;
    //             output.Add(entry.Name, entry.Value.ToString()!);
    //         }
    //     }
    //
    //     return output;
    // }   
    public static List<Dictionary<string, string>> ParsePsObjects(Collection<PSObject> psObjects)
    {
        var output = new List<Dictionary<string, string>>();
        var psObj = new Dictionary<string, string>();
        foreach (var member in psObjects)
        {
            foreach (var entry in member.Properties)
            {
                if (entry.Value == null)
                    continue;
                psObj.Add(entry.Name, entry.Value.ToString()!);
                // try
                // {
                // }
                // catch (ArgumentException e)
                // {
                // output.Add(psObj);
                // psObj = new Dictionary<string, string>();
                // }
            }
        }

        output.Add(psObj);


        return output;
    }

    public static void CloseRunspace()
    {
        _rs!.Close();
        _ps!.Dispose();
    }
}