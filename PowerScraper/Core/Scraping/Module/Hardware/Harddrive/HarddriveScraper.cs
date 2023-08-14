using PowerScraper.Core.ExtractionTooling.Powershell;
using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Scraping.DataStructure.Collection;
using PowerScraper.Core.Utility.OS;

namespace PowerScraper.Core.Scraping.Module.Hardware.Harddrive
{
    public sealed class HarddriveScraper : IScraper
    {
        private readonly PropertyGroup _propertyTree = new(
            // @formatter:off
            null,
            new[]
            {
                new ExtractionImplementation("Get-CimInstance Win32_LogicalDisk", Platform.Windows, ExtractionTool.PowerShell),
                new ExtractionImplementation(null, Platform.Linux, ExtractionTool.Bash),
                new ExtractionImplementation(null, Platform.OsX, ExtractionTool.Bash),
                new ExtractionImplementation(null, Platform.FreeBsd, ExtractionTool.Bash),
            },
            new List<PropertyItem>() {
                new (Platform.Windows,"DeviceID", "DeviceID", false, false, ExtractionTool.PowerShell, null),
                new (Platform.Windows,"DriveType", "DriveType", false, false, ExtractionTool.PowerShell, null),
                new (Platform.Windows,"ProviderName", "ProviderName", false, false, ExtractionTool.PowerShell, null),
                new (Platform.Windows,"VolumeName", "VolumeName", false, false, ExtractionTool.PowerShell, null),
                new (Platform.Windows,"Size", "Size", true, false, ExtractionTool.PowerShell, null),
                new (Platform.Windows,"FreeSpace", "FreeSpace", true, false, ExtractionTool.PowerShell, null),
            },
            new PropertyItemSequence (new  List<PropertyItem>() {
                new (Platform.Windows,"SDeviceID", "DeviceID", false, false, ExtractionTool.PowerShell, null),
                new (Platform.Windows,"SDriveType", "DriveType", false, false, ExtractionTool.PowerShell, null),
                new (Platform.Windows,"SProviderName", "ProviderName", false, false, ExtractionTool.PowerShell, null),
                new (Platform.Windows,"SVolumeName", "VolumeName", false, false, ExtractionTool.PowerShell, null),
                new (Platform.Windows,"SSize", "Size", true, false, ExtractionTool.PowerShell, null),
                new (Platform.Windows,"SFreeSpace", "FreeSpace", true, false, ExtractionTool.PowerShell, null),
            }),
            null
            // @formatter:on
        );

        public CollectionTree ScrapeWindows(CollectionTree collectionNodeInstance)
        {
            collectionNodeInstance.ModuleName = "Harddrive";

            ShellInstance.RunPowershellExtraction(_propertyTree, collectionNodeInstance, Platform.Windows, null);

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