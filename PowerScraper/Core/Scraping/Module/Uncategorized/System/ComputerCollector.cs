using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PowerScraper.Core.Scraping.Module.Uncategorized.System
{
    public sealed class ComputerCollector : AbstractCollector, ICollector
    {
        public Dictionary<string, string> PerformScraping()
        {
            try
            {
                var psObjects = TransientShell.InvokeRawScript(@"
                Get-WmiObject Win32_ComputerSystem | Select-Object DNSHostName,Domain,DomainRole,DaylightInEffect,
                CurrentTimeZone,AdminPasswordStatus,HypervisorPresent,InfraredSupported,
                Manufacturer,Model,Name,PartOfDomain,PrimaryOwnerName,SystemFamily,SystemSKUNumber,SystemType,
                TotalPhysicalMemory,UserName
                ");
                Output = TransientShell.ParsePsObjects(psObjects);
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
            }

            return Output;
        }
    }
}