using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Scraping.DataStructure.Collection;
using PowerScraper.Core.Utility.OS;

namespace PowerScraper.Core.Scraping.Module.Hardware.Cpu
{
    public sealed class CpuScraper : IScraper
    {
        // @formatter:off
        private readonly PropertyGroup _moduleProperties = new(
            "Get-CimInstance",
            new[]{"Win32_Processor"},
            new[]
        {
            new PropertyItem(Platform.Windows,"DeviceID", "DeviceID", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Linux,  "DeviceID", "DeviceID", false, false, DataExtractionTool.UnspecifiedSubprocess, "/root/proc/fs/sys01"),

            new PropertyItem(Platform.Windows,"SocketDesignation", "SocketDesignation", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"LoadPercentage", "LoadPercentage", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"Architecture", "Architecture", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"Description", "Description", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"Manufacturer", "Manufacturer", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"Name", "Name", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"NumberOfCores", "NumberOfCores", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"NumberOfLogicalProcessors", "NumberOfLogicalProcessors", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"ThreadCount", "ThreadCount", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"AddressWidth", "AddressWidth", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"DataWidth", "DataWidth", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"L2CacheSize", "L2CacheSize", true, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"L3CacheSize", "L3CacheSize", true, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"MaxClockSpeed", "MaxClockSpeed", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"PowerManagementSupported", "PowerManagementSupported", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"PartNumber", "PartNumber", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"SerialNumber", "SerialNumber", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"VirtualizationFirmwareEnabled", "VirtualizationFirmwareEnabled", false, false, DataExtractionTool.PowerShell, null),
            new PropertyItem(Platform.Windows,"VMMonitorModeExtensions", "VMMonitorModeExtensions", false, false, DataExtractionTool.PowerShell, null),
            // new PropertyMap("Clock",
            // new List<PropertyItem>() {
                // new PropertyItem(Platform.Windows,"Core 1" ,"", false, false,DataExtractionTool.PowerShell, null),
            // }),
        });
        // @formatter:on

        public CollectionTree ScrapeWindows(CollectionTree collectionNodeInstance)
        {
            collectionNodeInstance.ModuleName = "CPU";
            TransientShell.RunPowershellExtraction(_moduleProperties, collectionNodeInstance, Platform.Windows);

            var clockNode = new CollectionTree("Clock");
            clockNode.AddItem("Core 1", "2840 MHz");
            clockNode.AddItem("Core 2", "2841 MHz");
            clockNode.AddItem("Core 3", "2840 MHz");
            clockNode.AddItem("Core 4", "1839 MHz");

            collectionNodeInstance.Nodes.Add(clockNode);

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