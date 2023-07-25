using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Scraping.DataStructure.Collection;

namespace PowerScraper.Core.Scraping.Module.Hardware.Harddrive
{
    public sealed class HarddriveScraper : AbstractScraper, IScraper
    {
        public CollectionTree ScrapeWindows(CollectionTree collectionNodeInstance)
        {
            collectionNodeInstance.ModuleName = "Harddrive";
            var psObjects = TransientShell.InvokeRawScript(@"
                Get-CimInstance Win32_LogicalDisk | Select-Object DeviceID, DriveType, ProviderName, VolumeName, Size, FreeSpace");
            TransientShell.ParsePsObjects(psObjects, collectionNodeInstance);

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