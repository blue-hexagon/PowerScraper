using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Scraping.DataStructure.Collection;

namespace PowerScraper.Core.Scraping.Module.System.OS
{
    public sealed class OperatingSystemScraper :  IScraper
    {
        public CollectionTree ScrapeWindows(CollectionTree collectionNodeInstance)
        {
            collectionNodeInstance.ModuleName = "Operating System";
            var psObjects = TransientShell.InvokeRawScript(@"
                Get-CimInstance Win32_OperatingSystem | Select-Object BootDevice,BuildNumber,BuildType,CodeSet,CountryCode,
                CurrentTimeZone,
                FreePhysicalMemory,FreeVirtualMemory,TotalVirtualMemorySize,TotalVisibleMemorySize,
                InstallDate,LastBootUpTime,LocalDateTime,Locale,NumberOfProcesses,NumberOfUsers,Organization,
                OSLanguage,SizeStoredInPagingFiles,SystemDrive,WindowsDirectory");

            TransientShell.ParsePsObjectsAndAddItemsToNode(psObjects, null,collectionNodeInstance);
            return collectionNodeInstance;
        }

        public CollectionTree ScrapeLinux(CollectionTree collectionNodeInstance)
        {
            throw new NotImplementedException();
        }

        public CollectionTree ScrapeOsX(CollectionTree collectionNodeInstance)
        {
            throw new NotImplementedException();
        }

        public CollectionTree ScrapeFreeBsd(CollectionTree collectionNodeInstance)
        {
            throw new NotImplementedException();
        }
    }
}