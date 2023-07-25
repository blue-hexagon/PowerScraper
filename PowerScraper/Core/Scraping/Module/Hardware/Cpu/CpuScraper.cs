using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Scraping.DataStructure.Collection;

namespace PowerScraper.Core.Scraping.Module.Hardware.Cpu
{
    public sealed class CpuScraper : AbstractScraper, IScraper
    {
        public CollectionTree ScrapeWindows(CollectionTree collectionNodeInstance)
        {
            collectionNodeInstance.ModuleName = "CPU";
            var psObjects = TransientShell.InvokeRawScript(@"
                Get-CimInstance Win32_Processor | Select-Object DeviceID,SocketDesignation, LoadPercentage,
                Architecture,Description,
                Manufacturer,Name,NumberOfCores,NumberOfLogicalProcessors,ThreadCount, AddressWidth, DataWidth,
                L2CacheSize,L3CacheSize, MaxClockSpeed,PowerManagementSupported,
                PartNumber,SerialNumber,VirtualizationFirmwareEnabled,VMMonitorModeExtensions");
            
            OutputCollection = TransientShell.ParsePsObjects(psObjects);
            // TODO/FIX
            // TEMPORARY SOLUTION - We iterating over the collection twice
            // Once in the above line of code, and once in the below loops
            foreach (var item in OutputCollection)
            {
                foreach (var k in item)
                {
                    collectionNodeInstance.AddItem(k.Key, k.Value);
                }
            }

            var col = new CollectionTree("Clock");
            col.AddItem("Core 1", "2840 MHz");
            col.AddItem("Core 2", "2841 MHz");
            col.AddItem("Core 3", "2840 MHz");
            col.AddItem("Core 4", "1839 MHz");

            collectionNodeInstance.Nodes.Add(col);

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