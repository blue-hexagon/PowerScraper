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
            new[] {
            new PropertyItem(Platform.Windows,"DeviceID", "DeviceID", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Linux,  "DeviceID", "DeviceID", false, false, ExtractionTool.Subprocess, "/root/proc/fs/sys01"),
            new PropertyItem(Platform.Windows,"SocketDesignation", "SocketDesignation", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"LoadPercentage", "LoadPercentage", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"Architecture", "Architecture", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"Description", "Description", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"Manufacturer", "Manufacturer", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"Name", "Name", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"NumberOfCores", "NumberOfCores", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"NumberOfLogicalProcessors", "NumberOfLogicalProcessors", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"ThreadCount", "ThreadCount", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"AddressWidth", "AddressWidth", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"DataWidth", "DataWidth", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"L2CacheSize", "L2CacheSize", true, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"L3CacheSize", "L3CacheSize", true, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"MaxClockSpeed", "MaxClockSpeed", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"PowerManagementSupported", "PowerManagementSupported", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"PartNumber", "PartNumber", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"SerialNumber", "SerialNumber", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"VirtualizationFirmwareEnabled", "VirtualizationFirmwareEnabled", false, false, ExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"VMMonitorModeExtensions", "VMMonitorModeExtensions", false, false, ExtractionTool.PowerShell, null),
            },
            new[] {
                new PropertyGroup("Clock",
                    new[] {
                        new ExtractionImplementation("Get-CimInstance Win32_Processor", Platform.Windows, ExtractionTool.PowerShell),
                        new ExtractionImplementation(null, Platform.Linux, ExtractionTool.Bash),
                        new ExtractionImplementation(null, Platform.OsX, ExtractionTool.Bash),
                        new ExtractionImplementation(null, Platform.FreeBsd, ExtractionTool.Bash),
                    },
                    new[] {
                        new PropertyItem(Platform.Windows,"Clock Speed 1", "DeviceID", false, false, ExtractionTool.PowerShell, null),
                        new PropertyItem(Platform.Linux,  "DeviceID", "DeviceID", false, false, ExtractionTool.Subprocess, "/root/proc/fs/sys01"),
                        },
                                new[] {
                        new PropertyGroup("Specs",
                            new[] {
                                new ExtractionImplementation("Get-CimInstance Win32_Processor", Platform.Windows, ExtractionTool.PowerShell),
                                new ExtractionImplementation(null, Platform.Linux, ExtractionTool.Bash),
                                new ExtractionImplementation(null, Platform.OsX, ExtractionTool.Bash),
                                new ExtractionImplementation(null, Platform.FreeBsd, ExtractionTool.Bash),
                            },
                            new[] {
                                new PropertyItem(Platform.Windows,"Clock Specs 1", "DeviceID", false, false, ExtractionTool.PowerShell, null),
                                new PropertyItem(Platform.Linux,  "DeviceID", "DeviceID", false, false, ExtractionTool.Subprocess, "/root/proc/fs/sys01"),
                                },
                            null)
            })
            }
            // @formatter:on
        );

        public CollectionTree ScrapeWindows(CollectionTree collectionNodeInstance)
        {
            collectionNodeInstance.ModuleName = "CPU";
            
            TransientShell.RunPowershellExtraction(_propertyTree, collectionNodeInstance, Platform.Windows, null);

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