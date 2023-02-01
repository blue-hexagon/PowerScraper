using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.System.OS
{
    public sealed class OperatingSystemScraper : AbstractScraper, IScraper
    {
        public List<Dictionary<string, string>> ScrapeWindows()
        {
            var psObjects = TransientShell.InvokeRawScript(@"
                Get-CimInstance Win32_OperatingSystem | Select-Object BootDevice,BuildNumber,BuildType,CodeSet,CountryCode,
                CurrentTimeZone,
                FreePhysicalMemory,FreeVirtualMemory,TotalVirtualMemorySize,TotalVisibleMemorySize,
                InstallDate,LastBootUpTime,LocalDateTime,Locale,NumberOfProcesses,NumberOfUsers,Organization,
                OSLanguage,SizeStoredInPagingFiles,SystemDrive,WindowsDirectory
                ");

            OutputCollection = TransientShell.ParsePsObjects(psObjects);
            return OutputCollection;
        }

        public List<Dictionary<string, string>> ScrapeLinux()
        {
            throw new NotImplementedException();
        }

        public List<Dictionary<string, string>> ScrapeOsX()
        {
            throw new NotImplementedException();
        }

        public List<Dictionary<string, string>> ScrapeFreeBsd()
        {
            throw new NotImplementedException();
        }
    }
}