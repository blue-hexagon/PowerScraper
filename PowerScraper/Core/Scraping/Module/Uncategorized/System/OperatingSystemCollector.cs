using System.Diagnostics;

namespace PowerScraper.Core.Scraping.Module.Uncategorized.System
{
    public sealed class OperatingSystemCollector : AbstractCollector, ICollector
    {
        public Dictionary<string, string> ScrapeWindows()
        {
            try
            {
                var psObjects = TransientShell.InvokeRawScript(@"
                Get-WmiObject Win32_OperatingSystem | Select-Object BootDevice,BuildNumber,BuildType,CodeSet,CountryCode,
                CurrentTimeZone,
                FreePhysicalMemory,FreeVirtualMemory,TotalVirtualMemorySize,TotalVisibleMemorySize,
                InstallDate,LastBootUpTime,LocalDateTime,Locale,NumberOfProcesses,NumberOfUsers,Organization,
                OSLanguage,SizeStoredInPagingFiles,SystemDrive,WindowsDirectory
                ");
                
                Output = TransientShell.ParsePsObjects(psObjects);
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
            }

            return Output;
        }

        public Dictionary<string, string> ScrapeLinux()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> ScrapeOsX()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> ScrapeFreeBsd()
        {
            throw new NotImplementedException();
        }
    }
}