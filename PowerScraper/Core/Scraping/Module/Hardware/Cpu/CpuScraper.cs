using PowerScraper.Core.ExtractionTooling.Powershell;
using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Scraping.DataStructure.Collection;
using PowerScraper.Core.Utility.OS;

namespace PowerScraper.Core.Scraping.Module.Hardware.Cpu
{
    public sealed class CpuScraper : IScraper
    {
        private readonly PropertyGroup _propertyTree = new(
            // @formatter:off
            null,
            new[]
            {
                new ExtractionImplementation("Get-CimInstance Win32_Processor", Platform.Windows, ExtractionTool.PowerShell),
                new ExtractionImplementation(null, Platform.Linux, ExtractionTool.Bash),
                new ExtractionImplementation(null, Platform.OsX, ExtractionTool.Bash),
                new ExtractionImplementation(null, Platform.FreeBsd, ExtractionTool.Bash),
            },
            new List<PropertyItem>() {
            new (Platform.Windows,"DeviceID", "DeviceID", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Linux,  "DeviceID", "DeviceID", false, false, ExtractionTool.Subprocess, "/root/proc/fs/sys01"),
            new (Platform.Windows,"SocketDesignation", "SocketDesignation", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"LoadPercentage", "LoadPercentage", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"Architecture", "Architecture", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"Description", "Description", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"Manufacturer", "Manufacturer", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"Name", "Name", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"NumberOfCores", "NumberOfCores", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"NumberOfLogicalProcessors", "NumberOfLogicalProcessors", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"ThreadCount", "ThreadCount", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"AddressWidth", "AddressWidth", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"DataWidth", "DataWidth", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"L2CacheSize", "L2CacheSize", true, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"L3CacheSize", "L3CacheSize", true, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"MaxClockSpeed", "MaxClockSpeed", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"PowerManagementSupported", "PowerManagementSupported", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"PartNumber", "PartNumber", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"SerialNumber", "SerialNumber", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"VirtualizationFirmwareEnabled", "VirtualizationFirmwareEnabled", false, false, ExtractionTool.PowerShell, null),
            new (Platform.Windows,"VMMonitorModeExtensions", "VMMonitorModeExtensions", false, false, ExtractionTool.PowerShell, null),
            },
            null,
            new List<PropertyGroup>() {
                new (
                    "Clock",
                    new[] {
                        new ExtractionImplementation("Get-CimInstance Win32_Processor", Platform.Windows, ExtractionTool.PowerShell),
                        new ExtractionImplementation(null, Platform.Linux, ExtractionTool.Bash),
                        new ExtractionImplementation(null, Platform.OsX, ExtractionTool.Bash),
                        new ExtractionImplementation(null, Platform.FreeBsd, ExtractionTool.Bash),
                    },
                    new List<PropertyItem>() {
                        new (Platform.Windows,"Clock Speed 1", "DeviceID", false, false, ExtractionTool.PowerShell, null),
                        new (Platform.Linux,  "DeviceID", "DeviceID", false, false, ExtractionTool.Subprocess, "/root/proc/fs/sys01"),
                        },
                    null,
                    null)
            }
            // @formatter:on
        );

        public CollectionTree ScrapeWindows(CollectionTree collectionNodeInstance)
        {
            collectionNodeInstance.ModuleName = "CPU";

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