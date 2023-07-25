using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Scraping.DataStructure.Collection;

namespace PowerScraper.Core.Scraping.Module.System.Computer
{
    public sealed class ComputerScraper : AbstractScraper, IScraper
    {
        public CollectionTree ScrapeWindows(CollectionTree collectionNodeInstance)
        {
            collectionNodeInstance.ModuleName = "Computer";
            var psObjects = TransientShell.InvokeRawScript(@"
                Get-CimInstance Win32_ComputerSystem | Select-Object DNSHostName,Domain,DomainRole,DaylightInEffect,
                CurrentTimeZone,AdminPasswordStatus,HypervisorPresent,InfraredSupported,
                Manufacturer,Model,Name,PartOfDomain,PrimaryOwnerName,SystemFamily,SystemSKUNumber,SystemType,
                TotalPhysicalMemory,UserName
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