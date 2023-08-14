using PowerScraper.Core.ExtractionTooling.Powershell;
using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Scraping.DataStructure.Collection;

namespace PowerScraper.Core.Scraping.Module.System.Computer
{
    public sealed class ComputerScraper :  IScraper
    {
        public CollectionTree ScrapeWindows(CollectionTree collectionNodeInstance)
        {
            collectionNodeInstance.ModuleName = "Computer";
            // var psObjects = ShellInstance.InvokePsScript(@"
            //     Get-CimInstance Win32_ComputerSystem | Select-Object DNSHostName,Domain,DomainRole,DaylightInEffect,
            //     CurrentTimeZone,AdminPasswordStatus,HypervisorPresent,InfraredSupported,
            //     Manufacturer,Model,Name,PartOfDomain,PrimaryOwnerName,SystemFamily,SystemSKUNumber,SystemType,
            //     TotalPhysicalMemory,UserName");
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