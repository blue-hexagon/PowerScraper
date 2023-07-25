using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Scraping.DataStructure.Collection;

namespace PowerScraper.Core.Scraping.Module.System.OS
{
    public sealed class OperatingSystemScraper : AbstractScraper, IScraper
    {
        public CollectionTree ScrapeWindows(CollectionTree collectionNodeInstance)
        {
            collectionNodeInstance.ModuleName = "Operating System";
            var psObjects = TransientShell.InvokeRawScript(@"
                Get-CimInstance Win32_OperatingSystem | Select-Object BootDevice,BuildNumber,BuildType,CodeSet,CountryCode,
                CurrentTimeZone,
                FreePhysicalMemory,FreeVirtualMemory,TotalVirtualMemorySize,TotalVisibleMemorySize,
                InstallDate,LastBootUpTime,LocalDateTime,Locale,NumberOfProcesses,NumberOfUsers,Organization,
                OSLanguage,SizeStoredInPagingFiles,SystemDrive,WindowsDirectory
                ");

            OutputCollection = TransientShell.ParsePsObjects(psObjects);
            return collectionNodeInstance;
        }

        public CollectionTree ScrapeLinux()
        {
            throw new NotImplementedException();
        }

        public CollectionTree ScrapeOsX()
        {
            throw new NotImplementedException();
        }

        public CollectionTree ScrapeFreeBsd()
        {
            throw new NotImplementedException();
        }
    }
}